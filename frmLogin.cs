using System;
using System.Drawing;
using System.Windows.Forms;

namespace MukeshShop
{
    public partial class frmLogin : Form
    {
        // ========== Color Constants ========== //
        private readonly Color _accentColor = Color.FromArgb(52, 152, 219);
        private readonly Color _inactiveColor = Color.LightGray;
        private readonly Color _placeholderColor = Color.DarkGray;
        private readonly Color _textColor = Color.FromArgb(44, 62, 80);
        private readonly Color _closeHoverColor = Color.FromArgb(231, 76, 60);

        public frmLogin()
        {
            InitializeComponent();
        }

        // ========== Placeholder Text Logic ========== //

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            // Highlight username field
            pnlUsernameUnderline.BackColor = _accentColor;

            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = _textColor;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            // Reset username field appearance
            pnlUsernameUnderline.BackColor = _inactiveColor;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = _placeholderColor;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            // Highlight password field
            pnlPasswordUnderline.BackColor = _accentColor;

            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = _textColor;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            // Reset password field appearance
            pnlPasswordUnderline.BackColor = _inactiveColor;

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = _placeholderColor;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        // ========== Form Control Events ========== //

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Only toggle if there's actual text (not placeholder)
            if (txtPassword.Text != "Password")
            {
                txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLogin())
            {
                if (txtUsername.Text == "admin" && txtPassword.Text == "welcome")
                {
                    this.DialogResult = DialogResult.OK; // notify Program.cs that login succeeded
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private bool ValidateLogin()
        {
            // Simple validation example
            if (txtUsername.Text == "Username" || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter your username", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (txtPassword.Text == "Password" || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter your password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        // ========== UI Effects ========== //

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            // Darken button on hover
            btnLogin.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            // Restore original color
            btnLogin.BackColor = _accentColor;
        }

        // ========== Form Dragging Logic ========== //
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // ========== Secondary Actions ========== //

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Password reset instructions will be sent to your email",
                          "Forgot Password",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }
    }
}