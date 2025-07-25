using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class ucProduct : UserControl
    {
        public ucProduct()
        {
            InitializeComponent();
        }
        public event EventHandler SaveCompleted;

        public void LoadProduct(string code, string name, string unit, decimal rate)
        {
            txtCode.Text = code;
            txtName.Text = name;
            cmbUnit.SelectedItem = unit;
            txtRate.Text = rate.ToString("0.##");
        }


        void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            string name = txtName.Text.Trim();
            string unit = cmbUnit.SelectedItem?.ToString();
            string rateText = txtRate.Text.Trim();
            decimal rate;

            // 🧪 Validate
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(unit))
            {
                MessageBox.Show("Please select a unit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(rateText, out rate) || rate < 0)
            {
                MessageBox.Show("Please enter a valid rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection conn = DB.GetConnection())
                {
                    conn.Open();

                    if (!string.IsNullOrEmpty(code))
                    {
                        // 🔁 Update if code is present
                        string updateQuery = "UPDATE tblProduct SET pName = ?, pUnit = ?, pRate = ? WHERE ID = ?";
                        using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("?", name);
                            updateCmd.Parameters.AddWithValue("?", unit);
                            updateCmd.Parameters.AddWithValue("?", rate);
                            updateCmd.Parameters.AddWithValue("?", Convert.ToInt32(code));

                            int rowsAffected = updateCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Product updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SaveCompleted?.Invoke(this, EventArgs.Empty);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("No matching product found to update.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        // ➕ Insert if no code provided
                        string insertQuery = "INSERT INTO tblProduct (pName, pUnit, pRate, isActive) VALUES (?, ?, ?, 1)";
                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("?", name);
                            insertCmd.Parameters.AddWithValue("?", unit);
                            insertCmd.Parameters.AddWithValue("?", rate);

                            insertCmd.ExecuteNonQuery();
                            MessageBox.Show("Product inserted successfully.", "Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SaveCompleted?.Invoke(this, EventArgs.Empty);
                            return; // skip clearing form
                        }
                    }
                }

                // 🔄 Clear form after success
                txtCode.Clear();
                txtName.Clear();
                cmbUnit.SelectedIndex = -1;
                txtRate.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
