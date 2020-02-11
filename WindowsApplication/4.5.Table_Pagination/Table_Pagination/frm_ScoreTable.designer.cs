namespace Table_Pagination
{
    partial class frm_ScoreTable
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
            this.btn_PreviosPage = new System.Windows.Forms.Button();
            this.btn_NextPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Course)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Course1
            // 
            this.dgv_Course.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Course.Location = new System.Drawing.Point(12, 12);
            this.dgv_Course.Name = "dgv_Course1";
            this.dgv_Course.RowTemplate.Height = 23;
            this.dgv_Course.Size = new System.Drawing.Size(348, 280);
            this.dgv_Course.TabIndex = 50;
            // 
            // btn_Load1
            // 
            this.btn_Load.Location = new System.Drawing.Point(12, 298);
            this.btn_Load.Name = "btn_Load1";
            this.btn_Load.Size = new System.Drawing.Size(75, 23);
            this.btn_Load.TabIndex = 1;
            this.btn_Load.Text = "载入";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_PreviosPage1
            // 
            this.btn_PreviosPage.Location = new System.Drawing.Point(197, 298);
            this.btn_PreviosPage.Name = "btn_PreviosPage1";
            this.btn_PreviosPage.Size = new System.Drawing.Size(75, 23);
            this.btn_PreviosPage.TabIndex = 51;
            this.btn_PreviosPage.Text = "上一页";
            this.btn_PreviosPage.UseVisualStyleBackColor = true;
            this.btn_PreviosPage.Click += new System.EventHandler(this.btn_PreviosPage_Click);
            // 
            // btn_NextPage1
            // 
            this.btn_NextPage.Location = new System.Drawing.Point(285, 298);
            this.btn_NextPage.Name = "btn_NextPage1";
            this.btn_NextPage.Size = new System.Drawing.Size(75, 23);
            this.btn_NextPage.TabIndex = 52;
            this.btn_NextPage.Text = "下一页";
            this.btn_NextPage.UseVisualStyleBackColor = true;
            this.btn_NextPage.Click += new System.EventHandler(this.btn_NextPage_Click);
            // 
            // frm_ScoreTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 333);
            this.Controls.Add(this.btn_NextPage);
            this.Controls.Add(this.btn_PreviosPage);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.dgv_Course);
            this.Name = "frm_ScoreTable";
            this.Text = "成绩表";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Course)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Course;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btn_PreviosPage;
        private System.Windows.Forms.Button btn_NextPage;
    }
}