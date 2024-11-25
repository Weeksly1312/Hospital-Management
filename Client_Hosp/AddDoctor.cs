using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using Middle_Hosp;
using Client_Hosp.Utils;
using System.Linq;
using Server_Hosp;
using System.IO;

namespace Client_Hosp
{
    public partial class AddDoctor : UserControl
    {
        // Fields and Properties
        #region Fields and Properties
        private Middle_Hosp.RPC doctorRPC;
        private bool isEditing = false;
        #endregion

        // Constructor
        #region Constructor
        public AddDoctor()
        {
            InitializeComponent();
            InitializeRPCConnection();
            SetupComboBoxes();
        }
        #endregion

        // Initialization Methods
        #region Initialization Methods
        private void InitializeRPCConnection()
        {
            try
            {
                doctorRPC = ConnectionManager.InitializeRPCConnection("doctor");
            }
            catch (Exception ex)
            {
                ConnectionManager.ShowError(ex.Message);
            }
        }

        private void SetupComboBoxes()
        {
            ComSpecialization.Items.Clear();
            try
            {
                List<string> specializations = doctorRPC.GetSpecializations(ConnectionManager.ConnectionString);
                ComSpecialization.Items.AddRange(specializations.ToArray());
            }
            catch (Exception ex)
            {
                ConnectionManager.ShowError($"Error loading specializations: {ex.Message}");
            }

            try
            {
                List<string> departments = doctorRPC.GetDepartments(ConnectionManager.ConnectionString);
                ComDepartment.Items.Clear();
                ComDepartment.Items.AddRange(departments.ToArray());
            }
            catch (Exception ex)
            {
                ConnectionManager.ShowError($"Error loading departments: {ex.Message}");
            }

            ComStatus.Items.Clear();
            ComStatus.Items.AddRange(new string[] {
                "Available",
                "In Consultation",
                "On Break",
                "Off Duty",
                "In Surgery",
                "Emergency"
            });
            ComStatus.SelectedIndex = 0;
        }

