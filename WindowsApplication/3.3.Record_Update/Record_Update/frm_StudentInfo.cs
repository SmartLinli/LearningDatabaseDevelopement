using System;
using System.Configuration;                                                                                 
using System.Data;
using System.Data.SqlClient;                                                                                
using System.Windows.Forms;

namespace Record_Update
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
            this.cmb_Class.DropDownStyle = ComboBoxStyle.DropDownList;                                      
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
                ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;                            
            SqlCommand sqlCommand = new SqlCommand();                                                      
            SqlCommand sqlCommand2 = new SqlCommand();                                                     
            sqlCommand.Connection = sqlConnection;                                                         
            sqlCommand2.Connection = sqlConnection;                                                        
            sqlCommand.CommandText = "SELECT * FROM tb_Class;";                                            
            sqlCommand2.CommandText = "SELECT * FROM tb_Student WHERE No=@No;";                            
            sqlCommand2.Parameters.AddWithValue("@No", "3200707001");                                      
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                          
            sqlDataAdapter.SelectCommand = sqlCommand;                                                     
            DataTable classTable = new DataTable();                                                        
            sqlConnection.Open();                                                                          
            sqlDataAdapter.Fill(classTable);                                                               
            this.cmb_Class.DataSource = classTable;                                                        
            this.cmb_Class.DisplayMember = "Name";                                                         
            this.cmb_Class.ValueMember = "No";                                                             
            SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();                                     
            if (sqlDataReader.Read())                                                                      
            {
                this.txb_No.Text = sqlDataReader["No"].ToString();                                         
                this.txb_Name.Text = sqlDataReader["Name"].ToString();
                this.rdb_Male.Checked = (bool)sqlDataReader["Gender"];
                this.rdb_Female.Checked = !(bool)sqlDataReader["Gender"];
                this.dtp_BirthDate.Value = (DateTime)sqlDataReader["BirthDate"];
                this.cmb_Class.SelectedValue = (int)sqlDataReader["ClassNo"];
                this.txb_Speciality.Text = sqlDataReader["Speciality"].ToString();
            }
            sqlDataReader.Close();                                                                         
        }
        /// <summary>
        /// 点击更新按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                             
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;                            
            SqlCommand sqlCommand = new SqlCommand();                                                      
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                "UPDATE tb_Student" +
                 " SET Name=@Name,Gender=@Gender,BirthDate=@BirthDate,ClassNo=@ClassNo,Speciality=@Speciality" +
                 " WHERE No=@No;";
            sqlCommand.Parameters.AddWithValue("@Name", this.txb_Name.Text.Trim());                       
            sqlCommand.Parameters.AddWithValue("@Gender", this.rdb_Male.Checked);
            sqlCommand.Parameters.AddWithValue("@BirthDate", this.dtp_BirthDate.Value);
            sqlCommand.Parameters.AddWithValue("@ClassNo", (int)this.cmb_Class.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@Speciality", this.txb_Speciality.Text.Trim());     
            sqlCommand.Parameters.AddWithValue("@No", "3200707001");                                      
            sqlConnection.Open();                                                                         
            int rowAffected = sqlCommand.ExecuteNonQuery();                                               
            sqlConnection.Close();
			MessageBox.Show($"更新{rowAffected}行。");                                    
        }
    }                                                                                                    
}
