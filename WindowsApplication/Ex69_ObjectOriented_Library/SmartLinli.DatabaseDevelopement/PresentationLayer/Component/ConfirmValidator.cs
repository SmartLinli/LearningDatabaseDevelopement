using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 确认验证器；
	/// 使用前，先调用Add方法，添加需要验证内容是否一致的2个控件；
	/// 再调用With方法，添加错误提供器；
	/// </summary>
	public partial class ConfirmValidator : BaseValidator<Control>
	{
		/// <summary>
		/// 匹配操作；
		/// </summary>
		private Func<ValidatingUnit<Control>, bool> Match
		=>	v => v.ControlText == (v["ReferenceControl"] as Control).Text.Trim();
		/// <summary>
		/// 错误消息
		/// </summary>
		private string ErrorMessage => "两次输入不一致";
		/// <summary>
		/// 配置验证规则；
		/// </summary>
		/// <param name="validatingUnit">验证单元</param>
		/// <param name="referenceControl">参照控件</param>
		/// <returns>验证单元</returns>
		private ValidatingUnit<Control> ConfigSpecification(ValidatingUnit<Control> validatingUnit, Control referenceControl)
		{
			validatingUnit.Match = this.Match;
			validatingUnit.AddSpecification("ReferenceControl", referenceControl);
			validatingUnit.ErrorMessage = this.ErrorMessage;
			return validatingUnit;
		}
		/// <summary>
		/// 添加（参照控件与确认控件）；
		/// </summary>
		/// <param name="referenceControl">参照控件</param>
		/// <param name="confirmControl">确认控件</param>
		/// <returns>确认验证器</returns>
		public ConfirmValidator Add(Control referenceControl, Control confirmControl)
		{
			ValidatingUnit<Control> validatingUnit = new ValidatingUnit<Control>(confirmControl);
			this.ConfigSpecification(validatingUnit, referenceControl);
			this.ValidatingUnits.Add(validatingUnit);
			return this;
		}
		#region 组件设计器生成的代码
		public ConfirmValidator()
		{
			InitializeComponent();
		}

		public ConfirmValidator(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
		#endregion
	}
}
