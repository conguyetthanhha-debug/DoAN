using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=QLKTXSV")
        {
            

        }
        
        public virtual DbSet<DANGNHAP> DANGNHAPs { get; set; }
        public virtual DbSet<DICHVU> DICHVUs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<LOAIPHONG> LOAIPHONGs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHIEUDK> PHIEUDKs { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<SDDV> SDDVs { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIENs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
     
            modelBuilder.Entity<SINHVIEN>().Ignore(s => s.PHONG);
            modelBuilder.Entity<PHONG>().Ignore(p => p.SINHVIENs);


            modelBuilder.Entity<DANGNHAP>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<DANGNHAP>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<DICHVU>()
                .Property(e => e.MaDV)
                .IsUnicode(false);

            modelBuilder.Entity<DICHVU>()
                .HasMany(e => e.SDDVs)
                .WithRequired(e => e.DICHVU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.Khu)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.MaLoaiPhong)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.DienTich)
                .HasPrecision(6, 2);

            modelBuilder.Entity<LOAIPHONG>()
                .HasMany(e => e.PHONGs)
                .WithRequired(e => e.LOAIPHONG1)
                .HasForeignKey(e => e.LoaiPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaNQL)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.NHANVIEN1)
                .WithOptional(e => e.NHANVIEN2)
                .HasForeignKey(e => e.MaNQL);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUDKs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUDK>()
                .Property(e => e.MSSV)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDK>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDK>()
                .Property(e => e.Khu)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDK>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDK>()
                .Property(e => e.NgayGioDK)
                .HasPrecision(0);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.Khu)
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.LoaiPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.PHONG)
                .HasForeignKey(e => new { e.Khu, e.MaPhong })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.PHIEUDKs)
                .WithRequired(e => e.PHONG)
                .HasForeignKey(e => new { e.Khu, e.MaPhong })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SDDV>()
                .Property(e => e.MaDV)
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.MSSV)
                .IsUnicode(false);

    

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.BHYT)
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .HasMany(e => e.PHIEUDKs)
                .WithRequired(e => e.SINHVIEN)
                .WillCascadeOnDelete(false);
        }
    }
}
