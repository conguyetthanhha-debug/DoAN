
using System;
using System.Text;
using DAL.Model;
using DAL.Services;

namespace BUS
{
    public class NhanVienBUS
    {
        private readonly NhanVienDAL _dal = new NhanVienDAL();

        private void Validate(NHANVIEN nv, bool isUpdate)
        {
            var sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(nv.MaNV)) sb.AppendLine("• Mã NV là bắt buộc.");
            if (string.IsNullOrWhiteSpace(nv.HoTen)) sb.AppendLine("• Họ tên là bắt buộc.");
            if (string.IsNullOrWhiteSpace(nv.CMND)) sb.AppendLine("• CMND là bắt buộc.");

            if (!string.IsNullOrEmpty(nv.CMND) && nv.CMND.Length > 20) sb.AppendLine("• CMND tối đa 20 ký tự.");
            if (!string.IsNullOrEmpty(nv.SDT) && nv.SDT.Length > 20) sb.AppendLine("• SĐT tối đa 20 ký tự.");
            if (!string.IsNullOrEmpty(nv.Email) && nv.Email.Length > 120) sb.AppendLine("• Email tối đa 120 ký tự.");
            if (!string.IsNullOrEmpty(nv.DiaChi) && nv.DiaChi.Length > 400) sb.AppendLine("• Địa chỉ tối đa 400 ký tự.");
            if (nv.Luong.HasValue && nv.Luong.Value < 0) sb.AppendLine("• Lương phải ≥ 0.");

      
            if (!_dal.ManagerExists(nv.MaNQL)) sb.AppendLine("• Mã NQL không tồn tại.");


            if (!isUpdate && _dal.ExistsByMaNV(nv.MaNV)) sb.AppendLine("• Mã NV đã tồn tại.");
            if (!string.IsNullOrWhiteSpace(nv.CMND) && _dal.ExistsOtherByCMND(nv.CMND, isUpdate ? nv.MaNV : null))
                sb.AppendLine("• CMND đã được dùng bởi nhân viên khác.");

            if (sb.Length > 0) throw new InvalidOperationException(sb.ToString());
        }

        public bool ThemNhanVien(NHANVIEN nv)
        {
            Validate(nv, isUpdate: false);
            return _dal.Add(nv);
        }

        public bool CapNhatNhanVien(NHANVIEN nv)
        {
            Validate(nv, isUpdate: true);
            return _dal.Update(nv);
        }
    }
}
