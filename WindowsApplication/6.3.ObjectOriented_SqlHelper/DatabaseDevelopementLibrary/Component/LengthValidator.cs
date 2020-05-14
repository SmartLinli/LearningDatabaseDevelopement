using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 长度验证器；
	/// </summary>
	public partial class LengthValidator : BaseValidator
	{
		/// <summary>
		/// 最小长度；
		/// </summary>
		private int MinLength { get; set; }
		/// <summary>
		/// 最大长度；
		/// </summary>
		private int MaxLength { get; set; }
		/// <summary>
		/// 匹配条件；
		/// </summary>
		protected override Func<string, bool> Match
		=>	s => s.Length >= this.MinLength && s.Length <= this.MaxLength;
		/// <summary>
		/// 错误消息；
		/// </summary>
		protected override string ErrorMessage
		=>	$"长度应为{this.MinLength}{(this.MinLength == this.MaxLength ? "" : $"-{this.MaxLength}")}";
		/// <summary>
		/// 用于控件；
		/// </summary>
		/// <param name="controls">控件</param>
		/// <returns>长度验证器</returns>
		public LengthValidator For(params Control[] controls)
		{
			this.Add(controls);
			return this;
		}
		/// <summary>
		/// 长度介于；
		/// </summary>
		/// <param name="minLength">最小长度</param>
		/// <param name="maxLength">最大长度</param>
		/// <returns>长度验证器</returns>
		public LengthValidator Between(int minLength, int maxLength)
		{
			this.MinLength = minLength;
			this.MaxLength = maxLength;
			return this;
		}
		/// <summary>
		/// 构造函数；
		/// </summary>
		public LengthValidator() : base()
		{

		}
	}
}
