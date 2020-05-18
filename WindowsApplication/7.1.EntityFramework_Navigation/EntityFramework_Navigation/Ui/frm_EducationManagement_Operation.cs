using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EntityFramework_Navigation
{
	/// <summary>
	/// 教学管理窗体；（操作部分）
	/// </summary>
	public partial class frm_EducationManagement : Form
    {
        /// <summary>
        /// 班级编号；
        /// </summary>
        private int ClassNo { get; set; }		
        /// <summary>
        /// 初始化控件；
        /// </summary>
        private void InitializeControls()
        {
            this.StartPosition = FormStartPosition.CenterScreen;                                   
            this.dgv_Student.ReadOnly = true;                                                      
            this.dgv_Student.AllowUserToAddRows = false;                                           
            this.dgv_Student.RowHeadersVisible = false;                                            
            this.dgv_Student.BackgroundColor = Color.White;                                        
            this.dgv_Student.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;                                          
            this.dgv_Student.CellDoubleClick += this.dgv_Student_CellDoubleClick;                  
            this.btn_Add.Enabled = false;                                                          
            this.btn_Edit.Enabled = false;
            this.btn_Delete.Enabled = false;
        }
		/// <summary>
		/// 载入教学单位节点；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoadEducationUnitNodes(object sender, DoWorkEventArgs e)
		{
			var departments = DepartmentRepository.FindAll();                                      
			List<TreeNode> departmentNodes = new List<TreeNode>();
			foreach (Department department in departments)                                         
			{
				TreeNode departmentNode = new TreeNode();                                          
				departmentNode.Text = department.Name;                                             
				departmentNodes.Add(departmentNode);												
				foreach (Major major in department.Major)                                          
				{
					TreeNode majorNode = new TreeNode();                                           
					majorNode.Text = major.Name;                                                   
					departmentNode.Nodes.Add(majorNode);                                           
					foreach (Class currentClass in major.Class)                                    
					{
						TreeNode classNode = new TreeNode();                                       
						classNode.Text = currentClass.Name;                                        
						classNode.Tag = currentClass.No;                                           
						majorNode.Nodes.Add(classNode);                                            
					}
				}
			}
			e.Result = departmentNodes.ToArray();
		}
		/// <summary>
		/// 填充教学单位树形视图；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FillEducationUnitTree(object sender, RunWorkerCompletedEventArgs e)
		{
			this.trv_EducationUnit.Nodes.Clear();
			this.trv_EducationUnit.Nodes.AddRange(e.Result as TreeNode[]);
		}
		/// <summary>
		/// 载入当前班级的所有学生；
		/// </summary>
		private void LoadCurrentClassStudents()
		{
			this.dgv_Student.DataSource = null;
			this.btn_Add.Enabled = false;
			this.btn_Edit.Enabled = false;
			this.btn_Delete.Enabled = false;
			if (this.trv_EducationUnit.SelectedNode.Level != 2)
				return;
			this.btn_Add.Enabled = true;
			this.ClassNo = (int)this.trv_EducationUnit.SelectedNode.Tag;
			var students = StudentRepository.FindByClassNo(this.ClassNo);
			if (students.Count() == 0)
				return;
			this.dgv_Student.DataSource = students;
			this.dgv_Student.Columns["No"].HeaderText = "学号";
			this.dgv_Student.Columns["Name"].HeaderText = "姓名";
			this.btn_Edit.Enabled = true;
			this.btn_Delete.Enabled = true;
		}
        /// <summary>
        /// 添加学生；
        /// </summary>
        private void AddStudent()
        {
            frm_StudentInfo studentInfoForm = new frm_StudentInfo(null, this.ClassNo);    
            studentInfoForm.ShowDialog();                                                 
            this.LoadCurrentClassStudents();                                              
        }
        /// <summary>
        /// 编辑学生；
        /// </summary>
        private void EditStudent()
        {
            string currentStudentNo =                                                     
                this.dgv_Student.CurrentRow.Cells[0].Value.ToString();                    
            frm_StudentInfo studentInfoForm = new frm_StudentInfo(currentStudentNo, 0);   
            studentInfoForm.ShowDialog();                                                 
            this.LoadCurrentClassStudents();                                              
        }
        /// <summary>
        /// 删除学生；
        /// </summary>
        private void DeleteStudent()
        {
            string currentStudentNo =                                                     
                this.dgv_Student.CurrentCell.Value.ToString().Trim();                    
            var dialogResult =                                                            
                MessageBox.Show                                                           
                    ($"是否确认删除{currentStudentNo}号学生？"										
                    , "提示"                                                                        
                    , MessageBoxButtons.OKCancel);                                                  
            if (dialogResult != DialogResult.OK)                                                    
                return;                                                                             
			int rowsAffected = StudentRepository.Delete(currentStudentNo);                          
            if (rowsAffected > 0)                                                                   
            {
                MessageBox.Show("删除成功。");														
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
            this.LoadCurrentClassStudents();                                                        
        }
    }
}
