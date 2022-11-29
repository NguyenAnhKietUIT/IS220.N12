namespace IS220.N12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EVALUATE_HOTEL
    {
        [Key]
        [Column(Order = 0)]
        public int evaHotelID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelID { get; set; }

        public int Point { get; set; }

        [Required]
        [StringLength(255)]
        public string Comment { get; set; }

        [Required]
        [StringLength(255)]
        public string Image_Feedback { get; set; }
    }
}
