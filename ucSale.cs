using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MukeshShop
{
    public partial class ucSale : UserControl
    {
        public event EventHandler SaveCompleted;
        private DataTable productsTable = new DataTable();
        private int? currentSaleId = null;

        public ucSale()
        {
            InitializeComponent();
            this.Load += ucSale_Load;
            InitializeProductsTable();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            btnAddProduct.Click += btnAddProduct_Click;
            btnRemoveProduct.Click += btnRemoveProduct_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            txtDiscount.TextChanged += txtDiscount_TextChanged;
            dgvProducts.CellEndEdit += DgvProducts_CellEndEdit;
            cmbCustomer.SelectedIndexChanged += cmbCustomer_SelectedIndexChanged;
        }

        private void InitializeProductsTable()
        {
            productsTable = new DataTable("SaleProducts");
            productsTable.Columns.Add("ID", typeof(int));
            productsTable.Columns.Add("Product", typeof(string));
            productsTable.Columns.Add("Quantity", typeof(decimal));
            productsTable.Columns.Add("Rate", typeof(decimal));
            productsTable.Columns.Add("Amount", typeof(decimal));
        }

        private void ucSale_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            ConfigureProductsGrid();
        }

        public void LoadSale(int id, DateTime sDate, int cId, decimal total, decimal disc, decimal grandTotal)
        {
            try
            {
                currentSaleId = id;

                LoadCustomers();
                txtBillNo.Text = id.ToString();
                txtTotal.Text = total.ToString("N2");
                txtDiscount.Text = disc.ToString("N2");
                txtGrandTotal.Text = grandTotal.ToString("N2");
                dtpSaleDate.Value = sDate;

                if (cId > 0)
                {
                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke((MethodInvoker)delegate {
                            SetCustomerSelection(cId);
                        });
                    }
                    else
                    {
                        this.HandleCreated += (s, e) => {
                            this.BeginInvoke((MethodInvoker)delegate {
                                SetCustomerSelection(cId);
                            });
                        };
                    }
                }
                else
                {
                    cmbCustomer.SelectedIndex = -1;
                    txtMobile.Clear();
                }

                LoadSaleItems(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sale: " + ex.Message);
            }
        }

        private void SetCustomerSelection(int cId)
        {
            try
            {
                cmbCustomer.SelectedValue = cId;

                if (cmbCustomer.SelectedIndex == -1 && cmbCustomer.Items.Count > 0)
                {
                    for (int i = 0; i < cmbCustomer.Items.Count; i++)
                    {
                        DataRowView drv = (DataRowView)cmbCustomer.Items[i];
                        if (Convert.ToInt32(drv["ID"]) == cId)
                        {
                            cmbCustomer.SelectedIndex = i;
                            break;
                        }
                    }
                }

                if (cmbCustomer.SelectedItem is DataRowView selectedRow)
                {
                    txtMobile.Text = selectedRow["Mobile"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting customer selection: " + ex.Message);
            }
        }

        private void LoadSaleItems(int saleId)
        {
            try
            {
                productsTable.Rows.Clear();

                string query = @"SELECT p.ID, p.pName AS Product, si.Quantity, si.Rate, 
                                (si.Quantity * si.Rate) AS Amount
                                FROM tblSaleItems si
                                INNER JOIN tblProduct p ON si.pId = p.ID
                                WHERE si.sId = ?";

                var parameters = new OleDbParameter[] { DB.CreateParameter("sId", saleId, OleDbType.Integer) };
                DataTable items = DB.GetData(query, parameters);

                foreach (DataRow row in items.Rows)
                {
                    productsTable.ImportRow(row);
                }

                CalculateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sale items: " + ex.Message);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                object currentSelection = cmbCustomer.SelectedValue;

                DataTable dt = DB.GetData("SELECT ID, cName, Mobile FROM tblCustomer ORDER BY cName");
                cmbCustomer.DataSource = dt;
                cmbCustomer.DisplayMember = "cName";
                cmbCustomer.ValueMember = "ID";

                if (currentSelection != null)
                    cmbCustomer.SelectedValue = currentSelection;
                else
                    cmbCustomer.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex >= 0)
            {
                DataRowView selectedRow = (DataRowView)cmbCustomer.SelectedItem;
                txtMobile.Text = selectedRow["Mobile"].ToString();
            }
            else
            {
                txtMobile.Clear();
            }
        }

        private void ConfigureProductsGrid()
        {
            dgvProducts.Columns.Clear();
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = productsTable;

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colID",
                DataPropertyName = "ID",
                Visible = false
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProduct",
                DataPropertyName = "Product",
                HeaderText = "Product",
                Width = 250,
                ReadOnly = true
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                DataPropertyName = "Quantity",
                HeaderText = "Quantity",
                Width = 100
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRate",
                DataPropertyName = "Rate",
                HeaderText = "Rate",
                Width = 100,
                ReadOnly = true
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAmount",
                DataPropertyName = "Amount",
                HeaderText = "Amount",
                Width = 120,
                ReadOnly = true
            });

            dgvProducts.RowTemplate.Height = 30;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using (var productSelect = new frmProductSelection())
            {
                if (productSelect.ShowDialog() == DialogResult.OK)
                {
                    foreach (var product in productSelect.SelectedProducts)
                    {
                        if (!productsTable.AsEnumerable().Any(row => Convert.ToInt32(row["ID"]) == product.Id))
                        {
                            var row = productsTable.NewRow();
                            row["ID"] = product.Id;
                            row["Product"] = product.Name;
                            row["Quantity"] = 1;
                            row["Rate"] = product.Rate;
                            row["Amount"] = product.Rate;
                            productsTable.Rows.Add(row);
                        }
                    }
                    CalculateTotals();
                }
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvProducts.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dgvProducts.Rows.Remove(row);
                }
            }
            CalculateTotals();
        }

        private void DgvProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].Name == "colQuantity")
            {
                var row = dgvProducts.Rows[e.RowIndex];
                if (decimal.TryParse(row.Cells["colQuantity"].Value?.ToString(), out decimal qty) &&
                    decimal.TryParse(row.Cells["colRate"].Value?.ToString(), out decimal rate))
                {
                    row.Cells["colAmount"].Value = qty * rate;
                    CalculateTotals();
                }
            }
        }

        private void CalculateTotals()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (!row.IsNewRow && decimal.TryParse(row.Cells["colAmount"].Value?.ToString(), out decimal amt))
                    total += amt;
            }
            txtTotal.Text = total.ToString("N2");
            CalculateGrandTotal();
        }

        private void CalculateGrandTotal()
        {
            if (decimal.TryParse(txtTotal.Text, out decimal total) &&
                decimal.TryParse(txtDiscount.Text, out decimal discount))
            {
                txtGrandTotal.Text = (total - discount).ToString("N2");
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateGrandTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateSale())
            {
                SaveSale();
            }
        }

        private bool ValidateSale()
        {
            if (cmbCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer");
                return false;
            }

            if (dgvProducts.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one product");
                return false;
            }

            if (!decimal.TryParse(txtDiscount.Text, out _))
            {
                MessageBox.Show("Please enter a valid discount");
                return false;
            }

            return true;
        }

        private int SaveSaleHeader(OleDbConnection conn, OleDbTransaction tran)
        {
            string query = "INSERT INTO tblSale (sDate, cId, Total, Disc, GrandTotal) VALUES (?, ?, ?, ?, ?)";
            var cmd = new OleDbCommand(query, conn, tran);

            cmd.Parameters.AddRange(new OleDbParameter[]
            {
                DB.CreateDateParameter("sDate", dtpSaleDate.Value),
                DB.CreateParameter("cId", cmbCustomer.SelectedValue, OleDbType.Integer),
                DB.CreateParameter("Total", Convert.ToDecimal(txtTotal.Text), OleDbType.Decimal),
                DB.CreateParameter("Disc", Convert.ToDecimal(txtDiscount.Text), OleDbType.Decimal),
                DB.CreateParameter("GrandTotal", Convert.ToDecimal(txtGrandTotal.Text), OleDbType.Decimal)
            });

            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT @@IDENTITY";
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void UpdateSaleHeader(int saleId, OleDbConnection conn, OleDbTransaction tran)
        {
            string query = "UPDATE tblSale SET sDate = ?, cId = ?, Total = ?, Disc = ?, GrandTotal = ? WHERE ID = ?";
            var cmd = new OleDbCommand(query, conn, tran);

            cmd.Parameters.AddRange(new OleDbParameter[]
            {
                DB.CreateDateParameter("sDate", dtpSaleDate.Value.Date),
                DB.CreateParameter("cId", cmbCustomer.SelectedValue, OleDbType.Integer),
                DB.CreateParameter("Total", Convert.ToDecimal(txtTotal.Text), OleDbType.Decimal),
                DB.CreateParameter("Disc", Convert.ToDecimal(txtDiscount.Text), OleDbType.Decimal),
                DB.CreateParameter("GrandTotal", Convert.ToDecimal(txtGrandTotal.Text), OleDbType.Decimal),
                DB.CreateParameter("ID", saleId, OleDbType.Integer)
            });

            cmd.ExecuteNonQuery();
        }

        private void DeleteSaleItems(int saleId, OleDbConnection conn, OleDbTransaction tran)
        {
            string query = "DELETE FROM tblSaleItems WHERE sId = ?";
            var cmd = new OleDbCommand(query, conn, tran);
            cmd.Parameters.AddWithValue("?", saleId);
            cmd.ExecuteNonQuery();
        }

        private void SaveSaleItems(int saleId, OleDbConnection conn, OleDbTransaction tran)
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (!row.IsNewRow && row.DataBoundItem is DataRowView drv)
                {
                    string query = "INSERT INTO tblSaleItems (sId, pId, Quantity, Rate) VALUES (?, ?, ?, ?)";
                    var cmd = new OleDbCommand(query, conn, tran);
                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        DB.CreateParameter("sId", saleId, OleDbType.Integer),
                        DB.CreateParameter("pId", drv["ID"], OleDbType.Integer),
                        DB.CreateParameter("Quantity", drv["Quantity"], OleDbType.Decimal),
                        DB.CreateParameter("Rate", drv["Rate"], OleDbType.Decimal)
                    });
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SaveCompleted?.Invoke(this, EventArgs.Empty);
        }
        private void SaveSale()
        {
            using (OleDbConnection conn = DB.GetConnection())
            {
                conn.Open();
                var tran = conn.BeginTransaction();

                try
                {
                    int saleId;

                    if (currentSaleId.HasValue)
                    {
                        UpdateSaleHeader(currentSaleId.Value, conn, tran);
                        DeleteSaleItems(currentSaleId.Value, conn, tran);
                        saleId = currentSaleId.Value;
                    }
                    else
                    {
                        saleId = SaveSaleHeader(conn, tran);
                    }

                    SaveSaleItems(saleId, conn, tran);
                    tran.Commit();
                    MessageBox.Show("Sale saved successfully!");
                    PrintReceipt();
                    SaveCompleted?.Invoke(this, EventArgs.Empty);
                    currentSaleId = null;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error saving sale: " + ex.Message);
                }
            }
        }

        private void PrintReceipt()
        {
            List<ReceiptItem> receiptItems = new List<ReceiptItem>();

            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (!row.IsNewRow)
                {
                    receiptItems.Add(new ReceiptItem
                    {
                        Name = row.Cells["colProduct"].Value.ToString(),
                        Qty = Convert.ToDecimal(row.Cells["colQuantity"].Value),
                        Rate = Convert.ToDecimal(row.Cells["colRate"].Value)
                    });
                }
            }

            string shopName = "", shopAddress = "", mobile1 = "", mobile2 = "", gstNo = "";

            // Open connection and get profile info
            using (OleDbConnection conn = DB.GetConnection())
            {
                conn.Open();
                using (OleDbTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "SELECT * FROM tblProfile WHERE ID = 1";
                        var cmd = new OleDbCommand(query, conn, tran);
                        var dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            shopName = dr["shopName"].ToString();
                            shopAddress = dr["shopAddress"].ToString();
                            mobile1 = dr["Mobile1"].ToString();
                            mobile2 = dr["Mobile2"].ToString();
                            gstNo = dr["gstNo"].ToString();
                        }

                        dr.Close();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Error fetching company data: " + ex.Message);
                        return;
                    }
                }
            }

            var printer = new ReceiptPrinter(
                shopName: shopName,
                shopAddress: shopAddress,
                mobile1: mobile1,
                mobile2: mobile2,
                gstNo: gstNo,
                billNo: txtBillNo.Text,
                saleDate: dtpSaleDate.Value,
                customerName: cmbCustomer.Text,
                customerMobile: txtMobile.Text,
                items: receiptItems,
                total: Convert.ToDecimal(txtTotal.Text),
                discount: Convert.ToDecimal(txtDiscount.Text),
                grandTotal: Convert.ToDecimal(txtGrandTotal.Text)
            );

            printer.Print();
        }

    }
}
