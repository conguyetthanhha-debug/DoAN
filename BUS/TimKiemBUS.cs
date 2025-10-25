using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class TimKiemBUS
    {
        private readonly TimKiemDAL _dal = new TimKiemDAL();

        public List<SinhVienVm> LayDanhSachSinhVien() => _dal.GetSinhVien();
        public List<NhanVienVm> LayDanhSachNhanVien() => _dal.GetNhanVien();
        public List<PhongVm> LayDanhSachPhong(string khu = "", string phong = "") => _dal.GetPhong(khu, phong);
        public List<PhieuDKVm> LayDanhSachPhieuDK() => _dal.GetPhieuDK();
        public List<HoaDonVm> LayDanhSachHoaDon() => _dal.GetHoaDon();

        public IEnumerable<object> TimKiem(TableKind kind, string column, string keyword)
        {
            column = (column ?? "").Trim();
            keyword = (keyword ?? "").Trim().ToLower();

            switch (kind)
            {
                case TableKind.SinhVien:
                    {
                        var src = LayDanhSachSinhVien();
                        if (string.IsNullOrWhiteSpace(keyword) || column == "Tất cả")
                            return src;

                        return src.Where(x =>
                            (column == "MSSV" && (x.MSSV ?? "").ToLower().Contains(keyword)) ||
                            (column == "HoTen" && (x.HoTen ?? "").ToLower().Contains(keyword)) ||
                            (column == "GioiTinh" && (x.GioiTinh ?? "").ToLower().Contains(keyword)) ||
                            (column == "NgSinh" && ((x.NgSinh?.ToString("yyyy-MM-dd")) ?? "").Contains(keyword)) ||
                            (column == "CMND" && (x.CMND ?? "").ToLower().Contains(keyword)) ||
                            (column == "Email" && (x.Email ?? "").ToLower().Contains(keyword)) ||
                            (column == "SDT" && (x.SDT ?? "").ToLower().Contains(keyword)) ||
                            (column == "QueQuan" && (x.QueQuan ?? "").ToLower().Contains(keyword))
                        );
                    }

                case TableKind.NhanVien:
                    {
                        var src = LayDanhSachNhanVien();
                        if (string.IsNullOrWhiteSpace(keyword) || column == "Tất cả")
                            return src;

                        bool isLuong = int.TryParse(keyword, out var vLuong);

                        return src.Where(x =>
                            (column == "MaNV" && (x.MaNV ?? "").ToLower().Contains(keyword)) ||
                            (column == "HoTen" && (x.HoTen ?? "").ToLower().Contains(keyword)) ||
                            (column == "CMND" && (x.CMND ?? "").ToLower().Contains(keyword)) ||
                            (column == "SDT" && (x.SDT ?? "").ToLower().Contains(keyword)) ||
                            (column == "Email" && (x.Email ?? "").ToLower().Contains(keyword)) ||
                            (column == "DiaChi" && (x.DiaChi ?? "").ToLower().Contains(keyword)) ||
                            (column == "MaNQL" && (x.MaNQL ?? "").ToLower().Contains(keyword)) ||
                            (column == "Luong" && isLuong && (x.Luong ?? -1) == vLuong)
                        );
                    }

                case TableKind.Phong:
                    {
                        var src = LayDanhSachPhong();
                        if (string.IsNullOrWhiteSpace(keyword) || column == "Tất cả")
                            return src;

                        bool isInt = int.TryParse(keyword, out var vInt);
                        bool isDec = decimal.TryParse(keyword, out var vDec);

                        return src.Where(x =>
                            (column == "Khu" && (x.Khu ?? "").ToLower().Contains(keyword)) ||
                            (column == "MaPhong" && (x.MaPhong ?? "").ToLower().Contains(keyword)) ||
                            (column == "LoaiPhong" && (x.LoaiPhong ?? "").ToLower().Contains(keyword)) ||
                            (column == "TrangThai" && (x.TrangThai ?? "").ToLower().Contains(keyword)) ||
                            (column == "SucChua" && isInt && x.SucChua == vInt) ||
                            (column == "DangO" && isInt && x.DangO == vInt) ||
                            (column == "DonGia" && isInt && x.DonGia == vInt) ||
                            (column == "DienTich" && isDec && x.DienTich == vDec)
                        );
                    }

                case TableKind.PhieuDK:
                    {
                        var src = LayDanhSachPhieuDK();
                        if (string.IsNullOrWhiteSpace(keyword) || column == "Tất cả")
                            return src;

                        bool isThoiHan = int.TryParse(keyword, out var vThoiHan);
                        // Nếu HocKi là int:
                        bool isHocKi = int.TryParse(keyword, out var vHocKi);

                        return src.Where(x =>
                            (column == "MaPDK" && x.MaPDK.ToString().Contains(keyword)) ||
                            (column == "MSSV" && (x.MSSV ?? "").ToLower().Contains(keyword)) ||
                            (column == "TenSV" && (x.TenSV ?? "").ToLower().Contains(keyword)) ||
                            (column == "MaNV" && (x.MaNV ?? "").ToLower().Contains(keyword)) ||
                            (column == "TenNV" && (x.TenNV ?? "").ToLower().Contains(keyword)) ||
                            (column == "Khu" && (x.Khu ?? "").ToLower().Contains(keyword)) ||
                            (column == "MaPhong" && (x.MaPhong ?? "").ToLower().Contains(keyword)) ||
                            (column == "HocKi" && (x.HocKi.ToString().Contains(keyword) || (isHocKi && x.HocKi == vHocKi))) ||
                            (column == "NamHoc" && (x.NamHoc ?? "").ToLower().Contains(keyword)) ||
                          (column == "NgayGioDK" &&
    (x.NgayGioDK != null &&
     string.Format("{0:yyyy-MM-dd HH:mm:ss}", x.NgayGioDK).Contains(keyword))) ||

                            (column == "ThoiHan" && isThoiHan && x.ThoiHan == vThoiHan) ||
                            (column == "NgayBD" &&
    (x.NgayBD != null &&
     string.Format("{0:yyyy-MM-dd}", x.NgayBD).Contains(keyword)))
                        );
                    }

                case TableKind.HoaDon:
                    {
                        var src = LayDanhSachHoaDon();
                        if (string.IsNullOrWhiteSpace(keyword) || column == "Tất cả")
                            return src;

                        bool isDec = decimal.TryParse(keyword, out var vTien);

                        return src.Where(x =>
                            (column == "MaHD" && x.MaHD.ToString().Contains(keyword)) ||
                            (column == "Nam" && x.Nam.ToString().Contains(keyword)) ||
                            (column == "Thang" && x.Thang.ToString().Contains(keyword)) ||
                            (column == "NgayHD" && x.NgayHD.ToString("yyyy-MM-dd").Contains(keyword)) ||
                            (column == "Khu" && (x.Khu ?? "").ToLower().Contains(keyword)) ||
                            (column == "MaPhong" && (x.MaPhong ?? "").ToLower().Contains(keyword)) ||
                            (column == "MaNV" && (x.MaNV ?? "").ToLower().Contains(keyword)) ||
                            (column == "TenNV" && (x.TenNV ?? "").ToLower().Contains(keyword)) ||
                            (column == "TongTienDichVu" && isDec && x.TongTienDichVu == vTien)
                        );
                    }
            }

            return Enumerable.Empty<object>();
        }
    }
}
