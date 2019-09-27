using System;
using System.Configuration;
using System.Reflection;

namespace ObjectOriented_MultiDb
{
	/// <summary>
	/// 数据访问层工厂；
	/// </summary>
	public class DalFactory
	{
		/// <summary>
		/// 创建数据访问层；
		/// </summary>
		/// <returns>数据访问层</returns>
		public static IUserDal CreateUserDal()
		{
			IUserDal userDal = null;
			string dalTypeName = ConfigurationManager.AppSettings["DalType"];
			switch (dalTypeName)
			{
				case "PgSql":
					userDal = new UserDalPgSql();
					break;
				default:
					userDal = new UserDalSql();
					break;
			}
			return userDal;
		}
		/// <summary>
		/// 创建数据访问层；
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <returns>数据访问层</returns>
		public static TResult Create<TResult>()
		{
			string currentNamespace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
			Type dalInterface = typeof(TResult);
			string dalInterfaceName = dalInterface.Name;
			string modelTypeName = dalInterfaceName.Replace("Dal", "").Substring(1);
			string dalTypeNameSuffix = ConfigurationManager.AppSettings["DalType"];
			string dalFullTypeName = $"{currentNamespace}.{modelTypeName}Dal{dalTypeNameSuffix}";
			Type dalType = Type.GetType(dalFullTypeName);
			TResult dal = (TResult)Activator.CreateInstance(dalType);
			return dal;
		}
	}
}
