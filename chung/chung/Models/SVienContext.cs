using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace chung.Models
{
    public partial class SVienContext : DbContext
    {
        public SVienContext()
        {
        }

        public SVienContext(DbContextOptions<SVienContext> options)
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
                optionsBuilder.UseSqlServer("Server=localhost;Database=SVien; User ID=SA; Password=KenChung123@;Trusted_Connection=True; Integrated Security=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.GioiTinh)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.IdLop).HasColumnName("Id_Lop");

                entity.HasOne(d => d.IdLopNavigation)
                    .WithMany(p => p.SinhVien)
                    .HasForeignKey(d => d.IdLop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SinhVien__Id_Lop__38996AB5");
            });
        }
    }
}
