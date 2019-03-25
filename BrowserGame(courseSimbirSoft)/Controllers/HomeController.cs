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
    public class HomeController : Controller
    {


        [HttpGet]
        /// <summary>
        /// начальная страница
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        /// <summary>
        /// страница кондифциальности
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// страница логов
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Logs()
        {
            return View();
        }

        /// <summary>
        /// обработка ошибок
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult Error(int? id)
        {
            switch (id)
            {
                case 404:
                    return View("Error404");
                case 500:
                    return View("Error500");
                case 401:
                    return View("Error401");
                case 403:
                    return View("Error403");
                default:
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
