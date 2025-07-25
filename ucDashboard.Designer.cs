using System.Drawing;
using System.Windows.Forms;

namespace MukeshShop
{
    partial class ucDashboard
    {
        private FlowLayoutPanel flowLayoutPanelCards;
        private Panel pnlCardSales, pnlCardOrders, pnlCardCustomers, pnlCardProducts;
        private Label lblTotalSales, lblTotalOrders, lblTotalCustomers, lblTotalProducts;
        private Label label1, label2, label3, label4;

        private void InitializeComponent()
        {
            this.flowLayoutPanelCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCardSales = new System.Windows.Forms.Panel();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCardOrders = new System.Windows.Forms.Panel();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCardCustomers = new System.Windows.Forms.Panel();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlCardProducts = new System.Windows.Forms.Panel();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanelCards.SuspendLayout();
            this.pnlCardSales.SuspendLayout();
            this.pnlCardOrders.SuspendLayout();
            this.pnlCardCustomers.SuspendLayout();
            this.pnlCardProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelCards
            // 
            this.flowLayoutPanelCards.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanelCards.Controls.Add(this.pnlCardSales);
            this.flowLayoutPanelCards.Controls.Add(this.pnlCardOrders);
            this.flowLayoutPanelCards.Controls.Add(this.pnlCardCustomers);
            this.flowLayoutPanelCards.Controls.Add(this.pnlCardProducts);
            this.flowLayoutPanelCards.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelCards.Name = "flowLayoutPanelCards";
            this.flowLayoutPanelCards.Size = new System.Drawing.Size(924, 160);
            this.flowLayoutPanelCards.TabIndex = 0;
            // 
            // pnlCardSales
            // 
            this.pnlCardSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(25)))), ((int)(((byte)(60)))));
            this.pnlCardSales.Controls.Add(this.lblTotalSales);
            this.pnlCardSales.Controls.Add(this.label1);
            this.pnlCardSales.Location = new System.Drawing.Point(3, 3);
            this.pnlCardSales.Name = "pnlCardSales";
            this.pnlCardSales.Size = new System.Drawing.Size(220, 125);
            this.pnlCardSales.TabIndex = 0;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalSales.ForeColor = System.Drawing.Color.White;
            this.lblTotalSales.Location = new System.Drawing.Point(3, 50);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(214, 42);
            this.lblTotalSales.TabIndex = 1;
            this.lblTotalSales.Text = "₹0";
            this.lblTotalSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(166)))), ((int)(((byte)(178)))));
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Sales (This Month)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCardOrders
            // 
            this.pnlCardOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(25)))), ((int)(((byte)(60)))));
            this.pnlCardOrders.Controls.Add(this.lblTotalOrders);
            this.pnlCardOrders.Controls.Add(this.label2);
            this.pnlCardOrders.Location = new System.Drawing.Point(229, 3);
            this.pnlCardOrders.Name = "pnlCardOrders";
            this.pnlCardOrders.Size = new System.Drawing.Size(220, 125);
            this.pnlCardOrders.TabIndex = 1;
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.White;
            this.lblTotalOrders.Location = new System.Drawing.Point(6, 50);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(214, 42);
            this.lblTotalOrders.TabIndex = 1;
            this.lblTotalOrders.Text = "0";
            this.lblTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(166)))), ((int)(((byte)(178)))));
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Orders (This Month)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCardCustomers
            // 
            this.pnlCardCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(25)))), ((int)(((byte)(60)))));
            this.pnlCardCustomers.Controls.Add(this.lblTotalCustomers);
            this.pnlCardCustomers.Controls.Add(this.label3);
            this.pnlCardCustomers.Location = new System.Drawing.Point(455, 3);
            this.pnlCardCustomers.Name = "pnlCardCustomers";
            this.pnlCardCustomers.Size = new System.Drawing.Size(220, 125);
            this.pnlCardCustomers.TabIndex = 2;
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalCustomers.ForeColor = System.Drawing.Color.White;
            this.lblTotalCustomers.Location = new System.Drawing.Point(6, 50);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(214, 42);
            this.lblTotalCustomers.TabIndex = 1;
            this.lblTotalCustomers.Text = "0";
            this.lblTotalCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(166)))), ((int)(((byte)(178)))));
            this.label3.Location = new System.Drawing.Point(3, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Customers";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCardProducts
            // 
            this.pnlCardProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(25)))), ((int)(((byte)(60)))));
            this.pnlCardProducts.Controls.Add(this.lblTotalProducts);
            this.pnlCardProducts.Controls.Add(this.label4);
            this.pnlCardProducts.Location = new System.Drawing.Point(681, 3);
            this.pnlCardProducts.Name = "pnlCardProducts";
            this.pnlCardProducts.Size = new System.Drawing.Size(220, 125);
            this.pnlCardProducts.TabIndex = 3;
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalProducts.ForeColor = System.Drawing.Color.White;
            this.lblTotalProducts.Location = new System.Drawing.Point(6, 50);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(214, 42);
            this.lblTotalProducts.TabIndex = 1;
            this.lblTotalProducts.Text = "0";
            this.lblTotalProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(166)))), ((int)(((byte)(178)))));
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Products";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucDashboard
            // 
            this.Controls.Add(this.flowLayoutPanelCards);
            this.Name = "ucDashboard";
            this.Size = new System.Drawing.Size(924, 160);
            this.flowLayoutPanelCards.ResumeLayout(false);
            this.pnlCardSales.ResumeLayout(false);
            this.pnlCardOrders.ResumeLayout(false);
            this.pnlCardCustomers.ResumeLayout(false);
            this.pnlCardProducts.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
