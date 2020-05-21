namespace Table_GridView
{
    partial class frm_StudentTable
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
			this.btn_Update = new System.Windows.Forms.Button();
			this.dgv_Student = new System.Windows.Forms.DataGridView();
			this.btn_Load = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_Update
			// 
			this.btn_Update.Location = new System.Drawing.Point(365, 219);
			this.btn_Update.Name = "btn_Update";
			this.btn_Update.Size = new System.Drawing.Size(75, 23);
			this.btn_Update.TabIndex = 49;
			this.btn_Update.Text = "更新";
			this.btn_Update.UseVisualStyleBackColor = true;
			this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
			// 
			// dgv_Student
			// 
			this.dgv_Student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_Student.Location = new System.Drawing.Point(12, 12);
			this.dgv_Student.Name = "dgv_Student";
			this.dgv_Student.RowTemplate.Height = 23;
			this.dgv_Student.Size = new System.Drawing.Size(428, 192);
			this.dgv_Student.TabIndex = 50;
			// 
			// btn_Load
			// 
			this.btn_Load.Location = new System.Drawing.Point(274, 219);
			this.btn_Load.Name = "btn_Load";
			this.btn_Load.Size = new System.Drawing.Size(75, 23);
			this.btn_Load.TabIndex = 1;
			this.btn_Load.Text = "载入";
			this.btn_Load.UseVisualStyleBackColor = true;
			this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
			// 
			// frm_StudentTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(452, 254);
			this.Controls.Add(this.btn_Load);
			this.Controls.Add(this.dgv_Student);
			this.Controls.Add(this.btn_Update);
			this.Name = "frm_StudentTable";
			this.Text = "学生表";
			((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.DataGridView dgv_Student;
        private System.Windows.Forms.Button btn_Load;
    }
}