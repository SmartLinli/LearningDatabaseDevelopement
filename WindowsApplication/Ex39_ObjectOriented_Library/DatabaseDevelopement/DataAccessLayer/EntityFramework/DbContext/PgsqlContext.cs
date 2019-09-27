namespace SmartLinli.DatabaseDevelopement
{
	using Npgsql;
	using System;
	using System.Data.Entity;
	/// <summary>
	/// 数据库上下文（基于PostgreSQL）；
	/// </summary>
	public partial class PgsqlContext : MyDbContext
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PgsqlContext()
			: base("name=Pgsql")
		{
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
				NpgsqlException pgsqlEx = ex.InnerException.InnerException as NpgsqlException;
				if (pgsqlEx.Message.Substring(0, 5) == "23505")
				{
					throw new ApplicationException(notUniqueErrorMessage);
				}
				throw;
			}
			return rowAffected;
		}
	}
}
