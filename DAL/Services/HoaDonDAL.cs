using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Model;

namespace DAL.Services
{
    public class HoaDonDAL
    {
        public List<HoaDonVm> GetAll()
        {
            using (var db = new Model1())
            {
                var q =
                    from hd in db.HOADONs.Include(h => h.NHANVIEN)
                    join sddv in db.SDDVs on hd.MaHD equals sddv.MaHD into g
                    select new HoaDonVm
                    {
                        MaHD = hd.MaHD,
                        Nam = hd.Nam,
                        Thang = hd.Thang,
                        NgayHD = hd.NgayHD,
                        Khu = hd.Khu,
                        MaPhong = hd.MaPhong,
                        MaNV = hd.MaNV,
                        TenNV = hd.NHANVIEN.HoTen,
                        TongTienDichVu = g.Join(db.DICHVUs,
                                                sd => sd.MaDV,
                                                dv => dv.MaDV,
                                                (sd, dv) => (decimal)sd.SoLuong * (decimal)dv.GiaDV)
                                          .DefaultIfEmpty(0m)
                                          .Sum()
                    };

                return q.OrderByDescending(x => x.Nam)
                        .ThenByDescending(x => x.Thang)
                        .ThenByDescending(x => x.MaHD)
                        .AsNoTracking()
                        .ToList();
            }
        }

        public int InsertHoaDon(short nam, byte thang, DateTime ngayHD, string khu, string maPhong, string maNV)
        {
            using (var db = new Model1())
            {
                var hd = new HOADON
                {
                    Nam = nam,
                    Thang = thang,
                    NgayHD = ngayHD,
                    Khu = khu,
                    MaPhong = maPhong,
                    MaNV = maNV
                };
                db.HOADONs.Add(hd);
                db.SaveChanges();
                return hd.MaHD;
            }
        }

        public void InsertOrReplaceSDDV(int maHD, string maDV, int soLuong)
        {
            using (var db = new Model1())
            {
                var existed = db.SDDVs.FirstOrDefault(x => x.MaHD == maHD && x.MaDV == maDV);
                if (existed == null)
                {
                    db.SDDVs.Add(new SDDV
                    {
                        MaHD = maHD,
                        MaDV = maDV,
                        SoLuong = soLuong
                    });
                }
                else
                {
                    existed.SoLuong = soLuong; // Replace
                }
                db.SaveChanges();
            }
        }

        public List<HoaDonChiTietVm> GetChiTietByMaHD(int maHD)
        {
            using (var db = new Model1())
            {
                var q =
                    from sd in db.SDDVs.Where(x => x.MaHD == maHD)
                    join dv in db.DICHVUs on sd.MaDV equals dv.MaDV
                    select new HoaDonChiTietVm
                    {
                        MaDV = dv.MaDV,
                        TenDV = dv.TenDV,
                        DonViTinh = dv.DonViTinh,
                        SoLuong = sd.SoLuong
                    };

                return q.AsNoTracking().ToList();
            }
        }
    }
}
