using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Middle_Hosp;
using Server_Hosp.Utils;

namespace Server_Hosp
{
    public class LoginService : MarshalByRefObject, Middle_Hosp.RPC
    {
        #region Fields and Properties
        private string connectionString = ServerManager.ConnectionString;

        // Interface Properties
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Specialization { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DepartmentName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DepartmentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Gender { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string RPC.BloodType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime RPC.DateOfBirth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int RPC.DoctorId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int RPC.RoomId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string RPC.Diagnosis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region Authentication Methods
        public bool Login(string username, string password)
        {
            try
            {
                using (var conn = ServerManager.CreateConnection())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM dbo.users WHERE username = @username AND password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login error: {ex.Message}");
                return false;
            }
        }

        public string RegisterUser(string username, string password)
        {
            try
            {
                using (var conn = ServerManager.CreateConnection())
                {
                    conn.Open();

                    string query = "INSERT INTO dbo.users (username, password) VALUES (@username, @password)";

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
                string result = string.Empty;
                ServerManager.HandleSqlException(ex, ref result);
                return result;
            }
            catch (Exception ex)
            {
                string result = string.Empty;
                ServerManager.HandleException(ex, ref result);
                return result;
            }
        }
        #endregion

        #region Not Implemented Interface Members
        // Doctor-related methods
        public string Add(string connectionString) => throw new NotImplementedException();
        public string DeleteDoctor(string connectionString, int doctorId) => throw new NotImplementedException();
        public string ModifyDoctor(string connectionString, int doctorId, string firstName, string lastName, 
            string phoneNumber, string specialization, int departmentId, string address, string gender, string status) 
            => throw new NotImplementedException();
        public List<string> GetDepartments(string connectionString) => throw new NotImplementedException();
        public List<string> GetSpecializations(string connectionString) => throw new NotImplementedException();
        public List<RPC> GetDoctors(string connectionString) => throw new NotImplementedException();

        // Patient-related methods
        public string DeletePatient(string connectionString, int selectedPatientID) => throw new NotImplementedException();
        public string Update(string connectionString, int patientId, string v1, string v2, string v3, string v4, 
            DateTime value, string v5, string v6, int v7, int v8, string v9) => throw new NotImplementedException();

        // General methods
        public List<RPC> GetAll(string connectionString) => throw new NotImplementedException();
        public void Initialize(int id, string firstName, string lastName, string phoneNumber, string specialization, 
            int departmentId, string address, string gender, string status) => throw new NotImplementedException();
        public void Initialize(string text1, string text2, string text3, int v, string text4, string text5, 
            string text6, string text7) => throw new NotImplementedException();
        public void Initialize(int patientId, string v1, string v2, string v3, string v4, DateTime value, 
            string v5, string v6, int v7, int v8, string v9) => throw new NotImplementedException();

        // Explicit interface implementations
        void RPC.Initialize(int patientId, string firstName, string lastName, string gender, string bloodType, 
            DateTime dateOfBirth, string phoneNumber, string address, int doctorId, int roomId, string diagnosis) 
            => throw new NotImplementedException();
        string RPC.Update(string connectionString, int patientId, string firstName, string lastName, string gender, 
            string bloodType, DateTime dateOfBirth, string phoneNumber, string address, int doctorId, int roomId, 
            string diagnosis) => throw new NotImplementedException();
        #endregion
    }
}
