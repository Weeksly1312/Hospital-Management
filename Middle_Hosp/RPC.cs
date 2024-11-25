using System;
using System.Collections.Generic;

namespace Middle_Hosp
{
    public interface RPC
    {
        // Basic personal information properties for both doctors and patients
        #region Common Properties
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string Gender { get; set; }
        #endregion

        // Properties specific to doctors only
        #region Doctor Specific Properties
        string Specialization { get; set; }
        int DepartmentId { get; set; }
        string Status { get; set; }
        string DepartmentName { get; set; }
        #endregion

        // Properties specific to patients only
        #region Patient Specific Properties
        string BloodType { get; set; }
        DateTime DateOfBirth { get; set; }
        int DoctorId { get; set; }
        int RoomId { get; set; }
        string Diagnosis { get; set; }
        #endregion

        // Methods for managing doctors (add, update, delete, get)
        #region Doctor Methods
        void Initialize(int id, string firstName, string lastName, string phoneNumber,
            string specialization, int departmentId, string address, string gender, string status);
        string DeleteDoctor(string connectionString, int doctorId);
        string ModifyDoctor(string connectionString, int doctorId, string firstName, string lastName,
            string phoneNumber, string specialization, int departmentId, string address,
            string gender, string status);
        List<string> GetDepartments(string connectionString);
        List<string> GetSpecializations(string connectionString);
        List<RPC> GetDoctors(string connectionString);
        #endregion

        // Methods for managing patients (add, update, delete)
        #region Patient Methods
        void Initialize(int patientId, string firstName, string lastName, string gender,
            string bloodType, DateTime dateOfBirth, string phoneNumber, string address,
            int doctorId, int roomId, string diagnosis);
        string DeletePatient(string connectionString, int patientId);
        string Update(string connectionString, int patientId, string firstName, string lastName,
            string gender, string bloodType, DateTime dateOfBirth, string phoneNumber,
            string address, int doctorId, int roomId, string diagnosis);
        #endregion

        // Shared methods for authentication and general operations
        #region Common Methods
        string Add(string connectionString);
        List<RPC> GetAll(string connectionString);
        bool Login(string username, string password);
        string RegisterUser(string username, string password);
        #endregion
        
    }
}