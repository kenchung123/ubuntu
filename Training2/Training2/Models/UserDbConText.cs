using Microsoft.EntityFrameworkCore;

namespace Training2.Models
{
    public class UserDbConText : DbContext
    {
        public UserDbConText(DbContextOptions options) : base(options)  
        {  
        }  
  
        DbSet<User> User { get; set; }  
    }
}