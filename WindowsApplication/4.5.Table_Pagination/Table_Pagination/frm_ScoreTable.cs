using System;
using System.Data;
using System.Data.SqlClient;                                                                                //包含访问SQL Server所需的各类对象；
using System.Drawing;
using System.Windows.Forms;

namespace Table_Pagination
{    
    public partial class frm_ScoreTable : Form
    {
        /// <summary>
        /// 课程数据表；
        /// </summary>
        private DataTable CourseTable;
        /// <summary>
        /// 当前页课程的视图；
        /// </summary>
        private DataView CurrentPageView;
        /// <summary>
        /// 每页大小；
        /// </summary>
        private int PageSize;
        /// <summary>
        /// 当前页号；
        /// </summary>
        private int CurrentPageNo;
        /// <summary>
        /// 最大页号；
        /// </summary>
        private int MaxPageNo;
        /// <summary>
        /// 构造函数；
        /// </summary>
        public frm_ScoreTable()
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
		/// 刷新行筛选条件；
		/// </summary>
		private void RefreshRowFilter()
		=>	this.CurrentPageView.RowFilter =                                                                //设置课程数据视图的行筛选条件，即筛选当前页的记录；
				$"RowID >{(this.CurrentPageNo - 1) * this.PageSize}"
				+ $"AND RowID <={this.CurrentPageNo * this.PageSize}";                                      //根据当前页号、每页大小，计算相应的行编号范围，并作为行筛选条件；
		/// <summary>
		/// 点击载入按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Load_Click(object sender, EventArgs e)
        {
            this.PageSize = 10;                                                                             //设置每页大小为10（行记录）；
            this.CurrentPageNo = 1;                                                                         //设置当前页号为1；
            SqlConnection sqlConnection = new SqlConnection();                                              //声明并实例化SQL连接；
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                             //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
            SqlCommand sqlCommand = new SqlCommand();                                                       //声明并实例化SQL命令；
            sqlCommand.Connection = sqlConnection;                                                          //将SQL命令的连接属性指向SQL连接；
            sqlCommand.CommandText =
                "SELECT S.No,S.Name AS SName,C.Name AS CName,SS.TotalScore"
                + " FROM tb_Student AS S "
                + " JOIN tb_StudentScore AS SS ON S.No=SS.StudentNo"
                + " JOIN tb_Course AS C ON SS.CourseNo=C.No";                                               //指定SQL命令的命令文本；该命令查询所有学生成绩；
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                           //声明并实例化SQL数据适配器；
            sqlDataAdapter.SelectCommand = sqlCommand;                                                      //将SQL数据适配器的查询命令属性指向SQL命令；
            this.CourseTable = new DataTable();                                                             //实例化本窗体的课程数据表，用于保存所有课程，以用作数据网格视图数据源；
            this.CourseTable.TableName = "StudentScore";                                                    //设置课程数据表的表名；由于该查询访问多张表，数据适配器无法自动指定表名，故需手动指定表名；
            DataColumn rowIdColumn = new DataColumn();                                                      //声明并实例化数据列，用于保存行编号；
            rowIdColumn.ColumnName = "RowID";                                                               //设置数据列的名称；
            rowIdColumn.DataType = typeof(int);                                                             //设置数据列的类型；类型需借助typeof获取；
            rowIdColumn.AutoIncrement = true;                                                               //设置数据列为自增列；
            rowIdColumn.AutoIncrementSeed = 1;                                                              //设置数据列的自增种子为1；
            rowIdColumn.AutoIncrementStep = 1;                                                              //设置数据列的自增步长为1；
            this.CourseTable.Columns.Add(rowIdColumn);                                                      //数据列加入本窗体的课程数据表的列集合；
            sqlConnection.Open();                                                                           //打开SQL连接；
            sqlDataAdapter.Fill(this.CourseTable);                                                          //SQL数据适配器读取数据，并填充课程数据表；
            sqlConnection.Close();                                                                          //关闭SQL连接；
			this.MaxPageNo =
				(int)Math.Ceiling((double)this.CourseTable.Rows.Count / (double)this.PageSize);             //根据课程数据表的行集合的计数与每页大小，计算最大页号；
            this.CurrentPageView = new DataView();                                                          //实例化本窗体的课程数据视图，用于筛选当前页的记录；
            this.CurrentPageView.Table = this.CourseTable;                                                  //设置课程数据视图对应的数据表；
            this.CurrentPageView.Sort = "RowID ASC";                                                        //设置课程数据视图的排序条件，即行编号；
			this.RefreshRowFilter();																		//刷新行筛选条件，即筛选当前页的记录；
            this.dgv_Course.Columns.Clear();                                                                //数据网格视图的列集合清空；
            this.dgv_Course.DataSource = this.CurrentPageView;                                              //将数据网格视图的数据源设为当前页课程的视图；
            this.dgv_Course.Columns["No"].HeaderText = "学号";                                              //将数据网格视图的指定列的表头文本设为中文；
            this.dgv_Course.Columns["SName"].HeaderText = "姓名";
            this.dgv_Course.Columns["CName"].HeaderText = "课程";
            this.dgv_Course.Columns["TotalScore"].HeaderText = "总评成绩";
            this.dgv_Course.Columns["RowID"].Visible = false;                                               //将数据网格视图的指定列设为不可见；
            this.dgv_Course.Columns[this.dgv_Course.Columns.Count - 1].AutoSizeMode =                       //数据网格视图的最后一列的自动调整列宽模式设为填充（至数据网格视图右侧边缘）；
                DataGridViewAutoSizeColumnMode.Fill;
        }
        /// <summary>
        /// 点击上一页按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_PreviosPage_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageNo > 1)                                                                     //若当前页号大于1；
            {
                this.CurrentPageNo--;                                                                       //则当前页号递减；
            }
			this.RefreshRowFilter();                                                                        //刷新行筛选条件，即筛选当前页的记录；
		}
		/// <summary>
		/// 点击下一页按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_NextPage_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageNo < this.MaxPageNo)                                                        //若当前页号尚未超出最大页号；
            {
                this.CurrentPageNo++;                                                                       //则当前页号递增；
            }
			this.RefreshRowFilter();                                                                        //刷新行筛选条件，即筛选当前页的记录；
		}
	}                                                                                                    
}
