namespace Ex54_Table_Row
{
    partial class frm_CourseSelection
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
            this.dgv_Course = new System.Windows.Forms.DataGridView();
            this.btn_Load = new System.Windows.Forms.Button();
            this.dgv_SelectedCourse = new System.Windows.Forms.DataGridView();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.lbl_CreditSum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Course)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedCourse)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Course1
            // 
            this.dgv_Course.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Course.Location = new System.Drawing.Point(12, 12);
            this.dgv_Course.Name = "dgv_Course1";
            this.dgv_Course.RowTemplate.Height = 23;
            this.dgv_Course.Size = new System.Drawing.Size(267, 192);
            this.dgv_Course.TabIndex = 50;
            // 
            // btn_Load1
            // 
            this.btn_Load.Location = new System.Drawing.Point(12, 210);
            this.btn_Load.Name = "btn_Load1";
            this.btn_Load.Size = new System.Drawing.Size(75, 23);
            this.btn_Load.TabIndex = 1;
            this.btn_Load.Text = "载入";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // dgv_SelectedCourse1
            // 
            this.dgv_SelectedCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SelectedCourse.Location = new System.Drawing.Point(324, 12);
            this.dgv_SelectedCourse.Name = "dgv_SelectedCourse1";
            this.dgv_SelectedCourse.RowTemplate.Height = 23;
            this.dgv_SelectedCourse.Size = new System.Drawing.Size(333, 192);
            this.dgv_SelectedCourse.TabIndex = 51;
            // 
            // btn_Add1
            // 
            this.btn_Add.Location = new System.Drawing.Point(285, 12);
            this.btn_Add.Name = "btn_Add1";
            this.btn_Add.Size = new System.Drawing.Size(33, 23);
            this.btn_Add.TabIndex = 52;
            this.btn_Add.Text = ">>";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Remove1
            // 
            this.btn_Remove.Location = new System.Drawing.Point(285, 41);
            this.btn_Remove.Name = "btn_Remove1";
            this.btn_Remove.Size = new System.Drawing.Size(33, 23);
            this.btn_Remove.TabIndex = 53;
            this.btn_Remove.Text = "<<";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Submit1
            // 
            this.btn_Submit.Location = new System.Drawing.Point(582, 210);
            this.btn_Submit.Name = "btn_Submit1";
            this.btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.btn_Submit.TabIndex = 54;
            this.btn_Submit.Text = "提交";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // lbl_CreditSum1
            // 
            this.lbl_CreditSum.AutoSize = true;
            this.lbl_CreditSum.Location = new System.Drawing.Point(322, 215);
            this.lbl_CreditSum.Name = "lbl_CreditSum1";
            this.lbl_CreditSum.Size = new System.Drawing.Size(47, 12);
            this.lbl_CreditSum.TabIndex = 55;
            this.lbl_CreditSum.Text = "共0学分";
            // 
            // frm_CourseSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 243);
            this.Controls.Add(this.lbl_CreditSum);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.dgv_SelectedCourse);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.dgv_Course);
            this.Name = "frm_CourseSelection";
            this.Text = "选课";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Course)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedCourse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Course;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.DataGridView dgv_SelectedCourse;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Label lbl_CreditSum;
    }
}