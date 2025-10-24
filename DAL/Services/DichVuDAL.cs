
using System.Linq;
using DAL.Model;

namespace DAL.Services
{
    public class DichVuDAL
    {
        public DICHVU GetByTen(string ten)
        {
            using (var db = new Model1())
                return db.DICHVUs.FirstOrDefault(x => x.TenDV == ten);
        }

        public DICHVU GetByMa(string ma)
        {
            using (var db = new Model1())
                return db.DICHVUs.FirstOrDefault(x => x.MaDV == ma);
        }
    }
}
