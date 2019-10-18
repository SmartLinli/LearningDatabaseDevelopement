using System;

namespace ObjectOriented_Dapper
{
	/// <summary>
	/// 用户（SQL Server数据访问层）；
	/// </summary>
	public class UserDalSql : IUserDal
	{
		/// <summary>
		/// 查询用户计数;
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>计数</returns>
		public int SelectCount(string userNo)
		=>	DapperSqlHelper.GetScalarFromSp<int>
				("usp_selectUserCount"
				, new { No = userNo });
		/// <summary>
		/// 查询用户；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>用户</returns>
		public User Select(string userNo)
		=>	DapperSqlHelper.GetScalarFromSp<User>
				("usp_selectUser"
				, new { No = userNo });
		/// <summary>
		/// 更新用户；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>受影响行数</returns>
		public int Update(User user)
		=>	DapperSqlHelper.GetScalarFromSp<int>
				("usp_updateUser"
				, user);
		/// <summary>
		/// 插入用户；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>受影响行数</returns>
		public int Insert(User user)
		{
			int rowAffected = 0;
			try
			{
				rowAffected =
					DapperSqlHelper.GetScalarFromSp<int>
						("usp_insertUser"
						, new { user.No, user.Password, user.IsActivated });
			}
			catch (NotUniqueException)
			{
				throw new ApplicationException("您提交的用户号已存在");
			}
			catch (Exception)
			{
				throw;
			}
			return rowAffected;
		}
	}
}
