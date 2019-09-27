using System.Configuration;                                                                             //包含访问配置文件所需的配置管理器；需事先在本项目的“引用”中添加对System.Configuration的引用；
using System.Data;                                                                                      //包含各类数据对象；
using System.Data.SqlClient;                                                                            //包含访问SQL Server所需的各类对象；

namespace ObjectOriented_Class
{
	/// <summary>
	/// 公有类：用户；
	/// </summary>
	public class User
    {
        /// <summary>
        /// 公有属性：用户号；
        /// </summary>
        public string No
        {
            get;
            set;
        }
        /// <summary>
        /// 公有（只写）属性：密码；
        /// </summary>
        public string Password
        {
			private get;
			set;
        }
        /// <summary>
        /// 公有（只读）属性：消息；
        /// （用于返回验证结果）
        /// </summary>
        public string Message
        {
			get;
			private set;
        }
        /// <summary>
        /// 公有方法：登录；
        /// </summary>
        /// <returns>是否完成登录</returns>
        public bool LogIn()
        {
            SqlConnection sqlConnection = new SqlConnection();                                          //声明并实例化SQL连接；
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["Sql"].ToString();                               //配置管理器从App.config读取连接字符串；
            SqlCommand sqlCommand = sqlConnection.CreateCommand();                                      //调用SQL连接的方法CreateCommand来创建SQL命令；该命令将绑定SQL连接；
            sqlCommand.CommandText = "usp_selectUserCount";                                             //指定SQL命令的命令文本；命令文本为存储过程名称；
            sqlCommand.CommandType = CommandType.StoredProcedure;                                       //SQL命令的类型设为存储过程；
            sqlCommand.Parameters.AddWithValue("@No", this.No);                                         //向SQL命令的参数集合添加参数的名称、值；
            sqlCommand.Parameters.AddWithValue("@Password", this.Password);
            sqlConnection.Open();                                                                       //打开SQL连接；
            int rowCount = (int)sqlCommand.ExecuteScalar();                                             //调用SQL命令的方法ExecuteScalar来执行命令，并接受单个结果（即标量）；
            sqlConnection.Close();                                                                      //关闭SQL连接；
            bool hasLoggedIn = false;                                                                   //声明变量，用于保存是否完成登录；
            if (rowCount == 1)                                                                          //若查得所输用户号相应的1行记录；
            {
                hasLoggedIn = true;                                                                     //完成登录；
                this.Message = "登录成功。";																//给出正确提示；
            }
            else                                                                                        //否则；
            {
                hasLoggedIn = false;                                                                    //未完成登录；
                this.Message = "用户号/密码有误，请重新输入！";												//给出错误提示；
            }
            return hasLoggedIn;                                                                         //返回登录结果；
        }
    }
}
