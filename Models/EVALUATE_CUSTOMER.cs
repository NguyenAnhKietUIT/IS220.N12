namespace IS220.N12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EVALUATE_CUSTOMER
    {
        [Key]
        [Column(Order = 0)]
        public int evaCustomerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        public int Point { get; set; }

        [Required]
        [StringLength(255)]
        public string Comment { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        public virtual HOTEL HOTEL { get; set; }
    }
}
