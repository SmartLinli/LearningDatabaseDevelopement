using System;
using System.ComponentModel;

namespace ObjectOriented_MultiDb
{
	/// <summary>
	/// 存在验证器返回错误的条件为；
	/// </summary>
	public class ExistValidatorReturnError
	{
		/// <summary>
		/// 对象存在；
		/// </summary>
		public const bool IfExist = true;
		/// <summary>
		/// 对象不存在；
		/// </summary>
		public const bool IfNotExist = false;
	}
	/// <summary>
	/// 存在验证器；
	/// </summary>
	public partial class ExistValidator : BaseValidator
	{
		/// <summary>
		/// 存在则有误；
		/// </summary>
		private bool _HasErrorIfExist = false;
		/// <summary>
		/// 错误消息；
		/// </summary>
		protected override string ErrorMessage => this._HasErrorIfExist ? "已存在" : "不存在";
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
			if (parameters[0] is bool hasErrorIfExist)
			{
				this._HasErrorIfExist = hasErrorIfExist;
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
