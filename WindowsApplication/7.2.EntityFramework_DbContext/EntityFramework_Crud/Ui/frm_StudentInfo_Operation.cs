using System.Linq;
using System.Windows.Forms;

namespace EntityFramework_Crud
{
	/// <summary>
	/// 学生信息窗体；
	/// </summary>
	public partial class frm_StudentInfo : Form
    {
		/// <summary>
		/// 是否新建；
		/// </summary>
		private bool IsNew;
        /// <summary>
        /// 学生
        /// </summary>
        private Student Student;
        /// <summary>
        /// 数据库上下文；
        /// </summary>
        private EduBase EduBase;
        /// <summary>
        /// 初始化控件；
        /// </summary>
        private void InitializeControls()
        {
            this.StartPosition = FormStartPosition.CenterScreen;                                        //本窗体启动位置设为屏幕中央；
            this.EduBase = new EduBase();                                                               //实例化数据库上下文；
            var classes =ClassRepository.FindAll();                                                                       //匿名类型的成员包括班级编号、名称；
            this.cmb_Class.DataSource = classes;                                              //将所有班级转为数组，设为下拉框的数据源；
			this.cmb_Class.DisplayMember = "Name";                                                      //将下拉框的显示成员设为班级名称；
            this.cmb_Class.ValueMember = "No";                                                          //将下拉框的值成员设为班级编号；
        }
        /// <summary>
        /// 载入学生；
        /// <param name="studentNo">学号</param>
        /// <param name="classNo">班级编号</param>
        /// </summary>
        private void LoadStudent(string studentNo, int classNo)
        {
            if (studentNo == null)                                                                      //若传入的学号为空，即学生为新建；
            {
				this.IsNew = true;
                this.Student = new Student();                                                                    //学生设为空；
                this.cmb_Class.SelectedValue = classNo;                                                 //将下拉框的选中值设为班级编号；
                return;                                                                                 //返回；
            }
			this.IsNew = false;
            this.Student = StudentRepository.Find(studentNo);                                                          //由于查询返回集合，故需获取其中首个元素，即满足条件的唯一学生；
            this.txb_No.Text = this.Student.No;                                                         //逐一将各控件的文本、值设为学生的各属性；
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
            OpenFileDialog openPictureDialog = new OpenFileDialog()                                     //声明并实例化打开文件对话框；
            {                                                                                           //在初始化器中，设置打开文件对话框的各属性；
                Title = "打开图片文件（位图格式）"														//对话框标题；
                , Filter = "BMP Files (*.bmp)|*.bmp"                                                    //文件格式过滤器；
                , InitialDirectory = @"D:\"                                                             //初始目录；
            };
            if (openPictureDialog.ShowDialog() == DialogResult.OK)                                      //显示打开文件对话框，若打开文件对话框的对话结果为点击OK键；
            {
                this.Student.Photo = ImageTool.GetBytes(openPictureDialog.FileName);                    //读取图片文件，并设为学生照片；
                this.ptb_Photo.Image = ImageTool.GetImage(this.Student.Photo);                          //从学生照片中读取图像，并将之赋予本窗体的图像框的图像属性；
            }
        }
        /// <summary>
        /// 私有方法：提交；
        /// </summary>
        private void Submit()
        {
            //if (this.Student == null)                                                                   //若学生为空，即学生为新建；
            //{
            //    this.Student = new Student();                                                           //实例化学生对象；
                this.Student.No = this.txb_No.Text;                                                     //设置学号；
            //}
            this.Student.Name = this.txb_Name.Text.Trim();                                              //逐一将学生的各属性设为各控件的文本、值；
            this.Student.Gender = this.rdb_Male.Checked;
            this.Student.BirthDate = this.dtp_BirthDate.Value;
			this.Student.ClassNo= (int)this.cmb_Class.SelectedValue;
			this.Student.Speciality = this.txb_Speciality.Text.Trim();
			int rowsAffected = 0;
			if (this.IsNew)
			{
				rowsAffected=StudentRepository.Insert(this.Student);
			}
			else
			{
				rowsAffected=StudentRepository.Update(this.Student);
			}
            if (rowsAffected > 0)                                                                       //若受影响行数大于0；
            {
                MessageBox.Show("提交成功。");															//显示消息；
            }
            else
            {
                MessageBox.Show("提交失败！");
            }
        }
    }
}
