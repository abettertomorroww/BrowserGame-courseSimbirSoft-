using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrowserGame_courseSimbirSoft_.Data;
using BrowserGame_courseSimbirSoft_.Models;


namespace BrowserGame_courseSimbirSoft_.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharactersController(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewData["ClassSortParm"] = sortOrder == "Class" ? "date_desc" : "Class";
            ViewData["CurrentFilter"] = searchString;

            var characters = from s in _context.Characters
                             select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                characters = characters.Where(s => s.Name.Contains(searchString) || s.Race.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name":
                    characters = characters.OrderByDescending(s => s.Name);
                break;
                case "Class":
                    characters = characters.OrderBy(s => s.Class);
                    break;
                case "date_desc":
                    characters = characters.OrderByDescending(s => s.Class);
                    break;
                default:
                    characters = characters.OrderBy(s => s.Name);
                    break;
            }
            return View(await characters.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Information(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var character = await _context.Characters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Character character)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(character);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Невозможно сохранить изменения. " +
                                   "Повторите попытку, и если проблема не устранена, " +
            "обратитесь к системному администратору.");
            }
            return View(character);
        }
        public async Task<IActionResult> Transform(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        [HttpPost, ActionName("Transform")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TransformPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await _context.Characters.SingleOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Character>(
                studentToUpdate,
                "",
                s => s.Name, s => s.Race, s => s.Ability, s => s.Class))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Невозможно сохранить изменения. " +
                        "Повторите попытку, и если проблема не устранена, " +
 "обратитесь к системному администратору.");
                }
            }
            return View(studentToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Characters
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Ошибка удаления. Попробуйте еще раз, и если проблема не устранена " +
 "обратитесь к системному администратору.";
            }

            return View(student);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Characters
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Characters.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}
