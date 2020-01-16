using System;
using System.Data.SqlClient;                                                                                
using System.Windows.Forms;

namespace Record_Reader
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
            sqlCommand.CommandText = "SELECT * FROM tb_Student WHERE No=@No;";                              
            sqlCommand.Parameters.AddWithValue("@No", "3180707001");                                        
            sqlConnection.Open();                                                                           
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();                                       
            if (sqlDataReader.Read())                                                                       
            {
                this.txb_No.Text = sqlDataReader["No"].ToString();                                          
                this.txb_Name.Text = sqlDataReader["Name"].ToString();
                this.txb_Gender.Text = sqlDataReader["Gender"].ToString();
                this.txb_BirthDate.Text = ((DateTime)sqlDataReader["BirthDate"]).ToShortDateString();       
                this.txb_Class.Text = sqlDataReader["Class"].ToString();
                this.txb_Speciality.Text = sqlDataReader["Speciality"].ToString();
            }
            sqlDataReader.Close();                                                                          
        }
    }                                                                                                    
}
