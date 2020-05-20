using System.Collections.Generic;
using System.Linq;

namespace EntityFramework_Projection
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
		{
			using (var eduBase = EfHelper.GetDbContext())
			{
				var classes = from c in eduBase.Class
							  select c;
				return classes.ToList();
			}
		}
	}
}
