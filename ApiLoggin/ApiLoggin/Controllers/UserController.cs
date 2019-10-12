using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiLoggin.Models;

namespace ApiLoggin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;

            if (_context.User.Count() == 0)
            {
                _context.User.Add(new  LogginModel {UserNamme = "Item3", Password = "Item2"});
             
                _context.SaveChanges();
            }
        }

        
        public enum ValueType
        {
            Number,
            Text
        }
    }
}