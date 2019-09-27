using System;
using System.ComponentModel;

namespace ObjectOriented_SqlHelper
{
	/// <summary>
	/// 存在验证器；
	/// </summary>
	public partial class ExistsValidator : BaseValidator
	{
		/// <summary>
		/// 匹配条件；
		/// </summary>
		private bool ExistsIsValid = true;
		/// <summary>
		/// 错误消息；
		/// </summary>
		protected override string ErrorMessage => this.ExistsIsValid ? "不存在" : "已存在";
		/// <summary>
		/// 定义；
		/// </summary>
		/// <param name="parameters">参数</param>
		/// <returns>验证器</returns>
		public override BaseValidator Configure(params object[] parameters)
		{
			if (parameters[0] is Func<string, bool> match)
			{
				this.Match = parameters[0] as Func<string, bool>;
			}
			if (parameters[0] is bool existsIsValid)
			{
				this.ExistsIsValid = existsIsValid;
			}
			return this;
		}
		#region 组件设计器生成的代码
		public ExistsValidator()
		{
			InitializeComponent();
		}

		public ExistsValidator(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
		#endregion
	}
}
