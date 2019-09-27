using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ObjectOriented_Dapper
{
	/// <summary>
	/// 验证器基类；
	/// </summary>
	public partial class BaseValidator : Component
	{
		/// <summary>
		/// 控件列表；
		/// </summary>
		private List<Control> Controls = new List<Control>();
		/// <summary>
		/// 错误提供器；
		/// </summary>
		private ErrorProvider ErrorProvider;
		/// <summary>
		/// 匹配条件；
		/// </summary>
		protected virtual Func<string, bool> Match
		{
			get;
			set;
		}
		/// <summary>
		/// 错误消息；
		/// </summary>
		protected virtual string ErrorMessage => "输入无效";
		/// <summary>
		/// 添加（控件）；
		/// </summary>
		/// <param name="control">控件</param>
		/// <returns>验证器</returns>
		public BaseValidator Add(Control control)
		{
			control.Validating += this.Validate;
			this.Controls.Add(control);
			return this;
		}
		/// <summary>
		/// 添加（控件数组）；
		/// </summary>
		/// <param name="controls">控件</param>
		/// <returns>验证器</returns>
		public BaseValidator Add(Control[] controls)
		{
			foreach (var control in controls)
			{
				control.Validating += this.Validate;
			}
			this.Controls.AddRange(controls);
			return this;
		}
		/// <summary>
		/// 添加（错误提供器）；
		/// </summary>
		/// <param name="errorProvider">错误提供器</param>
		/// <returns>验证器</returns>
		public BaseValidator Add(ErrorProvider errorProvider)
		{
			this.ErrorProvider = errorProvider;
			return this;
		}
		/// <summary>
		/// 配置；
		/// </summary>
		/// <param name="parameters">参数</param>
		/// <returns>验证器</returns>
		public virtual BaseValidator Configure(params object[] parameters) => this;
		/// <summary>
		/// 验证；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Validate(object sender, CancelEventArgs e)
		{
			Control control = sender as Control;
			string
				controlDescription = control.Tag == null ? control.Name : control.Tag.ToString(),
				errorMessage = $"{controlDescription}{this.ErrorMessage}"
				, oldErrorMessage = this.ErrorProvider.GetError(control);
			bool
				ControlTextMatchesRule = this.Match(control.Text.Trim())
				, errorProviderHasError = oldErrorMessage != string.Empty
				, errorProviderHasSameOldError = oldErrorMessage == errorMessage;
			if (!ControlTextMatchesRule)
			{
				if (errorProviderHasError)
				{
					return;
				}
				this.ErrorProvider.SetError(control, errorMessage);
				return;
			}
			if (errorProviderHasSameOldError)
			{
				this.ErrorProvider.SetError(control, string.Empty);
			}
		}
		#region 组件设计器生成的代码
		public BaseValidator()
		{
			InitializeComponent();
		}

		public BaseValidator(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
		#endregion
	}
}
