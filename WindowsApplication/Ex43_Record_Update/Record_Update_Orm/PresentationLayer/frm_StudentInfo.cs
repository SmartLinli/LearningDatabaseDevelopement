using SmartLinli.DatabaseDevelopement;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace Record_Update_Orm
{
	public partial class frm_StudentInfo : Form
	{
		/// <summary>
		/// 学生；
		/// </summary>
		private Student _Student;
		/// <summary>
		/// 公有方法：构造函数；
		/// </summary>
		public frm_StudentInfo()
		{
			EfHelper.WarmUp();
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
			var classes = EfHelper.SelectAll<Class>();
			this.cmb_Class.DataSource = classes;
			this.cmb_Class.DisplayMember = "Name";
			this.cmb_Class.ValueMember = "No";
			var student = EfHelper.SelectOne<Student>(s => s.No == "3120707001");
			this._Student = student;
			if (student != null)
			{
				this.txb_No.Text = student.No;
				this.txb_Name.Text = student.Name;
				this.rdb_Male.Checked = student.Gender;
				this.rdb_Female.Checked = !student.Gender;
				this.dtp_BirthDate.Value = student.BirthDate;
				this.cmb_Class.SelectedValue = student.ClassNo;
				this.txb_Speciality.Text = student.Speciality;
			}
		}	
		/// <summary>
		/// 私有方法：点击更新按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Update_Click(object sender, EventArgs e)
		{
			var student = this._Student;
			student.No = this.txb_No.Text;
			student.Name = this.txb_Name.Text;
			student.Gender = this.rdb_Male.Checked;
			student.BirthDate = this.dtp_BirthDate.Value;
			student.ClassNo = (int)this.cmb_Class.SelectedValue;
			student.Speciality = this.txb_Speciality.Text;
			int rowAffected = EfHelper.Save(this._Student, EntityState.Modified);
			MessageBox.Show($"更新{rowAffected}行。");
		}
	}
}
