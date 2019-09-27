using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ObjectOriented_Layer
{
	/// <summary>
	/// 验证器基类；
	/// </summary>
	public partial class BaseValidator : Component
	{
		/// <summary>
		/// 控件列表；
		/// </summary>
		private List<Control> _Controls = new List<Control>();
		/// <summary>
		/// 错误提供器；
		/// </summary>
		private ErrorProvider _ErrorProvider;
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
		/// <param name="controls">控件</param>
		/// <returns>验证器</returns>
		public BaseValidator Add(params Control[] controls)
		{
			foreach (var control in controls)
			{
				control.Validating += this.Validate;
			}
			this._Controls.AddRange(controls);
			return this;
		}
		/// <summary>
		/// 添加（错误提供器）；
		/// </summary>
		/// <param name="errorProvider">错误提供器</param>
		/// <returns>验证器</returns>
		public BaseValidator Add(ErrorProvider errorProvider)
		{
			this._ErrorProvider = errorProvider;
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
		protected virtual void Validate(object sender, CancelEventArgs e)
		{
			Control control = sender as Control;
			string
				controlDescription = control.Tag == null ? control.Name : control.Tag.ToString()
				, currentValidatorMessage = $"{controlDescription}{this.ErrorMessage}"
				, errorProviderMessage = this._ErrorProvider.GetError(control);
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
				this._ErrorProvider.SetError(control, currentValidatorMessage);
				return;
			}
			this._ErrorProvider.SetError(control, string.Empty);
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
