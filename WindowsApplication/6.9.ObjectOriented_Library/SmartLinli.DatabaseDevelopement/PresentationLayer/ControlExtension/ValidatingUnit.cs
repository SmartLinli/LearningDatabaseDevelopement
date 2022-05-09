using Microsoft.CSharp.RuntimeBinder;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 验证单元；
	/// 针对单个控件，执行具体验证过程；
	/// 控件所在窗体应有错误提供器；
	/// </summary>
	internal partial class ValidatingUnit
	{
		/// <summary>
		/// 需要验证的控件；
		/// </summary>
		internal virtual Control Control { get; private set; }
		/// <summary>
		/// 错误提供器；
		/// </summary>
		internal virtual ErrorProvider ErrorProvider { get; private set; }
		/// <summary>
		/// 控件文本；
		/// </summary>
		internal virtual string ControlText => this.Control.Text.Trim();
		/// <summary>
		/// 匹配操作；
		/// </summary>
		internal virtual Func<string, bool> Match { get; set; }
		/// <summary>
		/// 错误消息；
		/// </summary>
		internal virtual string ErrorMessage { get; set; }
		/// <summary>
		/// 获取错误提供器；
		/// 控件所在窗体应有错误提供器，并通过名为ErrorProvider的公有属性访问；
		/// </summary>
		/// <param name="control">需要验证的控件</param>
		/// <returns>错误提供器</returns>
		private ErrorProvider GetErrorProvider(Control control)
		{
			ErrorProvider errorProvider;
			try
			{
				errorProvider = (control.FindForm() as dynamic).ErrorProvider;
			}
			catch (RuntimeBinderException)
			{
				throw new NotImplementedException("当前窗体未定义公有的ErrorProvider");
			}
			return errorProvider;
		}
		/// <summary>
		/// 验证；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		internal virtual void Validate(object sender, CancelEventArgs e)
		{
			Control control = sender as Control;
			string
				controlDescription = control.AccessibleDescription == null ? control.Name : control.AccessibleDescription.ToString()
				, currentValidatorMessage = $"{controlDescription}{this.ErrorMessage}"
				, errorProviderMessage = this.ErrorProvider.GetError(control);
			bool errorProviderHasErrorFromOtherValidator =
					errorProviderMessage != string.Empty
					&& errorProviderMessage != currentValidatorMessage;
			if (errorProviderHasErrorFromOtherValidator)
			{
				return;
			}
			bool controlTextMatchesRule = this.Match(this.ControlText);
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
		/// <param name="control">需要验证的控件</param>
		internal ValidatingUnit(Control control)
		{
			control.Validating += this.Validate;
			this.Control = control;
			this.ErrorProvider = GetErrorProvider(control);
			this.ErrorMessage = "输入无效";
		}
	}
}
