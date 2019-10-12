using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using Swagger.Models;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Swagger.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger){
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            _logger.LogInformation("Log message in the Index() method");

            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Log message in the About() method");           
            return View();
        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}