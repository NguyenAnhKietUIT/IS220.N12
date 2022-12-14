namespace IS220.N12
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EVALUATE_CUSTOMER
    {
        [Key]
        public int evaCustomerID { get; set; }

        public int HotelID { get; set; }

        public int CustomerID { get; set; }

        public int Point { get; set; }

        [Required]
        [StringLength(255)]
        public string Comment { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        public virtual HOTEL HOTEL { get; set; }
    }
}
