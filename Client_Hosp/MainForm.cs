using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Hosp
{
    public partial class MainForm : Form
    {
        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Navigation Methods
        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = true;
            addDoctor1.Visible = false;
            addPatient1.Visible = false;
            addRoom1.Visible = false;

            Dashboard dashForm = dashboard1 as Dashboard;
            if (dashForm != null)
            {
                dashForm.RefreshData();
            }
        }

        private void AddDoctor_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addDoctor1.Visible = true;
            addPatient1.Visible = false;
            addRoom1.Visible = false;
        }

        private void AddPatient_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addDoctor1.Visible = false;
            addPatient1.Visible = true;
            addRoom1.Visible = false;
        }

        private void AddRoom_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addDoctor1.Visible = false;
            addPatient1.Visible = false;
            addRoom1.Visible = true;
        }
        #endregion

        #region Session
        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?"
                , "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}

