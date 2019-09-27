using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// SQL助手；
	/// </summary>
	public class SqlHelper
	{
		/// <summary>
		/// SQL命令；
		/// </summary>
		private SqlCommand _SqlCommand;
		/// <summary>
		/// SQL参数；
		/// </summary>
		private SqlParameter _SqlParameter;
		/// <summary>
		/// SQL数据适配器；
		/// </summary>
		private SqlDataAdapter _SqlDataAdapter;
		/// <summary>
		/// SQL数据适配器；
		/// </summary>
		private SqlDataAdapter SqlDataAdapter
		{
			get
			{
				if (this._SqlDataAdapter == null)
				{
					this._SqlDataAdapter = new SqlDataAdapter();
				}
				return this._SqlDataAdapter;
			}
		}
		/// <summary>
		/// 新建SQL命令；
		/// </summary>
		/// <returns>SQL助手</returns>
		public SqlHelper NewCommand()
		{
			SqlConnection sqlConnection = new SqlConnection();
			sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ToString();
			this._SqlCommand = sqlConnection.CreateCommand();
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
			this._SqlCommand.CommandText = commandText;
			return this;
		}
		/// <summary>
		/// 设置SQL命令是否存储过程；
		/// </summary>
		/// <param name="isStoredProcedure">是否存储过程</param>
		/// <returns>SQL助手</returns>
		public SqlHelper IsStoredProcedure(bool isStoredProcedure = true)
		{
			this._SqlCommand.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
			return this;
		}
		/// <summary>
		/// 新建SQL参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <returns>SQL助手</returns>
		public SqlHelper NewParameter(string parameterName)
		{
			this._SqlParameter = new SqlParameter();
			this._SqlParameter.ParameterName = parameterName;
			this._SqlCommand.Parameters.Add(this._SqlParameter);
			return this;
		}
		/// <summary>
		/// 包含SQL参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="value">参数值</param>
		/// <returns>SQL助手</returns>
		public SqlHelper With(string parameterName, object value)
		{
			this.NewParameter(parameterName);
			this._SqlParameter.Value = value;
			return this;
		}
		/// <summary>
		/// 包含SQL参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="sqlDbType">SQL Server数据类型</param>
		/// <param name="size">长度</param>
		/// <param name="sourceColumn">来源列</param>
		/// <param name="dataRowVersion">数据行版本</param>
		/// <returns>SQL助手</returns>
		public SqlHelper With(string parameterName, SqlDbType sqlDbType = SqlDbType.VarChar, int size = 0, string sourceColumn = "", DataRowVersion dataRowVersion = DataRowVersion.Current)
		{
			this.NewParameter(parameterName);
			this._SqlParameter.SqlDbType = sqlDbType;
			this._SqlParameter.Size = size;
			sourceColumn =
				sourceColumn == "" ?
				parameterName.Substring(1, parameterName.Length - 1)
				: sourceColumn;
			this._SqlParameter.SourceColumn = sourceColumn;
			this._SqlParameter.SourceVersion = dataRowVersion;
			return this;
		}
		/// <summary>
		/// 设置SQL参数的SQL Server数据类型；
		/// </summary>
		/// <param name="sqlDbType">SQL Server数据类型</param>
		/// <returns>SQL助手</returns>
		public SqlHelper ParameterType(SqlDbType sqlDbType)
		{
			this._SqlParameter.SqlDbType = sqlDbType;
			return this;
		}
		/// <summary>
		/// 设置SQL参数的长度；
		/// </summary>
		/// <param name="size">长度</param>
		/// <returns>SQL助手</returns>
		public SqlHelper ParameterSize(int size)
		{
			this._SqlParameter.Size = size;
			return this;
		}
		/// <summary>
		/// 设置SQL参数的值；
		/// </summary>
		/// <param name="value">参数值</param>
		/// <returns>SQL助手</returns>
		public SqlHelper ParameterValue(object value)
		{
			this._SqlParameter.Value = value;
			return this;
		}
		/// <summary>
		/// 设置SQL参数的方向；
		/// </summary>
		/// <param name="parameterDirection">参数方向</param>
		/// <returns>SQL助手</returns>
		public SqlHelper ParameterDirection(ParameterDirection parameterDirection)
		{
			this._SqlParameter.Direction = parameterDirection;
			return this;
		}
		/// <summary>
		/// 将新建的SQL命令设为SQL数据适配器的插入命令；
		/// </summary>
		/// <returns>SQL助手</returns>
		public SqlHelper AsInsertCommand()
		{
			this.SqlDataAdapter.InsertCommand = this._SqlCommand;
			return this;
		}
		/// <summary>
		/// 将新建的SQL命令设为SQL数据适配器的更新命令；
		/// </summary>
		/// <returns>SQL助手</returns>
		public SqlHelper AsUpdateCommand()
		{
			this.SqlDataAdapter.UpdateCommand = this._SqlCommand;
			return this;
		}
		/// <summary>
		/// 将新建的SQL命令设为SQL数据适配器的删除命令；
		/// </summary>
		/// <returns>SQL助手</returns>
		public SqlHelper AsDeleteCommand()
		{
			this.SqlDataAdapter.DeleteCommand = this._SqlCommand;
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
			this._SqlCommand.Connection.Open();
			result = this._SqlCommand.ExecuteScalar();
			this._SqlCommand.Connection.Close();
			return (T)result;
		}
		/// <summary>
		/// 执行SQL命令，获取数据读取器；
		/// 完成读取后，请手动关闭数据读取器；
		/// </summary>
		/// <returns>数据读取器</returns>
		public IDataReader GetReader()
		{
			this._SqlCommand.Connection.Open();
			SqlDataReader sqlDataReader = this._SqlCommand.ExecuteReader();
			return sqlDataReader;
		}
		/// <summary>
		/// 执行SQL命令，获取数据表；
		/// </summary>
		/// <returns>数据表</returns>
		public DataTable GetTable()
		{
			DataTable dataTable = new DataTable();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
			sqlDataAdapter.SelectCommand = this._SqlCommand;
			this._SqlCommand.Connection.Open();
			sqlDataAdapter.Fill(dataTable);
			this._SqlCommand.Connection.Close();
			return dataTable;
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
				this._SqlCommand.Connection.Open();
				rowAffected = this._SqlCommand.ExecuteNonQuery();
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
				this._SqlCommand.Connection.Close();
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
			return this.SqlDataAdapter.Update(dataTable);
		}
	}
}
