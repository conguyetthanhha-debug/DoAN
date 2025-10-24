namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUDK")]
    public partial class PHIEUDK
    {
        [Key]
        public int MaPDK { get; set; }

        [Required]
        [StringLength(20)]
        public string MSSV { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(10)]
        public string Khu { get; set; }

        [Required]
        [StringLength(10)]
        public string MaPhong { get; set; }

        [Required]
        [StringLength(20)]
        public string HocKi { get; set; }

        [Required]
        [StringLength(20)]
        public string NamHoc { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime NgayGioDK { get; set; }

        public int ThoiHan { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayBD { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHONG PHONG { get; set; }

        public virtual SINHVIEN SINHVIEN { get; set; }
    }
}
