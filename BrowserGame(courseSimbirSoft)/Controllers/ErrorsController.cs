using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BrowserGame_courseSimbirSoft_.Views.Error;
using Microsoft.AspNetCore.Mvc;

namespace BrowserGame_courseSimbirSoft_.Controllers
{

    public class ErrorsController : Controller
    {
        public new int StatusCode { get; }
        public IActionResult Index()
        {
            return View("Error");
        }

        public IActionResult Error(int? id, int statusCode = 404)
        {
            switch (statusCode)
            {
                case 404:
                    return View("Error404");
                case 401:
                    return View("Error401");
                case 403:
                    return View("Error403");
                case 500:
                    return View("Error500");
                default:
                    return null;
            }
        }
    }
}
