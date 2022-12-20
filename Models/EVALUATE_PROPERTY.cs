namespace IS220.N12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EVALUATE_PROPERTY
    {
        [Key]
        public int evaPropertyID { get; set; }

        public int CustomerID { get; set; }

        public int PropertyID { get; set; }

        public int Point { get; set; }

        [Required]
        [StringLength(255)]
        public string Comment { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime TimeComment { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        public virtual PROPERTY PROPERTY { get; set; }
    }
}
