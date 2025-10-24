using System;
using System.Linq;
using DAL.Model;
using DAL.Services;

namespace BUS
{
    public class DangNhapBUS
    {
        private readonly DangNhapDAL dal = new DangNhapDAL();

        public bool DangNhap(string username, string password)
        {
            return dal.KiemTraDangNhap(username, password);
        }
    }
}
