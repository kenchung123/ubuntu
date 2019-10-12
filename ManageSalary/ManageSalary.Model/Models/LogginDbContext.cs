using System.Collections.Generic;
//using Example_04.Services;
using Microsoft.EntityFrameworkCore;

namespace ManageSalary.Models
{
    public class LogginDbContext : DbContext
    {
          public LogginDbContext(DbContextOptions options) : base(options)
                 {
                 }
                public DbSet<Loggin> DangNhap{ get; set; } 
           
    }
}