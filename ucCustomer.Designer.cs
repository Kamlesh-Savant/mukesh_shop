namespace MukeshShop
{
    partial class ucCustomer
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle, lblID, lblName, lblAddress, lblMobile, lblContactPerson;
        private System.Windows.Forms.Panel panelContainer, panelID, panelName, panelAddress, panelMobile, panelContactPerson;
        private System.Windows.Forms.TextBox txtID, txtName, txtAddress, txtMobile, txtContactPerson;
        private System.Windows.Forms.Button btnSave, btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelContainer = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.panelID = new System.Windows.Forms.Panel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panelName = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.panelAddress = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.panelMobile = new System.Windows.Forms.Panel();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.panelContactPerson = new System.Windows.Forms.Panel();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelContainer.SuspendLayout();
            this.panelID.SuspendLayout();
            this.panelName.SuspendLayout();
            this.panelAddress.SuspendLayout();
            this.panelMobile.SuspendLayout();
            this.panelContactPerson.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer.Controls.Add(this.lblTitle);
            this.panelContainer.Controls.Add(this.lblID);
            this.panelContainer.Controls.Add(this.panelID);
            this.panelContainer.Controls.Add(this.lblName);
            this.panelContainer.Controls.Add(this.panelName);
            this.panelContainer.Controls.Add(this.lblAddress);
            this.panelContainer.Controls.Add(this.panelAddress);
            this.panelContainer.Controls.Add(this.lblMobile);
            this.panelContainer.Controls.Add(this.panelMobile);
            this.panelContainer.Controls.Add(this.lblContactPerson);
            this.panelContainer.Controls.Add(this.panelContactPerson);
            this.panelContainer.Controls.Add(this.btnSave);
            this.panelContainer.Controls.Add(this.btnClear);
            this.panelContainer.Location = new System.Drawing.Point(0, -6);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(20);
            this.panelContainer.Size = new System.Drawing.Size(380, 500);
            this.panelContainer.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(201, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Customer Details";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblID.ForeColor = System.Drawing.Color.DimGray;
            this.lblID.Location = new System.Drawing.Point(20, 66);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(25, 21);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID";
            // 
            // panelID
            // 
            this.panelID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelID.Controls.Add(this.txtID);
            this.panelID.Location = new System.Drawing.Point(21, 89);
            this.panelID.Name = "panelID";
            this.panelID.Padding = new System.Windows.Forms.Padding(5);
            this.panelID.Size = new System.Drawing.Size(340, 40);
            this.panelID.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtID.Location = new System.Drawing.Point(5, 5);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(328, 26);
            this.txtID.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblName.ForeColor = System.Drawing.Color.DimGray;
            this.lblName.Location = new System.Drawing.Point(20, 140);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 21);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // panelName
            // 
            this.panelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelName.Controls.Add(this.txtName);
            this.panelName.Location = new System.Drawing.Point(21, 163);
            this.panelName.Name = "panelName";
            this.panelName.Padding = new System.Windows.Forms.Padding(5);
            this.panelName.Size = new System.Drawing.Size(340, 40);
            this.panelName.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtName.Location = new System.Drawing.Point(5, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(328, 26);
            this.txtName.TabIndex = 0;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAddress.ForeColor = System.Drawing.Color.DimGray;
            this.lblAddress.Location = new System.Drawing.Point(20, 214);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(66, 21);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Address";
            // 
            // panelAddress
            // 
            this.panelAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAddress.Controls.Add(this.txtAddress);
            this.panelAddress.Location = new System.Drawing.Point(21, 237);
            this.panelAddress.Name = "panelAddress";
            this.panelAddress.Padding = new System.Windows.Forms.Padding(5);
            this.panelAddress.Size = new System.Drawing.Size(340, 40);
            this.panelAddress.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtAddress.Location = new System.Drawing.Point(5, 5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(328, 26);
            this.txtAddress.TabIndex = 0;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMobile.ForeColor = System.Drawing.Color.DimGray;
            this.lblMobile.Location = new System.Drawing.Point(20, 288);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(58, 21);
            this.lblMobile.TabIndex = 7;
            this.lblMobile.Text = "Mobile";
            // 
            // panelMobile
            // 
            this.panelMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMobile.Controls.Add(this.txtMobile);
            this.panelMobile.Location = new System.Drawing.Point(21, 311);
            this.panelMobile.Name = "panelMobile";
            this.panelMobile.Padding = new System.Windows.Forms.Padding(5);
            this.panelMobile.Size = new System.Drawing.Size(340, 40);
            this.panelMobile.TabIndex = 8;
            // 
            // txtMobile
            // 
            this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMobile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMobile.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtMobile.Location = new System.Drawing.Point(5, 5);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(328, 26);
            this.txtMobile.TabIndex = 0;
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblContactPerson.ForeColor = System.Drawing.Color.DimGray;
            this.lblContactPerson.Location = new System.Drawing.Point(20, 362);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(114, 21);
            this.lblContactPerson.TabIndex = 9;
            this.lblContactPerson.Text = "Contact Person";
            // 
            // panelContactPerson
            // 
            this.panelContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContactPerson.Controls.Add(this.txtContactPerson);
            this.panelContactPerson.Location = new System.Drawing.Point(21, 385);
            this.panelContactPerson.Name = "panelContactPerson";
            this.panelContactPerson.Padding = new System.Windows.Forms.Padding(5);
            this.panelContactPerson.Size = new System.Drawing.Size(340, 40);
            this.panelContactPerson.TabIndex = 10;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContactPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContactPerson.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtContactPerson.Location = new System.Drawing.Point(5, 5);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(328, 26);
            this.txtContactPerson.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(166, 445);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Firebrick;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(270, 445);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 35);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ucCustomer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.panelContainer);
            this.Name = "ucCustomer";
            this.Size = new System.Drawing.Size(380, 500);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.panelID.ResumeLayout(false);
            this.panelID.PerformLayout();
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.panelAddress.ResumeLayout(false);
            this.panelAddress.PerformLayout();
            this.panelMobile.ResumeLayout(false);
            this.panelMobile.PerformLayout();
            this.panelContactPerson.ResumeLayout(false);
            this.panelContactPerson.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}