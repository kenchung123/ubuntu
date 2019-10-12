using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training_Ex4.Models;
using Training_Ex4.Services;
namespace Training_Ex4.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentRepository _studentRepository;
 
        public HomeController( StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
//        public IActionResult Insert()
//        {
//            return View();
//        }
//        public IActionResult Delete()
//        {
//            return View();
//        }
//        public IActionResult Update()
//        {
//            return View();
//        }

//        public IActionResult GetAll()
//        {
//         
//        }
        }
    }