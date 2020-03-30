using System;
using System.Windows.Forms;

namespace EntityFramework_Crud
{
    
    /// <summary>
    /// 学生信息窗体；
    /// </summary>
    public partial class frm_StudentInfo : Form
    {
        /// <summary>
        /// 构造函数；
        /// <param name="studentNo">学号</param>
        /// <param name="classNo">班级编号</param>
        /// </summary>
        public frm_StudentInfo(string studentNo, int classNo)
        {
            InitializeComponent();
            this.InitializeControls();                                          //初始化控件；
            this.LoadStudent(studentNo, classNo);                               //载入学生；
        }
        /// <summary>
        /// 点击打开照片按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenPhoto_Click(object sender, EventArgs e)
        {
            this.OpenPhoto();                                                   //打开照片；
        }
        /// <summary>
        /// 点击OK按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            this.Submit();                                                      //提交；
            this.Close();                                                       //本窗体关闭；
        }
        /// <summary>
        /// 点击取消按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();                                                       //本窗体关闭；
        }
    }                                                                                                    
}
