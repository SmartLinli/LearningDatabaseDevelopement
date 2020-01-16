using AutoMapper;
using System.Reflection;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// AutoMapper助手；
	/// </summary>
	public class AutoMapperHelper
	{
		/// <summary>
		/// 映射器；
		/// </summary>
		private static Mapper _Mapper;
		/// <summary>
		/// 初始化AutoMapper；
		/// </summary>
		private static void InitMapper()
		{
			var assemblyName = Assembly.GetCallingAssembly().GetName().Name;
			var mapperConfig = new MapperConfiguration
				(c =>
				{
					c.AddMaps(assemblyName);
					c.AllowNullDestinationValues = false;
				});
			_Mapper = new Mapper(mapperConfig);
		}
		/// <summary>
		/// 获取目标对象；
		/// </summary>
		/// <typeparam name="TSource">来源类型</typeparam>
		/// <typeparam name="TDestination">目标类型</typeparam>
		/// <param name="source">源对象</param>
		/// <returns>目标对象</returns>
		public static TDestination Get<TSource,TDestination>(TSource source)
		=>	_Mapper.Map<TSource, TDestination>(source);
		/// <summary>
		/// 构造函数；
		/// </summary>
		static AutoMapperHelper()
		=>	InitMapper();
	}
}
