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
        string RPC.Specialization { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int RPC.DepartmentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string RPC.Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime RPC.DateOfBirth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region Initialization Methods
        public void Initialize(int patientId, string firstName, string lastName, string gender,
            string bloodType, DateTime dateOfBirth, string phoneNumber, string address,
            int doctorId, int roomId, string diagnosis)
        {
            var (isValid, errorMessage) = ValidatePatient(firstName, lastName, gender, bloodType, phoneNumber, doctorId, roomId);
            if (!isValid)
                throw new ArgumentException(errorMessage);

            ID = patientId;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender.ToUpper();
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
                    using (SqlCommand command = new SqlCommand(GetInsertQuery(), connection))
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

        public string DeletePatient(string connectionString, int patientId)
        {
            try
            {
                using (SqlConnection connection = ServerManager.CreateConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM Patients WHERE id = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", patientId);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0 ? "Patient deleted successfully" : "No patient found with that ID";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public List<RPC> GetAll(string connectionString)
        {
            List<RPC> patients = new List<RPC>();
            try
            {
                using (SqlConnection connection = ServerManager.CreateConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(GetSelectAllQuery(), connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patients.Add(CreatePatientFromReader(reader));
                        }
                    }
                }
                return patients;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                return null;
            }
        }

        public string Update(string connectionString, int patientId, string firstName, string lastName,
            string gender, string bloodType, DateTime dateOfBirth, string phoneNumber, string address,
            int doctorId, int roomId, string diagnosis)
        {
            try
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

                var (isValid, errorMessage) = ValidatePatient(firstName, lastName, gender, bloodType, phoneNumber, doctorId, roomId);
                if (!isValid)
                    return $"Error: {errorMessage}";

                using (SqlConnection connection = ServerManager.CreateConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(GetUpdateQuery(), connection))
                    {
                        AddParameters(command);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0 ? "Patient updated successfully" : "No patient found with that ID";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        #endregion

        #region Helper Methods
        private void AddParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@id", ID);
            command.Parameters.AddWithValue("@firstName", FirstName);
            command.Parameters.AddWithValue("@lastName", LastName);
            command.Parameters.AddWithValue("@gender", Gender?.ToUpper());
            command.Parameters.AddWithValue("@bloodType", BloodType);
            command.Parameters.AddWithValue("@dateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@phoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@address", (object)Address ?? DBNull.Value);
            command.Parameters.AddWithValue("@doctorId", DoctorId);
            command.Parameters.AddWithValue("@roomId", RoomId);
            command.Parameters.AddWithValue("@diagnosis", (object)Diagnosis ?? DBNull.Value);
        }

        private Patient CreatePatientFromReader(SqlDataReader reader)
        {
            return new Patient
            {
                ID = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Gender = reader.GetString(3),
                BloodType = reader.GetString(4),
                DateOfBirth = reader.GetDateTime(5),
                PhoneNumber = reader.GetString(6),
                Address = reader.GetString(7),
                DoctorId = reader.GetInt32(8),
                RoomId = reader.GetInt32(9),
                Diagnosis = reader.GetString(10)
            };
        }

        private (bool isValid, string errorMessage) ValidatePatient(string firstName, string lastName,
            string gender, string bloodType, string phoneNumber, int doctorId, int roomId)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return (false, "First name cannot be empty");
            if (string.IsNullOrWhiteSpace(lastName))
                return (false, "Last name cannot be empty");
            if (string.IsNullOrWhiteSpace(gender))
                return (false, "Gender cannot be empty");
            if (string.IsNullOrWhiteSpace(bloodType))
                return (false, "Blood type cannot be empty");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return (false, "Phone number cannot be empty");
            if (doctorId <= 0)
                return (false, "Invalid doctor ID");
            if (roomId <= 0)
                return (false, "Invalid room ID");
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\+?[\d\s-]+$"))
                return (false, "Invalid phone number format");
            if (gender.ToUpper() != "M" && gender.ToUpper() != "F")
                return (false, "Gender must be 'M' or 'F'");

            return (true, string.Empty);
        }

        private string GetInsertQuery() => @"
            INSERT INTO Patients 
                (id, first_name, last_name, gender, blood_type, date_of_birth, 
                phone_number, address, doctor_id, room_id, diagnosis)
            VALUES 
                (@id, @firstName, @lastName, @gender, @bloodType, @dateOfBirth,
                @phoneNumber, @address, @doctorId, @roomId, @diagnosis)";

        private string GetUpdateQuery() => @"
            UPDATE Patients 
            SET first_name = @firstName,
                last_name = @lastName,
                gender = @gender,
                blood_type = @bloodType,
                date_of_birth = @dateOfBirth,
                phone_number = @phoneNumber,
                address = @address,
                doctor_id = @doctorId,
                room_id = @roomId,
                diagnosis = @diagnosis
            WHERE id = @id";

        private string GetSelectAllQuery() => @"
            SELECT * FROM Patients";

        void RPC.Initialize(int id, string firstName, string lastName, string phoneNumber, string specialization, int departmentId, string address, string gender, string status)
        {
            throw new NotImplementedException();
        }

        string RPC.DeleteDoctor(string connectionString, int doctorId)
        {
            throw new NotImplementedException();
        }

        string RPC.ModifyDoctor(string connectionString, int doctorId, string firstName, string lastName, string phoneNumber, string specialization, int departmentId, string address, string gender, string status)
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


        bool RPC.Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        string RPC.RegisterUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
