﻿using Microsoft.AspNetCore.Mvc;

namespace exampleone.Controllers
{
    public class Controller1 : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}