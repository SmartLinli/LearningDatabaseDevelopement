using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Crud
{
	/// <summary>
	/// 学院仓储；
	/// </summary>
	public class DepartmentRepository
	{
		/// <summary>
		/// 查找所有；
		/// </summary>
		/// <returns>学院列表</returns>
		public static List<Department> FindAll()
		{
			using (EduBase eduBase = new EduBase())
			{
				var departments = eduBase.Department.Include("Major.Class").ToList();
				return departments;
			}
		}
	}
}
