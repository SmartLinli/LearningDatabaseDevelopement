using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Data;

namespace ObjectOriented_MultiDb
{

	/// <summary>
	/// PGSQL助手；
	/// </summary>
	public class PgsqlHelper
	{
		/// <summary>
		/// PGSQL命令；
		/// </summary>
		private NpgsqlCommand PgsqlCommand { get; set; }
		/// <summary>
		/// PGSQL参数；
		/// </summary>
		private NpgsqlParameter PgsqlParameter { get; set; }
		/// <summary>
		/// 新建PGSQL命令；
		/// </summary>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper NewCommand()
		{
			NpgsqlConnection pgsqlConnection = new NpgsqlConnection();
			pgsqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Pgsql"].ToString();
			this.PgsqlCommand = pgsqlConnection.CreateCommand();
			return this;
		}
		/// <summary>
		/// 新建PGSQL命令；
		/// </summary>
		/// <param name="commandText">命令文本</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper NewCommand(string commandText)
		{
			this.NewCommand();
			return this.CommandText(commandText);
		}
		/// <summary>
		/// 设置PGSQL命令的命令文本
		/// </summary>
		/// <param name="commandText">命令文本</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper CommandText(string commandText)
		{
			this.PgsqlCommand.CommandText = commandText;
			return this;
		}
		/// <summary>
		/// 设置PGSQL命令是否存储过程；
		/// </summary>
		/// <param name="isStoredProcedure">是否存储过程</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper IsStoredProcedure(bool isStoredProcedure = true)
		{
			this.PgsqlCommand.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
			return this;
		}
		/// <summary>
		/// 新建PGSQL参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper NewParameter(string parameterName)
		{
			this.PgsqlParameter = new NpgsqlParameter();
			this.PgsqlParameter.ParameterName = parameterName;
			this.PgsqlCommand.Parameters.Add(this.PgsqlParameter);
			return this;
		}
		/// <summary>
		/// 新建PGSQL参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="value">参数值</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper NewParameter(string parameterName, object value)
		{
			this.NewParameter(parameterName);
			this.PgsqlParameter.Value = value;
			return this;
		}
		/// <summary>
		/// 设置PGSQL参数的PostgreSQL数据类型；
		/// </summary>
		/// <param name="sqlDbType">PostgreSQL数据类型</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper ParameterType(NpgsqlDbType pgsqlDbType)
		{
			this.PgsqlParameter.NpgsqlDbType = pgsqlDbType;
			return this;
		}
		/// <summary>
		/// 设置PGSQL参数的长度；
		/// </summary>
		/// <param name="size">长度</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper ParameterSize(int size)
		{
			this.PgsqlParameter.Size = size;
			return this;
		}
		/// <summary>
		/// 设置PGSQL参数的值；
		/// </summary>
		/// <param name="value">参数值</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper ParameterValue(object value)
		{
			this.PgsqlParameter.Value = value;
			return this;
		}
		/// <summary>
		/// 设置PGSQL参数的方向；
		/// </summary>
		/// <param name="parameterDirection">参数方向</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper ParameterDirection(ParameterDirection parameterDirection)
		{
			this.PgsqlParameter.Direction = parameterDirection;
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
			this.PgsqlCommand.Connection.Open();
			result = this.PgsqlCommand.ExecuteScalar();
			this.PgsqlCommand.Connection.Close();
			return (T)result;
		}
		/// <summary>
		/// 执行PGSQL命令，获取数据读取器；
		/// 完成读取后，请手动关闭数据读取器；
		/// </summary>
		/// <returns>数据读取器</returns>
		public IDataReader GetReader()
		{
			this.PgsqlCommand.Connection.Open();
			NpgsqlDataReader pgsqlDataReader = this.PgsqlCommand.ExecuteReader();
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
				this.PgsqlCommand.Connection.Open();
				rowAffected = this.PgsqlCommand.ExecuteNonQuery();
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
				this.PgsqlCommand.Connection.Close();
			}
			return rowAffected;
		}
	}
}