using System;
using System.Data;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 数据读取器助手；
	/// </summary>
	public class DataReaderHelper : IDataReaderHelper
	{
		/// <summary>
		/// 数据读取器；
		/// </summary>
		private IDataReader _DataReader;
		/// <summary>
		/// 数据读取器读取并前进至下一记录；
		/// </summary>
		/// <returns>是否读取得记录</returns>
		public bool Read()
		=> this._DataReader.Read();
		/// <summary>
		/// 获取位于指定索引的列的值；
		/// </summary>
		/// <param name="index">索引</param>
		/// <returns>值</returns>
		public object this[int index] => this._DataReader[index] == DBNull.Value ? null : this._DataReader[index];
		/// <summary>
		/// 获取位于指定名称的列的值；
		/// </summary>
		/// <param name="name">名称</param>
		/// <returns>值</returns>
		public object this[string name] => this._DataReader[name] == DBNull.Value ? null : this._DataReader[name];
		/// <summary>
		/// 关闭；
		/// </summary>
		public void Close()
		=> this._DataReader.Close();
		/// <summary>
		/// 构造函数；
		/// </summary>
		/// <param name="dataReader">数据读取器</param>
		internal DataReaderHelper(IDataReader dataReader)
		=> this._DataReader = dataReader;
	}
}
