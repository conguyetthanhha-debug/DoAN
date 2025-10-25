using System;
using DAL.Model;
using DAL.Services;

namespace BUS
{
    public class DangKyBUS
    {
        private readonly PhieuDKDAL _pdkDal = new PhieuDKDAL();

        public bool TaoPhieuDangKy(
            string mssv, string maKhu, string maPhong,
            string hocKiText, string namHoc, DateTime ngayBD,
            string thoiHanText, string maNV,
            out int maPDK, out string error)
        {
            maPDK = 0;
            error = null;

            // Ép về int theo đúng kiểu trong entity
            if (!int.TryParse(hocKiText, out var hocKi))
            {
                error = "Học kỳ không hợp lệ (phải là số).";
                return false;
            }
            if (!int.TryParse(thoiHanText, out var thoiHan))
            {
                error = "Thời hạn không hợp lệ (phải là số tháng).";
                return false;
            }

            try
            {
                var p = new PHIEUDK
                {
                    MSSV = string.IsNullOrWhiteSpace(mssv) ? null : mssv,
                    MaNV = string.IsNullOrWhiteSpace(maNV) ? null : maNV,
                    Khu = maKhu,
                    MaPhong = maPhong,
                    HocKi = hocKi,                // int
                    NamHoc = string.IsNullOrWhiteSpace(namHoc) ? null : namHoc,
                    NgayGioDK = DateTime.Now,      // property trong model của bạn
                    ThoiHan = thoiHan,        // int
                    NgayBD = ngayBD                // DateTime/Date
                };

                maPDK = _pdkDal.Insert(p);
                if (maPDK <= 0)
                {
                    error = "Không thể tạo phiếu đăng ký.";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex.GetBaseException()?.Message ?? ex.Message;
                return false;
            }
        }
    }
}
