using System.Collections.Generic;
using System.Linq;
using DAL.Model;

namespace DAL.Services
{
    public class PhongDAL
    {
        public List<string> GetKhusAB()
        {
            using (var db = new Model1())
            {
                return db.PHONGs
                         .Where(p => p.Khu == "A" || p.Khu == "B")
                         .Select(p => p.Khu)
                         .Distinct()
                         .OrderBy(x => x)
                         .ToList();
            }
        }

        public List<string> GetRoomsByKhu(string khu)
        {
            using (var db = new Model1())
            {
                return db.PHONGs
                         .Where(p => p.Khu == khu)
                         .OrderBy(p => p.MaPhong)
                         .Select(p => p.MaPhong)
                         .ToList();
            }
        }
    }
}
