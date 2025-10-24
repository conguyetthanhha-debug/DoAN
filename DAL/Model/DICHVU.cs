namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DICHVU")]
    public partial class DICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DICHVU()
        {
            SDDVs = new HashSet<SDDV>();
        }

        [Key]
        [StringLength(20)]
        public string MaDV { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDV { get; set; }

        public int GiaDV { get; set; }

        [Required]
        [StringLength(50)]
        public string DonViTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SDDV> SDDVs { get; set; }
    }
}
