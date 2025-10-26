using System;
using System.Collections.Generic;
using DAL.Services;

namespace BUS
{
    public class HoaDonBUS
    {
        private readonly HoaDonDAL dal = new HoaDonDAL();

        public List<HoaDonVm> LayTatCaHoaDon() => dal.GetAll();

        public bool TaoHoaDon(string maNV, string khu, string maPhong,
                              string thangText, string namText, DateTime ngayHD,
                              IEnumerable<(string MaDV, int SoLuong)> dsDichVu,
                              out int maHD, out string error)
        {
            maHD = 0; error = null;

            if (string.IsNullOrWhiteSpace(maNV)) { error = "Thiếu mã nhân viên."; return false; }
            if (string.IsNullOrWhiteSpace(khu)) { error = "Chưa chọn Khu."; return false; }
            if (string.IsNullOrWhiteSpace(maPhong)) { error = "Chưa chọn Phòng."; return false; }
            if (!byte.TryParse(thangText, out var thang) || thang < 1 || thang > 12)
            { error = "Tháng không hợp lệ."; return false; }
            if (!short.TryParse(namText, out var nam) || nam < 2000 || nam > 2100)
            { error = "Năm không hợp lệ."; return false; }

            try
            {
                maHD = dal.InsertHoaDon(nam, thang, ngayHD, khu, maPhong, maNV);

                if (dsDichVu != null)
                {
                    foreach (var item in dsDichVu)
                    {
                        if (string.IsNullOrWhiteSpace(item.MaDV) || item.SoLuong <= 0) continue;
                        dal.InsertOrReplaceSDDV(maHD, item.MaDV, item.SoLuong);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex.GetBaseException()?.Message ?? ex.Message;
                return false;
            }
        }

        public List<HoaDonChiTietVm> LayChiTiet(int maHD) => dal.GetChiTietByMaHD(maHD);

        public void CapNhatQRCode(int maHD, byte[] qrImage, out string error)
        {
            error = null;
            try
            {
                var dal = new HoaDonDAL();
                dal.UpdateQRCode(maHD, qrImage);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }



    }
}
