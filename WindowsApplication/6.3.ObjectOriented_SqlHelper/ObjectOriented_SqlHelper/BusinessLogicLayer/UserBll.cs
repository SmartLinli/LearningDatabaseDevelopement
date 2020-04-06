using System;

namespace ObjectOriented_SqlHelper
{
	/// <summary>
	/// 用户（业务逻辑层）；
	/// </summary>
	public class UserBll
	{
		/// <summary>
		/// 用户（数据访问层）；
		/// </summary>
		private UserDal _UserDal;
		/// <summary>
		/// 用户号最小长度；
		/// </summary>
		public static readonly int UserNoMinLengh = 10;
		/// <summary>
		/// 用户号最大长度；
		/// </summary>
		public static readonly int UserNoMaxLengh = 10;
		/// <summary>
		/// 是否完成登录；
		/// </summary>
		public bool HasLoggedIn
		{
			get;
			private set;
		}
		/// <summary>
		/// 是否完成注册；
		/// </summary>
		public bool HasSignedUp
		{
			get;
			private set;
		}
		/// <summary>
		/// 消息；
		/// </summary>
		public string Message
		{
			get;
			private set;
		}
		/// <summary>
		/// 处理用户不存在；
		/// </summary>
		/// <param name="user">用户</param>
		private void HandleUserNotExist(User user)
		{
			if (user == null)
			{
				this.Message = "用户号不存在！";
				throw new ApplicationException();
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
				this.Message = "用户已被冻结，需要手机验证！";
				throw new ApplicationException();
			}
		}
		/// <summary>
		/// 处理用户登录失败次数过多；
		/// </summary>
		/// <param name="user">用户</param>
		private void HandleUserLoginFailTooManyTimes(User user)
		{
			if (user.LoginFailCount >= 3)
			{
				user.IsActivated = false;
				this._UserDal.Update(user);
				this.Message = "密码错误达3次！\n用户已被冻结，需要手机验证！";
				throw new ApplicationException();
			}
		}
		/// <summary>
		/// 处理用户登录失败；
		/// </summary>
		/// <param name="user">用户</param>
		private void HandleUserLoginFail(User user)
		{
			user.LoginFailCount++;
			this._UserDal.Update(user);
			this.HandleUserLoginFailTooManyTimes(user);
			this.Message = $"密码错误，请重新输入！\n您还有{3 - user.LoginFailCount}次机会！";
			throw new ApplicationException();
		}
		/// <summary>
		/// 处理用户密码错误；
		/// </summary>
		/// <param name="user">用户</param>
		/// <param name="password">密码</param>
		private void HandleUserPasswordNotMatch(User user,string password)
		{
			bool isPasswordMatch = CrytoHelper.Md5Equal(user.Password, password);
			if (!isPasswordMatch)
			{
				this.HandleUserLoginFail(user);
				throw new ApplicationException();
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
				this._UserDal.Update(user);
			}
			this.HasLoggedIn = true;
			this.Message = "登录成功。";
		}
		/// <summary>
		/// 检查是否存在；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>是否存在</returns>
		public bool CheckExist(string userNo) 
		=>	this._UserDal.SelectCount(userNo) == 1;
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
		public User LogIn(string userNo, string userPassword)
		{
			this.HasLoggedIn = false;
			User user = this._UserDal.Select(userNo);
			try
			{
				this.HandleUserNotExist(user);
				this.HandleUserNotActivated(user);
				this.HandleUserPasswordNotMatch(user, userPassword);
				this.HandleUserLoginOk(user);
			}
			catch (ApplicationException)
			{
				;
			}
			return user;
		}
		/// <summary>
		/// 注册；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>是否注册成功</returns>
		public User SignUp(string userNo, string userPassword)
		{
			this.HasSignedUp = false;
			User user = new User()
			{
				No = userNo,
				Password = CrytoHelper.Md5(userPassword),
				IsActivated = true
			};
			try
			{
				this._UserDal.Insert(user);
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
			return user;
		}
		/// <summary>
		/// 构造函数；
		/// </summary>
		public UserBll()
		{
			this._UserDal = new UserDal();
		}
	}
}
