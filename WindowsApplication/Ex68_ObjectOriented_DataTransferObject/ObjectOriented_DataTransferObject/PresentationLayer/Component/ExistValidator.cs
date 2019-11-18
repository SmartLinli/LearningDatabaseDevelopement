using System;
using System.ComponentModel;

namespace ObjectOriented_DataTransferObject
{
	/// <summary>
	/// 存在验证器；
	/// </summary>
	public partial class ExistValidator : BaseValidator
	{
		/// <summary>
		/// 存在为有效；
		/// </summary>
		private bool ExistIsValid = true;
		/// <summary>
		/// 错误消息；
		/// </summary>
		protected override string ErrorMessage => this.ExistIsValid ? "不存在" : "已存在";
		/// <summary>
		/// 定义；
		/// </summary>
		/// <param name="parameters">参数</param>
		/// <returns>验证器</returns>
		public override BaseValidator Configure(params object[] parameters)
		{
			if (parameters[0] is Func<string, bool> match)
			{
				this.Match = match;
			}
			if (parameters[0] is bool ExistIsValid)
			{
				this.ExistIsValid = ExistIsValid;
			}
			return this;
		}
		#region 组件设计器生成的代码
		public ExistValidator()
		{
			InitializeComponent();
		}

		public ExistValidator(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
		#endregion
	}
}
