using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using clicker_mvp_test.Models;

namespace clicker_mvp_test.Controllers
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
            if(HttpContext.Session.GetInt32("TotalNumber") is null){
                HttpContext.Session.SetInt32("TotalNumber", 0);
                HttpContext.Session.SetInt32("ClickNumber", 1);
            }
            int? TotalNumber = HttpContext.Session.GetInt32("TotalNumber");
            int? ClickNumber = HttpContext.Session.GetInt32("ClickNumber");

            TotalNumber = (int)TotalNumber;
            ClickNumber = (int)ClickNumber;

            ViewBag.TotalNumber = TotalNumber;
            return View("Index");
        }
        [HttpPost]
        [Route("Click")]
        public IActionResult Click()
        {
            int? TotalNumber = HttpContext.Session.GetInt32("TotalNumber");
            int? ClickNumber = HttpContext.Session.GetInt32("ClickNumber");

            TotalNumber += ClickNumber;
            
            HttpContext.Session.SetInt32("TotalNumber", (int)TotalNumber);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Donate()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
