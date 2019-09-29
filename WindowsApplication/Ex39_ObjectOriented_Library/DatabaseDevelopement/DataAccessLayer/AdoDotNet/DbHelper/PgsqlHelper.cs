using Npgsql;
using NpgsqlTypes;
using System.Data.Common;

namespace SmartLinli.DatabaseDevelopement
{

	/// <summary>
	/// PostgreSQL助手；
	/// </summary>
	public class PgsqlHelper : DbHelperBase
	{
		/// <summary>
		/// 数据库连接字符串名称；
		/// </summary>
		protected override string DbConnectionStringName => "Pgsql";
		/// <summary>
		/// 获取数据库连接；
		/// </summary>
		/// <returns></returns>
		protected override DbConnection GetDbConnection()
		=>	new NpgsqlConnection();
		/// <summary>
		/// 获取数据库参数；
		/// </summary>
		/// <returns></returns>
		protected override DbParameter GetDbParameter()
		=>	new NpgsqlParameter();
		/// <summary>
		/// 获取数据适配器；
		/// </summary>
		/// <returns></returns>
		protected override DbDataAdapter GetDbDataAdapter()
		=>	new NpgsqlDataAdapter();
		/// <summary>
		/// 设置参数的PostgreSQL助手数据类型；
		/// </summary>
		/// <param name="sqlDbType">SQL Server数据类型</param>
		protected override void SpecificParameterType(object dbType)
		{
			NpgsqlDbType pgsqlDbType = NpgsqlDbType.Varchar;
			if (dbType != null)
			{
				pgsqlDbType = (NpgsqlDbType)dbType;
			}
			((NpgsqlParameter)this._DbParameter).NpgsqlDbType = pgsqlDbType;
		}
		/// <summary>
		/// 执行命令，提交数据；
		/// </summary>
		/// <returns>受影响行数</returns>
		public override int Submit()
		=>	base.ExecuteNonQuery(ex => (ex as NpgsqlException).Message.Substring(0, 5) == "23505");
	}
}