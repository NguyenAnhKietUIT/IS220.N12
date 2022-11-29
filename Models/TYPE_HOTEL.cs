namespace IS220.N12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TYPE_HOTEL
    {
        [Key]
        public int TypeID { get; set; }

        [Required]
        [StringLength(250)]
        public string TypeName { get; set; }
    }
}
