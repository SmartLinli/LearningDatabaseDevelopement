using System.Data.Entity;

namespace ObjectOriented_InversionOfControl
{
	/// <summary>
	/// 用户（基于EntityFramwork的数据访问层）；
	/// </summary>
	public class UserDal
	{
		/// <summary>
		/// 查询用户计数;
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>计数</returns>
		public int SelectCount(string userNo)
		=>	EfHelper.SelectCount<User>(u => u.No == userNo);
		/// <summary>
		/// 查询用户；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>用户</returns>
		public User Select(string userNo)
		=>	EfHelper.SelectOne<User>(u => u.No == userNo);
		/// <summary>
		/// 更新用户；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>受影响行数</returns>
		public int Update(User user)
		=>	EfHelper.Save(user, EntityState.Modified);
		/// <summary>
		/// 插入用户；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>受影响行数</returns>
		public int Insert(User user)
		=>	EfHelper.Save(user, EntityState.Added, "您提交的用户号已存在");
		/// <summary>
		/// 构造函数；
		/// </summary>
		public UserDal()
		=>	EfHelper.WarmUp();
	}
}
