using System;
using System.Data;
using System.Windows.Forms;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 数据绑定助手；
	/// </summary>
	public static class DataBindHelper
	{
		/// <summary>
		/// 快速填充；
		/// </summary>
		/// <param name="dbHelper">数据库助手</param>
		/// <param name="commandText">命令文本</param>
		/// <param name="listControl">列表控件</param>
		/// <param name="displayMember">显示值</param>
		/// <param name="valueMember">实际值</param>
		public static void QuickFill(this DbHelperBase dbHelper, string commandText, ListControl listControl, string displayMember = "Name", string valueMember = "No")
		{
			DataTable dataTable = dbHelper.NewCommand(commandText).ReturnTable();
			listControl.DataSource = dataTable;
			listControl.DisplayMember = "Name";
			listControl.ValueMember = "No";
		}
		/// <summary>
		/// 快速填充；
		/// </summary>
		/// <param name="dbHelper">数据库助手</param>
		/// <param name="commandText">命令文本</param>
		/// <param name="dataGridView">数据网格视图</param>
		public static void QuickFill(this DbHelperBase dbHelper, string commandText, DataGridView dataGridView)
		{
			DataTable dataTable = dbHelper.NewCommand(commandText).ReturnTable();
			dataGridView.DataSource = dataTable;
		}
		/// <summary>
		/// 获取数据属性的名称；
		/// </summary>
		/// <param name="control">控件</param>
		/// <returns>数据属性名称</returns>
		private static string GetDataColumnName(Control control)
		{
			string name = "";
			if (control.Tag == null)
			{
				string[] controlNameParts = control.Name.Split('_');
				name = controlNameParts[controlNameParts.Length - 1];
				return name;
			}
			name = control.Tag.ToString();
			return name;
		}
		/// <summary>
		/// 显示于控件；
		/// </summary>
		/// <param name="dbHelper">数据库助手</param>
		/// <param name="control">控件</param>
		/// <param name="name">数据属性名称</param>
		/// <returns>数据库助手</returns>
		public static DbHelperBase DisplayOn(this DbHelperBase dbHelper, Control control, string name = null)
		{
			if (!dbHelper.HasRecord)
			{
				return dbHelper;
			}
			name = name ?? GetDataColumnName(control);
			control.Text = dbHelper.Record[name].ToString();
			return dbHelper;
		}
		/// <summary>
		/// 显示于单选按钮；
		/// 单选按钮标签可能需要设为相应的属性名称；若单选按钮的选中状态与数据相反，还可在属性名称前加!；
		/// </summary>
		/// <param name="dbHelper">数据库助手</param>
		/// <param name="radioButton">单选按钮</param>
		/// <param name="name">数据属性名称</param>
		/// <param name="isOpposite">单选按钮的选中状态是否与数据相反</param>
		/// <returns>数据库助手</returns>
		public static DbHelperBase DisplayOn(this DbHelperBase dbHelper, RadioButton radioButton, string name = null, bool isOpposite = false)
		{
			if (!dbHelper.HasRecord)
			{
				return dbHelper;
			}
			name = name ?? GetDataColumnName(radioButton);
			if (name.Contains("!"))
			{
				isOpposite = true;
				name = name.Substring(1);
			}
			radioButton.Checked = (bool)dbHelper.Record[name] ^ isOpposite;
			return dbHelper;
		}
		/// <summary>
		/// 显示于日期时间选择器；
		/// </summary>
		/// <param name="dbHelper">数据库助手</param>
		/// <param name="dateTimePicker">日期时间选择器</param>
		/// <param name="name">数据属性名称</param>
		/// <returns>数据库助手</returns>
		public static DbHelperBase DisplayOn(this DbHelperBase dbHelper, DateTimePicker dateTimePicker, string name = null)
		{
			if (!dbHelper.HasRecord)
			{
				return dbHelper;
			}
			name = name ?? GetDataColumnName(dateTimePicker);
			dateTimePicker.Value = (DateTime)dbHelper.Record[name];
			return dbHelper;
		}
		/// <summary>
		/// 显示于列表控件；
		/// </summary>
		/// <param name="dbHelper">数据库助手</param>
		/// <param name="listControl">列表控件</param>
		/// <param name="name">数据属性名称</param>
		/// <returns>数据库助手</returns>
		public static DbHelperBase DisplayOn(this DbHelperBase dbHelper, ListControl listControl, string name = null)
		{
			if (!dbHelper.HasRecord)
			{
				return dbHelper;
			}
			name = name ?? GetDataColumnName(listControl);
			listControl.SelectedValue = (int)dbHelper.Record[name];
			return dbHelper;
		}
		/// <summary>
		/// 显示于控件；
		/// 控件应满足以下要求之一：①控件名称包含相应的属性名称作为后缀，并以下划线分隔，例如txb_Name；②控件标签设为相应的属性名称，或根据具体控件要求添加额外信息；
		/// </summary>
		/// <param name="dbHelper">数据库助手</param>
		/// <param name="controls">控件</param>
		/// <returns>数据库助手</returns>
		public static DbHelperBase DisplayOn(this DbHelperBase dbHelper, params Control[] controls)
		{
			if (!dbHelper.HasRecord)
			{
				return dbHelper;
			}
			foreach (var control in controls)
			{
				switch (control)
				{
					case RadioButton radioButton:
						{
							DisplayOn(dbHelper, radioButton, name: null);
						}
						break;
					case DateTimePicker dateTimePicker:
						{
							DisplayOn(dbHelper, dateTimePicker, name: null);
						}
						break;
					case ListControl listControl:
						{
							DisplayOn(dbHelper, listControl, name: null);
						}
						break;
					default:
						{
							DisplayOn(dbHelper, control, name: null);
						}
						break;
				}
			}
			return dbHelper;
		}
	}
}
