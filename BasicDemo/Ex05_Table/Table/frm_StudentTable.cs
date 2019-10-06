using SmartLinli.DatabaseDevelopement;
using System;
using System.Data;
using System.Windows.Forms;

namespace Table
{
	public partial class frm_StudentTable : Form
    {
        /// <summary>
        /// 构造函数；
        /// </summary>
        public frm_StudentTable()
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
			SqlHelper sqlHelper = new SqlHelper();
			var studentTable = sqlHelper
				.NewCommand("SELECT * FROM tb_Student;")
				.ReturnTable();
            this.dgv_Student.DataSource = studentTable;                                                    
        }        
        /// <summary>
        /// 点击提交按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Submit_Click(object sender, EventArgs e)
        {
			string
				insertCommand =
				"INSERT tb_Student"
				+ "(No,Name,Gender,BirthDate,Class,Speciality)"
				+ " VALUES(@No,@Name,@Gender,@BirthDate,@Class,@Speciality);"
				, updateCommand =
				"UPDATE tb_Student"
				+ " SET Name=@Name,Gender=@Gender,BirthDate=@BirthDate,Class=@Class,Speciality=@Speciality"
				+ " WHERE No=@No;"
				, deleteCommand =
				"DELETE tb_Student"
				+ " WHERE No=@No;";
			var studentTable = this.dgv_Student.DataSource as DataTable;
			SqlHelper sqlHelper=new SqlHelper();
			int rowAffected = sqlHelper
				.NewCommand(insertCommand)
				.WithParameters("@No", "@Name", "@Gender", "@BirthDate", "@Class", "@Speciality")
				.AsInsertCommand()
				.NewCommand(updateCommand)
				.WithParameters("@No", "@Name", "@Gender", "@BirthDate", "@Class", "@Speciality")
				.AsUpdateCommand()
				.NewCommand(deleteCommand)
				.WithParameter("@No")
				.AsDeleteCommand()
				.Submit(studentTable);
			MessageBox.Show($"更新{rowAffected}行。");														
        }
    }                                                                                                    
}
