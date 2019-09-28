namespace Record_Update_Orm
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [Key]
        [StringLength(10)]
        public string No { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public bool Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public int ClassNo { get; set; }

        [StringLength(100)]
        public string Speciality { get; set; }

        public virtual Class Class { get; set; }
    }
}
