using System;
using System.Windows.Forms;
using Middle_Hosp;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using Client_Hosp.Utils;

namespace Client_Hosp
{
    public partial class RegisterForm : Form
    {
        RPC ep;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            try
            {
                ep = ConnectionManager.InitializeRPCConnection("login");
            }
            catch (Exception ex)
            {
                ConnectionManager.ShowError(ex.Message);
            }
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            string username = signup_username.Text.Trim();
            string password = signup_password.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all fields.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check password length
            if (password.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters long.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Call the server's RegisterUser method
                string result = ep.RegisterUser(username, password);

                if (result.Contains("successfully"))
                {
                    MessageBox.Show(result, "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Return to login form
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result, "Registration Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void signup_loginBtn_Click(object sender, EventArgs e)
        {
            // Return to login form
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_showPass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showPass.Checked ? '\0' : '*';
        }
    }
}
