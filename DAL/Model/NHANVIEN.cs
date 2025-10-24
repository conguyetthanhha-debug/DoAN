namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            DANGNHAPs = new HashSet<DANGNHAP>();
            HOADONs = new HashSet<HOADON>();
            NHANVIEN1 = new HashSet<NHANVIEN>();
            PHIEUDKs = new HashSet<PHIEUDK>();
        }

        [Key]
        [StringLength(20)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(20)]
        public string CMND { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(120)]
        public string Email { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        public int? Luong { get; set; }

        [StringLength(20)]
        public string MaNQL { get; set; }

        [StringLength(255)]
        public string AnhChanDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANGNHAP> DANGNHAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN> NHANVIEN1 { get; set; }

        public virtual NHANVIEN NHANVIEN2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDK> PHIEUDKs { get; set; }
    }
}
