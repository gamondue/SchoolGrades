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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudent));
            this.btnNew = new System.Windows.Forms.Button();
            this.lblBirthPlace = new System.Windows.Forms.Label();
            this.lblOrigin = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblStudentCode = new System.Windows.Forms.Label();
            this.txtIdStudent = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblResidence = new System.Windows.Forms.Label();
            this.btnFindHomonyms = new System.Windows.Forms.Button();
            this.lblExistingSameName = new System.Windows.Forms.Label();
            this.dgwSearchedStudents = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.picStudent = new System.Windows.Forms.PictureBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtBirthPlace = new System.Windows.Forms.TextBox();
            this.txtBirthDate = new System.Windows.Forms.TextBox();
            this.txtOrigin = new System.Windows.Forms.TextBox();
            this.txtResidence = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.chkDisabled = new System.Windows.Forms.CheckBox();
            this.btnFindStudent = new System.Windows.Forms.Button();
            this.btnExitWithoutChoosing = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.chkHasSpecialNeeds = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSearchedStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(424, 242);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(91, 47);
            this.btnNew.TabIndex = 151;
            this.btnNew.Text = "Pulisci dati";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblBirthPlace
            // 
            this.lblBirthPlace.AutoSize = true;
            this.lblBirthPlace.Location = new System.Drawing.Point(5, 111);
            this.lblBirthPlace.Name = "lblBirthPlace";
            this.lblBirthPlace.Size = new System.Drawing.Size(114, 18);
            this.lblBirthPlace.TabIndex = 148;
            this.lblBirthPlace.Text = "Posto di nascita";
            // 
            // lblOrigin
            // 
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblOrigin.Location = new System.Drawing.Point(419, 141);
            this.lblOrigin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(90, 18);
            this.lblOrigin.TabIndex = 146;
            this.lblOrigin.Text = "Provenienza";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblBirthDate.Location = new System.Drawing.Point(300, 111);
            this.lblBirthDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(105, 18);
            this.lblBirthDate.TabIndex = 144;
            this.lblBirthDate.Text = "Data di nascita";
            // 
            // lblStudentCode
            // 
            this.lblStudentCode.AutoSize = true;
            this.lblStudentCode.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStudentCode.Location = new System.Drawing.Point(5, 7);
            this.lblStudentCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentCode.Name = "lblStudentCode";
            this.lblStudentCode.Size = new System.Drawing.Size(85, 18);
            this.lblStudentCode.TabIndex = 142;
            this.lblStudentCode.Text = "Cod. allievo";
            // 
            // txtIdStudent
            // 
            this.txtIdStudent.Enabled = false;
            this.txtIdStudent.Location = new System.Drawing.Point(5, 29);
            this.txtIdStudent.Name = "txtIdStudent";
            this.txtIdStudent.Size = new System.Drawing.Size(100, 24);
            this.txtIdStudent.TabIndex = 141;
            this.txtIdStudent.TabStop = false;
            this.txtIdStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLastName.Location = new System.Drawing.Point(112, 7);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(74, 18);
            this.lblLastName.TabIndex = 140;
            this.lblLastName.Text = "Cognome";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblEmail.Location = new System.Drawing.Point(5, 63);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(43, 18);
            this.lblEmail.TabIndex = 137;
            this.lblEmail.Text = "email";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblFirstName.Location = new System.Drawing.Point(300, 7);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(49, 18);
            this.lblFirstName.TabIndex = 136;
            this.lblFirstName.Text = "Nome";
            // 
            // lblResidence
            // 
            this.lblResidence.AutoSize = true;
            this.lblResidence.Location = new System.Drawing.Point(300, 63);
            this.lblResidence.Name = "lblResidence";
            this.lblResidence.Size = new System.Drawing.Size(78, 18);
            this.lblResidence.TabIndex = 135;
            this.lblResidence.Text = "Residenza";
            // 
            // btnFindHomonyms
            // 
            this.btnFindHomonyms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindHomonyms.Location = new System.Drawing.Point(327, 295);
            this.btnFindHomonyms.Name = "btnFindHomonyms";
            this.btnFindHomonyms.Size = new System.Drawing.Size(91, 47);
            this.btnFindHomonyms.TabIndex = 134;
            this.btnFindHomonyms.Text = "Ricerca omonimi";
            this.btnFindHomonyms.UseVisualStyleBackColor = true;
            this.btnFindHomonyms.Click += new System.EventHandler(this.btnFindHomonym_Click);
            // 
            // lblExistingSameName
            // 
            this.lblExistingSameName.AutoSize = true;
            this.lblExistingSameName.Location = new System.Drawing.Point(5, 188);
            this.lblExistingSameName.Name = "lblExistingSameName";
            this.lblExistingSameName.Size = new System.Drawing.Size(88, 18);
            this.lblExistingSameName.TabIndex = 133;
            this.lblExistingSameName.Text = "Allievi trovati";
            // 
            // dgwSearchedStudents
            // 
            this.dgwSearchedStudents.AllowUserToAddRows = false;
            this.dgwSearchedStudents.AllowUserToDeleteRows = false;
            this.dgwSearchedStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwSearchedStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwSearchedStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSearchedStudents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwSearchedStudents.Location = new System.Drawing.Point(5, 213);
            this.dgwSearchedStudents.Name = "dgwSearchedStudents";
            this.dgwSearchedStudents.Size = new System.Drawing.Size(292, 187);
            this.dgwSearchedStudents.TabIndex = 132;
            this.dgwSearchedStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwSearchedStudents_CellClick);
            this.dgwSearchedStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwSearchedStudents_CellContentClick);
            this.dgwSearchedStudents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwSearchedStudents_CellDoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(424, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 47);
            this.btnSave.TabIndex = 153;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picStudent
            // 
            this.picStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picStudent.Location = new System.Drawing.Point(519, 12);
            this.picStudent.Name = "picStudent";
            this.picStudent.Size = new System.Drawing.Size(221, 221);
            this.picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStudent.TabIndex = 152;
            this.picStudent.TabStop = false;
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoose.Location = new System.Drawing.Point(649, 348);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(91, 47);
            this.btnChoose.TabIndex = 154;
            this.btnChoose.Text = "Scegli";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(5, 85);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(292, 24);
            this.txtEmail.TabIndex = 3;
            // 
            // txtBirthPlace
            // 
            this.txtBirthPlace.Location = new System.Drawing.Point(5, 132);
            this.txtBirthPlace.Name = "txtBirthPlace";
            this.txtBirthPlace.Size = new System.Drawing.Size(292, 24);
            this.txtBirthPlace.TabIndex = 5;
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.Location = new System.Drawing.Point(303, 132);
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.Size = new System.Drawing.Size(100, 24);
            this.txtBirthDate.TabIndex = 6;
            // 
            // txtOrigin
            // 
            this.txtOrigin.Location = new System.Drawing.Point(5, 162);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(504, 24);
            this.txtOrigin.TabIndex = 7;
            // 
            // txtResidence
            // 
            this.txtResidence.Location = new System.Drawing.Point(303, 85);
            this.txtResidence.Name = "txtResidence";
            this.txtResidence.Size = new System.Drawing.Size(206, 24);
            this.txtResidence.TabIndex = 4;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(303, 29);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(206, 24);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(115, 29);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(182, 24);
            this.txtLastName.TabIndex = 1;
            // 
            // chkDisabled
            // 
            this.chkDisabled.AutoSize = true;
            this.chkDisabled.Location = new System.Drawing.Point(303, 188);
            this.chkDisabled.Name = "chkDisabled";
            this.chkDisabled.Size = new System.Drawing.Size(99, 22);
            this.chkDisabled.TabIndex = 155;
            this.chkDisabled.Text = "Disabilitato";
            this.chkDisabled.UseVisualStyleBackColor = true;
            // 
            // btnFindStudent
            // 
            this.btnFindStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindStudent.Location = new System.Drawing.Point(327, 242);
            this.btnFindStudent.Name = "btnFindStudent";
            this.btnFindStudent.Size = new System.Drawing.Size(91, 47);
            this.btnFindStudent.TabIndex = 156;
            this.btnFindStudent.Text = "Ricerca";
            this.btnFindStudent.UseVisualStyleBackColor = true;
            this.btnFindStudent.Click += new System.EventHandler(this.btnFindStudent_Click);
            // 
            // btnExitWithoutChoosing
            // 
            this.btnExitWithoutChoosing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitWithoutChoosing.Location = new System.Drawing.Point(552, 348);
            this.btnExitWithoutChoosing.Name = "btnExitWithoutChoosing";
            this.btnExitWithoutChoosing.Size = new System.Drawing.Size(91, 47);
            this.btnExitWithoutChoosing.TabIndex = 157;
            this.btnExitWithoutChoosing.Text = "Esci senza scegliere";
            this.toolTip1.SetToolTip(this.btnExitWithoutChoosing, "Esci dalla finestra senza scegliere questo studente");
            this.btnExitWithoutChoosing.UseVisualStyleBackColor = true;
            this.btnExitWithoutChoosing.Click += new System.EventHandler(this.btnExitWithoutChoosing_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteStudent.Location = new System.Drawing.Point(375, 348);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(91, 47);
            this.btnDeleteStudent.TabIndex = 158;
            this.btnDeleteStudent.Text = "Cancella";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // chkHasSpecialNeeds
            // 
            this.chkHasSpecialNeeds.AutoSize = true;
            this.chkHasSpecialNeeds.Location = new System.Drawing.Point(408, 188);
            this.chkHasSpecialNeeds.Name = "chkHasSpecialNeeds";
            this.chkHasSpecialNeeds.Size = new System.Drawing.Size(91, 22);
            this.chkHasSpecialNeeds.TabIndex = 159;
            this.chkHasSpecialNeeds.Text = "BES/DSA";
            this.chkHasSpecialNeeds.UseVisualStyleBackColor = true;
            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(754, 407);
            this.Controls.Add(this.chkHasSpecialNeeds);
            this.Controls.Add(this.btnDeleteStudent);
            this.Controls.Add(this.btnExitWithoutChoosing);
            this.Controls.Add(this.btnFindStudent);
            this.Controls.Add(this.chkDisabled);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtResidence);
            this.Controls.Add(this.txtOrigin);
            this.Controls.Add(this.txtBirthDate);
            this.Controls.Add(this.txtBirthPlace);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnFindHomonyms);
            this.Controls.Add(this.picStudent);
            this.Controls.Add(this.lblBirthPlace);
            this.Controls.Add(this.lblOrigin);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.lblStudentCode);
            this.Controls.Add(this.txtIdStudent);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblResidence);
            this.Controls.Add(this.lblExistingSameName);
            this.Controls.Add(this.dgwSearchedStudents);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmStudent";
            this.Text = "Gestione studenti";
            this.toolTip1.SetToolTip(this, "Esci scegliendo l\'attuale studente");
            this.Load += new System.EventHandler(this.frmStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwSearchedStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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