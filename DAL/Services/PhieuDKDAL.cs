using System;
using DAL.Model;

namespace DAL.Services
{
    public class PhieuDKDAL
    {
        // Trả về MaPDK (>=1) nếu thành công, 0 nếu lỗi
        public int Insert(PHIEUDK p)
        {
            using (var db = new Model1())
            {
                
                db.PHIEUDKs.Add(p);
                db.SaveChanges();
                return p.MaPDK; 
            }
        }
    }
}
