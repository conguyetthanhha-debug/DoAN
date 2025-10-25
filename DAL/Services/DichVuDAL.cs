
using DAL.Model;
using System.Collections.Generic;
using System.Linq;

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
        public List<DichVuVm> GetAllBasic()
        {
            using (var db = new Model1())
            {
                return db.DICHVUs
                    .OrderBy(d => d.TenDV)
                    .Select(d => new DichVuVm
                    {
                        MaDV = d.MaDV,
                        TenDV = d.TenDV,
                        DonViTinh = d.DonViTinh
                    })
                    .ToList();
            }
        }

        public List<DichVuVm> GetAll()
        {
            using (var db = new Model1())
            {
                return db.DICHVUs
                         .AsNoTracking()
                         .OrderBy(x => x.TenDV)
                         .Select(x => new DichVuVm
                         {
                             MaDV = x.MaDV,
                             TenDV = x.TenDV,
                             DonViTinh = x.DonViTinh
                         })
                         .ToList();
            }
        }
    }
}
