using System.Drawing;
using System.Windows.Forms;

namespace MukeshShop
{
    partial class ucHeader
    {
        private System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblUsername;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(700, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUsername.Location = new System.Drawing.Point(700, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(260, 60);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Welcome, User";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucHeader
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblUsername);
            this.Name = "ucHeader";
            this.Size = new System.Drawing.Size(960, 60);
            this.ResumeLayout(false);

        }
    }
    }


