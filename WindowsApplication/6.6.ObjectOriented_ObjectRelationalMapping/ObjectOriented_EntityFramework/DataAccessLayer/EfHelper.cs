using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ObjectOriented_EntityFramework
{
	/// <summary>
	/// EntityFramwork助手；
	/// </summary>
	public class EfHelper
	{
		/// <summary>
		/// 是否已预热；
		/// </summary>
		private static bool HasWarmedUp { get; set; }
		/// <summary>
		/// 获取数据库上下文；
		/// </summary>
		/// <returns></returns>
		private static MyDbContext GetDbContext()
		=>	new EduBasePgsql();
		/// <summary>
		/// 预热；
		/// </summary>
		public static async void WarmUp()
		{
			if (HasWarmedUp)
			{
				return;
			}
			using (MyDbContext eduBase = GetDbContext())
			{
				await Task.Run(() => eduBase.Database.ExecuteSqlCommand("SELECT 1"));
			}
		}
		/// <summary>
		/// 查询计数；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="match">匹配条件</param>
		/// <returns>计数</returns>
		public static int SelectCount<T>(Expression<Func<T, bool>> match) where T : class
		{
			using (MyDbContext eduBase = GetDbContext())
			{
				return eduBase.Set<T>().Where(match).Count();
			}
		}
		/// <summary>
		/// 查询单个实体；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="match">匹配条件</param>
		/// <returns>实体</returns>
		public static T SelectOne<T>(Expression<Func<T, bool>> match) where T : class
		{
			using (MyDbContext eduBase = GetDbContext())
			{
				return eduBase.Set<T>().Where(match).FirstOrDefault();
			}
		}
		/// <summary>
		/// 查询实体；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="match">匹配条件</param>
		/// <returns>实体</returns>
		public static IQueryable<T> SelectMany<T>(Expression<Func<T, bool>> match) where T : class
		{
			using (MyDbContext eduBase = GetDbContext())
			{
				return eduBase.Set<T>().Where(match);
			}
		}
		/// <summary>
		/// 保存；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="entity">实体</param>
		/// <param name="entityState">实体状态</param>
		/// <param name="message">消息</param>
		/// <returns>受影响行数</returns>
		public static int Save<T>(T entity, EntityState entityState, string message = "") where T : class
		{
			using (MyDbContext eduBase = GetDbContext())
			{
				eduBase.Entry(entity).State = entityState;
				return eduBase.SaveChanges(message);
			}
		}
		/// <summary>
		/// 构造函数；
		/// </summary>
		static EfHelper()
		{
			HasWarmedUp = false;
		}
	}
}
