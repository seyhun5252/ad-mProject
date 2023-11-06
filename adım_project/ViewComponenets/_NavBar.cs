using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace adım_project.ViewComponenets
{
    public class _NavBar : ViewComponent
    {
        MVCFormDataManager mVCFormDataManager = new MVCFormDataManager(new EfMVCFormDataDal());
        private readonly UserManager<AppUser> _userManager;

        public _NavBar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = mVCFormDataManager.GetByFilter(x => x.AppUserID == user.Id);
            bool isCopy = true;
            if (values.Count > 0)
            {
                ViewBag.IsActive = isCopy;

            }
            else
            {
                ViewBag.IsActive = !isCopy;
            }
            return View();
        }
    }
}
