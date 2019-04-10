using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrowserGame_courseSimbirSoft_.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using DataLogicLayer.Data;

namespace BrowserGame_courseSimbirSoft_.Controllers
{
    /// <summary>
    /// основной контроллер
    /// </summary>
    public class HomeController : Controller
    {


        [HttpGet]
        /// <summary>
        /// получаем начальную страница
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            return View("Index");
        }

        [HttpGet]
        /// <summary>
        /// получаем страницу кондифциальности
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View("Privacy");
        }
    }
}
