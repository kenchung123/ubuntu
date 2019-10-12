using Microsoft.EntityFrameworkCore;

namespace Bai04.Models
{
    public class Bai4DbContext : DbContext
    {
        public Bai4DbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}