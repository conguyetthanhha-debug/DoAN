using DAL.Model;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Services.LoaiPhongDAL;

namespace BUS
{
    public class LoaiPhongBUS
    {
        private readonly LoaiPhongDAL _dal = new LoaiPhongDAL();
        public LoaiPhongVm LayLoaiPhongTheoSoSV(int soSV) => _dal.GetLoaiPhongBySoSV(soSV);


    }
}
