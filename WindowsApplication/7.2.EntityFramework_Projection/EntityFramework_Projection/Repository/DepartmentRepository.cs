using System.Collections.Generic;

namespace EntityFramework_Projection
{
	/// <summary>
	/// 学院仓储；
	/// </summary>
	public class DepartmentRepository
	{
		/// <summary>
		/// 查找所有学院；
		/// </summary>
		/// <returns>学院列表</returns>
		public static List<Department> FindAll()
		=>	EfHelper.SelectAll<Department>("Major.Class");
	}
}
