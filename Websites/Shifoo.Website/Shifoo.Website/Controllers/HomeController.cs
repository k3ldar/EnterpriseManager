using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shifoo.Website.Models;
using Shifoo.Website.Global;

namespace Shifoo.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewResult result = View();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            HttpContext.Session.Set<string>("test", "hello");
            return View();
        }

        public IActionResult Contact()
        {
            string s = HttpContext.Session.Get<string>("test");
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
