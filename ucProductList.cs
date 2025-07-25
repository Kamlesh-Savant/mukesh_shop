using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class ucProductList : UserControl
    {
        public event EventHandler AddClicked;
        public event Action<string, string, string, decimal> ProductSelected;

        private DataTable productTable;

        public ucProductList()
        {
            InitializeComponent();
            LoadProductData();
            txtSearch.TextChanged += TxtSearch_TextChanged;
            dgvProducts.CellDoubleClick += dgvProducts_CellDoubleClick;
        }

        private void LoadProductData()
        {
            try
            {
                string query = "SELECT ID, pName, pUnit, pRate FROM tblProduct WHERE isActive = 1";
                productTable = DB.GetData(query);

                dgvProducts.Columns.Clear();
                dgvProducts.DataSource = productTable;

                dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                dgvProducts.RowTemplate.Height = 35;

                if (dgvProducts.Columns.Contains("ID"))
                {
                    var col = dgvProducts.Columns["ID"];
                    col.HeaderText = "ID";
                    col.Width = 100;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvProducts.Columns.Contains("pName"))
                {
                    var col = dgvProducts.Columns["pName"];
                    col.HeaderText = "Name";
                    col.Width = 400;
                }

                if (dgvProducts.Columns.Contains("pUnit"))
                {
                    var col = dgvProducts.Columns["pUnit"];
                    col.HeaderText = "Unit";
                    col.Width = 150;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvProducts.Columns.Contains("pRate"))
                {
                    var col = dgvProducts.Columns["pRate"];
                    col.HeaderText = "Rate";
                    col.Width = 150;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.DefaultCellStyle.Format = "N2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product data: " + ex.Message);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (productTable == null) return;

            string filter = txtSearch.Text.Trim().Replace("'", "''");
            productTable.DefaultView.RowFilter =
                $"pName LIKE '%{filter}%' OR pUnit LIKE '%{filter}%'";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ID"].Value);
                    DeleteProduct(id);
                    LoadProductData();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void DeleteProduct(int id)
        {
            string query = "UPDATE tblProduct SET isActive = 0 WHERE ID = ?";
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
                MessageBox.Show("Error deleting product: " + ex.Message);
            }
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                string code = row.Cells["ID"].Value.ToString();
                string name = row.Cells["pName"].Value.ToString();
                string unit = row.Cells["pUnit"].Value.ToString();
                decimal rate = Convert.ToDecimal(row.Cells["pRate"].Value);

                ProductSelected?.Invoke(code, name, unit, rate);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertDefaultProducts();
            LoadProductData(); // Refresh the grid
        }

        private void InsertDefaultProducts()
        {
            var products = new List<(string Name, string Unit, decimal Rate, byte IsActive)>
    {
        ("तीखा / खट्टा मीठा मिक्स", "पट्टी", 5.00m, 1),
        ("नायलॉन / भावनगर गांठिया", "पट्टी", 5.00m, 1),
        ("तीखा / वनेला गांठिया", "पट्टी", 5.00m, 1),
        ("चंपाकली गांठिया", "पट्टी", 5.00m, 1),
        ("क्रिस्पी पापड़ी", "पट्टी", 5.00m, 1),
        ("पापड़ी गांठिया", "पट्टी", 5.00m, 1),
        ("तीखी पापड़ी", "पट्टी", 5.00m, 1),
        ("तीखा मोरा", "पट्टी", 5.00m, 1),
        ("सेव ममरा", "पट्टी", 5.00m, 1),
        ("गार्लिक / मसाला सेव ममरा", "पट्टी", 5.00m, 1),
        ("पापड़ चेवड़ा", "पट्टी", 5.00m, 1),
        ("स्पेशल | नायलॉन सेव", "पट्टी", 5.00m, 1),
        ("तीखी सेव", "पट्टी", 5.00m, 1),
        ("रतलामी / आलू सेव", "पट्टी", 5.00m, 1),
        ("सेव बुंदी", "पट्टी", 5.00m, 1),
        ("दाल मुठ", "पट्टी", 5.00m, 1),
        ("सिंग भजिया", "पट्टी", 5.00m, 1),
        ("सक्करपारा", "पट्टी", 5.00m, 1),
        ("भाखरवड़ी", "पट्टी", 5.00m, 1),
        ("मैजिक पूरी", "पट्टी", 5.00m, 1),
        ("नायलॉन चेवड़ा", "पट्टी", 5.00m, 1),
        ("मसाला चना दाल", "पट्टी", 5.00m, 1),
        ("दाबेला चना", "पट्टी", 5.00m, 1),
        ("चोको बिस्किट", "पट्टी", 5.00m, 1),
        ("राजवाड़ी काजू बिस्किट", "पट्टी", 5.00m, 1),
        ("मीठा | फराली चेवड़ा", "पट्टी", 5.00m, 1),
        ("सोचा स्टिक", "पट्टी", 5.00m, 1),
        ("पंजाबी तड़का", "पट्टी", 5.00m, 1),
        ("क्लासिक पीनट्स", "पट्टी", 5.00m, 1),
        ("हिंग जीरा पीनट्स", "पट्टी", 5.00m, 1),
        ("आलू भजिया", "पट्टी", 5.00m, 1),
        ("युग दाल", "पट्टी", 5.00m, 1),
        ("टमाटर पफ", "पट्टी", 5.00m, 1),
        ("रिंग मसाला / रिंग टमाटर", "पट्टी", 5.00m, 1),
        ("मुन चिप्स मसाला / टमाटर", "पट्टी", 5.00m, 1),
        ("सॉल्टेड कंसी पाइप", "पट्टी", 5.00m, 1),
        ("मसाला पाइप-बिरयानी", "पट्टी", 5.00m, 1),
        ("व्हाइट क्रंची पापड़", "पट्टी", 5.00m, 1),
        ("चीज़ी नूडल्स", "पट्टी", 5.00m, 1),
        ("चाइनीज़ चिली पाइप", "पट्टी", 5.00m, 1),
        ("पास्ता", "पट्टी", 5.00m, 1),
        ("स्मॉल कप टमाटर", "पट्टी", 5.00m, 1),
        ("एबीसीडी", "पट्टी", 5.00m, 1),
        ("यमस सेव", "पट्टी", 5.00m, 1),
        ("एनिमल", "पट्टी", 5.00m, 1),
        ("सॉफ्टी ट्रायंगल", "पट्टी", 5.00m, 1),
        ("विल्स मसाला", "पट्टी", 5.00m, 1),
        ("चोखड़ी", "पट्टी", 5.00m, 1),
        ("प्लेन", "पट्टी", 5.00m, 1),
        ("पॉपकॉर्न", "पट्टी", 5.00m, 1),
        ("सागो बॉल", "पट्टी", 5.00m, 1),
        ("स्टिक्स-क्रीम और प्याज", "पट्टी", 5.00m, 1),
        ("स्टिक्स-इमली | टमाटर", "पट्टी", 5.00m, 1),
        ("प्लेन सॉल्टेड पटैटो चिप्स", "पट्टी", 5.00m, 1),
        ("मैजिक मसाला पटैटो चिप्स", "पट्टी", 5.00m, 1),
        ("टमाटर पटैटो चिप्स", "पट्टी", 5.00m, 1),
        ("क्रीम एंड ओनियन पटैटो चिप्स", "पट्टी", 5.00m, 1),
        ("उपवास पटैटो चिप्स", "पट्टी", 5.00m, 1),
        ("स्पाइसी ट्रीट पटैटो चिप्स", "पट्टी", 5.00m, 1),
        ("पिरी-पिरी पटैटो चिप्स", "पट्टी", 5.00m, 1),
        ("चोको वनीला केक", "पट्टी", 5.00m, 1),
        ("मिनी मस्का बन", "पट्टी", 5.00m, 1),
        ("चॉकलेट कुकी केक", "पट्टी", 5.00m, 1),
        ("यम केक (मिक्सबेरी)", "पट्टी", 5.00m, 1),
        ("कप केक (चॉकलेट)/(वनीला)", "पट्टी", 5.00m, 1),
        ("टिफिन केक (फ्रूट)", "पट्टी", 5.00m, 1),
        ("रोल-चॉकलेट / ऑरेंज", "पट्टी", 5.00m, 1),
        ("उड़द पापड़", "पट्टी", 5.00m, 1)
    };

            try
            {
                using (OleDbConnection conn = DB.GetConnection())
                {
                    conn.Open();
                    int insertedCount = 0;

                    foreach (var (Name, Unit, Rate, IsActive) in products)
                    {
                        string query = "INSERT INTO tblProduct (pName, pUnit, pRate, isActive) VALUES (?, ?, ?, ?)";
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@p1", Name);
                            cmd.Parameters.AddWithValue("@p2", Unit);
                            cmd.Parameters.AddWithValue("@p3", Rate);
                            cmd.Parameters.AddWithValue("@p4", IsActive);
                            cmd.ExecuteNonQuery();
                            insertedCount++;
                        }
                    }

                    MessageBox.Show($"Successfully inserted {insertedCount} products!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting products: " + ex.Message);
            }
        }

    }
}
