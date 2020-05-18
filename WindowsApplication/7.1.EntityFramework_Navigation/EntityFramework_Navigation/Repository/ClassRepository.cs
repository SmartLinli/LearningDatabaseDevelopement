using System.Collections.Generic;

namespace EntityFramework_Navigation
{
	/// <summary>
	/// 班级仓储；
	/// </summary>
	public class ClassRepository
	{
		/// <summary>
		/// 查找所有班级；
		/// </summary>
		/// <returns>班级列表</returns>
		public static List<Class> FindAll()
		=>	EfHelper.SelectAll<Class>();
	}
}