        private void AddDoctor_Load_1(object sender, EventArgs e)
        {
            try
            {
                if (doctorRPC == null)
                {
                    InitializeRPCConnection();
                }

                if (doctorRPC != null)
                {
                    RefreshDoctorsList();
                }
                else
                {
                    MessageBox.Show("Could not connect to the doctor service. Please try again.",
                        "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.ShowError($"Error loading doctors: {ex.Message}");
            }
        }
        #endregion

        // CRUD Operations
        #region CRUD Operations
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtDoctorID.Text, out int doctorId))
                {
                    MessageBox.Show("Please enter a valid numeric ID", 
                        "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<RPC> doctors = doctorRPC.GetAll(ConnectionManager.ConnectionString);
                if (doctors.Any(d => d.ID == doctorId))
                {
                    MessageBox.Show("A doctor with this ID already exists. Please use a different ID.",
                        "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateFormInputs())
                    return;

                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Adding doctor...";

                doctorRPC.Initialize(
                    doctorId,
                    txtName.Text.Trim(),
                    txtLast.Text.Trim(),
                    txtPhone.Text.Trim(),
                    ComSpecialization.SelectedItem.ToString(),
                    GetSelectedDepartmentId(),
                    textAdress.Text.Trim(),
                    GetSelectedGender(),
                    ComStatus.SelectedItem.ToString()
                );

                string result = doctorRPC.Add(ConnectionManager.ConnectionString);
                
                if (!result.Contains("Error"))
                {
                    ClearFields();
                    RefreshDoctorsList();
                    lblStatus.Text = "Doctor added successfully";
                }
                else
                {
                    lblStatus.Text = "Error adding doctor";
                }

                MessageBox.Show(result, result.Contains("Error") ? "Error" : "Success",
                    MessageBoxButtons.OK, result.Contains("Error") ? MessageBoxIcon.Error : MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the doctor: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Error occurred";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnModify_Click_1(object sender, EventArgs e)
        {
            if (listViewDoctors.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a doctor to modify.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isEditing)
            {
                List<RPC> doctors = doctorRPC.GetAll(ConnectionManager.ConnectionString);
                var selectedDoctor = doctors.Find(doc =>
                    doc.ID.ToString() == listViewDoctors.SelectedItems[0].Text);

                if (selectedDoctor != null)
                {
                    txtDoctorID.Text = selectedDoctor.ID.ToString();
                    txtName.Text = selectedDoctor.FirstName;
                    txtLast.Text = selectedDoctor.LastName;
                    txtPhone.Text = selectedDoctor.PhoneNumber;
                    textAdress.Text = selectedDoctor.Address;
                    
                    foreach (var item in ComSpecialization.Items)
                    {
                        string itemName = item.ToString().Split('-')[1].Trim();
                        if (itemName == selectedDoctor.Specialization)
                        {
                            ComSpecialization.SelectedItem = item;
                            break;
                        }
                    }
                    
                    SetSelectedGender(selectedDoctor.Gender);
                    ComStatus.Text = selectedDoctor.Status;

                    foreach (var item in ComDepartment.Items)
                    {
                        if (item.ToString().StartsWith(selectedDoctor.DepartmentId.ToString()))
                        {
                            ComDepartment.SelectedItem = item;
                            break;
                        }
                    }

                    txtDoctorID.ReadOnly = true;
                    btnModify.Text = "Save Changes";
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                    isEditing = true;
                }
            }
            else
            {
                try
                {
                    if (!ValidateFormInputs())
                        return;

                    if (!int.TryParse(txtDoctorID.Text, out int doctorId))
                    {
                        MessageBox.Show("Invalid ID format", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Cursor = Cursors.WaitCursor;
                    lblStatus.Text = "Updating doctor...";

                    string modificationResult = doctorRPC.ModifyDoctor(
                        ConnectionManager.ConnectionString,
                        doctorId,
                        txtName.Text.Trim(),
                        txtLast.Text.Trim(),
                        txtPhone.Text.Trim(),
                        ComSpecialization.Text,
                        GetSelectedDepartmentId(),
                        textAdress.Text.Trim(),
                        GetSelectedGender(),
                        ComStatus.SelectedItem.ToString()
                    );

                    RefreshDoctorsList();
                    ClearFields();
                    btnModify.Text = "Modify";
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                    isEditing = false;

                    lblStatus.Text = modificationResult.Contains("Error") ? 
                        "Error updating doctor" : "Doctor updated successfully";

                    MessageBox.Show(modificationResult);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating doctor: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = "Error occurred";
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (listViewDoctors.SelectedItems.Count > 0)
            {
                if (int.TryParse(listViewDoctors.SelectedItems[0].Text, out int selectedDoctorID))
                {
                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete doctor with ID: {selectedDoctorID}?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        string deletionResult = doctorRPC.DeleteDoctor(ConnectionManager.ConnectionString, selectedDoctorID);
                        RefreshDoctorsList();
                        MessageBox.Show(deletionResult);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid doctor ID format", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a doctor to delete.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Refreshing doctors list...";
                RefreshDoctorsList();
                lblStatus.Text = "Doctors list refreshed";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing doctors list: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Error refreshing list";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void RefreshDoctorsList()
        {
            listViewDoctors.Items.Clear();
            List<RPC> doctors = doctorRPC.GetAll(ConnectionManager.ConnectionString);

            if (doctors != null)
            {
                foreach (var doc in doctors)
                {
                    var item = new ListViewItem(doc.ID.ToString());
                    item.SubItems.Add(doc.FirstName);
                    item.SubItems.Add(doc.LastName);
                    item.SubItems.Add(doc.PhoneNumber);
                    item.SubItems.Add(doc.Specialization);
                    item.SubItems.Add(doc.Address);
                    item.SubItems.Add(doc.Gender);
                    item.SubItems.Add(doc.Status);
                    item.SubItems.Add(((Doctor)doc).DepartmentName);

                    listViewDoctors.Items.Add(item);
                }
            }
            else
            {
                lblStatus.Text = "Error: No doctors found.";
            }
        }
        #endregion

        // Helper Methods
        #region Helper Methods
        private bool ValidateFormInputs()
        {
            if (string.IsNullOrWhiteSpace(txtDoctorID.Text))
            {
                MessageBox.Show("Please enter a Doctor ID",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtLast.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                ComSpecialization.SelectedIndex == -1 ||
                (!GenM.Checked && !GenF.Checked) ||
                ComDepartment.SelectedIndex == -1 ||
                ComStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int departmentId = GetSelectedDepartmentId();
            if (departmentId <= 0)
            {
                MessageBox.Show("Please select a valid department.", 
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txtDoctorID.Clear();
            txtName.Clear();
            txtLast.Clear();
            txtPhone.Clear();
            textAdress.Clear();
            ComSpecialization.SelectedIndex = -1;
            GenM.Checked = false;
            GenF.Checked = false;
            ComDepartment.SelectedIndex = -1;
            txtDoctorID.ReadOnly = false;
        }

        private string GetSelectedGender()
        {
            if (GenM.Checked) return "M";
            if (GenF.Checked) return "F";
            return string.Empty;
        }

        private void SetSelectedGender(string gender)
        {
            GenM.Checked = gender.ToUpper() == "M";
            GenF.Checked = gender.ToUpper() == "F";
        }

        private int GetSelectedDepartmentId()
        {
            if (ComDepartment.SelectedItem != null)
            {
                string departmentText = ComDepartment.SelectedItem.ToString();
                return int.Parse(departmentText.Split('-')[0].Trim());
            }
            return -1;
        }
        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV files (.csv)|.csv";
                    saveFileDialog.Title = "Export Doctors List to CSV";
                    saveFileDialog.FileName = "DoctorsList.csv";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {                        
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {                          
                            writer.WriteLine("ID,First Name,Last Name,Phone,Specialization,Address,Gender,Status,Department ID");
                         
                            foreach (ListViewItem item in listViewDoctors.Items)
                            {
                                string[] row = new string[item.SubItems.Count];
                                for (int i = 0; i < item.SubItems.Count; i++)
                                {
                                    row[i] = item.SubItems[i].Text;
                                }

                                writer.WriteLine(string.Join(",", row));
                            }
                        }

                        MessageBox.Show("Doctors list exported successfully!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during export: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}