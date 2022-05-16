using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ObjectOriented_SqlHelper
{
	/// <summary>
	/// 违反唯一性异常；
	/// </summary>
	public class NotUniqueException : Exception { }
	/// <summary>
	/// SQL助手；
	/// </summary>
	public class SqlHelper
	{
		/// <summary>
		/// SQL命令；
		/// </summary>
		private SqlCommand SqlCommand { get; set; }
		/// <summary>
		/// SQL参数；
		/// </summary>
		private SqlParameter SqlParameter { get; set; }
		/// <summary>
		/// 新建SQL命令；
		/// </summary>
		/// <returns>SQL助手</returns>
		public SqlHelper NewCommand()
		{
			SqlConnection sqlConnection = new SqlConnection();
			sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ToString();
			this.SqlCommand = sqlConnection.CreateCommand();
			return this;
		}
		/// <summary>
		/// 新建SQL命令；
		/// </summary>
		/// <param name="commandText">命令文本</param>
		/// <returns>SQL助手</returns>
		public SqlHelper NewCommand(string commandText)
		{
			this.NewCommand();
			return this.CommandText(commandText);
		}
		/// <summary>
		/// 设置SQL命令的命令文本
		/// </summary>
		/// <param name="commandText">命令文本</param>
		/// <returns>SQL助手</returns>
		public SqlHelper CommandText(string commandText)
		{
			this.SqlCommand.CommandText = commandText;
			return this;
		}
		/// <summary>
		/// 设置SQL命令是否存储过程；
		/// </summary>
		/// <param name="isStoredProcedure">是否存储过程</param>
		/// <returns>SQL助手</returns>
		public SqlHelper IsStoredProcedure(bool isStoredProcedure = true)
		{
			this.SqlCommand.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
			return this;
		}
		/// <summary>
		/// 新建SQL参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <returns>SQL助手</returns>
		public SqlHelper NewParameter(string parameterName)
		{
			this.SqlParameter = new SqlParameter();
			this.SqlParameter.ParameterName = parameterName;
			this.SqlCommand.Parameters.Add(this.SqlParameter);
			return this;
		}
		/// <summary>
		/// 新建SQL参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="value">参数值</param>
		/// <returns>SQL助手</returns>
		public SqlHelper NewParameter(string parameterName, object value)
		{
			this.NewParameter(parameterName);
			this.SqlParameter.Value = value;
			return this;
		}
		/// <summary>
		/// 设置SQL参数的SQL Server数据类型；
		/// </summary>
		/// <param name="sqlDbType">SQL Server数据类型</param>
		/// <returns>SQL助手</returns>
		public SqlHelper ParameterType(SqlDbType sqlDbType)
		{
			this.SqlParameter.SqlDbType = sqlDbType;
			return this;
		}
		/// <summary>
		/// 设置SQL参数的长度；
		/// </summary>
		/// <param name="size">长度</param>
		/// <returns>SQL助手</returns>
		public SqlHelper ParameterSize(int size)
		{
			this.SqlParameter.Size = size;
			return this;
		}
		/// <summary>
		/// 设置SQL参数的值；
		/// </summary>
		/// <param name="value">参数值</param>
		/// <returns>SQL助手</returns>
		public SqlHelper ParameterValue(object value)
		{
			this.SqlParameter.Value = value;
			return this;
		}
		/// <summary>
		/// 设置SQL参数的方向；
		/// </summary>
		/// <param name="parameterDirection">参数方向</param>
		/// <returns>SQL助手</returns>
		public SqlHelper ParameterDirection(ParameterDirection parameterDirection)
		{
			this.SqlParameter.Direction = parameterDirection;
			return this;
		}
		/// <summary>
		/// 执行SQL命令，获取标量；
		/// </summary>
		/// <typeparam name="T">标量类型</typeparam>
		/// <returns>标量值</returns>
		public T GetScalar<T>()
		{
			object result = null;
			this.SqlCommand.Connection.Open();
			result = this.SqlCommand.ExecuteScalar();
			this.SqlCommand.Connection.Close();
			return (T)result;
		}
		/// <summary>
		/// 执行SQL命令，获取数据读取器；
		/// 完成读取后，请手动关闭数据读取器；
		/// </summary>
		/// <returns>数据读取器</returns>
		public IDataReader GetReader()
		{
			this.SqlCommand.Connection.Open();
			SqlDataReader sqlDataReader = this.SqlCommand.ExecuteReader();
			return sqlDataReader;
		}
		/// <summary>
		/// 执行SQL命令，写入数据；
		/// </summary>
		/// <returns>受影响行数</returns>
		public int NonQuery()
		{
			int rowAffected = 0;
			try
			{
				this.SqlCommand.Connection.Open();
				rowAffected = this.SqlCommand.ExecuteNonQuery();
			}
			catch (SqlException sqlEx)
			{
				if (sqlEx.Number == 2627)
				{
					throw new NotUniqueException();
				}
				throw;
			}
			finally
			{
				this.SqlCommand.Connection.Close();
			}
			return rowAffected;
		}
	}
}