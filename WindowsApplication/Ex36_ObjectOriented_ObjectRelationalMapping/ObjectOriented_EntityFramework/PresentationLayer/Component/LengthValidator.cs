using System;
using System.ComponentModel;

namespace ObjectOriented_EntityFramework
{
	/// <summary>
	/// 长度验证器；
	/// </summary>
	public partial class LengthValidator : BaseValidator
	{
		/// <summary>
		/// 最小长度；
		/// </summary>
		private int MinLength = 1;
		/// <summary>
		/// 最大长度；
		/// </summary>
		private int MaxLength = 100;
		/// <summary>
		/// 匹配条件；
		/// </summary>
		protected override Func<string, bool> Match =>
			(s => s.Length >= this.MinLength && s.Length <= this.MaxLength);
		/// <summary>
		/// 错误消息；
		/// </summary>
		protected override string ErrorMessage =>
			$"长度应为{this.MinLength}{(this.MinLength == this.MaxLength ? "" : $"-{this.MaxLength}")}";
		/// <summary>
		/// 定义；
		/// </summary>
		/// <param name="parameters">最小值、最大值</param>
		/// <returns>验证器</returns>
		public override BaseValidator Configure(params object[] parameters)
		{
			this.MinLength = (int)parameters[0];
			this.MaxLength = (int)parameters[1];
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
