namespace Connection_ConnectionString
{
    partial class frm_Connection
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Hint = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Hint1
            // 
            this.lbl_Hint.AutoSize = true;
            this.lbl_Hint.Location = new System.Drawing.Point(7, 20);
            this.lbl_Hint.Name = "lbl_Hint1";
            this.lbl_Hint.Size = new System.Drawing.Size(245, 12);
            this.lbl_Hint.TabIndex = 0;
            this.lbl_Hint.Text = "（数据库连接的连接字符串来自字符串变量）";
            // 
            // btn_Connect1
            // 
            this.btn_Connect.Location = new System.Drawing.Point(92, 43);
            this.btn_Connect.Name = "btn_Connect1";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // frm_Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 78);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.lbl_Hint);
            this.Name = "frm_Connection";
            this.Text = "数据库连接";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Hint;
        private System.Windows.Forms.Button btn_Connect;
    }
}

