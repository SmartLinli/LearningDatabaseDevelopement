using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

namespace ObjectOriented_InversionOfControl
{
	/// <summary>
	/// Autofac助手；
	/// </summary>
	public class AutofacHelper
	{
		/// <summary>
		/// 容器；
		/// </summary>
		private static IContainer _Container;
		/// <summary>
		/// 初始化Autofac；
		/// </summary>
		private static void InitAutofac()
		{
			var configBuilder = new ConfigurationBuilder();
			configBuilder.AddJsonFile("autofac.json");
			var config = configBuilder.Build();
			var configModule = new ConfigurationModule(config);
			var containerBuilder = new ContainerBuilder();
			containerBuilder.RegisterModule(configModule);
			_Container = containerBuilder.Build();
		}
		/// <summary>
		/// 获取实例；
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		public static T Get<T>()
		=>	_Container.Resolve<T>();
		/// <summary>
		/// 构造函数；
		/// </summary>
		static AutofacHelper()
		=>	InitAutofac();
	}
}
