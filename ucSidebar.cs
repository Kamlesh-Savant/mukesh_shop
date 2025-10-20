using System.Windows.Forms;

namespace MukeshShop
{
    public partial class ucSidebar : UserControl
    {

        // Expose internal buttons to outside via public properties
        public Button BtnDashboard => btnDashboard;
        public Button BtnSales => btnSales;
        public Button BtnProducts => btnProducts;
        public Button BtnCustomers => btnCustomers;
        public Button BtnSettings => btnSettings;
        public Button BtnOrderList => btnOrderList;
        public Button BtnLogout => btnLogout;

        public ucSidebar()
        {
            InitializeComponent();
        }


        private void btnLogout_Click(object sender, System.EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }
    }
}
