using System;
using System.Data;

namespace ObjectOriented_SqlHelper
{
	/// <summary>
	/// 用户（数据访问层）；
	/// </summary>
	public class UserDal
	{
		/// <summary>
		/// SQL助手；
		/// </summary>
		private SqlHelper SqlHelper;
		/// <summary>
		/// 查询用户计数;
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>计数</returns>
		public int SelectCount(string userNo)
		=>	this.SqlHelper
			.NewCommand("usp_selectUserCountByNo")
			.IsStoredProcedure(true)
			.NewParameter("@No", userNo)
			.GetScalar<int>();
		/// <summary>
		/// 查询用户；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>用户</returns>
		public User Select(string userNo)
		{
			IDataReader dataReader=
				this.SqlHelper
				.NewCommand("usp_selectUserByNo")
				.IsStoredProcedure(true)
				.NewParameter("@No", userNo)
				.GetReader();
			User user = null;
			if (dataReader.Read())
			{
				user = new User()
				{
					No = userNo,
					Password = (byte[])dataReader["Password"],
					IsActivated = (bool)dataReader["IsActivated"],
					LoginFailCount = (int)dataReader["LoginFailCount"]
				};
			}
			return user;
		}
		/// <summary>
		/// 更新用户；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>受影响行数</returns>
		public int Update(User user)
		=>	this.SqlHelper
			.NewCommand("usp_updateUser")
			.IsStoredProcedure(true)
			.NewParameter("@No", user.No)
			.NewParameter("@Password", user.Password)
			.NewParameter("@IsActivated", user.IsActivated)
			.NewParameter("@LoginFailCount", user.LoginFailCount)
			.NonQuery();
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
					this.SqlHelper.NewCommand("usp_insertUser")
					.IsStoredProcedure(true)
					.NewParameter("@No", user.No)
					.NewParameter("@Password", user.Password)
					.NewParameter("@IsActivated", user.IsActivated)
					.NonQuery();
			}
			catch(NotUniqueException)
			{
				throw new ApplicationException("您提交的用户号已存在");
			}
			catch (Exception)
			{
				throw;
			}
			return rowAffected;
		}
		/// <summary>
		/// 构造函数；
		/// </summary>
		public UserDal()
		{
			this.SqlHelper = new SqlHelper();
		}
	}
}
