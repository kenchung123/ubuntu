using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ApiLoggin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiLoggin.Service
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _context;
        public UserService(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogginModel>>> GetUser()
        {       
            return await _context.User.ToListAsync();      
        }

        [HttpPost]
        public async Task<ActionResult>  PostUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            { 
                return StatusCode((int)HttpStatusCode.BadRequest,("username or password is null")); 
            }

            var user = _context.User.Where(x => x.UserNamme == username).FirstOrDefault<LogginModel>();
            if (user == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest,("Invalid Login"));
            }          
            if (user.Password.Equals(password)==false )
            {
                return StatusCode((int)HttpStatusCode.BadRequest,("Password is false"));
            }
            
            return StatusCode((int)HttpStatusCode.OK,("Sucess !!!"));
        }
        [HttpPut]
        public async Task<ActionResult<LogginModel>> ChangePassword( string usename ,string oldpass , string newpass)
        {
            var use = await _context.User.FindAsync(usename);
            if (use == null)
            {
                return BadRequest();
            }
            if (use.Password.Equals(oldpass) == false)
            {
                return BadRequest();
            }

            use.Password = newpass;
            try{
           
                _context.User.Update(use);
                await _context.SaveChangesAsync();
                return NotFound();

            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.BadRequest, e);

            }

        }
    }
}