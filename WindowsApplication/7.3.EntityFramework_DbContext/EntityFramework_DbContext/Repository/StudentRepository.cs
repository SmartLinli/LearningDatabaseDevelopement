using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
namespace EntityFramework_DbContext
{
	/// <summary>
	/// 学生仓储；
	/// </summary>
	public class StudentRepository
	{
		/// <summary>
		/// EduBase数据库上下文；
		/// </summary>
		private EduBase EduBase { get; set; }
		/// <summary>
		/// 每页大小；
		/// </summary>
		public int PageSize { get; set; }
		/// <summary>
		/// 查找所有学生；
		/// </summary>
		/// <returns>学生绑定列表</returns>
		public BindingList<Student> FindAll()
		{
			var students = from s in this.EduBase.Student
						   orderby s.No ascending
						   select s;
			students.Load();
			return this.EduBase.Student.Local.ToBindingList();
		}
		/// <summary>
		/// 查找指定页码的所有学生；
		/// </summary>
		/// <param name="pageIndex">页码</param>
		/// <returns>学生绑定列表</returns>
		public IEnumerable<Student> FindAll(int pageIndex)
		{
			this.EduBase = EfHelper.GetDbContext();
			var students = from s in this.EduBase.Student
						   orderby s.No ascending
						   select s;
			int previousRowCount = (pageIndex - 1) * this.PageSize;
			var studentsPage = students.Skip(previousRowCount).Take(this.PageSize);
			studentsPage.Load();
			return this.EduBase.Student.Local.ToBindingList();
		}
		/// <summary>
		/// 保存；
		/// </summary>
		/// <returns>受影响行数</returns>
		public int Save()
		{
			return this.EduBase.SaveChanges();
		}
		/// <summary>
		/// 构造函数；
		/// </summary>
		public StudentRepository()
		{
			this.EduBase = EfHelper.GetDbContext();
			this.PageSize = 6;
		}
	}
}
