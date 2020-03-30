using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFramework_Crud
{
	/// <summary>
	/// 学生仓储；
	/// </summary>
	public class StudentRepository
	{
		/// <summary>
		/// 查找；
		/// </summary>
		/// <param name="studentNo">学号</param>
		/// <returns>学生</returns>
		public static Student Find(string studentNo)
		{
			using (EduBase eduBase = new EduBase())
			{
				var student =
					(from s in eduBase.Student                                              //从数据库上下文中的学生；
					 where s.No == studentNo                                                     //筛选学号等于指定值的学生；
					 select s).First();                                                          //由于查询返回集合，故需获取其中首个元素，即满足条件的唯一学生；
				return student;
			}
		}
		/// <summary>
		/// 查找班级成员；
		/// </summary>
		/// <param name="classNo">班级编号</param>
		/// <returns>学生简况列表</returns>
		public static List<StudentBasicInfo> FindByClassNo(int classNo)
		{
			using (EduBase eduBase = new EduBase())
			{
				var students =                                                                          //声明隐式类型变量，用于保存LINQ查询结果；
					from s in eduBase.Student                                                      //从数据库上下文中的学生；
					where s.ClassNo == classNo                                                     //筛选班级编号等于指定值的学生；
					select new StudentBasicInfo                                                                          //查询结果存入匿名类型，并将之实例化；
					{ No = s.No, Name = s.Name };                                                                   //匿名类型的成员包括学生学号、姓名；
				return students.ToList();

			}
		}
		/// <summary>
		/// 插入；
		/// </summary>
		/// <param name="student">学生</param>
		/// <returns>受影响行数</returns>
		public static int Insert(Student student)
		{
			using (EduBase eduBase = new EduBase())
			{
				eduBase.Student.Add(student);                                                    //向数据库上下文的学生实体集添加学生；
				int rowAffected = eduBase.SaveChanges();
				return rowAffected;
			}
		}
		/// <summary>
		/// 更新；
		/// </summary>
		/// <param name="student">学生</param>
		/// <returns>受影响行数</returns>
		public static int Update(Student student)
		{
			using (EduBase eduBase = new EduBase())
			{
				eduBase.Entry(student).State = EntityState.Modified;
				int rowAffected = eduBase.SaveChanges();
				return rowAffected;
			}
		}
		/// <summary>
		/// 删除；
		/// </summary>
		/// <param name="studentNo">学号</param>
		/// <returns>受影响行数</returns>
		public static int Delete(string studentNo)
		{
			using (EduBase eduBase = new EduBase())
			{
				var student = eduBase.Student.Find(studentNo);                                                     //从数据库上下文中的学生；
				eduBase.Student.Remove(student);                                                   //从数据库上下文的学生实体集中删除该学生；
				int rowsAffected = eduBase.SaveChanges();                                          //数据库上下文保存更改，返回受影响行数；
				return rowsAffected;
			}
		}
	}
}
