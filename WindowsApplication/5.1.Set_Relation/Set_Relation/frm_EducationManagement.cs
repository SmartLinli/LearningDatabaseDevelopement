using System;
using System.Data;
using System.Data.SqlClient;                                                                            //包含访问SQL Server所需的各类对象；
using System.Drawing;
using System.Windows.Forms;

namespace Set_Relation
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
            this.StartPosition = FormStartPosition.CenterScreen;                                        //本窗体启动位置设为屏幕中央；
            this.dgv_Student.AllowUserToAddRows = false;                                                //数据网格视图不允许用户添加行；
            this.dgv_Student.RowHeadersVisible = false;                                                 //数据网格视图的行标题不可见；
            this.dgv_Student.BackgroundColor = Color.White;                                             //数据网格视图的背景色设为白色；
            this.dgv_Student.AutoSizeColumnsMode =                                                     
                DataGridViewAutoSizeColumnsMode.AllCells;                                               //数据网格视图的自动调整列宽模式设为显示所有单元格；
        }
        /// <summary>
        /// 点击载入按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Load_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                          //声明并实例化SQL连接；
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                         //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
            SqlCommand sqlCommand = new SqlCommand();                                                   //声明并实例化SQL命令；
            sqlCommand.Connection = sqlConnection;                                                      //将SQL命令的连接属性指向SQL连接；
            sqlCommand.CommandText =                                                                    //指定SQL命令的命令文本；
                "SELECT * FROM tb_Department;" +                                                        //该命令分别查询所有院系、专业、班级，查询结果将返回多张表；
                "SELECT * FROM tb_Major;" +
                "SELECT * FROM tb_Class;";                                       
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                       //声明并实例化SQL数据适配器，同时借助构造函数，将其SelectCommand属性设为先前创建的SQL命令；
            sqlDataAdapter.SelectCommand = sqlCommand;                                                  //将SQL数据适配器的查询命令属性指向SQL命令；
            DataSet dataSet = new DataSet();                                                            //声明并实例化数据集，用于保存查得的多张表；
            sqlConnection.Open();                                                                       //打开SQL连接；
            sqlDataAdapter.Fill(dataSet);                                                               //SQL数据适配器读取数据，并填充数据集；
            sqlConnection.Close();                                                                      //关闭SQL连接；
            DataTable departmentTable = dataSet.Tables[0];                                              //声明院系数据表，对应数据集的表集合中的第1张数据表；
            DataTable majorTable = dataSet.Tables[1];                                                   //声明专业数据表，对应数据集的表集合中的第2张数据表；
            DataTable classTable = dataSet.Tables[2];                                                   //声明班级数据表，对应数据集的表集合中的第3张数据表；
            DataRelation[] dataRelations =                                                              //声明数据关系数组；
            {
                new DataRelation                                                                        //实例化数据关系，实现院系表、专业表之间的层次关系；
                    ("Department_Major",                                                                //数据关系名称；
                     departmentTable.Columns["No"],                                                     //父表的被参照列为院系表的编号列；
                     majorTable.Columns["DepartmentNo"]),                                                //子表的参照列为专业表的院系编号列；不要求后端数据库在子表的参照列上创建外键约束；
                new DataRelation                                                                        //实例化数据关系，实现专业表、班级表之间的层次关系；
                    ("Major_Class",                                                                     //数据关系名称；
                     majorTable.Columns["No"],                                                          //父表的被参照列为专业表的编号列；
                     classTable.Columns["MajorNo"])                                                     //子表的参照列为班级表的专业编号列；
            };
            dataSet.Relations.AddRange(dataRelations);                                                  //将数据关系数组批量加入数据集的关系集合中；
            this.trv_EducationUnit.Nodes.Clear();                                                       //树形视图的节点集合清空；
            foreach (DataRow departmentRow in departmentTable.Rows)                                     //遍历院系数据表中的每一数据行；
            {
                TreeNode departmentNode = new TreeNode();                                               //声明并实例化院系节点，该节点对应当前某个院系；
                departmentNode.Text = departmentRow["Name"].ToString();                                 //院系节点的文本设为当前院系的名称；
                this.trv_EducationUnit.Nodes.Add(departmentNode);                                       //将院系节点加入树形视图的（根）节点集合；
                foreach (DataRow majorRow in departmentRow.GetChildRows("Department_Major"))            //借助先前定义的数据关系，遍历当前院系所在数据行的子行，即下属所有专业；
                {
                    TreeNode majorNode = new TreeNode();                                                //声明并实例化专业节点，该节点对应当前某个专业；
                    majorNode.Text = majorRow["Name"].ToString();                                       //专业节点的文本设为当前专业的名称；
                    departmentNode.Nodes.Add(majorNode);                                                //专业节点加入当前院系节点的节点集合，成为第1级节点之一；
                    foreach (DataRow classRow in majorRow.GetChildRows("Major_Class"))                  //借助先前定义的数据关系，遍历当前专业所在数据行的子行，即下属所有班级；
                    {
                        TreeNode classNode = new TreeNode();                                            //声明并实例化班级节点，该节点对应当前某个班级；
                        classNode.Text = classRow["Name"].ToString();                                   //班级节点的文本设为当前班级的名称；
                        classNode.Tag = classRow["No"];													//班级节点的标签设为当前班级的编号；
                        majorNode.Nodes.Add(classNode);                                                 //班级节点加入当前专业节点的节点集合，成为第2级节点之一；
                    }
                }
            }
        }
        /// <summary>
        /// 选择教学单位树形视图；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trv_EducationUnit_AfterSelect(object sender, TreeViewEventArgs e)
        {
			if (this.trv_EducationUnit.SelectedNode.Level != 2)                                         //若树形视图的选中节点的级别不为3，即未选中班级节点；
				return;																					//则返回；
            int classNo = (int)this.trv_EducationUnit.SelectedNode.Tag;									//将树形视图的选中节点的标签转为整型，即可获得事先保存的班级编号；
            SqlConnection sqlConnection = new SqlConnection();                                          //声明并实例化SQL连接；
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                         //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
            SqlCommand sqlCommand = new SqlCommand();                                                   //声明并实例化SQL命令；
            sqlCommand.Connection = sqlConnection;                                                      //将SQL命令的连接属性指向SQL连接；
            sqlCommand.CommandText = "SELECT No,Name FROM tb_Student WHERE ClassNo=@ClassNo;";          //指定SQL命令的命令文本；该命令查询当前选中班级的所有学生名单，以用作数据网格视图数据源；
            sqlCommand.Parameters.AddWithValue("@ClassNo", classNo);                                    //向SQL命令的参数集合添加参数的名称、值；
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                       //声明并实例化SQL数据适配器，同时借助构造函数，将其SelectCommand属性设为先前创建的SQL命令；
            sqlDataAdapter.SelectCommand = sqlCommand;                                                  //将SQL数据适配器的查询命令属性指向SQL命令；
            DataTable studentTable = new DataTable();                                                   //声明并实例化数据表，用于保存当前选中班级的所有学生名单，以用作数据网格视图的数据源；
            sqlConnection.Open();                                                                       //打开SQL连接；
            sqlDataAdapter.Fill(studentTable);                                                          //SQL数据适配器读取数据，并填充班级数据表；
            sqlConnection.Close();                                                                      //关闭SQL连接；
            this.dgv_Student.DataSource = studentTable;                                                 //设置数据网格视图的数据源；
            this.dgv_Student.Columns["No"].HeaderText = "学号";                                         //将数据网格视图的指定列的表头文本设为中文；
            this.dgv_Student.Columns["Name"].HeaderText = "姓名";
            this.dgv_Student.Columns[this.dgv_Student.Columns.Count - 1].AutoSizeMode =                 //数据网格视图的最后一列的自动调整列宽模式设为填充（至数据网格视图右侧边缘）；
                DataGridViewAutoSizeColumnMode.Fill;
        }
    }                                                                                                    
}
