namespace Table_Pagination
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
			this.dgv_Student = new System.Windows.Forms.DataGridView();
			this.btn_Load = new System.Windows.Forms.Button();
			this.btn_PreviousPage = new System.Windows.Forms.Button();
			this.btn_NextPage = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv_Student
			// 
			this.dgv_Student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_Student.Location = new System.Drawing.Point(12, 12);
			this.dgv_Student.Name = "dgv_Student";
			this.dgv_Student.RowTemplate.Height = 23;
			this.dgv_Student.Size = new System.Drawing.Size(348, 280);
			this.dgv_Student.TabIndex = 50;
			// 
			// btn_Load
			// 
			this.btn_Load.Location = new System.Drawing.Point(12, 298);
			this.btn_Load.Name = "btn_Load";
			this.btn_Load.Size = new System.Drawing.Size(75, 23);
			this.btn_Load.TabIndex = 1;
			this.btn_Load.Text = "载入";
			this.btn_Load.UseVisualStyleBackColor = true;
			this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
			// 
			// btn_PreviousPage
			// 
			this.btn_PreviousPage.Location = new System.Drawing.Point(197, 298);
			this.btn_PreviousPage.Name = "btn_PreviousPage";
			this.btn_PreviousPage.Size = new System.Drawing.Size(75, 23);
			this.btn_PreviousPage.TabIndex = 51;
			this.btn_PreviousPage.Text = "上一页";
			this.btn_PreviousPage.UseVisualStyleBackColor = true;
			this.btn_PreviousPage.Click += new System.EventHandler(this.btn_PreviousPage_Click);
			// 
			// btn_NextPage
			// 
			this.btn_NextPage.Location = new System.Drawing.Point(285, 298);
			this.btn_NextPage.Name = "btn_NextPage";
			this.btn_NextPage.Size = new System.Drawing.Size(75, 23);
			this.btn_NextPage.TabIndex = 52;
			this.btn_NextPage.Text = "下一页";
			this.btn_NextPage.UseVisualStyleBackColor = true;
			this.btn_NextPage.Click += new System.EventHandler(this.btn_NextPage_Click);
			// 
			// frm_StudentInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(372, 333);
			this.Controls.Add(this.btn_NextPage);
			this.Controls.Add(this.btn_PreviousPage);
			this.Controls.Add(this.btn_Load);
			this.Controls.Add(this.dgv_Student);
			this.Name = "frm_StudentInfo";
			this.Text = "学生信息";
			((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Student;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btn_PreviousPage;
        private System.Windows.Forms.Button btn_NextPage;
    }
}