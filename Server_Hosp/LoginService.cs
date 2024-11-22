using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Middle_Hosp;

namespace Server_Hosp
{
    public class LoginService : MarshalByRefObject, Middle_Hosp.RPC
    {
        private string connectionString = @"Data Source=DESKTOP-C03F80S\SQLEXPRESS01;Initial Catalog=DoctorManagements;Integrated Security=True;Connect Timeout=30;";
            //@"Data Source=DESKTOP-MVIQ4R9\SQLEXPRESS01;Initial Catalog=New Database;Integrated Security=True;Connect Timeout=30;";

        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Specialization { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DepartmentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Gender { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Add(string connectionString)
        {
            throw new NotImplementedException();
        }

        public string DeleteDoctor(string connectionString, int doctorId)
        {
            throw new NotImplementedException();
        }

        public List<RPC> GetAll(string connectionString)
        {
            throw new NotImplementedException();
        }

        public List<string> GetDepartments(string connectionString)
        {
            throw new NotImplementedException();
        }

        public void Initialize(int id, string firstName, string lastName, string phoneNumber, string specialization, int departmentId, string address, string gender, string status)
        {
            throw new NotImplementedException();
        }

        public void Initialize(string text1, string text2, string text3, int v, string text4, string text5, string text6, string text7)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM dbo.users WHERE username = @username AND password = @password";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; // Returns true if credentials are correct
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login error: {ex.Message}");
                return false;
            }
        }

        public string ModifyDoctor(string connectionString, int doctorId, string firstName, string lastName, string phoneNumber, string specialization, int departmentId, string address, string gender, string status)
        {
            throw new NotImplementedException();
        }

        public string RegisterUser(string username, string password)
        {
            try
            {
                string query = "INSERT INTO dbo.users (username, password) VALUES (@username, @password)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return $"User '{username}' registered successfully!";
                        }
                        else
                        {
                            return "Registration failed. No rows affected.";
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle unique constraint errors or other SQL issues
                if (ex.Number == 2627) // Unique constraint violation
                {
                    return $"Username '{username}' already exists.";
                }

                Console.WriteLine($"SQL error: {ex.Message}");
                return "An error occurred during registration.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RegisterUser error: {ex.Message}");
                return "An unexpected error occurred.";
            }
        }
    }
}
