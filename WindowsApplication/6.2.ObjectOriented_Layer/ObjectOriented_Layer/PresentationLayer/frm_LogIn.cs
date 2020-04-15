using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace ObjectOriented_Layer
{
	/// <summary>
	/// 登录窗体；
	/// </summary>
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
			this.txb_UserNo.Validating += this.ValidateUserNo;
			this.txb_Password.Validating += this.ValidatePassword;
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
		/// <summary>
		/// 验证用户号；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ValidateUserNo(object sender, CancelEventArgs e)
		{
			string userNo = this.txb_UserNo.Text;
			bool isEmpty = string.IsNullOrEmpty(userNo);
			if (isEmpty)
			{
				this.ErrorProvider.SetError(this.txb_UserNo, "用户号不能为空");
				return;
			}
			bool isLengthValid =
				userNo.Length >= this._UserBll.UserNoMinLength
				&& userNo.Length <= this._UserBll.UserNoMaxLength;
			if (!isLengthValid)
			{
				this.ErrorProvider.SetError
					(this.txb_UserNo,
					$"用户号长度应为{this._UserBll.UserNoMinLength}~{this._UserBll.UserNoMaxLength}");
				return;
			}
			bool isExisting = this._UserBll.CheckExist(userNo);
			if (!isExisting)
			{
				this.ErrorProvider.SetError(this.txb_UserNo, "用户号不存在");
				return;
			}
			this.ErrorProvider.SetError(this.txb_UserNo, "");
		}
		/// <summary>
		/// 验证密码；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ValidatePassword(object sender, CancelEventArgs e)
		{
			string password = this.txb_Password.Text;
			bool isEmpty = string.IsNullOrEmpty(password);
			if (isEmpty)
			{
				this.ErrorProvider.SetError(this.txb_Password, "密码不能为空");
				return;
			}
			this.ErrorProvider.SetError(this.txb_Password, "");
		}
	}
}
