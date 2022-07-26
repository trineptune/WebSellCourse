using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library_Class.Entities
{
    public partial class pdkladykillah_eLearningContext : DbContext
    {
        public pdkladykillah_eLearningContext()
        {
        }

        public pdkladykillah_eLearningContext(DbContextOptions<pdkladykillah_eLearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaiHoc> BaiHocs { get; set; } = null!;
        public virtual DbSet<ChiTietDatHang> ChiTietDatHangs { get; set; } = null!;
        public virtual DbSet<DangKy> DangKies { get; set; } = null!;
        public virtual DbSet<DanhGiaKhoaHoc> DanhGiaKhoaHocs { get; set; } = null!;
        public virtual DbSet<DatHang> DatHangs { get; set; } = null!;
        public virtual DbSet<GiangVien> GiangViens { get; set; } = null!;
        public virtual DbSet<GioHang> GioHangs { get; set; } = null!;
        public virtual DbSet<HocVien> HocViens { get; set; } = null!;
        public virtual DbSet<KhoaHocOnline> KhoaHocOnlines { get; set; } = null!;
        public virtual DbSet<NganhHoc> NganhHocs { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;
        public virtual DbSet<ThongTinKhoaHoc> ThongTinKhoaHocs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=sql.bsite.net\\MSSQL2016;user Id=pdkladykillah_eLearning;password=Ayenl1206;database=pdkladykillah_eLearning");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiHoc>(entity =>
            {
                entity.ToTable("BaiHoc");

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.IdKhoaHocOnlineNavigation)
                    .WithMany(p => p.BaiHocs)
                    .HasForeignKey(d => d.IdKhoaHocOnline)
                    .HasConstraintName("FK_BaiHoc_KhoaHocOnline");
            });

            modelBuilder.Entity<ChiTietDatHang>(entity =>
            {
                entity.HasKey(e => e.IdDatHang);

                entity.ToTable("ChiTietDatHang");

                entity.Property(e => e.GiaKhoaHoc).HasColumnType("money");

                entity.HasOne(d => d.IdKhoaHocOnlineNavigation)
                    .WithMany(p => p.ChiTietDatHangs)
                    .HasForeignKey(d => d.IdKhoaHocOnline)
                    .HasConstraintName("FK_ChiTietDatHang_KhoaHocOnline");
            });

            modelBuilder.Entity<DangKy>(entity =>
            {
                entity.ToTable("DangKy");

                entity.Property(e => e.NgayDangKy).HasColumnType("datetime");

                entity.Property(e => e.ThanhTien).HasColumnType("money");

                entity.HasOne(d => d.IdHocVienNavigation)
                    .WithMany(p => p.DangKies)
                    .HasForeignKey(d => d.IdHocVien)
                    .HasConstraintName("FK_DangKy_HocVien");

                entity.HasOne(d => d.IdKhoaHocOnlineNavigation)
                    .WithMany(p => p.DangKies)
                    .HasForeignKey(d => d.IdKhoaHocOnline)
                    .HasConstraintName("FK_DangKy_KhoaHocOnline");
            });

            modelBuilder.Entity<DanhGiaKhoaHoc>(entity =>
            {
                entity.ToTable("DanhGiaKhoaHoc");

                entity.Property(e => e.NgayDanhGia).HasColumnType("datetime");

                entity.Property(e => e.NoiDungDanhGia).HasColumnName("NoiDungDanhGIa");

                entity.HasOne(d => d.IdHocVienNavigation)
                    .WithMany(p => p.DanhGiaKhoaHocs)
                    .HasForeignKey(d => d.IdHocVien)
                    .HasConstraintName("FK_DanhGiaKhoaHoc_HocVien");

                entity.HasOne(d => d.IdKhoaHocOnlineNavigation)
                    .WithMany(p => p.DanhGiaKhoaHocs)
                    .HasForeignKey(d => d.IdKhoaHocOnline)
                    .HasConstraintName("FK_DanhGiaKhoaHoc_KhoaHocOnline");
            });

            modelBuilder.Entity<DatHang>(entity =>
            {
                entity.HasKey(e => e.IdDatHang)
                    .HasName("PK_DonHang");

                entity.ToTable("DatHang");

                entity.Property(e => e.NgayDatHang).HasColumnType("datetime");

                entity.Property(e => e.TinhTrangDonHang).HasMaxLength(50);

                entity.Property(e => e.TongGia).HasColumnType("money");

                entity.HasOne(d => d.IdHocVienNavigation)
                    .WithMany(p => p.DatHangs)
                    .HasForeignKey(d => d.IdHocVien)
                    .HasConstraintName("FK_DatHang_HocVien");
            });

            modelBuilder.Entity<GiangVien>(entity =>
            {
                entity.ToTable("GiangVien");

                entity.HasIndex(e => e.Id, "IX_GiangVien")
                    .IsUnique();

                entity.Property(e => e.BangCap).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => e.IdGioHang)
                    .HasName("PK_Gio Hang");

                entity.ToTable("GioHang");

                entity.HasOne(d => d.IdKhoaHocOnlineNavigation)
                    .WithMany(p => p.GioHangs)
                    .HasForeignKey(d => d.IdKhoaHocOnline)
                    .HasConstraintName("FK_GioHang_KhoaHocOnline");
            });

            modelBuilder.Entity<HocVien>(entity =>
            {
                entity.ToTable("HocVien");

                entity.HasIndex(e => e.TaiKhoan, "IX_HocVien")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.TaiKhoan).HasMaxLength(50);
            });

            modelBuilder.Entity<KhoaHocOnline>(entity =>
            {
                entity.ToTable("KhoaHocOnline");

                entity.Property(e => e.DanhGia).HasMaxLength(50);

                entity.Property(e => e.GiaGiam).HasColumnType("money");

                entity.Property(e => e.GiaGoc).HasColumnType("money");

                entity.Property(e => e.TenKhoaHoc).HasMaxLength(50);

                entity.HasOne(d => d.IdGiangVienNavigation)
                    .WithMany(p => p.KhoaHocOnlines)
                    .HasForeignKey(d => d.IdGiangVien)
                    .HasConstraintName("FK_KhoaHocOnline_GiangVien");

                entity.HasOne(d => d.IdNganhHocNavigation)
                    .WithMany(p => p.KhoaHocOnlines)
                    .HasForeignKey(d => d.IdNganhHoc)
                    .HasConstraintName("FK_KhoaHocOnline_NganhHoc");
            });

            modelBuilder.Entity<NganhHoc>(entity =>
            {
                entity.HasKey(e => e.IdNganhHoc);

                entity.ToTable("NganhHoc");

                entity.Property(e => e.TenNganhHoc).HasMaxLength(50);
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.HasOne(d => d.IdGiangVienNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.IdGiangVien)
                    .HasConstraintName("FK_TaiKhoan_GiangVien1");

                entity.HasOne(d => d.IdHocVienNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.IdHocVien)
                    .HasConstraintName("FK_TaiKhoan_HocVien");
            });

            modelBuilder.Entity<ThongTinKhoaHoc>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ThongTinKhoaHoc");

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.Property(e => e.TenKhoaHoc).HasMaxLength(50);

                entity.Property(e => e.TenNganhHoc).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
