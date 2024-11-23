using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Server_Hosp
{
    public class Patient : MarshalByRefObject
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

        #region Methods
        public void Initialize(int id, string firstName, string lastName, string gender,
            string bloodType, DateTime dateOfBirth, string phoneNumber, string address,
            int doctorId, int roomId, string diagnosis)
        {
            ID = id;
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

        public string Add(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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
                return $"Error: {ex.Message}";
            }
        }

        public string ModifyPatient(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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
                using (SqlConnection connection = new SqlConnection(connectionString))
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
                return $"Error: {ex.Message}";
            }
        }

        public List<Patient> GetAll(string connectionString)
        {
            List<Patient> patients = new List<Patient>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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
            catch
            {
                return null;
            }
        }

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
    }
}
