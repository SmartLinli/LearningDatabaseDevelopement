namespace EntityFramework_Linq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	/// <summary>
	/// ¿Î³Ì£»
	/// </summary>
    public partial class Course
    {
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
        public string StudyType { get; set; }

        [Required]
        [StringLength(10)]
        public string ExamType { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<SelectedCourse> SelectedCourse { get; set; }
	}
}
