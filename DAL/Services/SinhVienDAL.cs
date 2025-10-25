using System.Linq;
using DAL.Model;

namespace DAL.Services
{
    public class SinhVienDAL
    {
        public bool ExistsByMSSV(string mssv)
        {
            if (string.IsNullOrWhiteSpace(mssv)) return false;
            using (var db = new Model1())
                return db.SINHVIENs.Any(x => x.MSSV == mssv);
        }

        public SINHVIEN GetByMSSV(string mssv)
        {
            if (string.IsNullOrWhiteSpace(mssv)) return null;
            using (var db = new Model1())
                return db.SINHVIENs.AsNoTracking().FirstOrDefault(x => x.MSSV == mssv);
        }

        public bool Add(SINHVIEN sv)
        {
            using (var db = new Model1())
            {
                db.SINHVIENs.Add(sv);
                db.SaveChanges();
                return true;
            }
        }

        public bool Update(SINHVIEN sv)
        {
            using (var db = new Model1())
            {
                var old = db.SINHVIENs.SingleOrDefault(x => x.MSSV == sv.MSSV);
                if (old == null) return false;

                old.HoTen = sv.HoTen;

                old.DienSV = sv.DienSV;
                old.Phai = sv.Phai;
                old.NgSinh = sv.NgSinh;
                old.CMND = sv.CMND;
                old.Email = sv.Email;
                old.SDT = sv.SDT;
                old.BHYT = sv.BHYT;
                old.QueQuan = sv.QueQuan;
                old.AnhChanDung = sv.AnhChanDung; // string path theo model

                db.SaveChanges();
                return true;
            }
        }
    }
}
