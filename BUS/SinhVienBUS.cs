using System;
using System.Text;
using DAL.Model;
using DAL.Services;

namespace BUS
{
    public class SinhVienBUS
    {
        private readonly SinhVienDAL _dal = new SinhVienDAL();

        private void Validate(SINHVIEN sv, bool isUpdate)
        {
            var sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(sv.MSSV)) sb.AppendLine("• MSSV là bắt buộc.");
            if (string.IsNullOrWhiteSpace(sv.HoTen)) sb.AppendLine("• Họ tên là bắt buộc.");
            if (sv.Email != null && sv.Email.Length > 120) sb.AppendLine("• Email tối đa 120 ký tự.");
            if (sv.SDT != null && sv.SDT.Length > 20) sb.AppendLine("• SĐT tối đa 20 ký tự.");
            if (sv.CMND != null && sv.CMND.Length > 20) sb.AppendLine("• CMND tối đa 20 ký tự.");

            if (!isUpdate && _dal.ExistsByMSSV(sv.MSSV)) sb.AppendLine("• MSSV đã tồn tại.");

            if (sb.Length > 0) throw new InvalidOperationException(sb.ToString());
            if (sv.AnhChanDung != null && sv.AnhChanDung.Length > 255)
                sb.AppendLine("• Ảnh chân dung: đường dẫn quá dài (tối đa 255 ký tự).");

        }

        public bool ThemSinhVien(SINHVIEN sv)
        {
            Validate(sv, isUpdate: false);
            return _dal.Add(sv);
        }

        public bool CapNhatSinhVien(SINHVIEN sv)
        {
            if (!_dal.ExistsByMSSV(sv.MSSV))
                throw new InvalidOperationException("Không tìm thấy sinh viên để cập nhật.");
            Validate(sv, isUpdate: true);
            return _dal.Update(sv);
        }

        public SINHVIEN LaySinhVienTheoMSSV(string mssv) => _dal.GetByMSSV(mssv);
        public bool TonTaiMSSV(string mssv) => _dal.ExistsByMSSV(mssv);
    }
}
