namespace IS220.N12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SERVICE_SUPPLIED
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Describe_Service { get; set; }

        [Column(TypeName = "money")]
        public decimal Price_Service { get; set; }

        public virtual HOTEL HOTEL { get; set; }

        public virtual SERVICE SERVICE { get; set; }
    }
}
