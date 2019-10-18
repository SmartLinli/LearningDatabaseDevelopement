using System.Data.Entity;

namespace ObjectOriented_DataTransferObject
{
	/// <summary>
	/// 用户（基于EntityFramwork的数据访问层）；
	/// </summary>
	public class UserDal : DalBase
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
		=>	EfHelper.SelectOne<User>(u => u.No == userNo, nameof(Role));
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
	}
}
