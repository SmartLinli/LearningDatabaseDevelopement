using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 描述扩展；
	/// </summary>
	public static class DescriptionExtension
	{
		/// <summary>
		/// 控件相应信息的描述；
		/// </summary>
		/// <param name="control">需要验证的控件</param>
		/// <param name="description">描述</param>
		/// <returns>控件</returns>
		public static Control Descrption(this Control control, string description)
		{
			control.AccessibleDescription = description;
			return control;
		}
	}
}
