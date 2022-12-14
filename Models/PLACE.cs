namespace IS220.N12
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PLACE")]
    public partial class PLACE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PLACE()
        {
            HOTELs = new HashSet<HOTEL>();
            ImageOfPlaces = new HashSet<ImageOfPlace>();
        }

        public int PlaceID { get; set; }

        [Required]
        [StringLength(250)]
        public string PlaceName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOTEL> HOTELs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageOfPlace> ImageOfPlaces { get; set; }
    }
}
