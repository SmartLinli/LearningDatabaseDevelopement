using SmartLinli.DatabaseDevelopement;
using System;
using System.Windows.Forms;

namespace ObjectOriented_MultiDb
{
	public partial class frm_LogIn : Form
	{
		/// <summary>
		/// 用户；
		/// </summary>
		private User User { get; set; }
		/// <summary>
		/// 用户（业务逻辑层）；
		/// </summary>
		private IUserBll UserBll { get; set; }
		/// <summary>
		/// 构造函数；
		/// </summary>
		public frm_LogIn()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this.UserBll = new UserBll();
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
			this.User = this.UserBll.LogIn(userNo, userPassword);
			MessageBox.Show(this.UserBll.Message);
			if (!this.UserBll.HasLoggedIn)
			{
				this.txb_Password.Focus();
				this.txb_Password.SelectAll();
				return;
			}
			MessageBox.Show($"即将打开{this.User.No}的主界面。");
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
