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
				classCommand = "SELECT * FROM tb_Class"
				, studentCommand = $"SELECT * FROM tb_Student WHERE No='{this.txb_No.Text.Trim()}';";
			SqlHelper sqlHelper = new SqlHelper();
			sqlHelper.QuickRead(studentCommand);
			if (sqlHelper.HasRecord)
			{
				sqlHelper.QuickFill(classCommand, this.cmb_Class);
				this.txb_No.Text = sqlHelper["No"].ToString();
				this.txb_Name.Text = sqlHelper["Name"].ToString();
				this.rdb_Male.Checked = (bool)sqlHelper["Gender"];
				this.rdb_Female.Checked = !(bool)sqlHelper["Gender"];
				this.dtp_BirthDate.Value = (DateTime)sqlHelper["BirthDate"];
				this.cmb_Class.SelectedValue = (int)sqlHelper["ClassNo"];
				this.txb_Speciality.Text = sqlHelper["Speciality"].ToString();
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
			int rowAffected = sqlHelper.QuickSubmit(commandText);
			MessageBox.Show($"更新{rowAffected}行。");
		}
	}
}
