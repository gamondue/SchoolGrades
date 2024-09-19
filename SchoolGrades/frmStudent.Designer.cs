namespace SchoolGrades
{
    partial class frmStudent
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudent));
            btnNew = new System.Windows.Forms.Button();
            lblBirthPlace = new System.Windows.Forms.Label();
            lblOrigin = new System.Windows.Forms.Label();
            lblBirthDate = new System.Windows.Forms.Label();
            lblStudentCode = new System.Windows.Forms.Label();
            txtIdStudent = new System.Windows.Forms.TextBox();
            lblLastName = new System.Windows.Forms.Label();
            lblEmail = new System.Windows.Forms.Label();
            lblFirstName = new System.Windows.Forms.Label();
            lblCity = new System.Windows.Forms.Label();
            btnFindHomonyms = new System.Windows.Forms.Button();
            lblExistingSameName = new System.Windows.Forms.Label();
            dgwSearchedStudents = new System.Windows.Forms.DataGridView();
            btnSave = new System.Windows.Forms.Button();
            picStudent = new System.Windows.Forms.PictureBox();
            btnChoose = new System.Windows.Forms.Button();
            txtEmail = new System.Windows.Forms.TextBox();
            txtBirthPlace = new System.Windows.Forms.TextBox();
            txtBirthDate = new System.Windows.Forms.TextBox();
            txtOrigin = new System.Windows.Forms.TextBox();
            txtCity = new System.Windows.Forms.TextBox();
            txtFirstName = new System.Windows.Forms.TextBox();
            txtLastName = new System.Windows.Forms.TextBox();
            chkDisabled = new System.Windows.Forms.CheckBox();
            btnFindStudent = new System.Windows.Forms.Button();
            btnExitWithoutChoosing = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            btnDeleteStudent = new System.Windows.Forms.Button();
            chkHasSpecialNeeds = new System.Windows.Forms.CheckBox();
            txtTelephone = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            txtMobileTelephone = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtGender = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtStreetAddress = new System.Windows.Forms.TextBox();
            txtZipCode = new System.Windows.Forms.TextBox();
            txtState = new System.Windows.Forms.TextBox();
            txtCounty = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgwSearchedStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStudent).BeginInit();
            SuspendLayout();
            // 
            // btnNew
            // 
            btnNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnNew.Location = new System.Drawing.Point(644, 427);
            btnNew.Name = "btnNew";
            btnNew.Size = new System.Drawing.Size(91, 47);
            btnNew.TabIndex = 95;
            btnNew.Text = "Pulisci dati";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // lblBirthPlace
            // 
            lblBirthPlace.AutoSize = true;
            lblBirthPlace.Location = new System.Drawing.Point(5, 111);
            lblBirthPlace.Name = "lblBirthPlace";
            lblBirthPlace.Size = new System.Drawing.Size(114, 18);
            lblBirthPlace.TabIndex = 148;
            lblBirthPlace.Text = "Posto di nascita";
            // 
            // lblOrigin
            // 
            lblOrigin.AutoSize = true;
            lblOrigin.ForeColor = System.Drawing.Color.DarkBlue;
            lblOrigin.Location = new System.Drawing.Point(5, 160);
            lblOrigin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOrigin.Name = "lblOrigin";
            lblOrigin.Size = new System.Drawing.Size(135, 18);
            lblOrigin.TabIndex = 146;
            lblOrigin.Text = "Provenienza e note";
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.ForeColor = System.Drawing.Color.DarkBlue;
            lblBirthDate.Location = new System.Drawing.Point(300, 111);
            lblBirthDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new System.Drawing.Size(105, 18);
            lblBirthDate.TabIndex = 144;
            lblBirthDate.Text = "Data di nascita";
            // 
            // lblStudentCode
            // 
            lblStudentCode.AutoSize = true;
            lblStudentCode.ForeColor = System.Drawing.Color.DarkBlue;
            lblStudentCode.Location = new System.Drawing.Point(5, 7);
            lblStudentCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStudentCode.Name = "lblStudentCode";
            lblStudentCode.Size = new System.Drawing.Size(64, 18);
            lblStudentCode.TabIndex = 142;
            lblStudentCode.Text = "Id allievo";
            // 
            // txtIdStudent
            // 
            txtIdStudent.Enabled = false;
            txtIdStudent.Location = new System.Drawing.Point(5, 29);
            txtIdStudent.Name = "txtIdStudent";
            txtIdStudent.Size = new System.Drawing.Size(70, 24);
            txtIdStudent.TabIndex = 1;
            txtIdStudent.TabStop = false;
            txtIdStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.ForeColor = System.Drawing.Color.DarkBlue;
            lblLastName.Location = new System.Drawing.Point(112, 7);
            lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new System.Drawing.Size(74, 18);
            lblLastName.TabIndex = 140;
            lblLastName.Text = "Cognome";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.ForeColor = System.Drawing.Color.DarkBlue;
            lblEmail.Location = new System.Drawing.Point(408, 110);
            lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(43, 18);
            lblEmail.TabIndex = 137;
            lblEmail.Text = "email";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.ForeColor = System.Drawing.Color.DarkBlue;
            lblFirstName.Location = new System.Drawing.Point(300, 7);
            lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new System.Drawing.Size(49, 18);
            lblFirstName.TabIndex = 136;
            lblFirstName.Text = "Nome";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new System.Drawing.Point(510, 7);
            lblCity.Name = "lblCity";
            lblCity.Size = new System.Drawing.Size(78, 18);
            lblCity.TabIndex = 135;
            lblCity.Text = "Residenza";
            // 
            // btnFindHomonyms
            // 
            btnFindHomonyms.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnFindHomonyms.Location = new System.Drawing.Point(547, 480);
            btnFindHomonyms.Name = "btnFindHomonyms";
            btnFindHomonyms.Size = new System.Drawing.Size(91, 47);
            btnFindHomonyms.TabIndex = 100;
            btnFindHomonyms.Text = "Ricerca omonimi";
            btnFindHomonyms.UseVisualStyleBackColor = true;
            btnFindHomonyms.Click += btnFindHomonym_Click;
            // 
            // lblExistingSameName
            // 
            lblExistingSameName.AutoSize = true;
            lblExistingSameName.Location = new System.Drawing.Point(4, 215);
            lblExistingSameName.Name = "lblExistingSameName";
            lblExistingSameName.Size = new System.Drawing.Size(88, 18);
            lblExistingSameName.TabIndex = 133;
            lblExistingSameName.Text = "Allievi trovati";
            // 
            // dgwSearchedStudents
            // 
            dgwSearchedStudents.AllowUserToAddRows = false;
            dgwSearchedStudents.AllowUserToDeleteRows = false;
            dgwSearchedStudents.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwSearchedStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwSearchedStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwSearchedStudents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgwSearchedStudents.Location = new System.Drawing.Point(1, 236);
            dgwSearchedStudents.Name = "dgwSearchedStudents";
            dgwSearchedStudents.Size = new System.Drawing.Size(520, 339);
            dgwSearchedStudents.TabIndex = 77;
            dgwSearchedStudents.CellClick += dgwSearchedStudents_CellClick;
            dgwSearchedStudents.CellContentClick += dgwSearchedStudents_CellContentClick;
            dgwSearchedStudents.CellDoubleClick += dgwSearchedStudents_CellDoubleClick;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSave.Location = new System.Drawing.Point(644, 480);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(91, 47);
            btnSave.TabIndex = 105;
            btnSave.Text = "Salva";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // picStudent
            // 
            picStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            picStudent.Location = new System.Drawing.Point(726, 12);
            picStudent.Name = "picStudent";
            picStudent.Size = new System.Drawing.Size(221, 221);
            picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picStudent.TabIndex = 152;
            picStudent.TabStop = false;
            // 
            // btnChoose
            // 
            btnChoose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnChoose.Location = new System.Drawing.Point(842, 532);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(91, 47);
            btnChoose.TabIndex = 120;
            btnChoose.Text = "Scegli";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(408, 132);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(312, 24);
            txtEmail.TabIndex = 60;
            // 
            // txtBirthPlace
            // 
            txtBirthPlace.Location = new System.Drawing.Point(5, 132);
            txtBirthPlace.Name = "txtBirthPlace";
            txtBirthPlace.Size = new System.Drawing.Size(292, 24);
            txtBirthPlace.TabIndex = 50;
            // 
            // txtBirthDate
            // 
            txtBirthDate.Location = new System.Drawing.Point(303, 132);
            txtBirthDate.Name = "txtBirthDate";
            txtBirthDate.Size = new System.Drawing.Size(100, 24);
            txtBirthDate.TabIndex = 55;
            // 
            // txtOrigin
            // 
            txtOrigin.Location = new System.Drawing.Point(5, 181);
            txtOrigin.Name = "txtOrigin";
            txtOrigin.Size = new System.Drawing.Size(715, 24);
            txtOrigin.TabIndex = 65;
            // 
            // txtCity
            // 
            txtCity.Location = new System.Drawing.Point(513, 29);
            txtCity.Name = "txtCity";
            txtCity.Size = new System.Drawing.Size(207, 24);
            txtCity.TabIndex = 25;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new System.Drawing.Point(303, 29);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(206, 24);
            txtFirstName.TabIndex = 20;
            // 
            // txtLastName
            // 
            txtLastName.Location = new System.Drawing.Point(115, 29);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(182, 24);
            txtLastName.TabIndex = 15;
            // 
            // chkDisabled
            // 
            chkDisabled.AutoSize = true;
            chkDisabled.Location = new System.Drawing.Point(302, 211);
            chkDisabled.Name = "chkDisabled";
            chkDisabled.Size = new System.Drawing.Size(99, 22);
            chkDisabled.TabIndex = 70;
            chkDisabled.Text = "Disabilitato";
            chkDisabled.UseVisualStyleBackColor = true;
            // 
            // btnFindStudent
            // 
            btnFindStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnFindStudent.Location = new System.Drawing.Point(547, 427);
            btnFindStudent.Name = "btnFindStudent";
            btnFindStudent.Size = new System.Drawing.Size(91, 47);
            btnFindStudent.TabIndex = 90;
            btnFindStudent.Text = "Ricerca";
            btnFindStudent.UseVisualStyleBackColor = true;
            btnFindStudent.Click += btnFindStudent_Click;
            // 
            // btnExitWithoutChoosing
            // 
            btnExitWithoutChoosing.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnExitWithoutChoosing.Location = new System.Drawing.Point(745, 532);
            btnExitWithoutChoosing.Name = "btnExitWithoutChoosing";
            btnExitWithoutChoosing.Size = new System.Drawing.Size(91, 47);
            btnExitWithoutChoosing.TabIndex = 115;
            btnExitWithoutChoosing.Text = "Esci senza scegliere";
            toolTip1.SetToolTip(btnExitWithoutChoosing, "Esci dalla finestra senza scegliere questo studente");
            btnExitWithoutChoosing.UseVisualStyleBackColor = true;
            btnExitWithoutChoosing.Click += btnExitWithoutChoosing_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnDeleteStudent.Location = new System.Drawing.Point(595, 533);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new System.Drawing.Size(91, 47);
            btnDeleteStudent.TabIndex = 110;
            btnDeleteStudent.Text = "Cancella";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // chkHasSpecialNeeds
            // 
            chkHasSpecialNeeds.AutoSize = true;
            chkHasSpecialNeeds.Location = new System.Drawing.Point(407, 211);
            chkHasSpecialNeeds.Name = "chkHasSpecialNeeds";
            chkHasSpecialNeeds.Size = new System.Drawing.Size(91, 22);
            chkHasSpecialNeeds.TabIndex = 75;
            chkHasSpecialNeeds.Text = "BES/DSA";
            chkHasSpecialNeeds.UseVisualStyleBackColor = true;
            // 
            // txtTelephone
            // 
            txtTelephone.Location = new System.Drawing.Point(531, 261);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new System.Drawing.Size(206, 24);
            txtTelephone.TabIndex = 80;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.DarkBlue;
            label1.Location = new System.Drawing.Point(528, 239);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(66, 18);
            label1.TabIndex = 161;
            label1.Text = "Telefono";
            // 
            // txtMobileTelephone
            // 
            txtMobileTelephone.Location = new System.Drawing.Point(743, 261);
            txtMobileTelephone.Name = "txtMobileTelephone";
            txtMobileTelephone.Size = new System.Drawing.Size(206, 24);
            txtMobileTelephone.TabIndex = 85;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.DarkBlue;
            label2.Location = new System.Drawing.Point(740, 239);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 18);
            label2.TabIndex = 163;
            label2.Text = "Cellulare";
            // 
            // txtGender
            // 
            txtGender.Location = new System.Drawing.Point(81, 29);
            txtGender.Name = "txtGender";
            txtGender.Size = new System.Drawing.Size(28, 24);
            txtGender.TabIndex = 10;
            txtGender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.DarkBlue;
            label3.Location = new System.Drawing.Point(75, 8);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(40, 18);
            label3.TabIndex = 165;
            label3.Text = "Gen.";
            // 
            // txtStreetAddress
            // 
            txtStreetAddress.Location = new System.Drawing.Point(4, 77);
            txtStreetAddress.Name = "txtStreetAddress";
            txtStreetAddress.Size = new System.Drawing.Size(505, 24);
            txtStreetAddress.TabIndex = 30;
            // 
            // txtZipCode
            // 
            txtZipCode.Location = new System.Drawing.Point(513, 77);
            txtZipCode.Name = "txtZipCode";
            txtZipCode.Size = new System.Drawing.Size(60, 24);
            txtZipCode.TabIndex = 35;
            // 
            // txtState
            // 
            txtState.Location = new System.Drawing.Point(620, 77);
            txtState.Name = "txtState";
            txtState.Size = new System.Drawing.Size(100, 24);
            txtState.TabIndex = 45;
            // 
            // txtCounty
            // 
            txtCounty.Location = new System.Drawing.Point(579, 77);
            txtCounty.Name = "txtCounty";
            txtCounty.Size = new System.Drawing.Size(35, 24);
            txtCounty.TabIndex = 40;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.DarkBlue;
            label4.Location = new System.Drawing.Point(4, 56);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(63, 18);
            label4.TabIndex = 170;
            label4.Text = "Indirizzo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.Color.DarkBlue;
            label5.Location = new System.Drawing.Point(513, 56);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(38, 18);
            label5.TabIndex = 171;
            label5.Text = "CAP";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.Color.DarkBlue;
            label6.Location = new System.Drawing.Point(575, 56);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(43, 18);
            label6.TabIndex = 172;
            label6.Text = "Prov.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.Color.DarkBlue;
            label7.Location = new System.Drawing.Point(620, 56);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(63, 18);
            label7.TabIndex = 173;
            label7.Text = "Regione";
            // 
            // frmStudent
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(961, 585);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtCounty);
            Controls.Add(txtState);
            Controls.Add(txtZipCode);
            Controls.Add(txtStreetAddress);
            Controls.Add(label3);
            Controls.Add(txtGender);
            Controls.Add(txtMobileTelephone);
            Controls.Add(label2);
            Controls.Add(txtTelephone);
            Controls.Add(label1);
            Controls.Add(chkHasSpecialNeeds);
            Controls.Add(btnDeleteStudent);
            Controls.Add(btnExitWithoutChoosing);
            Controls.Add(btnFindStudent);
            Controls.Add(chkDisabled);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(txtCity);
            Controls.Add(txtOrigin);
            Controls.Add(txtBirthDate);
            Controls.Add(txtBirthPlace);
            Controls.Add(txtEmail);
            Controls.Add(btnChoose);
            Controls.Add(btnSave);
            Controls.Add(btnNew);
            Controls.Add(btnFindHomonyms);
            Controls.Add(picStudent);
            Controls.Add(lblBirthPlace);
            Controls.Add(lblOrigin);
            Controls.Add(lblBirthDate);
            Controls.Add(lblStudentCode);
            Controls.Add(txtIdStudent);
            Controls.Add(lblLastName);
            Controls.Add(lblEmail);
            Controls.Add(lblFirstName);
            Controls.Add(lblCity);
            Controls.Add(lblExistingSameName);
            Controls.Add(dgwSearchedStudents);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            ForeColor = System.Drawing.Color.DarkBlue;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            Name = "frmStudent";
            Text = "Gestione studenti";
            toolTip1.SetToolTip(this, "Esci scegliendo l'attuale studente");
            Load += frmStudent_Load;
            ((System.ComponentModel.ISupportInitialize)dgwSearchedStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStudent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblBirthPlace;
        private System.Windows.Forms.Label lblOrigin;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblStudentCode;
        private System.Windows.Forms.TextBox txtIdStudent;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Button btnFindHomonyms;
        private System.Windows.Forms.Label lblExistingSameName;
        private System.Windows.Forms.DataGridView dgwSearchedStudents;
        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtBirthPlace;
        private System.Windows.Forms.TextBox txtBirthDate;
        private System.Windows.Forms.TextBox txtOrigin;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.CheckBox chkDisabled;
        private System.Windows.Forms.Button btnFindStudent;
        private System.Windows.Forms.Button btnExitWithoutChoosing;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.CheckBox chkHasSpecialNeeds;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMobileTelephone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtStreetAddress;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label7;
    }
}