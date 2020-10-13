using System;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 存在验证扩展；
	/// </summary>
	public static class ExistValidatingExtension
	{
		/// <summary>
		/// 检查是否存在；
		/// 控件所在窗体应有错误提供器，并通过名为ErrorProvider的公有属性访问；
		/// </summary>
		/// <param name="control">需要验证的控件</param>
		/// <param name="match">匹配条件</param>
		/// <param name="existIsValid">存在是否为有效</param>
		/// <returns>控件</returns>
		public static Control CheckExist(this Control control, Func<string, bool> match, bool existIsValid)
		{
			ValidatingUnit validatingUnit = new ValidatingUnit(control);
			validatingUnit.Match = match;
			validatingUnit.ErrorMessage = existIsValid ? "不存在" : "已存在";
			return control;
		}
	}
}
