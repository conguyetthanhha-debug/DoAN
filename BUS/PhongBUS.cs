using System.Collections.Generic;
using DAL.Services;

namespace BUS
{
    public class PhongBUS
    {
        private readonly PhongDAL dal = new PhongDAL();
        public List<string> LayKhuAB() => dal.GetKhusAB();
        public List<string> LayPhongTheoKhu(string khu) => dal.GetRoomsByKhu(khu);
    }
}
