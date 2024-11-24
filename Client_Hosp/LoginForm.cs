using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Middle_Hosp;
using Client_Hosp.Utils;

namespace Client_Hosp
{
    public partial class LoginForm : Form
    {
        private RPC ep;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = login_username.Text.Trim();
            string password = login_password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ConnectionManager.ShowError("Please fill all fields.");
                return;
            }

            try
            {
                bool isLoggedIn = ep.Login(username, password);
                if (isLoggedIn)
                {
                    ConnectionManager.ShowSuccess("Login successful!");
                    MainForm mForm = new MainForm();
                    mForm.Show();
                    this.Hide();
                }
                else
                {
                    ConnectionManager.ShowError("Incorrect username or password.");
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.ShowError(ex.Message);
            }
        }

        private void login_showPass_CheckedChanged_1(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RegisterForm regForm = new RegisterForm();
            //regForm.Show();
            //this.Hide();
        }

        private void exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.Show();
            this.Hide();
        }

        private void login_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
