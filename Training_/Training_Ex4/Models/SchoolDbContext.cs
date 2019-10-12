using Microsoft.EntityFrameworkCore;

namespace Training_Ex4.Models
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options, DbSet<Student> students) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; } 
         DbSet<Class> Classes { get; set; }
    }

}