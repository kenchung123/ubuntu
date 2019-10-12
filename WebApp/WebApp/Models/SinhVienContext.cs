using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp.Models
{
    public partial class SinhVienContext : DbContext
    {
        public SinhVienContext()
        {
        }

        public SinhVienContext(DbContextOptions<SinhVienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sv> Sv { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=SinhVien; User ID=SA; Password=KenChung123@;Trusted_Connection=True; Integrated Security=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Sv>(entity =>
            {
                entity.ToTable("SV");

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(30);
            });
        }
    }
}
