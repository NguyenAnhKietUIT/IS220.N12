namespace IS220.N12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROPERTY")]
    public partial class PROPERTY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROPERTY()
        {
            EVALUATE_CUSTOMER = new HashSet<EVALUATE_CUSTOMER>();
            EVALUATE_PROPERTY = new HashSet<EVALUATE_PROPERTY>();
            ROOMs = new HashSet<ROOM>();
            SERVICEs = new HashSet<SERVICE>();
        }

        public int PropertyID { get; set; }

        [Required]
        [StringLength(255)]
        public string PropertyName { get; set; }

        [Required]
        [StringLength(100)]
        public string CheckInTime { get; set; }

        [Required]
        [StringLength(100)]
        public string CheckOutTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Address_Property { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Detail_Property { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone_Property { get; set; }

        [Required]
        [StringLength(15)]
        public string TypeName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Image_Property { get; set; }

        public int AccountID { get; set; }

        public int PlaceID { get; set; }

        [Required]
        [StringLength(15)]
        public string TypeOfCategory { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVALUATE_CUSTOMER> EVALUATE_CUSTOMER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVALUATE_PROPERTY> EVALUATE_PROPERTY { get; set; }

        public virtual PLACE PLACE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROOM> ROOMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVICE> SERVICEs { get; set; }
    }
}
