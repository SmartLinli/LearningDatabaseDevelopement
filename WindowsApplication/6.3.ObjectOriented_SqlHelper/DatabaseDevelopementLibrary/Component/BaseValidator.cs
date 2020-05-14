using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 验证器基类；
	/// </summary>
	public abstract partial class BaseValidator
	{
		/// <summary>
		/// 控件列表；
		/// </summary>
		private List<Control> Controls { get; set; }
		/// <summary>
		/// 错误提供器；
		/// </summary>
		private ErrorProvider ErrorProvider { get; set; }
		/// <summary>
		/// 匹配条件；
		/// </summary>
		protected virtual Func<string, bool> Match { get; set; }
		/// <summary>
		/// 错误消息；
		/// </summary>
		protected virtual string ErrorMessage => "输入无效";
		/// <summary>
		/// 设置错误提供器；
		/// </summary>
		/// <param name="errorProvider">错误提供器</param>
		internal void SetErrorProvider(ErrorProvider errorProvider)
		{
			if (this.ErrorProvider != null)
				return;
			this.ErrorProvider = errorProvider;
		}
		/// <summary>
		/// 添加控件；
		/// </summary>
		/// <param name="controls">控件</param>
		/// <returns>验证器</returns>
		protected BaseValidator Add(params Control[] controls)
		{
			foreach (var control in controls)
			{
				control.Validating += this.Validate;
			}
			this.Controls.AddRange(controls);
			return this;
		}
		/// <summary>
		/// 验证；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void Validate(object sender, CancelEventArgs e)
		{
			Control control = sender as Control;
			string
				controlDescription = control.Tag == null ? control.Name : control.Tag.ToString()
				, currentValidatorMessage = $"{controlDescription}{this.ErrorMessage}"
				, errorProviderMessage = this.ErrorProvider.GetError(control);
			bool errorProviderHasErrorFromOtherValidator =
					errorProviderMessage != string.Empty
					&& errorProviderMessage != currentValidatorMessage;
			if (errorProviderHasErrorFromOtherValidator)
			{
				return;
			}
			bool controlTextMatchesRule = this.Match(control.Text.Trim());
			if (!controlTextMatchesRule)
			{
				this.ErrorProvider.SetError(control, currentValidatorMessage);
				return;
			}
			this.ErrorProvider.SetError(control, string.Empty);
		}
		/// <summary>
		/// 构造函数；
		/// </summary>
		public BaseValidator()
		{
			this.Controls = new List<Control>();
		}
	}
}
