using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Crud
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
			using (EduBase eduBase = new EduBase())
			{
				var classes =                                                                               //声明隐式类型变量，用于保存LINQ查询结果；
					from c in eduBase.Class                                                            //从数据库上下文中的班级；
					select c;                                                                         //查询所有班级；
				return classes.ToList();
			}
		}
	}
}
