using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 存在验证器；
	/// 使用前，先调用Add方法，添加需要验证的控件、匹配操作、并指定存在是否为有效；
	/// 亦可先调用Add方法，批量添加需要验证的控件，再调用Configure方法，统一配置匹配操作、并指定存在是否为有效；
	/// 最后调用With方法，添加错误提供器；
	/// </summary>
	public partial class ExistValidator : BaseValidator<Func<string, bool>>
	{
		/// <summary>
		/// 存在为有效；
		/// </summary>
		private bool ExistIsValid = true;
		/// <summary>
		/// 错误消息；
		/// </summary>
		private string ErrorMessage => this.ExistIsValid ? "不存在" : "已存在";
		/// <summary>
		/// 配置验证规则；
		/// </summary>
		/// <param name="validatingUnit">验证单元</param>
		/// <param name="match">匹配操作</param>
		/// <param name="existIsValid">存在是否为有效</param>
		/// <returns></returns>
		private ValidatingUnit<Func<string, bool>> ConfigSpecification(ValidatingUnit<Func<string, bool>> validatingUnit, Func<string, bool> match, bool existIsValid)
		{
			this.ExistIsValid = existIsValid;
			validatingUnit.Match = s => match(s.ControlText);
			validatingUnit.ErrorMessage = existIsValid ? "不存在" : "已存在";
			return validatingUnit;
		}
		/// <summary>
		/// 添加（需要验证的控件）；
		/// 同时指定匹配操作、存在是否为有效；
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="match">匹配操作</param>
		/// <param name="existIsValid">存在是否为有效</param>
		/// <returns>存在验证器</returns>
		public ExistValidator Add(Control control, Func<string, bool> match, bool existIsValid)
		{
			ValidatingUnit<Func<string, bool>> validatingUnit = new ValidatingUnit<Func<string, bool>>(control);
			this.ConfigSpecification(validatingUnit, match, existIsValid);
			this.ValidatingUnits.Add(validatingUnit);
			return this;
		}
		/// <summary>
		/// 配置；
		/// </summary>
		/// <param name="match">匹配操作</param>
		/// <param name="existIsValid">存在是否为有效</param>
		/// <returns>存在验证器</returns>
		public ExistValidator Configure(Func<string, bool> match, bool existIsValid)
		{
			this.ExistIsValid = existIsValid;
			foreach (var validatingUnit in this.ValidatingUnits)
			{
				validatingUnit.Match = s => match(s.ControlText);
				validatingUnit.ErrorMessage = this.ErrorMessage;
			}
			return this;
		}
		#region 组件设计器生成的代码
		public ExistValidator()
		{
			InitializeComponent();
		}

		public ExistValidator(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
		#endregion
	}
}
