using System;
using System.Data;
using System.Data.SqlClient;                                                                                //包含访问SQL Server所需的各类对象；
using System.Windows.Forms;

namespace Ex51_Table_Adapter
{
	public partial class frm_StudentTable : Form
    {
        /// <summary>
        /// 公有方法：构造函数；
        /// </summary>
        public frm_StudentTable()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                                            //本窗体启动位置设为屏幕中央； 
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
            sqlCommand.CommandText = "SELECT * FROM tb_Student;";                                           //指定SQL命令的命令文本；该命令查询所有学生；
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                           //声明并实例化SQL数据适配器；
            sqlDataAdapter.SelectCommand = sqlCommand;                                                      //将SQL数据适配器的查询命令属性指向SQL命令；
            DataTable studentTable = new DataTable();                                                       //声明并实例化数据表，用于保存所有学生，以用作数据网格视图的数据源；
            sqlConnection.Open();                                                                           //打开SQL连接；
            sqlDataAdapter.Fill(studentTable);                                                              //SQL数据适配器读取数据，并填充学生数据表；
            sqlConnection.Close();                                                                          //关闭SQL连接；
            this.dgv_Student.DataSource = studentTable;                                                     //将数据网格视图的数据源设为学生数据表；
        }
        
        /// <summary>
        /// 私有方法：点击提交按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                              //声明并实例化SQL连接；
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBaseDemo;Integrated Security=sspi";                             //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
            SqlCommand insertCommand = new SqlCommand();                                                    //声明并实例化SQL命令；该命令用于插入记录；
            insertCommand.Connection = sqlConnection;                                                       //将SQL命令的连接属性指向SQL连接；
            insertCommand.CommandText =                                                                     //指定SQL命令的命令文本；
                "INSERT tb_Student"
                + "(No,Name,Gender,BirthDate,Class,Speciality)"
                + " VALUES(@No,@Name,@Gender,@BirthDate,@Class,@Speciality);";
            insertCommand.Parameters.Add("@No", SqlDbType.Char, 10, "No");                                  //向SQL命令的参数集合添加参数的名称、SQL Server数据类型、长度（仅用于定长类型）、所绑定的数据表中的列名；
            insertCommand.Parameters.Add("@Name", SqlDbType.VarChar, 0, "Name");                                 
            insertCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 0, "Gender");
            insertCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar, 0, "BirthDate");
            insertCommand.Parameters.Add("@Class", SqlDbType.VarChar, 0, "Class");
            insertCommand.Parameters.Add("@Speciality", SqlDbType.VarChar, 0, "Speciality");
            SqlCommand updateCommand = new SqlCommand();                                                    //声明并实例化SQL命令；该命令用于更新记录；
            updateCommand.Connection = sqlConnection;                                                       //将SQL命令的连接属性指向SQL连接；
            updateCommand.CommandText =                                                                     //指定SQL命令的命令文本；
                "UPDATE tb_Student"
                + " SET No=@NewNo,Name=@Name,Gender=@Gender,BirthDate=@BirthDate,Class=@Class,Speciality=@Speciality"
                + " WHERE No=@OldNo;";
            updateCommand.Parameters.Add("@NewNo", SqlDbType.Char, 10, "No");                               //向SQL命令的参数集合添加参数的名称、SQL Server数据类型、长度（仅用于定长类型）、所绑定的数据表中的列名；
            updateCommand.Parameters.Add("@Name",SqlDbType.VarChar,0,"Name");                              
            updateCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 0, "Gender");
            updateCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar, 0, "BirthDate");
            updateCommand.Parameters.Add("@Class", SqlDbType.VarChar, 0, "Class");
            updateCommand.Parameters.Add("@Speciality", SqlDbType.VarChar, 0, "Speciality");
            updateCommand.Parameters.Add("@OldNo", SqlDbType.Char, 10, "No");                               //若学号发生更改，则还需提供旧学号，以便查询要更改的行；
            updateCommand.Parameters["@OldNo"].SourceVersion = DataRowVersion.Original;                     //旧学号的来源版本，为数据行版本中的原始值；
            SqlCommand deleteCommand = new SqlCommand();                                                    //声明并实例化SQL命令；该命令用于删除；
            deleteCommand.Connection = sqlConnection;                                                       //将SQL命令的连接属性指向SQL连接；
            deleteCommand.CommandText =                                                                     //指定SQL命令的命令文本；
                "DELETE tb_Student"
                + " WHERE No=@No;";
            deleteCommand.Parameters.Add("@No", SqlDbType.Char, 10, "No");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                           //声明并实例化SQL数据适配器；
            sqlDataAdapter.InsertCommand = insertCommand;                                                   //将SQL数据适配器的属性InsertCommand指向用于插入记录的SQL命令；
            sqlDataAdapter.UpdateCommand = updateCommand;                                                   //将SQL数据适配器的属性UpdateCommand指向用于更新记录的SQL命令；
            sqlDataAdapter.DeleteCommand = deleteCommand;                                                   //将SQL数据适配器的属性DeleteCommand指向用于删除记录的SQL命令；
			DataTable studentTable = this.dgv_Student.DataSource as DataTable;                              //声明数据表，并指向数据网格视图的数据源；数据源默认类型为object，还需强制转换类型；
            sqlConnection.Open();                                                                           //打开SQL连接；
            int rowAffected = sqlDataAdapter.Update(studentTable);                                          //SQL数据适配器根据学生数据表提交所有更新，并返回受影响行数；
            sqlConnection.Close();                                                                          //关闭SQL连接；
			MessageBox.Show($"更新{rowAffected}行。");														//在消息框显示受影响行数；
        }
    }                                                                                                    
}
