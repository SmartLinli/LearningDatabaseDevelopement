using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EntityFramework_Linq
{
	public partial class frm_CourseSelection : Form
	{
		/// <summary>
		/// 学号；
		/// </summary>
		private string StudentNo => "3180707001";
		/// <summary>
		/// 已选课程仓储；
		/// </summary>
		private SelectedCourseRepository SelectedCourseRepository { get; set; }
		/// <summary>
		/// 课程信息绑定列表；
		/// </summary>
		private BindingList<CourseInfo> CourseInfos { get; set; }
		/// <summary>
		/// 已选课程信息绑定列表；
		/// </summary>
		private BindingList<SelectedCourseInfo> SelectedCourseInfos { get; set; }
		/// <summary>
		/// 构造函数；
		/// </summary>
		public frm_CourseSelection()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this.dgv_Course.ReadOnly = true;
			this.dgv_Course.AllowUserToAddRows = false;
			this.dgv_Course.RowHeadersVisible = false;
			this.dgv_Course.BackgroundColor = Color.White;
			this.dgv_Course.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgv_SelectedCourse.AllowUserToAddRows = false;
			this.dgv_SelectedCourse.RowHeadersVisible = false;
			this.dgv_SelectedCourse.BackgroundColor = Color.LightBlue;
			this.dgv_SelectedCourse.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.AllCells;
			this.SelectedCourseRepository = new SelectedCourseRepository();
		}
		/// <summary>
		/// 点击载入按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Load_Click(object sender, EventArgs e)
		{
			this.dgv_Course.Columns.Clear();
			var courses = CourseRepository.FindByStudentNo(this.StudentNo);
			this.CourseInfos = new BindingList<CourseInfo>(courses);
			this.dgv_Course.DataSource = this.CourseInfos;
			this.dgv_Course.Columns["No"].HeaderText = "编号";
			this.dgv_Course.Columns["Name"].HeaderText = "名称";
			this.dgv_Course.Columns["Credit"].HeaderText = "学分";
			this.dgv_Course.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dgv_SelectedCourse.Columns.Clear();
			this.SelectedCourseInfos = new BindingList<SelectedCourseInfo>(this.SelectedCourseRepository.FindByStudentNo(this.StudentNo));
			this.dgv_SelectedCourse.DataSource = this.SelectedCourseInfos;
			this.dgv_SelectedCourse.Columns["CourseNo"].HeaderText = "编号";
			this.dgv_SelectedCourse.Columns["CourseName"].HeaderText = "名称";
			this.dgv_SelectedCourse.Columns["Credit"].HeaderText = "学分";
			this.dgv_SelectedCourse.Columns["OrderBook"].HeaderText = "订购课本";
			this.dgv_SelectedCourse.Columns["StudentNo"].Visible = false;
			this.dgv_SelectedCourse.Columns["CourseName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.lbl_CreditSum.Text =
				$"共{this.SelectedCourseInfos.Sum(c => c.Credit)}学分";
		}
		/// <summary>
		/// 点击添加按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Add_Click(object sender, EventArgs e)
		{
			if (this.dgv_Course.RowCount == 0)
				return;
			var currentCourse =
				this.dgv_Course.CurrentRow.DataBoundItem as CourseInfo;
			var selectedCourse = CourseService.Select(currentCourse,this.StudentNo);
			this.SelectedCourseInfos.Add(selectedCourse);
			this.CourseInfos.Remove(currentCourse);
			this.lbl_CreditSum.Text =
				$"共{this.SelectedCourseInfos.Sum(c => c.Credit)}学分";
		}
		/// <summary>
		/// 点击移除按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Remove_Click(object sender, EventArgs e)
		{
			if (this.dgv_SelectedCourse.RowCount == 0)
				return;
			var currentSelectedCourseInfo =
				this.dgv_SelectedCourse.CurrentRow.DataBoundItem as SelectedCourseInfo;
			bool isNew = this.SelectedCourseRepository.IsNew(currentSelectedCourseInfo);
			if (!CourseService.CanBeRejected(isNew))
				return;
			var course = CourseService.Reject(currentSelectedCourseInfo);
			this.CourseInfos.Add(course);
			this.SelectedCourseInfos.Remove(currentSelectedCourseInfo);
			this.lbl_CreditSum.Text =
				$"共{this.SelectedCourseInfos.Sum(c => c.Credit)}学分";
		}
		/// <summary>
		/// 点击提交按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Submit_Click(object sender, EventArgs e)
		{
			int rowAffected =
				this.SelectedCourseRepository.Save();
			MessageBox.Show($"提交{rowAffected}行。");
		}
	}
}
