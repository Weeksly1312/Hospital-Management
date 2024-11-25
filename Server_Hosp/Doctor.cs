using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Middle_Hosp;
using Server_Hosp.Utils;

namespace Server_Hosp
{
    public class Doctor : MarshalByRefObject, Middle_Hosp.RPC
    {
        #region Properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }
        public int DepartmentId { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        string RPC.BloodType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime RPC.DateOfBirth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int RPC.DoctorId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int RPC.RoomId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string RPC.Diagnosis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region Initialization Methods
        public void Initialize(int id, string firstName, string lastName, string phoneNumber,
            string specialization, int departmentId, string address, string gender, string status)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be empty");
            if (string.IsNullOrWhiteSpace(gender))
                throw new ArgumentException("Gender cannot be empty");
            if (departmentId <= 0)
                throw new ArgumentException("Invalid department ID");

            ID = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Specialization = specialization;
            DepartmentId = departmentId;
            Address = address;
            Gender = gender.ToUpper();
            Status = status ?? "Available";
        }
        #endregion

        #region Database Operations
        public string Add(string connectionString)
        {
            try
            {
                var (isValid, errorMessage) = ValidateDoctor(FirstName, LastName, PhoneNumber, 
                    DepartmentId, Gender, Status);
                
                if (!isValid)
                    return $"Error: {errorMessage}";

                int specializationId = int.Parse(Specialization.Split('-')[0].Trim());

                using (SqlConnection conn = ServerManager.CreateConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(GetInsertQuery(), conn))
                    {
                        AddParameters(cmd, specializationId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0 ? "Doctor added successfully!" : "No rows affected.";
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

        public string DeleteDoctor(string connectionString, int doctorId)
        {
            try
            {
                using (SqlConnection conn = ServerManager.CreateConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Doctors WHERE id = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", doctorId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0 ? "Doctor deleted successfully." : "No doctor found with that ID.";
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
            List<RPC> doctors = new List<RPC>();
            try
            {
                using (SqlConnection conn = ServerManager.CreateConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(GetSelectAllQuery(), conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            doctors.Add(CreateDoctorFromReader(reader));
                        }
                    }
                }
                return doctors;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                return null;
            }
        }

        public string ModifyDoctor(string connectionString, int doctorId, string firstName, string lastName,
            string phoneNumber, string specialization, int departmentId, string address, string gender, string status)
        {
            try
            {
                ID = doctorId;
                FirstName = firstName;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Specialization = specialization;
                DepartmentId = departmentId;
                Address = address;
                Gender = gender;
                Status = status;

                var (isValid, errorMessage) = ValidateDoctor(FirstName, LastName, PhoneNumber, 
                    DepartmentId, Gender, Status);
                
                if (!isValid)
                    return $"Error: {errorMessage}";

                int specializationId = int.Parse(specialization.Split('-')[0].Trim());

                using (SqlConnection conn = ServerManager.CreateConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(GetUpdateQuery(), conn))
                    {
                        AddParameters(cmd, specializationId);
                        cmd.Parameters["@ID"].Value = doctorId;
                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0 ? "Doctor details updated successfully." : "No doctor found with that ID.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public List<string> GetDepartments(string connectionString)
        {
            return GetLookupData("SELECT ID, Name FROM Departments ORDER BY ID");
        }

        public List<string> GetSpecializations(string connectionString)
        {
            return GetLookupData("SELECT ID, Name FROM Specializations ORDER BY ID");
        }
        #endregion

        #region Helper Methods
        private void AddParameters(SqlCommand cmd, int specializationId)
        {
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@SpecializationId", specializationId);
            cmd.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            cmd.Parameters.AddWithValue("@Address", (object)Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Gender", Gender.ToUpper());
            cmd.Parameters.AddWithValue("@Status", Status);
        }

        private Doctor CreateDoctorFromReader(SqlDataReader reader)
        {
            return new Doctor
            {
                ID = Convert.ToInt32(reader["id"]),
                FirstName = reader["first_name"].ToString(),
                LastName = reader["last_name"].ToString(),
                PhoneNumber = reader["phone_number"].ToString(),
                Specialization = reader["specialization"].ToString(),
                DepartmentId = Convert.ToInt32(reader["department_id"]),
                Address = reader["address"].ToString(),
                Gender = reader["gender"].ToString(),
                Status = reader["status"].ToString()
            };
        }

        private List<string> GetLookupData(string query)
        {
            List<string> items = new List<string>();
            try
            {
                using (SqlConnection conn = ServerManager.CreateConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add($"{reader["ID"]} - {reader["Name"]}");
                        }
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting data: {ex.Message}");
                return new List<string>();
            }
        }

        private (bool isValid, string errorMessage) ValidateDoctor(string firstName, string lastName, 
            string phoneNumber, int departmentId, string gender, string status)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return (false, "First name cannot be empty");
            if (string.IsNullOrWhiteSpace(lastName))
                return (false, "Last name cannot be empty");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return (false, "Phone number cannot be empty");
            if (string.IsNullOrWhiteSpace(gender))
                return (false, "Gender cannot be empty");
            if (departmentId <= 0)
                return (false, "Invalid department ID");
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\+?[\d\s-]+$"))
                return (false, "Invalid phone number format");
            if (gender.ToUpper() != "M" && gender.ToUpper() != "F")
                return (false, "Gender must be 'M' or 'F'");
            if (!IsValidStatus(status))
                return (false, "Invalid status value");

            return (true, string.Empty);
        }

        private bool IsValidStatus(string status)
        {
            string[] validStatuses = {
                "Available", "In Consultation", "On Break",
                "Off Duty", "In Surgery", "Unavailable", "Emergency"
            };
            return validStatuses.Contains(status);
        }

        private string GetInsertQuery() => @"
            INSERT INTO dbo.Doctors 
                (ID, first_name, last_name, phone_number, specialization_id, 
                department_id, address, gender, status) 
            VALUES 
                (@ID, @FirstName, @LastName, @PhoneNumber, @SpecializationId, 
                @DepartmentId, @Address, @Gender, @Status)";

        private string GetUpdateQuery() => @"
            UPDATE dbo.Doctors 
            SET first_name = @FirstName, 
                last_name = @LastName, 
                phone_number = @PhoneNumber,
                specialization_id = @SpecializationId,
                department_id = @DepartmentId,
                address = @Address,
                gender = @Gender,
                status = @Status
            WHERE id = @ID";

        private string GetSelectAllQuery() => @"
            SELECT d.id, d.first_name, d.last_name, d.phone_number, 
                   d.specialization_id as specialization, d.department_id, d.address, 
                   d.gender, d.status 
            FROM dbo.Doctors d";
        #endregion

        #region Not Implemented Interface Members
        public bool Login(string username, string password) => throw new NotImplementedException();
        public string RegisterUser(string username, string password) => throw new NotImplementedException();
        public void Initialize(string text1, string text2, string text3, int v, string text4, string text5, string text6, string text7) => throw new NotImplementedException();
        public List<RPC> GetDoctors(string connectionString) => throw new NotImplementedException();
        public void Initialize(int patientId, string v1, string v2, string v3, string v4, DateTime value, string v5, string v6, int v7, int v8, string v9) => throw new NotImplementedException();
        public string DeletePatient(string connectionString, int selectedPatientID) => throw new NotImplementedException();
        public string Update(string connectionString, int patientId, string v1, string v2, string v3, string v4, DateTime value, string v5, string v6, int v7, int v8, string v9) => throw new NotImplementedException();

        List<RPC> RPC.GetDoctors(string connectionString)
        {
            throw new NotImplementedException();
        }

        void RPC.Initialize(int patientId, string firstName, string lastName, string gender, string bloodType, DateTime dateOfBirth, string phoneNumber, string address, int doctorId, int roomId, string diagnosis)
        {
            throw new NotImplementedException();
        }

        string RPC.DeletePatient(string connectionString, int patientId)
        {
            throw new NotImplementedException();
        }

        string RPC.Update(string connectionString, int patientId, string firstName, string lastName, string gender, string bloodType, DateTime dateOfBirth, string phoneNumber, string address, int doctorId, int roomId, string diagnosis)
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
