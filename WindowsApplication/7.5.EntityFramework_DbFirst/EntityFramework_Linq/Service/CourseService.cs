namespace EntityFramework_Linq
{
	public class CourseService
	{
		/// <summary>
		/// 选课；
		/// </summary>
		/// <param name="courseInfo">课程信息</param>
		/// <returns>已选课程信息</returns>
		public static SelectedCourseInfo Select(CourseInfo courseInfo, string studentNo)
		{
			var selectedCourseInfo = new SelectedCourseInfo()
			{
				StudentNo = studentNo,
				CourseNo = courseInfo.No,
				CourseName = courseInfo.Name,
				Credit = courseInfo.Credit,
				OrderBook = false
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
				No = selectedCourseInfo.CourseNo,
				Name = selectedCourseInfo.CourseName,
				Credit = selectedCourseInfo.Credit,
			};
			return courseInfo;
		}
		public static bool CanBeRejected(bool isNew)
		=>	isNew;
	}
}
