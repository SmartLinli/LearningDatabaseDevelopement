using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 长度验证器；
	/// 使用前，先调用Add方法，添加需要验证的控件、最小长度、最大长度；
	/// 亦可先调用Add方法，批量添加需要验证的控件，再调用Configure方法，统一配置最小长度、最大长度；
	/// 最后调用With方法，添加错误提供器；
	/// </summary>
	public partial class LengthValidator : BaseValidator<int>
	{
		/// <summary>
		/// 匹配操作；
		/// </summary>
		private Func<ValidatingUnit<int>, bool> Match
		=>	v => v.ControlText.Length >= v["MinLength"]
				  && v.ControlText.Length <= v["MaxLength"];
		/// <summary>
		/// 配置验证规则；
		/// </summary>
		/// <param name="validatingUnit">验证单元</param>
		/// <param name="minLength">最小长度</param>
		/// <param name="maxLength">最大长度</param>
		/// <returns>验证单元</returns>
		private ValidatingUnit<int> ConfigSpecification(ValidatingUnit<int> validatingUnit, int minLength, int maxLength)
		{
			validatingUnit.Match = this.Match;
			validatingUnit.AddSpecification("MinLength", minLength);
			validatingUnit.AddSpecification("MaxLength", maxLength);
			validatingUnit.ErrorMessage = $"长度应为{minLength}{(minLength == maxLength ? "" : $"-{maxLength}")}";
			return validatingUnit;
		}
		/// <summary>
		/// 添加（需要验证的控件）；
		/// 同时指定最小长度、最大长度;
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="minLength">最小长度</param>
		/// <param name="maxLength">最大长度</param>
		/// <returns>长度验证器</returns>
		public LengthValidator Add(Control control, int minLength, int maxLength)
		{
			ValidatingUnit<int> validatingUnit = new ValidatingUnit<int>(control);
			this.ConfigSpecification(validatingUnit, minLength, maxLength);
			this.ValidatingUnits.Add(validatingUnit);
			return this;
		}
		/// <summary>
		/// 配置；
		/// </summary>
		/// <param name="minLength">最小长度</param>
		/// <param name="maxLength">最大长度</param>
		/// <returns>验证器</returns>
		public BaseValidator<int> Configure(int minLength, int maxLength)
		{
			foreach (var validatingUnit in this.ValidatingUnits)
			{
				this.ConfigSpecification(validatingUnit, minLength, maxLength);
			}
			return this;
		}
		#region 组件设计器生成的代码
		public LengthValidator()
		{
			InitializeComponent();

		}

		public LengthValidator(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
		#endregion
	}
}
