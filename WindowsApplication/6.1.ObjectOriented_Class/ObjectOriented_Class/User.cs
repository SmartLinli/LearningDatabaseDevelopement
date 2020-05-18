using System.Configuration;                                                                            
using System.Data;                                                                                     
using System.Data.SqlClient;                                                                           

namespace ObjectOriented_Class
{
	/// <summary>
	/// 用户；
	/// </summary>
	public class User
    {
        /// <summary>
        /// 用户号；
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 密码；
        /// </summary>
        public string Password { private get; set; }
        /// <summary>
        /// 消息；
        /// （用于返回验证结果）
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// 登录；
        /// </summary>
        /// <returns>是否完成登录</returns>
        public bool LogIn()
        {
            SqlConnection sqlConnection = new SqlConnection();                                          
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["Sql"].ToString();                               
            SqlCommand sqlCommand = sqlConnection.CreateCommand();                                      
            sqlCommand.CommandText = "usp_selectUserCount";                                             
            sqlCommand.CommandType = CommandType.StoredProcedure;                                       
            sqlCommand.Parameters.AddWithValue("@No", this.No);                                         
            sqlCommand.Parameters.AddWithValue("@Password", this.Password);
            sqlConnection.Open();                                                                       
            int rowCount = (int)sqlCommand.ExecuteScalar();                                             
            sqlConnection.Close();                                                                      
            bool hasLoggedIn = false;                                                                   
            if (rowCount == 1)                                                                          
            {
                hasLoggedIn = true;                                                                     
                this.Message = "登录成功。";																
            }
            else                                                                                        
            {
                hasLoggedIn = false;                                                                    
                this.Message = "用户号/密码有误，请重新输入！";												
            }
            return hasLoggedIn;                                                                         
        }
    }
}
