using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class ucSetting : UserControl
    {
        private int profileId = -1;

        public ucSetting()
        {
            InitializeComponent();
            LoadProfile();
        }

        private void LoadProfile()
        {
            try
            {
                string query = "SELECT ID, shopName, shopAddress, gstNo, Mobile1, Mobile2 FROM tblProfile";
                DataTable dt = DB.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    profileId = Convert.ToInt32(row["ID"]);
                    txtName.Text = row["shopName"].ToString();
                    txtAddress.Text = row["shopAddress"].ToString();
                    txtGstNo.Text = row["gstNo"].ToString();
                    txtMobile1.Text = row["Mobile1"].ToString();
                    txtMobile2.Text = row["Mobile2"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string shopName = txtName.Text.Trim();
            string shopAddress = txtAddress.Text.Trim();
            string gstNo = txtGstNo.Text.Trim();
            string mobile1 = txtMobile1.Text.Trim();
            string mobile2 = txtMobile2.Text.Trim();

            string query = @"
                UPDATE tblProfile SET 
                    shopName = ?, 
                    shopAddress = ?, 
                    gstNo = ?, 
                    Mobile1 = ?, 
                    Mobile2 = ?
                WHERE ID = 1";

            try
            {
                using (OleDbConnection conn = DB.GetConnection())
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", shopName);
                    cmd.Parameters.AddWithValue("?", shopAddress);
                    cmd.Parameters.AddWithValue("?", gstNo);
                    cmd.Parameters.AddWithValue("?", mobile1);
                    cmd.Parameters.AddWithValue("?", mobile2);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("Profile updated successfully.");
                    else
                        MessageBox.Show("Update failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message);
            }
        }
    }
}
