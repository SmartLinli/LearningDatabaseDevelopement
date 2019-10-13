using SmartLinli.DatabaseDevelopement;
using System;
using System.Windows.Forms;

namespace Command_Query
{
	/// <summary>
	/// 注册窗体；
	/// </summary>
	public partial class frm_SignUp : Form
    {
        /// <summary>
        /// 公有方法：构造函数；
        /// </summary>
        public frm_SignUp()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                                       
        }
        /// <summary>
        /// 私有方法：单击注册按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SignUp_Click(object sender, EventArgs e) 
        {
			#region 验证输入
			if (this.txb_UserNo.Text.Trim() == "")
			{
				MessageBox.Show("用户号不能为空！");
				this.txb_UserNo.Focus();
				return;
			}
			if (this.txb_Password.Text.Trim() == "")
			{
				MessageBox.Show("密码不能为空！");
				this.txb_Password.Focus();
				return;
			}
			#endregion
			string commandText =
				$"INSERT tb_User(No,Password)"
				+ $" VALUES"
				+ $" ('{this.txb_UserNo.Text.Trim()}','{this.txb_Password.Text.Trim()}');";
			SqlHelper sqlHelper = new SqlHelper();
			int rowAffected = sqlHelper.QuickSubmit(commandText);
			if (rowAffected == 1)
			{
				MessageBox.Show("注册成功。");
			}
			else
			{
				MessageBox.Show("注册失败！");
			}
		}
    }
}
