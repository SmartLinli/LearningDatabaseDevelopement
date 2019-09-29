using SmartLinli.DatabaseDevelopement;
using System;
using System.Data;
using System.Windows.Forms;

namespace Record_Update_RawSql
{
	public partial class frm_StudentInfo : Form
	{
		/// <summary>
		/// 公有方法：构造函数；
		/// </summary>
		public frm_StudentInfo()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this.txb_No.ReadOnly = true;
			this.cmb_Class.DropDownStyle = ComboBoxStyle.DropDownList;
		}
		/// <summary>
		/// 私有方法：点击载入按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Load_Click(object sender, EventArgs e)
		{
			var dbHelper = new SqlHelper();
			var classTable = dbHelper
				.NewCommand("SELECT * FROM Class;")
				.ReturnTable();
			this.cmb_Class.DataSource = classTable;
			this.cmb_Class.DisplayMember = "Name";
			this.cmb_Class.ValueMember = "No";
			var studentReader = dbHelper
				.NewCommand("SELECT * FROM Student WHERE No=@No;")
				.With("@No", "3120707001")
				.ReturnReader();
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
			studentReader.Close();
		}	
		/// <summary>
		/// 私有方法：点击更新按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Update_Click(object sender, EventArgs e)
		{
			var dbHelper = new SqlHelper();
			string updateCommand =
				"UPDATE Student"
				+ " SET Name=@Name,Gender=@Gender,BirthDate=@BirthDate,ClassNo=@ClassNo,Speciality=@Speciality"
				+ " WHERE No=@No;";
			int rowAffected = dbHelper
				.NewCommand(updateCommand)
				.With("@No", "3120707001", DbType.StringFixedLength, 10)
				.With("@Name", this.txb_Name.Text.Trim())
				.With("@Gender", this.rdb_Male.Checked, DbType.Boolean)
				.With("@BirthDate", this.dtp_BirthDate.Value, DbType.Date)
				.With("@ClassNo", (int)this.cmb_Class.SelectedValue, DbType.Int32)
				.With("@Speciality", this.txb_Speciality.Text.Trim())
				.Submit();
			MessageBox.Show($"更新{rowAffected}行。");
		}
	}
}
