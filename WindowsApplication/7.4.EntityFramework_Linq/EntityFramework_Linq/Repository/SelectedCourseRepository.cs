using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace EntityFramework_Linq
{
	/// <summary>
	/// 已选课程仓储；
	/// </summary>
	public class SelectedCourseRepository
	{
		/// <summary>
		/// EduBase数据库上下文；
		/// </summary>
		private EduBaseSql EduBase { get; set; }
		/// <summary>
		/// 根据学号查找学生已选课程；
		/// </summary>
		/// <param name="studentNo">学号</param>
		/// <returns>已选课程信息列表</returns>
		public List<SelectedCourseInfo> FindByStudentNo(string studentNo)
		{
			var courses =
				from sc in this.EduBase.SelectedCourse
				join c in this.EduBase.Course on sc.CourseNo equals c.No
				where sc.StudentNo == studentNo
				orderby c.No ascending
				select new SelectedCourseInfo
				{
					No = sc.CourseNo,
					Name = sc.Course.Name,
					Credit = sc.Course.Credit,
					OrderBook = sc.OrderBook,
					State = EntityInfoState.Original
				};
			return courses.ToList();
		}
		/// <summary>
		/// 保存；
		/// </summary>
		/// <param name="selectedCourseInfos">已选课程信息列表</param>
		/// <param name="studentNo">学号</param>
		/// <returns>受影响行数</returns>
		public int Save(List<SelectedCourseInfo> selectedCourseInfos, string studentNo)
		{
			foreach (var selectedCourseInfo in selectedCourseInfos)
			{
				var selectedCourse = CourseService.Submit(selectedCourseInfo, studentNo);
				switch (selectedCourseInfo.State)
				{
					case EntityInfoState.Added:
						this.EduBase.Entry(selectedCourse).State = EntityState.Added;
						break;
					case EntityInfoState.Modified:
						this.EduBase.Entry(selectedCourse).State = EntityState.Modified;
						break;
					default:
						break;
				}
			}
			return this.EduBase.SaveChanges();
		}
		/// <summary>
		/// 构造函数；
		/// </summary>
		public SelectedCourseRepository()
		{
			this.EduBase = new EduBaseSql();
		}
	}
}

