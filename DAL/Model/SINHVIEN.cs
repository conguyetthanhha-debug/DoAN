namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SINHVIEN")]
    public partial class SINHVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SINHVIEN()
        {
            PHIEUDKs = new HashSet<PHIEUDK>();
        }

        [Key]
        [StringLength(20)]
        public string MSSV { get; set; }



        [StringLength(30)]
        public string DienSV { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        public bool Phai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgSinh { get; set; }

        [StringLength(20)]
        public string CMND { get; set; }

        [StringLength(120)]
        public string Email { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string BHYT { get; set; }

        [StringLength(100)]
        public string QueQuan { get; set; }

        [StringLength(255)]
        public string AnhChanDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDK> PHIEUDKs { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
