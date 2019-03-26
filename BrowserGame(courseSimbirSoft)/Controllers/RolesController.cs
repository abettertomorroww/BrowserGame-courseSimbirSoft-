using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BrowserGame_courseSimbirSoft_.Models;
using DataLogicLayer.Models;
using BrowserGame_courseSimbirSoft_.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrowserGame_courseSimbirSoft_.Controllers
{

    /// <summary>
    /// контролер ролей
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// возвращаем список с ролями
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index() => View(_roleManager.Roles.ToList());

        /// <summary>
        /// выводим страницу для создания ролей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create() => View();

        /// <summary>
        /// возвращаем метод создания ролей
        /// </summary>
        /// <param name="name">имя персонажа</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        /// <summary>
        /// удаление ролей
        /// </summary>
        /// <param name="id">индификатор персонажа</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            if (role == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// получаем страницу с списком пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UserList() => View(_userManager.Users.ToList());

        /// <summary>
        /// получаем страницу для изменения ролей
        /// </summary>
        /// <param name="userId">индификатор пользователя</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(string userId)
        {
            IdentityUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        /// <summary>
        /// редактирование ролей
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            IdentityUser user = await _userManager.FindByIdAsync(userId);
            if (roles == null)
            {
                return NotFound();
            }
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);
                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);
                return RedirectToAction("UserList");
            }

            return NotFound();
        }
    }
}
