using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class ucCustomer : UserControl
    {
        public ucCustomer()
        {
            InitializeComponent();
        }
        public event EventHandler SaveCompleted;

        public void LoadCustomer(int id, string name, string address, string mobile, string contactPerson)
        {
            txtID.Text = id.ToString();
            txtName.Text = name;
            txtAddress.Text = address;
            txtMobile.Text = mobile;
            txtContactPerson.Text = contactPerson;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idText = txtID.Text.Trim();
            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string mobile = txtMobile.Text.Trim();
            string contactPerson = txtContactPerson.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter customer name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(mobile))
            {
                MessageBox.Show("Please enter mobile number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection conn = DB.GetConnection())
                {
                    conn.Open();

                    if (!string.IsNullOrEmpty(idText)) // Update existing customer
                    {
                        int id = Convert.ToInt32(idText);
                        string updateQuery = "UPDATE tblCustomer SET cName = ?, cAddress = ?, Mobile = ?, ContactPerson = ? WHERE ID = ?";

                        using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("?", name);
                            updateCmd.Parameters.AddWithValue("?", address);
                            updateCmd.Parameters.AddWithValue("?", mobile);
                            updateCmd.Parameters.AddWithValue("?", contactPerson);
                            updateCmd.Parameters.AddWithValue("?", id);

                            int rowsAffected = updateCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Customer updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SaveCompleted?.Invoke(this, EventArgs.Empty);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("No matching customer found to update.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                
                    else // Insert new customer
                    {
                        string insertQuery = "INSERT INTO tblCustomer (cName, cAddress, Mobile, ContactPerson) VALUES (?, ?, ?, ?)";

                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("?", name);
                            insertCmd.Parameters.AddWithValue("?", address);
                            insertCmd.Parameters.AddWithValue("?", mobile);
                            insertCmd.Parameters.AddWithValue("?", contactPerson);

                            insertCmd.ExecuteNonQuery();
                            MessageBox.Show("Customer added successfully.", "Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SaveCompleted?.Invoke(this, EventArgs.Empty);
                            return;
                        }
                    }
                }

                // Clear form after successful save (only if not returning after success)
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtID.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtMobile.Clear();
            txtContactPerson.Clear();
        }
    }
}