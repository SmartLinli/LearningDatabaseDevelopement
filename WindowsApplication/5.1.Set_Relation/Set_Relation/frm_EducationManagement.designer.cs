namespace Set_Relation
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
			this.btn_Load = new System.Windows.Forms.Button();
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
			this.dgv_Student.Size = new System.Drawing.Size(163, 174);
			this.dgv_Student.TabIndex = 1;
			// 
			// btn_Load
			// 
			this.btn_Load.Location = new System.Drawing.Point(255, 211);
			this.btn_Load.Name = "btn_Load";
			this.btn_Load.Size = new System.Drawing.Size(75, 23);
			this.btn_Load.TabIndex = 2;
			this.btn_Load.Text = "载入";
			this.btn_Load.UseVisualStyleBackColor = true;
			this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
			// 
			// frm_EducationManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(342, 246);
			this.Controls.Add(this.btn_Load);
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
        private System.Windows.Forms.Button btn_Load;

    }
}