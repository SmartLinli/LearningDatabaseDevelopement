using Dapper;
using Npgsql;
using System.Configuration;
using System.Data;
using System.Linq;

namespace ObjectOriented_Dapper
{
	/// <summary>
	/// 基于Dapper的SQL助手；
	/// </summary>
	public class DapperPgsqlHelper
	{
		/// <summary>
		/// 获取数据库连接；
		/// </summary>
		/// <returns>数据库连接</returns>
		public static IDbConnection GetDbConnection()
		=>	new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Pgsql"].ToString());
		/// <summary>
		/// 执行存储过程，获取标量；
		/// </summary>
		/// <typeparam name="T">返回类型</typeparam>
		/// <param name="commmandText">命令文本</param>
		/// <param name="parameter">参数</param>
		/// <returns>标量</returns>
		public static T GetScalarFromSp<T>(string commmandText, object parameter)
		{
			using (IDbConnection db = GetDbConnection())
			{
				try
				{
					return db.Query<T>
						(commmandText
						, parameter
						, commandType: CommandType.StoredProcedure)
						.FirstOrDefault();
				}
				catch (NpgsqlException pgsqlEx)
				{
					if (pgsqlEx.Message.Substring(0, 5) == "23505")
					{
						throw new NotUniqueException();
					}
					throw;
				}
			}
		}
	}
}
