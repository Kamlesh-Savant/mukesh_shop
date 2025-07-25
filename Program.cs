using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MukeshShop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin loginForm = new frmLogin();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmDashboard()); // Only runs dashboard if login succeeded
            }
        }
    }
}
