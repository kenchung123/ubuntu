using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)  
        {  
        }  
  
        DbSet<User> User { get; set; }  
    }
}