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

namespace Client_Hosp
{
    public partial class LoginForm : Form
    {
        RPC ep;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Check if we already have a TCP channel registered
                TcpChannel existingChannel = null;
                foreach (IChannel chan in ChannelServices.RegisteredChannels)
                {
                    if (chan is TcpChannel)
                    {
                        existingChannel = (TcpChannel)chan;
                        break;
                    }
                }

                // Only create and register a new channel if one doesn't exist
                if (existingChannel == null)
                {
                    TcpChannel chnl = new TcpChannel();
                    ChannelServices.RegisterChannel(chnl, false);
                }

                // Get the remote object (RPC object)
                ep = (Middle_Hosp.RPC)Activator.GetObject(
                    typeof(Middle_Hosp.RPC),
                    "tcp://localhost:2222/login");

                if (ep == null)
                {
                    throw new Exception("Failed to connect to RPC server");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize connection: {ex.Message}", "Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = login_username.Text.Trim();
            string password = login_password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Call the server's Login method
                bool isLoggedIn = ep.Login(username, password);

                if (isLoggedIn)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Proceed to the next form

                    MainForm mForm = new MainForm();
                    mForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
