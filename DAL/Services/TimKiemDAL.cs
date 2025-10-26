using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Model;

namespace DAL.Services
{
    
    public class TimKiemDAL
    {
        public List<SinhVienVm> GetSinhVien()
        {
            using (var db = new Model1())
            {
                return db.SINHVIENs
                    .AsNoTracking()
                    .OrderBy(s => s.HoTen)
                    .Select(s => new SinhVienVm
                    {
                        MSSV = s.MSSV,
                        HoTen = s.HoTen,
                        GioiTinh = s.Phai ? "Nam" : "Nữ",
                        NgSinh = s.NgSinh,
                        CMND = s.CMND,
                        Email = s.Email,
                        SDT = s.SDT,
                        QueQuan = s.QueQuan
                    })
                    .ToList();
            }
        }

        public List<NhanVienVm> GetNhanVien()
        {
            using (var db = new Model1())
            {
                return db.NHANVIENs
                    .AsNoTracking()
                    .OrderBy(n => n.HoTen)
                    .Select(n => new NhanVienVm
                    {
                        MaNV = n.MaNV,
                        HoTen = n.HoTen,
                        CMND = n.CMND,
                        SDT = n.SDT,
                        Email = n.Email,
                        DiaChi = n.DiaChi,
                        Luong = n.Luong,
                        MaNQL = n.MaNQL
                    })
                    .ToList();
            }
        }

        public List<PhieuDKVm> GetPhieuDK()
        {
            using (var db = new Model1())
            {
                return db.PHIEUDKs
                    .Include(p => p.SINHVIEN)
                    .Include(p => p.NHANVIEN)
                    .AsNoTracking()
                    .OrderByDescending(p => p.NgayGioDK)
                    .Select(p => new PhieuDKVm
                    {
                        MaPDK = p.MaPDK,
                        MSSV = p.MSSV,
                        TenSV = p.SINHVIEN != null ? p.SINHVIEN.HoTen : null,
                        MaNV = p.MaNV,
                        TenNV = p.NHANVIEN != null ? p.NHANVIEN.HoTen : null,
                        Khu = p.Khu,
                        MaPhong = p.MaPhong,
                        HocKi = p.HocKi,                 // int -> int (khớp kiểu)
                        NamHoc = p.NamHoc,
                        NgayGioDK = p.NgayGioDK,         // DateTime? -> DateTime?
                        ThoiHan = p.ThoiHan,             // int -> int
                        NgayBD = p.NgayBD                // DateTime? -> DateTime?
                    })
                    .ToList();
            }
        }


        public List<HoaDonVm> GetHoaDon()
        {
            using (var db = new Model1())
            {
                var q =
                    from hd in db.HOADONs
                    join nv in db.NHANVIENs on hd.MaNV equals nv.MaNV
                    select new HoaDonVm
                    {
                        MaHD = hd.MaHD,
                        Nam = hd.Nam,
                        Thang = hd.Thang,
                        NgayHD = hd.NgayHD,
                        Khu = hd.Khu,
                        MaPhong = hd.MaPhong,
                        MaNV = hd.MaNV,
                        TenNV = nv.HoTen,
                        TongTienDichVu = (
                            from sddv in db.SDDVs
                            join dv in db.DICHVUs on sddv.MaDV equals dv.MaDV
                            where sddv.MaHD == hd.MaHD
                            select (decimal)sddv.SoLuong * (decimal)dv.GiaDV
                        ).DefaultIfEmpty(0).Sum(),

                        // ✅ Thêm 2 dòng này:
                        QRCode = hd.QRCode,
                        QRCodeUpdatedAt = hd.QRCodeUpdatedAt
                    };

                return q.AsNoTracking().ToList();
            }
        }

        public List<PhongVm> GetPhong(string khu = "", string maPhong = "")
        {
            using (var db = new Model1())
            {
                string sql = @"
SELECT  P.Khu,
        P.MaPhong,
        P.LoaiPhong,
        LP.SoSV   AS SucChua,
        LP.DienTich,
        LP.DonGia,
        ISNULL(X.CurSV, 0) AS DangO,
        CASE WHEN ISNULL(X.CurSV,0) < LP.SoSV THEN N'Còn chỗ' ELSE N'Đủ chỗ' END AS TrangThai
FROM    dbo.PHONG AS P
INNER JOIN dbo.LOAIPHONG AS LP ON LP.MaLoaiPhong = P.LoaiPhong
OUTER APPLY (SELECT COUNT(*) AS CurSV FROM dbo.STAY S WHERE S.Khu = P.Khu AND S.MaPhong = P.MaPhong) X
WHERE (@p0 = '' OR P.Khu = @p0) AND (@p1 = '' OR P.MaPhong = @p1)
ORDER BY P.Khu, P.MaPhong;";
                return db.Database.SqlQuery<PhongVm>(sql, khu ?? "", maPhong ?? "").ToList();
            }
        }
    }
}
