using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Record_Control
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
            SqlCommand sqlCommand2 = new SqlCommand();                                                      
            sqlCommand.Connection = sqlConnection;                                                          
            sqlCommand2.Connection = sqlConnection;                                                         
            sqlCommand.CommandText = "SELECT * FROM tb_Class;";                                             
            sqlCommand2.CommandText = "SELECT * FROM tb_Student WHERE No=@No;";                             
            sqlCommand2.Parameters.AddWithValue("@No", "3210707001");                                       
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
    }                                                                                                    
}
