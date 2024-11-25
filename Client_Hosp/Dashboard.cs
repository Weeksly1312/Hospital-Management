using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Middle_Hosp;
using Client_Hosp.Utils;

namespace Client_Hosp
{
    public partial class Dashboard : UserControl
    {
        #region Fields and Properties
        private Middle_Hosp.RPC doctorRPC;
        private Middle_Hosp.RPC patientRPC;
        #endregion

        #region Constructor and Initialization
        public Dashboard()
        {
            InitializeComponent();
            InitializeRPCConnections();
        }

        private void InitializeRPCConnections()
        {
            try
            {
                doctorRPC = ConnectionManager.InitializeRPCConnection("doctor");
                patientRPC = ConnectionManager.InitializeRPCConnection("patient");
            }
            catch (Exception ex)
            {
                ConnectionManager.ShowError(ex.Message);
            }
        }
        #endregion

        #region Data Update Methods
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            UpdateDoctorCount();
            UpdatePatientCount();
        }

        private void UpdateDoctorCount()
        {
            try
            {
                if (doctorRPC == null)
                {
                    InitializeRPCConnections();
                }

                if (doctorRPC != null)
                {
                    List<RPC> doctors = doctorRPC.GetAll(ConnectionManager.ConnectionString);
                    int doctorCount = doctors?.Count ?? 0;
                    dashboard_TD.Text = doctorCount.ToString();
                }
                else
                {
                    dashboard_TD.Text = "Error";
                }
            }
            catch (Exception ex)
            {
                dashboard_TD.Text = "Error";
                ConnectionManager.ShowError($"Error updating doctor count: {ex.Message}");
            }
        }

        private void UpdatePatientCount()
        {
            try
            {
                if (patientRPC == null)
                {
                    InitializeRPCConnections();
                }

                if (patientRPC != null)
                {
                    List<RPC> patients = patientRPC.GetAll(ConnectionManager.ConnectionString);
                    int patientCount = patients?.Count ?? 0;
                    dashboard_TP.Text = patientCount.ToString();
                }
                else
                {
                    dashboard_TP.Text = "Error";
                }
            }
            catch (Exception ex)
            {
                dashboard_TP.Text = "Error";
                ConnectionManager.ShowError($"Error updating patient count: {ex.Message}");
            }
        }
        #endregion

        #region Event Handlers
        private void Dashboard_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dashboard_TE_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dashboard_TP_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion
    }
}
