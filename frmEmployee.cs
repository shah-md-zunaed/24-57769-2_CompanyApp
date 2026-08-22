using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class frmEmployee : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        // =========================
        // LOAD EMPLOYEES
        // =========================
        private void LoadEmployees()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        SELECT
                            e.EmpId,
                            e.EmpName,
                            e.EmpAge,
                            e.EmpContact,
                            e.EmpGender,
                            e.CreatedBy,
                            u.Username AS CreatedByUsername
                        FROM dbo.Emp_details e
                        LEFT JOIN dbo.Users u
                            ON e.CreatedBy = u.UserID";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvEmployees.DataSource = dt;
                    }
                }
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

        // =========================
        // ADD EMPLOYEE
        // =========================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string empId = txtID.Text.Trim();
            string empName = txtName.Text.Trim();
            string ageText = txtAge.Text.Trim();
            string empContact = txtContact.Text.Trim();
            string empGender = txtGender.Text.Trim();

            if (empId == "" ||
                empName == "" ||
                ageText == "")
            {
                MessageBox.Show(
                    "Please enter Employee ID, Name and Age.",
                    "Input Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int empAge;

            if (!int.TryParse(ageText, out empAge))
            {
                MessageBox.Show(
                    "Age must be a number.",
                    "Invalid Age",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAge.Focus();
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.Emp_details
                        WHERE EmpId = @EmpId";

                    using (SqlCommand checkCmd =
                        new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@EmpId", empId);

                        int count =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "Employee ID already exists.",
                                "Duplicate ID",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtID.Focus();
                            return;
                        }
                    }

                    string insertQuery = @"
                        INSERT INTO dbo.Emp_details
                        (
                            EmpId,
                            EmpName,
                            EmpAge,
                            EmpContact,
                            EmpGender,
                            CreatedBy
                        )
                        VALUES
                        (
                            @EmpId,
                            @EmpName,
                            @EmpAge,
                            @EmpContact,
                            @EmpGender,
                            @CreatedBy
                        )";

                    using (SqlCommand cmd =
                        new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@EmpId", empId);

                        cmd.Parameters.AddWithValue(
                            "@EmpName", empName);

                        cmd.Parameters.AddWithValue(
                            "@EmpAge", empAge);

                        cmd.Parameters.AddWithValue(
                            "@EmpContact",
                            string.IsNullOrWhiteSpace(empContact)
                                ? (object)DBNull.Value
                                : empContact);

                        cmd.Parameters.AddWithValue(
                            "@EmpGender",
                            string.IsNullOrWhiteSpace(empGender)
                                ? (object)DBNull.Value
                                : empGender);

                        cmd.Parameters.AddWithValue(
                            "@CreatedBy",
                            Session.UserID);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Employee added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadEmployees();
                ClearFields();
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

        // =========================
        // UPDATE EMPLOYEE
        // =========================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string empId = txtID.Text.Trim();
            string empName = txtName.Text.Trim();
            string ageText = txtAge.Text.Trim();
            string empContact = txtContact.Text.Trim();
            string empGender = txtGender.Text.Trim();

            if (empId == "" ||
                empName == "" ||
                ageText == "")
            {
                MessageBox.Show(
                    "Please select an employee and fill in the required fields.",
                    "Input Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int empAge;

            if (!int.TryParse(ageText, out empAge))
            {
                MessageBox.Show(
                    "Age must be a number.",
                    "Invalid Age",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAge.Focus();
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        UPDATE dbo.Emp_details
                        SET
                            EmpName = @EmpName,
                            EmpAge = @EmpAge,
                            EmpContact = @EmpContact,
                            EmpGender = @EmpGender
                        WHERE EmpId = @EmpId";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@EmpId", empId);

                        cmd.Parameters.AddWithValue(
                            "@EmpName", empName);

                        cmd.Parameters.AddWithValue(
                            "@EmpAge", empAge);

                        cmd.Parameters.AddWithValue(
                            "@EmpContact",
                            string.IsNullOrWhiteSpace(empContact)
                                ? (object)DBNull.Value
                                : empContact);

                        cmd.Parameters.AddWithValue(
                            "@EmpGender",
                            string.IsNullOrWhiteSpace(empGender)
                                ? (object)DBNull.Value
                                : empGender);

                        int rows =
                            cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageBox.Show(
                                "Employee not found.",
                                "Update Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Employee updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadEmployees();
                ClearFields();
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

        // =========================
        // DELETE EMPLOYEE
        // =========================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string empId = txtID.Text.Trim();

            if (empId == "")
            {
                MessageBox.Show(
                    "Please select an employee first.",
                    "Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this employee?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        DELETE FROM dbo.Emp_details
                        WHERE EmpId = @EmpId";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@EmpId", empId);

                        int rows =
                            cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageBox.Show(
                                "Employee not found.",
                                "Delete Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Employee deleted successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadEmployees();
                ClearFields();
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

        // =========================
        // CLEAR
        // =========================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtContact.Clear();
            txtGender.Clear();

            txtID.Focus();
        }

        // =========================
        // CLOSE
        // =========================
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =========================
        // DATAGRIDVIEW CELL CLICK
        // =========================
        private void dgvEmployees_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvEmployees.Rows[e.RowIndex];

            txtID.Text =
                row.Cells["EmpId"].Value?.ToString();

            txtName.Text =
                row.Cells["EmpName"].Value?.ToString();

            txtAge.Text =
                row.Cells["EmpAge"].Value?.ToString();

            txtContact.Text =
                row.Cells["EmpContact"].Value?.ToString();

            txtGender.Text =
                row.Cells["EmpGender"].Value?.ToString();
        }

        // =========================
        // CELL CONTENT CLICK
        // =========================
        private void dgvEmployees_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }
    }
}