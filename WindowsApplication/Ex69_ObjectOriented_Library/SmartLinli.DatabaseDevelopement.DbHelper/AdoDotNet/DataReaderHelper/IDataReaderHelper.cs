namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 数据读取器助手接口；
	/// </summary>
	public interface IDataReaderHelper
	{
		/// <summary>
		/// 数据读取器读取并前进至下一记录；
		/// </summary>
		/// <returns>是否读取得记录</returns>
		bool Read();
		/// <summary>
		/// 获取位于指定索引的列的值；
		/// </summary>
		/// <param name="index">索引</param>
		/// <returns>对象</returns>
		object this[int index] { get; }
		/// <summary>
		/// 获取位于指定名称的列的值；
		/// </summary>
		/// <param name="name">名称</param>
		/// <returns>对象</returns>
		object this[string name] { get; }
		/// <summary>
		/// 关闭；
		/// </summary>
		void Close();
	}
}
