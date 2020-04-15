using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ObjectOriented_Layer
{
	/// <summary>
	/// 用户（数据访问层）；
	/// </summary>
	public class UserDal : IUserDal
	{
		/// <summary>
		/// 查询用户计数;
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>计数</returns>
		public int SelectCount(string userNo)
		{
			SqlConnection sqlConnection = new SqlConnection();                                  
			sqlConnection.ConnectionString =
				ConfigurationManager.ConnectionStrings["Sql"].ToString();                       
			SqlCommand sqlCommand1 = sqlConnection.CreateCommand();                             
			sqlCommand1.CommandText = "usp_selectUserCount";                                
			sqlCommand1.CommandType = CommandType.StoredProcedure;                        
			sqlCommand1.Parameters.AddWithValue("@No", userNo);                           
			sqlConnection.Open();                                                         
			int count = (int)sqlCommand1.ExecuteScalar();                                 
			sqlConnection.Close();                                                        
			return count;                                                                 
		}
		/// <summary>
		/// 查询用户；
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>用户</returns>
		public User Select(string userNo)
		{
			SqlConnection sqlConnection = new SqlConnection();                           
			sqlConnection.ConnectionString =
				ConfigurationManager.ConnectionStrings["Sql"].ToString();                
			SqlCommand sqlCommand = sqlConnection.CreateCommand();                       
			sqlCommand.CommandText = "usp_selectUser";                               
			sqlCommand.CommandType = CommandType.StoredProcedure;                        
			sqlCommand.Parameters.AddWithValue("@No", userNo);                           
			sqlConnection.Open();                                                        
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();                    
			User user = null;
			if (sqlDataReader.Read())
			{
				user = new User()
				{
					No = userNo,
					Password = (byte[])sqlDataReader["Password"],
					IsActivated = (bool)sqlDataReader["IsActivated"],
					LoginFailCount = (int)sqlDataReader["LoginFailCount"]
				};
			}
			sqlDataReader.Close();                                                       
			return user;                                                                 
		}
		/// <summary>
		/// 更新用户；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>受影响行数</returns>
		public int Update(User user)
		{
			SqlConnection sqlConnection = new SqlConnection();                         
			sqlConnection.ConnectionString =
				ConfigurationManager.ConnectionStrings["Sql"].ToString();              
			SqlCommand sqlCommand = sqlConnection.CreateCommand();                     
			sqlCommand.CommandText = "usp_updateUser";                                 
			sqlCommand.CommandType = CommandType.StoredProcedure;                      
			sqlCommand.Parameters.AddWithValue("@No", user.No);                        
			sqlCommand.Parameters.AddWithValue("@Password", user.Password);
			sqlCommand.Parameters.AddWithValue("@IsActivated", user.IsActivated);
			sqlCommand.Parameters.AddWithValue("@LoginFailCount", user.LoginFailCount);
			sqlConnection.Open();                                                            
			int rowAffected = sqlCommand.ExecuteNonQuery();                                  
			sqlConnection.Close();                                                           
			return rowAffected;                                                              
		}
		/// <summary>
		/// 插入用户；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>受影响行数</returns>
		public int Insert(User user)
		{
			SqlConnection sqlConnection = new SqlConnection();                               
			sqlConnection.ConnectionString =
				ConfigurationManager.ConnectionStrings["Sql"].ToString();                    
			SqlCommand sqlCommand = sqlConnection.CreateCommand();                           
			sqlCommand.CommandText = "usp_insertUser";                                       
			sqlCommand.CommandType = CommandType.StoredProcedure;                            
			sqlCommand.Parameters.AddWithValue("@No", user.No);                              
			sqlCommand.Parameters.AddWithValue("@Password", user.Password);
			sqlCommand.Parameters.AddWithValue("@IsActivated", user.IsActivated);
			int rowAffected = 0;                                                             
			try                                                                              
			{
				sqlConnection.Open();                                                        
				rowAffected = sqlCommand.ExecuteNonQuery();                                  
			}
			catch (SqlException sqlEx)                                                       
			{
				if (sqlEx.Number == 2627)
				{
					throw new ApplicationException("您提交的用户号已存在");
				}
				throw sqlEx;
			}
			finally
			{
				sqlConnection.Close();
			}
			return rowAffected;                                                               
		}
	}
}
