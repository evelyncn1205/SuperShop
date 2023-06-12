﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SuperShop2.Helpers;
using SuperShop2.Models;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SuperShop2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        public AccountController(IUserHelper userHelper)
        {
            _userHelper =   userHelper;
        }

        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<IActionResult> Loginout()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if(result.Succeeded)
                {
                    if(this.Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(this.Request.Query["ReturnUrl"].First());
                    }
                    return this.RedirectToAction("Index", "Home");
                }
            }
            this.ModelState.AddModelError(string.Empty, "Failed to login");
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {                     
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
                        
        }

    }
}
