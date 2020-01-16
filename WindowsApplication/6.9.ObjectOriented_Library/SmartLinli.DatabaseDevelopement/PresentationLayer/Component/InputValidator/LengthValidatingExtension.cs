using System;
using System.Linq;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 文本长度验证扩展；
	/// </summary>
	public static class LengthValidatingExtension
	{
		/// <summary>
		/// 文本长度；允许指定多个文本长度；
		/// 控件所在窗体应有错误提供器，并通过名为ErrorProvider的公有属性访问；
		/// </summary>
		/// <param name="control">需要验证的控件</param>
		/// <param name="lengths">有效的文本长度</param>
		/// <returns>控件</returns>
		public static Control Length(this Control control, params int[] lengths)
		{
			ValidatingUnit validatingUnit = new ValidatingUnit(control);
			validatingUnit.Match =
				s =>
				{
					bool isValid = false;
					foreach (var length in lengths)
					{
						isValid |= s.Length == length;
					}
					return isValid;
				};
			string validLength = String.Empty;
			lengths.ToList().ForEach(i => validLength += i.ToString() + "或");
			validatingUnit.ErrorMessage = "长度应为" + validLength.Substring(0, validLength.Length - 1) + "位";
			return control;
		}
		/// <summary>
		/// 文本长度范围；
		/// 控件所在窗体应有错误提供器，并通过名为ErrorProvider的公有属性访问；
		/// </summary>
		/// <param name="control">需要验证的控件</param>
		/// <param name="minLength">有效的最小文本长度</param>
		/// <param name="maxLength">有效的最大文本长度</param>
		/// <returns>控件</returns>
		public static Control LengthRange(this Control control, int minLength, int maxLength)
		{
			ValidatingUnit validatingUnit = new ValidatingUnit(control);
			validatingUnit.Match = s => s.Length >= minLength && s.Length <= maxLength;
			validatingUnit.ErrorMessage = $"长度应为{minLength}~{maxLength}位";
			return control;
		}
	}
}
