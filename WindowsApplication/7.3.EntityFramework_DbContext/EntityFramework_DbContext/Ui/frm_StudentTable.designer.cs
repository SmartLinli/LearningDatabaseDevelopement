namespace EntityFramework_DbContext
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
			this.dgv_Score = new System.Windows.Forms.DataGridView();
			this.btn_Load = new System.Windows.Forms.Button();
			this.btn_InitDb = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Score)).BeginInit();
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
			// dgv_Score
			// 
			this.dgv_Score.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_Score.Location = new System.Drawing.Point(12, 12);
			this.dgv_Score.Name = "dgv_Score";
			this.dgv_Score.RowTemplate.Height = 23;
			this.dgv_Score.Size = new System.Drawing.Size(428, 192);
			this.dgv_Score.TabIndex = 50;
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
			// btn_InitDb
			// 
			this.btn_InitDb.Location = new System.Drawing.Point(12, 219);
			this.btn_InitDb.Name = "btn_InitDb";
			this.btn_InitDb.Size = new System.Drawing.Size(91, 23);
			this.btn_InitDb.TabIndex = 51;
			this.btn_InitDb.Text = "初始化数据库";
			this.btn_InitDb.UseVisualStyleBackColor = true;
			this.btn_InitDb.Click += new System.EventHandler(this.btn_InitDb_Click);
			// 
			// frm_StudentTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 254);
			this.Controls.Add(this.btn_InitDb);
			this.Controls.Add(this.btn_Load);
			this.Controls.Add(this.dgv_Score);
			this.Controls.Add(this.btn_Update);
			this.Name = "frm_StudentTable";
			this.Text = "学生表";
			((System.ComponentModel.ISupportInitialize)(this.dgv_Score)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.DataGridView dgv_Score;
        private System.Windows.Forms.Button btn_Load;
		private System.Windows.Forms.Button btn_InitDb;
	}
}