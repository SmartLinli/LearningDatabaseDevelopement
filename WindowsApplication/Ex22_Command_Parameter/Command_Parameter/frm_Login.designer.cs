﻿namespace Command_Parameter
{
    partial class frm_Login
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
            this.txb_UserNo = new System.Windows.Forms.TextBox();
            this.txb_Password = new System.Windows.Forms.TextBox();
            this.lbl_UserNo = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            this.lbl_Hint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txb_UserNo1
            // 
            this.txb_UserNo.Location = new System.Drawing.Point(62, 13);
            this.txb_UserNo.Name = "txb_UserNo1";
            this.txb_UserNo.Size = new System.Drawing.Size(100, 21);
            this.txb_UserNo.TabIndex = 0;
            // 
            // txb_Password1
            // 
            this.txb_Password.Location = new System.Drawing.Point(62, 48);
            this.txb_Password.Name = "txb_Password1";
            this.txb_Password.Size = new System.Drawing.Size(100, 21);
            this.txb_Password.TabIndex = 1;
            // 
            // lbl_UserNo1
            // 
            this.lbl_UserNo.AutoSize = true;
            this.lbl_UserNo.Location = new System.Drawing.Point(3, 16);
            this.lbl_UserNo.Name = "lbl_UserNo1";
            this.lbl_UserNo.Size = new System.Drawing.Size(53, 12);
            this.lbl_UserNo.TabIndex = 2;
            this.lbl_UserNo.Text = "用户号：";
            // 
            // lbl_Password1
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(12, 51);
            this.lbl_Password.Name = "lbl_Password1";
            this.lbl_Password.Size = new System.Drawing.Size(41, 12);
            this.lbl_Password.TabIndex = 3;
            this.lbl_Password.Text = "密码：";
            // 
            // btn_Login1
            // 
            this.btn_Login.Location = new System.Drawing.Point(62, 109);
            this.btn_Login.Name = "btn_Login1";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 5;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // lbl_Hint1
            // 
            this.lbl_Hint.AutoSize = true;
            this.lbl_Hint.Location = new System.Drawing.Point(62, 83);
            this.lbl_Hint.Name = "lbl_Hint1";
            this.lbl_Hint.Size = new System.Drawing.Size(113, 12);
            this.lbl_Hint.TabIndex = 6;
            this.lbl_Hint.Text = "请输入用户号、密码";
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 146);
            this.Controls.Add(this.lbl_Hint);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_UserNo);
            this.Controls.Add(this.txb_Password);
            this.Controls.Add(this.txb_UserNo);
            this.Name = "frm_Login";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_UserNo;
        private System.Windows.Forms.TextBox txb_Password;
        private System.Windows.Forms.Label lbl_UserNo;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label lbl_Hint;
    }
}

