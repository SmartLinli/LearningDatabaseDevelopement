using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFramework_DbContext
{
	/// <summary>
	/// EntityFramwork助手；
	/// </summary>
	public class EfHelper
	{
		/// <summary>
		/// 获取数据库上下文；
		/// </summary>
		/// <returns></returns>
		public static EduBase GetDbContext()
		=> new EduBaseSql();
		/// <summary>
		/// 查询计数；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="match">匹配条件</param>
		/// <returns>计数</returns>
		public static int SelectCount<T>(Expression<Func<T, bool>> match) where T : class
		{
			using (var dbContext = GetDbContext())
			{
				return dbContext.Set<T>().Where(match).Count();
			}
		}
		/// <summary>
		/// 根据唯一标识查询单个实体；
		/// </summary>
		/// <typeparam name="TId">标识类型</typeparam>
		/// <typeparam name="TEntity">实体类型</typeparam>
		/// <param name="id">标识</param>
		/// <returns>实体</returns>
		public static TEntity SelectById<TId, TEntity>(TId id) where TEntity : class
		{
			using (var dbContext = GetDbContext())
			{
				return dbContext.Set<TEntity>().Find(id);
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
			using (var dbContext = GetDbContext())
			{
				return dbContext.Set<T>().Where(match).FirstOrDefault();
			}
		}
		/// <summary>
		/// 查询多个实体；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="match">匹配条件</param>
		/// <returns>实体列表</returns>
		public static List<T> Select<T>(Expression<Func<T, bool>> match) where T : class
		{
			using (var dbContext = GetDbContext())
			{
				return dbContext.Set<T>().Where(match).ToList();
			}
		}
		/// <summary>
		/// 查询多个实体；
		/// </summary>
		/// <typeparam name="TEntity">实体类型</typeparam>
		/// <typeparam name="TResult">结果类型</typeparam>
		/// <param name="match">匹配条件</param>
		/// <param name="project">投影</param>
		/// <returns>实体列表</returns>
		public static List<TResult> Select<TEntity, TResult>(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, TResult>> project) where TEntity : class where TResult : class
		{
			using (var dbContext = GetDbContext())
			{
				return dbContext.Set<TEntity>().Where(match).Select(project).ToList();
			}
		}
		/// <summary>
		/// 查询所有实体；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <returns>实体列表</returns>
		public static List<T> SelectAll<T>() where T : class
		{
			using (var dbContext = GetDbContext())
			{
				return dbContext.Set<T>().ToList();
			}
		}
		/// <summary>
		/// 查询所有实体；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="path">实体路径</param>
		/// <returns>实体列表</returns>
		public static List<T> SelectAll<T>(string path) where T : class
		{
			using (var dbContext = GetDbContext())
			{
				return dbContext.Set<T>().Include(path).ToList();
			}
		}
		/// <summary>
		/// 保存；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="entity">实体</param>
		/// <param name="entityState">实体状态</param>
		/// <returns>受影响行数</returns>
		public static int Save<T>(T entity, EntityState entityState) where T : class
		{
			using (var dbContext = GetDbContext())
			{
				dbContext.Entry(entity).State = entityState;
				return dbContext.SaveChanges();
			}
		}
		public static bool InitDb()
		{
			using (var dbContext = GetDbContext())
			{
				return dbContext.Database.CreateIfNotExists();
			}
		}
	}
}
