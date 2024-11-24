using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Middle_Hosp;
using Server_Hosp.Utils;

namespace Server_Hosp
{
    public class Patient : MarshalByRefObject, Middle_Hosp.RPC
    {
        #region Properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string BloodType { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int DoctorId { get; set; }
        public int RoomId { get; set; }
        public string Diagnosis { get; set; }
        #endregion

        #region Initialization Methods
        public void Initialize(int patientId, string firstName, string lastName, string gender,
            string bloodType, DateTime dateOfBirth, string phoneNumber, string address,
            int doctorId, int roomId, string diagnosis)
        {
            ID = patientId;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BloodType = bloodType;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Address = address;
            DoctorId = doctorId;
            RoomId = roomId;
            Diagnosis = diagnosis;
        }
        #endregion

        #region Database Operations
        public string Add(string connectionString)
        {
            try
            {
                using (SqlConnection connection = ServerManager.CreateConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO Patients (id, first_name, last_name, gender, 
                        blood_type, date_of_birth, phone_number, address, doctor_id, room_id, diagnosis)
                        VALUES (@id, @firstName, @lastName, @gender, @bloodType, @dateOfBirth,
                        @phoneNumber, @address, @doctorId, @roomId, @diagnosis)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddParameters(command);
                        command.ExecuteNonQuery();
                    }
                }
                return "Patient added successfully";
            }
            catch (Exception ex)
            {
                string result = string.Empty;
                ServerManager.HandleException(ex, ref result);
                return result;
            }
        }

        public string ModifyPatient(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ServerManager.ConnectionString))
                {
                    connection.Open();
                    string query = @"UPDATE Patients SET first_name = @firstName, last_name = @lastName,
                        gender = @gender, blood_type = @bloodType, date_of_birth = @dateOfBirth,
                        phone_number = @phoneNumber, address = @address, doctor_id = @doctorId,
                        room_id = @roomId, diagnosis = @diagnosis WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddParameters(command);
                        command.ExecuteNonQuery();
                    }
                }
                return "Patient modified successfully";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string DeletePatient(string connectionString, int patientId)
        {
            try
            {
                using (SqlConnection connection = ServerManager.CreateConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Patients WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", patientId);
                        command.ExecuteNonQuery();
                    }
                }
                return "Patient deleted successfully";
            }
            catch (Exception ex)
            {
                string result = string.Empty;
                ServerManager.HandleException(ex, ref result);
                return result;
            }
        }

        public List<RPC> GetAll(string connectionString)
        {
            var patients = new List<RPC>();
            try
            {
                using (SqlConnection connection = ServerManager.CreateConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Patients";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Patient patient = new Patient();
                                patient.Initialize(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetString(4),
                                    reader.GetDateTime(5),
                                    reader.GetString(6),
                                    reader.GetString(7),
                                    reader.GetInt32(8),
                                    reader.GetInt32(9),
                                    reader.GetString(10)
                                );
                                patients.Add(patient);
                            }
                        }
                    }
                }
                return patients;
            }
            catch (Exception ex)
            {
                string result = string.Empty;
                ServerManager.HandleException(ex, ref result);
                return null;
            }
        }
        #endregion

        #region Helper Methods
        private void AddParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@id", ID);
            command.Parameters.AddWithValue("@firstName", FirstName);
            command.Parameters.AddWithValue("@lastName", LastName);
            command.Parameters.AddWithValue("@gender", Gender);
            command.Parameters.AddWithValue("@bloodType", BloodType);
            command.Parameters.AddWithValue("@dateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@phoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@address", Address);
            command.Parameters.AddWithValue("@doctorId", DoctorId);
            command.Parameters.AddWithValue("@roomId", RoomId);
            command.Parameters.AddWithValue("@diagnosis", Diagnosis ?? (object)DBNull.Value);
        }
        #endregion

        #region Not Implemented Interface Members
        // RPC Interface members that are not implemented for Patient class
        public string Specialization { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DepartmentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int RPC.ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string RPC.FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string RPC.LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string RPC.PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string RPC.Specialization { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int RPC.DepartmentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string RPC.Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string RPC.Gender { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string RPC.Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Login(string username, string password) => throw new NotImplementedException();
        public string RegisterUser(string username, string password) => throw new NotImplementedException();
        public List<RPC> GetDoctors(string connectionString) => throw new NotImplementedException();
        public void Initialize(string text1, string text2, string text3, int v, string text4, string text5, string text6, string text7) => throw new NotImplementedException();
        public void Initialize(int id, string firstName, string lastName, string phoneNumber, string specialization, int departmentId, string address, string gender, string status) => throw new NotImplementedException();
        public string DeleteDoctor(string connectionString, int doctorId) => throw new NotImplementedException();
        public string ModifyDoctor(string connectionString, int doctorId, string firstName, string lastName, string phoneNumber, string specialization, int departmentId, string address, string gender, string status) => throw new NotImplementedException();
        public List<string> GetDepartments(string connectionString) => throw new NotImplementedException();
        public List<string> GetSpecializations(string connectionString) => throw new NotImplementedException();

        void RPC.Initialize(int id, string firstName, string lastName, string phoneNumber, string specialization, int departmentId, string address, string gender, string status)
        {
            throw new NotImplementedException();
        }

        string RPC.Add(string connectionString)
        {
            throw new NotImplementedException();
        }

        string RPC.DeleteDoctor(string connectionString, int doctorId)
        {
            throw new NotImplementedException();
        }

        List<RPC> RPC.GetAll(string connectionString)
        {
            throw new NotImplementedException();
        }

        string RPC.ModifyDoctor(string connectionString, int doctorId, string firstName, string lastName, string phoneNumber, string specialization, int departmentId, string address, string gender, string status)
        {
            throw new NotImplementedException();
        }

        bool RPC.Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        string RPC.RegisterUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        void RPC.Initialize(string text1, string text2, string text3, int v, string text4, string text5, string text6, string text7)
        {
            throw new NotImplementedException();
        }

        List<string> RPC.GetDepartments(string connectionString)
        {
            throw new NotImplementedException();
        }

        List<string> RPC.GetSpecializations(string connectionString)
        {
            throw new NotImplementedException();
        }

        List<RPC> RPC.GetDoctors(string connectionString)
        {
            throw new NotImplementedException();
        }

        void RPC.Initialize(int patientId, string v1, string v2, string v3, string v4, DateTime value, string v5, string v6, int v7, int v8, string v9)
        {
            throw new NotImplementedException();
        }

        string RPC.DeletePatient(string connectionString, int selectedPatientID)
        {
            throw new NotImplementedException();
        }

        string RPC.Update(string connectionString, int patientId, string v1, string v2, string v3, string v4, DateTime value, string v5, string v6, int v7, int v8, string v9)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}