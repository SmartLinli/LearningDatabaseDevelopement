using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace ObjectOriented_DataTransferObject
{
	/// <summary>
	/// 用户（数据传输对象）；
	/// </summary>
	[AutoMap(typeof(User))]
	public class UserDto
	{
		/// <summary>
		/// 用户号；
		/// </summary>
		public string No { get; set; }
		/// <summary>
		/// 密码；
		/// </summary>
		public byte[] Password { get; set; }
		/// <summary>
		/// 角色名称；
		/// </summary>
		public string RoleName { get; set; }
		/// <summary>
		/// 是否完成登录；
		/// </summary>
		[Ignore]
		public bool HasLoggedIn { get; set; }
		/// <summary>
		/// 是否完成注册；
		/// </summary>
		[Ignore]
		public bool HasSignedUp { get; set; }
		/// <summary>
		/// 消息；
		/// </summary>
		[Ignore]
		public string Message { get; set; }
	}
}
