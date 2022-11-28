namespace IS220.N12.Models
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
            ROOMs = new HashSet<ROOM>();
            SERVICE_SUPPLIED = new HashSet<SERVICE_SUPPLIED>();
        }

        public int HotelID { get; set; }

        [Required]
        [StringLength(255)]
        public string HotelName { get; set; }

        [Required]
        [StringLength(255)]
        public string Address_Hotel { get; set; }

        public int Phone_Hotel { get; set; }

        [Required]
        [StringLength(255)]
        public string TypeOfHotel { get; set; }

        [Required]
        [StringLength(1000)]
        public string Image_Hotel { get; set; }

        public int AccountID { get; set; }

        public int PlaceID { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVALUATE_CUSTOMER> EVALUATE_CUSTOMER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROOM> ROOMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVICE_SUPPLIED> SERVICE_SUPPLIED { get; set; }
    }
}
