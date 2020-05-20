using System.Collections.Generic;
using System.Linq;

namespace EntityFramework_Navigation
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
		{
			using (var eduBase = EfHelper.GetDbContext())
			{
				var departments = from d in eduBase.Department.Include("Major.Class")
								  select d;
				return departments.ToList();
			}
		}
	}
}
