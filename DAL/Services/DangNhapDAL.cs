using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        

    }
}
