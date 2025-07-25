using System.Drawing;
using System.Windows.Forms;

namespace MukeshShop
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private ucSidebar ucSidebar1;
        private ucHeader ucHeader1;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Panel pnlContentContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlContentContainer = new System.Windows.Forms.Panel();
            this.ucHeader1 = new MukeshShop.ucHeader();
            this.ucSidebar1 = new MukeshShop.ucSidebar();
            this.pnlMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.Controls.Add(this.pnlContentContainer);
            this.pnlMainContainer.Controls.Add(this.ucHeader1);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(220, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(964, 720);
            this.pnlMainContainer.TabIndex = 3;
            // 
            // pnlContentContainer
            // 
            this.pnlContentContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentContainer.Location = new System.Drawing.Point(0, 60);
            this.pnlContentContainer.Name = "pnlContentContainer";
            this.pnlContentContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContentContainer.Size = new System.Drawing.Size(964, 660);
            this.pnlContentContainer.TabIndex = 0;
            // 
            // ucHeader1
            // 
            this.ucHeader1.BackColor = System.Drawing.Color.White;
            this.ucHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucHeader1.Location = new System.Drawing.Point(0, 0);
            this.ucHeader1.Name = "ucHeader1";
            this.ucHeader1.Size = new System.Drawing.Size(964, 60);
            this.ucHeader1.TabIndex = 1;
            // 
            // ucSidebar1
            // 
            this.ucSidebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucSidebar1.Location = new System.Drawing.Point(0, 0);
            this.ucSidebar1.Name = "ucSidebar1";
            this.ucSidebar1.Size = new System.Drawing.Size(220, 720);
            this.ucSidebar1.TabIndex = 2;
            // 
            // frmDashboard
            // 
            this.ClientSize = new System.Drawing.Size(1184, 720);
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.ucSidebar1);
            this.MinimumSize = new System.Drawing.Size(1200, 750);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mukesh Shop - Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.pnlMainContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        // Method to display content centered
        public void DisplayContent(Control contentControl)
        {
            // Clear existing content
            pnlContentContainer.Controls.Clear();

            // Configure the control to be centered
            contentControl.Anchor = AnchorStyles.None;
            contentControl.Location = new Point(
                (pnlContentContainer.Width - contentControl.Width) / 2,
                (pnlContentContainer.Height - contentControl.Height) / 2
            );

            // Add to container
            pnlContentContainer.Controls.Add(contentControl);
        }
    }
}