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
		/// <summary>
		/// 查找班级成员；
		/// </summary>
		/// <param name="classNo">班级编号</param>
		/// <returns>班级成员列表</returns>
		public static List<ClassMember> FindMembers(int classNo)
		{
			using (EduBase eduBase = new EduBase())
			{
				var students =                                                                          //声明隐式类型变量，用于保存LINQ查询结果；
					from s in eduBase.Student                                                      //从数据库上下文中的学生；
					where s.ClassNo == classNo                                                     //筛选班级编号等于指定值的学生；
					select new ClassMember                                                                          //查询结果存入匿名类型，并将之实例化；
					{ No = s.No, Name = s.Name };                                                                   //匿名类型的成员包括学生学号、姓名；
				return students.ToList();

			}
		}
	}
}
