using System.Collections.Generic;
using System.Data.Entity;

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
		=>	EfHelper.SelectById<string, Student>(studentNo);
		/// <summary>
		/// 查找指定班级的学生；
		/// </summary>
		/// <param name="classNo">班级编号</param>
		/// <returns>学生简况列表</returns>
		public static List<Student> FindByClassNo(int classNo)
		=>	EfHelper.Select<Student>(s => s.ClassNo == classNo, "Class");
		/// <summary>
		/// 添加；
		/// </summary>
		/// <param name="student">学生</param>
		/// <returns>受影响行数</returns>
		public static int Add(Student student)
		=>	EfHelper.Save(student, EntityState.Added);
		/// <summary>
		/// 更新；
		/// </summary>
		/// <param name="student">学生</param>
		/// <returns>受影响行数</returns>
		public static int Update(Student student)
		=>	EfHelper.Save(student, EntityState.Modified);
		/// <summary>
		/// 删除；
		/// </summary>
		/// <param name="studentNo">学号</param>
		/// <returns>受影响行数</returns>
		public static int Delete(string studentNo)
		=>	EfHelper.Save
			(EfHelper.SelectById<string, Student>(studentNo),
			 EntityState.Deleted);
	}
}
