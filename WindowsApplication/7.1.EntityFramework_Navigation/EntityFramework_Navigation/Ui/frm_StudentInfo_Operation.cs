using System.Windows.Forms;

namespace EntityFramework_Navigation
{
	/// <summary>
	/// 学生信息窗体；
	/// </summary>
	public partial class frm_StudentInfo : Form
	{
		/// <summary>
		/// 是否新建；
		/// </summary>
		private bool IsNew { get; set; }
		/// <summary>
		/// 学生
		/// </summary>
		private Student Student { get; set; }
		/// <summary>
		/// 初始化控件；
		/// </summary>
		private void InitializeControls()
		{
			this.StartPosition = FormStartPosition.CenterScreen;                          
			var classes = ClassRepository.FindAll();                                      
			this.cmb_Class.DataSource = classes;                                          
			this.cmb_Class.DisplayMember = "Name";                                        
			this.cmb_Class.ValueMember = "No";                                            
		}
		/// <summary>
		/// 载入学生；
		/// <param name="studentNo">学号</param>
		/// <param name="classNo">班级编号</param>
		/// </summary>
		private void LoadStudent(string studentNo, int classNo)
		{
			if (studentNo == null)                                                        
			{
				this.IsNew = true;
				this.Student = new Student();                                             
				this.cmb_Class.SelectedValue = classNo;                                   
				return;                                                                   
			}
			this.IsNew = false;
			this.Student = StudentRepository.Find(studentNo);                             
			this.txb_No.Text = this.Student.No;                                           
			this.txb_Name.Text = this.Student.Name;
			this.rdb_Male.Checked = this.Student.Gender;
			this.rdb_Female.Checked = !this.Student.Gender;
			this.dtp_BirthDate.Value = this.Student.BirthDate;
			this.cmb_Class.SelectedValue = this.Student.ClassNo;
			this.txb_Speciality.Text = this.Student.Speciality;
			this.ptb_Photo.Image = ImageTool.GetImage(this.Student.Photo);
		}
		/// <summary>
		/// 私有方法：打开照片；
		/// </summary>
		private void OpenPhoto()
		{
			OpenFileDialog openPictureDialog = new OpenFileDialog()                       
			{                                                                             
				Title = "打开图片文件（位图格式）",
				Filter = "BMP Files (*.bmp)|*.bmp",
				InitialDirectory = @"D:\"                                                 
			};
			if (openPictureDialog.ShowDialog() == DialogResult.OK)                        
			{
				this.Student.Photo = ImageTool.GetBytes(openPictureDialog.FileName);      
				this.ptb_Photo.Image = ImageTool.GetImage(this.Student.Photo);            
			}
		}
		/// <summary>
		/// 私有方法：提交；
		/// </summary>
		private void Submit()
		{
			this.Student.No = this.txb_No.Text;                                           
			this.Student.Name = this.txb_Name.Text.Trim();                                
			this.Student.Gender = this.rdb_Male.Checked;
			this.Student.BirthDate = this.dtp_BirthDate.Value;
			this.Student.ClassNo = (int)this.cmb_Class.SelectedValue;
			this.Student.Speciality = this.txb_Speciality.Text.Trim();
			int rowAffected = 0;
			if (this.IsNew)
			{
				rowAffected = StudentRepository.Add(this.Student);
			}
			else
			{
				rowAffected = StudentRepository.Update(this.Student);
			}
			if (rowAffected > 0)                                                          
			{
				MessageBox.Show("提交成功。");                                             
			}
			else
			{
				MessageBox.Show("提交失败！");
			}
		}
	}
}
