namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            SDDVs = new HashSet<SDDV>();
        }

        [Key]
        public int MaHD { get; set; }

        public short Nam { get; set; }

        public byte Thang { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayHD { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(10)]
        public string MaPhong { get; set; }

        [Required]
        [StringLength(10)]
        public string Khu { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHONG PHONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SDDV> SDDVs { get; set; }
    }
}
