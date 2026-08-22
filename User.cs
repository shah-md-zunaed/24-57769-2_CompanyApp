using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeDetails
{
    public class User
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public int ValidateLogin(string username, string password)
        {
            const string query = @"
                SELECT UserID
                FROM dbo.Users
                WHERE Username = @Username
                  AND Password = @Password;";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();

                object result = cmd.ExecuteScalar();
                return result == null ? 0 : Convert.ToInt32(result);
            }
        }

        public bool UsernameExists(string username)
        {
            const string query = @"
                SELECT COUNT(1)
                FROM dbo.Users
                WHERE Username = @Username;";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);

                con.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public int RegisterUser(string username, string password)
        {
            const string query = @"
                INSERT INTO dbo.Users (Username, Password)
                OUTPUT INSERTED.UserID
                VALUES (@Username, @Password);";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
