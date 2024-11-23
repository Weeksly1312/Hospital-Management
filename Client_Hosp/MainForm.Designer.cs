namespace Client_Hosp
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label2 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AddRoom_btn = new System.Windows.Forms.Button();
            this.logout_btn = new System.Windows.Forms.Button();
            this.AddPatient_btn = new System.Windows.Forms.Button();
            this.AddDoctor_btn = new System.Windows.Forms.Button();
            this.dashboard_btn = new System.Windows.Forms.Button();
            this.greet_user = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dashboard1 = new Client_Hosp.Dashboard();
            this.addPatient1 = new Client_Hosp.AddPatient();
            this.addDoctor1 = new Client_Hosp.AddDoctor();
            this.addRoom1 = new Client_Hosp.AddRoom();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hospital Management System";
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(1079, 8);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(15, 16);
            this.exit.TabIndex = 0;
            this.exit.Text = "X";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.AddRoom_btn);
            this.panel2.Controls.Add(this.logout_btn);
            this.panel2.Controls.Add(this.AddPatient_btn);
            this.panel2.Controls.Add(this.AddDoctor_btn);
            this.panel2.Controls.Add(this.dashboard_btn);
            this.panel2.Controls.Add(this.greet_user);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 565);
            this.panel2.TabIndex = 4;
            // 
            // AddRoom_btn
            // 
            this.AddRoom_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.AddRoom_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddRoom_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.AddRoom_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.AddRoom_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.AddRoom_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRoom_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddRoom_btn.ForeColor = System.Drawing.Color.White;
            this.AddRoom_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddRoom_btn.Location = new System.Drawing.Point(14, 390);
            this.AddRoom_btn.Name = "AddRoom_btn";
            this.AddRoom_btn.Size = new System.Drawing.Size(200, 40);
            this.AddRoom_btn.TabIndex = 7;
            this.AddRoom_btn.Text = "MANAGE ROOMS";
            this.AddRoom_btn.UseVisualStyleBackColor = false;
            this.AddRoom_btn.Click += new System.EventHandler(this.AddRoom_btn_Click);
            // 
            // logout_btn
            // 
            this.logout_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.logout_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout_btn.FlatAppearance.BorderSize = 0;
            this.logout_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.logout_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.logout_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.ForeColor = System.Drawing.Color.Black;
            this.logout_btn.Location = new System.Drawing.Point(11, 517);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(43, 35);
            this.logout_btn.TabIndex = 5;
            this.logout_btn.Text = "Close X";
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // AddPatient_btn
            // 
            this.AddPatient_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.AddPatient_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddPatient_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.AddPatient_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.AddPatient_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.AddPatient_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPatient_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPatient_btn.ForeColor = System.Drawing.Color.White;
            this.AddPatient_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddPatient_btn.Location = new System.Drawing.Point(14, 334);
            this.AddPatient_btn.Name = "AddPatient_btn";
            this.AddPatient_btn.Size = new System.Drawing.Size(200, 40);
            this.AddPatient_btn.TabIndex = 4;
            this.AddPatient_btn.Text = "MANAGE PATIENTS";
            this.AddPatient_btn.UseVisualStyleBackColor = false;
            this.AddPatient_btn.Click += new System.EventHandler(this.AddPatient_btn_Click);
            // 
            // AddDoctor_btn
            // 
            this.AddDoctor_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.AddDoctor_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddDoctor_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.AddDoctor_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.AddDoctor_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.AddDoctor_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddDoctor_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDoctor_btn.ForeColor = System.Drawing.Color.White;
            this.AddDoctor_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddDoctor_btn.Location = new System.Drawing.Point(14, 277);
            this.AddDoctor_btn.Name = "AddDoctor_btn";
            this.AddDoctor_btn.Size = new System.Drawing.Size(200, 40);
            this.AddDoctor_btn.TabIndex = 3;
            this.AddDoctor_btn.Text = "MANAGE DOCTORS";
            this.AddDoctor_btn.UseVisualStyleBackColor = false;
            this.AddDoctor_btn.Click += new System.EventHandler(this.AddDoctor_btn_Click);
            // 
            // dashboard_btn
            // 
            this.dashboard_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.dashboard_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboard_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.dashboard_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.dashboard_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboard_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_btn.ForeColor = System.Drawing.Color.White;
            this.dashboard_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboard_btn.Location = new System.Drawing.Point(14, 220);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.Size = new System.Drawing.Size(200, 40);
            this.dashboard_btn.TabIndex = 2;
            this.dashboard_btn.Text = "HOME";
            this.dashboard_btn.UseVisualStyleBackColor = false;
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // 
            // greet_user
            // 
            this.greet_user.AutoSize = true;
            this.greet_user.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greet_user.ForeColor = System.Drawing.Color.Black;
            this.greet_user.Location = new System.Drawing.Point(55, 149);
            this.greet_user.Name = "greet_user";
            this.greet_user.Size = new System.Drawing.Size(125, 19);
            this.greet_user.TabIndex = 1;
            this.greet_user.Text = "Welcome Admin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(62, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dashboard1);
            this.panel3.Controls.Add(this.addRoom1);
            this.panel3.Controls.Add(this.addPatient1);
            this.panel3.Controls.Add(this.addDoctor1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1100, 565);
            this.panel3.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 35);
            this.panel1.TabIndex = 3;
            // 
            // dashboard1
            // 
            this.dashboard1.Location = new System.Drawing.Point(225, 0);
            this.dashboard1.Name = "dashboard1";
            this.dashboard1.Size = new System.Drawing.Size(875, 562);
            this.dashboard1.TabIndex = 2;
            // 
            // addPatient1
            // 
            this.addPatient1.Location = new System.Drawing.Point(225, 0);
            this.addPatient1.Name = "addPatient1";
            this.addPatient1.Size = new System.Drawing.Size(875, 562);
            this.addPatient1.TabIndex = 1;
            // 
            // addDoctor1
            // 
            this.addDoctor1.Location = new System.Drawing.Point(225, 0);
            this.addDoctor1.Name = "addDoctor1";
            this.addDoctor1.Size = new System.Drawing.Size(875, 565);
            this.addDoctor1.TabIndex = 0;
            // 
            // addRoom1
            // 
            this.addRoom1.Location = new System.Drawing.Point(225, 0);
            this.addRoom1.Name = "addRoom1";
            this.addRoom1.Size = new System.Drawing.Size(875, 562);
            this.addRoom1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Button AddPatient_btn;
        private System.Windows.Forms.Button AddDoctor_btn;
        private System.Windows.Forms.Button dashboard_btn;
        private System.Windows.Forms.Label greet_user;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AddRoom_btn;
        private Dashboard dashboard1;
        private AddPatient addPatient1;
        private AddDoctor addDoctor1;
        private AddRoom addRoom1;
    }
}