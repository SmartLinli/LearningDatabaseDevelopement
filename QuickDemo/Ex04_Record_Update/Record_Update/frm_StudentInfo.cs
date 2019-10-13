using SmartLinli.DatabaseDevelopement;
using System;
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
		}
		/// <summary>
		/// 点击载入按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Load_Click(object sender, EventArgs e)
		{
			string
				studentCommand = $"SELECT * FROM tb_Student WHERE No='{this.txb_No.Text.Trim()}';"
				, classCommand = "SELECT * FROM tb_Class";
			SqlHelper sqlHelper = new SqlHelper();
			var studentReader = sqlHelper
				.NewCommand(studentCommand)
				.ReturnReader();
			var classTable = sqlHelper
				.NewCommand(classCommand)
				.ReturnTable();
			this.cmb_Class.DataSource = classTable;
			this.cmb_Class.ValueMember = "No";
			this.cmb_Class.DisplayMember = "Name";
			if (studentReader.Read())
			{
				this.txb_No.Text = studentReader["No"].ToString();
				this.txb_Name.Text = studentReader["Name"].ToString();
				this.rdb_Male.Checked = (bool)studentReader["Gender"];
				this.rdb_Female.Checked = !(bool)studentReader["Gender"];
				this.dtp_BirthDate.Value = (DateTime)studentReader["BirthDate"];
				this.cmb_Class.SelectedValue = (int)studentReader["ClassNo"];
				this.txb_Speciality.Text = studentReader["Speciality"].ToString();
			}
		}
		/// <summary>
		/// 点击更新按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Update_Click(object sender, EventArgs e)
		{
			string commandText =
				$"UPDATE tb_Student"
				+ $" SET"
				+ $" Name='{this.txb_Name.Text.Trim()}'"
				+ $" ,Gender='{this.rdb_Male.Checked}'"
				+ $" ,BirthDate='{this.dtp_BirthDate.Value}'"
				+ $" ,ClassNo={this.cmb_Class.SelectedValue}"
				+ $" ,Speciality='{this.txb_Speciality.Text.Trim()}'"
				+ $" WHERE No='{this.txb_No.Text.Trim()}';";
			SqlHelper sqlHelper = new SqlHelper();
			int rowAffected = sqlHelper
				.NewCommand(commandText)
				.Submit();
			MessageBox.Show($"更新{rowAffected}行。");
		}
	}
}
