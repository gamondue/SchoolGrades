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
            lblResidence = new System.Windows.Forms.Label();
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
            txtResidence = new System.Windows.Forms.TextBox();
            txtFirstName = new System.Windows.Forms.TextBox();
            txtLastName = new System.Windows.Forms.TextBox();
            chkDisabled = new System.Windows.Forms.CheckBox();
            btnFindStudent = new System.Windows.Forms.Button();
            btnExitWithoutChoosing = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            btnDeleteStudent = new System.Windows.Forms.Button();
            chkHasSpecialNeeds = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgwSearchedStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStudent).BeginInit();
            SuspendLayout();
            // 
            // btnNew
            // 
            btnNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNew.Location = new System.Drawing.Point(424, 242);
            btnNew.Name = "btnNew";
            btnNew.Size = new System.Drawing.Size(91, 47);
            btnNew.TabIndex = 151;
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
            lblOrigin.Location = new System.Drawing.Point(419, 141);
            lblOrigin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOrigin.Name = "lblOrigin";
            lblOrigin.Size = new System.Drawing.Size(90, 18);
            lblOrigin.TabIndex = 146;
            lblOrigin.Text = "Provenienza";
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
            lblStudentCode.Size = new System.Drawing.Size(85, 18);
            lblStudentCode.TabIndex = 142;
            lblStudentCode.Text = "Cod. allievo";
            // 
            // txtIdStudent
            // 
            txtIdStudent.Enabled = false;
            txtIdStudent.Location = new System.Drawing.Point(5, 29);
            txtIdStudent.Name = "txtIdStudent";
            txtIdStudent.Size = new System.Drawing.Size(100, 24);
            txtIdStudent.TabIndex = 141;
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
            lblEmail.Location = new System.Drawing.Point(5, 63);
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
            // lblResidence
            // 
            lblResidence.AutoSize = true;
            lblResidence.Location = new System.Drawing.Point(300, 63);
            lblResidence.Name = "lblResidence";
            lblResidence.Size = new System.Drawing.Size(78, 18);
            lblResidence.TabIndex = 135;
            lblResidence.Text = "Residenza";
            // 
            // btnFindHomonyms
            // 
            btnFindHomonyms.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFindHomonyms.Location = new System.Drawing.Point(327, 295);
            btnFindHomonyms.Name = "btnFindHomonyms";
            btnFindHomonyms.Size = new System.Drawing.Size(91, 47);
            btnFindHomonyms.TabIndex = 134;
            btnFindHomonyms.Text = "Ricerca omonimi";
            btnFindHomonyms.UseVisualStyleBackColor = true;
            btnFindHomonyms.Click += btnFindHomonym_Click;
            // 
            // lblExistingSameName
            // 
            lblExistingSameName.AutoSize = true;
            lblExistingSameName.Location = new System.Drawing.Point(5, 188);
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
            dgwSearchedStudents.Location = new System.Drawing.Point(5, 213);
            dgwSearchedStudents.Name = "dgwSearchedStudents";
            dgwSearchedStudents.Size = new System.Drawing.Size(292, 187);
            dgwSearchedStudents.TabIndex = 132;
            dgwSearchedStudents.CellClick += dgwSearchedStudents_CellClick;
            dgwSearchedStudents.CellContentClick += dgwSearchedStudents_CellContentClick;
            dgwSearchedStudents.CellDoubleClick += dgwSearchedStudents_CellDoubleClick;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSave.Location = new System.Drawing.Point(424, 295);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(91, 47);
            btnSave.TabIndex = 153;
            btnSave.Text = "Salva";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // picStudent
            // 
            picStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            picStudent.Location = new System.Drawing.Point(519, 12);
            picStudent.Name = "picStudent";
            picStudent.Size = new System.Drawing.Size(221, 221);
            picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picStudent.TabIndex = 152;
            picStudent.TabStop = false;
            // 
            // btnChoose
            // 
            btnChoose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnChoose.Location = new System.Drawing.Point(649, 348);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(91, 47);
            btnChoose.TabIndex = 154;
            btnChoose.Text = "Scegli";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(5, 85);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(292, 24);
            txtEmail.TabIndex = 3;
            // 
            // txtBirthPlace
            // 
            txtBirthPlace.Location = new System.Drawing.Point(5, 132);
            txtBirthPlace.Name = "txtBirthPlace";
            txtBirthPlace.Size = new System.Drawing.Size(292, 24);
            txtBirthPlace.TabIndex = 5;
            // 
            // txtBirthDate
            // 
            txtBirthDate.Location = new System.Drawing.Point(303, 132);
            txtBirthDate.Name = "txtBirthDate";
            txtBirthDate.Size = new System.Drawing.Size(100, 24);
            txtBirthDate.TabIndex = 6;
            // 
            // txtOrigin
            // 
            txtOrigin.Location = new System.Drawing.Point(5, 162);
            txtOrigin.Name = "txtOrigin";
            txtOrigin.Size = new System.Drawing.Size(504, 24);
            txtOrigin.TabIndex = 7;
            // 
            // txtResidence
            // 
            txtResidence.Location = new System.Drawing.Point(303, 85);
            txtResidence.Name = "txtResidence";
            txtResidence.Size = new System.Drawing.Size(206, 24);
            txtResidence.TabIndex = 4;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new System.Drawing.Point(303, 29);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(206, 24);
            txtFirstName.TabIndex = 2;
            // 
            // txtLastName
            // 
            txtLastName.Location = new System.Drawing.Point(115, 29);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(182, 24);
            txtLastName.TabIndex = 1;
            // 
            // chkDisabled
            // 
            chkDisabled.AutoSize = true;
            chkDisabled.Location = new System.Drawing.Point(303, 188);
            chkDisabled.Name = "chkDisabled";
            chkDisabled.Size = new System.Drawing.Size(99, 22);
            chkDisabled.TabIndex = 155;
            chkDisabled.Text = "Disabilitato";
            chkDisabled.UseVisualStyleBackColor = true;
            // 
            // btnFindStudent
            // 
            btnFindStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFindStudent.Location = new System.Drawing.Point(327, 242);
            btnFindStudent.Name = "btnFindStudent";
            btnFindStudent.Size = new System.Drawing.Size(91, 47);
            btnFindStudent.TabIndex = 156;
            btnFindStudent.Text = "Ricerca";
            btnFindStudent.UseVisualStyleBackColor = true;
            btnFindStudent.Click += btnFindStudent_Click;
            // 
            // btnExitWithoutChoosing
            // 
            btnExitWithoutChoosing.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnExitWithoutChoosing.Location = new System.Drawing.Point(552, 348);
            btnExitWithoutChoosing.Name = "btnExitWithoutChoosing";
            btnExitWithoutChoosing.Size = new System.Drawing.Size(91, 47);
            btnExitWithoutChoosing.TabIndex = 157;
            btnExitWithoutChoosing.Text = "Esci senza scegliere";
            toolTip1.SetToolTip(btnExitWithoutChoosing, "Esci dalla finestra senza scegliere questo studente");
            btnExitWithoutChoosing.UseVisualStyleBackColor = true;
            btnExitWithoutChoosing.Click += btnExitWithoutChoosing_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDeleteStudent.Location = new System.Drawing.Point(375, 348);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new System.Drawing.Size(91, 47);
            btnDeleteStudent.TabIndex = 158;
            btnDeleteStudent.Text = "Cancella";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // chkHasSpecialNeeds
            // 
            chkHasSpecialNeeds.AutoSize = true;
            chkHasSpecialNeeds.Location = new System.Drawing.Point(408, 188);
            chkHasSpecialNeeds.Name = "chkHasSpecialNeeds";
            chkHasSpecialNeeds.Size = new System.Drawing.Size(91, 22);
            chkHasSpecialNeeds.TabIndex = 159;
            chkHasSpecialNeeds.Text = "BES/DSA";
            chkHasSpecialNeeds.UseVisualStyleBackColor = true;
            // 
            // frmStudent
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(754, 407);
            Controls.Add(chkHasSpecialNeeds);
            Controls.Add(btnDeleteStudent);
            Controls.Add(btnExitWithoutChoosing);
            Controls.Add(btnFindStudent);
            Controls.Add(chkDisabled);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(txtResidence);
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
            Controls.Add(lblResidence);
            Controls.Add(lblExistingSameName);
            Controls.Add(dgwSearchedStudents);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
        private System.Windows.Forms.Label lblResidence;
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
        private System.Windows.Forms.TextBox txtResidence;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.CheckBox chkDisabled;
        private System.Windows.Forms.Button btnFindStudent;
        private System.Windows.Forms.Button btnExitWithoutChoosing;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.CheckBox chkHasSpecialNeeds;
    }
}