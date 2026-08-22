using System;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class frmRegister : Form
    {
        private readonly User userService = new User();

        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Please fill in all fields.",
                    "Registration Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Password does not match.",
                    "Registration Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Clear();
                txtConPassword.Clear();
                txtPassword.Focus();
                return;
            }

            try
            {
                if (userService.UsernameExists(username))
                {
                    MessageBox.Show(
                        "Username already exists.",
                        "Registration Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtUsername.Focus();
                    return;
                }

                userService.RegisterUser(username, password);

                MessageBox.Show(
                    "Account created successfully!",
                    "Registration Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
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
            char passwordChar = checkbxShowPas.Checked ? '\0' : '•';
            txtPassword.PasswordChar = passwordChar;
            txtConPassword.PasswordChar = passwordChar;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConPassword.Clear();
            txtUsername.Focus();
        }

        private void clickLogin_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
