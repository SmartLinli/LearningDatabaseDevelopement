using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 必填信息验证器；
	/// </summary>
	public partial class RequiredInfoValidator : BaseValidator
	{
		/// <summary>
		/// 匹配条件；
		/// </summary>
		protected override Func<string, bool> Match
		=>	(s => !string.IsNullOrEmpty(s));
		/// <summary>
		/// 错误消息；
		/// </summary>
		protected override string ErrorMessage => "不能为空";
		/// <summary>
		/// 用于控件；
		/// </summary>
		/// <param name="controls">控件</param>
		/// <returns>必填信息验证器</returns>
		public RequiredInfoValidator For(params Control[] controls)
		{
			this.Add(controls);
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
