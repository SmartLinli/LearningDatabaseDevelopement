using System;
using System.Data;
using System.Data.SqlClient;                                                                                
using System.Windows.Forms;

namespace Table_Adapter
{    
    public partial class frm_StudentInfo : Form
    {
        /// <summary>
        /// 构造函数；
        /// </summary>
        public frm_StudentInfo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                                            
        }
        /// <summary>
        /// 点击载入按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Load_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                              
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                             
            SqlCommand sqlCommand = new SqlCommand();                                                       
            sqlCommand.Connection = sqlConnection;                                                          
            sqlCommand.CommandText = "SELECT * FROM tb_Student;";                                           
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                           
            sqlDataAdapter.SelectCommand = sqlCommand;                                                      
            DataTable studentTable = new DataTable();                                                       
            sqlConnection.Open();                                                                           
            sqlDataAdapter.Fill(studentTable);                                                              
            sqlConnection.Close();                                                                          
            this.dgv_Student.DataSource = studentTable;                                                     
        }        
        /// <summary>
        /// 点击提交按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                              
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                             
            SqlCommand insertCommand = new SqlCommand();                                                    
            insertCommand.Connection = sqlConnection;                                                       
            insertCommand.CommandText =                                                                     
                "INSERT tb_Student"
                + "(No,Name,Gender,BirthDate,Class,Speciality)"
                + " VALUES(@No,@Name,@Gender,@BirthDate,@Class,@Speciality);";
            insertCommand.Parameters.Add("@No", SqlDbType.Char, 10, "No");                                  
            insertCommand.Parameters.Add("@Name", SqlDbType.VarChar, 0, "Name");                            
            insertCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 0, "Gender");
            insertCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar, 0, "BirthDate");
            insertCommand.Parameters.Add("@Class", SqlDbType.VarChar, 0, "Class");
            insertCommand.Parameters.Add("@Speciality", SqlDbType.VarChar, 0, "Speciality");
            SqlCommand updateCommand = new SqlCommand();                                                    
            updateCommand.Connection = sqlConnection;                                                       
            updateCommand.CommandText =                                                                     
                "UPDATE tb_Student"
                + " SET No=@NewNo,Name=@Name,Gender=@Gender,BirthDate=@BirthDate,Class=@Class,Speciality=@Speciality"
                + " WHERE No=@OldNo;";
            updateCommand.Parameters.Add("@NewNo", SqlDbType.Char, 10, "No");                              
            updateCommand.Parameters.Add("@Name",SqlDbType.VarChar,0,"Name");                              
            updateCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 0, "Gender");
            updateCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar, 0, "BirthDate");
            updateCommand.Parameters.Add("@Class", SqlDbType.VarChar, 0, "Class");
            updateCommand.Parameters.Add("@Speciality", SqlDbType.VarChar, 0, "Speciality");
            updateCommand.Parameters.Add("@OldNo", SqlDbType.Char, 10, "No");                              
            updateCommand.Parameters["@OldNo"].SourceVersion = DataRowVersion.Original;                    
            SqlCommand deleteCommand = new SqlCommand();                                                   
            deleteCommand.Connection = sqlConnection;                                                      
            deleteCommand.CommandText =                                                                    
                "DELETE tb_Student"
                + " WHERE No=@No;";
            deleteCommand.Parameters.Add("@No", SqlDbType.Char, 10, "No");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                          
            sqlDataAdapter.InsertCommand = insertCommand;                                                  
            sqlDataAdapter.UpdateCommand = updateCommand;                                                  
            sqlDataAdapter.DeleteCommand = deleteCommand;                                                  
            DataTable studentTable = (DataTable)this.dgv_Student.DataSource;                               
            sqlConnection.Open();                                                                          
            int rowAffected = sqlDataAdapter.Update(studentTable);                                         
            sqlConnection.Close();                                                                         
            MessageBox.Show($"更新{rowAffected}行。");                                      
        }
    }                                                                                                    
}
