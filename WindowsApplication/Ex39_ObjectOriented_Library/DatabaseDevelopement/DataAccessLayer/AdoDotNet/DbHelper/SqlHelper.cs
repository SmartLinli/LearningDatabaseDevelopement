using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// SQL Server助手；
	/// </summary>
	public class SqlHelper : DbHelperBase
	{
		/// <summary>
		/// 数据库连接字符串名称；
		/// </summary>
		protected override string DbConnectionStringName => "Sql";
		/// <summary>
		/// 获取数据库连接；
		/// </summary>
		/// <returns></returns>
		protected override DbConnection GetDbConnection()
		=>	new SqlConnection();
		/// <summary>
		/// 获取数据库参数；
		/// </summary>
		/// <returns></returns>
		protected override DbParameter GetDbParameter()
		=>	new SqlParameter();
		/// <summary>
		/// 获取数据适配器；
		/// </summary>
		/// <returns></returns>
		protected override DbDataAdapter GetDbDataAdapter()
		=>	new SqlDataAdapter();
		/// <summary>
		/// 设置参数的SQL Server数据类型；
		/// </summary>
		/// <param name="sqlDbType">SQL Server数据类型</param>
		protected override void SpecificParameterType(object dbType)
		{
			SqlDbType sqlDbType = SqlDbType.VarChar;
			if (dbType != null)
			{
				sqlDbType = (SqlDbType)dbType;
			}
			((SqlParameter)this._DbParameter).SqlDbType = sqlDbType;
		}
		/// <summary>
		/// 执行命令，提交数据；
		/// </summary>
		/// <returns>受影响行数</returns>
		public override int Submit()
		=>	base.ExecuteNonQuery(ex => (ex as SqlException).Number == 2627);
	}
}
