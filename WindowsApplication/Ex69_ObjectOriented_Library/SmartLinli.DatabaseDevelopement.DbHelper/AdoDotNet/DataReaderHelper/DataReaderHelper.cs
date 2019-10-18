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
		/// 是否读取过；
		/// </summary>
		private bool _HasRead = false;
		/// <summary>
		/// 是否读取得记录；
		/// </summary>
		private bool _HasRecord = false;
		/// <summary>
		/// 数据读取器读取并前进至下一记录；
		/// </summary>
		/// <returns>是否读取得记录</returns>
		public bool Read()
		{
			this._HasRecord = this._DataReader.Read();
			this._HasRead = true;
			return this._HasRecord;
		}
		/// <summary>
		/// 获取位于指定索引的列的值；
		/// </summary>
		/// <param name="index">索引</param>
		/// <returns>值</returns>
		public object this[int index]
		{
			get
			{
				if (!this._HasRead)
				{
					this.Read();
				}
				if (this._HasRecord)
				{
					return this._DataReader[index] == DBNull.Value ? null : this._DataReader[index];
				}
				return null;
			}
		}
		/// <summary>
		/// 获取位于指定名称的列的值；
		/// </summary>
		/// <param name="name">名称</param>
		/// <returns>值</returns>
		public object this[string name]
		{
			get
			{
				int index;
				if (!this._HasRead)
				{
					this.Read();
				}
				try
				{
					index = this._DataReader.GetOrdinal(name);
				}
				catch (IndexOutOfRangeException)
				{
					return null;
				}				
				return this[index];

			}
		}
		/// <summary>
		/// 关闭；
		/// </summary>
		public void Close()
		{
			if (!this._DataReader.IsClosed)
			{
				this._DataReader.Close();
			}
		}
		/// <summary>
		/// 构造函数；
		/// </summary>
		/// <param name="dataReader">数据读取器</param>
		internal DataReaderHelper(IDataReader dataReader)
		=>	this._DataReader = dataReader;
	}
}
