namespace EntityFramework_Crud
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Class")]
    public partial class Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class()
        {
            Student = new HashSet<Student>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int No { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int MajorNo { get; set; }

        public virtual Major Major { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Student { get; set; }
    }
}
