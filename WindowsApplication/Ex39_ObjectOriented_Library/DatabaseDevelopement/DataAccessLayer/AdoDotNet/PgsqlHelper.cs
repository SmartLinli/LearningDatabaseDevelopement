using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Data;

namespace SmartLinli.DatabaseDevelopement
{

	/// <summary>
	/// PGSQL助手；
	/// </summary>
	public class PgsqlHelper
	{
		/// <summary>
		/// PGSQL命令；
		/// </summary>
		private NpgsqlCommand _PgsqlCommand;
		/// <summary>
		/// PGSQL参数；
		/// </summary>
		private NpgsqlParameter _PgsqlParameter;
		/// <summary>
		/// PGSQL数据适配器；
		/// </summary>
		private NpgsqlDataAdapter _PgsqlDataAdapter;
		/// <summary>
		/// SQL数据适配器；
		/// </summary>
		private NpgsqlDataAdapter PgsqlDataAdapter
		{
			get
			{
				if (this._PgsqlDataAdapter == null)
				{
					this._PgsqlDataAdapter = new NpgsqlDataAdapter();
				}
				return this._PgsqlDataAdapter;
			}
		}
		/// <summary>
		/// 新建PGSQL命令；
		/// </summary>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper NewCommand()
		{
			NpgsqlConnection pgsqlConnection = new NpgsqlConnection();
			pgsqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Pgsql"].ToString();
			this._PgsqlCommand = pgsqlConnection.CreateCommand();
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
			this._PgsqlCommand.CommandText = commandText;
			return this;
		}
		/// <summary>
		/// 设置PGSQL命令是否存储过程；
		/// </summary>
		/// <param name="isStoredProcedure">是否存储过程</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper IsStoredProcedure(bool isStoredProcedure = true)
		{
			this._PgsqlCommand.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
			return this;
		}
		/// <summary>
		/// 新建PGSQL参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper NewParameter(string parameterName)
		{
			this._PgsqlParameter = new NpgsqlParameter();
			this._PgsqlParameter.ParameterName = parameterName;
			this._PgsqlCommand.Parameters.Add(this._PgsqlParameter);
			return this;
		}
		/// <summary>
		/// 包含PGSQL参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="value">参数值</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper With(string parameterName, object value)
		{
			this.NewParameter(parameterName);
			this._PgsqlParameter.Value = value;
			return this;
		}
		/// <summary>
		/// 包含PGSQL参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="pgsqlDbType">PostgreSQL数据类型</param>
		/// <param name="size">长度</param>
		/// <param name="sourceColumn">来源列</param>
		/// <param name="dataRowVersion">数据行版本</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper With(string parameterName, NpgsqlDbType pgsqlDbType = NpgsqlDbType.Text, int size = 0, string sourceColumn = "", DataRowVersion dataRowVersion = DataRowVersion.Current)
		{
			this.NewParameter(parameterName);
			this._PgsqlParameter.NpgsqlDbType = pgsqlDbType;
			this._PgsqlParameter.Size = size;
			sourceColumn =
				sourceColumn == "" ?
				parameterName.Substring(1, parameterName.Length - 1)
				: sourceColumn;
			this._PgsqlParameter.SourceColumn = sourceColumn;
			this._PgsqlParameter.SourceVersion = dataRowVersion;
			return this;
		}
		/// <summary>
		/// 设置PGSQL参数的PostgreSQL数据类型；
		/// </summary>
		/// <param name="sqlDbType">PostgreSQL数据类型</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper ParameterType(NpgsqlDbType pgsqlDbType)
		{
			this._PgsqlParameter.NpgsqlDbType = pgsqlDbType;
			return this;
		}
		/// <summary>
		/// 设置PGSQL参数的长度；
		/// </summary>
		/// <param name="size">长度</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper ParameterSize(int size)
		{
			this._PgsqlParameter.Size = size;
			return this;
		}
		/// <summary>
		/// 设置PGSQL参数的值；
		/// </summary>
		/// <param name="value">参数值</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper ParameterValue(object value)
		{
			this._PgsqlParameter.Value = value;
			return this;
		}
		/// <summary>
		/// 设置PGSQL参数的方向；
		/// </summary>
		/// <param name="parameterDirection">参数方向</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper ParameterDirection(ParameterDirection parameterDirection)
		{
			this._PgsqlParameter.Direction = parameterDirection;
			return this;
		}
		/// <summary>
		/// 将新建的PGSQL命令设为PGSQL数据适配器的插入命令；
		/// </summary>
		/// <returns>SQL助手</returns>
		public PgsqlHelper AsInsertCommand()
		{
			this.PgsqlDataAdapter.InsertCommand = this._PgsqlCommand;
			return this;
		}
		/// <summary>
		/// 将新建的PGSQL命令设为PGSQL数据适配器的更新命令；
		/// </summary>
		/// <returns>SQL助手</returns>
		public PgsqlHelper AsUpdateCommand()
		{
			this.PgsqlDataAdapter.UpdateCommand = this._PgsqlCommand;
			return this;
		}
		/// <summary>
		/// 将新建的PGSQL命令设为PGSQL数据适配器的删除命令；
		/// </summary>
		/// <returns>SQL助手</returns>
		public PgsqlHelper AsDeleteCommand()
		{
			this.PgsqlDataAdapter.DeleteCommand = this._PgsqlCommand;
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
			this._PgsqlCommand.Connection.Open();
			result = this._PgsqlCommand.ExecuteScalar();
			this._PgsqlCommand.Connection.Close();
			return (T)result;
		}
		/// <summary>
		/// 执行PGSQL命令，获取数据读取器；
		/// 完成读取后，请手动关闭数据读取器；
		/// </summary>
		/// <returns>数据读取器</returns>
		public IDataReader GetReader()
		{
			this._PgsqlCommand.Connection.Open();
			NpgsqlDataReader pgsqlDataReader = this._PgsqlCommand.ExecuteReader();
			return pgsqlDataReader;
		}
		/// <summary>
		/// 执行PGSQL命令，获取数据表；
		/// </summary>
		/// <returns>数据表</returns>
		public DataTable GetTable()
		{
			DataTable dataTable = new DataTable();
			NpgsqlDataAdapter pgsqlDataAdapter = new NpgsqlDataAdapter();
			pgsqlDataAdapter.SelectCommand = this._PgsqlCommand;
			this._PgsqlCommand.Connection.Open();
			pgsqlDataAdapter.Fill(dataTable);
			this._PgsqlCommand.Connection.Close();
			return dataTable;
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
				this._PgsqlCommand.Connection.Open();
				rowAffected = this._PgsqlCommand.ExecuteNonQuery();
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
				this._PgsqlCommand.Connection.Close();
			}
			return rowAffected;
		}
		/// <summary>
		/// 提交；
		/// </summary>
		/// <param name="dataTable">数据表</param>
		/// <returns>受影响行数</returns>
		public int Submit(DataTable dataTable)
		{
			return this.PgsqlDataAdapter.Update(dataTable);
		}
	}
}