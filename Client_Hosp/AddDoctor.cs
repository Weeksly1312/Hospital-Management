using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using Middle_Hosp;

namespace Client_Hosp
{
    public partial class AddDoctor : UserControl
    {
        private Middle_Hosp.RPC doctorRPC;
        private readonly string connectionString = @"Data Source=DESKTOP-C03F80S\SQLEXPRESS01;Initial Catalog=DoctorManagement;Integrated Security=True;Connect Timeout=30;";
            //@"Data Source=DESKTOP-MVIQ4R9\SQLEXPRESS01;Initial Catalog=New Database;Integrated Security=True;Connect Timeout=30;";

        public AddDoctor()
        {
            InitializeComponent();
            InitializeRPCConnection();
            SetupComboBoxes();
        }

        private void SetupComboBoxes()
        {
            // Setup Specialization ComboBox
            ComSpecialization.Items.AddRange(new string[] {
                "General Medicine",
                "Cardiology",
                "Neurology",
                "Pediatrics",
                "Orthopedics",
                "Dermatology",
                "Ophthalmology",
                "Psychiatry"
            });

            // Updated Department ComboBox with more realistic departments
            ComDepartment.Items.AddRange(new string[] {
                "1 - Emergency Department",
                "2 - Internal Medicine",
                "3 - Surgery Department",
                "4 - Pediatrics Department",
                "5 - Obstetrics & Gynecology",
                "6 - Cardiology Department",
                "7 - Neurology Department",
                "8 - Intensive Care Unit"
            });

            // Status ComboBox remains the same
            ComStatus.Items.Clear();
            ComStatus.Items.AddRange(new string[] {
                "Available",
                "In Consultation",
                "On Break",
                "Off Duty",
                "In Surgery",
                "Unavailable",
                "Emergency"
            });
            ComStatus.SelectedIndex = 0; // Set default status to Available
        }


        private void InitializeRPCConnection()
        {
            try
            {
                TcpChannel existingChannel = null;
                foreach (IChannel chan in ChannelServices.RegisteredChannels)
                {
                    if (chan is TcpChannel)
                    {
                        existingChannel = (TcpChannel)chan;
                        break;
                    }
                }

                if (existingChannel == null)
                {
                    TcpChannel channelDoctor = new TcpChannel();
                    ChannelServices.RegisterChannel(channelDoctor, false);
                }

                doctorRPC = (Middle_Hosp.RPC)Activator.GetObject(
                    typeof(Middle_Hosp.RPC),
                    "tcp://localhost:2222/doctor");

                if (doctorRPC == null)
                {
                    throw new Exception("Failed to connect to doctor service");
                }

                try
                {
                    List<RPC> doctors = doctorRPC.GetAll(connectionString);
                    if (doctors == null)
                    {
                        throw new Exception("Failed to retrieve doctors list");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error testing doctor service connection: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize RPC connection: {ex.Message}",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show($"Error loading doctors: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDoctorsList()
        {
            listViewDoctors.Items.Clear();
            List<RPC> doctors = doctorRPC.GetAll(connectionString);

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
                    item.SubItems.Add(doc.DepartmentId.ToString());

                    listViewDoctors.Items.Add(item);
                }
            }
            else
            {
                lblStatus.Text = "Error: No doctors found.";
            }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
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
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\+?[\d\s-]+$"))
                {
                    MessageBox.Show("Please enter a valid phone number",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string gender = GetSelectedGender();
                int departmentId = GetSelectedDepartmentId();

                if (departmentId <= 0)
                {
                    MessageBox.Show("Please select a valid department.", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Adding doctor...";

                doctorRPC.Initialize(
                    0,
                    txtName.Text.Trim(),
                    txtLast.Text.Trim(),
                    txtPhone.Text.Trim(),
                    ComSpecialization.SelectedItem.ToString(),
                    departmentId,
                    textAdress.Text.Trim(),
                    gender,
                    ComStatus.SelectedItem.ToString()
                );

                string result = doctorRPC.Add(connectionString);
                
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

        private bool isEditing = false;

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (listViewDoctors.SelectedItems.Count > 0)
            {
                if (!isEditing)
                {
                    List<RPC> doctors = doctorRPC.GetAll(connectionString);
                    var selectedDoctor = doctors.Find(doc =>
                        doc.ID.ToString() == listViewDoctors.SelectedItems[0].Text);

                    if (selectedDoctor != null)
                    {
                        txtDoctorID.Text = selectedDoctor.ID.ToString();
                        txtName.Text = selectedDoctor.FirstName;
                        txtLast.Text = selectedDoctor.LastName;
                        txtPhone.Text = selectedDoctor.PhoneNumber;
                        textAdress.Text = selectedDoctor.Address;
                        ComSpecialization.Text = selectedDoctor.Specialization;
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
                        if (!int.TryParse(txtDoctorID.Text, out int doctorId))
                        {
                            MessageBox.Show("Invalid ID format", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
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
                            return;
                        }

                        int departmentId = GetSelectedDepartmentId();
                        if (departmentId <= 0)
                        {
                            MessageBox.Show("Invalid department selection", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Cursor = Cursors.WaitCursor;
                        lblStatus.Text = "Updating doctor...";

                        string modificationResult = doctorRPC.ModifyDoctor(
                            connectionString,
                            doctorId,
                            txtName.Text.Trim(),
                            txtLast.Text.Trim(),
                            txtPhone.Text.Trim(),
                            ComSpecialization.Text,
                            departmentId,
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
            else
            {
                MessageBox.Show("Please select a doctor to modify.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(listViewDoctors.SelectedItems.Count > 0)
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
                        string deletionResult = doctorRPC.DeleteDoctor(connectionString, selectedDoctorID);
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

        private void listViewDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        // Existing delete and other methods remain the same...
    }
}