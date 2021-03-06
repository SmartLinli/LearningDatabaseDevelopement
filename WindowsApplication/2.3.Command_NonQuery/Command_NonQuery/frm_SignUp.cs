﻿using System;
using System.Data;
using System.Data.SqlClient;                                                                            //包含访问SQL Server所需的各类对象；
using System.Windows.Forms;

namespace Command_NonQuery
{
    public partial class frm_SignUp : Form
    {
        /// <summary>
        /// 公有方法：构造函数；
        /// </summary>
        public frm_SignUp()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                                        //本窗体启动位置设为屏幕中央； 
        }
        /// <summary>
        /// 私有方法：单击注册按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SignUp_Click(object sender, EventArgs e) 
        {
            if (this.txb_UserNo.Text.Trim() == "")                                                      //若用户号文本框为空；
            {
                MessageBox.Show("用户号不能为空！");														//给出错误提示；
                this.txb_UserNo.Focus();                                                                //用户号文本框获得焦点；
                return;                                                                                 //返回；
            }
            if (this.txb_Password.Text.Trim() == "")                                                    //若密码文本框为空；
            {
                MessageBox.Show("密码不能为空！");														//给出错误提示；
                this.txb_Password.Focus();                                                              //密码文本框获得焦点；
                return;                                                                                 //返回；
            }
            SqlConnection sqlConnection = new SqlConnection();                                          //声明并实例化SQL连接；
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                         //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
            SqlCommand sqlCommand = sqlConnection.CreateCommand();                                      //调用SQL连接的方法CreateCommand来创建SQL命令；该命令将绑定SQL连接；
            sqlCommand.CommandText =
                "INSERT tb_User (No,Password) VALUES(@No,HASHBYTES('MD5',@Password));";                 //指定SQL命令的命令文本；命令文本包含参数；
            sqlCommand.Parameters.AddWithValue("@No", this.txb_UserNo.Text.Trim());                     //向SQL命令的参数集合添加参数的名称、值；
            sqlCommand.Parameters.AddWithValue("@Password", this.txb_Password.Text.Trim());
            sqlCommand.Parameters["@Password"].SqlDbType = SqlDbType.VarChar;                           //将密码参数的类型设为变长字符串；
                                                                                                        //SQL参数自动识别类型；若参数值为字符串，则类型自动设为NVARCHAR，且可在执行时自动转换；但对于相同密码，VARCHAR/NVARCHAR类型所获得的散列值不同，故需手动将SQL参数类型统一设为VARCHAR;
            sqlConnection.Open();                                                                       //打开SQL连接；
            int rowAffected = sqlCommand.ExecuteNonQuery();                                             //调用SQL命令的方法ExecuteNonQuery来执行命令，向数据库写入数据，并返回受影响行数；
            sqlConnection.Close();                                                                      //关闭SQL连接；
            if (rowAffected == 1)                                                                       //若成功写入1行记录；
            {
                MessageBox.Show("注册成功。");															//给出正确提示；
            }
            else                                                                                        //否则；
            {
                MessageBox.Show("注册失败！");															//给出错误提示；
            }
        }
    }
}
