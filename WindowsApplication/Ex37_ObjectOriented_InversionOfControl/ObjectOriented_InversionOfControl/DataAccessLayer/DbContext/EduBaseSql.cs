namespace ObjectOriented_InversionOfControl
{
	using System;
	using System.Data.Entity;
	using System.Data.SqlClient;
	/// <summary>
	/// EduBase数据库上下文（基于SQL Server）；
	/// </summary>
	public partial class EduBaseSql : MyDbContext
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public EduBaseSql()
			: base("name=Sql")
		{
		}
		/// <summary>
		/// 实体集（用户）；
		/// </summary>
		public virtual DbSet<User> User { get; set; }
		/// <summary>
		/// 创建模型时；
		/// </summary>
		/// <param name="modelBuilder">模型建造器</param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");
			modelBuilder.Entity<User>()
				.Property(e => e.No)
				.IsFixedLength()
				.IsUnicode(false);
		}

		/// <summary>
		/// 保存更改；
		/// </summary>
		/// <param name="notUniqueErrorMessage">不唯一错误消息</param>
		/// <returns>受影响行数</returns>
		public override int SaveChanges(string notUniqueErrorMessage)
		{
			int rowAffected = 0;
			try
			{
				rowAffected = this.SaveChanges();
			}
			catch (Exception ex)
			{
				SqlException sqlEx = ex.InnerException.InnerException as SqlException;
				if (sqlEx.Number == 2627)
				{
					throw new ApplicationException(notUniqueErrorMessage);
				}
				throw;
			}
			return rowAffected;
		}
	}
}
