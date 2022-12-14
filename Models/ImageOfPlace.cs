namespace IS220.N12
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageOfPlace")]
    public partial class ImageOfPlace
    {
        [Key]
        public int ImagePlaceID { get; set; }

        [Required]
        [StringLength(250)]
        public string Link_Image { get; set; }

        public int? PlaceID { get; set; }

        public virtual PLACE PLACE { get; set; }
    }
}
