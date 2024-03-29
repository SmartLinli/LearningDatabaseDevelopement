﻿using System;
using SmartLinli.DatabaseDevelopement;

namespace ObjectOriented_DataTransferObject
{
	/// <summary>
	/// 用户（业务逻辑层）；
	/// </summary>
	public class UserBll : IUserBll
	{
		/// <summary>
		/// 用户（数据访问层）；
		/// </summary>
		private IUserDal UserDal { get; set; }
		/// <summary>
		/// 角色（数据访问层）；
		/// </summary>
		private IRoleDal RoleDal { get; set; }
		/// 登录失败次数上限；
		/// </summary>
		private int LogInFailCountMax => 3;
		/// <summary>
		/// 用户号最小长度；
		/// </summary>
		public int UserNoMinLength => 7;
		/// <summary>
		/// 用户号最大长度；
		/// </summary>
		public int UserNoMaxLength => 10;
		/// <summary>
		/// 密码最小长度；
		/// </summary>
		public int PasswordMinLengh => 4;
		/// <summary>
		/// 密码最大长度；
		/// </summary>
		public int PasswordMaxLengh => 20;
		/// <summary>
		/// 默认角色名称；
		/// </summary>
		private string DefaultRoleName => "学生";
		/// <summary>
		/// 是否完成登录；
		/// </summary>
		public bool HasLoggedIn { get; private set; }
		/// <summary>
		/// 是否完成注册；
		/// </summary>
		public bool HasSignedUp { get; private set; }
		/// <summary>
		/// 消息；
		/// </summary>
		public string Message { get; private set; }
		/// <summary>
		/// 处理用户不存在；
		/// </summary>
		/// <param name="user">用户</param>
		private void HandleUserNotExist(User user)
		{
			if (user == null)
			{
				string errorMessage = "用户号不存在！";
				throw new ApplicationException(errorMessage);
			}
		}
		/// <summary>
		/// 处理用户被冻结；
		/// </summary>
		/// <param name="user">用户</param>
		private void HandleUserNotActivated(User user)
		{
			if (!user.IsActivated)
			{
				string errorMessage = "用户已被冻结，需要手机验证！";
				throw new ApplicationException(errorMessage);
			}
		}
		/// <summary>
		/// 处理用户登录失败次数过多；
		/// </summary>
		/// <param name="user">用户</param>
		private void HandleUserLoginFailTooManyTimes(User user)
		{
			if (user.LoginFailCount >= this.LogInFailCountMax)
			{
				user.IsActivated = false;
				this.UserDal.Update(user);
			}
		}
		/// <summary>
		/// 处理用户登录失败；
		/// </summary>
		/// <param name="user">用户</param>
		private void HandleUserLoginFail(User user)
		{
			user.LoginFailCount++;
			this.UserDal.Update(user);
		}
		/// <summary>
		/// 处理用户密码错误；
		/// </summary>
		/// <param name="user">用户</param>
		/// <param name="password">密码</param>
		private void HandleUserPasswordNotMatch(User user, string password)
		{
			bool isPasswordMatch = CrytoHelper.Md5Equal(user.Password, password);
			if (!isPasswordMatch)
			{
				this.HandleUserLoginFail(user);
				this.HandleUserLoginFailTooManyTimes(user);
				string errorMessage =
					user.IsActivated ?
					$"密码错误，请重新输入！\n您还有{this.LogInFailCountMax - user.LoginFailCount}次机会！"
					: $"密码错误已达{this.LogInFailCountMax}次上限！";
				throw new ApplicationException(errorMessage);
			}
		}
		/// <summary>
		/// 处理用户登录成功；
		/// </summary>
		/// <param name="user">用户</param>
		private void HandleUserLoginOk(User user)
		{
			if (user.LoginFailCount != 0)
			{
				user.LoginFailCount = 0;
				this.UserDal.Update(user);
			}
			this.HasLoggedIn = true;
			this.Message = "登录成功。";
		}
		/// <summary>
		/// 获取角色；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>角色</returns>
		private Role GetRole(string userNo)
		{
			string roleName = this.DefaultRoleName;
			if (userNo.Length == 7)
			{
				roleName = "教师";
			}
			return this.RoleDal.Select(roleName);
		}
		/// <summary>
		/// 检查是否存在；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>是否存在</returns>
		public bool CheckExist(string userNo)
		=>	this.UserDal.SelectCount(userNo) == 1;
		/// <summary>
		/// 检查是否不存在；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>是否不存在</returns>
		public bool CheckNotExist(string userNo)
		=>	!this.CheckExist(userNo);
		/// <summary>
		/// 登录；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>是否登录成功</returns>
		public UserDto LogIn(string userNo, string password)
		{
			this.HasLoggedIn = false;
			User user = this.UserDal.Select(userNo);
			try
			{
				this.HandleUserNotExist(user);
				this.HandleUserNotActivated(user);
				this.HandleUserPasswordNotMatch(user, password);
				this.HandleUserLoginOk(user);
			}
			catch (ApplicationException ex)
			{
				this.Message = ex.Message;
			}
			catch (Exception)
			{
				this.Message = "登录失败！";
			}
			UserDto userDto = AutoMapperHelper.Get<User, UserDto>(user);
			userDto.HasLoggedIn = this.HasLoggedIn;
			userDto.Message = this.Message;
			return userDto;
		}
		/// <summary>
		/// 注册；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>是否注册成功</returns>
		public UserDto SignUp(string userNo, string userPassword)
		{
			this.HasSignedUp = false;
			User user = new User()
			{
				No = userNo,
				Password = CrytoHelper.Md5(userPassword),
				IsActivated = true,
				RoleNo = this.GetRole(userNo).No
			};
			try
			{
				this.UserDal.Insert(user);
				this.HasSignedUp = true;
				this.Message = "注册成功。";
			}
			catch (ApplicationException ex)
			{
				this.Message = $"{ex.Message}\n注册失败！";
			}
			catch (Exception)
			{
				this.Message = "注册失败！";
			}
			UserDto userDto = AutoMapperHelper.Get<User, UserDto>(user);
			userDto.HasSignedUp = this.HasSignedUp;
			userDto.Message = this.Message;
			return userDto;
		}
		/// <summary>
		/// 构造函数；
		/// </summary>
		public UserBll()
		{
			this.UserDal = new UserDal();
			this.RoleDal = new RoleDal();
		}
	}
}
