using DAL.Services;

namespace BUS
{
    public class DangNhapBUS
    {
        private readonly DangNhapDAL dal = new DangNhapDAL();

        public bool DangNhap(string username, string password, out string maNV)
        {
            maNV = null;

            var ok = dal.KiemTraDangNhap(username, password);
            if (ok)
            {
                
                maNV = dal.GetMaNVByUsername(username);
            }

            return ok;
        }
    }
}
