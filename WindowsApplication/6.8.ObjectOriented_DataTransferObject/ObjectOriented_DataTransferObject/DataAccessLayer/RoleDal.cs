namespace ObjectOriented_DataTransferObject
{
	/// <summary>
	/// 角色（基于EntityFramwork的数据访问层）；
	/// </summary>
	public class RoleDal : DalBase, IRoleDal
	{
		/// <summary>
		/// 查询角色；
		/// </summary>
		/// <param name="roleName">角色名称</param>
		/// <returns>角色</returns>
		public Role Select(string roleName)
		=>	EfHelper.SelectOne<Role>(r => r.Name == roleName);
	}
}
