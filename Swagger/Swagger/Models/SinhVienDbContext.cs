using Microsoft.EntityFrameworkCore;

namespace Swagger.Models
{
    public class SinhVienDbContext : DbContext
    {
        public SinhVienDbContext(DbContextOptions<SinhVienDbContext> options) : base(options)
        {}
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<UserModel> User { get; set; }
    }
}