using System;
using System.Windows.Forms;

namespace Client_Hosp
{
    partial class AddDoctor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textAdress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.listViewDoctors = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.txtDoctorID = new System.Windows.Forms.TextBox();
            this.ComSpecialization = new System.Windows.Forms.ComboBox();
            this.ComStatus = new System.Windows.Forms.ComboBox();
            this.GenF = new System.Windows.Forms.RadioButton();
            this.GenM = new System.Windows.Forms.RadioButton();
            this.ComDepartment = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 60;
            this.label9.Text = "Department Id ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "Status ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 57;
            this.label8.Text = "Gender ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Specialization ";
            // 
            // textAdress
            // 
            this.textAdress.Location = new System.Drawing.Point(154, 189);
            this.textAdress.Name = "textAdress";
            this.textAdress.Size = new System.Drawing.Size(99, 20);
            this.textAdress.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Address ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Phone Number ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Last Name ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "First Name ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "ID";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(35, 189);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPhone.TabIndex = 47;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(29, 62);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 46;
            // 
            // listViewDoctors
            // 
            this.listViewDoctors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader9,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewDoctors.HideSelection = false;
            this.listViewDoctors.Location = new System.Drawing.Point(260, 107);
            this.listViewDoctors.Name = "listViewDoctors";
            this.listViewDoctors.Size = new System.Drawing.Size(602, 247);
            this.listViewDoctors.TabIndex = 45;
            this.listViewDoctors.UseCompatibleStateImageBehavior = false;
            this.listViewDoctors.View = System.Windows.Forms.View.Details;
            this.listViewDoctors.SelectedIndexChanged += new System.EventHandler(this.listViewDoctors_SelectedIndexChanged_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "First Name";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Name";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Phone Number";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Specialization";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Address";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Gender";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Status";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Departement ID";
            this.columnHeader8.Width = 90;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 377);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 44;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(422, 377);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 43;
            this.btnModify.Text = "Modifier";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(626, 377);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 42;
            this.btnView.Text = "Afficher";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(316, 377);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 41;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(35, 150);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 40;
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(154, 150);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(100, 20);
            this.txtLast.TabIndex = 39;
            // 
            // txtDoctorID
            // 
            this.txtDoctorID.Location = new System.Drawing.Point(67, 107);
            this.txtDoctorID.Name = "txtDoctorID";
            this.txtDoctorID.Size = new System.Drawing.Size(186, 20);
            this.txtDoctorID.TabIndex = 38;
            // 
            // ComSpecialization
            // 
            this.ComSpecialization.FormattingEnabled = true;
            this.ComSpecialization.Location = new System.Drawing.Point(35, 228);
            this.ComSpecialization.Name = "ComSpecialization";
            this.ComSpecialization.Size = new System.Drawing.Size(218, 21);
            this.ComSpecialization.TabIndex = 63;
            // 
            // ComStatus
            // 
            this.ComStatus.FormattingEnabled = true;
            this.ComStatus.Location = new System.Drawing.Point(153, 269);
            this.ComStatus.Name = "ComStatus";
            this.ComStatus.Size = new System.Drawing.Size(100, 21);
            this.ComStatus.TabIndex = 64;
            // 
            // GenF
            // 
            this.GenF.AutoSize = true;
            this.GenF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(82)))), ((int)(((byte)(163)))));
            this.GenF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenF.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.GenF.Location = new System.Drawing.Point(83, 269);
            this.GenF.Name = "GenF";
            this.GenF.Size = new System.Drawing.Size(63, 19);
            this.GenF.TabIndex = 66;
            this.GenF.Text = "Female";
            this.GenF.UseVisualStyleBackColor = true;
            // 
            // GenM
            // 
            this.GenM.AutoSize = true;
            this.GenM.Checked = true;
            this.GenM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(82)))), ((int)(((byte)(163)))));
            this.GenM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenM.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.GenM.Location = new System.Drawing.Point(35, 269);
            this.GenM.Name = "GenM";
            this.GenM.Size = new System.Drawing.Size(52, 19);
            this.GenM.TabIndex = 65;
            this.GenM.TabStop = true;
            this.GenM.Text = "Male";
            this.GenM.UseVisualStyleBackColor = true;
            // 
            // ComDepartment
            // 
            this.ComDepartment.FormattingEnabled = true;
            this.ComDepartment.Location = new System.Drawing.Point(35, 313);
            this.ComDepartment.Name = "ComDepartment";
            this.ComDepartment.Size = new System.Drawing.Size(100, 21);
            this.ComDepartment.TabIndex = 67;
            // 
            // AddDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComDepartment);
            this.Controls.Add(this.GenF);
            this.Controls.Add(this.GenM);
            this.Controls.Add(this.ComStatus);
            this.Controls.Add(this.ComSpecialization);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textAdress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.listViewDoctors);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtLast);
            this.Controls.Add(this.txtDoctorID);
            this.Name = "AddDoctor";
            this.Size = new System.Drawing.Size(875, 565);
            this.Load += new System.EventHandler(this.AddDoctor_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void listViewDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtDoctorID_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddDoctor_addBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddDoctor_updateBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private Label label9;
        private Label label7;
        private Label label8;
        private Label label6;
        private TextBox textAdress;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtPhone;
        private Label lblStatus;
        private ListView listViewDoctors;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private Button btnDelete;
        private Button btnModify;
        private Button btnView;
        private Button btnAdd;
        private TextBox txtName;
        private TextBox txtLast;
        private TextBox txtDoctorID;
        private ComboBox ComSpecialization;
        private ComboBox ComStatus;
        private RadioButton GenF;
        private RadioButton GenM;
        private ComboBox ComDepartment;
        private ColumnHeader columnHeader9;
    }
}
