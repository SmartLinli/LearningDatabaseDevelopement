namespace ObjectOriented_InversionOfControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [StringLength(10)]
		[Column("No")]
        public string No { get; set; }

        [Required]
        [MaxLength(128)]
		[Column("Password")]
		public byte[] Password { get; set; }

		[Column("IsActivated")]
		public bool IsActivated { get; set; }

		[Column("LoginFailCount")]
		public int LoginFailCount { get; set; }
    }
}
