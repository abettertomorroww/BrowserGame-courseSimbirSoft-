using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrowserGame_courseSimbirSoft_.Models;
using Microsoft.Extensions.Logging;

namespace BrowserGame_courseSimbirSoft_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;

        public IActionResult Index()
        {
            //this.logger.LogCritical("Critical Error");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //public HomeController(ILogger logger)
        //{
        //    this.logger = logger;
        //}
    }
}
