using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HeThongNhaSach.Models
{
    public partial class HeThongNhaSachContext : DbContext
    {
        public HeThongNhaSachContext()
        {
        }

        public HeThongNhaSachContext(DbContextOptions<HeThongNhaSachContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitiethd> Chitiethd { get; set; }
        public virtual DbSet<Chucvu> Chucvu { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Loaisach> Loaisach { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Nhasach> Nhasach { get; set; }
        public virtual DbSet<Nhaxuatban> Nhaxuatban { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<Sachnhasach> Sachnhasach { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database= #HeThongNhaSach; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitiethd>(entity =>
            {
                entity.HasKey(e => new { e.Mahd, e.Masach })
                    .HasName("PK__CHITIETH__BEDDB9609818ADA7");

                entity.ToTable("CHITIETHD");

                entity.HasOne(d => d.MahdNavigation)
                    .WithMany(p => p.Chitiethd)
                    .HasForeignKey(d => d.Mahd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETHD__Mahd__1FCDBCEB");

                entity.HasOne(d => d.MasachNavigation)
                    .WithMany(p => p.Chitiethd)
                    .HasForeignKey(d => d.Masach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETHD__Masac__20C1E124");
            });

            modelBuilder.Entity<Chucvu>(entity =>
            {
                entity.HasKey(e => e.Macv)
                    .HasName("PK__CHUCVU__2724823E870A9CAD");

                entity.ToTable("CHUCVU");

                entity.Property(e => e.Matkhau)
                 .HasMaxLength(40)
                 .IsUnicode(false)
                 .IsFixedLength();

                entity.Property(e => e.Taikhoan)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Tencv).HasMaxLength(250);
               
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahd)
                    .HasName("PK__HOADON__27249AA8C764A7F1");

                entity.ToTable("HOADON");

                entity.Property(e => e.Manv).HasMaxLength(5);

                entity.Property(e => e.Ngaylap).HasColumnType("date");
            });

            modelBuilder.Entity<Loaisach>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__LOAISACH__3E1DB46D48116CD3");

                entity.ToTable("LOAISACH");

                entity.Property(e => e.Tenloai).HasMaxLength(250);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv)
                    .HasName("PK__NHANVIEN__2724CB0293585E45");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Manv).HasMaxLength(5);

                entity.Property(e => e.Diachi).HasMaxLength(250);

                entity.Property(e => e.Hoten).HasMaxLength(250);

                entity.Property(e => e.Matkhau)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ngaysinh).HasColumnType("date");

                entity.HasOne(d => d.MacvNavigation)
                    .WithMany(p => p.Nhanvien)
                    .HasForeignKey(d => d.Macv)
                    .HasConstraintName("FK__NHANVIEN__Macv__1273C1CD");
            });

            modelBuilder.Entity<Nhasach>(entity =>
            {
                entity.HasKey(e => e.Mans)
                    .HasName("PK__NHASACH__2724CB0FFFAFC2F3");

                entity.ToTable("NHASACH");

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Std)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Tenns)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Nhaxuatban>(entity =>
            {
                entity.HasKey(e => e.Manxb)
                    .HasName("PK__NHAXUATB__339E50421BA14972");

                entity.ToTable("NHAXUATBAN");

                entity.Property(e => e.Diachi).HasMaxLength(250);

                entity.Property(e => e.Sdt).HasMaxLength(11);

                entity.Property(e => e.Tennxb).HasMaxLength(250);
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.Masach)
                    .HasName("PK__SACH__9F923C88C725F4D6");

                entity.ToTable("SACH");

                entity.Property(e => e.Isbn).HasMaxLength(250);

                entity.Property(e => e.Manv).HasMaxLength(5);

                entity.Property(e => e.Tacgia).HasMaxLength(250);

                entity.Property(e => e.Tensach).HasMaxLength(250);

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK__SACH__Maloai__1920BF5C");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK__SACH__Manv__1A14E395");

                entity.HasOne(d => d.ManxbNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.Manxb)
                    .HasConstraintName("FK__SACH__Manxb__1B0907CE");
            });

            modelBuilder.Entity<Sachnhasach>(entity =>
            {
                entity.HasKey(e => new { e.Mans, e.Masach })
                    .HasName("PK__SACHNHAS__BEDDE8C7ED76F84A");

                entity.ToTable("SACHNHASACH");

                entity.HasOne(d => d.MansNavigation)
                    .WithMany(p => p.Sachnhasach)
                    .HasForeignKey(d => d.Mans)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SACHNHASAC__Mans__25869641");

                entity.HasOne(d => d.MasachNavigation)
                    .WithMany(p => p.Sachnhasach)
                    .HasForeignKey(d => d.Masach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SACHNHASA__Masac__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
