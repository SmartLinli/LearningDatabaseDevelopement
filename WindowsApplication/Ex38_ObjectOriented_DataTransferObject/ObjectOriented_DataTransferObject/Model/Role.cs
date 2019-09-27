namespace ObjectOriented_DataTransferObject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	/// <summary>
	/// 角色；
	/// </summary>
    [Table("Role")]
    public partial class Role
    {
		/// <summary>
		/// 构造函数；
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Role()
        {
            User = new HashSet<User>();
        }
		/// <summary>
		/// 编号；
		/// </summary>
        [Key]
        public int No { get; set; }
		/// <summary>
		/// 名称；
		/// </summary>
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
		/// <summary>
		/// 用户；
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<User> User { get; set; }
    }
}
