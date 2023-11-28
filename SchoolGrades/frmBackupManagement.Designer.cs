namespace SchoolGrades
{
    partial class frmBackupManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackupManagement));
            btnClassBackup = new System.Windows.Forms.Button();
            btnBackupTables = new System.Windows.Forms.Button();
            CmbSchoolYear = new System.Windows.Forms.ComboBox();
            lstClasses = new System.Windows.Forms.ListBox();
            grpOnlyOneClass = new System.Windows.Forms.GroupBox();
            btnMakeDemo = new System.Windows.Forms.Button();
            BtnNewDatabase = new System.Windows.Forms.Button();
            btnRestoreTables = new System.Windows.Forms.Button();
            btnBackupTopics = new System.Windows.Forms.Button();
            btnExportTopics = new System.Windows.Forms.Button();
            btnBackupTags = new System.Windows.Forms.Button();
            btnImportTopics = new System.Windows.Forms.Button();
            btnRestoreTopics = new System.Windows.Forms.Button();
            btnSaveDatabaseFile = new System.Windows.Forms.Button();
            btnRestoreTags = new System.Windows.Forms.Button();
            btnRestoreStudents = new System.Windows.Forms.Button();
            btnBackupStudents = new System.Windows.Forms.Button();
            rdbRestoreErasing = new System.Windows.Forms.RadioButton();
            rdbRestoreWithAdd = new System.Windows.Forms.RadioButton();
            btnExportTags = new System.Windows.Forms.Button();
            btnImportTags = new System.Windows.Forms.Button();
            btnCompactDatabase = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            grpOnlyOneClass.SuspendLayout();
            SuspendLayout();
            // 
            // btnClassBackup
            // 
            btnClassBackup.Location = new System.Drawing.Point(6, 67);
            btnClassBackup.Name = "btnClassBackup";
            btnClassBackup.Size = new System.Drawing.Size(98, 68);
            btnClassBackup.TabIndex = 0;
            btnClassBackup.Text = "Genera database classe";
            toolTip1.SetToolTip(btnClassBackup, "Genera un database contenente solo i dati della classe selezionata");
            btnClassBackup.UseVisualStyleBackColor = true;
            btnClassBackup.Click += btnClassBackup_Click;
            // 
            // btnBackupTables
            // 
            btnBackupTables.Location = new System.Drawing.Point(12, 12);
            btnBackupTables.Name = "btnBackupTables";
            btnBackupTables.Size = new System.Drawing.Size(98, 67);
            btnBackupTables.TabIndex = 10;
            btnBackupTables.Text = "Backup tabelle";
            btnBackupTables.UseVisualStyleBackColor = true;
            btnBackupTables.Click += btnBackupTables_Click;
            // 
            // CmbSchoolYear
            // 
            CmbSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            CmbSchoolYear.FormattingEnabled = true;
            CmbSchoolYear.Location = new System.Drawing.Point(6, 23);
            CmbSchoolYear.Name = "CmbSchoolYear";
            CmbSchoolYear.Size = new System.Drawing.Size(98, 26);
            CmbSchoolYear.TabIndex = 64;
            CmbSchoolYear.SelectedIndexChanged += cmbSchoolYear_SelectedIndexChanged;
            // 
            // lstClasses
            // 
            lstClasses.BackColor = System.Drawing.Color.PowderBlue;
            lstClasses.ForeColor = System.Drawing.Color.DarkBlue;
            lstClasses.FormattingEnabled = true;
            lstClasses.ItemHeight = 18;
            lstClasses.Location = new System.Drawing.Point(110, 23);
            lstClasses.Name = "lstClasses";
            lstClasses.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            lstClasses.Size = new System.Drawing.Size(76, 112);
            lstClasses.TabIndex = 63;
            lstClasses.TabStop = false;
            lstClasses.SelectedIndexChanged += lstClasses_SelectedIndexChanged;
            lstClasses.DoubleClick += lstClassi_DoubleClick;
            // 
            // grpOnlyOneClass
            // 
            grpOnlyOneClass.Controls.Add(btnMakeDemo);
            grpOnlyOneClass.Controls.Add(BtnNewDatabase);
            grpOnlyOneClass.Controls.Add(CmbSchoolYear);
            grpOnlyOneClass.Controls.Add(lstClasses);
            grpOnlyOneClass.Controls.Add(btnClassBackup);
            grpOnlyOneClass.Location = new System.Drawing.Point(3, 367);
            grpOnlyOneClass.Name = "grpOnlyOneClass";
            grpOnlyOneClass.Size = new System.Drawing.Size(290, 146);
            grpOnlyOneClass.TabIndex = 65;
            grpOnlyOneClass.TabStop = false;
            grpOnlyOneClass.Text = "Database con solo una classe";
            // 
            // btnMakeDemo
            // 
            btnMakeDemo.Location = new System.Drawing.Point(192, 90);
            btnMakeDemo.Name = "btnMakeDemo";
            btnMakeDemo.Size = new System.Drawing.Size(98, 46);
            btnMakeDemo.TabIndex = 65;
            btnMakeDemo.Text = "Genera dati demo";
            toolTip1.SetToolTip(btnMakeDemo, "Genera un database demo dell'applicazione");
            btnMakeDemo.UseVisualStyleBackColor = true;
            btnMakeDemo.Click += BtnMakeDemo_Click;
            // 
            // BtnNewDatabase
            // 
            BtnNewDatabase.Location = new System.Drawing.Point(192, 23);
            BtnNewDatabase.Name = "BtnNewDatabase";
            BtnNewDatabase.Size = new System.Drawing.Size(98, 68);
            BtnNewDatabase.TabIndex = 81;
            BtnNewDatabase.Text = "Nuovo database (da zero)";
            toolTip1.SetToolTip(BtnNewDatabase, "Database nuovo per cominciare dall'inizio");
            BtnNewDatabase.UseVisualStyleBackColor = true;
            BtnNewDatabase.Click += BtnNewDatabase_Click;
            // 
            // btnRestoreTables
            // 
            btnRestoreTables.Location = new System.Drawing.Point(12, 85);
            btnRestoreTables.Name = "btnRestoreTables";
            btnRestoreTables.Size = new System.Drawing.Size(98, 67);
            btnRestoreTables.TabIndex = 66;
            btnRestoreTables.Text = "Restore tabelle";
            btnRestoreTables.UseVisualStyleBackColor = true;
            btnRestoreTables.Click += btnRestoreTables_Click;
            // 
            // btnBackupTopics
            // 
            btnBackupTopics.Location = new System.Drawing.Point(116, 12);
            btnBackupTopics.Name = "btnBackupTopics";
            btnBackupTopics.Size = new System.Drawing.Size(98, 67);
            btnBackupTopics.TabIndex = 67;
            btnBackupTopics.Text = "Backup argomenti";
            btnBackupTopics.UseVisualStyleBackColor = true;
            btnBackupTopics.Click += btnBackupTopics_Click;
            // 
            // btnExportTopics
            // 
            btnExportTopics.Location = new System.Drawing.Point(116, 217);
            btnExportTopics.Name = "btnExportTopics";
            btnExportTopics.Size = new System.Drawing.Size(98, 67);
            btnExportTopics.TabIndex = 68;
            btnExportTopics.Text = "Export argomenti";
            btnExportTopics.UseVisualStyleBackColor = true;
            btnExportTopics.Click += btnExportTopics_Click;
            // 
            // btnBackupTags
            // 
            btnBackupTags.Location = new System.Drawing.Point(220, 12);
            btnBackupTags.Name = "btnBackupTags";
            btnBackupTags.Size = new System.Drawing.Size(98, 67);
            btnBackupTags.TabIndex = 69;
            btnBackupTags.Text = "Backup tag";
            btnBackupTags.UseVisualStyleBackColor = true;
            btnBackupTags.Click += btnBackupTags_Click;
            // 
            // btnImportTopics
            // 
            btnImportTopics.Location = new System.Drawing.Point(116, 290);
            btnImportTopics.Name = "btnImportTopics";
            btnImportTopics.Size = new System.Drawing.Size(98, 67);
            btnImportTopics.TabIndex = 70;
            btnImportTopics.Text = "Import argomenti";
            btnImportTopics.UseVisualStyleBackColor = true;
            btnImportTopics.Click += btnImportTopics_Click;
            // 
            // btnRestoreTopics
            // 
            btnRestoreTopics.Location = new System.Drawing.Point(116, 85);
            btnRestoreTopics.Name = "btnRestoreTopics";
            btnRestoreTopics.Size = new System.Drawing.Size(98, 67);
            btnRestoreTopics.TabIndex = 71;
            btnRestoreTopics.Text = "Restore argomenti";
            btnRestoreTopics.UseVisualStyleBackColor = true;
            btnRestoreTopics.Click += btnRestoreTopics_Click;
            // 
            // btnSaveDatabaseFile
            // 
            btnSaveDatabaseFile.Location = new System.Drawing.Point(333, 451);
            btnSaveDatabaseFile.Name = "btnSaveDatabaseFile";
            btnSaveDatabaseFile.Size = new System.Drawing.Size(98, 50);
            btnSaveDatabaseFile.TabIndex = 72;
            btnSaveDatabaseFile.Text = "Salva file database";
            toolTip1.SetToolTip(btnSaveDatabaseFile, "Copia il file del database con la data attuale nel nome");
            btnSaveDatabaseFile.UseVisualStyleBackColor = true;
            btnSaveDatabaseFile.Click += btnSaveDatabaseFile_Click;
            // 
            // btnRestoreTags
            // 
            btnRestoreTags.Location = new System.Drawing.Point(220, 85);
            btnRestoreTags.Name = "btnRestoreTags";
            btnRestoreTags.Size = new System.Drawing.Size(98, 67);
            btnRestoreTags.TabIndex = 73;
            btnRestoreTags.Text = "Restore tag";
            btnRestoreTags.UseVisualStyleBackColor = true;
            btnRestoreTags.Click += btnRestoreTags_Click;
            // 
            // btnRestoreStudents
            // 
            btnRestoreStudents.Location = new System.Drawing.Point(326, 85);
            btnRestoreStudents.Name = "btnRestoreStudents";
            btnRestoreStudents.Size = new System.Drawing.Size(98, 67);
            btnRestoreStudents.TabIndex = 75;
            btnRestoreStudents.Text = "Restore allievi";
            btnRestoreStudents.UseVisualStyleBackColor = true;
            btnRestoreStudents.Click += btnRestoreStudents_Click;
            // 
            // btnBackupStudents
            // 
            btnBackupStudents.Location = new System.Drawing.Point(326, 12);
            btnBackupStudents.Name = "btnBackupStudents";
            btnBackupStudents.Size = new System.Drawing.Size(98, 67);
            btnBackupStudents.TabIndex = 74;
            btnBackupStudents.Text = "Backup allievi";
            btnBackupStudents.UseVisualStyleBackColor = true;
            btnBackupStudents.Click += btnBackupStudents_Click;
            // 
            // rdbRestoreErasing
            // 
            rdbRestoreErasing.AutoSize = true;
            rdbRestoreErasing.Checked = true;
            rdbRestoreErasing.Location = new System.Drawing.Point(144, 158);
            rdbRestoreErasing.Name = "rdbRestoreErasing";
            rdbRestoreErasing.Size = new System.Drawing.Size(206, 22);
            rdbRestoreErasing.TabIndex = 76;
            rdbRestoreErasing.TabStop = true;
            rdbRestoreErasing.Text = "Restore con cancellazione ";
            rdbRestoreErasing.UseVisualStyleBackColor = true;
            // 
            // rdbRestoreWithAdd
            // 
            rdbRestoreWithAdd.AutoSize = true;
            rdbRestoreWithAdd.Enabled = false;
            rdbRestoreWithAdd.Location = new System.Drawing.Point(144, 183);
            rdbRestoreWithAdd.Name = "rdbRestoreWithAdd";
            rdbRestoreWithAdd.Size = new System.Drawing.Size(167, 22);
            rdbRestoreWithAdd.TabIndex = 77;
            rdbRestoreWithAdd.Text = "Restore con aggiunta";
            rdbRestoreWithAdd.UseVisualStyleBackColor = true;
            // 
            // btnExportTags
            // 
            btnExportTags.Location = new System.Drawing.Point(220, 217);
            btnExportTags.Name = "btnExportTags";
            btnExportTags.Size = new System.Drawing.Size(98, 67);
            btnExportTags.TabIndex = 78;
            btnExportTags.Text = "Export tag";
            btnExportTags.UseVisualStyleBackColor = true;
            btnExportTags.Click += btnExportTags_Click;
            // 
            // btnImportTags
            // 
            btnImportTags.Location = new System.Drawing.Point(220, 290);
            btnImportTags.Name = "btnImportTags";
            btnImportTags.Size = new System.Drawing.Size(98, 67);
            btnImportTags.TabIndex = 79;
            btnImportTags.Text = "Import tag";
            btnImportTags.UseVisualStyleBackColor = true;
            btnImportTags.Click += btnImportTags_Click;
            // 
            // btnCompactDatabase
            // 
            btnCompactDatabase.Location = new System.Drawing.Point(333, 390);
            btnCompactDatabase.Name = "btnCompactDatabase";
            btnCompactDatabase.Size = new System.Drawing.Size(98, 48);
            btnCompactDatabase.TabIndex = 80;
            btnCompactDatabase.Text = "Compatta database";
            toolTip1.SetToolTip(btnCompactDatabase, "Rende più piccolo il file SqLite del database");
            btnCompactDatabase.UseVisualStyleBackColor = true;
            btnCompactDatabase.Click += btnCompactDatabase_Click;
            // 
            // frmBackupManagement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(436, 513);
            Controls.Add(btnCompactDatabase);
            Controls.Add(btnImportTags);
            Controls.Add(btnExportTags);
            Controls.Add(rdbRestoreWithAdd);
            Controls.Add(rdbRestoreErasing);
            Controls.Add(btnRestoreStudents);
            Controls.Add(btnBackupStudents);
            Controls.Add(btnSaveDatabaseFile);
            Controls.Add(btnRestoreTags);
            Controls.Add(btnRestoreTopics);
            Controls.Add(btnImportTopics);
            Controls.Add(btnBackupTags);
            Controls.Add(btnExportTopics);
            Controls.Add(btnBackupTopics);
            Controls.Add(btnRestoreTables);
            Controls.Add(grpOnlyOneClass);
            Controls.Add(btnBackupTables);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            Name = "frmBackupManagement";
            Text = "Gestione Backup";
            Load += frmBackupManagement_Load;
            grpOnlyOneClass.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnClassBackup;
        private System.Windows.Forms.Button btnBackupTables;
        private System.Windows.Forms.ComboBox CmbSchoolYear;
        private System.Windows.Forms.ListBox lstClasses;
        private System.Windows.Forms.GroupBox grpOnlyOneClass;
        private System.Windows.Forms.Button btnRestoreTables;
        private System.Windows.Forms.Button btnBackupTopics;
        private System.Windows.Forms.Button btnExportTopics;
        private System.Windows.Forms.Button btnBackupTags;
        private System.Windows.Forms.Button btnImportTopics;
        private System.Windows.Forms.Button btnRestoreTopics;
        private System.Windows.Forms.Button btnSaveDatabaseFile;
        private System.Windows.Forms.Button btnRestoreTags;
        private System.Windows.Forms.Button btnRestoreStudents;
        private System.Windows.Forms.Button btnBackupStudents;
        private System.Windows.Forms.RadioButton rdbRestoreErasing;
        private System.Windows.Forms.RadioButton rdbRestoreWithAdd;
        private System.Windows.Forms.Button btnExportTags;
        private System.Windows.Forms.Button btnImportTags;
        private System.Windows.Forms.Button btnCompactDatabase;
        private System.Windows.Forms.Button btnMakeDemo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button BtnNewDatabase;
    }
}