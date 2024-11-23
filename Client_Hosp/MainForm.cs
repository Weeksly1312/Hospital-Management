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
       
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

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

            //salary1.Visible = false;

            AddDoctor addEmForm = addDoctor1 as AddDoctor;

            //if (addEmForm != null)
            //{
            //    addEmForm.RefreshData();
            //}
        }

        private void dashboard1_Load(object sender, EventArgs e)
        {

        }

        

        private void addDoctor2_Load(object sender, EventArgs e)
        {

        }

        private void AddDoctor1_Load(object sender, EventArgs e)
        {

        }

        private void AddPatient_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addDoctor1.Visible = false;
            addPatient1.Visible = true;
            addRoom1.Visible = false;

            AddPatient dashForm = addPatient1 as AddPatient;

            //if (dashForm != null)
            //{
            //    dashForm.RefreshData();
            //}
        }

        private void AddRoom_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addDoctor1.Visible = false;
            addPatient1.Visible = false;
            addRoom1.Visible = true;


            AddRoom dashForm = addRoom1 as AddRoom;

            //if (dashForm != null)
            //{
            //    dashForm.RefreshData();
            //}
        }
    }
    }

