using System.Drawing;                                                                               //提供颜色；
using System.Linq;
using System.Windows.Forms;

namespace EntityFramework_Crud
{
	/// <summary>
	/// 教学管理窗体；（操作部分）
	/// </summary>
	public partial class frm_EducationManagement : Form
    {
        /// <summary>
        /// 数据库上下文；
        /// </summary>
        private EduBase EduBase;
        /// <summary>
        /// 班级编号；
        /// </summary>
        private int ClassNo;
        /// <summary>
        /// 初始化控件；
        /// </summary>
        private void InitializeControls()
        {
            this.StartPosition = FormStartPosition.CenterScreen;                                    //本窗体启动位置设为屏幕中央；
            this.dgv_Student.ReadOnly = true;                                                       //数据网格视图设为只读；
            this.dgv_Student.AllowUserToAddRows = false;                                            //数据网格视图不允许用户添加行；
            this.dgv_Student.RowHeadersVisible = false;                                             //数据网格视图的行标题不可见；
            this.dgv_Student.BackgroundColor = Color.White;                                         //数据网格视图的背景色设为白色；
            this.dgv_Student.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;                                           //数据网格视图的自动调整列宽模式设为显示所有单元格；
            this.dgv_Student.CellDoubleClick += this.dgv_Student_CellDoubleClick;                   //订阅数据网格视图的单元格双击事件；
            this.btn_Add.Enabled = false;                                                           //添加等按钮不可用；
            this.btn_Edit.Enabled = false;
            this.btn_Delete.Enabled = false;
        }
        /// <summary>
        /// 载入教学单位；
        /// </summary>
        private void LoadEducationUnit()
        {
            this.EduBase = new EduBase();                                                           //实例化数据库上下文；
            var departments = DepartmentRepository.FindAll();										//从数据库上下文读取所有院系，同时根据查询路径，预加载各院系下属的专业、班级；
            this.trv_EducationUnit.Nodes.Clear();                                                   //树形视图的节点集合清空；
            foreach (Department department in departments)                                          //遍历所有院系；
            {
                TreeNode departmentNode = new TreeNode();                                           //声明并实例化院系节点，该节点对应当前某个院系；
                departmentNode.Text = department.Name;                                              //院系节点的文本设为当前院系的名称；
                this.trv_EducationUnit.Nodes.Add(departmentNode);                                   //院系节点加入树形视图的节点列表，成为第0级节点之一；
                foreach (Major major in department.Major)                                           //遍历当前院系的所有专业；
                {
                    TreeNode majorNode = new TreeNode();                                            //声明并实例化专业节点，该节点对应当前某个专业；
                    majorNode.Text = major.Name;                                                    //专业节点的文本设为当前专业的名称；
                    departmentNode.Nodes.Add(majorNode);                                            //专业节点加入当前院系节点的节点集合，成为第1级节点之一；
                    foreach (Class currentClass in major.Class)                                     //遍历当前专业的所有班级；
                    {
                        TreeNode classNode = new TreeNode();                                        //声明并实例化班级节点，该节点对应当前某个班级；
                        classNode.Text = currentClass.Name;                                         //班级节点的文本设为当前班级的名称；
                        classNode.Tag = currentClass.No;                                            //班级节点的标签设为当前班级的编号；
                        majorNode.Nodes.Add(classNode);                                             //班级节点加入当前专业节点的节点集合，成为第2级节点之一；
                    }
                }
            }
        }
        /// <summary>
        /// 载入当前班级的所有学生；
        /// </summary>
        private void LoadCurrentClassStudents()
        {
            this.dgv_Student.DataSource = null;                                                     //将数据网格视图的数据源设为空；
            this.btn_Add.Enabled = false;                                                           //添加等按钮不可用；
            this.btn_Edit.Enabled = false;
            this.btn_Delete.Enabled = false;
            if (this.trv_EducationUnit.SelectedNode.Level != 2)                                     //若树形视图的选中节点的级别不等于2，即选中的并非班级节点；
                return;                                                                             //返回；
            this.btn_Add.Enabled = true;                                                            //添加按钮可用；
            this.ClassNo = (int)this.trv_EducationUnit.SelectedNode.Tag;                            //树形视图的选中节点的标签转为整型，即为事先保存的班级编号；
			var students = StudentRepository.FindByClassNo(this.ClassNo);																//匿名类型的成员包括学生学号、姓名；
            if (students.Count() == 0)                                                              //若查得学生人数为0；                                                  
                return;                                                                             //返回；
            this.dgv_Student.DataSource = students;                                        //将查得的当前班级学生转为列表后，设为数据网格视图的数据源；
            this.dgv_Student.Columns["No"].HeaderText = "学号";                                     //将数据网格视图的指定列的表头文本设为中文；
            this.dgv_Student.Columns["Name"].HeaderText = "姓名";
            this.dgv_Student.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;    //该列的自动调整列宽模式设为填充（至数据网格视图右侧边缘）；
            this.btn_Edit.Enabled = true;                                                           //编辑等按钮可用；
            this.btn_Delete.Enabled = true;
        }
        /// <summary>
        /// 添加学生；
        /// </summary>
        private void AddStudent()
        {
            frm_StudentInfo studentInfoForm = new frm_StudentInfo(null, this.ClassNo);              //声明并实例化学生信息窗体，在构造函数中传入班级编号；
            studentInfoForm.ShowDialog();                                                           //学生信息窗体以对话框方式打开；
            this.LoadCurrentClassStudents();                                                             //学生信息窗体关闭后，重新载入当前班级的所有学生；
        }
        /// <summary>
        /// 编辑学生；
        /// </summary>
        private void EditStudent()
        {
            string currentStudentNo =                                                               //声明字符串变量，用于保存当前选中的学生学号；
                this.dgv_Student.CurrentCell.Value.ToString();                           //数据网格视图的当前行的单元格集合中，对应学号的单元格的值即为当前选中的学生学号；
            frm_StudentInfo studentInfoForm = new frm_StudentInfo(currentStudentNo, 0);             //声明并实例化学生信息窗体，在构造函数中传入当前选中的学生学号；
            studentInfoForm.ShowDialog();                                                           //学生信息窗体以对话框方式打开；
            this.LoadCurrentClassStudents();                                                             //学生信息窗体关闭后，重新载入当前班级的所有学生；
        }
        /// <summary>
        /// 删除学生；
        /// </summary>
        private void DeleteStudent()
        {
            string currentStudentNo =                                                               //声明字符串变量，用于保存当前选中的学生学号；
                this.dgv_Student.CurrentCell.Value.ToString().Trim();                    //数据网格视图的当前行的单元格集合中，对应学号的单元格的值即为当前选中的学生学号；
            var dialogResult =                                                                      //声明隐式类型变量，用于保存对话框点击结果；
                MessageBox.Show                                                                     //消息框显示；
                    ($"是否确认删除{currentStudentNo}号学生？"										//删除提示；
                    , "提示"                                                                        //消息框标题；
                    , MessageBoxButtons.OKCancel);                                                  //消息框包含OK、取消按钮；
            if (dialogResult != DialogResult.OK)                                                    //若对话框点击结果并非OK；
                return;                                                                             //返回；
            int rowsAffected = StudentRepository.Delete(currentStudentNo);                                          //数据库上下文保存更改，返回受影响行数；
            if (rowsAffected > 0)                                                                   //若受影响行数大于0；
            {
                MessageBox.Show("删除成功。");														//显示消息；
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
            this.LoadCurrentClassStudents();                                                             //重新载入当前班级的所有学生；
        }
    }
}
