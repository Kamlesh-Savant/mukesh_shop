using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class frmProductSelection : Form
    {
        public List<Product> SelectedProducts { get; private set; } = new List<Product>();
        private DataTable productsTable;

        public frmProductSelection()
        {
            InitializeComponent();
            LoadProducts();
            ConfigureGrid();

            dgvProducts.CellDoubleClick += DgvProducts_CellDoubleClick;
            dgvProducts.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && dgvProducts.CurrentRow != null)
                {
                    e.Handled = true;
                    btnAdd_Click(s, e);
                }
            };
        }

        private void LoadProducts()
        {
            try
            {
                productsTable = DB.GetData("SELECT ID, pName, pUnit, pRate FROM tblProduct WHERE isActive = 1 ORDER BY pName");
                dgvProducts.DataSource = productsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                DataPropertyName = "ID",
                Visible = false
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colName",
                DataPropertyName = "pName",
                HeaderText = "Product Name",
                Width = 250,
                ReadOnly = true
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colUnit",
                DataPropertyName = "pUnit",
                HeaderText = "Unit",
                Width = 200,
                ReadOnly = true
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colRate",
                DataPropertyName = "pRate",
                HeaderText = "Rate",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvProducts.RowTemplate.Height = 30;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = true;
            dgvProducts.AllowUserToAddRows = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim().Replace("'", "''"); // Escape single quotes
            if (productsTable != null)
            {
                productsTable.DefaultView.RowFilter = $"pName LIKE '%{filter}%'";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SelectedProducts.Clear();

            foreach (DataGridViewRow row in dgvProducts.SelectedRows)
            {
                try
                {
                    SelectedProducts.Add(new Product
                    {
                        Id = Convert.ToInt32(row.Cells["colId"].Value),
                        Name = row.Cells["colName"].Value.ToString(),
                        Unit = row.Cells["colUnit"].Value.ToString(),
                        Rate = Convert.ToDecimal(row.Cells["colRate"].Value)
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing selection: " + ex.Message);
                    SelectedProducts.Clear();
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void DgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnAdd_Click(sender, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
