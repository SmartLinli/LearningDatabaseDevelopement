namespace EntityFramework_Navigation
{
    partial class frm_EducationManagement
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
			this.trv_EducationUnit = new System.Windows.Forms.TreeView();
			this.dgv_Student = new System.Windows.Forms.DataGridView();
			this.btn_Edit = new System.Windows.Forms.Button();
			this.btn_Add = new System.Windows.Forms.Button();
			this.btn_Delete = new System.Windows.Forms.Button();
			this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).BeginInit();
			this.SuspendLayout();
			// 
			// trv_EducationUnit
			// 
			this.trv_EducationUnit.Location = new System.Drawing.Point(9, 12);
			this.trv_EducationUnit.Name = "trv_EducationUnit";
			this.trv_EducationUnit.Size = new System.Drawing.Size(139, 174);
			this.trv_EducationUnit.TabIndex = 0;
			this.trv_EducationUnit.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv_EducationUnit_AfterSelect);
			// 
			// dgv_Student
			// 
			this.dgv_Student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_Student.Location = new System.Drawing.Point(167, 12);
			this.dgv_Student.Name = "dgv_Student";
			this.dgv_Student.RowTemplate.Height = 23;
			this.dgv_Student.Size = new System.Drawing.Size(145, 174);
			this.dgv_Student.TabIndex = 1;
			// 
			// btn_Edit
			// 
			this.btn_Edit.Location = new System.Drawing.Point(237, 192);
			this.btn_Edit.Name = "btn_Edit";
			this.btn_Edit.Size = new System.Drawing.Size(75, 23);
			this.btn_Edit.TabIndex = 2;
			this.btn_Edit.Text = "编辑";
			this.btn_Edit.UseVisualStyleBackColor = true;
			this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
			// 
			// btn_Add
			// 
			this.btn_Add.Location = new System.Drawing.Point(156, 192);
			this.btn_Add.Name = "btn_Add";
			this.btn_Add.Size = new System.Drawing.Size(75, 23);
			this.btn_Add.TabIndex = 4;
			this.btn_Add.Text = "添加";
			this.btn_Add.UseVisualStyleBackColor = true;
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// btn_Delete
			// 
			this.btn_Delete.Location = new System.Drawing.Point(156, 221);
			this.btn_Delete.Name = "btn_Delete";
			this.btn_Delete.Size = new System.Drawing.Size(75, 23);
			this.btn_Delete.TabIndex = 5;
			this.btn_Delete.Text = "删除";
			this.btn_Delete.UseVisualStyleBackColor = true;
			this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
			// 
			// frm_EducationManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 246);
			this.Controls.Add(this.btn_Delete);
			this.Controls.Add(this.btn_Add);
			this.Controls.Add(this.btn_Edit);
			this.Controls.Add(this.dgv_Student);
			this.Controls.Add(this.trv_EducationUnit);
			this.Name = "frm_EducationManagement";
			this.Text = "教学管理";
			((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).EndInit();
			this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.TreeView trv_EducationUnit;
        private System.Windows.Forms.DataGridView dgv_Student;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Delete;
		private System.ComponentModel.BackgroundWorker BackgroundWorker;
	}
}