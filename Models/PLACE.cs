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
        public int PlaceID { get; set; }

        [Required]
        [StringLength(250)]
        public string PlaceName { get; set; }
    }
}
