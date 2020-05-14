namespace ObjectOriented_DataTransferObject
{
	/// <summary>
	/// 用户（业务逻辑层）接口；
	/// </summary>
	public interface IUserBll
	{
		/// <summary>
		/// 用户号最小长度；
		/// </summary>
		int UserNoMinLength { get; }
		/// <summary>
		/// 用户号最大长度；
		/// </summary>
		int UserNoMaxLength { get; }
		/// <summary>
		/// 密码最小长度；
		/// </summary>
		int PasswordMinLengh { get; }
		/// <summary>
		/// 密码最大长度；
		/// </summary>
		int PasswordMaxLengh { get; }
		/// <summary>
		/// 是否完成登录；
		/// </summary>
		bool HasLoggedIn { get; }
		/// <summary>
		/// 是否完成注册；
		/// </summary>
		bool HasSignedUp { get; }
		/// <summary>
		/// 消息；
		/// </summary>
		string Message { get; }
		/// <summary>
		/// 检查是否存在；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>是否存在</returns>
		bool CheckExist(string userNo);
		/// <summary>
		/// 检查是否不存在；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>是否不存在</returns>
		bool CheckNotExist(string userNo);
		/// <summary>
		/// 登录；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <param name="password">密码</param>
		/// <returns>用户</returns>
		UserDto LogIn(string userNo, string password);
		/// <summary>
		/// 注册；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <param name="password">密码</param>
		/// <returns>用户</returns>
		UserDto SignUp(string userNo, string password);
	}
}
