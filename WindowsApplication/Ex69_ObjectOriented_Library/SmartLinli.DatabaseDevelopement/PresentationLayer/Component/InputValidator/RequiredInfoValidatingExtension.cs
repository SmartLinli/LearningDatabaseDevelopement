using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 必填信息验证扩展；
	/// </summary>
	public static class RequiredInfoValidatingExtension
	{
		/// <summary>
		/// 非空；
		/// 控件所在窗体应有错误提供器，并通过名为ErrorProvider的公有属性访问；
		/// </summary>
		/// <param name="control">需要验证的控件</param>
		/// <returns>控件</returns>
		public static Control NotNull(this Control control)
		{
			ValidatingUnit validatingUnit = new ValidatingUnit(control);
			validatingUnit.Match = s => !string.IsNullOrEmpty(s);
			validatingUnit.ErrorMessage = "不能为空";
			return control;
		}
	}
}
