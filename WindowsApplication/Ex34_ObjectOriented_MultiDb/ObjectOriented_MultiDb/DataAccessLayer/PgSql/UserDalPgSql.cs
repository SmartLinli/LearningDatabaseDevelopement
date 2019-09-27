using System;
using System.Data;

namespace ObjectOriented_MultiDb
{
	/// <summary>
	/// 用户（PostgreSQL数据访问层）；
	/// </summary>
	public class UserDalPgsql:IUserDal
	{
		/// <summary>
		/// SQL助手；
		/// </summary>
		private PgsqlHelper _PgsqlHelper;
		/// <summary>
		/// 查询用户计数;
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>计数</returns>
		public int SelectCount(string userNo)
		=>	this._PgsqlHelper
			.NewCommand("usp_select_user_count_by_no")
			.IsStoredProcedure()
			.NewParameter("p_no", userNo)
			.GetScalar<int>();
		/// <summary>
		/// 查询用户；
		/// </summary>
		/// <param name="user">用户号</param>
		/// <returns>用户</returns>
		public User Select(string userNo)
		{
			IDataReader dataReader =
				this._PgsqlHelper
				.NewCommand("usp_select_user_by_no")
				.IsStoredProcedure()
				.NewParameter("p_no", userNo)
				.GetReader();
			User user = null;
			if (dataReader.Read())
			{
				user = new User()
				{
					No = userNo,
					Password = (byte[])dataReader["password"],
					IsActivated = (bool)dataReader["is_activated"],
					LoginFailCount = (int)dataReader["login_fail_count"]
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
		=>	this._PgsqlHelper
			.NewCommand("usp_update_user")
			.IsStoredProcedure()
			.NewParameter("p_no", user.No)
			.NewParameter("p_password", user.Password)
			.NewParameter("p_is_activated", user.IsActivated)
			.NewParameter("p_login_fail_count", user.LoginFailCount)
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
					this._PgsqlHelper.NewCommand("usp_insert_user")
					.IsStoredProcedure()
					.NewParameter("p_no", user.No)
					.NewParameter("p_password", user.Password)
					.NewParameter("p_is_activated", user.IsActivated)
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
		public UserDalPgsql()
		{
			this._PgsqlHelper = new PgsqlHelper();
		}
	}
}
