using System;

namespace DAL.Services
{

    public class SinhVienVm
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgSinh { get; set; }
        public string CMND { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string QueQuan { get; set; }
    }

    public class NhanVienVm
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public int? Luong { get; set; }
        public string MaNQL { get; set; }
    }

    public class PhieuDKVm
    {
        public int MaPDK { get; set; }
        public string MSSV { get; set; }
        public string TenSV { get; set; }
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string Khu { get; set; }
        public string MaPhong { get; set; }

        // Đổi từ string -> int
        public int HocKi { get; set; }

        public string NamHoc { get; set; }

        // Cho phép null nếu cột trong DB có thể null
        public DateTime? NgayGioDK { get; set; }

        public int ThoiHan { get; set; }

        // Cho phép null nếu cột trong DB có thể null
        public DateTime? NgayBD { get; set; }
    }
    public class PhongVm
    {
        public string Khu { get; set; }
        public string MaPhong { get; set; }
        public string LoaiPhong { get; set; }
        public int SucChua { get; set; }
        public decimal DienTich { get; set; }
        public int DonGia { get; set; }
        public int DangO { get; set; }
        public string TrangThai { get; set; }
    }
    public class DichVuVm
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public string DonViTinh { get; set; }
    }

    public class HoaDonVm
    {
        public int MaHD { get; set; }
        public short Nam { get; set; }
        public byte Thang { get; set; }
        public DateTime NgayHD { get; set; }
        public string Khu { get; set; }
        public string MaPhong { get; set; }
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public decimal TongTienDichVu { get; set; }
    }

    public class HoaDonChiTietVm
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
    }
}
