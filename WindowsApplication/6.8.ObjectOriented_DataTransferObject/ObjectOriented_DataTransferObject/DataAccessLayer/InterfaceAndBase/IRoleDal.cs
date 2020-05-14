namespace ObjectOriented_DataTransferObject
{
	/// <summary>
	/// 角色（数据访问层）接口；
	/// </summary>
	public interface IRoleDal
	{
		/// <summary>
		/// 查询；
		/// </summary>
		/// <param name="roleName">角色名称</param>
		/// <returns>角色</returns>
		Role Select(string roleName);
	}
}