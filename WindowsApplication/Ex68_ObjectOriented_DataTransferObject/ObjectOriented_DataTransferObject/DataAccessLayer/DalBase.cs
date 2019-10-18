namespace ObjectOriented_DataTransferObject
{
	/// <summary>
	/// 基于EntityFramwork的数据访问层基类；
	/// </summary>
	public abstract class DalBase
	{
		/// <summary>
		/// 构造函数；
		/// </summary>
		public DalBase()
		=>	EfHelper.WarmUp();
	}
}
