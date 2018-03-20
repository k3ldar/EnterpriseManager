using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Website.Library.Core.Controllers;
using Website.Library.Core.Classes;

using Shifoo.Systems.Website.Models;

namespace Shifoo.Systems.Website.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            LocalWebSessionData localData = GetWebSessionData();
            long time = (long)HttpContext.Items["UserSessionTimings"];
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
