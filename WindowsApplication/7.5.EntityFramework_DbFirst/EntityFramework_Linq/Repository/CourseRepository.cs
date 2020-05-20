using System.Collections.Generic;
using System.Linq;

namespace EntityFramework_Linq
{
	/// <summary>
	/// 课程仓储；
	/// </summary>
	public class CourseRepository
	{
		/// <summary>
		/// 根据学号查找学生所能选的课程；
		/// 该学生已选课程不能再选，不予列出；
		/// </summary>
		/// <param name="studentNo">学号</param>
		/// <returns>课程信息列表</returns>
		public static List<CourseInfo> FindByStudentNo(string studentNo)
		{
			using (var eduBase = new EduBase())
			{
				var courses =
					from c in eduBase.Course
					where
						!(from sc in eduBase.SelectedCourse
						  where sc.StudentNo == studentNo
						  select sc.CourseNo)
						.Contains(c.No)
					select new CourseInfo { No = c.No, Name = c.Name, Credit = c.Credit };
				return courses.ToList();
			}
		}
	}
}
