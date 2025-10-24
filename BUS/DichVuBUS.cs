
using DAL.Model;
using DAL.Services;

namespace BUS
{
    public class DichVuBUS
    {
        private readonly DichVuDAL _dal = new DichVuDAL();

        public DICHVU LayTheoTen(string ten) => _dal.GetByTen(ten);
        public DICHVU LayTheoMa(string ma) => _dal.GetByMa(ma);
    }
}
