using System;
using System.Data;
using System.Data.SqlClient;                                                                            //包含访问SQL Server所需的各类对象；
using System.Windows.Forms;

namespace Command_ParameterDirection
{
    public partial class frm_Login : Form
    {
        /// <summary>
        /// 公有方法：构造函数；
        /// </summary>
        public frm_Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                                        //本窗体启动位置设为屏幕中央； 
        }
        /// <summary>
        /// 私有方法：单击登录按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                          //声明并实例化SQL连接；
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                         //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
            SqlCommand sqlCommand = sqlConnection.CreateCommand();                                      //调用SQL连接的方法CreateCommand来创建SQL命令；该命令将绑定SQL连接；
            sqlCommand.CommandText = "usp_selectUserCount";                                             //指定SQL命令的命令文本；命令文本为存储过程名称； 
            sqlCommand.CommandType = CommandType.StoredProcedure;                                       //SQL命令的类型设为存储过程；
            sqlCommand.Parameters.AddWithValue("@No", this.txb_UserNo.Text.Trim());                     //调用方法AddWithValue向SQL命令的参数集合添加参数的名称、值；
            sqlCommand.Parameters.AddWithValue("@Password", this.txb_Password.Text.Trim());           
            sqlCommand.Parameters.Add("@RowCount", SqlDbType.TinyInt);                                  //调用方法Add向SQL命令的参数集合添加参数的名称、SQL Server数据类型；
            sqlCommand.Parameters.Add("@LastLogInAddress", SqlDbType.VarChar,20);                      
            sqlCommand.Parameters["@RowCount"].Direction = ParameterDirection.Output;                   //设置SQL参数方向为输出；
            sqlCommand.Parameters["@LastLogInAddress"].Direction = ParameterDirection.Output;
            sqlConnection.Open();                                                                       //打开SQL连接；
            sqlCommand.ExecuteNonQuery();                                                               //调用SQL命令的方法ExecuteNonQuery来执行命令，向数据库写入数据；
            sqlConnection.Close();                                                                      //关闭SQL连接；
            int rowCount = (byte)sqlCommand.Parameters["@RowCount"].Value;                              //声明整型变量，用于保存与所输用户号相应的行计数，并从相应的输出参数值中获得行计数；存储过程中该参数类型为TINYINT，需转换为相应的byte类型；
            string LastLogInAddress = sqlCommand.Parameters["@LastLogInAddress"].Value.ToString();      //声明整型变量，用于保存上次登录时间，并从相应的输出参数值中获得上次登录时间；
            if (rowCount == 1)                                                                          //若查得所输用户号相应的1行记录；
            {
                MessageBox.Show($"登录成功。\n您上次登录地址是{LastLogInAddress}。");						//给出正确提示；
            }
            else                                                                                        //否则；
            {
                MessageBox.Show("用户号/密码有误，请重新输入！");											//给出错误提示；
                this.txb_Password.Focus();                                                              //密码文本框获得焦点；
                this.txb_Password.SelectAll();                                                          //密码文本框内所有文本被选中；
            }
        }
    }
}
