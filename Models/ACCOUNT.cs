namespace IS220.N12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("ACCOUNT")]
    public partial class ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCOUNT()
        {
            CUSTOMERs = new HashSet<CUSTOMER>();
            HOTELs = new HashSet<HOTEL>();
        }

        public int AccountID { get; set; }

        [Required]
        [StringLength(255)]
        [Remote("IsExists", "ACCOUNT", ErrorMessage ="Username is already exist")]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Passwords { get; set; }

        [Required]
        [StringLength(255)]
        public string GMAIL { get; set; }

        public int ROLES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTOMER> CUSTOMERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOTEL> HOTELs { get; set; }
    }
}
