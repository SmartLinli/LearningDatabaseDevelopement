using System.Data.Entity;

namespace ObjectOriented_EntityFramework
{
	/// <summary>
	/// 自定义数据库上下文；
	/// </summary>
	public abstract class MyDbContext : DbContext
	{
		/// <summary>
		/// 保存更改；
		/// </summary>
		/// <param name="message">消息</param>
		/// <returns>受影响行数</returns>
		public abstract int SaveChanges(string message);
		/// <summary>
		/// 构造函数；
		/// </summary>
		/// <param name="nameOrConnectionString">数据库名称或连接字符串名称</param>
		public MyDbContext(string nameOrConnectionString) 
			: base(nameOrConnectionString)
		{
			;
		}
	}
}
