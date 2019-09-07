using System;
using System.Data.SqlClient;                                                                                //包含访问SQL Server所需的各类对象；
using System.Windows.Forms;

namespace Ex43_Record_Update
{
	public partial class frm_StudentInfo : Form
    {
        /// <summary>
        /// 公有方法：构造函数；
        /// </summary>
        public frm_StudentInfo()
        {
            InitializeComponent(); 
            this.StartPosition = FormStartPosition.CenterScreen;                                            //本窗体启动位置设为屏幕中央； 
        }
        /// <summary>
        /// 私有方法：点击载入按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Load_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                              //声明并实例化SQL连接；
			sqlConnection.ConnectionString =
				"Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                             //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
			SqlCommand sqlCommand = new SqlCommand();                                                       //声明并实例化SQL命令；
            sqlCommand.Connection = sqlConnection;                                                          //将SQL命令的连接属性指向SQL连接；
			sqlCommand.CommandText =                                                                        //指定SQL命令的命令文本；
				$"SELECT * FROM tb_Student WHERE No='{this.txb_No.Text.Trim()}';";
            sqlConnection.Open();                                                                           //打开SQL连接；
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();										//调用SQL命令的方法ExecuteReader来执行命令，并获取数据阅读器；
            if (sqlDataReader.Read())                                                                       //若数据阅读器成功读取到下一条记录（首次查询则表示第一条记录）；
            {
                this.txb_No.Text = sqlDataReader["No"].ToString();                                          //在数据阅读器的索引器中指定列名，从而访问当前记录的指定列的值，并赋予相应控件；
                this.txb_Name.Text = sqlDataReader["Name"].ToString();
                this.rdb_Male.Checked = sqlDataReader["Gender"].ToString()==this.rdb_Male.Text;
                this.rdb_Female.Checked = sqlDataReader["Gender"].ToString() == this.rdb_Female.Text;
                this.dtp_BirthDate.Value = (DateTime)sqlDataReader["BirthDate"];
                this.txb_Class.Text =sqlDataReader["Class"].ToString();
                this.txb_Speciality.Text = sqlDataReader["Speciality"].ToString();
            }
            sqlDataReader.Close();                                                                          //关闭数据阅读器（同时关闭连接）；
        }
        /// <summary>
        /// 私有方法：点击更新按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                              //声明并实例化SQL连接；
			sqlConnection.ConnectionString =
				"Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                             //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
			SqlCommand sqlCommand = new SqlCommand();                                                       //声明并实例化SQL命令；
            sqlCommand.Connection = sqlConnection;                                                          //将SQL命令的连接属性指向SQL连接；
			sqlCommand.CommandText =                                                                        //指定SQL命令的命令文本；
				$"UPDATE tb_Student"
				+ $" SET"
				+ $" Name='{this.txb_Name.Text.Trim()}'"
				+ $" ,Gender='{(this.rdb_Male.Checked ? this.rdb_Male.Text : this.rdb_Female.Text)}'"
				+ $" ,BirthDate='{this.dtp_BirthDate.Value.ToShortDateString()}'"
				+ $" ,Class='{this.txb_Class.Text.Trim()}'"
				+ $" ,Speciality='{this.txb_Speciality.Text.Trim()}'"
				+ $" WHERE No='{this.txb_No.Text.Trim()}';";
            sqlConnection.Open();                                                                           //打开SQL连接；
            int rowAffected = sqlCommand.ExecuteNonQuery();                                                 //调用SQL命令的方法ExecuteNonQuery来执行命令，向数据库写入数据，并返回受影响行数；
            sqlConnection.Close();                                                                          //关闭SQL连接；
			MessageBox.Show($"更新{rowAffected}行。");														//在消息框显示受影响行数；
        }
    }                                                                                                    
}
