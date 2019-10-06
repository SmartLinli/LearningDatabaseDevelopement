using SmartLinli.DatabaseDevelopement;
using System;
using System.Windows.Forms;

namespace Command
{
	public partial class frm_LogIn : Form
    {        
        /// <summary>
        /// 构造函数；
        /// </summary>
        public frm_LogIn()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
		}
		/// <summary>
		/// 单击登录按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_LogIn_Click(object sender, EventArgs e)
        {
			string commandText =
				$"SELECT COUNT(1) FROM tb_User"
				+ $" WHERE No='{this.txb_UserNo.Text.Trim()}'"
				+ $" AND Password='{this.txb_Password.Text.Trim()}';";
			SqlHelper sqlHelper = new SqlHelper();
			int rowCount = sqlHelper
				.NewCommand(commandText)
				.Return<int>();
            if (rowCount == 1)                                                             
            {
                MessageBox.Show("登录成功。");												
            }
            else                                                                           
            {
                MessageBox.Show("用户号/密码有误，请重新输入！");								
                this.txb_Password.Focus();                                                 
                this.txb_Password.SelectAll();                                             
            }
        }
	}
}
