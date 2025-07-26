namespace MukeshShop
{
    partial class frmLicense
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtLicenseKey;
        private System.Windows.Forms.Button btnActivate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtLicenseKey = new System.Windows.Forms.TextBox();
            this.btnActivate = new System.Windows.Forms.Button();
            this.txtMachineId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMessage.Location = new System.Drawing.Point(30, 25);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(255, 19);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Please enter your license key to activate:";
            // 
            // txtLicenseKey
            // 
            this.txtLicenseKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLicenseKey.Location = new System.Drawing.Point(34, 79);
            this.txtLicenseKey.Name = "txtLicenseKey";
            this.txtLicenseKey.Size = new System.Drawing.Size(380, 25);
            this.txtLicenseKey.TabIndex = 1;
            // 
            // btnActivate
            // 
            this.btnActivate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnActivate.Location = new System.Drawing.Point(160, 123);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(130, 35);
            this.btnActivate.TabIndex = 2;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // txtMachineId
            // 
            this.txtMachineId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMachineId.Location = new System.Drawing.Point(35, 48);
            this.txtMachineId.Name = "txtMachineId";
            this.txtMachineId.Size = new System.Drawing.Size(380, 25);
            this.txtMachineId.TabIndex = 3;
            this.txtMachineId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmLicense
            // 
            this.AcceptButton = this.btnActivate;
            this.ClientSize = new System.Drawing.Size(450, 170);
            this.Controls.Add(this.txtMachineId);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtLicenseKey);
            this.Controls.Add(this.btnActivate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License Activation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtMachineId;
    }
}
