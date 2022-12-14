namespace IS220.N12
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RESERVATION")]
    public partial class RESERVATION
    {
        public int ReservationID { get; set; }

        public int CustomerID { get; set; }

        public int RoomID { get; set; }

        [Required]
        [StringLength(255)]
        public string NameCheckInPerson { get; set; }

        [Required]
        [StringLength(12)]
        public string PhoneCheckInPerson { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CheckIn { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CheckOut { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total { get; set; }

        public int Status_Reservation { get; set; }

        public int? DiscountID { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        public virtual DISCOUNT DISCOUNT { get; set; }

        public virtual ROOM ROOM { get; set; }
    }
}
