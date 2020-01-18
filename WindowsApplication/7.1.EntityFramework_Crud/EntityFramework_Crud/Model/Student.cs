namespace EntityFramework_Crud
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            StudentScore = new HashSet<StudentScore>();
        }

        [Key]
        [StringLength(10)]
        public string No { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public bool Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [StringLength(100)]
        public string PoliticalStatus { get; set; }

        [StringLength(100)]
        public string Nationality { get; set; }

        [StringLength(100)]
        public string Province { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string GraduateFrom { get; set; }

        [StringLength(100)]
        public string IdentificationCard { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Speciality { get; set; }

        public byte[] Photo { get; set; }

        public int ClassNo { get; set; }

        public virtual Class Class { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentScore> StudentScore { get; set; }
    }
}
