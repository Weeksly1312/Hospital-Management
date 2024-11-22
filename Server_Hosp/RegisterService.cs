using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Middle_Hosp;

public class RegisterService : MarshalByRefObject, RPC
{
    private readonly string connectionString = @"Data Source=DESKTOP-C03F80S\SQLEXPRESS01;Initial Catalog=DoctorManagements;Integrated Security=True;Connect Timeout=30;";
    //@"Data Source=DESKTOP-MVIQ4R9\SQLEXPRESS01;Initial Catalog=New Database;Integrated Security=True;Connect Timeout=30";
    public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Specialization { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int DepartmentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Gender { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public string RegisterUser(string username, string password)
{
    try
    {
        // Check if username already exists
        string checkQuery = "SELECT COUNT(*) FROM dbo.users WHERE username = @username";
        
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            // First, check if username is already taken
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@username", username);
                int existingUserCount = (int)checkCmd.ExecuteScalar();

                if (existingUserCount > 0)
                {
                    return "Username already exists. Please choose a different username.";
                }
            }

            // If username is unique, proceed with registration
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
    catch (Exception ex)
    {
        Console.WriteLine($"Registration error: {ex.Message}");
        return $"Error: {ex.Message}";
    }
}
    //public string RegisterUser(string username, string password)
    //{
    //    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
    //        return "Please fill all blank fields.";

    //    try
    //    {
    //        if (_connect.State != System.Data.ConnectionState.Open)
    //        {
    //            _connect.Open();
    //        }

    //        // Check if the user already exists
    //        string selectUsername = "SELECT COUNT(id) FROM dbo.users WHERE username = @user";
    //        using (SqlCommand checkUser = new SqlCommand(selectUsername, _connect))
    //        {
    //            checkUser.Parameters.AddWithValue("@user", username.Trim());
    //            int count = (int)checkUser.ExecuteScalar();

    //            if (count >= 1)
    //            {
    //                return $"{username.Trim()} is already taken.";
    //            }
    //        }

    //        // Insert new user
    //        string insertData = "INSERT INTO dbo.users (username, password) VALUES(@username, @password)";
    //        using (SqlCommand cmd = new SqlCommand(insertData, _connect))
    //        {
    //            cmd.Parameters.AddWithValue("@username", username.Trim());
    //            cmd.Parameters.AddWithValue("@password", password.Trim());
    //            cmd.ExecuteNonQuery();
    //        }

    //        return "Registered successfully!";
    //    }
    //    catch (Exception ex)
    //    {
    //        return $"Error: {ex.Message}";
    //    }
    //    finally
    //    {
    //        if (_connect.State == System.Data.ConnectionState.Open)
    //        {
    //            _connect.Close();
    //        }
    //    }
    //}


public bool Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public void Initialize(int id, string firstName, string lastName, string phoneNumber, string specialization, int departmentId, string address, string gender, string status)
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

    public void Initialize(string text1, string text2, string text3, int v, string text4, string text5, string text6, string text7)
    {
        throw new NotImplementedException();
    }
}

//using System.Data.SqlClient;
//using System.Drawing;
//using System.Linq;
//using System.Runtime.Remoting.Contexts;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace HospitalAPP
//{
//    public partial class RegisterForm : Form
//    {
//        SqlConnection connect
//            = new SqlConnection(@"Data Source=DESKTOP-MVIQ4R9\SQLEXPRESS01;Initial Catalog=New Database;Integrated Security=True;Connect Timeout=30");
//        public RegisterForm()
//        {
//            InitializeComponent();
//        }

//        private void label7_Click(object sender, EventArgs e)
//        {

//        }

//        private void exit_Click(object sender, EventArgs e)
//        {
//            Application.Exit();
//        }

//        private void login_showPass_CheckedChanged(object sender, EventArgs e)
//        {

//            signup_password.PasswordChar = signup_showPass.Checked ? '\0' : '*';


//        }


//        private void login_btn_Click(object sender, EventArgs e)
//        {
//            if (signup_username.Text == ""
//                || signup_password.Text == "")
//            {
//                MessageBox.Show("Please fill all blank fields"
//                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            else
//            {
//                if (connect.State != ConnectionState.Open)
//                {
//                    try
//                    {
//                        connect.Open();
//                        // TO CHECK IF THE USER IS EXISTING ALREADY
//                        string selectUsername = "SELECT COUNT(id) FROM dbo.users WHERE username = @user";

//                        using (SqlCommand checkUser = new SqlCommand(selectUsername, connect))
//                        {
//                            checkUser.Parameters.AddWithValue("@user", signup_username.Text.Trim());
//                            int count = (int)checkUser.ExecuteScalar();

//                            if (count >= 1)
//                            {
//                                MessageBox.Show(signup_username.Text.Trim() + " is already taken"
//                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                            }
//                            else
//                            {
//                                DateTime today = DateTime.Today;

//                                string insertData = "INSERT INTO dbo.users " +
//                                    "(username, password ) " +
//                                "VALUES(@username, @password)";

//                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
//                                {
//                                    cmd.Parameters.AddWithValue("@username", signup_username.Text.Trim());
//                                    cmd.Parameters.AddWithValue("@password", signup_password.Text.Trim());
//                                    //cmd.Parameters.AddWithValue("@dateReg", today);

//                                    cmd.ExecuteNonQuery();

//                                    MessageBox.Show("Registered successfully!"
//                                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                                    //Form1 loginForm = new Form1();
//                                    //loginForm.Show();
//                                    //this.Hide();
//                                }
//                            }
//                        }



//                    }
//                    catch (Exception ex)
//                    {
//                        MessageBox.Show("Error: " + ex
//                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                    finally
//                    {
//                        connect.Close();
//                    }
//                }
//            }
//        }

//        private void signup_loginBtn_Click(object sender, EventArgs e)
//        {
//            LoginForm regForm = new LoginForm();
//            regForm.Show();
//            this.Hide();
//        }

//        private void RegisterForm_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}
