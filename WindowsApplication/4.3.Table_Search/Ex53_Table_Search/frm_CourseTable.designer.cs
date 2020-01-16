namespace Table_Search
{
    partial class frm_CourseTable
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
            this.btn_SearchByNo = new System.Windows.Forms.Button();
            this.btn_SearchByName = new System.Windows.Forms.Button();
            this.txb_CourseNo = new System.Windows.Forms.TextBox();
            this.txb_CourseName = new System.Windows.Forms.TextBox();
            this.txb_Pinyin = new System.Windows.Forms.TextBox();
            this.lbl_PinyinHint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Course)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Course
            // 
            this.dgv_Course.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Course.Location = new System.Drawing.Point(12, 12);
            this.dgv_Course.Name = "dgv_Course";
            this.dgv_Course.RowTemplate.Height = 23;
            this.dgv_Course.Size = new System.Drawing.Size(565, 192);
            this.dgv_Course.TabIndex = 50;
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(12, 210);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(75, 23);
            this.btn_Load.TabIndex = 1;
            this.btn_Load.Text = "载入";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_SearchByNo
            // 
            this.btn_SearchByNo.Location = new System.Drawing.Point(278, 208);
            this.btn_SearchByNo.Name = "btn_SearchByNo";
            this.btn_SearchByNo.Size = new System.Drawing.Size(95, 23);
            this.btn_SearchByNo.TabIndex = 51;
            this.btn_SearchByNo.Text = "根据编号搜索";
            this.btn_SearchByNo.UseVisualStyleBackColor = true;
            this.btn_SearchByNo.Click += new System.EventHandler(this.btn_SearchByNo_Click);
            // 
            // btn_SearchByName
            // 
            this.btn_SearchByName.Location = new System.Drawing.Point(278, 237);
            this.btn_SearchByName.Name = "btn_SearchByName";
            this.btn_SearchByName.Size = new System.Drawing.Size(95, 23);
            this.btn_SearchByName.TabIndex = 52;
            this.btn_SearchByName.Text = "根据名称搜索";
            this.btn_SearchByName.UseVisualStyleBackColor = true;
            this.btn_SearchByName.Click += new System.EventHandler(this.btn_SearchByName_Click);
            // 
            // txb_CourseNo
            // 
            this.txb_CourseNo.Location = new System.Drawing.Point(141, 210);
            this.txb_CourseNo.Name = "txb_CourseNo";
            this.txb_CourseNo.Size = new System.Drawing.Size(131, 21);
            this.txb_CourseNo.TabIndex = 53;
            // 
            // txb_CourseName
            // 
            this.txb_CourseName.Location = new System.Drawing.Point(141, 237);
            this.txb_CourseName.Name = "txb_CourseName";
            this.txb_CourseName.Size = new System.Drawing.Size(131, 21);
            this.txb_CourseName.TabIndex = 54;
            // 
            // txb_Pinyin
            // 
            this.txb_Pinyin.Location = new System.Drawing.Point(446, 237);
            this.txb_Pinyin.Name = "txb_Pinyin";
            this.txb_Pinyin.Size = new System.Drawing.Size(131, 21);
            this.txb_Pinyin.TabIndex = 55;
            this.txb_Pinyin.TextChanged += new System.EventHandler(this.txb_Pinyin_TextChanged);
            // 
            // lbl_PinyinHint
            // 
            this.lbl_PinyinHint.AutoSize = true;
            this.lbl_PinyinHint.Location = new System.Drawing.Point(444, 215);
            this.lbl_PinyinHint.Name = "lbl_PinyinHint";
            this.lbl_PinyinHint.Size = new System.Drawing.Size(113, 12);
            this.lbl_PinyinHint.TabIndex = 56;
            this.lbl_PinyinHint.Text = "根据拼音缩写搜索：";
            // 
            // frm_CourseTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 272);
            this.Controls.Add(this.lbl_PinyinHint);
            this.Controls.Add(this.txb_Pinyin);
            this.Controls.Add(this.txb_CourseName);
            this.Controls.Add(this.txb_CourseNo);
            this.Controls.Add(this.btn_SearchByName);
            this.Controls.Add(this.btn_SearchByNo);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.dgv_Course);
            this.Name = "frm_CourseTable";
            this.Text = "课程表";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Course)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Course;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btn_SearchByNo;
        private System.Windows.Forms.Button btn_SearchByName;
        private System.Windows.Forms.TextBox txb_CourseNo;
        private System.Windows.Forms.TextBox txb_CourseName;
        private System.Windows.Forms.TextBox txb_Pinyin;
        private System.Windows.Forms.Label lbl_PinyinHint;
    }
}