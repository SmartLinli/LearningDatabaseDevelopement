namespace EntityFramework_DbContext
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	/// <summary>
	/// EduBase数据库上下文（SQL Server）
	/// </summary>
	public partial class EduBaseSql : EduBase
	{
		public EduBaseSql()
			: base("name=EduBaseSql")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");
			modelBuilder.Entity<Class>().ToTable("tb_Class");
			modelBuilder.Entity<Student>().ToTable("tb_Student");
			base.OnModelCreating(modelBuilder);
		}
	}
}
