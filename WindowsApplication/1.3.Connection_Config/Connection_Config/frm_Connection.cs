using System;
using System.Configuration;                                                                                                     //包含访问配置文件所需的配置管理器；需事先在本项目的“引用”中添加对System.Configuration的引用；
using System.Data.SqlClient;                                                                                                    //包含访问SQL Server所需的各类对象；
using System.Windows.Forms;

namespace Connection_Config
{
	public partial class frm_Connection : Form
    {        
        /// <summary>
        /// 公有方法：窗体构造函数；
        /// </summary>
        public frm_Connection()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                                                                //本窗体启动位置设为屏幕中央；
            if (ConfigurationManager.ConnectionStrings["Sql"] != null)                                                          //若配置管理器从配置文件读取到指定的连接字符串；
            {
                SqlConnectionStringBuilder sqlConnectionStringBuilder =  new SqlConnectionStringBuilder();                      //声明并实例化SQL连接字符串构造器；
                sqlConnectionStringBuilder.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;   //借助配置管理器从配置文件读取完整的连接字符串，并赋予SQL连接字符串构造器的相应属性；
                this.txb_Server.Text = sqlConnectionStringBuilder.DataSource;                                                   //从SQL连接字符串构造器各属性中，获取连接字符串的各个元素，并显示于相应控件上；
                this.txb_Database.Text = sqlConnectionStringBuilder.InitialCatalog;
                this.ckb_IsWindowsAuthentication.Checked = sqlConnectionStringBuilder.IntegratedSecurity;
            }
        }
        /// <summary>
        /// 私有方法：单击连接按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                                                  //声明并实例化SQL连接；
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;                                                 //配置管理器从配置文件读取连接字符串，并将之赋予SQL连接的连接字符串属性；
            sqlConnection.Open();                                                                                               //打开SQL连接；
            MessageBox.Show                                                                                                     //在消息框中显示；
                ($"连接状态：{sqlConnection.State.ToString()}" +                                                                 //消息框消息内容；
                 $"\n工作站标识：{sqlConnection.WorkstationId}" +
                 $"\n服务器地址：{sqlConnection.DataSource}" +
                 $"\n服务器版本：{sqlConnection.ServerVersion}" +
                 $"\n数据库名称：{sqlConnection.Database}" +
                 $"\n\n（单击【确定】后将关闭SQL连接）");
			sqlConnection.Close();                                                                                              //关闭SQL连接；
        }
    }
}
