using Microsoft.EntityFrameworkCore;

namespace Example_3.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)  
        {  
        }  
  
        DbSet<User> User { get; set; }  
    }
}