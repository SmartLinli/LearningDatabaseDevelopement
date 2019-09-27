namespace Connection_ConnectionStringBuilder
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
            this.btn_Connect = new System.Windows.Forms.Button();
            this.gpb_ConnectionParameter = new System.Windows.Forms.GroupBox();
            this.lbl_Server = new System.Windows.Forms.Label();
            this.lbl_Database = new System.Windows.Forms.Label();
            this.txb_Server = new System.Windows.Forms.TextBox();
            this.txb_Database = new System.Windows.Forms.TextBox();
            this.ckb_IsWindowsAuthentication = new System.Windows.Forms.CheckBox();
            this.gpb_ConnectionParameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Connect1
            // 
            this.btn_Connect.Location = new System.Drawing.Point(92, 106);
            this.btn_Connect.Name = "btn_Connect1";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // gpb_ConnectionParameter1
            // 
            this.gpb_ConnectionParameter.Controls.Add(this.ckb_IsWindowsAuthentication);
            this.gpb_ConnectionParameter.Controls.Add(this.txb_Database);
            this.gpb_ConnectionParameter.Controls.Add(this.txb_Server);
            this.gpb_ConnectionParameter.Controls.Add(this.lbl_Database);
            this.gpb_ConnectionParameter.Controls.Add(this.lbl_Server);
            this.gpb_ConnectionParameter.Location = new System.Drawing.Point(12, 12);
            this.gpb_ConnectionParameter.Name = "gpb_ConnectionParameter1";
            this.gpb_ConnectionParameter.Size = new System.Drawing.Size(235, 88);
            this.gpb_ConnectionParameter.TabIndex = 2;
            this.gpb_ConnectionParameter.TabStop = false;
            this.gpb_ConnectionParameter.Text = "连接参数";
            // 
            // lbl_Server1
            // 
            this.lbl_Server.AutoSize = true;
            this.lbl_Server.Location = new System.Drawing.Point(6, 19);
            this.lbl_Server.Name = "lbl_Server1";
            this.lbl_Server.Size = new System.Drawing.Size(53, 12);
            this.lbl_Server.TabIndex = 0;
            this.lbl_Server.Text = "服务器：";
            // 
            // lbl_Database1
            // 
            this.lbl_Database.AutoSize = true;
            this.lbl_Database.Location = new System.Drawing.Point(6, 43);
            this.lbl_Database.Name = "lbl_Database1";
            this.lbl_Database.Size = new System.Drawing.Size(53, 12);
            this.lbl_Database.TabIndex = 1;
            this.lbl_Database.Text = "数据库：";
            // 
            // txb_Server1
            // 
            this.txb_Server.Location = new System.Drawing.Point(65, 16);
            this.txb_Server.Name = "txb_Server1";
            this.txb_Server.Size = new System.Drawing.Size(100, 21);
            this.txb_Server.TabIndex = 3;
            // 
            // txb_Database1
            // 
            this.txb_Database.Location = new System.Drawing.Point(65, 40);
            this.txb_Database.Name = "txb_Database1";
            this.txb_Database.Size = new System.Drawing.Size(100, 21);
            this.txb_Database.TabIndex = 4;
            // 
            // ckb_IsWindowsAuthentication1
            // 
            this.ckb_IsWindowsAuthentication.AutoSize = true;
            this.ckb_IsWindowsAuthentication.Location = new System.Drawing.Point(65, 66);
            this.ckb_IsWindowsAuthentication.Name = "ckb_IsWindowsAuthentication1";
            this.ckb_IsWindowsAuthentication.Size = new System.Drawing.Size(90, 16);
            this.ckb_IsWindowsAuthentication.TabIndex = 5;
            this.ckb_IsWindowsAuthentication.Text = "Windows验证";
            this.ckb_IsWindowsAuthentication.UseVisualStyleBackColor = true;
            // 
            // frm_Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 134);
            this.Controls.Add(this.gpb_ConnectionParameter);
            this.Controls.Add(this.btn_Connect);
            this.Name = "frm_Connection";
            this.Text = "数据库连接";
            this.gpb_ConnectionParameter.ResumeLayout(false);
            this.gpb_ConnectionParameter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.GroupBox gpb_ConnectionParameter;
        private System.Windows.Forms.CheckBox ckb_IsWindowsAuthentication;
        private System.Windows.Forms.TextBox txb_Database;
        private System.Windows.Forms.TextBox txb_Server;
        private System.Windows.Forms.Label lbl_Database;
        private System.Windows.Forms.Label lbl_Server;
    }
}

