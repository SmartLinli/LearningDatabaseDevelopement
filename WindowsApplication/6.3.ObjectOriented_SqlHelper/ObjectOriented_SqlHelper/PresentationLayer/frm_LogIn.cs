using System;
using System.Windows.Forms;

namespace ObjectOriented_SqlHelper
{
	public partial class frm_LogIn : Form
	{
		/// <summary>
		/// 用户；
		/// </summary>
		private User _User;
		/// <summary>
		/// 用户（业务逻辑层）；
		/// </summary>
		private IUserBll _UserBll;
		/// <summary>
		/// 构造函数；
		/// </summary>
		public frm_LogIn()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this._UserBll = new UserBll();
			this.txb_UserNo.Tag = "用户号";
			this.txb_Password.Tag = "密码";
			this.RequiredInfoValidator
				.Add(this.txb_UserNo, this.txb_Password);
			this.LengthValidator
				.Add(this.txb_UserNo)
				.Configure(this._UserBll.UserNoMinLength, this._UserBll.UserNoMaxLength);
			this.ExistValidator
				.Add(this.txb_UserNo)
				.Configure((Func<string, bool>)this._UserBll.CheckExist)
				.Configure(ExistValidatorReturnsError.IfNotExist);
			this.ErrorProvider.BlinkRate = 500;
			this.AcceptButton = this.btn_LogIn;
		}
		/// <summary>
		/// 点击登录按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Login_Click(object sender, EventArgs e)
		{
			string userNo = this.txb_UserNo.Text.Trim();
			string userPassword = this.txb_Password.Text.Trim();
			this._User = this._UserBll.LogIn(userNo, userPassword);
			MessageBox.Show(this._UserBll.Message);
			if (!this._UserBll.HasLoggedIn)
			{
				this.txb_Password.Focus();
				this.txb_Password.SelectAll();
				return;
			}
			MessageBox.Show($"即将打开{this._User.No}的主界面。");
		}
		/// <summary>
		/// 点击注册按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_SignUp_Click(object sender, EventArgs e)
		{
			frm_SignUp signUpForm = new frm_SignUp();
			signUpForm.ShowDialog(this);
		}
	}
}
