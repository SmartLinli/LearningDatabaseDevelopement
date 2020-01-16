using System;
using System.Windows.Forms;

namespace Record
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			frm_LogIn logInForm = new frm_LogIn();
			logInForm.Show();
            Application.Run();
        }
    }
}
