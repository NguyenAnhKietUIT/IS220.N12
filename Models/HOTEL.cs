namespace IS220.N12
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOTEL")]
    public partial class HOTEL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOTEL()
        {
            EVALUATE_CUSTOMER = new HashSet<EVALUATE_CUSTOMER>();
            EVALUATE_HOTEL = new HashSet<EVALUATE_HOTEL>();
            ROOMs = new HashSet<ROOM>();
            SERVICEs = new HashSet<SERVICE>();
        }

        public int HotelID { get; set; }

        [Required]
        [StringLength(255)]
        public string HotelName { get; set; }

        [Required]
        [StringLength(100)]
        public string CheckInTime { get; set; }

        [Required]
        [StringLength(100)]
        public string CheckOutTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Address_Hotel { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Detail_Hotel { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone_Hotel { get; set; }

        public int TypeID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Image_Hotel { get; set; }

        public int AccountID { get; set; }

        public int PlaceID { get; set; }

        public int TypeOfCategory { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVALUATE_CUSTOMER> EVALUATE_CUSTOMER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVALUATE_HOTEL> EVALUATE_HOTEL { get; set; }

        public virtual PLACE PLACE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROOM> ROOMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVICE> SERVICEs { get; set; }
    }
}
