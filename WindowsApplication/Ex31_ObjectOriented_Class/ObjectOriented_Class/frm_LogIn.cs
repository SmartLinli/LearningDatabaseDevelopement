using System;
using System.Windows.Forms;

namespace ObjectOriented_Class
{
	public partial class frm_LogIn : Form
    {
        /// <summary>
        /// 公有方法：构造函数；
        /// </summary>
        public frm_LogIn()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                        //本窗体启动位置设为屏幕中央；
        }
        /// <summary>
        /// 私有方法：单击登录按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            User user = new User();                                                     //声明并实例化用户对象；
            user.No = this.txb_UserNo.Text.Trim();                                      //将文本框的文本清除首尾的空格后，赋予用户的相应属性；
            user.Password = this.txb_Password.Text.Trim();
            if (!user.LogIn())                                                          //若用户未完成登录，即登录失败；
            {
                this.txb_Password.Focus();                                              //密码文本框获得焦点；
                this.txb_Password.SelectAll();                                          //密码文本框内所有文本被选中；
            }
            MessageBox.Show(user.Message);                                              //在消息框中显示登录消息；
        }
    }
}
