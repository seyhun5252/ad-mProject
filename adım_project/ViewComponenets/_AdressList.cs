﻿using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace adım_project.ViewComponenets
{
    [Authorize]
    public class _AdressList : ViewComponent
    {
        AdressManager adressManager = new AdressManager(new EfAdressDal());
        private readonly UserManager<AppUser> _userManager;

        public _AdressList(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var values = adressManager.TGetList();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = adressManager.GetByFilter(x=>x.AppUserID == user.Id);
            return View(values);
        }
    }
}
