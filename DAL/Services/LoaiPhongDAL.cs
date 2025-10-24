using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class LoaiPhongDAL
    {
        public class LoaiPhongVm
        {
            public string MaLoaiPhong { get; set; }
            public int SoSV { get; set; }
            public decimal DienTich { get; set; }
            public int DonGia { get; set; }
        }

        public LoaiPhongVm GetLoaiPhongBySoSV(int soSV)
        {
            using (var db = new DAL.Model.Model1())
            {
                return db.LOAIPHONGs
                         .AsNoTracking()
                         .Where(x => x.SoSV == soSV)
                         .Select(x => new LoaiPhongVm
                         {
                             MaLoaiPhong = x.MaLoaiPhong,
                             SoSV = x.SoSV,
                             DienTich = x.DienTich,
                             DonGia = x.DonGia
                         })
                         .FirstOrDefault();
            }
        }

    }
}
