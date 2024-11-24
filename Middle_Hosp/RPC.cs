using System;
using System.Collections.Generic;

namespace Middle_Hosp
{
    public interface RPC
    {
        #region Common Properties
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string Gender { get; set; }
        #endregion

        #region Doctor Specific Properties
        string Specialization { get; set; }
        int DepartmentId { get; set; }
        string Status { get; set; }
        #endregion

        #region Patient Specific Properties
        string BloodType { get; set; }
        DateTime DateOfBirth { get; set; }
        int DoctorId { get; set; }
        int RoomId { get; set; }
        string Diagnosis { get; set; }
        #endregion

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

        #region Patient Methods
        void Initialize(int patientId, string firstName, string lastName, string gender,
            string bloodType, DateTime dateOfBirth, string phoneNumber, string address,
            int doctorId, int roomId, string diagnosis);
        string DeletePatient(string connectionString, int patientId);
        string Update(string connectionString, int patientId, string firstName, string lastName,
            string gender, string bloodType, DateTime dateOfBirth, string phoneNumber,
            string address, int doctorId, int roomId, string diagnosis);
        #endregion

        #region Common Methods
        string Add(string connectionString);
        List<RPC> GetAll(string connectionString);
        bool Login(string username, string password);
        string RegisterUser(string username, string password);
        #endregion
    }
}