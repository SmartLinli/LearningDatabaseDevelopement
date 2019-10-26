using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 确认验证扩展；
	/// </summary>
	public static class ConfirmValidatingExtension
	{
		/// <summary>
		/// 确认是否与另一控件的内容一致；
		/// </summary>
		/// <param name="confirmControl">需要验证的控件</param>
		/// <param name="referenceControl">需要参照的控件</param>
		/// <returns>控件</returns>
		public static Control Confirm(this Control confirmControl, Control referenceControl)
		{
			ValidatingUnit validatingUnit = new ValidatingUnit(confirmControl);
			validatingUnit.Match = s => s == referenceControl.Text.Trim();
			validatingUnit.ErrorMessage = "两次输入不一致";
			return confirmControl;
		}
	}
}
