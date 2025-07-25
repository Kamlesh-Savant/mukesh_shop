using System;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class ucHeader : UserControl
    {
        public void SetUsername(string username)
        {
            lblUsername.Text = $"Welcome, {username}";
        }

        public ucHeader()
        {
            InitializeComponent();
        }
    }
}
