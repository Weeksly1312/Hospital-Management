using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using Middle_Hosp;

namespace Server_Hosp
{
    public class Doctor : MarshalByRefObject, Middle_Hosp.RPC
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }
        public int DepartmentId { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }

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

        public string Add(string connectionString)
        {
            try
            {
                if (!IsValidStatus(Status))
                {
                    return "Error: Invalid status value";
                }

                string query = @"INSERT INTO dbo.Doctors 
                    (first_name, last_name, phone_number, specialization, department_id, address, gender, status) 
                    VALUES (@FirstName, @LastName, @PhoneNumber, @Specialization, @DepartmentId, @Address, @Gender, @Status)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", FirstName);
                        cmd.Parameters.AddWithValue("@LastName", LastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        cmd.Parameters.AddWithValue("@Specialization", (object)Specialization ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DepartmentId", DepartmentId);
                        cmd.Parameters.AddWithValue("@Address", (object)Address ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Gender", Gender.ToUpper());
                        cmd.Parameters.AddWithValue("@Status", Status);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0 ? "Doctor added successfully!" : "No rows affected.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private bool IsValidStatus(string status)
        {
            string[] validStatuses = new string[]
            {
                "Available",
                "In Consultation",
                "On Break",
                "Off Duty",
                "In Surgery",
                "Unavailable",
                "Emergency"
            };

            return validStatuses.Contains(status);
        }

        public string DeleteDoctor(string connectionString, int doctorId)
        {
            try
            {
                string query = "DELETE FROM dbo.Doctors WHERE id = @ID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
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
                string query = @"SELECT id, first_name, last_name, phone_number, specialization, 
                               department_id, address, gender, status FROM dbo.Doctors";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Doctor doc = new Doctor
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
                                doctors.Add(doc);
                            }
                        }
                    }
                }
                return doctors;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public string ModifyDoctor(string connectionString, int doctorId, string firstName, string lastName,
            string phoneNumber, string specialization, int departmentId, string address, string gender, string status)
        {
            try
            {
                if (!IsValidStatus(status))
                {
                    return "Error: Invalid status value";
                }

                string query = @"UPDATE dbo.Doctors 
                    SET first_name = @FirstName, 
                        last_name = @LastName, 
                        phone_number = @PhoneNumber,
                        specialization = @Specialization,
                        department_id = @DepartmentId,
                        address = @Address,
                        gender = @Gender,
                        status = @Status
                    WHERE id = @ID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", doctorId);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@Specialization", (object)specialization ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
                        cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Gender", gender.ToUpper());
                        cmd.Parameters.AddWithValue("@Status", status);

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

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string RegisterUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Initialize(string text1, string text2, string text3, int v, string text4, string text5, string text6, string text7)
        {
            throw new NotImplementedException();
        }
    }

}
