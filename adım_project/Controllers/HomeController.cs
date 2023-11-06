using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace adım_project.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        AdressManager adressManager = new AdressManager(new EfAdressDal());
        MVCFormDataManager mVCFormDataManager = new MVCFormDataManager(new EfMVCFormDataDal());
        private readonly UserManager<AppUser> _userManager;

        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Default()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Default(Adress adress)
        {
            //Login olmuş kullanıcını verilerine getiryor
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            //Adress modelindeki userId alanın birbrine bağlıyor
            adress.AppUserID = value.Id;
            //kaydediyor
            adressManager.TAdd(adress);
            return RedirectToAction("Default");
        }

        [HttpPost]
        public async Task<ActionResult> PostMetaDataAsync([FromBody] List<MVCFormData> mVCFormData)
        {
            try
            {
                var value = await _userManager.FindByNameAsync(User.Identity.Name);
                foreach (var item in mVCFormData)
                {

                    item.AppUserID = value.Id;
                }

                mVCFormDataManager.TAddList(mVCFormData);

                // Başarılı yanıt döndür
                return Ok(new { message = "Veri başarıyla işlendi." });
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun yanıt döndür
                return BadRequest(new { message = "İşleme sırasında hata oluştu: " + ex.Message });
            }
        }



        [HttpGet]
        public async Task<IActionResult> DefaultCopyAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            //Veri tabanında veri al
            List<MVCFormData> values = await mVCFormDataManager.TGetListUserId(user);
            if (values.Count > 0)
            {
                //Veriyi jsona çevir ve viwebag ile asyfaya gönder
                var formDataJson = JsonConvert.SerializeObject(values);
                ViewData["FormDataJson"] = formDataJson;
                return View();

            }
            return RedirectToAction("Default");

        }


    }
}
