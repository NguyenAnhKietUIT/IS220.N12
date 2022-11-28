namespace IS220.N12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageOfType")]
    public partial class ImageOfType
    {
        public int ImageOfTypeID { get; set; }

        [Required]
        [StringLength(250)]
        public string Link_Image { get; set; }

        public int TypeID { get; set; }
    }
}
