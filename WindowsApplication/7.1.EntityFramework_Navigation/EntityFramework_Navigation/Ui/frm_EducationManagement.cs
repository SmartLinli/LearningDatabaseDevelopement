using System;
using System.Windows.Forms;

namespace EntityFramework_Navigation
{
	/// <summary>
	/// 教学管理窗体；
	/// </summary>
	public partial class frm_EducationManagement : Form
    {
        /// <summary>
        /// 构造函数；
        /// </summary>
        public frm_EducationManagement()
        {
            InitializeComponent();
			this.InitializeControls();
			this.BackgroundWorker.DoWork += this.LoadEducationUnitNodes;
			this.BackgroundWorker.RunWorkerCompleted += FillEducationUnitTree;
			this.BackgroundWorker.RunWorkerAsync();
		}
		/// <summary>
		/// 选择教学单位树形视图；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trv_EducationUnit_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.LoadCurrentClassStudents();                                                        
        }
        /// <summary>
        /// 双击学生数据网格视图；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Student_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.EditStudent();                                                                     
        }
        /// <summary>
        /// 单击添加按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.AddStudent();                                                                      
        }
        /// <summary>
        /// 单击编辑按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            this.EditStudent();                                                                     
        }
        /// <summary>
        /// 单击删除按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void btn_Delete_Click(object sender, EventArgs e)
        {
             this.DeleteStudent();                                                                   
        }
	}                                                                                                    
}
