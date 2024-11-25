namespace Client_Hosp
{
    partial class AddPatient
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewPatients = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.ComDisease = new System.Windows.Forms.ComboBox();
            this.GenPaF = new System.Windows.Forms.RadioButton();
            this.GenPaM = new System.Windows.Forms.RadioButton();
            this.ComBlood = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPaPhone = new System.Windows.Forms.TextBox();
            this.txtPaName = new System.Windows.Forms.TextBox();
            this.txtPaLast = new System.Windows.Forms.TextBox();
            this.txtPaID = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ComRoom = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ComDoctor = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textPaAdress = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listViewPatients);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(18, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 279);
            this.panel1.TabIndex = 5;
            // 
            // listViewPatients
            // 
            this.listViewPatients.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.listViewPatients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.listViewPatients.HideSelection = false;
            this.listViewPatients.Location = new System.Drawing.Point(22, 59);
            this.listViewPatients.Name = "listViewPatients";
            this.listViewPatients.Size = new System.Drawing.Size(798, 193);
            this.listViewPatients.TabIndex = 46;
            this.listViewPatients.UseCompatibleStateImageBehavior = false;
            this.listViewPatients.View = System.Windows.Forms.View.Details;
            //this.listViewPatients.SelectedIndexChanged += new System.EventHandler(this.listViewPatients_SelectedIndexChanged);
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
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Gender";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Birth date";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Address";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Doctor";
            this.columnHeader8.Width = 65;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Diagnosis";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Blood Type";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Room";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Patients Management";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(0, 299);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(839, 226);
            this.panel2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Green;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(595, 159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 37);
            this.button2.TabIndex = 90;
            this.button2.Text = "Export .csv";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(464, 159);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 37);
            this.btnDelete.TabIndex = 89;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.FlatAppearance.BorderSize = 0;
            this.btnModify.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnModify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnModify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.ForeColor = System.Drawing.Color.White;
            this.btnModify.Location = new System.Drawing.Point(293, 159);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(100, 37);
            this.btnModify.TabIndex = 88;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // ComDisease
            // 
            this.ComDisease.FormattingEnabled = true;
            this.ComDisease.Location = new System.Drawing.Point(293, 111);
            this.ComDisease.Name = "ComDisease";
            this.ComDisease.Size = new System.Drawing.Size(100, 21);
            this.ComDisease.TabIndex = 87;
            // 
            // GenPaF
            // 
            this.GenPaF.AutoSize = true;
            this.GenPaF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(82)))), ((int)(((byte)(163)))));
            this.GenPaF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenPaF.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenPaF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.GenPaF.Location = new System.Drawing.Point(522, 27);
            this.GenPaF.Name = "GenPaF";
            this.GenPaF.Size = new System.Drawing.Size(63, 19);
            this.GenPaF.TabIndex = 86;
            this.GenPaF.Text = "Female";
            this.GenPaF.UseVisualStyleBackColor = true;
            // 
            // GenPaM
            // 
            this.GenPaM.AutoSize = true;
            this.GenPaM.Checked = true;
            this.GenPaM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(82)))), ((int)(((byte)(163)))));
            this.GenPaM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenPaM.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenPaM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.GenPaM.Location = new System.Drawing.Point(464, 27);
            this.GenPaM.Name = "GenPaM";
            this.GenPaM.Size = new System.Drawing.Size(52, 19);
            this.GenPaM.TabIndex = 85;
            this.GenPaM.TabStop = true;
            this.GenPaM.Text = "Male";
            this.GenPaM.UseVisualStyleBackColor = true;
            // 
            // ComBlood
            // 
            this.ComBlood.FormattingEnabled = true;
            this.ComBlood.Location = new System.Drawing.Point(598, 26);
            this.ComBlood.Name = "ComBlood";
            this.ComBlood.Size = new System.Drawing.Size(100, 21);
            this.ComBlood.TabIndex = 84;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(290, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 82;
            this.label9.Text = "Diagnosis";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(595, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 81;
            this.label7.Text = "Blood";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(462, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "Gender ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Phone Number ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Last Name ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "First Name ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(171, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 73;
            this.label10.Text = "ID";
            // 
            // txtPaPhone
            // 
            this.txtPaPhone.Location = new System.Drawing.Point(174, 111);
            this.txtPaPhone.Name = "txtPaPhone";
            this.txtPaPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPaPhone.TabIndex = 72;
            // 
            // txtPaName
            // 
            this.txtPaName.Location = new System.Drawing.Point(293, 26);
            this.txtPaName.Name = "txtPaName";
            this.txtPaName.Size = new System.Drawing.Size(100, 20);
            this.txtPaName.TabIndex = 70;
            // 
            // txtPaLast
            // 
            this.txtPaLast.Location = new System.Drawing.Point(174, 66);
            this.txtPaLast.Name = "txtPaLast";
            this.txtPaLast.Size = new System.Drawing.Size(100, 20);
            this.txtPaLast.TabIndex = 69;
            // 
            // txtPaID
            // 
            this.txtPaID.Location = new System.Drawing.Point(174, 26);
            this.txtPaID.Name = "txtPaID";
            this.txtPaID.Size = new System.Drawing.Size(46, 20);
            this.txtPaID.TabIndex = 68;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.ComRoom);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.ComDoctor);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.textPaAdress);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnModify);
            this.panel3.Controls.Add(this.ComDisease);
            this.panel3.Controls.Add(this.GenPaF);
            this.panel3.Controls.Add(this.GenPaM);
            this.panel3.Controls.Add(this.ComBlood);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtPaPhone);
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Controls.Add(this.txtPaName);
            this.panel3.Controls.Add(this.txtPaLast);
            this.panel3.Controls.Add(this.txtPaID);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(18, 324);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(839, 215);
            this.panel3.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(293, 69);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // ComRoom
            // 
            this.ComRoom.FormattingEnabled = true;
            this.ComRoom.Items.AddRange(new object[] {
            "1"});
            this.ComRoom.Location = new System.Drawing.Point(598, 70);
            this.ComRoom.Name = "ComRoom";
            this.ComRoom.Size = new System.Drawing.Size(100, 21);
            this.ComRoom.TabIndex = 102;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(594, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 101;
            this.label11.Text = "Room";
            // 
            // ComDoctor
            // 
            this.ComDoctor.FormattingEnabled = true;
            this.ComDoctor.Location = new System.Drawing.Point(464, 69);
            this.ComDoctor.Name = "ComDoctor";
            this.ComDoctor.Size = new System.Drawing.Size(114, 21);
            this.ComDoctor.TabIndex = 100;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(460, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 13);
            this.label24.TabIndex = 99;
            this.label24.Text = "Doctor";
            // 
            // textPaAdress
            // 
            this.textPaAdress.Location = new System.Drawing.Point(464, 112);
            this.textPaAdress.Name = "textPaAdress";
            this.textPaAdress.Size = new System.Drawing.Size(234, 20);
            this.textPaAdress.TabIndex = 98;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(461, 95);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(91, 13);
            this.label25.TabIndex = 97;
            this.label25.Text = "Address (optional)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(290, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 94;
            this.label12.Text = "Age";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(306, -30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 71;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(174, 159);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 37);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Location = new System.Drawing.Point(0, 299);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(839, 226);
            this.panel4.TabIndex = 1;
            // 
            // AddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "AddPatient";
            this.Size = new System.Drawing.Size(875, 565);
            this.Load += new System.EventHandler(this.AddPatient_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewPatients;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.ComboBox ComDisease;
        private System.Windows.Forms.RadioButton GenPaF;
        private System.Windows.Forms.RadioButton GenPaM;
        private System.Windows.Forms.ComboBox ComBlood;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPaPhone;
        private System.Windows.Forms.TextBox txtPaName;
        private System.Windows.Forms.TextBox txtPaLast;
        private System.Windows.Forms.TextBox txtPaID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ComboBox ComRoom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ComDoctor;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textPaAdress;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
