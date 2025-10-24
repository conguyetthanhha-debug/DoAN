
using System.Linq;
using DAL.Model;

namespace DAL.Services
{
    public class NhanVienDAL
    {
        public bool ExistsByMaNV(string ma)
        {
            using (var db = new Model1())
                return db.NHANVIENs.Any(x => x.MaNV == ma);
        }

        public bool ExistsOtherByCMND(string cmnd, string exceptMaNV = null)
        {
            using (var db = new Model1())
                return db.NHANVIENs.Any(x => x.CMND == cmnd && x.MaNV != exceptMaNV);
        }

        public bool ManagerExists(string maNql)
        {
            if (string.IsNullOrWhiteSpace(maNql)) return true; 
            using (var db = new Model1())
                return db.NHANVIENs.Any(x => x.MaNV == maNql);
        }

        public bool Add(NHANVIEN nv)
        {
            using (var db = new Model1())
            {
                db.NHANVIENs.Add(nv);
                db.SaveChanges();
                return true;
            }
        }

        public bool Update(NHANVIEN nv)
        {
            using (var db = new Model1())
            {
                var old = db.NHANVIENs.SingleOrDefault(x => x.MaNV == nv.MaNV);
                if (old == null) return false;

                old.HoTen = nv.HoTen;
                old.CMND = nv.CMND;
                old.SDT = nv.SDT;
                old.Email = nv.Email;
                old.DiaChi = nv.DiaChi;
                old.Luong = nv.Luong;
                old.MaNQL = nv.MaNQL;
                old.AnhChanDung = nv.AnhChanDung;
                db.SaveChanges();
                return true;
            }
        }
    }
}
