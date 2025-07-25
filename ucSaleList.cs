using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class ucSaleList : UserControl
    {
        public event EventHandler AddClicked;
        public event Action<int, DateTime, int, decimal, decimal, decimal> SaleSelected;

        private DataTable saleTable;

        public ucSaleList()
        {
            InitializeComponent();
            dtpFromDate.Value = DateTime.Today.AddDays(-30);
            dtpToDate.Value = DateTime.Today;
        }

        private void ucSaleList_Load(object sender, EventArgs e)
        {
            LoadSaleData();
        }

        private void LoadSaleData()
        {
            try
            {
                string query = @"SELECT s.ID, s.sDate, c.cName AS Customer, 
                        s.cId, s.Total, s.Disc, s.GrandTotal 
                        FROM tblSale s
                        LEFT JOIN tblCustomer c ON s.cId = c.ID
                        WHERE s.sDate BETWEEN ? AND ?
                        ORDER BY s.sDate DESC";

                saleTable = DB.GetData(query, new OleDbParameter("?", dtpFromDate.Value.Date), new OleDbParameter("?", dtpToDate.Value.Date));

                dgvSales.Columns.Clear();
                dgvSales.DataSource = saleTable;

                dgvSales.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvSales.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                dgvSales.RowTemplate.Height = 35;

                if (dgvSales.Columns.Contains("ID"))
                {
                    var col = dgvSales.Columns["ID"];
                    col.HeaderText = "ID";
                    col.Width = 80;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvSales.Columns.Contains("sDate"))
                {
                    var col = dgvSales.Columns["sDate"];
                    col.HeaderText = "Date";
                    col.Width = 120;
                    col.DefaultCellStyle.Format = "dd-MMM-yyyy";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                // Add this with your other column configurations
                if (dgvSales.Columns.Contains("cId"))
                {
                    var col = dgvSales.Columns["cId"];
                    col.Visible = false; // Hide this column as we don't need to show it
                }

                if (dgvSales.Columns.Contains("Customer"))
                {
                    var col = dgvSales.Columns["Customer"];
                    col.HeaderText = "Customer";
                    col.Width = 250;
                }

                if (dgvSales.Columns.Contains("Total"))
                {
                    var col = dgvSales.Columns["Total"];
                    col.HeaderText = "Total";
                    col.Width = 120;
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvSales.Columns.Contains("Disc"))
                {
                    var col = dgvSales.Columns["Disc"];
                    col.HeaderText = "Discount";
                    col.Width = 120;
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvSales.Columns.Contains("GrandTotal"))
                {
                    var col = dgvSales.Columns["GrandTotal"];
                    col.HeaderText = "Grand Total";
                    col.Width = 120;
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales data: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (saleTable == null) return;

            string filter = txtSearch.Text.Trim().Replace("'", "''");
            saleTable.DefaultView.RowFilter =
                $"Customer LIKE '%{filter}%' OR ID = '{filter}'";
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            LoadSaleData();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            LoadSaleData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSales.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this sale?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvSales.SelectedRows[0].Cells["ID"].Value);
                    DeleteSale(id);
                    LoadSaleData();
                }
            }
            else
            {
                MessageBox.Show("Please select a sale to delete.");
            }
        }

        private void DeleteSale(int id)
        {
            string query = "DELETE FROM tblSale WHERE ID = ?";
            try
            {
                using (OleDbConnection conn = DB.GetConnection())
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting sale: " + ex.Message);
            }
        }


        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSales.Rows[e.RowIndex];

                if (row.Cells["ID"].Value != null)
                {
                    try
                    {
                        int id = Convert.ToInt32(row.Cells["ID"].Value);
                        DateTime sDate = Convert.ToDateTime(row.Cells["sDate"].Value);
                        int cId = row.Cells["cId"].Value != DBNull.Value ?
                                  Convert.ToInt32(row.Cells["cId"].Value) : -1;
                        decimal total = Convert.ToDecimal(row.Cells["Total"].Value);
                        decimal disc = Convert.ToDecimal(row.Cells["Disc"].Value);
                        decimal grandTotal = Convert.ToDecimal(row.Cells["GrandTotal"].Value);
                        SaleSelected?.Invoke(id, sDate, cId, total, disc, grandTotal);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while loading sale: " + ex.Message);
                    }
                }
            }
        }


        private int GetCustomerId(string customerName)
        {
            string query = "SELECT ID FROM tblCustomer WHERE cName = ?";
            try
            {
                using (OleDbConnection conn = DB.GetConnection())
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", customerName);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}