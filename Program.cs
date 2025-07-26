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

            if (!LicenseStorage.IsLicenseSaved() || !LicenseManager.ValidateKey(LicenseStorage.LoadLicense()))
            {
                frmLicense licenseForm = new frmLicense();
                if (licenseForm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Activation required to run the app.");
                    return;
                }
            }

            frmLogin loginForm = new frmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmDashboard());
            }
        }

    }
}
