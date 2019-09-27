using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace ObjectOriented_MultiDb
{

	/// <summary>
	/// PGSQL助手；
	/// </summary>
	public class PgSqlHelper
	{
		/// <summary>
		/// PGSQL命令；
		/// </summary>
		private NpgsqlCommand PgSqlCommand;
		/// <summary>
		/// PGSQL参数；
		/// </summary>
		private NpgsqlParameter PgSqlParameter;
		/// <summary>
		/// 新建PGSQL命令；
		/// </summary>
		/// <returns>PGSQL助手</returns>
		public PgSqlHelper NewCommand()
		{
			NpgsqlConnection pgsqlConnection = new NpgsqlConnection();
			pgsqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["PgSql"].ToString();
			this.PgSqlCommand = pgsqlConnection.CreateCommand();
			return this;
		}
		/// <summary>
		/// 新建PGSQL命令；
		/// </summary>
		/// <param name="commandText">命令文本</param>
		/// <returns>PGSQL助手</returns>
		public PgSqlHelper NewCommand(string commandText)
		{
			this.NewCommand();
			return this.CommandText(commandText);
		}
		/// <summary>
		/// 设置PGSQL命令的命令文本
		/// </summary>
		/// <param name="commandText">命令文本</param>
		/// <returns>PGSQL助手</returns>
		public PgSqlHelper CommandText(string commandText)
		{
			this.PgSqlCommand.CommandText = commandText;
			return this;
		}
		/// <summary>
		/// 设置PGSQL命令是否存储过程；
		/// </summary>
		/// <param name="isStoredProcedure">是否存储过程</param>
		/// <returns>PGSQL助手</returns>
		public PgSqlHelper IsStoredProcedure(bool isStoredProcedure)
		{
			this.PgSqlCommand.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
			return this;
		}
		/// <summary>
		/// 新建PGSQL参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <returns>PGSQL助手</returns>
		public PgSqlHelper NewParameter(string parameterName)
		{
			this.PgSqlParameter = new NpgsqlParameter();
			this.PgSqlParameter.ParameterName = parameterName;
			this.PgSqlCommand.Parameters.Add(this.PgSqlParameter);
			return this;
		}
		/// <summary>
		/// 新建PGSQL参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="value">参数值</param>
		/// <returns>PGSQL助手</returns>
		public PgSqlHelper NewParameter(string parameterName, object value)
		{
			this.NewParameter(parameterName);
			this.PgSqlParameter.Value = value;
			return this;
		}
		/// <summary>
		/// 设置PGSQL参数的PostgreSQL数据类型；
		/// </summary>
		/// <param name="sqlDbType">PostgreSQL数据类型</param>
		/// <returns>PGSQL助手</returns>
		public PgSqlHelper ParameterType(NpgsqlDbType pgsqlDbType)
		{
			this.PgSqlParameter.NpgsqlDbType = pgsqlDbType;
			return this;
		}
		/// <summary>
		/// 设置PGSQL参数的长度；
		/// </summary>
		/// <param name="size">长度</param>
		/// <returns>PGSQL助手</returns>
		public PgSqlHelper ParameterSize(int size)
		{
			this.PgSqlParameter.Size = size;
			return this;
		}
		/// <summary>
		/// 设置PGSQL参数的值；
		/// </summary>
		/// <param name="value">参数值</param>
		/// <returns>PGSQL助手</returns>
		public PgSqlHelper ParameterValue(object value)
		{
			this.PgSqlParameter.Value = value;
			return this;
		}
		/// <summary>
		/// 设置PGSQL参数的方向；
		/// </summary>
		/// <param name="parameterDirection">参数方向</param>
		/// <returns>PGSQL助手</returns>
		public PgSqlHelper ParameterDirection(ParameterDirection parameterDirection)
		{
			this.PgSqlParameter.Direction = parameterDirection;
			return this;
		}
		/// <summary>
		/// 执行PGSQL命令，获取标量；
		/// </summary>
		/// <typeparam name="T">标量类型</typeparam>
		/// <returns>标量值</returns>
		public T GetScalar<T>()
		{
			object result = null;
			this.PgSqlCommand.Connection.Open();
			result = this.PgSqlCommand.ExecuteScalar();
			this.PgSqlCommand.Connection.Close();
			return (T)result;
		}
		/// <summary>
		/// 执行PGSQL命令，获取数据读取器；
		/// 完成读取后，请手动关闭数据读取器；
		/// </summary>
		/// <returns>数据读取器</returns>
		public IDataReader GetReader()
		{
			this.PgSqlCommand.Connection.Open();
			NpgsqlDataReader pgsqlDataReader = this.PgSqlCommand.ExecuteReader();
			return pgsqlDataReader;
		}
		/// <summary>
		/// 执行PGSQL命令，写入数据；
		/// </summary>
		/// <returns>受影响行数</returns>
		public int NonQuery()
		{
			int rowAffected = 0;
			try
			{
				this.PgSqlCommand.Connection.Open();
				rowAffected = this.PgSqlCommand.ExecuteNonQuery();
			}
			catch (NpgsqlException pgsqlEx)
			{
				if (pgsqlEx.Message.Substring(0, 5) == "23505")
				{
					throw new NotUniqueException();
				}
				throw;
			}
			finally
			{
				this.PgSqlCommand.Connection.Close();
			}
			return rowAffected;
		}
	}
}