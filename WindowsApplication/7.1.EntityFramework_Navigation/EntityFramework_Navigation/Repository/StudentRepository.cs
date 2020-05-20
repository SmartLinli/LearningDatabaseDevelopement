using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EntityFramework_Navigation
{
	/// <summary>
	/// 学生仓储；
	/// </summary>
	public class StudentRepository
	{
		/// <summary>
		/// 查找学生；
		/// </summary>
		/// <param name="studentNo">学号</param>
		/// <returns>学生</returns>
		public static Student Find(string studentNo)
		{
			using (var eduBase = EfHelper.GetDbContext())
			{
				var student = from s in eduBase.Student
							  where s.No == studentNo
							  select s;
				return student.FirstOrDefault();
			}
		}
		/// <summary>
		/// 查找指定班级的学生；
		/// </summary>
		/// <param name="classNo">班级编号</param>
		/// <returns>学生简况列表</returns>
		public static List<Student> FindByClassNo(int classNo)
		{
			using (var eduBase = EfHelper.GetDbContext())
			{
				var students = from s in eduBase.Student.Include("Class")
							   where s.ClassNo == classNo
							   select s;
				return students.ToList();
			}
		}
		/// <summary>
		/// 添加；
		/// </summary>
		/// <param name="student">学生</param>
		/// <returns>受影响行数</returns>
		public static int Add(Student student)
		{
			using (var eduBase = EfHelper.GetDbContext())
			{
				eduBase.Student.Add(student);
				return eduBase.SaveChanges();
			}
		}
		/// <summary>
		/// 更新；
		/// </summary>
		/// <param name="student">学生</param>
		/// <returns>受影响行数</returns>
		public static int Update(Student student)
		{
			using (var eduBase = EfHelper.GetDbContext())
			{
				eduBase.Entry(student).State = EntityState.Modified;
				return eduBase.SaveChanges();
			}
		}
		/// <summary>
		/// 删除；
		/// </summary>
		/// <param name="studentNo">学号</param>
		/// <returns>受影响行数</returns>
		public static int Delete(string studentNo)
		{
			using (var eduBase = EfHelper.GetDbContext())
			{
				var student = eduBase.Student.Find(studentNo);
				eduBase.Student.Remove(student);
				return eduBase.SaveChanges();
			}
		}
	}
}
