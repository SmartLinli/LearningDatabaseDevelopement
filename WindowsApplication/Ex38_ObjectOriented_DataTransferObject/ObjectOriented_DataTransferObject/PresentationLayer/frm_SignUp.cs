using System;
using System.Windows.Forms;

namespace ObjectOriented_DataTransferObject
{
	public partial class frm_SignUp : Form
	{
		/// <summary>
		/// 用户；
		/// </summary>
		private UserDto _User;
		/// <summary>
		/// 用户（业务逻辑层）；
		/// </summary>
		private UserBll _UserBll;
		/// <summary>
		/// 构造函数；
		/// </summary>
		public frm_SignUp()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this._UserBll = new UserBll();
			this.txb_UserNo.Tag = "用户号";
			this.txb_Password.Tag = "密码";
			this.RequiredInfoValidator
				.Add(this.txb_UserNo, this.txb_Password)
				.Add(this.ErrorProvider);
			this.LengthValidator
				.Add(this.txb_UserNo)
				.Add(this.ErrorProvider)
				.Configure(UserBll.UserNoMinLengh, UserBll.UserNoMaxLengh);
			this.ExistsValidator
				.Add(this.txb_UserNo)
				.Add(this.ErrorProvider)
				.Configure((Func<string, bool>)this._UserBll.CheckNotExists)
				.Configure(false);
			this.ErrorProvider.BlinkRate = 500;
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
			this._User = this._UserBll.SignUp(userNo, userPassword);
			MessageBox.Show(this._User.Message);
		}
	}
}
