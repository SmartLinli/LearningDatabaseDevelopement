using System;

namespace ObjectOriented_Dapper
{
	/// <summary>
	/// 用户（数据访问层）接口；
	/// </summary>
	public interface IUserDal
	{
		/// <summary>
		/// 查询用户计数;
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>计数</returns>
		int SelectCount(string userNo);
		/// <summary>
		/// 查询用户；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>用户</returns>
		User Select(string userNo);
		/// <summary>
		/// 更新用户；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>受影响行数</returns>
		int Update(User user);
		/// <summary>
		/// 插入用户；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>受影响行数</returns>
		int Insert(User user);
	}
	/// <summary>
	/// 违反唯一性异常；
	/// </summary>
	public class NotUniqueException : Exception
	{

	}
}
