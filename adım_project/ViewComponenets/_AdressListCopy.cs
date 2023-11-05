using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace adım_project.ViewComponenets
{
    public class _AdressListCopy : ViewComponent
    {
        AdressManager adressManager = new AdressManager(new EfAdressDal());
        private readonly UserManager<AppUser> _userManager;

        public _AdressListCopy(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = adressManager.GetByFilter(x => x.AppUserID == user.Id);
            return View(values);
        }
    }
}
