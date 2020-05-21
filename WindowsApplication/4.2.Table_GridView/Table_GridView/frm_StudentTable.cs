using System;
using System.Data;
using System.Data.SqlClient;                                                                                
using System.Drawing;
using System.Windows.Forms;

namespace Table_GridView
{
	public partial class frm_StudentTable : Form
    {
        /// <summary>
        /// 学生表；
        /// </summary>
        private DataTable StudentTable;        
        /// <summary>
        /// 构造函数；
        /// </summary>
        public frm_StudentTable()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                                            
            this.dgv_Student.AllowUserToAddRows = false;                                                      
            this.dgv_Student.RowHeadersVisible = false;                                                       
            this.dgv_Student.BackgroundColor = Color.White;                                                   
            this.dgv_Student.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;                                                   
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
            sqlCommand.CommandText = "SELECT * FROM tb_Class;";                                             
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                           
            sqlDataAdapter.SelectCommand = sqlCommand;                                                      
            DataTable classTable = new DataTable();                                                         
            DataTable studentTable = new DataTable();                                                       
            sqlConnection.Open();                                                                           
            sqlDataAdapter.Fill(classTable);                                                                
            sqlCommand.CommandText = "SELECT * FROM tb_Student;";                                           
            sqlDataAdapter.Fill(studentTable);                                                              
            sqlConnection.Close();                                                                          
            this.StudentTable = studentTable;                                                               
            this.dgv_Student.Columns.Clear();                                                                 
            this.dgv_Student.DataSource = studentTable;                                                       
            this.dgv_Student.Columns["No"].ReadOnly = true;                                                   
            this.dgv_Student.Columns["No"].HeaderText = "学号";                                               
            this.dgv_Student.Columns["Name"].HeaderText = "姓名";
            this.dgv_Student.Columns["Gender"].HeaderText = "性别";
            this.dgv_Student.Columns["BirthDate"].HeaderText = "生日";
            this.dgv_Student.Columns["Speciality"].HeaderText = "特长";
            this.dgv_Student.Columns["Photo"].HeaderText = "照片";
            this.dgv_Student.Columns["ClassNo"].Visible = false;                                              
            DataGridViewComboBoxColumn classColumn = new DataGridViewComboBoxColumn();                      
            this.dgv_Student.Columns.Add(classColumn);                                                        
            classColumn.Name = "Class";                                                                     
            classColumn.HeaderText = "班级";                                                                
            classColumn.DataSource = classTable;                                                            
            classColumn.DisplayMember = "Name";                                                             
            classColumn.ValueMember = "No";                                                                 
            classColumn.DataPropertyName = "ClassNo";                                                       
            classColumn.DisplayIndex = 4;                                                                   
            classColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;                             
            this.dgv_Student.Columns[this.dgv_Student.Columns.Count - 2].AutoSizeMode =                         
                DataGridViewAutoSizeColumnMode.Fill;
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
                "Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                             
            SqlCommand sqlCommand = new SqlCommand();                                                       
            sqlCommand.Connection = sqlConnection;                                                          
            sqlCommand.CommandText =                                                                        
                "UPDATE tb_Student"
                + " SET Name=@Name,Gender=@Gender,BirthDate=@BirthDate,ClassNo=@ClassNo,Speciality=@Speciality"
                + " WHERE No=@No;";
            sqlCommand.Parameters.Add("@Name",SqlDbType.VarChar,0,"Name");                                  
            sqlCommand.Parameters.Add("@Gender", SqlDbType.Bit, 0, "Gender");
            sqlCommand.Parameters.Add("@BirthDate", SqlDbType.Date, 0, "BirthDate");
            sqlCommand.Parameters.Add("@ClassNo", SqlDbType.Int, 0, "ClassNo");
            sqlCommand.Parameters.Add("@Speciality", SqlDbType.VarChar, 0, "Speciality");
            sqlCommand.Parameters.Add("@No", SqlDbType.Char, 10, "No");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                           
            sqlDataAdapter.UpdateCommand = sqlCommand;                                                      
            DataTable studentTable = this.StudentTable;                                                     
            sqlConnection.Open();                                                                           
            int rowAffected = sqlDataAdapter.Update(studentTable);                                          
            sqlConnection.Close();                                                                          
			MessageBox.Show($"更新{rowAffected}行。");														
		}
    }                                                                                                    
}
