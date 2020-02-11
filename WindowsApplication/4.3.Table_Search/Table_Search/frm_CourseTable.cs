using System;
using System.Data;
using System.Data.SqlClient;                                                                                //包含访问SQL Server所需的各类对象；
using System.Drawing;
using System.Windows.Forms;

namespace Table_Search
{    
    public partial class frm_CourseTable : Form
    {
        /// <summary>
        /// 私有字段：课程数据表；
        /// </summary>
        private DataTable CourseTable;
        /// <summary>
        /// 私有字段：先修课程数据表；
        /// </summary>
        private DataTable PreCourseTable;
        /// <summary>
        /// 私有字段：按名称排序的课程数据视图；
        /// </summary>
        private DataView CourseViewByName;
        /// <summary>
        /// 公有方法：构造函数；
        /// </summary>
        public frm_CourseTable()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                                            //本窗体启动位置设为屏幕中央； 
            this.dgv_Course.AllowUserToAddRows = false;                                                     //数据网格视图不允许用户添加行；
            this.dgv_Course.RowHeadersVisible = false;                                                      //数据网格视图的行标题不可见；
            this.dgv_Course.BackgroundColor = Color.White;                                                  //数据网格视图的背景色设为白色；
            this.dgv_Course.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;                                                   //数据网格视图的自动调整列宽模式设为显示所有单元格；
        }
        /// <summary>
        /// 私有方法：点击载入按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Load_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                              //声明并实例化SQL连接；
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                             //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
            SqlCommand sqlCommand = new SqlCommand();                                                       //声明并实例化SQL命令；
            sqlCommand.Connection = sqlConnection;                                                          //将SQL命令的连接属性指向SQL连接；
            sqlCommand.CommandText = "SELECT * FROM tb_Course;";                                            //指定SQL命令的命令文本；该命令查询所有课程，以用作数据网格视图数据源；
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                           //声明并实例化SQL数据适配器；
            sqlDataAdapter.SelectCommand = sqlCommand;                                                      //将SQL数据适配器的查询命令属性指向SQL命令；
            sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;                            //设置SQL数据适配器在缺少架构时的动作为追加主键，从而获取数据库中定义的主键，否则无法根据编号搜索课程；
            this.CourseTable = new DataTable();                                                             //实例化本窗体的课程数据表，用于保存所有课程，以用作数据网格视图数据源；
            sqlConnection.Open();                                                                           //打开SQL连接；
            sqlDataAdapter.Fill(this.CourseTable);                                                          //SQL数据适配器读取数据，并填充课程数据表；
            sqlConnection.Close();                                                                          //关闭SQL连接；
            this.PreCourseTable = this.CourseTable.Copy();                                                  //借助本窗体的课程数据表的方法Copy来复制数据表，并赋予本窗体的先修课程数据表，用作先修课程下拉框的数据源；
            this.CourseViewByName = new DataView();                                                         //实例化本窗体的课程数据视图，用于按照名称进行快速查询；
            this.CourseViewByName.Table = this.CourseTable;                                                 //设置课程数据视图对应的数据表；
            this.CourseViewByName.Sort = "Name ASC";                                                        //设置课程数据视图的排序条件，即查询所覆盖的列；
            this.dgv_Course.Columns.Clear();                                                                //数据网格视图的列集合清空；
            this.dgv_Course.DataSource = this.CourseTable;                                                  //将数据网格视图的数据源设为学生数据表；
            this.dgv_Course.Columns["No"].HeaderText = "编号";                                              //将数据网格视图的指定列的表头文本设为中文；
            this.dgv_Course.Columns["Name"].HeaderText = "名称";
            this.dgv_Course.Columns["Credit"].HeaderText = "学分";
            this.dgv_Course.Columns["StudyType"].HeaderText = "修读类型";
            this.dgv_Course.Columns["ExamType"].HeaderText = "考试类型";
            this.dgv_Course.Columns["Pinyin"].Visible = false;                                              //将数据网格视图的指定列设为不可见；
            this.dgv_Course.Columns["PreCourseNo"].Visible = false; 
            DataGridViewComboBoxColumn preCourseColumn = new DataGridViewComboBoxColumn();                  //声明并实例化数据网格视图下拉框列，用于设置先修课程；
            this.dgv_Course.Columns.Add(preCourseColumn);                                                   //将下拉框列加入数据网格视图的列集合；
            preCourseColumn.Name = "PreCourse";                                                             //设置下拉框列的名称；
            preCourseColumn.HeaderText = "先修课程";                                                        //设置下拉框列的表头文本；
            preCourseColumn.DataSource = this.PreCourseTable;                                               //设置下拉框列的数据源为先修课程数据表；
            preCourseColumn.DisplayMember = "Name";                                                         //设置下拉框列的显示成员为（先修课程数据表的）名称（列）；
            preCourseColumn.ValueMember = "No";                                                             //设置下拉框列的值成员为（先修课程数据表的）编号（列）；
            preCourseColumn.DataPropertyName = "PreCourseNo";                                               //设置下拉框列的数据属性名称为（课程数据表的）先修课程编号（列）；
            preCourseColumn.DisplayIndex = 3;                                                               //设置下拉框列的显示顺序；
            preCourseColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;                         //设置下拉框列的自动调整列宽模式为（显示）所有单元格；
            this.dgv_Course.Columns[this.dgv_Course.Columns.Count - 2].AutoSizeMode =                       //数据网格视图的倒数第2列（即考试类型列）的自动调整列宽模式设为填充（至数据网格视图右侧边缘）；
                DataGridViewAutoSizeColumnMode.Fill;
        }
        /// <summary>
        /// 私有方法：点击根据编号搜索按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SearchByNo_Click(object sender, EventArgs e)
        {
            DataRow searchResultRow = this.CourseTable.Rows.Find(this.txb_CourseNo.Text.Trim());            //借助本窗体的课程数据表的行集合的方法Find，根据主键值（即课程编号）快速查找相应课程，并返回其所在的数据行；但数据行不能作为数据源，需另行创建数据表，并导入该数据行，最后将数据表作为数据源；
            DataTable searchResultTable = this.CourseTable.Clone();                                         //借助本窗体的课程数据表的方法Clone，创建相同架构的空表，用于保存搜索结果所在数据行；
            searchResultTable.ImportRow(searchResultRow);                                                   //将（复制后的）数据行导入数据表；
            this.dgv_Course.DataSource = searchResultTable;                                                 //将数据网格视图的数据源设为搜索结果数据表；
        }
        /// <summary>
        /// 私有方法：点击根据名称搜索按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SearchByName_Click(object sender, EventArgs e)
        {
            DataRowView[] searchResultRowViews = 
                this.CourseViewByName.FindRows(this.txb_CourseName.Text.Trim());                            //借助本窗体的按名称排序的课程数据视图的方法FindRows，根据排序列（即课程名称）快速查找相应课程；由于该列并非主键，可能返回多行查询结果，故返回数据行视图数组；数据行视图数组不能直接作为数据源，需转为列表后方可作为数据源；
            DataTable searchResultTable = this.CourseTable.Clone();                                         //借助本窗体的课程数据表的方法Clone，创建相同架构的空表，用于保存搜索结果所在数据行；
            foreach (DataRowView dataRowView in searchResultRowViews)                                       //遍历搜索结果所在数据行视图数组；
            {
                searchResultTable.ImportRow(dataRowView.Row);                                               //通过每条数据行视图的属性Row获取相应的数据行，并导入数据表；
            }
            this.dgv_Course.DataSource = searchResultTable;                                                 //将数据网格视图的数据源设为搜索结果数据表；
        }
        /// <summary>
        /// 私有方法：拼音文本框的文本更改；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_Pinyin_TextChanged(object sender, EventArgs e)
        {
			DataRow[] searchResultRows =
				this.CourseTable.Select($"Pinyin LIKE '%{this.txb_Pinyin.Text.Trim()}%'");					//借助本窗体的课程数据表的方法Select，并提供与SQL类似的谓词表达式作为查询条件，根据拼音缩写进行模糊查询（仅支持%通配符）；查询将返回数据行数组；
            DataTable searchResultTable = this.CourseTable.Clone();                                         //借助本窗体的课程数据表的方法Clone，创建相同架构的空表，用于保存搜索结果所在数据行；
            foreach (DataRow row in searchResultRows)                                                       //遍历搜索结果所在数据行数组；
            {
                searchResultTable.ImportRow(row);                                                           //数据行导入数据表；
            }
            this.dgv_Course.DataSource = searchResultTable;                                                 //将数据网格视图的数据源设为搜索结果数据表；
        }
    }                                                                                                    
}
