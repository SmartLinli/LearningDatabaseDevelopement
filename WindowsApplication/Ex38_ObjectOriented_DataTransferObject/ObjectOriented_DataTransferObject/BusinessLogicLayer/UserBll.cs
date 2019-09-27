using System;

namespace ObjectOriented_DataTransferObject
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
		/// 角色（数据访问层）；
		/// </summary>
		private RoleDal _RoleDal;
		/// <summary>
		/// 是否完成登录；
		/// </summary>
		private bool _HasLoggedIn;
		/// <summary>
		/// 是否完成注册；
		/// </summary>
		private bool _HasSignedUp;
		/// <summary>
		/// 消息；
		/// </summary>
		private string _Message;
		/// <summary>
		/// 默认角色名称；
		/// </summary>
		private readonly string _DefaultRoleName = "学生";
		/// <summary>
		/// 用户号最小长度；
		/// </summary>
		public static readonly int UserNoMinLengh = 7;
		/// <summary>
		/// 用户号最大长度；
		/// </summary>
		public static readonly int UserNoMaxLengh = 10;
		/// <summary>
		/// 处理用户不存在；
		/// </summary>
		/// <param name="user">用户</param>
		private void HandleUserNotExists(User user)
		{
			if (user == null)
			{
				this._Message = "用户号不存在！";
				throw new Exception();
			}
		}
		/// <summary>
		/// 处理用户密码错误且被冻结；
		/// </summary>
		/// <param name="user">用户</param>
		/// <param name="password">密码</param>
		private void HandleUserPasswordNotMatchAndNotActivated(User user, string password)
		{
			bool isPasswordMatch = CrytoHelper.Md5Equal(user.Password, password);
			if (!isPasswordMatch && !user.IsActivated)
			{
				this._Message = "密码错误！\n用户已被冻结，需要手机验证！";
				throw new Exception();
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
				this._Message = "用户已被冻结，需要手机验证！";
				throw new Exception();
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
				this._Message = "密码错误达3次！\n用户已被冻结，需要手机验证！";
				throw new Exception();
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
			this._Message = $"密码错误，请重新输入！\n您还有{3 - user.LoginFailCount}次机会！";
			throw new Exception();
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
			}
		}
		/// <summary>
		/// 处理用户登录成功；
		/// </summary>
		/// <param name="user">用户</param>
		private void HandleUserLoginOk(User user)
		{
			if (user.LoginFailCount!=0)
			{
				user.LoginFailCount = 0;
				this._UserDal.Update(user);
			}
			this._HasLoggedIn = true;
			this._Message = "登录成功。";
		}
		/// <summary>
		/// 获取角色；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>角色</returns>
		private Role GetRole(string userNo)
		{
			string roleName = this._DefaultRoleName;
			if (userNo.Length == 7)
			{
				roleName = "教师";
			}
			return this._RoleDal.Select(roleName);
		}
		/// <summary>
		/// 检查是否存在；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>是否存在</returns>
		public bool CheckExists(string userNo) 
		=>	this._UserDal.SelectCount(userNo) == 1;
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
		public UserDto LogIn(string userNo, string userPassword)
		{
			this._HasLoggedIn = false;
			User user = this._UserDal.Select(userNo);
			try
			{
				this.HandleUserNotExists(user);
				this.HandleUserPasswordNotMatchAndNotActivated(user, userPassword);
				this.HandleUserNotActivated(user);
				this.HandleUserPasswordNotMatch(user, userPassword);
				this.HandleUserLoginOk(user);
			}
			catch (Exception)
			{
				this._Message = "登录失败！"; ;
			}
			UserDto userDto = AutoMapperHelper.Get<User, UserDto>(user);
			userDto.HasLoggedIn = this._HasLoggedIn;
			userDto.Message = this._Message;
			return userDto;
		}
		/// <summary>
		/// 注册；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>是否注册成功</returns>
		public UserDto SignUp(string userNo, string userPassword)
		{
			this._HasSignedUp = false;
			User user = new User()
			{
				No = userNo,
				Password = CrytoHelper.Md5(userPassword),
				IsActivated = true,
				RoleNo = this.GetRole(userNo).No
			};
			try
			{
				this._UserDal.Insert(user);
				this._HasSignedUp = true;
				this._Message = "注册成功。";
			}
			catch (ApplicationException ex)
			{
				this._Message = $"{ex.Message}\n注册失败！";
			}
			catch (Exception)
			{
				this._Message = "注册失败！";
			}
			UserDto userDto = AutoMapperHelper.Get<User, UserDto>(user);
			userDto.HasSignedUp = this._HasSignedUp;
			userDto.Message = this._Message;
			return userDto;
		}
		/// <summary>
		/// 构造函数；
		/// </summary>
		public UserBll()
		{
			this._UserDal = new UserDal();
			this._RoleDal = new RoleDal();
		}
	}
}
