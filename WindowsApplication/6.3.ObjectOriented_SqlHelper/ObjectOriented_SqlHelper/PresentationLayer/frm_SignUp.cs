using SmartLinli.DatabaseDevelopement;
using System;
using System.Windows.Forms;

namespace ObjectOriented_SqlHelper
{
	public partial class frm_SignUp : Form
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
		public frm_SignUp()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this.UserBll = new UserBll();
			this.txb_UserNo
				.Descrption("用户号")
				.NotNull()
				.LengthRange(this.UserBll.UserNoMinLength, this.UserBll.UserNoMaxLength)
				.CheckExist(no => this.UserBll.CheckNotExist(no), false);
			this.txb_UserNo
				.Descrption("密码")
				.NotNull()
				.LengthRange(this.UserBll.PasswordMinLengh, this.UserBll.PasswordMaxLengh);
			this.AcceptButton = this.btn_SignUp;
		}
		/// <summary>
		/// 点击注册按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_SignUp_Click(object sender, EventArgs e)
		{
			string userNo = this.txb_UserNo.Text.Trim();
			string userPassword = this.txb_Password.Text.Trim();
			this.User = this.UserBll.SignUp(userNo, userPassword);
			MessageBox.Show(this.UserBll.Message);
			this.Close();
		}
	}
}
