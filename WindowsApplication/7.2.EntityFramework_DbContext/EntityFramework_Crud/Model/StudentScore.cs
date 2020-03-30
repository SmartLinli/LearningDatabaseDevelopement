namespace EntityFramework_Crud
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentScore")]
    public partial class StudentScore
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string StudentNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string CourseNo { get; set; }

        public decimal? BasicScore { get; set; }

        public decimal? FinalScore { get; set; }

        public decimal? TotalScore { get; set; }

        public decimal? FacultyRate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LastModifyTime { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
