using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class ucOrderList : UserControl
    {

        private DataTable saleTable;

        public ucOrderList()
        {
            InitializeComponent();
            dtpFromDate.Value = DateTime.Today.AddDays(-30);
            dtpToDate.Value = DateTime.Today;
        }

        private void ucOrderList_Load(object sender, EventArgs e)
        {
            LoadSaleData();
        }

        private void LoadSaleData()
        {
            try
            {
                string query = @"
            SELECT 
                p.pName AS [Product Name],
                SUM(si.Quantity) AS [Total]
            FROM (tblSale AS s 
                INNER JOIN tblSaleItems AS si ON s.ID = si.sId)
                INNER JOIN tblProduct AS p ON si.pId = p.ID
            WHERE s.sDate BETWEEN ? AND ?
            GROUP BY p.pName
            HAVING SUM(si.Quantity) > 0
            ORDER BY p.pName;
        ";

                saleTable = DB.GetData(
                    query,
                    new OleDbParameter("?", dtpFromDate.Value.Date),
                    new OleDbParameter("?", dtpToDate.Value.Date)
                );

                dgvSales.Columns.Clear();
                dgvSales.DataSource = saleTable;

                dgvSales.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvSales.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                dgvSales.RowTemplate.Height = 35;

                if (dgvSales.Columns.Contains("Product Name"))
                {
                    var col = dgvSales.Columns["Product Name"];
                    col.HeaderText = "Product Name";
                    col.Width = 343;
                }

                if (dgvSales.Columns.Contains("Total"))
                {
                    var col = dgvSales.Columns["Total"];
                    col.HeaderText = "Total";
                    col.Width = 80;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product summary: " + ex.Message);
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (saleTable == null) return;

            string filter = txtSearch.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(filter))
            {
                saleTable.DefaultView.RowFilter = "";
            }
            else
            {
                // Filter by product name (case-insensitive)
                saleTable.DefaultView.RowFilter =
                    $"[Product Name] LIKE '%{filter}%'";
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            LoadSaleData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Prepare your data list from saleTable
            List<ProductSummaryItem> list = new List<ProductSummaryItem>();

            foreach (DataRow row in saleTable.Rows)
            {
                list.Add(new ProductSummaryItem
                {
                    ProductName = row["Product Name"].ToString(),
                    TotalQty = Convert.ToDecimal(row["Total"])
                });
            }

            // Print report
            var printer = new ProductSummaryPrinter(
                "Product Sales Summary",
                dtpFromDate.Value,
                dtpToDate.Value,
                list
            );
            printer.Print();

        }
    }
}