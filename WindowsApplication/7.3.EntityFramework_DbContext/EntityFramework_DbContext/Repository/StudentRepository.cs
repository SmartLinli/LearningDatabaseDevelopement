using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

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
		/// 查找所有学生；
		/// </summary>
		/// <returns>学生绑定列表</returns>
		public IBindingList FindAll()
		{
			var students = from s in this.EduBase.Student
						   select s;
			students.Load();
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
		}
	}
}
