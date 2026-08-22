using System;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class frmLogin : Form
    {
        private readonly User userService = new User();

        public frmLogin()
        {
            InitializeComponent();
            this.FormClosed += frmLogin_FormClosed;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter username and password.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int userId = userService.ValidateLogin(username, password);

                if (userId <= 0)
                {
                    MessageBox.Show(
                        "Username and password are incorrect.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    txtPassword.Clear();
                    txtUsername.Focus();
                    return;
                }

                Session.UserID = userId;
                Session.Username = username;

                frmDashboard dashboard = new frmDashboard();
                dashboard.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar =
                checkbxShowPas.Checked ? '\0' : '•';
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void clickRegister_Click(object sender, EventArgs e)
        {
            using (frmRegister register = new frmRegister())
            {
                register.ShowDialog(this);
            }

            txtUsername.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
