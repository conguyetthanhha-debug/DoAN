using System.Linq;
using DAL.Model;

namespace DAL.Services
{
    public class DangNhapDAL
    {
        public bool KiemTraDangNhap(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            using (var db = new Model1())
            {
                return db.DANGNHAPs.Any(u =>
                    u.TenDN == username.Trim() &&
                    u.MatKhau == password.Trim()
                );
            }
        }

        public string GetMaNVByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;
            using (var db = new Model1())
            {
                return db.DANGNHAPs
                         .Where(x => x.TenDN == username.Trim())
                         .Select(x => x.MaNV)
                         .FirstOrDefault();
            }
        }
    }
}
