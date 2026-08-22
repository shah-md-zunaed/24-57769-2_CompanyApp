using System;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome, " + Session.Username;
        }

        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            frmEmployee employeeForm = new frmEmployee();
            employeeForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            Session.Clear();

            frmLogin login = new frmLogin();
            login.Show();

            this.Close();
        }

        private void visitWeb_Click(object sender, EventArgs e)
        {
            try
            {
                bmBrowser.Navigate("https://www.bloggingmetrics.com/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void bmBrowser_DocumentCompleted(
            object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
        }
    }
}
