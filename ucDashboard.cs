using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class ucDashboard : UserControl
    {
        public ucDashboard()
        {
            InitializeComponent();
            LoadData(); // Ensure data loads when the dashboard is initialized
        }

        private void LoadData()
        {
            try
            {
                using (OleDbConnection conn = DB.GetConnection())
                {
                    conn.Open();

                    // 1. Monthly Sales & Order Count
                    string saleQuery = @"
                        SELECT COUNT(*) AS OrderCount, SUM(GrandTotal) AS Total 
                        FROM tblSale 
                        WHERE sDate >= DateSerial(Year(Date()), Month(Date()), 1) 
                          AND sDate < DateSerial(Year(Date()), Month(Date()) + 1, 1)";

                    using (OleDbCommand cmd1 = new OleDbCommand(saleQuery, conn))
                    using (OleDbDataReader reader1 = cmd1.ExecuteReader())
                    {
                        if (reader1.Read())
                        {
                            decimal total = !reader1.IsDBNull(1) ? reader1.GetDecimal(1) : 0;
                            int orders = !reader1.IsDBNull(0) ? reader1.GetInt32(0) : 0;

                            lblTotalSales.Text = "₹ " + total.ToString("0.00");
                            lblTotalOrders.Text = orders.ToString();
                        }
                        else
                        {
                            lblTotalSales.Text = "₹ 0.00";
                            lblTotalOrders.Text = "0";
                        }
                    }

                    // 2. Total Customers
                    string customerQuery = "SELECT COUNT(*) FROM tblCustomer";
                    using (OleDbCommand cmd2 = new OleDbCommand(customerQuery, conn))
                    {
                        int customerCount = Convert.ToInt32(cmd2.ExecuteScalar());
                        lblTotalCustomers.Text = customerCount.ToString();
                    }

                    // 3. Total Products
                    string productQuery = "SELECT COUNT(*) FROM tblProduct";
                    using (OleDbCommand cmd3 = new OleDbCommand(productQuery, conn))
                    {
                        int productCount = Convert.ToInt32(cmd3.ExecuteScalar());
                        lblTotalProducts.Text = productCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard stats: " + ex.Message);

                // Set default safe values
                lblTotalSales.Text = "₹ 0.00";
                lblTotalOrders.Text = "0";
                lblTotalCustomers.Text = "0";
                lblTotalProducts.Text = "0";
            }
        }

        // Optional external setter method if needed
        public void SetStats(string sales, string orders, string customers, string products)
        {
            lblTotalSales.Text = sales;
            lblTotalOrders.Text = orders;
            lblTotalCustomers.Text = customers;
            lblTotalProducts.Text = products;
        }
    }
}
