using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 验证器组件；
	/// </summary>
	public partial class ValidatorComponent : Component
	{
		/// <summary>
		/// 验证器列表；
		/// </summary>
		private List<BaseValidator> Validators { get; set; }
		/// <summary>
		/// 错误提供器；
		/// </summary>
		private ErrorProvider ErrorProvider { get; set; }
		/// <summary>
		/// 初始化成员；
		/// </summary>
		private void InitializeMembers()
		{
			this.Validators = new List<BaseValidator>();
			this.ErrorProvider = new ErrorProvider();
		}
		/// <summary>
		/// 添加验证器；
		/// </summary>
		/// <typeparam name="T">验证器类型</typeparam>
		/// <param name="configValidator">调用验证器中的方法，对验证器进行配置</param>
		/// <returns>验证器组件</returns>
		public ValidatorComponent Add<T>(Func<T, T> configValidator) where T : BaseValidator, new()
		{
			T validator = new T();
			configValidator(validator);
			validator.SetErrorProvider(this.ErrorProvider);
			this.Validators.Add(validator);
			return this;
		}
		/// <summary>
		/// 添加多个验证器；
		/// </summary>
		/// <typeparam name="T">验证器类型</typeparam>
		/// <param name="configValidators">调用验证器中的方法，对验证器进行配置</param>
		/// <returns>验证器组件</returns>
		public ValidatorComponent Add<T>(params Func<T, T>[] configValidators) where T : BaseValidator, new()
		{
			foreach (var config in configValidators)
			{
				this.Add(config);
			}
			return this;
		}
		#region 组件设计器生成的代码
		/// <summary>
		/// 构造函数；
		/// </summary>
		public ValidatorComponent()
		{
			InitializeComponent();
			this.InitializeMembers();
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="container">容器</param>
		public ValidatorComponent(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
			this.InitializeMembers();
		}
		#endregion
	}
}
