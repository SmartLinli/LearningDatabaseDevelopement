using System;
using System.ComponentModel;

namespace ObjectOriented_Dapper
{
	/// <summary>
	/// 必填信息验证器；
	/// </summary>
	public partial class RequiredInfoValidator : BaseValidator
	{
		/// <summary>
		/// 匹配条件；
		/// </summary>
		protected override Func<string, bool> Match 
		=>	(s => s != null && s != string.Empty);
		/// <summary>
		/// 错误消息；
		/// </summary>
		protected override string ErrorMessage => "不能为空";
		#region 组件设计器生成的代码
		public RequiredInfoValidator()
		{
			InitializeComponent();

		}

		public RequiredInfoValidator(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
		#endregion
	}
}
