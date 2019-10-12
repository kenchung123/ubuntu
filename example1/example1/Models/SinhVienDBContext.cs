using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace example1.Models
{
    public partial class SinhVienDBContext : DbContext
    {
        public SinhVienDBContext()
        {
        }

        public SinhVienDBContext(DbContextOptions<SinhVienDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lop> Lop { get; set; }
        public virtual DbSet<SinhVien> SinhVien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=SinhVienDB; User ID=SA; Password=KenChung123@;Trusted_Connection=True; Integrated Security=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.Property(e => e.TenLop)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(30);
            });
        }
    }
}
