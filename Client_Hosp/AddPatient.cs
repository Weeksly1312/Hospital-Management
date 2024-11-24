using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using Middle_Hosp;
using Client_Hosp.Utils;
using System.Linq;

namespace Client_Hosp
{
    public partial class AddPatient : UserControl
    {
        private bool isEditing = false;
        private Middle_Hosp.RPC patientRPC;
        private Middle_Hosp.RPC doctorRPC;

        public AddPatient()
        {
            InitializeComponent();
            InitializeRPCConnection();
            SetupComboBoxes();
        }

        private void InitializeRPCConnection()
        {
            try
            {
                patientRPC = ConnectionManager.InitializeRPCConnection("patient");
                doctorRPC = ConnectionManager.InitializeRPCConnection("doctor");
            }
            catch (Exception ex)
            {
                ConnectionManager.ShowError(ex.Message);
            }
        }

        private void SetupComboBoxes()
        {
            ComBlood.Items.Clear();
            ComBlood.Items.AddRange(new string[] {
                "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"
            });

            try
            {
                ComDoctor.Items.Clear();
                List<RPC> doctors = doctorRPC.GetAll(ConnectionManager.ConnectionString);
                
                if (doctors != null)
                {
                    foreach (var doctor in doctors)
                    {
                        ComDoctor.Items.Add($"{doctor.ID} - Dr. {doctor.FirstName} {doctor.LastName}");
                    }
                }
                else
                {
                    ConnectionManager.ShowError("No doctors found in the system.");
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.ShowError($"Error loading doctors: {ex.Message}");
            }

            ComDisease.Items.Clear();
            ComDisease.Items.AddRange(new string[] {
                "Flu", "Pneumonia", "Diabetes", "Hypertension", "Asthma"
            });

            ComRoom.Items.Clear();
            string[] rooms = {
                "1 - Living Room",
                "2 - Bedroom",
                "3 - Kitchen",
                "4 - Bathroom",
                "5 - Office"
            };
            ComRoom.Items.AddRange(rooms);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtPaID.Text, out int patientId))
                {
                    ConnectionManager.ShowError("Please enter a valid numeric ID");
                    return;
                }

                List<RPC> patients = patientRPC.GetAll(ConnectionManager.ConnectionString);
                if (patients.Any(p => p.ID == patientId))
                {
                    ConnectionManager.ShowError("A patient with this ID already exists. Please use a different ID.");
                    return;
                }

                if (!ValidateFormInputs())
                    return;

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
                    GetSelectedRoomId(),
                    ComDisease.SelectedItem.ToString()
                );

                string result = patientRPC.Add(ConnectionManager.ConnectionString);

                if (!result.Contains("Error"))
                {
                    ClearFields();
                    RefreshPatientsList();
                    lblStatus.Text = "Patient added successfully";
                    ConnectionManager.ShowSuccess("Patient added successfully");
                }
                else
                {
                    lblStatus.Text = "Error adding patient";
                    ConnectionManager.ShowError(result);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.ShowError($"An error occurred while adding the patient: {ex.Message}");
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
                ConnectionManager.ShowError("Please select a patient to modify.");
                return;
            }

            if (!isEditing)
            {
                LoadPatientDataForEditing();
            }
            else
            {
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
                        string deletionResult = patientRPC.DeletePatient(ConnectionManager.ConnectionString, selectedPatientID);
                        RefreshPatientsList();
                        ConnectionManager.Show(deletionResult);
                    }
                }
            }
            else
            {
                ConnectionManager.ShowError("Please select a patient to delete.");
            }
        }

        private bool ValidateFormInputs()
        {
            if (string.IsNullOrWhiteSpace(txtPaID.Text))
            {
                ConnectionManager.ShowError("Please enter a Patient ID");
                return false;
            }

            if (!int.TryParse(txtPaID.Text, out _))
            {
                ConnectionManager.ShowError("Patient ID must be a valid number");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPaName.Text))
            {
                ConnectionManager.ShowError("Please enter the patient's first name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPaLast.Text))
            {
                ConnectionManager.ShowError("Please enter the patient's last name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPaPhone.Text))
            {
                ConnectionManager.ShowError("Please enter the patient's phone number");
                return false;
            }

            if (!GenPaM.Checked && !GenPaF.Checked)
            {
                ConnectionManager.ShowError("Please select the patient's gender");
                return false;
            }

            if (ComBlood.SelectedIndex == -1)
            {
                ConnectionManager.ShowError("Please select the patient's blood type");
                return false;
            }

            if (dateTimePicker1.Value > DateTime.Now)
            {
                ConnectionManager.ShowError("Date of birth cannot be in the future");
                return false;
            }

            if (ComDoctor.SelectedIndex == -1)
            {
                ConnectionManager.ShowError("Please assign a doctor to the patient");
                return false;
            }

            if (ComRoom.SelectedIndex == -1)
            {
                ConnectionManager.ShowError("Please assign a room to the patient");
                return false;
            }

            if (ComDisease.SelectedIndex == -1)
            {
                ConnectionManager.ShowError("Please select the patient's diagnosis");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPaPhone.Text.Trim(), @"^\+?[\d\s-]+$"))
            {
                ConnectionManager.ShowError("Please enter a valid phone number format");
                return false;
            }

            return true;
        }

        private void RefreshPatientsList()
        {
            listViewPatients.Items.Clear();
            List<RPC> patients = patientRPC.GetAll(ConnectionManager.ConnectionString);

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

        private int GetSelectedRoomId()
        {
            if (ComRoom.SelectedItem != null)
            {
                string roomText = ComRoom.SelectedItem.ToString();
                return int.Parse(roomText.Split('-')[0].Trim());
            }
            return -1;
        }

        private void LoadPatientDataForEditing()
        {
            List<RPC> patients = patientRPC.GetAll(ConnectionManager.ConnectionString);
            var selectedPatient = patients.Find(pat =>
                pat.ID.ToString() == listViewPatients.SelectedItems[0].Text);

            if (selectedPatient != null)
            {
                txtPaID.Text = selectedPatient.ID.ToString();
                txtPaName.Text = selectedPatient.FirstName;
                txtPaLast.Text = selectedPatient.LastName;
                txtPaPhone.Text = selectedPatient.PhoneNumber;
                textPaAdress.Text = selectedPatient.Address;
                
                ComDisease.Text = listViewPatients.SelectedItems[0].SubItems[10].Text;
                ComBlood.Text = listViewPatients.SelectedItems[0].SubItems[4].Text;
                ComRoom.Text = listViewPatients.SelectedItems[0].SubItems[9].Text;
                SetSelectedGender(selectedPatient.Gender);

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
                    ConnectionManager.ShowError("Invalid ID format", "Error");
                    return;
                }

                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Updating patient...";

                string modificationResult = patientRPC.Update(
                    ConnectionManager.ConnectionString,
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

                ConnectionManager.Show(modificationResult);
            }
            catch (Exception ex)
            {
                ConnectionManager.ShowError($"Error updating patient: {ex.Message}",
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
    }
}
