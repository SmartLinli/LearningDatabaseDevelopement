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
            this.AcceptButton = this.btn_Load;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.LoadClasses();
		}
		/// <summary>
		/// 向下拉框载入班级名称；
		/// </summary>
		private void LoadClasses()
		{
			string commandText = "SELECT Name FROM tb_Class";
			var sqlHelper = new SqlHelper();
            sqlHelper.QuickFill(commandText, this.cmb_Class);
		}
		/// <summary>
		/// 点击载入按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Load_Click(object sender, EventArgs e)
		{
			string  commandText = $"SELECT * FROM tb_Student WHERE No='{this.txb_No.Text.Trim()}';";
			SqlHelper sqlHelper = new SqlHelper();
			sqlHelper.QuickRead(commandText);
			if (sqlHelper.HasRecord)
			{
				this.txb_No.Text = sqlHelper["No"].ToString();
				this.txb_Name.Text = sqlHelper["Name"].ToString();
				this.rdb_Male.Checked = (bool)sqlHelper["Gender"];
				this.rdb_Female.Checked = !(bool)sqlHelper["Gender"];
				this.dtp_BirthDate.Value = (DateTime)sqlHelper["BirthDate"];
				this.cmb_Class.SelectedItem = sqlHelper["Class"].ToString();
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
				$@"UPDATE tb_Student
					SET Name='{this.txb_Name.Text.Trim()}'
						,Gender='{this.rdb_Male.Checked}'
						,BirthDate='{this.dtp_BirthDate.Value}'
						,Class='{this.cmb_Class.SelectedItem.ToString()}'
						,Speciality='{this.txb_Speciality.Text.Trim()}'
					WHERE No='{this.txb_No.Text.Trim()}';";
			SqlHelper sqlHelper = new SqlHelper();
			int rowAffected = sqlHelper.QuickSubmit(commandText);
			MessageBox.Show($"更新{rowAffected}行。");
		}
	}
}
