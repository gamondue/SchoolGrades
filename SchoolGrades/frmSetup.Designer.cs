namespace SchoolGrades
{
    partial class FrmSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetup));
            btnTabelle = new System.Windows.Forms.Button();
            btnClassi = new System.Windows.Forms.Button();
            btnBackupManagement = new System.Windows.Forms.Button();
            TxtFileDatabase = new System.Windows.Forms.TextBox();
            btnFileDatabase = new System.Windows.Forms.Button();
            TxtPathImages = new System.Windows.Forms.TextBox();
            btnPathImages = new System.Windows.Forms.Button();
            btnSaveConfigurationFile = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            lblFileDatabase = new System.Windows.Forms.Label();
            lblPathDatabase = new System.Windows.Forms.Label();
            TxtPathDatabase = new System.Windows.Forms.TextBox();
            btnPathDatabase = new System.Windows.Forms.Button();
            lblPathImages = new System.Windows.Forms.Label();
            btnTopicsManagement = new System.Windows.Forms.Button();
            btnTagsManagement = new System.Windows.Forms.Button();
            btnStartLinksManagenet = new System.Windows.Forms.Button();
            btnQuestionManagement = new System.Windows.Forms.Button();
            btnTestManagement = new System.Windows.Forms.Button();
            btnRecoverTopics = new System.Windows.Forms.Button();
            TxtPathDocuments = new System.Windows.Forms.TextBox();
            btnPathDocuments = new System.Windows.Forms.Button();
            lblPathDocuments = new System.Windows.Forms.Label();
            btnEraseConfigurationFile = new System.Windows.Forms.Button();
            BtnUseDemo = new System.Windows.Forms.Button();
            btnSchoolSubjectManagement = new System.Windows.Forms.Button();
            btnOpenConfigurationFolder = new System.Windows.Forms.Button();
            chkAskPassword = new System.Windows.Forms.CheckBox();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            chkSaveBackup = new System.Windows.Forms.CheckBox();
            btnSchoolPeriodsManagement = new System.Windows.Forms.Button();
            btnUsersManagement = new System.Windows.Forms.Button();
            btnResetDatabase = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnTabelle
            // 
            btnTabelle.Location = new System.Drawing.Point(8, 12);
            btnTabelle.Name = "btnTabelle";
            btnTabelle.Size = new System.Drawing.Size(82, 60);
            btnTabelle.TabIndex = 0;
            btnTabelle.Text = "Gestione tabelle";
            toolTip1.SetToolTip(btnTabelle, "Modifiche delle tabelle dei dati fissi");
            btnTabelle.UseVisualStyleBackColor = true;
            btnTabelle.Click += BtnTabelle_Click;
            // 
            // btnClassi
            // 
            btnClassi.Location = new System.Drawing.Point(95, 12);
            btnClassi.Name = "btnClassi";
            btnClassi.Size = new System.Drawing.Size(82, 60);
            btnClassi.TabIndex = 1;
            btnClassi.Text = "Gestione classi";
            toolTip1.SetToolTip(btnClassi, "Creazione e modifica delle classi");
            btnClassi.UseVisualStyleBackColor = true;
            btnClassi.Click += BtnClassi_Click;
            // 
            // btnBackupManagement
            // 
            btnBackupManagement.Location = new System.Drawing.Point(182, 12);
            btnBackupManagement.Name = "btnBackupManagement";
            btnBackupManagement.Size = new System.Drawing.Size(82, 60);
            btnBackupManagement.TabIndex = 2;
            btnBackupManagement.Text = "Backup e gen.file";
            toolTip1.SetToolTip(btnBackupManagement, "Generazione di file e salvataggi di backup");
            btnBackupManagement.UseVisualStyleBackColor = true;
            btnBackupManagement.Click += btnBackupManagement_Click;
            // 
            // TxtFileDatabase
            // 
            TxtFileDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TxtFileDatabase.Location = new System.Drawing.Point(8, 153);
            TxtFileDatabase.Margin = new System.Windows.Forms.Padding(4);
            TxtFileDatabase.Name = "TxtFileDatabase";
            TxtFileDatabase.Size = new System.Drawing.Size(537, 24);
            TxtFileDatabase.TabIndex = 2;
            TxtFileDatabase.TextChanged += TxtFileDatabase_TextChanged;
            TxtFileDatabase.DoubleClick += TxtPaths_DoubleClick;
            // 
            // btnFileDatabase
            // 
            btnFileDatabase.BackColor = System.Drawing.Color.Transparent;
            btnFileDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnFileDatabase.ForeColor = System.Drawing.Color.DarkBlue;
            btnFileDatabase.Location = new System.Drawing.Point(555, 144);
            btnFileDatabase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnFileDatabase.Name = "btnFileDatabase";
            btnFileDatabase.Size = new System.Drawing.Size(54, 40);
            btnFileDatabase.TabIndex = 84;
            btnFileDatabase.Text = "..";
            btnFileDatabase.UseVisualStyleBackColor = false;
            btnFileDatabase.Click += btnScegliFile_Click;
            // 
            // TxtPathImages
            // 
            TxtPathImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TxtPathImages.Location = new System.Drawing.Point(8, 203);
            TxtPathImages.Margin = new System.Windows.Forms.Padding(4);
            TxtPathImages.Name = "TxtPathImages";
            TxtPathImages.Size = new System.Drawing.Size(762, 24);
            TxtPathImages.TabIndex = 15;
            TxtPathImages.TextChanged += TxtPathImages_TextChanged;
            TxtPathImages.DoubleClick += TxtPaths_DoubleClick;
            // 
            // btnPathImages
            // 
            btnPathImages.BackColor = System.Drawing.Color.Transparent;
            btnPathImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPathImages.ForeColor = System.Drawing.Color.DarkBlue;
            btnPathImages.Location = new System.Drawing.Point(780, 193);
            btnPathImages.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnPathImages.Name = "btnPathImages";
            btnPathImages.Size = new System.Drawing.Size(54, 40);
            btnPathImages.TabIndex = 83;
            btnPathImages.Text = "..";
            btnPathImages.UseVisualStyleBackColor = false;
            btnPathImages.Click += btnCartellaImmagini_Click;
            // 
            // btnSaveConfigurationFile
            // 
            btnSaveConfigurationFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnSaveConfigurationFile.Location = new System.Drawing.Point(965, 76);
            btnSaveConfigurationFile.Name = "btnSaveConfigurationFile";
            btnSaveConfigurationFile.Size = new System.Drawing.Size(82, 60);
            btnSaveConfigurationFile.TabIndex = 92;
            btnSaveConfigurationFile.Text = "Salva config.";
            btnSaveConfigurationFile.UseVisualStyleBackColor = true;
            btnSaveConfigurationFile.Click += btnSave_Click;
            // 
            // lblFileDatabase
            // 
            lblFileDatabase.AutoSize = true;
            lblFileDatabase.Location = new System.Drawing.Point(5, 132);
            lblFileDatabase.Name = "lblFileDatabase";
            lblFileDatabase.Size = new System.Drawing.Size(81, 18);
            lblFileDatabase.TabIndex = 93;
            lblFileDatabase.Text = "File dei dati";
            // 
            // lblPathDatabase
            // 
            lblPathDatabase.AutoSize = true;
            lblPathDatabase.Location = new System.Drawing.Point(5, 74);
            lblPathDatabase.Name = "lblPathDatabase";
            lblPathDatabase.Size = new System.Drawing.Size(108, 18);
            lblPathDatabase.TabIndex = 96;
            lblPathDatabase.Text = "Cartella dei dati";
            // 
            // TxtPathDatabase
            // 
            TxtPathDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TxtPathDatabase.Location = new System.Drawing.Point(8, 95);
            TxtPathDatabase.Margin = new System.Windows.Forms.Padding(4);
            TxtPathDatabase.Name = "TxtPathDatabase";
            TxtPathDatabase.Size = new System.Drawing.Size(762, 24);
            TxtPathDatabase.TabIndex = 94;
            TxtPathDatabase.TextChanged += TxtPathDatabase_TextChanged;
            TxtPathDatabase.DoubleClick += TxtPaths_DoubleClick;
            // 
            // btnPathDatabase
            // 
            btnPathDatabase.BackColor = System.Drawing.Color.Transparent;
            btnPathDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPathDatabase.ForeColor = System.Drawing.Color.DarkBlue;
            btnPathDatabase.Location = new System.Drawing.Point(780, 86);
            btnPathDatabase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnPathDatabase.Name = "btnPathDatabase";
            btnPathDatabase.Size = new System.Drawing.Size(54, 40);
            btnPathDatabase.TabIndex = 95;
            btnPathDatabase.Text = "..";
            btnPathDatabase.UseVisualStyleBackColor = false;
            btnPathDatabase.Click += btnPathDatabase_Click;
            // 
            // lblPathImages
            // 
            lblPathImages.AutoSize = true;
            lblPathImages.Location = new System.Drawing.Point(5, 181);
            lblPathImages.Name = "lblPathImages";
            lblPathImages.Size = new System.Drawing.Size(155, 18);
            lblPathImages.TabIndex = 97;
            lblPathImages.Text = "Cartella delle immagini";
            // 
            // btnTopicsManagement
            // 
            btnTopicsManagement.Location = new System.Drawing.Point(269, 12);
            btnTopicsManagement.Name = "btnTopicsManagement";
            btnTopicsManagement.Size = new System.Drawing.Size(82, 60);
            btnTopicsManagement.TabIndex = 99;
            btnTopicsManagement.Text = "Gestione argomenti";
            toolTip1.SetToolTip(btnTopicsManagement, "Gestione dell'albero degli argomenti");
            btnTopicsManagement.UseVisualStyleBackColor = true;
            btnTopicsManagement.Click += btnTopicsManagement_Click;
            // 
            // btnTagsManagement
            // 
            btnTagsManagement.Location = new System.Drawing.Point(356, 12);
            btnTagsManagement.Name = "btnTagsManagement";
            btnTagsManagement.Size = new System.Drawing.Size(82, 60);
            btnTagsManagement.TabIndex = 100;
            btnTagsManagement.Text = "Gestione tag";
            toolTip1.SetToolTip(btnTagsManagement, "Gestione dei tag associati agli argomenti ");
            btnTagsManagement.UseVisualStyleBackColor = true;
            btnTagsManagement.Click += btnTagsManagement_Click;
            // 
            // btnStartLinksManagenet
            // 
            btnStartLinksManagenet.Location = new System.Drawing.Point(530, 12);
            btnStartLinksManagenet.Name = "btnStartLinksManagenet";
            btnStartLinksManagenet.Size = new System.Drawing.Size(82, 60);
            btnStartLinksManagenet.TabIndex = 101;
            btnStartLinksManagenet.Text = "Gestione start links";
            toolTip1.SetToolTip(btnStartLinksManagenet, "Gestione di link e programmi lanciati all'apertura di una classe");
            btnStartLinksManagenet.UseVisualStyleBackColor = true;
            btnStartLinksManagenet.Click += btnStartLinksManagenet_Click;
            // 
            // btnQuestionManagement
            // 
            btnQuestionManagement.Enabled = false;
            btnQuestionManagement.Location = new System.Drawing.Point(443, 12);
            btnQuestionManagement.Name = "btnQuestionManagement";
            btnQuestionManagement.Size = new System.Drawing.Size(82, 60);
            btnQuestionManagement.TabIndex = 102;
            btnQuestionManagement.Text = "Gestione domande";
            toolTip1.SetToolTip(btnQuestionManagement, "Gestione delle domande");
            btnQuestionManagement.UseVisualStyleBackColor = true;
            btnQuestionManagement.Click += btnQuestionManagement_Click;
            // 
            // btnTestManagement
            // 
            btnTestManagement.Enabled = false;
            btnTestManagement.Location = new System.Drawing.Point(617, 12);
            btnTestManagement.Name = "btnTestManagement";
            btnTestManagement.Size = new System.Drawing.Size(82, 60);
            btnTestManagement.TabIndex = 103;
            btnTestManagement.Text = "Gestione prove";
            toolTip1.SetToolTip(btnTestManagement, "Gestione dei test (da finire e controllare! )");
            btnTestManagement.UseVisualStyleBackColor = true;
            btnTestManagement.Click += btnTestManagement_Click;
            // 
            // btnRecoverTopics
            // 
            btnRecoverTopics.Location = new System.Drawing.Point(704, 12);
            btnRecoverTopics.Name = "btnRecoverTopics";
            btnRecoverTopics.Size = new System.Drawing.Size(82, 60);
            btnRecoverTopics.TabIndex = 104;
            btnRecoverTopics.Text = "Recover argomenti";
            toolTip1.SetToolTip(btnRecoverTopics, "Confronto fra versioni dell'albero degli argomenti (da complatare)");
            btnRecoverTopics.UseVisualStyleBackColor = true;
            btnRecoverTopics.Click += btnRecoverTopics_Click;
            // 
            // TxtPathDocuments
            // 
            TxtPathDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TxtPathDocuments.Location = new System.Drawing.Point(8, 258);
            TxtPathDocuments.Margin = new System.Windows.Forms.Padding(4);
            TxtPathDocuments.Name = "TxtPathDocuments";
            TxtPathDocuments.Size = new System.Drawing.Size(762, 24);
            TxtPathDocuments.TabIndex = 105;
            TxtPathDocuments.TextChanged += TxtPathDocuments_TextChanged;
            TxtPathDocuments.DoubleClick += TxtPaths_DoubleClick;
            // 
            // btnPathDocuments
            // 
            btnPathDocuments.BackColor = System.Drawing.Color.Transparent;
            btnPathDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPathDocuments.ForeColor = System.Drawing.Color.DarkBlue;
            btnPathDocuments.Location = new System.Drawing.Point(780, 248);
            btnPathDocuments.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnPathDocuments.Name = "btnPathDocuments";
            btnPathDocuments.Size = new System.Drawing.Size(54, 40);
            btnPathDocuments.TabIndex = 106;
            btnPathDocuments.Text = "..";
            btnPathDocuments.UseVisualStyleBackColor = false;
            btnPathDocuments.Click += btnPathDocuments_Click;
            // 
            // lblPathDocuments
            // 
            lblPathDocuments.AutoSize = true;
            lblPathDocuments.Location = new System.Drawing.Point(5, 236);
            lblPathDocuments.Name = "lblPathDocuments";
            lblPathDocuments.Size = new System.Drawing.Size(154, 18);
            lblPathDocuments.TabIndex = 107;
            lblPathDocuments.Text = "Cartella dei documenti";
            // 
            // btnEraseConfigurationFile
            // 
            btnEraseConfigurationFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnEraseConfigurationFile.Location = new System.Drawing.Point(965, 206);
            btnEraseConfigurationFile.Name = "btnEraseConfigurationFile";
            btnEraseConfigurationFile.Size = new System.Drawing.Size(82, 60);
            btnEraseConfigurationFile.TabIndex = 108;
            btnEraseConfigurationFile.Text = "Cancella config.";
            btnEraseConfigurationFile.UseVisualStyleBackColor = true;
            btnEraseConfigurationFile.Click += btnEraseConfigurationFile_Click;
            // 
            // BtnUseDemo
            // 
            BtnUseDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BtnUseDemo.Location = new System.Drawing.Point(867, 141);
            BtnUseDemo.Name = "BtnUseDemo";
            BtnUseDemo.Size = new System.Drawing.Size(82, 60);
            BtnUseDemo.TabIndex = 109;
            BtnUseDemo.Text = "Usa demo";
            BtnUseDemo.UseVisualStyleBackColor = true;
            BtnUseDemo.Visible = false;
            BtnUseDemo.Click += BtnUseDemo_Click;
            // 
            // btnSchoolSubjectManagement
            // 
            btnSchoolSubjectManagement.Location = new System.Drawing.Point(878, 12);
            btnSchoolSubjectManagement.Name = "btnSchoolSubjectManagement";
            btnSchoolSubjectManagement.Size = new System.Drawing.Size(82, 60);
            btnSchoolSubjectManagement.TabIndex = 110;
            btnSchoolSubjectManagement.Text = "Gestione materie";
            btnSchoolSubjectManagement.UseVisualStyleBackColor = true;
            btnSchoolSubjectManagement.Click += btnSchoolSubjectManagement_Click;
            // 
            // btnOpenConfigurationFolder
            // 
            btnOpenConfigurationFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnOpenConfigurationFolder.Location = new System.Drawing.Point(965, 141);
            btnOpenConfigurationFolder.Name = "btnOpenConfigurationFolder";
            btnOpenConfigurationFolder.Size = new System.Drawing.Size(82, 60);
            btnOpenConfigurationFolder.TabIndex = 111;
            btnOpenConfigurationFolder.Text = "Cartella config.";
            btnOpenConfigurationFolder.UseVisualStyleBackColor = true;
            btnOpenConfigurationFolder.Click += btnOpenConfigurationFolder_Click;
            // 
            // chkAskPassword
            // 
            chkAskPassword.AutoSize = true;
            chkAskPassword.Enabled = false;
            chkAskPassword.Location = new System.Drawing.Point(878, 272);
            chkAskPassword.Name = "chkAskPassword";
            chkAskPassword.Size = new System.Drawing.Size(152, 22);
            chkAskPassword.TabIndex = 112;
            chkAskPassword.Text = "Chiedi la password";
            toolTip1.SetToolTip(chkAskPassword, "Se abilitato il programma chiede una password per entrare");
            chkAskPassword.UseVisualStyleBackColor = true;
            // 
            // chkSaveBackup
            // 
            chkSaveBackup.AutoSize = true;
            chkSaveBackup.Location = new System.Drawing.Point(618, 152);
            chkSaveBackup.Name = "chkSaveBackup";
            chkSaveBackup.Size = new System.Drawing.Size(213, 22);
            chkSaveBackup.TabIndex = 113;
            chkSaveBackup.Text = "Salva database alla chiusura";
            toolTip1.SetToolTip(chkSaveBackup, "Se abilitato il programma chiede una password per entrare");
            chkSaveBackup.UseVisualStyleBackColor = true;
            // 
            // btnSchoolPeriodsManagement
            // 
            btnSchoolPeriodsManagement.Location = new System.Drawing.Point(965, 11);
            btnSchoolPeriodsManagement.Name = "btnSchoolPeriodsManagement";
            btnSchoolPeriodsManagement.Size = new System.Drawing.Size(82, 60);
            btnSchoolPeriodsManagement.TabIndex = 115;
            btnSchoolPeriodsManagement.Text = "Gestione periodi";
            toolTip1.SetToolTip(btnSchoolPeriodsManagement, "Gestione periodi scolastici (trimesti, quadrimestri..)");
            btnSchoolPeriodsManagement.UseVisualStyleBackColor = true;
            btnSchoolPeriodsManagement.Click += btnSchoolPeriodsManagement_Click;
            // 
            // btnUsersManagement
            // 
            btnUsersManagement.Enabled = false;
            btnUsersManagement.Location = new System.Drawing.Point(791, 12);
            btnUsersManagement.Name = "btnUsersManagement";
            btnUsersManagement.Size = new System.Drawing.Size(82, 60);
            btnUsersManagement.TabIndex = 114;
            btnUsersManagement.Text = "Gestione Utenti";
            toolTip1.SetToolTip(btnUsersManagement, "TODO!");
            btnUsersManagement.UseVisualStyleBackColor = true;
            btnUsersManagement.Click += btnUsersManagement_Click;
            // 
            // btnResetDatabase
            // 
            btnResetDatabase.BackColor = System.Drawing.Color.Red;
            btnResetDatabase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnResetDatabase.ForeColor = System.Drawing.Color.Yellow;
            btnResetDatabase.Location = new System.Drawing.Point(859, 203);
            btnResetDatabase.Name = "btnResetDatabase";
            btnResetDatabase.Size = new System.Drawing.Size(99, 69);
            btnResetDatabase.TabIndex = 116;
            btnResetDatabase.Text = "Reset database";
            btnResetDatabase.UseVisualStyleBackColor = false;
            btnResetDatabase.Click += btnResetDatabase_Click;
            // 
            // FrmSetup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(1051, 298);
            Controls.Add(btnResetDatabase);
            Controls.Add(btnSchoolPeriodsManagement);
            Controls.Add(btnUsersManagement);
            Controls.Add(chkSaveBackup);
            Controls.Add(chkAskPassword);
            Controls.Add(btnOpenConfigurationFolder);
            Controls.Add(btnSchoolSubjectManagement);
            Controls.Add(BtnUseDemo);
            Controls.Add(btnEraseConfigurationFile);
            Controls.Add(TxtPathDocuments);
            Controls.Add(btnPathDocuments);
            Controls.Add(lblPathDocuments);
            Controls.Add(btnRecoverTopics);
            Controls.Add(btnTestManagement);
            Controls.Add(btnQuestionManagement);
            Controls.Add(btnStartLinksManagenet);
            Controls.Add(btnTagsManagement);
            Controls.Add(btnTopicsManagement);
            Controls.Add(TxtPathImages);
            Controls.Add(btnPathImages);
            Controls.Add(lblPathImages);
            Controls.Add(lblPathDatabase);
            Controls.Add(TxtPathDatabase);
            Controls.Add(btnPathDatabase);
            Controls.Add(btnSaveConfigurationFile);
            Controls.Add(lblFileDatabase);
            Controls.Add(TxtFileDatabase);
            Controls.Add(btnFileDatabase);
            Controls.Add(btnBackupManagement);
            Controls.Add(btnClassi);
            Controls.Add(btnTabelle);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            Name = "FrmSetup";
            Text = "Setup";
            Load += frmSetup_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnTabelle;
        private System.Windows.Forms.Button btnClassi;
        private System.Windows.Forms.Button btnBackupManagement;
        private System.Windows.Forms.TextBox TxtFileDatabase;
        private System.Windows.Forms.Button btnFileDatabase;
        private System.Windows.Forms.TextBox TxtPathImages;
        private System.Windows.Forms.Button btnPathImages;
        private System.Windows.Forms.Button btnSaveConfigurationFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblFileDatabase;
        private System.Windows.Forms.Label lblPathDatabase;
        private System.Windows.Forms.TextBox TxtPathDatabase;
        private System.Windows.Forms.Button btnPathDatabase;
        private System.Windows.Forms.Label lblPathImages;
        private System.Windows.Forms.Button btnTopicsManagement;
        private System.Windows.Forms.Button btnTagsManagement;
        private System.Windows.Forms.Button btnStartLinksManagenet;
        private System.Windows.Forms.Button btnQuestionManagement;
        private System.Windows.Forms.Button btnTestManagement;
        private System.Windows.Forms.Button btnRecoverTopics;
        private System.Windows.Forms.TextBox TxtPathDocuments;
        private System.Windows.Forms.Button btnPathDocuments;
        private System.Windows.Forms.Label lblPathDocuments;
        private System.Windows.Forms.Button btnEraseConfigurationFile;
        private System.Windows.Forms.Button BtnUseDemo;
        private System.Windows.Forms.Button btnSchoolSubjectManagement;
        private System.Windows.Forms.Button btnOpenConfigurationFolder;
        private System.Windows.Forms.CheckBox chkAskPassword;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkSaveBackup;
        private System.Windows.Forms.Button btnUsersManagement;
        private System.Windows.Forms.Button btnSchoolPeriodsManagement;
        private System.Windows.Forms.Button btnResetDatabase;
    }
}