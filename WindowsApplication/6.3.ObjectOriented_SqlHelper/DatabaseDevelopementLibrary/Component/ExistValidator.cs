using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 存在验证器；
	/// </summary>
	public partial class ExistValidator : BaseValidator
	{
		/// <summary>
		/// 存在则有误；
		/// </summary>
		private bool HasErrorIfExist { get; set; }
		/// <summary>
		/// 错误消息；
		/// </summary>
		protected override string ErrorMessage => this.HasErrorIfExist ? "已存在" : "不存在";
		/// <summary>
		/// 用于控件；
		/// </summary>
		/// <param name="controls">控件</param>
		/// <returns>存在验证器</returns>
		public ExistValidator For(params Control[] controls)
		{
			this.Add(controls);
			return this;
		}
		/// <summary>
		/// 基于验证方法；
		/// </summary>
		/// <param name="match">验证方法</param>
		/// <returns>存在验证器</returns>
		public ExistValidator By(Func<string, bool> match)
		{
			this.Match = match;
			return this;
		}
		/// <summary>
		/// 若存在则显示错误；
		/// </summary>
		/// <returns>存在验证器</returns>
		public ExistValidator ShowErrorIfExist()
		{
			this.HasErrorIfExist = true;
			return this;
		}
		/// <summary>
		/// 若不存在则显示错误；
		/// </summary>
		/// <returns>存在验证器</returns>
		public ExistValidator ShowErrorIfNotExist()
		{
			this.HasErrorIfExist = false;
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
