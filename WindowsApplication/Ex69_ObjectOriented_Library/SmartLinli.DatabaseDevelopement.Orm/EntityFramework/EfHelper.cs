using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// EntityFramwork助手；
	/// </summary>
	public class EfHelper
	{
		/// <summary>
		/// 是否已预热；
		/// </summary>
		private static bool _HasWarmedUp = false;
		/// <summary>
		/// 获取数据库上下文；
		/// </summary>
		/// <returns></returns>
		public static SmartDbContext GetDbContext()
		=>	AutofacHelper.Get<SmartDbContext>();
		/// <summary>
		/// 预热；
		/// </summary>
		public static async void WarmUp()
		{
			if (_HasWarmedUp)
			{
				return;
			}
			using (SmartDbContext eduBase = GetDbContext())
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
			using (SmartDbContext eduBase = GetDbContext())
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
			using (SmartDbContext eduBase = GetDbContext())
			{
				return eduBase.Set<T>().Where(match).FirstOrDefault();
			}
		}
		/// <summary>
		/// 查询单个实体；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="match">匹配条件</param>
		/// <param name="objectPath">对象路径</param>
		/// <returns>实体</returns>
		public static T SelectOne<T>(Expression<Func<T, bool>> match,string objectPath) where T : class
		{
			using (SmartDbContext eduBase = GetDbContext())
			{
				return eduBase.Set<T>().Where(match).Include(objectPath).FirstOrDefault();
			}
		}
		/// <summary>
		/// 查询实体；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="match">匹配条件</param>
		/// <returns>实体</returns>
		public static List<T> Select<T>(Expression<Func<T, bool>> match) where T : class
		{
			using (SmartDbContext eduBase = GetDbContext())
			{
				return eduBase.Set<T>().Where(match).ToList();
			}
		}
		/// <summary>
		/// 查询单个实体；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="commandText">命令文本</param>
		/// <param name="parameters">参数</param>
		/// <returns>实体</returns>
		public static T SelectOne<T>(string commandText, params object[] parameters) where T : class
		{
			using (SmartDbContext eduBase = GetDbContext())
			{
				return eduBase.Database.SqlQuery<T>(commandText, parameters).FirstOrDefault();
			}
		}
		/// <summary>
		/// 查询实体；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="commandText">命令文本</param>
		/// <param name="parameters">参数</param>
		/// <returns>实体</returns>
		public static List<T> Select<T>(string commandText, params object[] parameters) where T : class
		{
			using (SmartDbContext eduBase = GetDbContext())
			{
				return eduBase.Database.SqlQuery<T>(commandText, parameters).ToList();
			}
		}
		/// <summary>
		/// 查询所有实体；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <returns>实体</returns>
		public static List<T> SelectAll<T>() where T:class
		{
			using (SmartDbContext eduBase = GetDbContext())
			{
				return eduBase.Set<T>().ToList();
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
			using (SmartDbContext eduBase = GetDbContext())
			{
				eduBase.Entry(entity).State = entityState;
				return eduBase.SaveChanges(message);
			}
		} 
	}
}
