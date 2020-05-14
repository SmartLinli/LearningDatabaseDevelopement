namespace ObjectOriented_DataTransferObject
{
    partial class frm_LogIn
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
			this.components = new System.ComponentModel.Container();
			this.txb_UserNo = new System.Windows.Forms.TextBox();
			this.txb_Password = new System.Windows.Forms.TextBox();
			this.lbl_UserNo = new System.Windows.Forms.Label();
			this.lbl_Password = new System.Windows.Forms.Label();
			this.lbl_Hint = new System.Windows.Forms.Label();
			this.btn_LogIn = new System.Windows.Forms.Button();
			this.btn_SignUp = new System.Windows.Forms.Button();
			this.ValidatorComponent = new SmartLinli.DatabaseDevelopement.ValidatorComponent(this.components);
			this.SuspendLayout();
			// 
			// txb_UserNo
			// 
			this.txb_UserNo.Location = new System.Drawing.Point(62, 13);
			this.txb_UserNo.Name = "txb_UserNo";
			this.txb_UserNo.Size = new System.Drawing.Size(100, 21);
			this.txb_UserNo.TabIndex = 0;
			// 
			// txb_Password
			// 
			this.txb_Password.Location = new System.Drawing.Point(62, 48);
			this.txb_Password.Name = "txb_Password";
			this.txb_Password.Size = new System.Drawing.Size(100, 21);
			this.txb_Password.TabIndex = 1;
			// 
			// lbl_UserNo
			// 
			this.lbl_UserNo.AutoSize = true;
			this.lbl_UserNo.Location = new System.Drawing.Point(3, 16);
			this.lbl_UserNo.Name = "lbl_UserNo";
			this.lbl_UserNo.Size = new System.Drawing.Size(53, 12);
			this.lbl_UserNo.TabIndex = 2;
			this.lbl_UserNo.Text = "用户号：";
			// 
			// lbl_Password
			// 
			this.lbl_Password.AutoSize = true;
			this.lbl_Password.Location = new System.Drawing.Point(12, 51);
			this.lbl_Password.Name = "lbl_Password";
			this.lbl_Password.Size = new System.Drawing.Size(41, 12);
			this.lbl_Password.TabIndex = 3;
			this.lbl_Password.Text = "密码：";
			// 
			// lbl_Hint
			// 
			this.lbl_Hint.AutoSize = true;
			this.lbl_Hint.Location = new System.Drawing.Point(60, 83);
			this.lbl_Hint.Name = "lbl_Hint";
			this.lbl_Hint.Size = new System.Drawing.Size(113, 12);
			this.lbl_Hint.TabIndex = 4;
			this.lbl_Hint.Text = "请输入用户号、密码";
			// 
			// btn_LogIn
			// 
			this.btn_LogIn.Location = new System.Drawing.Point(62, 109);
			this.btn_LogIn.Name = "btn_LogIn";
			this.btn_LogIn.Size = new System.Drawing.Size(75, 23);
			this.btn_LogIn.TabIndex = 5;
			this.btn_LogIn.Text = "登录";
			this.btn_LogIn.UseVisualStyleBackColor = true;
			this.btn_LogIn.Click += new System.EventHandler(this.btn_Login_Click);
			// 
			// btn_SignUp
			// 
			this.btn_SignUp.Location = new System.Drawing.Point(62, 148);
			this.btn_SignUp.Name = "btn_SignUp";
			this.btn_SignUp.Size = new System.Drawing.Size(75, 23);
			this.btn_SignUp.TabIndex = 6;
			this.btn_SignUp.Text = "注册";
			this.btn_SignUp.UseVisualStyleBackColor = true;
			this.btn_SignUp.Click += new System.EventHandler(this.btn_SignUp_Click);
			// 
			// frm_LogIn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(225, 187);
			this.Controls.Add(this.btn_SignUp);
			this.Controls.Add(this.btn_LogIn);
			this.Controls.Add(this.lbl_Hint);
			this.Controls.Add(this.lbl_Password);
			this.Controls.Add(this.lbl_UserNo);
			this.Controls.Add(this.txb_Password);
			this.Controls.Add(this.txb_UserNo);
			this.Name = "frm_LogIn";
			this.Text = "登录";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_UserNo;
        private System.Windows.Forms.TextBox txb_Password;
        private System.Windows.Forms.Label lbl_UserNo;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_Hint;
        private System.Windows.Forms.Button btn_LogIn;
        private System.Windows.Forms.Button btn_SignUp;
		private SmartLinli.DatabaseDevelopement.ValidatorComponent ValidatorComponent;
	}
}

