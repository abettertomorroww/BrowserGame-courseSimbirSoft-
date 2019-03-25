using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrowserGame_courseSimbirSoft_.Models;
using BrowserGame_courseSimbirSoft_.ViewModels;
using BrowserGame_courseSimbirSoft_.Services;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace BrowserGame_courseSimbirSoft_.Controllers
{

    /// <summary>
    /// управление персонажами
    /// </summary>
    [Authorize]
    public class CharactersController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICharacterServices _char;

        public CharactersController(ILogger<CharactersController> logger, ICharacterServices chara)
        {
            _logger = logger;
            _char = chara;
        }


        /// <summary>
        /// получаем список персонажей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("Index", await this._char.GetCharacter(HttpContext.User.Identity.Name));
        }

        /// <summary>
        /// ин-фо о персонаже
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characters = await _char.GetDetails((int)id);

            if (characters == null)
            {
                return NotFound();
            }

            if (characters.User != HttpContext.User.Identity.Name || characters.User == "Default")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(characters);
        }

        /// <summary>
        /// страница для создания персонажа
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// создание персонажа
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Character character)

        {
            if (character.Name.Length < 2 || character.Name.Length > 20)
            {
                ModelState.AddModelError("Name", "The length of the string must be between 2 to 20 characters");
            }

            if (_char.EqualChar(character.Name, "add", null).Count() > 0)
            {
                ModelState.AddModelError("Name", "Error");
            }

            if (ModelState.IsValid)
            {
                var name = HttpContext.User.Identity.Name;

                var charsId = await _char.CreateChar(character, name, "add");
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        /// <summary>
        /// страница редактирования персонажа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _char.GetDetails((int)id);

            if (character == null)
            {
                return NotFound();
            }

            if (character.User != HttpContext.User.Identity.Name || character.User == "Default")
            {
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }


        /// <summary>
        /// редактирование персонажа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Transform")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Character character)
        {

            if (id != character.Id)
            {
                return NotFound();
            }

            if (_char.EqualChar(character.Name, "update", character.Id).Count() > 0)
            {
                ModelState.AddModelError("Name", "A character with that name is employ!");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _char.CreateChar(character, HttpContext.User.Identity.Name, "update");
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }


        /// <summary>
        /// страница удаления персонажа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _char.GetDetails((int)id);

            if (character == null)
            {
                return NotFound();
            }

            if (character.User != HttpContext.User.Identity.Name || character.User == "Default")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(character);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _char.DeleteCharacterAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
