using SmartLinli.DatabaseDevelopement;
using System;
using System.Windows.Forms;

namespace GridView
{
    /// <summary>
    /// 选课窗体；
    /// </summary>
    public partial class frm_CourseSelection : Form
    {
        /// <summary>
        /// 当前学号；
        /// </summary>
        private string StudentNumber => "3210707001";
        /// <summary>
        /// 构造函数；
        /// </summary>
        public frm_CourseSelection()
        {
            InitializeComponent();
            this.LoadCourses();
        }
        /// <summary>
        /// 载入课程；
        /// </summary>
        private void LoadCourses()
        {
            SqlHelper sqlHelper = new SqlHelper();
            string commantText =
                $@"SELECT C.*,IIF(SS.StudentNumber IS NULL,'未选','已选') AS Status 
				    FROM tb_Course AS C LEFT JOIN tb_StudentScore AS SS ON C.Number=SS.CourseNumber 
                        AND SS.StudentNumber='{StudentNumber}';";
            sqlHelper.QuickFill(commantText, this.dgv_AllCourses);
            commantText =
                $@"SELECT C.*,IIF(SS.Score IS NULL,'可退选','不可退') AS Status 
                    FROM tb_Course AS C JOIN tb_StudentScore AS SS ON SS.CourseNumber=C.Number 
                    WHERE SS.StudentNumber='{StudentNumber}';";
            sqlHelper.QuickFill(commantText, this.dgv_SelectedCourses);
        }
        /// <summary>
        /// 选课；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            string status = this.dgv_AllCourses.CurrentRow.Cells["Status"].Value.ToString();
            if (status == "已选")
            {
                MessageBox.Show("该课已选！请勿重复选修！");
                return;
            }
            SqlHelper sqlHelper = new SqlHelper();
            string currentCourseNumber = this.dgv_AllCourses.CurrentRow.Cells["Number"].Value.ToString();
            sqlHelper.QuickSubmit($"INSERT tb_StudentScore(StudentNumber,CourseNumber) VALUES('{StudentNumber}','{currentCourseNumber}');");
            this.LoadCourses();
        }
        /// <summary>
        /// 退选；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Reject_Click(object sender, EventArgs e)
        {
            string status = this.dgv_SelectedCourses.CurrentRow.Cells["Status"].Value.ToString();
            if (status == "不可退")
            {
                MessageBox.Show("该课已有成绩！不可退选！");
                return;
            }
            SqlHelper sqlHelper = new SqlHelper();
            string currentCourseNumber = this.dgv_SelectedCourses.CurrentRow.Cells["Number"].Value.ToString();
            sqlHelper.QuickSubmit($"DELETE tb_StudentScore WHERE StudentNumber='{StudentNumber}' AND CourseNumber='{currentCourseNumber}';");
            this.LoadCourses();
        }
    }
}
