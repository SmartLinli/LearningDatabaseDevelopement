using System;
using System.Data;
using System.Data.SqlClient;                                                                                //包含访问SQL Server所需的各类对象；
using System.Drawing;
using System.Windows.Forms;

namespace Table_Row
{
	public partial class frm_CourseSelection : Form
    {
		/// <summary>
		/// 学号；
		/// </summary>
		private string StudentNo = "3180707001";
        /// <summary>
        /// 课程数据表；
        /// </summary>
        private DataTable CourseTable;
        /// <summary>
        /// 已选课程数据表；
        /// </summary>
        private DataTable SelectedCourseTable;
        /// <summary>
        /// 构造函数；
        /// </summary>
        public frm_CourseSelection()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                                            //本窗体启动位置设为屏幕中央； 
            this.dgv_Course.ReadOnly = true;                                                                //课程数据网格视图设为只读；
            this.dgv_Course.AllowUserToAddRows = false;                                                     //课程数据网格视图不允许用户添加行；
            this.dgv_Course.RowHeadersVisible = false;                                                      //课程数据网格视图的行标题不可见；
            this.dgv_Course.BackgroundColor = Color.White;                                                  //课程数据网格视图的背景色设为白色；
            this.dgv_Course.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;                                                   //课程数据网格视图的自动调整列宽模式设为显示所有单元格；
            this.dgv_SelectedCourse.AllowUserToAddRows = false;                                             //已选课程数据网格视图不允许用户添加行；
            this.dgv_SelectedCourse.RowHeadersVisible = false;                                              //已选课程数据网格视图的行标题不可见；
            this.dgv_SelectedCourse.BackgroundColor = Color.LightBlue;                                      //已选课程数据网格视图的背景色设为白色；
            this.dgv_SelectedCourse.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;                                                   //已选课程数据网格视图的自动调整列宽模式设为显示所有单元格；
        }
        /// <summary>
        /// 点击载入按钮；
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
            sqlCommand.CommandText =
                @"SELECT No,Name,Credit FROM tb_Course WHERE No NOT IN
					(SELECT CourseNo FROM tb_SelectedCourse WHERE StudentNo=@StudentNo);";                  //指定SQL命令的命令文本；该命令查询学生尚未选修的课程，以用作数据网格视图数据源；
            sqlCommand.Parameters.AddWithValue("@StudentNo", this.StudentNo);                               //向SQL命令的参数集合添加参数的名称、SQL Server数据类型、长度（仅用于定长类型）、所绑定的数据表中的列名；
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                           //声明并实例化SQL数据适配器；
            sqlDataAdapter.SelectCommand = sqlCommand;                                                      //将SQL数据适配器的查询命令属性指向SQL命令；
            this.CourseTable = new DataTable();                                                             //实例化本窗体的课程数据表，用于保存所有课程，以用作数据网格视图数据源；
            this.SelectedCourseTable = new DataTable();                                                     //实例化本窗体的已选课程数据表，用于保存学生已选修课程，以用作数据网格视图数据源；
            sqlConnection.Open();                                                                           //打开SQL连接；
            sqlDataAdapter.Fill(this.CourseTable);                                                          //SQL数据适配器读取数据，并填充课程数据表；
            sqlCommand.CommandText =
                @"SELECT C.No,C.Name,C.Credit,SC.OrderBook
					FROM tb_Course AS C JOIN tb_SelectedCourse AS SC ON C.No=SC.CourseNo
					WHERE SC.StudentNo=@StudentNo;";                                                        //指定SQL命令的命令文本；该命令查询学生已选修的课程，以用作数据网格视图数据源；
            sqlDataAdapter.Fill(this.SelectedCourseTable);                                                  //SQL数据适配器读取数据，并填充已选课程数据表；
            sqlConnection.Close();                                                                          //关闭SQL连接；
            this.dgv_Course.Columns.Clear();                                                                //课程数据网格视图的列集合清空；
            this.dgv_Course.DataSource = this.CourseTable;                                                  //将数据网格视图的数据源设为学生数据表；
            this.dgv_Course.Columns["No"].HeaderText = "编号";                                              //将数据网格视图的指定列的表头文本设为中文；
            this.dgv_Course.Columns["Name"].HeaderText = "名称";
            this.dgv_Course.Columns["Credit"].HeaderText = "学分";
            this.dgv_Course.Columns[this.dgv_Course.Columns.Count - 1].AutoSizeMode =                       //数据网格视图的最后一列的自动调整列宽模式设为填充（至数据网格视图右侧边缘）；
                DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_SelectedCourse.Columns.Clear();                                                        //已选课程数据网格视图的列集合清空；
            this.dgv_SelectedCourse.DataSource = this.SelectedCourseTable;                                  //将数据网格视图的数据源设为学生数据表；
            this.dgv_SelectedCourse.Columns["No"].HeaderText = "编号";                                      //将数据网格视图的指定列的表头文本设为中文；
            this.dgv_SelectedCourse.Columns["Name"].HeaderText = "名称";
            this.dgv_SelectedCourse.Columns["Credit"].HeaderText = "学分";
            this.dgv_SelectedCourse.Columns["OrderBook"].HeaderText = "订购课本";
            this.dgv_SelectedCourse.Columns[this.dgv_SelectedCourse.Columns.Count - 1].AutoSizeMode =       //数据网格视图的最后一列的自动调整列宽模式设为填充（至数据网格视图右侧边缘）；
                DataGridViewAutoSizeColumnMode.Fill;
            this.lbl_CreditSum.Text =                                                                       //在标签中显示已选课程的学分总和；
                $"共{this.SelectedCourseTable.Compute("SUM(Credit)", "")}学分";								//借助已选课程数据表的方法Compute，实现简单计算，例如聚合；
        }
        /// <summary>
        /// 点击添加按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
			if (this.dgv_Course.RowCount == 0)                                                              //若课程数据网格视图内的行计数等于0；
				return;                                                                                     //返回；
			DataRowView currentCourseRowView = 
				this.dgv_Course.CurrentRow.DataBoundItem as DataRowView;									//将课程数据网格视图的当前行的数据绑定项，转换为数据行视图；
			DataRow                                                                                         //声明数据行；
				currentCourseRow = currentCourseRowView.Row													//通过当前的数据行视图，获取其相应的数据行；
                , selectedCourseRow = this.SelectedCourseTable.NewRow();									//已选课程数据行则通过已选课程数据表的方法NewRow来新建；随后该行的状态为分离；
            selectedCourseRow["No"] = currentCourseRow["No"];												//逐一将当前课程数据行的各列值，赋予已选课程数据行的相应列；
            selectedCourseRow["Name"] = currentCourseRow["Name"];
            selectedCourseRow["Credit"] = currentCourseRow["Credit"];
            this.SelectedCourseTable.Rows.Add(selectedCourseRow);											//已选课程数据行加入已选课程数据表；随后该行的状态为添加；此处不可用数据表的ImportRow方法替代，后者无法改变行的分离状态；
            currentCourseRow.Delete();																		//当前课程数据行删除；随后该行的状态为删除；
            this.lbl_CreditSum.Text =																		//在标签中显示已选课程的学分总和；
                $"共{this.SelectedCourseTable.Compute("SUM(Credit)", "")}学分";								//借助已选课程数据表的方法Compute，实现简单计算，例如聚合；
        }
        /// <summary>
        /// 点击移除按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Remove_Click(object sender, EventArgs e)
        {
			if (this.dgv_SelectedCourse.RowCount == 0)                                                      //若已选课程数据网格视图内的行计数等于0；
				return;                                                                                     //返回；
			DataRowView selectedCourseRowView = 
				this.dgv_SelectedCourse.CurrentRow.DataBoundItem as DataRowView;                            //将已选课程数据网格视图的当前行的数据绑定项，转换为数据行视图；
			DataRow selectedCourseRow = selectedCourseRowView.Row;                                          //通过当前的数据行视图，获取其相应的数据行；
			if (selectedCourseRow.RowState != DataRowState.Added)											//若已选课程数据行的行状态并非添加；
				return;																						//返回；
			string courseNo = selectedCourseRow["No"].ToString();											//获取当前课程数据行的课程编号；
            DataRow deletedCourseRow =																		//声明已删课程数据行（即先前从课程数据表中删除的数据行）；
                this.CourseTable.Select($"No='{courseNo}'", "", DataViewRowState.Deleted)[0];			//已删课程数据行可通过课程数据表的方法Select查得，该方法接受查询条件、排序条件、行状态条件等参数，并返回数据行数组；
            deletedCourseRow.RejectChanges();																//已删课程数据行拒绝更改，即回滚先前对其执行的删除；随后该行的状态为未更改；
            this.SelectedCourseTable.Rows.Remove(selectedCourseRow);										//从已选课程数据表的行集合中移除当前课程数据行；随后该行的状态为分离；
            this.lbl_CreditSum.Text =																		//在标签中显示已选课程的学分总和；
                $"共{this.SelectedCourseTable.Compute("SUM(Credit)", "")}学分";								//借助已选课程数据表的方法Compute，实现简单计算，例如聚合；
        }
        /// <summary>
        /// 点击提交按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                              //声明并实例化SQL连接；
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                             //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
            SqlCommand insertCommand = new SqlCommand();                                                    //声明并实例化用于插入的SQL命令；
            insertCommand.Connection = sqlConnection;                                                       //将SQL命令的连接属性指向SQL连接；
            insertCommand.CommandText =
                @"INSERT tb_SelectedCourse(StudentNo,CourseNo,OrderBook)
					VALUES(@StudentNo,@CourseNo,@OrderBook);";                                              //指定SQL命令的命令文本；该命令插入选课记录；
            insertCommand.Parameters.AddWithValue("@StudentNo", this.StudentNo);                            //向SQL命令的参数集合添加参数的名称、SQL Server数据类型、长度（仅用于定长类型）、所绑定的数据表中的列名；
            insertCommand.Parameters.Add("@CourseNo", SqlDbType.Char, 4, "No");
            insertCommand.Parameters.Add("@OrderBook", SqlDbType.Bit, 0, "OrderBook");
            SqlCommand updateCommand = new SqlCommand();                                                    //声明并实例化用于更新（教材订购状态）的SQL命令；
            updateCommand.Connection = sqlConnection;                                                       //将SQL命令的连接属性指向SQL连接；
            updateCommand.CommandText =                                                                     //指定SQL命令的命令文本；该命令更新教材订购状态；
                @"UPDATE tb_SelectedCourse
					SET OrderBook=@OrderBook
					WHERE StudentNo=@StudentNo AND CourseNo=@CourseNo;";
            updateCommand.Parameters.AddWithValue("@StudentNo", this.StudentNo);                            //向SQL命令的参数集合添加参数的名称、SQL Server数据类型、长度（仅用于定长类型）、所绑定的数据表中的列名；
            updateCommand.Parameters.Add("@CourseNo", SqlDbType.Char, 4, "No");
            updateCommand.Parameters.Add("@OrderBook", SqlDbType.Bit, 0, "OrderBook");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                           //声明并实例化SQL数据适配器；
            sqlDataAdapter.InsertCommand = insertCommand;                                                   //将SQL数据适配器的插入命令属性指向SQL命令；
            sqlDataAdapter.UpdateCommand = updateCommand;                                                   //将SQL数据适配器的更新命令属性指向SQL命令；
            sqlConnection.Open();                                                                           //打开SQL连接；
            int rowAffected = sqlDataAdapter.Update(this.SelectedCourseTable);                              //SQL数据适配器根据学生数据表提交更新，并返回受影响行数；
            sqlConnection.Close();                                                                          //关闭SQL连接；
            MessageBox.Show($"提交{rowAffected}行。");														//在消息框显示受影响行数；
        }
    }
}
