namespace GridView
{
	partial class CourseSelection
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
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.dgv_AllCourses = new System.Windows.Forms.DataGridView();
			this.dgv_SelectedCourses = new System.Windows.Forms.DataGridView();
			this.btn_Select = new System.Windows.Forms.Button();
			this.btn_Reject = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_AllCourses)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedCourses)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv_AllCourses
			// 
			this.dgv_AllCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_AllCourses.Location = new System.Drawing.Point(32, 29);
			this.dgv_AllCourses.Name = "dgv_AllCourses";
			this.dgv_AllCourses.RowTemplate.Height = 23;
			this.dgv_AllCourses.Size = new System.Drawing.Size(416, 172);
			this.dgv_AllCourses.TabIndex = 0;
			// 
			// dgv_SelectedCourses
			// 
			this.dgv_SelectedCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_SelectedCourses.Location = new System.Drawing.Point(32, 250);
			this.dgv_SelectedCourses.Name = "dgv_SelectedCourses";
			this.dgv_SelectedCourses.RowTemplate.Height = 23;
			this.dgv_SelectedCourses.Size = new System.Drawing.Size(416, 172);
			this.dgv_SelectedCourses.TabIndex = 1;
			// 
			// btn_Select
			// 
			this.btn_Select.Location = new System.Drawing.Point(32, 214);
			this.btn_Select.Name = "btn_Select";
			this.btn_Select.Size = new System.Drawing.Size(75, 23);
			this.btn_Select.TabIndex = 2;
			this.btn_Select.Text = "选修↓";
			this.btn_Select.UseVisualStyleBackColor = true;
			this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
			// 
			// btn_Reject
			// 
			this.btn_Reject.Location = new System.Drawing.Point(373, 214);
			this.btn_Reject.Name = "btn_Reject";
			this.btn_Reject.Size = new System.Drawing.Size(75, 23);
			this.btn_Reject.TabIndex = 3;
			this.btn_Reject.Text = "退选↑";
			this.btn_Reject.UseVisualStyleBackColor = true;
			this.btn_Reject.Click += new System.EventHandler(this.btn_Reject_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(480, 450);
			this.Controls.Add(this.btn_Reject);
			this.Controls.Add(this.btn_Select);
			this.Controls.Add(this.dgv_SelectedCourses);
			this.Controls.Add(this.dgv_AllCourses);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dgv_AllCourses)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedCourses)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv_AllCourses;
		private System.Windows.Forms.DataGridView dgv_SelectedCourses;
		private System.Windows.Forms.Button btn_Select;
		private System.Windows.Forms.Button btn_Reject;
	}
}

