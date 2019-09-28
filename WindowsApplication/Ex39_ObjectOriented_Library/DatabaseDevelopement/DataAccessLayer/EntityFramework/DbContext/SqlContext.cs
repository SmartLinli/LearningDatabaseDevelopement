namespace SmartLinli.DatabaseDevelopement
{
	using System;
	using System.Data.Entity;
	using System.Data.SqlClient;
	/// <summary>
	/// 数据库上下文（基于SQL Server）；
	/// </summary>
	public partial class SqlContext : MyDbContext
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public SqlContext()
			: base("name=Sql")
		{
		}
		/// <summary>
		/// 创建模型时；
		/// </summary>
		/// <param name="modelBuilder">模型建造器</param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");
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
