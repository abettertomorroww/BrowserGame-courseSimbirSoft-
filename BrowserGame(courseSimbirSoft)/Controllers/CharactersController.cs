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
    /// контроллер управления персонажем
    /// </summary>
    [Authorize]
    public class CharactersController : Controller
    {
        private readonly ICharacterServices _character;

        public CharactersController(ICharacterServices characters)
        {
            _character = characters;
        }


        /// <summary>
        /// возвращает список персонажей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("Index", await this._character.GetCharacter(HttpContext.User.Identity.Name));
        }

        /// <summary>
        /// возвращает информацию о персонаже
        /// </summary>
        /// <param name="id">индификатор персонажа</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characters = await _character.GetDetails(id.Value);

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
        /// <param name="character">персонаж</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Character character)

        {
            if (ModelState.IsValid)
            {
                await _character.CreateChar(character);
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        /// <summary>
        /// страница редактирования персонажаконсоль
        /// </summary>
        /// <param name="id">индификатор персонажа</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _character.GetDetails((int)id);

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _character.UpdateChar(character);
                }
                catch (DbUpdateConcurrencyException)
                {
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }



        /// <summary>
        /// получаем страницу удаления персонажа
        /// </summary>
        /// <param name="id">индификатор персонажа</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _character.GetDetails((int)id);

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
        /// удаление персонажа 
        /// </summary>
        /// <param name="id">индификатор персонажа</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _character.DeleteCharacterAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
