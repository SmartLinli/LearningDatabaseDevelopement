using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 数据库助手（基类）；
	/// </summary>
	public abstract partial class DbHelperBase
	{
		/// <summary>
		/// 数据库命令；
		/// </summary>
		private DbCommand _DbCommand;
		/// <summary>
		/// 数据库命令；
		/// </summary>
		protected DbCommand DbCommand
		{
			get
			{
				if (this._DbCommand == null)
				{
					throw new ApplicationException("尚未创建数据库命令");
				}
				return this._DbCommand;
			}
			set
			{
				this._DbCommand = value;
			}
		}
		/// <summary>
		/// 数据库参数；
		/// </summary>
		private DbParameter _DbParameter;
		/// <summary>
		/// 数据库参数；
		/// </summary>
		protected DbParameter DbParameter
		{
			get
			{
				if (this._DbParameter == null)
				{
					throw new ApplicationException("尚未创建数据库参数");
				}
				return this._DbParameter;
			}
			set
			{
				this._DbParameter = value;
			}
		}
		/// <summary>
		/// 数据适配器；
		/// </summary>
		private DbDataAdapter _DbDataAdapter;
		/// <summary>
		/// 数据适配器；
		/// </summary>
		protected DbDataAdapter DbDataAdapter
		{
			get
			{
				this._DbDataAdapter = this._DbDataAdapter ?? this.GetDbDataAdapter();
				return this._DbDataAdapter;
			}
		}
		/// <summary>
		/// 数据库连接字符串名称；
		/// </summary>
		protected abstract string DbConnectionStringName { get; }
		/// <summary>
		/// 获取数据库连接；
		/// </summary>
		/// <returns></returns>
		protected abstract DbConnection GetDbConnection();
		/// <summary>
		/// 获取数据库参数；
		/// </summary>
		/// <returns></returns>
		protected abstract DbParameter GetDbParameter();
		/// <summary>
		/// 获取数据适配器；
		/// </summary>
		/// <returns></returns>
		protected abstract DbDataAdapter GetDbDataAdapter();
		/// <summary>
		/// 新建命令；
		/// </summary>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase NewCommand()
		{
			DbConnection dbConnection = this.GetDbConnection();
			dbConnection.ConnectionString = ConfigurationManager.ConnectionStrings[this.DbConnectionStringName].ToString();
			this.DbCommand = dbConnection.CreateCommand();
			return this;
		}
		/// <summary>
		/// 设置命令文本
		/// </summary>
		/// <param name="commandText">命令文本</param>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase CommandText(string commandText)
		{
			this.DbCommand.CommandText = commandText;
			return this;
		}
		/// <summary>
		/// 设置命令是否存储过程；
		/// </summary>
		/// <param name="isStoredProcedure">是否存储过程</param>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase IsStoredProcedure(bool isStoredProcedure = true)
		{
			this.DbCommand.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
			return this;
		}
		/// <summary>
		/// 新建命令；
		/// </summary>
		/// <param name="commandText">命令文本</param>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase NewCommand(string commandText)
		{
			this.NewCommand();
			return this.CommandText(commandText);
		}
		/// <summary>
		/// 新建参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase NewParameter(string parameterName)
		{
			this.DbParameter = this.GetDbParameter();
			this.DbParameter.ParameterName = parameterName;
			this.DbCommand.Parameters.Add(this._DbParameter);
			return this;
		}
		/// <summary>
		/// 设置特定数据库参数类型；
		/// </summary>
		/// <param name="dbType"></param>
		protected abstract void SpecificParameterType(object dbType);
		/// <summary>
		/// 包含参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="value">值</param>
		/// <param name="dbType">数据类型</param>
		/// <param name="size">长度</param>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase WithParameter(string parameterName, object value, ValueType dbType = null, int size = 0)
		{
			this.NewParameter(parameterName);
			this.DbParameter.Value = value;
			this.SpecificParameterType(dbType);
			this.DbParameter.Size = size;
			return this;
		}
		/// <summary>
		/// 包含参数；
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="dbType">数据类型</param>
		/// <param name="size">长度</param>
		/// <param name="sourceColumn">来源列</param>
		/// <param name="dataRowVersion">数据行版本</param>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase WithParameter(string parameterName, ValueType dbType = null, int size = 0, string sourceColumn = "", DataRowVersion dataRowVersion = DataRowVersion.Current)
		{
			this.NewParameter(parameterName);
			this.SpecificParameterType(dbType);
			this.DbParameter.Size = size;
			sourceColumn =
				sourceColumn == "" ?
				parameterName.Substring(1, parameterName.Length - 1)
				: sourceColumn;
			this.DbParameter.SourceColumn = sourceColumn;
			this.DbParameter.SourceVersion = dataRowVersion;
			return this;
		}
		/// <summary>
		/// 包含参数；参数值源自数据表；
		/// </summary>
		/// <param name="parameterNames">参数名称</param>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase WithParameters(params string[] parameterNames)
		{
			foreach (var parameterName in parameterNames)
			{
				this.WithParameter(parameterName, null, 0, "", DataRowVersion.Current);
			}
			return this;
		}
		/// <summary>
		/// 设置通用数据库参数类型；
		/// </summary>
		/// <param name="dbType">通用数据库数据类型</param>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase ParameterType(DbType dbType)
		{
			this.DbParameter.DbType = dbType;
			return this;
		}
		/// <summary>
		/// 设置参数长度；
		/// </summary>
		/// <param name="size">长度</param>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase ParameterSize(int size)
		{
			this.DbParameter.Size = size;
			return this;
		}
		/// <summary>
		/// 设置参数值；
		/// </summary>
		/// <param name="value">值</param>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase ParameterValue(object value)
		{
			this.DbParameter.Value = value;
			return this;
		}
		/// <summary>
		/// 设置L参数方向；
		/// </summary>
		/// <param name="parameterDirection">参数方向</param>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase ParameterDirection(ParameterDirection parameterDirection)
		{
			this.DbParameter.Direction = parameterDirection;
			return this;
		}
		/// <summary>
		/// 将新建的命令设为数据适配器的插入命令；
		/// </summary>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase AsInsertCommand()
		{
			this.DbDataAdapter.InsertCommand = this._DbCommand;
			return this;
		}
		/// <summary>
		/// 将新建的命令设为数据适配器的更新命令；
		/// </summary>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase AsUpdateCommand()
		{
			this.DbDataAdapter.UpdateCommand = this._DbCommand;
			return this;
		}
		/// <summary>
		/// 将新建的命令设为数据适配器的删除命令；
		/// </summary>
		/// <returns>数据库助手</returns>
		public virtual DbHelperBase AsDeleteCommand()
		{
			this.DbDataAdapter.DeleteCommand = this._DbCommand;
			return this;
		}
		/// <summary>
		/// 执行命令，返回标量；
		/// </summary>
		/// <returns>标量值</returns>
		public virtual object Return()
		{
			object result = null;
			this.DbCommand.Connection.Open();
			result = this._DbCommand.ExecuteScalar();
			this.DbCommand.Connection.Close();
			return result;
		}
		/// <summary>
		/// 执行命令，返回标量；
		/// 若结果为空值，将返回其类型的默认值；
		/// </summary>
		/// <typeparam name="T">标量类型</typeparam>
		/// <returns>标量值</returns>
		public virtual T Return<T>()
		{
			object result = this.Return();
			return result == null ? default(T) : (T)result;
		}
		/// <summary>
		/// 执行命令，返回可空标量；
		/// 若结果为空值，将返回可空类型的标量值；
		/// </summary>
		/// <typeparam name="T">标量类型</typeparam>
		/// <returns>标量值</returns>
		public virtual T? ReturnNullable<T>() where T : struct
		{
			object result = this.Return();
			return new T?((T)result);
		}
		/// <summary>
		/// 快速执行命令，返回标量；
		/// 若结果为空值，将返回其类型的默认值；
		/// </summary>
		/// <typeparam name="T">标量类型</typeparam>
		/// <param name="commandText">命令文本</param>
		/// <returns>标量值</returns>
		public virtual T QuickReturn<T>(string commandText)
		{
			object result = this.NewCommand(commandText).Return();
			return result == null ? default(T) : (T)result;
		}
		/// <summary>
		/// 执行命令，返回数据读取器；
		/// 完成读取后，请手动关闭数据读取器；
		/// </summary>
		/// <returns>数据读取器</returns>
		public virtual IDataReader ReturnReader()
		{
			this.DbCommand.Connection.Open();
			IDataReader dataReader = this.DbCommand.ExecuteReader();
			return dataReader;
		}
		/// <summary>
		/// 快速执行命令，返回数据读取器助手；
		/// 完成读取后，请手动关闭数据读取器；
		/// </summary>
		/// <param name="commandText">命令文本</param>
		/// <returns>数据读取器助手</returns>
		public virtual IDataReaderHelper QuickReturnReader(string commandText)
		=>	new DataReaderHelper(this.NewCommand(commandText).ReturnReader());
		/// <summary>
		/// 初始记录序号；
		/// </summary>
		private int InitialRecordIndex => -1;
		/// <summary>
		/// 当前记录序号；
		/// </summary>
		private int CurrentRecordIndex { get; set; }
		/// <summary>
		/// 最大记录序号；
		/// </summary>
		private int MaxRecordIndex { get; set; }
		/// <summary>
		/// 是否读得记录；
		/// </summary>
		public bool HasRecord
		{
			get
			{
				if (this.CurrentRecordIndex <= this.MaxRecordIndex)
				{
					this.CurrentRecordIndex++;
				}
				return this.CurrentRecordIndex <= this.MaxRecordIndex;
			}
		}
		/// <summary>
		/// 数据读取器读得的记录；
		/// </summary>
		private List<Dictionary<string, object>> Records { get; set; }
		/// <summary>
		/// 获取指定名称的列的值；
		/// </summary>
		/// <param name="name">名称</param>
		/// <returns>值</returns>
		public object this[string name]
		{
			get
			{
				if (this.CurrentRecordIndex <= this.InitialRecordIndex)
				{
					throw new ApplicationException("请先判断SQL助手是否读得记录");
				}
				return this.Records[CurrentRecordIndex][name];
			}
		}
		/// <summary>
		/// 快速执行命令，并读取一行或多行记录；
		/// 随后判断数据库助手是否读得记录，再通过数据库助手的索引器访问该行记录的指定列；
		/// </summary>
		/// <param name="commandText">命令文本</param>
		/// <returns>数据库助手</returns>
		public DbHelperBase QuickRead(string commandText)
		{
			this.MaxRecordIndex = this.InitialRecordIndex;
			var dataReader = this.NewCommand(commandText).ReturnReader();
			this.Records = new List<Dictionary<string, object>>();
			while (dataReader.Read())
			{
				var record = new Dictionary<string, object>();
				for (int i = 0; i < dataReader.FieldCount; i++)
				{
					var value = dataReader[i] == DBNull.Value ? null : dataReader[i];
					record.Add(dataReader.GetName(i), value);
				}
				this.Records.Add(record);
			}
			dataReader.Close();
			this.MaxRecordIndex = this.Records.Count - 1;
			this.CurrentRecordIndex = this.InitialRecordIndex;
			return this;
		}	
		/// <summary>
		/// 执行SQL命令，返回数据表；
		/// </summary>
		/// <returns>数据表</returns>
		public virtual DataTable ReturnTable()
		{
			DataTable dataTable = new DataTable();
			this.DbDataAdapter.SelectCommand = this._DbCommand;
			this.DbCommand.Connection.Open();
			this.DbDataAdapter.Fill(dataTable);
			this.DbCommand.Connection.Close();
			return dataTable;
		}
		/// <summary>
		/// 执行SQL命令，写入数据；
		/// </summary>
		/// <param name="match">匹配特定异常</param>
		/// <returns>受影响行数</returns>
		protected int ExecuteNonQuery(Func<Exception, bool> match)
		{
			int rowAffected = 0;
			try
			{
				this.DbCommand.Connection.Open();
				rowAffected = this.DbCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				if (match(ex))
				{
					throw new NotUniqueException();
				}
				throw;
			}
			finally
			{
				this.DbCommand.Connection.Close();
			}
			return rowAffected;
		}
		/// <summary>
		/// 执行命令，提交数据；
		/// </summary>
		/// <returns>受影响行数</returns>
		public abstract int Submit();
		/// <summary>
		/// 快速执行命令，提交数据；
		/// </summary>
		/// <param name="commandText">命令文本</param>
		/// <returns>受影响行数</returns>
		public virtual int QuickSubmit(string commandText)
		=>	this.NewCommand(commandText).Submit();
		/// <summary>
		/// 执行命令，提交数据；
		/// </summary>
		/// <param name="dataTable">数据表</param>
		/// <returns>受影响行数</returns>
		public virtual int Submit(DataTable dataTable)
		=>	this.DbDataAdapter.Update(dataTable);
		/// <summary>
		/// 转换可空值；
		/// </summary>
		/// <typeparam name="T">结果类型</typeparam>
		/// <param name="value">值</param>
		/// <returns>结果</returns>
		public virtual T ConvertNullable<T>(object value)
		{
			T result = default(T);
			if (value != DBNull.Value)
			{
				result = (T)value;
			}
			return result;
		}
	}
}
