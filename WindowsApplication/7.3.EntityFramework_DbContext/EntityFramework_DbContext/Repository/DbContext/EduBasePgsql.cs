namespace EntityFramework_DbContext
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.ModelConfiguration.Conventions;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	/// <summary>
	/// EduBase数据库上下文（PostgreSQL）
	/// </summary>
	public partial class EduBasePgsql : EduBase
	{
		public EduBasePgsql()
			: base("name=EduBasePgsql")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.HasDefaultSchema("public");
			modelBuilder.Entity<Class>().ToTable("tb_Class");
			modelBuilder.Entity<Student>().ToTable("tb_Student");
			base.OnModelCreating(modelBuilder);
		}
	}
}
