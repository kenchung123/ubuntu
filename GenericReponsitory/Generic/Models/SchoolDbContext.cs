using System.Collections.Generic;
using Example_04.Services;
using Microsoft.EntityFrameworkCore;

namespace Example_04.Models
{
    public class SChoolDbContext : DbContext
    {
         public SChoolDbContext(DbContextOptions options) : base(options)
                {
                }

        public DbSet<Student> Students { get; set; } 
        public  DbSet<Class> Classes { get; set; }
    }
}