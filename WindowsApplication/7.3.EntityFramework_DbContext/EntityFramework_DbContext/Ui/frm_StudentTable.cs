using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace EntityFramework_DbContext
{
	public partial class frm_StudentTable : Form
	{
		/// <summary>
		/// 学生仓储；
		/// </summary>
		private StudentRepository StudentRepository { get; set; }
		/// <summary>
		/// 当前页码；
		/// </summary>
		private int currentPageIndex { get; set; }
		/// <summary>
		/// 构造函数；
		/// </summary>
		public frm_StudentTable()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this.dgv_Score.AllowUserToAddRows = false;
			this.dgv_Score.RowHeadersVisible = false;
			this.dgv_Score.BackgroundColor = Color.White;
			this.dgv_Score.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.AllCells;
			this.btn_PreviousPage.Enabled = false;
			this.btn_NextPage.Enabled = false;
			this.StudentRepository = new StudentRepository();
			this.currentPageIndex = 1;
		}
		/// <summary>
		/// 点击载入按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Load_Click(object sender, EventArgs e)
		{
			var classes = ClassRepository.FindAll();
			var students = this.StudentRepository.FindAll(this.currentPageIndex);
			this.dgv_Score.Columns.Clear();
			this.dgv_Score.DataSource = students;
			this.dgv_Score.Columns["No"].ReadOnly = true;
			this.dgv_Score.Columns["No"].HeaderText = "学号";
			this.dgv_Score.Columns["Name"].HeaderText = "姓名";
			this.dgv_Score.Columns["Gender"].HeaderText = "性别";
			this.dgv_Score.Columns["BirthDate"].HeaderText = "生日";
			this.dgv_Score.Columns["Speciality"].HeaderText = "特长";
			this.dgv_Score.Columns["Photo"].HeaderText = "照片";
			this.dgv_Score.Columns["ClassNo"].Visible = false;
			this.dgv_Score.Columns["Class"].Visible = false;
			DataGridViewComboBoxColumn classColumn = new DataGridViewComboBoxColumn();
			this.dgv_Score.Columns.Add(classColumn);
			classColumn.Name = "Class";
			classColumn.HeaderText = "班级";
			classColumn.DataSource = classes;
			classColumn.DisplayMember = "Name";
			classColumn.ValueMember = "No";
			classColumn.DataPropertyName = "ClassNo";
			classColumn.DisplayIndex = 4;
			classColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			this.dgv_Score.Columns[this.dgv_Score.Columns.Count - 2].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;
			this.btn_PreviousPage.Enabled = true;
			this.btn_NextPage.Enabled = true;
		}
		/// <summary>
		/// 点击更新按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Update_Click(object sender, EventArgs e)
		{
			int rowAffected = this.StudentRepository.Save();
			MessageBox.Show($"更新{rowAffected}行。");
		}
		/// <summary>
		/// 点击初始化数据库按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_InitDb_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show
					("即将初始化数据库，是否继续",
					"注意",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Exclamation)
				!= DialogResult.Yes)
			{
				return;
			}
			if (EfHelper.InitDb())
			{
				MessageBox.Show("数据库初始化完毕。");
			}
		}
		/// <summary>
		/// 点击下一页；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_NextPage_Click(object sender, EventArgs e)
		{
			if (this.dgv_Score.RowCount == this.StudentRepository.PageSize)
				this.currentPageIndex++;
			this.dgv_Score.DataSource = this.StudentRepository.FindAll(this.currentPageIndex);
		}
		/// <summary>
		/// 点击上一页；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_PreviousPage_Click(object sender, EventArgs e)
		{
			if (this.currentPageIndex>1)
				this.currentPageIndex--;
			this.dgv_Score.DataSource = this.StudentRepository.FindAll(this.currentPageIndex);
		}
	}
}
