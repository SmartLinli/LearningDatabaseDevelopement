namespace Ex41_Record_Reader
{
    partial class frm_StudentInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.lbl_No = new System.Windows.Forms.Label();
			this.lbl_Name = new System.Windows.Forms.Label();
			this.lbl_Gender = new System.Windows.Forms.Label();
			this.lbl_BirthDate = new System.Windows.Forms.Label();
			this.lbl_Class = new System.Windows.Forms.Label();
			this.lbl_Specialty = new System.Windows.Forms.Label();
			this.txb_No = new System.Windows.Forms.TextBox();
			this.txb_Name = new System.Windows.Forms.TextBox();
			this.txb_Speciality = new System.Windows.Forms.TextBox();
			this.txb_Class = new System.Windows.Forms.TextBox();
			this.txb_BirthDate = new System.Windows.Forms.TextBox();
			this.txb_Gender = new System.Windows.Forms.TextBox();
			this.btn_Load = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbl_No
			// 
			this.lbl_No.AutoSize = true;
			this.lbl_No.Location = new System.Drawing.Point(30, 26);
			this.lbl_No.Name = "lbl_No";
			this.lbl_No.Size = new System.Drawing.Size(41, 12);
			this.lbl_No.TabIndex = 0;
			this.lbl_No.Text = "学号：";
			// 
			// lbl_Name
			// 
			this.lbl_Name.AutoSize = true;
			this.lbl_Name.Location = new System.Drawing.Point(30, 59);
			this.lbl_Name.Name = "lbl_Name";
			this.lbl_Name.Size = new System.Drawing.Size(41, 12);
			this.lbl_Name.TabIndex = 1;
			this.lbl_Name.Text = "姓名：";
			// 
			// lbl_Gender
			// 
			this.lbl_Gender.AutoSize = true;
			this.lbl_Gender.Location = new System.Drawing.Point(30, 92);
			this.lbl_Gender.Name = "lbl_Gender";
			this.lbl_Gender.Size = new System.Drawing.Size(41, 12);
			this.lbl_Gender.TabIndex = 2;
			this.lbl_Gender.Text = "性别：";
			// 
			// lbl_BirthDate
			// 
			this.lbl_BirthDate.AutoSize = true;
			this.lbl_BirthDate.Location = new System.Drawing.Point(174, 26);
			this.lbl_BirthDate.Name = "lbl_BirthDate";
			this.lbl_BirthDate.Size = new System.Drawing.Size(41, 12);
			this.lbl_BirthDate.TabIndex = 3;
			this.lbl_BirthDate.Text = "生日：";
			// 
			// lbl_Class
			// 
			this.lbl_Class.AutoSize = true;
			this.lbl_Class.Location = new System.Drawing.Point(174, 59);
			this.lbl_Class.Name = "lbl_Class";
			this.lbl_Class.Size = new System.Drawing.Size(41, 12);
			this.lbl_Class.TabIndex = 4;
			this.lbl_Class.Text = "班级：";
			// 
			// lbl_Specialty
			// 
			this.lbl_Specialty.AutoSize = true;
			this.lbl_Specialty.Location = new System.Drawing.Point(174, 92);
			this.lbl_Specialty.Name = "lbl_Specialty";
			this.lbl_Specialty.Size = new System.Drawing.Size(41, 12);
			this.lbl_Specialty.TabIndex = 15;
			this.lbl_Specialty.Text = "特长：";
			// 
			// txb_No
			// 
			this.txb_No.Location = new System.Drawing.Point(77, 23);
			this.txb_No.Name = "txb_No";
			this.txb_No.Size = new System.Drawing.Size(74, 21);
			this.txb_No.TabIndex = 17;
			// 
			// txb_Name
			// 
			this.txb_Name.Location = new System.Drawing.Point(77, 56);
			this.txb_Name.Name = "txb_Name";
			this.txb_Name.Size = new System.Drawing.Size(74, 21);
			this.txb_Name.TabIndex = 18;
			// 
			// txb_Speciality
			// 
			this.txb_Speciality.Location = new System.Drawing.Point(221, 89);
			this.txb_Speciality.Name = "txb_Speciality";
			this.txb_Speciality.Size = new System.Drawing.Size(74, 21);
			this.txb_Speciality.TabIndex = 32;
			// 
			// txb_Class
			// 
			this.txb_Class.Location = new System.Drawing.Point(221, 56);
			this.txb_Class.Name = "txb_Class";
			this.txb_Class.Size = new System.Drawing.Size(74, 21);
			this.txb_Class.TabIndex = 44;
			// 
			// txb_BirthDate
			// 
			this.txb_BirthDate.Location = new System.Drawing.Point(221, 23);
			this.txb_BirthDate.Name = "txb_BirthDate";
			this.txb_BirthDate.Size = new System.Drawing.Size(74, 21);
			this.txb_BirthDate.TabIndex = 43;
			// 
			// txb_Gender
			// 
			this.txb_Gender.Location = new System.Drawing.Point(77, 89);
			this.txb_Gender.Name = "txb_Gender";
			this.txb_Gender.Size = new System.Drawing.Size(36, 21);
			this.txb_Gender.TabIndex = 42;
			// 
			// btn_Load
			// 
			this.btn_Load.Location = new System.Drawing.Point(221, 124);
			this.btn_Load.Name = "btn_Load";
			this.btn_Load.Size = new System.Drawing.Size(75, 23);
			this.btn_Load.TabIndex = 45;
			this.btn_Load.Text = "载入";
			this.btn_Load.UseVisualStyleBackColor = true;
			this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
			// 
			// frm_StudentInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(333, 159);
			this.Controls.Add(this.btn_Load);
			this.Controls.Add(this.txb_No);
			this.Controls.Add(this.txb_Name);
			this.Controls.Add(this.txb_Class);
			this.Controls.Add(this.txb_Speciality);
			this.Controls.Add(this.txb_BirthDate);
			this.Controls.Add(this.txb_Gender);
			this.Controls.Add(this.lbl_No);
			this.Controls.Add(this.lbl_Name);
			this.Controls.Add(this.lbl_Class);
			this.Controls.Add(this.lbl_Gender);
			this.Controls.Add(this.lbl_BirthDate);
			this.Controls.Add(this.lbl_Specialty);
			this.Name = "frm_StudentInfo";
			this.Text = "学生信息";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_No;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Gender;
        private System.Windows.Forms.Label lbl_BirthDate;
        private System.Windows.Forms.Label lbl_Class;
        private System.Windows.Forms.Label lbl_Specialty;
        private System.Windows.Forms.TextBox txb_No;
        private System.Windows.Forms.TextBox txb_Name;
        private System.Windows.Forms.TextBox txb_Speciality;
        private System.Windows.Forms.TextBox txb_BirthDate;
        private System.Windows.Forms.TextBox txb_Gender;
        private System.Windows.Forms.TextBox txb_Class;
        private System.Windows.Forms.Button btn_Load;
    }
}