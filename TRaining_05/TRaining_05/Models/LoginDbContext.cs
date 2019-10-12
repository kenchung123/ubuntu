using Microsoft.EntityFrameworkCore;

namespace TRaining_05.Models
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions options) : base(options)
        {           
        }

        private DbSet<Login> DangNhap { get; set; }
    }
}