using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middle_Hosp
{
    public interface RPC
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Specialization { get; set; }
        int DepartmentId { get; set; }
        string Address { get; set; }
        string Gender { get; set; }
        string Status { get; set; }

        void Initialize(int id, string firstName, string lastName, string phoneNumber,
            string specialization, int departmentId, string address, string gender, string status);

        string Add(string connectionString);
        string DeleteDoctor(string connectionString, int doctorId);
        List<RPC> GetAll(string connectionString);
        string ModifyDoctor(string connectionString, int doctorId, string firstName, string lastName,
            string phoneNumber, string specialization, int departmentId, string address, string gender, string status);
    

        // Login @ signup
        bool Login(string username, string password);
        string RegisterUser(string username, string password);
        void Initialize(string text1, string text2, string text3, int v, string text4, string text5, string text6, string text7);

        List<string> GetDepartments(string connectionString);
        List<string> GetSpecializations(string connectionString);
        List<RPC> GetDoctors(string connectionString);
        void Initialize(int patientId, string v1, string v2, string v3, string v4, DateTime value, string v5, string v6, int v7, int v8, string v9);
        string DeletePatient(string connectionString, int selectedPatientID);
        string Update(string connectionString, int patientId, string v1, string v2, string v3, string v4, DateTime value, string v5, string v6, int v7, int v8, string v9);
    }
}
