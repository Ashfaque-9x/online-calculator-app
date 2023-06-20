using calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace calculator.Controllers
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
        [HttpPost]
        public IActionResult Index(Calculator cal)
        {
            Double a = cal.value1;
            Double b = cal.value2;
            cal.Result = a + b;
            if(cal.calculate == "add")
            {
                cal.Result = a + b;
            }
            else if( cal.calculate=="sub")
            {
                cal.Result = a - b;
            }
            else if( cal.calculate=="mul")
            {
                cal.Result = a * b;
            }
            else if(cal.calculate=="divi")
            {
                if (b == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }

                cal.Result = a / b;
            }
            ViewData["result"] = cal.Result;
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
    }
}
