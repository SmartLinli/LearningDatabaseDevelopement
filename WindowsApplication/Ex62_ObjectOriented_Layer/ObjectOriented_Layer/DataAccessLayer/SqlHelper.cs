using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
                                                                                                            //添加调用：
using System.Data;                                                                                          //包含Ado.Net的各类数据对象；
using System.Data.SqlClient;                                                                                //包含访问SQL Server所需的各类对象；
using System.Configuration;                                                                                 //包含访问配置文件所需的配置管理器；需事先在本项目的“引用”中添加对System.Configuration的引用；

namespace Ex27_Layer
{
    
    /// <summary>
    /// 公有静态类：Sql助手；
    /// </summary>
    public static class SqlHelper
    {

        /// <summary>
        /// 私有静态方法：获取SQL命令；
        /// （创建包含SQL连接的SQL命令）
        /// </summary>
        /// <param name="commandText1">命令文本</param>
        /// <param name="isStoredProcedure1">是否存储过程</param>
        /// <param name="sqlParameters1">SQL参数数组</param>
        /// <returns>SQL命令</returns>
        private static SqlCommand GetCommand(string commandText1, bool isStoredProcedure1, SqlParameter[] sqlParameters1)
        {
            SqlConnection sqlConnection1 = new SqlConnection();                                             //声明并实例化SQL连接；
            sqlConnection1.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ToString();     //配置管理器从App.config读取连接字符串；
            SqlCommand sqlCommand1 = sqlConnection1.CreateCommand();                                        //借助SQL连接的方法CreateCommand来创建SQL命令；该SQL命令将绑定SQL连接；
            sqlCommand1.CommandText = commandText1;                                                         //指定SQL命令的命令文本；
            if (isStoredProcedure1)                                                                         //若要求执行存储过程；
            {
                sqlCommand1.CommandType = CommandType.StoredProcedure;                                      //SQL命令的类型设为存储过程；
            }
            if (sqlParameters1 != null)                                                                     //若SQL参数数组非空；
            {
                sqlCommand1.Parameters.AddRange(sqlParameters1);                                            //将SQL参数数组内的所有SQL参数，批量添加至SQL命令的参数集合；
            }
            return sqlCommand1;                                                                             //返回SQL命令；
        }

        /// <summary>
        /// 公有静态方法：查询标量；
        /// （查询单值）
        /// </summary>
        /// <param name="commandText1">命令文本</param>
        /// <param name="isStoredProcedure1">是否存储过程</param>
        /// <param name="sqlParameters1">SQL参数数组</param>
        /// <returns>查询结果</returns>
        public static object Scalar(string commandText1,bool isStoredProcedure1, SqlParameter[] sqlParameters1)
        {
            object result1 = null;                                                                          //查询结果可能类型多样，故先声明对象，并指向空值；
            using (SqlCommand sqlCommand1 = GetCommand(commandText1, isStoredProcedure1, sqlParameters1))   //借助SQL助手的静态方法GetCommand来创建SQL命令，并定义其作用范围；
            {
                sqlCommand1.Connection.Open();                                                              //打开SQL命令的连接；
                result1 = sqlCommand1.ExecuteScalar();                                                      //借助SQL命令的方法ExecuteScalar来执行命令，并返回单个结果（即标量）；
                sqlCommand1.Connection.Close();                                                             //关闭SQL连接；
            }
            return result1;                                                                                 //返回查询结果；
        }

        /// <summary>
        /// 公有静态方法：写入；
        /// （插入、更新、删除）
        /// </summary>
        /// <param name="commandText1">命令文本</param>
        /// <param name="isStoredProcedure1">是否存储过程</param>
        /// <param name="sqlParameters1">SQL参数数组</param>
        /// <returns>受影响行数</returns>
        public static int NonQuery(string commandText1, bool isStoredProcedure1, SqlParameter[] sqlParameters1)
        {
            int rowAffected1 = 0;                                                                           //声明整型变量，用于保存受影响行数；
            using (SqlCommand sqlCommand1 = GetCommand(commandText1, isStoredProcedure1, sqlParameters1))   //借助SQL助手的静态方法GetCommand来创建SQL命令，并定义其作用范围；
            {
                sqlCommand1.Connection.Open();                                                              //打开SQL命令的连接；
                rowAffected1 = sqlCommand1.ExecuteNonQuery();                                               //借助SQL命令的方法ExecuteNonQuery来执行命令，向数据库写入数据，并返回受影响行数；
                sqlCommand1.Connection.Close();                                                             //关闭SQL连接；
            }
            return rowAffected1;                                                                            //返回受影响行数；
        }
    }
}
