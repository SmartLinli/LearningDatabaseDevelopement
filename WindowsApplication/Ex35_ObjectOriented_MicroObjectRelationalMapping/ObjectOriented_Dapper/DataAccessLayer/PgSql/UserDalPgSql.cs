﻿using System;
using System.Linq;

namespace ObjectOriented_Dapper
{
	/// <summary>
	/// 用户（PostgreSQL数据访问层）；
	/// </summary>
	public class UserDalPgSql:IUserDal
	{
		/// <summary>
		/// 查询用户计数;
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>计数</returns>
		public int SelectCount(string userNo)
		=>	DapperPgSqlHelper.GetScalarFromSp<int>
				("usp_select_user_count_by_no"
				, new { p_no = userNo });
		/// <summary>
		/// 查询用户；
		/// </summary>
		/// <param name="user">用户号</param>
		/// <returns>用户</returns>
		public User Select(string userNo)
		=>	DapperPgSqlHelper.GetQueryResultFromSp<dynamic>
				("usp_select_user_by_no"
				, new { p_no = userNo })
				.Select
					(u => new User()
					{
						No = u.no,
						Password = u.password,
						IsActivated = u.is_activated,
						LoginFailCount = u.login_fail_count
					})
				.FirstOrDefault();
		/// <summary>
		/// 更新用户；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>受影响行数</returns>
		public int Update(User user)
		=> DapperPgSqlHelper.GetScalarFromSp<int>
				("usp_update_user"
				, new
				{
					p_no = user.No,
					p_password = user.Password,
					p_is_activated = user.IsActivated,
					p_login_fail_count = user.LoginFailCount
				});
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
					DapperPgSqlHelper.GetScalarFromSp<int>
						("usp_insert_user"
						, new
						{
							p_no = user.No,
							p_password = user.Password,
							p_is_activated = user.IsActivated,
						});
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
