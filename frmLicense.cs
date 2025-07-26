using System;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class frmLicense : Form
    {
        public frmLicense()
        {
            InitializeComponent();
            ShowMachineId(); // <- Call this after InitializeComponent
        }

        private void ShowMachineId()
        {
            string machineId = MachineHelper.GetMachineId();
            txtMachineId.Text = machineId; // readonly textbox
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            string enteredKey = txtLicenseKey.Text.Trim();

            if (string.IsNullOrEmpty(enteredKey))
            {
                MessageBox.Show("Please enter the license key.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (LicenseManager.ValidateKey(enteredKey))
            {
                LicenseStorage.SaveLicense(enteredKey);
                MessageBox.Show("License activated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid license key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
