using System;

namespace ObjectOriented_Layer
{
	/// <summary>
	/// 用户（业务逻辑层）；
	/// </summary>
	public class UserBll
	{
		/// <summary>
		/// 用户（数据访问层）；
		/// </summary>
		private UserDal UserDal;
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
			set;
		}
		/// <summary>
		/// 是否完成注册；
		/// </summary>
		public bool HasSignedUp
		{
			get;
			set;
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
		private void ProcessUserNotExists(User user)
		{
			if (user == null)
			{
				this.Message = "用户号不存在！";
				throw new Exception();
			}
		}
		/// <summary>
		/// 处理用户密码错误且被冻结；
		/// </summary>
		/// <param name="user">用户</param>
		/// <param name="password">密码</param>
		private void ProcessUserPasswordNotMatchAndNotActivated(User user,string password)
		{
			bool isPasswordMatch = CrytoHelper.Md5Equal(user.Password, password);
			if (!isPasswordMatch && !user.IsActivated)
			{
				this.Message = "密码错误！\n用户已被冻结，需要手机验证！";
				throw new Exception();
			}
		}
		/// <summary>
		/// 处理用户被冻结；
		/// </summary>
		/// <param name="user">用户</param>
		private void ProcessUserNotActivated(User user)
		{
			if (!user.IsActivated)
			{
				this.Message = "用户已被冻结，需要手机验证！";
				throw new Exception();
			}
		}
		/// <summary>
		/// 处理用户登录失败超出限制；
		/// </summary>
		/// <param name="user">用户</param>
		private void ProcessUserLoginFailOutOfLimit(User user)
		{
			if (user.LoginFailCount >= 3)
			{
				user.IsActivated = false;
				this.UserDal.Update(user);
				this.Message = "密码错误达3次！\n用户已被冻结，需要手机验证！";
				throw new Exception();
			}
		}
		/// <summary>
		/// 处理用户登录失败；
		/// </summary>
		/// <param name="user">用户</param>
		private void ProcessUserLoginFail(User user)
		{
			user.LoginFailCount++;
			this.UserDal.Update(user);
			this.ProcessUserLoginFailOutOfLimit(user);
			this.Message = $"密码错误，请重新输入！\n您还有{3 - user.LoginFailCount}次机会！";
			throw new Exception();
		}
		/// <summary>
		/// 处理用户密码错误；
		/// </summary>
		/// <param name="user">用户</param>
		/// <param name="password">密码</param>
		private void ProcessUserPasswordNotMatch(User user,string password)
		{
			bool isPasswordMatch = CrytoHelper.Md5Equal(user.Password, password);
			if (!isPasswordMatch)
			{
				this.ProcessUserLoginFail(user);
				throw new Exception();
			}
		}
		/// <summary>
		/// 处理用户登录成功；
		/// </summary>
		/// <param name="user">用户</param>
		private void ProcessUserLoginOk(User user)
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
		/// 检查是否存在；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>是否存在</returns>
		public bool CheckExists(string userNo) 
		=>	this.UserDal.SelectCount(userNo) == 1;
		/// <summary>
		/// 检查是否不存在；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>是否不存在</returns>
		public bool CheckNotExists(string userNo) 
		=>	!this.CheckExists(userNo);
		/// <summary>
		/// 登录；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>是否登录成功</returns>
		public User LogIn(string userNo, string userPassword)
		{
			this.HasLoggedIn = false;
			User user = this.UserDal.Select(userNo);
			try
			{
				this.ProcessUserNotExists(user);
				this.ProcessUserPasswordNotMatchAndNotActivated(user, userPassword);
				this.ProcessUserNotActivated(user);
				this.ProcessUserPasswordNotMatch(user, userPassword);
				this.ProcessUserLoginOk(user);
			}
			catch (Exception)
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
			return user;
		}
		/// <summary>
		/// 构造函数；
		/// </summary>
		public UserBll()
		{
			this.UserDal = new UserDal();
		}
	}
}
