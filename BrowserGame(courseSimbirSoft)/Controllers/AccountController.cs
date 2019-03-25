using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrowserGame_courseSimbirSoft_.Models;
using BrowserGame_courseSimbirSoft_.ViewModels;
using BrowserGame_courseSimbirSoft_.Services;
using DataLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BrowserGame_courseSimbirSoft_.Services.Implementation;

namespace BrowserGame_courseSimbirSoft_.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<UserData> _userManager;
        private readonly SignInManager<UserData> _signInManager;


        public AccountController(UserManager<UserData> userManager, SignInManager<UserData> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// страница регистрации
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserData user = new UserData { Email = model.Email, UserName = model.Password };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}