using System;
using System.Data;
using System.Data.SqlClient;                                                                                //包含访问SQL Server所需的各类对象；
using System.Drawing;
using System.Windows.Forms;

namespace Table_GridView
{
	public partial class frm_StudentTable : Form
    {
        /// <summary>
        /// 私有字段：学生表；
        /// </summary>
        private DataTable StudentTable;        
        /// <summary>
        /// 公有方法：构造函数；
        /// </summary>
        public frm_StudentTable()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                                            //本窗体启动位置设为屏幕中央； 
            this.dgv_Score.AllowUserToAddRows = false;                                                      //数据网格视图不允许用户添加行；
            this.dgv_Score.RowHeadersVisible = false;                                                       //数据网格视图的行标题不可见；
            this.dgv_Score.BackgroundColor = Color.White;                                                   //数据网格视图的背景色设为白色；
            this.dgv_Score.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;                                                   //数据网格视图的自动调整列宽模式设为（显示）所有单元格；
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
            sqlCommand.CommandText = "SELECT * FROM tb_Class;";                                             //指定SQL命令的命令文本；该命令查询所有班级，以用作下拉框数据源；
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                           //声明并实例化SQL数据适配器；
            sqlDataAdapter.SelectCommand = sqlCommand;                                                      //将SQL数据适配器的查询命令属性指向SQL命令；
            DataTable classTable = new DataTable();                                                         //声明并实例化数据表，用于保存所有班级，以用作下拉框数据源；
            DataTable studentTable = new DataTable();                                                       //声明并实例化数据表，用于保存所有学生，以用作数据网格视图的数据源；
            sqlConnection.Open();                                                                           //打开SQL连接；
            sqlDataAdapter.Fill(classTable);                                                                //SQL数据适配器读取数据，并填充班级数据表；
            sqlCommand.CommandText = "SELECT * FROM tb_Student;";                                           //指定SQL命令的命令文本；该命令查询所有学生；
            sqlDataAdapter.Fill(studentTable);                                                              //SQL数据适配器读取数据，并填充学生数据表；
            sqlConnection.Close();                                                                          //关闭SQL连接；
            this.StudentTable = studentTable;                                                               //将学生表赋予本窗体的相应私有字段，便于其它方法访问；
            this.dgv_Score.Columns.Clear();                                                                 //数据网格视图的列集合清空；
            this.dgv_Score.DataSource = studentTable;                                                       //将数据网格视图的数据源设为学生数据表；
            this.dgv_Score.Columns["No"].ReadOnly = true;                                                   //将数据网格视图的指定列设为只读；
            this.dgv_Score.Columns["No"].HeaderText = "学号";                                               //将数据网格视图的指定列的表头文本设为中文；
            this.dgv_Score.Columns["Name"].HeaderText = "姓名";
            this.dgv_Score.Columns["Gender"].HeaderText = "性别";
            this.dgv_Score.Columns["BirthDate"].HeaderText = "生日";
            this.dgv_Score.Columns["Speciality"].HeaderText = "特长";
            this.dgv_Score.Columns["Photo"].HeaderText = "照片";
            this.dgv_Score.Columns["ClassNo"].Visible = false;                                              //将数据网格视图的指定列设为不可见；
            DataGridViewComboBoxColumn classColumn = new DataGridViewComboBoxColumn();                      //声明并实例化数据网格视图下拉框列，用于设置学生的班级；
            this.dgv_Score.Columns.Add(classColumn);                                                        //将下拉框列加入数据网格视图的列集合；
            classColumn.Name = "Class";                                                                     //设置下拉框列的名称；
            classColumn.HeaderText = "班级";                                                                //设置下拉框列的表头文本；
            classColumn.DataSource = classTable;                                                            //设置下拉框列的数据源为班级数据表；
            classColumn.DisplayMember = "Name";                                                             //设置下拉框列的显示成员为（班级数据表的）名称（列）；
            classColumn.ValueMember = "No";                                                                 //设置下拉框列的值成员为（班级数据表的）编号（列）；
            classColumn.DataPropertyName = "ClassNo";                                                       //设置下拉框列的数据属性名称为（学生数据表的）班级编号（列）；
            classColumn.DisplayIndex = 4;                                                                   //设置下拉框列的显示顺序；
            classColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;                             //设置下拉框列的自动调整列宽模式为（显示）所有单元格；
            this.dgv_Score.Columns[this.dgv_Score.Columns.Count - 2].AutoSizeMode =                         //数据网格视图的倒数第2列（即照片列）的自动调整列宽模式设为填充（至数据网格视图右侧边缘）；
                DataGridViewAutoSizeColumnMode.Fill;
        }        
        /// <summary>
        /// 私有方法：点击更新按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                              //声明并实例化SQL连接；
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                             //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
            SqlCommand sqlCommand = new SqlCommand();                                                       //声明并实例化SQL命令；
            sqlCommand.Connection = sqlConnection;                                                          //将SQL命令的连接属性指向SQL连接；
            sqlCommand.CommandText =                                                                        //指定SQL命令的命令文本；
                "UPDATE tb_Student"
                + " SET Name=@Name,Gender=@Gender,BirthDate=@BirthDate,ClassNo=@ClassNo,Speciality=@Speciality"
                + " WHERE No=@No;";
            sqlCommand.Parameters.Add("@Name",SqlDbType.VarChar,0,"Name");                                  //向SQL命令的参数集合添加参数的名称、SQL Server数据类型、长度（仅用于定长类型）、所绑定的数据表中的列名；
            sqlCommand.Parameters.Add("@Gender", SqlDbType.Bit, 0, "Gender");
            sqlCommand.Parameters.Add("@BirthDate", SqlDbType.Date, 0, "BirthDate");
            sqlCommand.Parameters.Add("@ClassNo", SqlDbType.Int, 0, "ClassNo");
            sqlCommand.Parameters.Add("@Speciality", SqlDbType.VarChar, 0, "Speciality");
            sqlCommand.Parameters.Add("@No", SqlDbType.Char, 10, "No");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                           //声明并实例化SQL数据适配器，同时借助构造函数，将其SelectCommand属性设为先前创建的SQL命令；
            sqlDataAdapter.UpdateCommand = sqlCommand;                                                      //将SQL数据适配器的更新命令属性指向SQL命令；
            DataTable studentTable = this.StudentTable;                                                     //声明数据表，并指向本窗体的相应私有字段；
            sqlConnection.Open();                                                                           //打开SQL连接；
            int rowAffected = sqlDataAdapter.Update(studentTable);                                          //SQL数据适配器根据学生数据表提交更新，并返回受影响行数；
            sqlConnection.Close();                                                                          //关闭SQL连接；
            MessageBox.Show("更新" + rowAffected.ToString() + "行。");                                      //在消息框显示受影响行数；
        }
    }                                                                                                    
}
