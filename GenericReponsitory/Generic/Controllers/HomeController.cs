﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Example_04.Models;
using Example_04.Services;

namespace Example_04.Controllers
{
    public class HomeController : Controller
    {
         
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
     
//        public IActionResult Delete()
//        {
//            return View();
//        }
//        public IActionResult Update()
//        {
//            return View();
//        }
//        public IActionResult Create()
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