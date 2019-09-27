namespace ObjectOriented_EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	/// <summary>
	/// 用户；
	/// </summary>
	[Table("User")]
	public partial class User
	{
		/// <summary>
		/// 用户号；
		/// </summary>
		[Key]
		[StringLength(10)]
		public string No { get; set; }
		/// <summary>
		/// 密码；
		/// </summary>
		[Required]
		[MaxLength(128)]
		public byte[] Password { get; set; }
		/// <summary>
		/// 是否激活；
		/// </summary>
		public bool IsActivated { get; set; }
		/// <summary>
		/// 登录失败计数；
		/// </summary>
		public int LoginFailCount { get; set; }
	}
}
