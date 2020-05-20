namespace EntityFramework_Linq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	/// <summary>
	/// ÒÑÑ¡¿Î³Ì£»
	/// </summary>
    public partial class SelectedCourse
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string StudentNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string CourseNo { get; set; }

        public bool OrderBook { get; set; }

		public virtual Course Course { get; set; }
	}
}
