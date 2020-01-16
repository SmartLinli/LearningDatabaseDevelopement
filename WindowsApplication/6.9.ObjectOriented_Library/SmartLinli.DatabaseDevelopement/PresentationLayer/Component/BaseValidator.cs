using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 验证单元；
	/// </summary>
	/// <typeparam name="TSpec">验证规则类型</typeparam>
	internal class BaseValidatingUnit<TSpec>
	{
		/// <summary>
		/// 验证规则；
		/// </summary>
		private Dictionary<string, TSpec> Specifications { get; set; }
		/// <summary>
		/// 需要验证的控件；
		/// </summary>
		internal Control Control { get; private set; }
		/// <summary>
		/// 错误提供器；
		/// </summary>
		internal ErrorProvider ErrorProvider { get; set; }
		/// <summary>
		/// 控件文本；
		/// </summary>
		internal string ControlText => this.Control.Text.Trim();
		/// <summary>
		/// 匹配操作；
		/// </summary>
		internal virtual Func<BaseValidatingUnit<TSpec>, bool> Match { get; set; }
		/// <summary>
		/// 错误消息；
		/// </summary>
		internal virtual string ErrorMessage { get; set; }
		/// <summary>
		/// 索引器；
		/// </summary>
		/// <param name="name">验证规则名称</param>
		/// <returns>验证规则</returns>
		internal TSpec this[string name] => this.Specifications[name];
		/// <summary>
		/// 添加验证规则；
		/// </summary>
		/// <param name="name">验证规则名称</param>
		/// <param name="item">验证规则项目</param>
		/// <returns>验证单元</returns>
		internal BaseValidatingUnit<TSpec> AddSpecification(string name, TSpec item)
		{
			if (this.Specifications == null)
			{
				this.Specifications = new Dictionary<string, TSpec>();
			}
			this.Specifications.Add(name, item);
			return this;
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
			bool controlTextMatchesRule = this.Match(this);
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
		internal BaseValidatingUnit(Control control)
		{
			control.Validating += this.Validate;
			this.Control = control;
			this.ErrorMessage = "输入无效";
		}
	}
	/// <summary>
	/// 验证器基类；
	/// </summary>
	/// <typeparam name="TSpec">验证规则类型</typeparam>
	public abstract partial class BaseValidator<TSpec> : Component
	{
		/// <summary>
		/// 验证单元；
		/// </summary>
		internal List<BaseValidatingUnit<TSpec>> ValidatingUnits = new List<BaseValidatingUnit<TSpec>>();		
		/// <summary>
		/// 添加（需要验证的控件）；
		/// </summary>
		/// <param name="controls">控件</param>
		/// <returns>验证器</returns>
		public virtual BaseValidator<TSpec> Add(params Control[] controls)
		{
			foreach (var control in controls)
			{
				BaseValidatingUnit<TSpec> validatingUnit = new BaseValidatingUnit<TSpec>(control);
				this.ValidatingUnits.Add(validatingUnit);
			}
			return this;
		}
		/// <summary>
		/// 包含（错误提供器）；
		/// </summary>
		/// <param name="errorProvider">错误提供器</param>
		/// <returns>验证器</returns>
		public virtual BaseValidator<TSpec> With(ErrorProvider errorProvider)
		{
			foreach (var validatingUnit in this.ValidatingUnits)
			{
				validatingUnit.ErrorProvider = errorProvider;
			}
			return this;
		}
		/// <summary>
		/// （为所有验证单元）配置；
		/// </summary>
		/// <param name="match">匹配操作</param>
		/// <param name="errorMessage">错误消息</param>
		/// <param name="specifications">验证规则</param>
		/// <returns>验证器</returns>
		internal virtual BaseValidator<TSpec> Configure(Func<BaseValidatingUnit<TSpec>, bool> match, string errorMessage, params (string Name, TSpec Item)[] specifications)
		{
			foreach (var validatingUnit in this.ValidatingUnits)
			{
				validatingUnit.Match = match;
				validatingUnit.ErrorMessage = errorMessage;
				if (specifications==null)
				{
					continue;
				}
				foreach (var specification in specifications)
				{
					validatingUnit.AddSpecification(specification.Name, specification.Item);
				}
			}
			return this;
		}
		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="control">需要验证的控件</param>
		/// <param name="match">匹配操作</param>
		/// <param name="errorMessage">错误消息</param>
		/// <param name="specifications">验证规则</param>
		/// <returns>验证器</returns>
		internal virtual BaseValidator<TSpec> Add(Control control, Func<BaseValidatingUnit<TSpec>, bool> match, string errorMessage, params (string Name, TSpec Item)[] specifications)
		{
			BaseValidatingUnit<TSpec> validatingUnit = new BaseValidatingUnit<TSpec>(control);
			validatingUnit.Match = match;
			validatingUnit.ErrorMessage = errorMessage;
			foreach (var specification in specifications)
			{
				validatingUnit.AddSpecification(specification.Name, specification.Item);
			}
			this.ValidatingUnits.Add(validatingUnit);
			return this;
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
