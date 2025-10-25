
using DAL.Model;
using DAL.Services;
using System.Collections.Generic;

namespace BUS
{
    public class DichVuBUS
    {
        private readonly DichVuDAL _dal = new DichVuDAL();

        public DICHVU LayTheoTen(string ten) => _dal.GetByTen(ten);
        public DICHVU LayTheoMa(string ma) => _dal.GetByMa(ma);
        public List<DichVuVm> LayTatCaDichVu() => _dal.GetAll();

            public List<DichVuVm> LayDanhSachDichVu() => _dal.GetAllBasic();
        
    }
}
