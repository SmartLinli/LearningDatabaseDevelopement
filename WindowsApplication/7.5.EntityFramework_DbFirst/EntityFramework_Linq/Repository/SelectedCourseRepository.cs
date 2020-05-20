using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel;

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
		private EduBase EduBase { get; set; }
		/// <summary>
		/// 根据学号查找学生已选课程；
		/// </summary>
		/// <param name="studentNo">学号</param>
		/// <returns>已选课程信息列表</returns>
		public BindingList<SelectedCourseInfo> FindByStudentNo(string studentNo)
		{
			var selectedCourseInfos =
				from sc in this.EduBase.SelectedCourseInfo
				where sc.StudentNo == studentNo
				select sc;
			selectedCourseInfos.Load();
			return this.EduBase.SelectedCourseInfo.Local.ToBindingList();
		}
		/// <summary>
		/// 保存；
		/// </summary>
		/// <param name="selectedCourseInfos">已选课程信息列表</param>
		/// <param name="studentNo">学号</param>
		/// <returns>受影响行数</returns>
		public int Save()
		=>	this.EduBase.SaveChanges();
		public bool IsNew(SelectedCourseInfo selectedCourseInfo)
		=>	this.EduBase.Entry(selectedCourseInfo).State == EntityState.Added;
		/// <summary>
		/// 构造函数；
		/// </summary>
		public SelectedCourseRepository()
		{
			this.EduBase = new EduBase();
		}
	}
}

