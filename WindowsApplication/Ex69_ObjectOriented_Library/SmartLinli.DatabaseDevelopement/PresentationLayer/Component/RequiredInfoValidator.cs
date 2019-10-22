using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 必填信息验证器；
	/// 使用前，先调用Add方法，批量添加需要验证的控件；
	/// 再调用With方法，添加错误提供器；
	/// </summary>
	public partial class RequiredInfoValidator : BaseValidator<object>
	{
		/// <summary>
		/// 匹配操作；
		/// </summary>
		private Func<ValidatingUnit<object>, bool> Match
		=>	v => !string.IsNullOrEmpty(v.ControlText);
		/// <summary>
		/// 错误消息；
		/// </summary>
		private string ErrorMessage => "不能为空";
		/// <summary>
		/// 添加（需要验证的控件）；
		/// </summary>
		/// <param name="controls">控件</param>
		/// <returns>验证器</returns>
		public override BaseValidator<object> Add(params Control[] controls)
		{
			base.Add(controls);
			base.Configure(this.Match, this.ErrorMessage);
			return this;
		}
		#region 组件设计器生成的代码
		public RequiredInfoValidator()
		{
			InitializeComponent();

		}

		public RequiredInfoValidator(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
		#endregion
	}
}
