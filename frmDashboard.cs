using System;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();

            // Sidebar button navigation
            ucSidebar1.BtnDashboard.Click += (s, e) => LoadControl(new ucDashboard());
            ucSidebar1.BtnCustomers.Click += (s, e) => ShowCustomerList();
            ucSidebar1.BtnSettings.Click += (s, e) => LoadControl(new ucSetting());
            ucSidebar1.BtnProducts.Click += (s, e) => ShowProductList();
            ucSidebar1.BtnSales.Click += (s, e) => ShowSaleList();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            ucHeader1.SetUsername("Admin");
            LoadControl(new ucDashboard()); // default load
        }

        // 🔁 Utility to replace current UserControl in panel
        private void LoadControl(Control ctrl)
        {
            pnlContentContainer.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            pnlContentContainer.Controls.Add(ctrl);
        }

        // 📦 Load product list page
        private void ShowProductList()
        {
            var productList = new ucProductList();

            productList.AddClicked += (sender, args) =>
            {
                var productForm = new ucProduct();
                productForm.SaveCompleted += (s, e) => ShowProductList(); // refresh after save
                LoadControl(productForm);
            };

            productList.ProductSelected += (code, name, unit, rate) =>
            {
                var productForm = new ucProduct();
                productForm.LoadProduct(code, name, unit, rate); // load product in form
                productForm.SaveCompleted += (s, e) => ShowProductList(); // refresh after save
                LoadControl(productForm);
            };

            LoadControl(productList);
        }

        // 👤 Load customer list page
        private void ShowCustomerList()
        {
            var customerList = new ucCustomerList();

            customerList.AddClicked += (sender, args) =>
            {
                var customerForm = new ucCustomer();
                customerForm.SaveCompleted += (s, e) => ShowCustomerList(); // refresh after save
                LoadControl(customerForm);
            };

            customerList.CustomerSelected += (id, name, address, mobile, contactPerson) =>
            {
                var customerForm = new ucCustomer();
                customerForm.LoadCustomer(id, name, address, mobile, contactPerson);
                customerForm.SaveCompleted += (s, e) => ShowCustomerList(); // refresh after save
                LoadControl(customerForm);
            };

            LoadControl(customerList);
        }

        // 🧾 Load sale list page
        private void ShowSaleList()
        {
            var saleList = new ucSaleList();

            saleList.AddClicked += (sender, args) =>
            {
                var saleForm = new ucSale();
                saleForm.SaveCompleted += (s, e) => ShowSaleList(); // refresh after save
                LoadControl(saleForm);
            };

            saleList.SaleSelected += (id, sDate, cId, total, disc, grandTotal) =>
            {
                var saleForm = new ucSale();
                saleForm.SaveCompleted += (s, e) => ShowSaleList(); // refresh after save

                // 👇 Delay LoadSale until after control is shown
                LoadControl(saleForm);

                // 👇 Use BeginInvoke to run LoadSale after UI thread has rendered control
                this.BeginInvoke((MethodInvoker)delegate
                {
                    saleForm.LoadSale(id, sDate, cId, total, disc, grandTotal);
                });
            };

            LoadControl(saleList);
        }

    }
}
