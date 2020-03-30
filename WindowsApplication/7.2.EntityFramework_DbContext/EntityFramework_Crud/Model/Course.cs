namespace EntityFramework_Crud
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            StudentScore = new HashSet<StudentScore>();
        }

        [Key]
        [StringLength(4)]
        public string No { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Pinyin { get; set; }

        [StringLength(4)]
        public string PreCourseNo { get; set; }

        public decimal Credit { get; set; }

        [Required]
        [StringLength(20)]
        public string StudyTypeNo { get; set; }

        [Required]
        [StringLength(10)]
        public string ExamTypeNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentScore> StudentScore { get; set; }
    }
}
