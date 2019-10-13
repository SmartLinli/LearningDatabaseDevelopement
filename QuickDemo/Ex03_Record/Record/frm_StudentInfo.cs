using SmartLinli.DatabaseDevelopement;
using System;
using System.Windows.Forms;

namespace Record
{
	/// <summary>
	/// 学生信息窗体；
	/// </summary>
	public partial class frm_StudentInfo : Form
    {
		/// <summary>
		/// 学号；
		/// </summary>
		private string _StudentNo;
        /// <summary>
        /// 构造函数；
        /// </summary>
        public frm_StudentInfo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
			this.FormClosing += (_, __) => Application.Exit();
        }
		/// <summary>
		/// 构造函数；
		/// </summary>
		/// <param name="studentNo">学号</param>
		public frm_StudentInfo(string studentNo):this()
		{
			this._StudentNo = studentNo;
		}
        /// <summary>
        /// 点击载入按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Load_Click(object sender, EventArgs e)
        {
			string commandText =
				$"SELECT * FROM tb_Student WHERE No='{this._StudentNo}';";
			SqlHelper sqlHelper = new SqlHelper();
			var studentReader = sqlHelper.NewCommand(commandText).ReturnReader();
            if (studentReader.Read())                                                                      
            {
                this.txb_No.Text = studentReader["No"].ToString();                                         
                this.txb_Name.Text = studentReader["Name"].ToString();
                this.txb_Gender.Text = studentReader["Gender"].ToString();
                this.txb_BirthDate.Text = ((DateTime)studentReader["BirthDate"]).ToShortDateString();      
                this.txb_Class.Text = studentReader["Class"].ToString();
                this.txb_Speciality.Text = studentReader["Speciality"].ToString();
            }
			studentReader.Close();                                                                         
        }
    }                                                                                                    
}
