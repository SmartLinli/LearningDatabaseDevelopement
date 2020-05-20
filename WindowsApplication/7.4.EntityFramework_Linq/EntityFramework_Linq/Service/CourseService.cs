using System.Collections.Generic;
using System.Linq;

namespace EntityFramework_Linq
{
	public static class CourseService
	{
		/// <summary>
		/// 求学分总和；
		/// </summary>
		/// <param name="selectedCourseInfos">已选课程信息列表</param>
		/// <returns>学分总和</returns>
		public static decimal SumCredit(this IList<SelectedCourseInfo> selectedCourseInfos)
		=>	selectedCourseInfos.Sum(c => c.Credit);
		/// <summary>
		/// 选课；
		/// </summary>
		/// <param name="courseInfo">课程信息</param>
		/// <returns>已选课程信息</returns>
		public static SelectedCourseInfo Select(CourseInfo courseInfo)
		{
			var selectedCourseInfo = new SelectedCourseInfo()
			{
				No = courseInfo.No,
				Name = courseInfo.Name,
				Credit = courseInfo.Credit,
				OrderBook = false,
				State = EntityInfoState.Added
			};
			return selectedCourseInfo;
		}
		/// <summary>
		/// 退选；
		/// </summary>
		/// <param name="selectedCourseInfo">已选课程信息</param>
		/// <returns>课程信息</returns>
		public static CourseInfo Reject(SelectedCourseInfo selectedCourseInfo)
		{
			var courseInfo = new CourseInfo()
			{
				No = selectedCourseInfo.No,
				Name = selectedCourseInfo.Name,
				Credit = selectedCourseInfo.Credit,
			};
			return courseInfo;
		}
		/// <summary>
		/// 提交；
		/// </summary>
		/// <param name="selectedCourseInfo">已选课程信息</param>
		/// <param name="studentNo">学号</param>
		/// <returns>已选课程</returns>
		public static SelectedCourse Submit(SelectedCourseInfo selectedCourseInfo, string studentNo)
		{
			var selectedCourse = new SelectedCourse()
			{
				StudentNo = studentNo,
				CourseNo = selectedCourseInfo.No,
				OrderBook = selectedCourseInfo.OrderBook
			};
			return selectedCourse;
		}
	}
}
