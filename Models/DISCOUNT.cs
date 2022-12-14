namespace IS220.N12
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DISCOUNT")]
    public partial class DISCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISCOUNT()
        {
            RESERVATIONs = new HashSet<RESERVATION>();
        }

        public int DiscountID { get; set; }

        [Required]
        [StringLength(300)]
        public string Describe_Dis { get; set; }

        [Column(TypeName = "money")]
        public decimal Requirement { get; set; }

        [Column(TypeName = "money")]
        public decimal Reduction { get; set; }

        public int NumberOfDiscount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVATION> RESERVATIONs { get; set; }
    }
}
