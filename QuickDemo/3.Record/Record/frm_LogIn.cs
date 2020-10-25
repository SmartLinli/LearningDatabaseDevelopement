using SmartLinli.DatabaseDevelopement;
using System;
using System.Windows.Forms;

namespace Record
{
	/// <summary>
	/// 登录窗体；
	/// </summary>
	public partial class frm_LogIn : Form
    {        
        /// <summary>
        /// 构造函数；
        /// </summary>
        public frm_LogIn()
        {
            InitializeComponent();
            this.AcceptButton = this.btn_LogIn;
            this.StartPosition = FormStartPosition.CenterScreen;
			this.FormClosed += (_, __) =>
			{
				if (Application.OpenForms.Count == 0)
				{
					Application.Exit();
				}
			};
		}
		/// <summary>
		/// 单击登录按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_LogIn_Click(object sender, EventArgs e)
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
				$@"SELECT 1 
					FROM tb_User
					WHERE No='{this.txb_UserNo.Text.Trim()}' AND Password='{this.txb_Password.Text.Trim()}';";
			SqlHelper sqlHelper = new SqlHelper();
			int result = sqlHelper.QuickReturn<int>(commandText);
            if (result == 1)                                                             
            {
                MessageBox.Show("登录成功。");
				frm_StudentInfo studentInfoForm = new frm_StudentInfo(this.txb_UserNo.Text.Trim());
				studentInfoForm.Show();
				this.Close();
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
