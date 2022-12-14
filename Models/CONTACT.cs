namespace IS220.N12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTACT")]
    public partial class CONTACT
    {
        public int ContactID { get; set; }

        [StringLength(255)]
        public string userNameSend { get; set; }

        [Required]
        [StringLength(255)]
        public string userNameReceive { get; set; }

        [Required]
        [StringLength(255)]
        public string topicType { get; set; }

        [Required]
        [StringLength(255)]
        public string topicName { get; set; }

        [Required]
        [StringLength(255)]
        public string fullName { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(1000)]
        public string message { get; set; }
    }
}
