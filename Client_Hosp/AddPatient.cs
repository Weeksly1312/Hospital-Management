using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using Middle_Hosp;

namespace Client_Hosp
{
    public partial class AddPatient : UserControl
    {
        #region Fields
        private Middle_Hosp.RPC patientRPC;
        private Middle_Hosp.RPC doctorRPC;
        private readonly string connectionString = @"Data Source=DESKTOP-C03F80S\SQLEXPRESS01;Initial Catalog=DoctorManagements;Integrated Security=True;Connect Timeout=30;";
        private bool isEditing = false;
        #endregion

        #region Constructor
        public AddPatient()
        {
            InitializeComponent();
            InitializeRPCConnection();
            SetupComboBoxes();
        }
        #endregion

        #region Initialization Methods
        private void InitializeRPCConnection()
        {
            try
            {
                // First ensure server is reachable
                using (var client = new System.Net.Sockets.TcpClient())
                {
                    try
                    {
                        client.Connect("localhost", 2222);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Cannot connect to server. Please ensure the server is running.");
                    }
                }

                // Unregister any existing channels
                foreach (IChannel chan in ChannelServices.RegisteredChannels)
                {
                    ChannelServices.UnregisterChannel(chan);
                }

                // Register new channel
                TcpChannel channelPatient = new TcpChannel();
                ChannelServices.RegisterChannel(channelPatient, false);

                patientRPC = (Middle_Hosp.RPC)Activator.GetObject(
                    typeof(Middle_Hosp.RPC),
                    "tcp://localhost:2222/patient");

                doctorRPC = (Middle_Hosp.RPC)Activator.GetObject(
                    typeof(Middle_Hosp.RPC),
                    "tcp://localhost:2222/doctor");

                if (patientRPC == null || doctorRPC == null)
                {
                    throw new Exception("Failed to connect to one or more services");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize RPC connection: {ex.Message}",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupComboBoxes()
        {
            // Setup blood type combo box
            ComBlood.Items.Clear();
            ComBlood.Items.AddRange(new string[] {
                "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"
            });

            // Setup doctors combo box
            try
            {
                ComDoctor.Items.Clear();
                List<RPC> doctors = doctorRPC.GetAll(connectionString);
                
                if (doctors != null)
                {
                    foreach (var doctor in doctors)
                    {
                        ComDoctor.Items.Add($"{doctor.ID} - Dr. {doctor.FirstName} {doctor.LastName}");
                    }
                }
                else
                {
                    MessageBox.Show("No doctors found in the system.", 
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctors: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Setup disease/diagnosis combo box
            ComDisease.Items.Clear();
            ComDisease.Items.AddRange(new string[] {
                "Flu",
                "Pneumonia",
                "Diabetes",
                "Hypertension",
                "Asthma",
                // Add more diseases as needed
            });
        }
        #endregion

        #region Event Handlers
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateFormInputs())
                    return;

                if (!int.TryParse(txtPaID.Text, out int patientId))
                {
                    MessageBox.Show("Please enter a valid numeric ID",
                        "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Adding patient...";

                patientRPC.Initialize(
                    patientId,
                    txtPaName.Text.Trim(),
                    txtPaLast.Text.Trim(),
                    GetSelectedGender(),
                    ComBlood.SelectedItem.ToString(),
                    dateTimePicker1.Value,
                    txtPaPhone.Text.Trim(),
                    textPaAdress.Text.Trim(),
                    GetSelectedDoctorId(),
                    0, // Room ID is not used in your UI
                    ComDisease.SelectedItem.ToString()
                );

                string result = patientRPC.Add(connectionString);

                if (!result.Contains("Error"))
                {
                    ClearFields();
                    RefreshPatientsList();
                    lblStatus.Text = "Patient added successfully";
                }
                else
                {
                    lblStatus.Text = "Error adding patient";
                }

                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the patient: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Error occurred";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (listViewPatients.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a patient to modify.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isEditing)
            {
                // Load patient data into form
                LoadPatientDataForEditing();
            }
            else
            {
                // Save modifications
                SavePatientModifications();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewPatients.SelectedItems.Count > 0)
            {
                if (int.TryParse(listViewPatients.SelectedItems[0].Text, out int selectedPatientID))
                {
                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete patient with ID: {selectedPatientID}?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        string deletionResult = patientRPC.DeletePatient(connectionString, selectedPatientID);
                        RefreshPatientsList();
                        MessageBox.Show(deletionResult);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a patient to delete.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Helper Methods
        private bool ValidateFormInputs()
        {
            if (string.IsNullOrWhiteSpace(txtPaID.Text) ||
                string.IsNullOrWhiteSpace(txtPaName.Text) ||
                string.IsNullOrWhiteSpace(txtPaLast.Text) ||
                string.IsNullOrWhiteSpace(txtPaPhone.Text) ||
                string.IsNullOrWhiteSpace(dateTimePicker1.Text) ||
                ComBlood.SelectedIndex == -1 ||
                (!GenPaM.Checked && !GenPaF.Checked) ||
                ComDoctor.SelectedIndex == -1 ||
                ComDisease.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void RefreshPatientsList()
        {
            listViewPatients.Items.Clear();
            List<RPC> patients = patientRPC.GetAll(connectionString);

            if (patients != null)
            {
                foreach (var patient in patients)
                {
                    var item = new ListViewItem(patient.ID.ToString());
                    item.SubItems.Add(patient.FirstName);
                    item.SubItems.Add(patient.LastName);
                    item.SubItems.Add(patient.Gender);
                    item.SubItems.Add(ComBlood.Text);
                    item.SubItems.Add(dateTimePicker1.Value.ToShortDateString());
                    item.SubItems.Add(patient.PhoneNumber);
                    item.SubItems.Add(patient.Address);
                    item.SubItems.Add(ComDoctor.Text);
                    item.SubItems.Add(ComRoom.Text);
                    item.SubItems.Add(ComDisease.Text);

                    listViewPatients.Items.Add(item);
                }
            }
        }

        private void ClearFields()
        {
            txtPaID.Clear();
            txtPaName.Clear();
            txtPaLast.Clear();
            txtPaPhone.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textPaAdress.Clear();
            ComBlood.SelectedIndex = -1;
            ComDoctor.SelectedIndex = -1;
            ComDisease.SelectedIndex = -1;
            ComRoom.SelectedIndex = -1;
            GenPaM.Checked = false;
            GenPaF.Checked = false;
            txtPaID.ReadOnly = false;
        }

        private string GetSelectedGender()
        {
            return GenPaM.Checked ? "M" : GenPaF.Checked ? "F" : string.Empty;
        }

        private int GetSelectedDoctorId()
        {
            if (ComDoctor.SelectedItem != null)
            {
                string doctorText = ComDoctor.SelectedItem.ToString();
                return int.Parse(doctorText.Split('-')[0].Trim());
            }
            return -1;
        }

        private void LoadPatientDataForEditing()
        {
            List<RPC> patients = patientRPC.GetAll(connectionString);
            var selectedPatient = patients.Find(pat =>
                pat.ID.ToString() == listViewPatients.SelectedItems[0].Text);

            if (selectedPatient != null)
            {
                txtPaID.Text = selectedPatient.ID.ToString();
                txtPaName.Text = selectedPatient.FirstName;
                txtPaLast.Text = selectedPatient.LastName;
                txtPaPhone.Text = selectedPatient.PhoneNumber;
                textPaAdress.Text = selectedPatient.Address;
                
                // Set the values from the ListView instead of RPC object
                ComDisease.Text = listViewPatients.SelectedItems[0].SubItems[10].Text;
                ComBlood.Text = listViewPatients.SelectedItems[0].SubItems[4].Text;
                ComRoom.Text = listViewPatients.SelectedItems[0].SubItems[9].Text;
                SetSelectedGender(selectedPatient.Gender);

                // Set doctor selection using the ID from ListView
                string doctorId = listViewPatients.SelectedItems[0].SubItems[8].Text.Split('-')[0].Trim();
                SetSelectedDoctor(doctorId);

                txtPaID.ReadOnly = true;
                btnModify.Text = "Save Changes";
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                isEditing = true;
            }
        }

        private void SavePatientModifications()
        {
            try
            {
                if (!ValidateFormInputs())
                    return;

                if (!int.TryParse(txtPaID.Text, out int patientId))
                {
                    MessageBox.Show("Invalid ID format", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Updating patient...";

                string modificationResult = patientRPC.Update(
                    connectionString,
                    patientId,
                    txtPaName.Text.Trim(),
                    txtPaLast.Text.Trim(),
                    GetSelectedGender(),
                    ComBlood.SelectedItem.ToString(),
                    dateTimePicker1.Value,
                    txtPaPhone.Text.Trim(),
                    textPaAdress.Text.Trim(),
                    GetSelectedDoctorId(),
                    int.Parse(ComRoom.Text),
                    ComDisease.SelectedItem.ToString()
                );

                RefreshPatientsList();
                ClearFields();
                btnModify.Text = "Modify";
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                isEditing = false;

                MessageBox.Show(modificationResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating patient: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SetSelectedGender(string gender)
        {
            GenPaM.Checked = gender.ToUpper() == "M";
            GenPaF.Checked = gender.ToUpper() == "F";
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        private void SetSelectedDoctor(string doctorId)
        {
            for (int i = 0; i < ComDoctor.Items.Count; i++)
            {
                string item = ComDoctor.Items[i].ToString();
                if (item.StartsWith(doctorId + " -"))
                {
                    ComDoctor.SelectedIndex = i;
                    break;
                }
            }
        }
        #endregion

        private void GenPaF_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listViewDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
