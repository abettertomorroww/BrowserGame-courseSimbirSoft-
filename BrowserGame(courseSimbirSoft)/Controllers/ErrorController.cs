using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrowserGame_courseSimbirSoft_.Models;
using System.Diagnostics;

namespace BrowserGame_courseSimbirSoft_.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View("Error");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? id)
        {
            if (id == 404)
            {
                return View("404error");
            }
            else if (id == 401)
            {
                return View("401error");
            }
            else if(id == 403)
            {
                return View("403error");
            }
            else if (id == 500)
            {
                return View("500error");
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
