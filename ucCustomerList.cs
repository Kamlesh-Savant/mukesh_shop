using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class ucCustomerList : UserControl
    {
        public event EventHandler AddClicked;
        public event Action<int, string, string, string, string> CustomerSelected;

        private DataTable customerTable;

        public ucCustomerList()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            try
            {
                string query = "SELECT ID, cName, cAddress, Mobile, ContactPerson FROM tblCustomer";
                customerTable = DB.GetData(query);

                dgvCustomers.Columns.Clear();
                dgvCustomers.DataSource = customerTable;

                dgvCustomers.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                dgvCustomers.RowTemplate.Height = 35;

                if (dgvCustomers.Columns.Contains("ID"))
                {
                    var col = dgvCustomers.Columns["ID"];
                    col.HeaderText = "ID";
                    col.Width = 80;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvCustomers.Columns.Contains("cName"))
                {
                    var col = dgvCustomers.Columns["cName"];
                    col.HeaderText = "Name";
                    col.Width = 250;
                }

                if (dgvCustomers.Columns.Contains("cAddress"))
                {
                    var col = dgvCustomers.Columns["cAddress"];
                    col.HeaderText = "Address";
                    col.Width = 300;
                }

                if (dgvCustomers.Columns.Contains("Mobile"))
                {
                    var col = dgvCustomers.Columns["Mobile"];
                    col.HeaderText = "Mobile";
                    col.Width = 150;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvCustomers.Columns.Contains("ContactPerson"))
                {
                    var col = dgvCustomers.Columns["ContactPerson"];
                    col.HeaderText = "Contact Person";
                    col.Width = 200;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer data: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (customerTable == null) return;

            string filter = txtSearch.Text.Trim().Replace("'", "''");
            customerTable.DefaultView.RowFilter =
                $"cName LIKE '%{filter}%' OR cAddress LIKE '%{filter}%' OR Mobile LIKE '%{filter}%' OR ContactPerson LIKE '%{filter}%'";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this customer?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["ID"].Value);
                    DeleteCustomer(id);
                    LoadCustomerData();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        private void DeleteCustomer(int id)
        {
            string query = "DELETE FROM tblCustomer WHERE ID = ?";
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
                MessageBox.Show("Error deleting customer: " + ex.Message);
            }
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomers.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["ID"].Value);
                string name = row.Cells["cName"].Value.ToString();
                string address = row.Cells["cAddress"].Value.ToString();
                string mobile = row.Cells["Mobile"].Value.ToString();
                string contactPerson = row.Cells["ContactPerson"].Value.ToString();

                CustomerSelected?.Invoke(id, name, address, mobile, contactPerson);
            }
        }
    }
}