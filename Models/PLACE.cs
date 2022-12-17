namespace IS220.N12.Models
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
            PROPERTies = new HashSet<PROPERTY>();
        }

        public int PlaceID { get; set; }

        [Required]
        [StringLength(250)]
        public string PlaceName { get; set; }

        [Required]
        [StringLength(1000)]
        public string ImageOfPlace { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROPERTY> PROPERTies { get; set; }
    }
}
