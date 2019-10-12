using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Swagger.Models;

namespace Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly SinhVienDbContext _context;

        public UserController(SinhVienDbContext context)
        {
            _context = context;

            if (!EnumerableExtensions.Any(_context.User))
            {
                _context.User.Add(new UserModel() {UserName = "kenchung"});
                _context.SaveChanges();
            }
        }
       
    }
}