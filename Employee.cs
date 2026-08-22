using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeDetails
{
    public class Employee
    {
        private static readonly string myConn =
            ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string Age { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public int? CreatedBy { get; set; }

        private const string SelectQuery = @"
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
                ON e.CreatedBy = u.UserID;";

        private const string InsertQuery = @"
            INSERT INTO dbo.Emp_details
                (EmpId, EmpName, EmpAge, EmpContact, EmpGender, CreatedBy)
            VALUES
                (@EmpId, @EmpName, @EmpAge, @EmpContact, @EmpGender, @CreatedBy);";

        private const string UpdateQuery = @"
            UPDATE dbo.Emp_details
            SET
                EmpName = @EmpName,
                EmpAge = @EmpAge,
                EmpContact = @EmpContact,
                EmpGender = @EmpGender
            WHERE EmpId = @EmpId;";

        private const string DeleteQuery = @"
            DELETE FROM dbo.Emp_details
            WHERE EmpId = @EmpId;";

        public DataTable GetEmployees()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection con = new SqlConnection(myConn))
            using (SqlCommand command = new SqlCommand(SelectQuery, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                con.Open();
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public bool InsertEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            using (SqlCommand command = new SqlCommand(InsertQuery, con))
            {
                command.Parameters.AddWithValue("@EmpId", employee.EmpId);
                command.Parameters.AddWithValue("@EmpName", employee.EmpName);
                command.Parameters.AddWithValue("@EmpAge", employee.Age);
                command.Parameters.AddWithValue(
                    "@EmpContact",
                    string.IsNullOrWhiteSpace(employee.ContactNo)
                        ? (object)DBNull.Value
                        : employee.ContactNo);
                command.Parameters.AddWithValue(
                    "@EmpGender",
                    string.IsNullOrWhiteSpace(employee.Gender)
                        ? (object)DBNull.Value
                        : employee.Gender);
                command.Parameters.AddWithValue(
                    "@CreatedBy",
                    employee.CreatedBy.HasValue
                        ? (object)employee.CreatedBy.Value
                        : DBNull.Value);

                con.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            using (SqlCommand command = new SqlCommand(UpdateQuery, con))
            {
                command.Parameters.AddWithValue("@EmpName", employee.EmpName);
                command.Parameters.AddWithValue("@EmpAge", employee.Age);
                command.Parameters.AddWithValue(
                    "@EmpContact",
                    string.IsNullOrWhiteSpace(employee.ContactNo)
                        ? (object)DBNull.Value
                        : employee.ContactNo);
                command.Parameters.AddWithValue(
                    "@EmpGender",
                    string.IsNullOrWhiteSpace(employee.Gender)
                        ? (object)DBNull.Value
                        : employee.Gender);
                command.Parameters.AddWithValue("@EmpId", employee.EmpId);

                con.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            using (SqlCommand command = new SqlCommand(DeleteQuery, con))
            {
                command.Parameters.AddWithValue("@EmpId", employee.EmpId);

                con.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
