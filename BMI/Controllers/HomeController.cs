using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BMI.Models;

namespace BMI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getData()
        {
            userViewModel model = new userViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult displayBMI(string f, string l, string g, int m, int d, int y, int w, int h)
        {
            userViewModel model = new userViewModel(f,l,g,m,d,y,h,w);
            if (!ModelState.IsValid)
            {
                return RedirectToAction("getData", model);
            }
            DateTime bd = new DateTime((int)model.y, (int)model.m, (int)model.d);
            model.age = DateTime.Now - bd;
            model.bmi = (int)((model.w / Math.Pow(h, 2)) * 703);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult chart()
        {
            return View();
        }
    }
}
