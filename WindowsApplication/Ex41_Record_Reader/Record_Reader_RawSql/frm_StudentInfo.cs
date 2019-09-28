using SmartLinli.DatabaseDevelopement;
using System;
using System.Windows.Forms;

namespace Record_Reader_RawSql
{
	public partial class frm_StudentInfo : Form
    {
        /// <summary>
        /// 公有方法：构造函数；
        /// </summary>
        public frm_StudentInfo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                                            
        }
		/// <summary>
		/// 私有方法：点击载入按钮；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Load_Click(object sender, EventArgs e)
        {
			var dbHelper = new SqlHelper();
			var dataReader = dbHelper
				.NewCommand("SELECT * FROM Student WHERE No=@No;")
				.With("@No", "3120707001")
				.GetReader();                                      
            if (dataReader.Read())                                                                       
            {
                this.txb_No.Text = dataReader["No"].ToString();                                          
                this.txb_Name.Text = dataReader["Name"].ToString();
                this.txb_Gender.Text = dataReader["Gender"].ToString();
                this.txb_BirthDate.Text = ((DateTime)dataReader["BirthDate"]).ToShortDateString();       
                this.txb_Class.Text = dataReader["Class"].ToString();
                this.txb_Speciality.Text = dataReader["Speciality"].ToString();
            }
			dataReader.Close();                                                                          
        }
    }                                                                                                    
}
