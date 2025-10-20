namespace MukeshShop
{
    partial class ucProduct
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle, lblCode, lblName, lblUnit, lblRate;
        private System.Windows.Forms.Panel panelContainer, panelCode, panelName, panelUnit, panelRate;
        private System.Windows.Forms.TextBox txtCode, txtName, txtRate;
        private System.Windows.Forms.ComboBox cmbUnit;
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
            this.lblCode = new System.Windows.Forms.Label();
            this.panelCode = new System.Windows.Forms.Panel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panelName = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.panelUnit = new System.Windows.Forms.Panel();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.panelRate = new System.Windows.Forms.Panel();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelContainer.SuspendLayout();
            this.panelCode.SuspendLayout();
            this.panelName.SuspendLayout();
            this.panelUnit.SuspendLayout();
            this.panelRate.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer.Controls.Add(this.lblTitle);
            this.panelContainer.Controls.Add(this.lblCode);
            this.panelContainer.Controls.Add(this.panelCode);
            this.panelContainer.Controls.Add(this.lblName);
            this.panelContainer.Controls.Add(this.panelName);
            this.panelContainer.Controls.Add(this.lblUnit);
            this.panelContainer.Controls.Add(this.panelUnit);
            this.panelContainer.Controls.Add(this.lblRate);
            this.panelContainer.Controls.Add(this.panelRate);
            this.panelContainer.Controls.Add(this.btnSave);
            this.panelContainer.Controls.Add(this.btnClear);
            this.panelContainer.Location = new System.Drawing.Point(0, -6);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(20);
            this.panelContainer.Size = new System.Drawing.Size(380, 427);
            this.panelContainer.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(181, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Product Details";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCode.ForeColor = System.Drawing.Color.DimGray;
            this.lblCode.Location = new System.Drawing.Point(20, 66);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(25, 21);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "ID";
            // 
            // panelCode
            // 
            this.panelCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCode.Controls.Add(this.txtCode);
            this.panelCode.Location = new System.Drawing.Point(21, 89);
            this.panelCode.Name = "panelCode";
            this.panelCode.Padding = new System.Windows.Forms.Padding(5);
            this.panelCode.Size = new System.Drawing.Size(340, 40);
            this.panelCode.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Enabled = false;
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtCode.Location = new System.Drawing.Point(5, 5);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(328, 26);
            this.txtCode.TabIndex = 0;
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
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUnit.ForeColor = System.Drawing.Color.DimGray;
            this.lblUnit.Location = new System.Drawing.Point(20, 214);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(39, 21);
            this.lblUnit.TabIndex = 5;
            this.lblUnit.Text = "Unit";
            // 
            // panelUnit
            // 
            this.panelUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUnit.Controls.Add(this.cmbUnit);
            this.panelUnit.Location = new System.Drawing.Point(21, 237);
            this.panelUnit.Name = "panelUnit";
            this.panelUnit.Padding = new System.Windows.Forms.Padding(5);
            this.panelUnit.Size = new System.Drawing.Size(340, 40);
            this.panelUnit.TabIndex = 6;
            // 
            // cmbUnit
            // 
            this.cmbUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cmbUnit.Items.AddRange(new object[] {
            "Ladi",
            "Unit"});
            this.cmbUnit.Location = new System.Drawing.Point(5, 5);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(328, 33);
            this.cmbUnit.TabIndex = 0;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRate.ForeColor = System.Drawing.Color.DimGray;
            this.lblRate.Location = new System.Drawing.Point(20, 288);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(41, 21);
            this.lblRate.TabIndex = 7;
            this.lblRate.Text = "Rate";
            // 
            // panelRate
            // 
            this.panelRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRate.Controls.Add(this.txtRate);
            this.panelRate.Location = new System.Drawing.Point(21, 311);
            this.panelRate.Name = "panelRate";
            this.panelRate.Padding = new System.Windows.Forms.Padding(5);
            this.panelRate.Size = new System.Drawing.Size(340, 40);
            this.panelRate.TabIndex = 8;
            // 
            // txtRate
            // 
            this.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRate.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtRate.Location = new System.Drawing.Point(5, 5);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(328, 26);
            this.txtRate.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(166, 373);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 9;
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
            this.btnClear.Location = new System.Drawing.Point(270, 373);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 35);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // ucProduct
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.panelContainer);
            this.Name = "ucProduct";
            this.Size = new System.Drawing.Size(380, 424);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.panelCode.ResumeLayout(false);
            this.panelCode.PerformLayout();
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.panelUnit.ResumeLayout(false);
            this.panelRate.ResumeLayout(false);
            this.panelRate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
