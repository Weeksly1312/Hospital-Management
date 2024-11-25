using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Middle_Hosp;
using Server_Hosp.Utils;

public class RegisterService : MarshalByRefObject, Middle_Hosp.RPC
{
    private readonly string connectionString = ServerManager.ConnectionString;
    public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Specialization { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int DepartmentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Gender { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    int RPC.ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string RPC.FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string RPC.LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string RPC.PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string RPC.Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string RPC.Gender { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string RPC.Specialization { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    int RPC.DepartmentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string RPC.Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string RPC.BloodType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    DateTime RPC.DateOfBirth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    int RPC.DoctorId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    int RPC.RoomId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string RPC.Diagnosis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public string RegisterUser(string username, string password)
{
    try
    {
        using (var conn = ServerManager.CreateConnection())
        {
            conn.Open();

            string checkQuery = "SELECT COUNT(*) FROM dbo.users WHERE username = @username";
            
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@username", username);
                int existingUserCount = (int)checkCmd.ExecuteScalar();

                if (existingUserCount > 0)
                {
                    return "Username already exists. Please choose a different username.";
                }
            }

            string insertQuery = "INSERT INTO dbo.users (username, password) VALUES (@username, @password)";
            
            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
            {
                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@password", password);

                int rowsAffected = insertCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Registration failed. Please try again.";
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
public bool Login(string username, string password)
    {
        throw new NotImplementedException();
    }

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

    public string ModifyDoctor(string connectionString, int doctorId, string firstName, string lastName, string phoneNumber, string specialization, int departmentId, string address, string gender, string status)
    {
        throw new NotImplementedException();
    }

    public List<string> GetDepartments(string connectionString)
    {
        throw new NotImplementedException();
    }

    public List<string> GetSpecializations(string connectionString)
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

    public List<RPC> GetDoctors(string connectionString)
    {
        throw new NotImplementedException();
    }

    public void Initialize(int patientId, string v1, string v2, string v3, string v4, DateTime value, string v5, string v6, int v7, int v8, string v9)
    {
        throw new NotImplementedException();
    }

    public string DeletePatient(string connectionString, int selectedPatientID)
    {
        throw new NotImplementedException();
    }

    public string Update(string connectionString, int patientId, string v1, string v2, string v3, string v4, DateTime value, string v5, string v6, int v7, int v8, string v9)
    {
        throw new NotImplementedException();
    }

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

    string RPC.Add(string connectionString)
    {
        throw new NotImplementedException();
    }

    List<RPC> RPC.GetAll(string connectionString)
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
}
