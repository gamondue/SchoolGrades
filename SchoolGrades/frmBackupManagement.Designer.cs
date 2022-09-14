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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackupManagement));
            this.btnClassBackup = new System.Windows.Forms.Button();
            this.btnBackupTables = new System.Windows.Forms.Button();
            this.CmbSchoolYear = new System.Windows.Forms.ComboBox();
            this.lstClasses = new System.Windows.Forms.ListBox();
            this.grpOnlyOneClass = new System.Windows.Forms.GroupBox();
            this.btnMakeDemo = new System.Windows.Forms.Button();
            this.BtnNewDatabase = new System.Windows.Forms.Button();
            this.btnRestoreTables = new System.Windows.Forms.Button();
            this.btnBackupTopics = new System.Windows.Forms.Button();
            this.btnExportTopics = new System.Windows.Forms.Button();
            this.btnBackupTags = new System.Windows.Forms.Button();
            this.btnImportTopics = new System.Windows.Forms.Button();
            this.btnRestoreTopics = new System.Windows.Forms.Button();
            this.btnSaveDatabaseFile = new System.Windows.Forms.Button();
            this.btnRestoreTags = new System.Windows.Forms.Button();
            this.btnRestoreStudents = new System.Windows.Forms.Button();
            this.btnBackupStudents = new System.Windows.Forms.Button();
            this.rdbRestoreErasing = new System.Windows.Forms.RadioButton();
            this.rdbRestoreWithAdd = new System.Windows.Forms.RadioButton();
            this.btnExportTags = new System.Windows.Forms.Button();
            this.btnImportTags = new System.Windows.Forms.Button();
            this.btnCompactDatabase = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpOnlyOneClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClassBackup
            // 
            this.btnClassBackup.Location = new System.Drawing.Point(6, 67);
            this.btnClassBackup.Name = "btnClassBackup";
            this.btnClassBackup.Size = new System.Drawing.Size(98, 68);
            this.btnClassBackup.TabIndex = 0;
            this.btnClassBackup.Text = "Genera database classe";
            this.toolTip1.SetToolTip(this.btnClassBackup, "Genera un database contenente solo i dati della classe selezionata");
            this.btnClassBackup.UseVisualStyleBackColor = true;
            this.btnClassBackup.Click += new System.EventHandler(this.btnClassBackup_Click);
            // 
            // btnBackupTables
            // 
            this.btnBackupTables.Location = new System.Drawing.Point(12, 12);
            this.btnBackupTables.Name = "btnBackupTables";
            this.btnBackupTables.Size = new System.Drawing.Size(98, 67);
            this.btnBackupTables.TabIndex = 10;
            this.btnBackupTables.Text = "Backup tabelle";
            this.btnBackupTables.UseVisualStyleBackColor = true;
            this.btnBackupTables.Click += new System.EventHandler(this.btnBackupTables_Click);
            // 
            // CmbSchoolYear
            // 
            this.CmbSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.CmbSchoolYear.FormattingEnabled = true;
            this.CmbSchoolYear.Location = new System.Drawing.Point(6, 23);
            this.CmbSchoolYear.Name = "CmbSchoolYear";
            this.CmbSchoolYear.Size = new System.Drawing.Size(98, 26);
            this.CmbSchoolYear.TabIndex = 64;
            this.CmbSchoolYear.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolYear_SelectedIndexChanged);
            // 
            // lstClasses
            // 
            this.lstClasses.BackColor = System.Drawing.Color.PowderBlue;
            this.lstClasses.ForeColor = System.Drawing.Color.DarkBlue;
            this.lstClasses.FormattingEnabled = true;
            this.lstClasses.ItemHeight = 18;
            this.lstClasses.Location = new System.Drawing.Point(110, 23);
            this.lstClasses.Name = "lstClasses";
            this.lstClasses.Size = new System.Drawing.Size(76, 112);
            this.lstClasses.TabIndex = 63;
            this.lstClasses.TabStop = false;
            this.lstClasses.SelectedIndexChanged += new System.EventHandler(this.lstClasses_SelectedIndexChanged);
            this.lstClasses.DoubleClick += new System.EventHandler(this.lstClassi_DoubleClick);
            // 
            // grpOnlyOneClass
            // 
            this.grpOnlyOneClass.Controls.Add(this.btnMakeDemo);
            this.grpOnlyOneClass.Controls.Add(this.BtnNewDatabase);
            this.grpOnlyOneClass.Controls.Add(this.CmbSchoolYear);
            this.grpOnlyOneClass.Controls.Add(this.lstClasses);
            this.grpOnlyOneClass.Controls.Add(this.btnClassBackup);
            this.grpOnlyOneClass.Location = new System.Drawing.Point(3, 367);
            this.grpOnlyOneClass.Name = "grpOnlyOneClass";
            this.grpOnlyOneClass.Size = new System.Drawing.Size(290, 146);
            this.grpOnlyOneClass.TabIndex = 65;
            this.grpOnlyOneClass.TabStop = false;
            this.grpOnlyOneClass.Text = "Database con solo una classe";
            // 
            // btnMakeDemo
            // 
            this.btnMakeDemo.Location = new System.Drawing.Point(192, 90);
            this.btnMakeDemo.Name = "btnMakeDemo";
            this.btnMakeDemo.Size = new System.Drawing.Size(98, 46);
            this.btnMakeDemo.TabIndex = 65;
            this.btnMakeDemo.Text = "Genera dati demo";
            this.toolTip1.SetToolTip(this.btnMakeDemo, "Genera un database demo dell\'applicazione");
            this.btnMakeDemo.UseVisualStyleBackColor = true;
            this.btnMakeDemo.Click += new System.EventHandler(this.BtnMakeDemo_Click);
            // 
            // BtnNewDatabase
            // 
            this.BtnNewDatabase.Location = new System.Drawing.Point(192, 23);
            this.BtnNewDatabase.Name = "BtnNewDatabase";
            this.BtnNewDatabase.Size = new System.Drawing.Size(98, 68);
            this.BtnNewDatabase.TabIndex = 81;
            this.BtnNewDatabase.Text = "Nuovo database (da zero)";
            this.toolTip1.SetToolTip(this.BtnNewDatabase, "Database nuovo per cominciare dall\'inizio");
            this.BtnNewDatabase.UseVisualStyleBackColor = true;
            this.BtnNewDatabase.Click += new System.EventHandler(this.BtnNewDatabase_Click);
            // 
            // btnRestoreTables
            // 
            this.btnRestoreTables.Location = new System.Drawing.Point(12, 85);
            this.btnRestoreTables.Name = "btnRestoreTables";
            this.btnRestoreTables.Size = new System.Drawing.Size(98, 67);
            this.btnRestoreTables.TabIndex = 66;
            this.btnRestoreTables.Text = "Restore tabelle";
            this.btnRestoreTables.UseVisualStyleBackColor = true;
            this.btnRestoreTables.Click += new System.EventHandler(this.btnRestoreTables_Click);
            // 
            // btnBackupTopics
            // 
            this.btnBackupTopics.Location = new System.Drawing.Point(116, 12);
            this.btnBackupTopics.Name = "btnBackupTopics";
            this.btnBackupTopics.Size = new System.Drawing.Size(98, 67);
            this.btnBackupTopics.TabIndex = 67;
            this.btnBackupTopics.Text = "Backup argomenti";
            this.btnBackupTopics.UseVisualStyleBackColor = true;
            this.btnBackupTopics.Click += new System.EventHandler(this.btnBackupTopics_Click);
            // 
            // btnExportTopics
            // 
            this.btnExportTopics.Location = new System.Drawing.Point(116, 217);
            this.btnExportTopics.Name = "btnExportTopics";
            this.btnExportTopics.Size = new System.Drawing.Size(98, 67);
            this.btnExportTopics.TabIndex = 68;
            this.btnExportTopics.Text = "Export argomenti";
            this.btnExportTopics.UseVisualStyleBackColor = true;
            this.btnExportTopics.Click += new System.EventHandler(this.btnExportTopics_Click);
            // 
            // btnBackupTags
            // 
            this.btnBackupTags.Location = new System.Drawing.Point(220, 12);
            this.btnBackupTags.Name = "btnBackupTags";
            this.btnBackupTags.Size = new System.Drawing.Size(98, 67);
            this.btnBackupTags.TabIndex = 69;
            this.btnBackupTags.Text = "Backup tag";
            this.btnBackupTags.UseVisualStyleBackColor = true;
            this.btnBackupTags.Click += new System.EventHandler(this.btnBackupTags_Click);
            // 
            // btnImportTopics
            // 
            this.btnImportTopics.Location = new System.Drawing.Point(116, 290);
            this.btnImportTopics.Name = "btnImportTopics";
            this.btnImportTopics.Size = new System.Drawing.Size(98, 67);
            this.btnImportTopics.TabIndex = 70;
            this.btnImportTopics.Text = "Import argomenti";
            this.btnImportTopics.UseVisualStyleBackColor = true;
            this.btnImportTopics.Click += new System.EventHandler(this.btnImportTopics_Click);
            // 
            // btnRestoreTopics
            // 
            this.btnRestoreTopics.Location = new System.Drawing.Point(116, 85);
            this.btnRestoreTopics.Name = "btnRestoreTopics";
            this.btnRestoreTopics.Size = new System.Drawing.Size(98, 67);
            this.btnRestoreTopics.TabIndex = 71;
            this.btnRestoreTopics.Text = "Restore argomenti";
            this.btnRestoreTopics.UseVisualStyleBackColor = true;
            this.btnRestoreTopics.Click += new System.EventHandler(this.btnRestoreTopics_Click);
            // 
            // btnSaveDatabaseFile
            // 
            this.btnSaveDatabaseFile.Location = new System.Drawing.Point(333, 451);
            this.btnSaveDatabaseFile.Name = "btnSaveDatabaseFile";
            this.btnSaveDatabaseFile.Size = new System.Drawing.Size(98, 50);
            this.btnSaveDatabaseFile.TabIndex = 72;
            this.btnSaveDatabaseFile.Text = "Salva file database";
            this.toolTip1.SetToolTip(this.btnSaveDatabaseFile, "Copia il file del database con la data attuale nel nome");
            this.btnSaveDatabaseFile.UseVisualStyleBackColor = true;
            this.btnSaveDatabaseFile.Click += new System.EventHandler(this.btnSaveDatabaseFile_Click);
            // 
            // btnRestoreTags
            // 
            this.btnRestoreTags.Location = new System.Drawing.Point(220, 85);
            this.btnRestoreTags.Name = "btnRestoreTags";
            this.btnRestoreTags.Size = new System.Drawing.Size(98, 67);
            this.btnRestoreTags.TabIndex = 73;
            this.btnRestoreTags.Text = "Restore tag";
            this.btnRestoreTags.UseVisualStyleBackColor = true;
            this.btnRestoreTags.Click += new System.EventHandler(this.btnRestoreTags_Click);
            // 
            // btnRestoreStudents
            // 
            this.btnRestoreStudents.Location = new System.Drawing.Point(326, 85);
            this.btnRestoreStudents.Name = "btnRestoreStudents";
            this.btnRestoreStudents.Size = new System.Drawing.Size(98, 67);
            this.btnRestoreStudents.TabIndex = 75;
            this.btnRestoreStudents.Text = "Restore allievi";
            this.btnRestoreStudents.UseVisualStyleBackColor = true;
            this.btnRestoreStudents.Click += new System.EventHandler(this.btnRestoreStudents_Click);
            // 
            // btnBackupStudents
            // 
            this.btnBackupStudents.Location = new System.Drawing.Point(326, 12);
            this.btnBackupStudents.Name = "btnBackupStudents";
            this.btnBackupStudents.Size = new System.Drawing.Size(98, 67);
            this.btnBackupStudents.TabIndex = 74;
            this.btnBackupStudents.Text = "Backup allievi";
            this.btnBackupStudents.UseVisualStyleBackColor = true;
            this.btnBackupStudents.Click += new System.EventHandler(this.btnBackupStudents_Click);
            // 
            // rdbRestoreErasing
            // 
            this.rdbRestoreErasing.AutoSize = true;
            this.rdbRestoreErasing.Checked = true;
            this.rdbRestoreErasing.Location = new System.Drawing.Point(144, 158);
            this.rdbRestoreErasing.Name = "rdbRestoreErasing";
            this.rdbRestoreErasing.Size = new System.Drawing.Size(206, 22);
            this.rdbRestoreErasing.TabIndex = 76;
            this.rdbRestoreErasing.TabStop = true;
            this.rdbRestoreErasing.Text = "Restore con cancellazione ";
            this.rdbRestoreErasing.UseVisualStyleBackColor = true;
            // 
            // rdbRestoreWithAdd
            // 
            this.rdbRestoreWithAdd.AutoSize = true;
            this.rdbRestoreWithAdd.Enabled = false;
            this.rdbRestoreWithAdd.Location = new System.Drawing.Point(144, 183);
            this.rdbRestoreWithAdd.Name = "rdbRestoreWithAdd";
            this.rdbRestoreWithAdd.Size = new System.Drawing.Size(167, 22);
            this.rdbRestoreWithAdd.TabIndex = 77;
            this.rdbRestoreWithAdd.Text = "Restore con aggiunta";
            this.rdbRestoreWithAdd.UseVisualStyleBackColor = true;
            // 
            // btnExportTags
            // 
            this.btnExportTags.Location = new System.Drawing.Point(220, 217);
            this.btnExportTags.Name = "btnExportTags";
            this.btnExportTags.Size = new System.Drawing.Size(98, 67);
            this.btnExportTags.TabIndex = 78;
            this.btnExportTags.Text = "Export tag";
            this.btnExportTags.UseVisualStyleBackColor = true;
            this.btnExportTags.Click += new System.EventHandler(this.btnExportTags_Click);
            // 
            // btnImportTags
            // 
            this.btnImportTags.Location = new System.Drawing.Point(220, 290);
            this.btnImportTags.Name = "btnImportTags";
            this.btnImportTags.Size = new System.Drawing.Size(98, 67);
            this.btnImportTags.TabIndex = 79;
            this.btnImportTags.Text = "Import tag";
            this.btnImportTags.UseVisualStyleBackColor = true;
            this.btnImportTags.Click += new System.EventHandler(this.btnImportTags_Click);
            // 
            // btnCompactDatabase
            // 
            this.btnCompactDatabase.Location = new System.Drawing.Point(333, 390);
            this.btnCompactDatabase.Name = "btnCompactDatabase";
            this.btnCompactDatabase.Size = new System.Drawing.Size(98, 48);
            this.btnCompactDatabase.TabIndex = 80;
            this.btnCompactDatabase.Text = "Compatta database";
            this.toolTip1.SetToolTip(this.btnCompactDatabase, "Rende più piccolo il file SqLite del database");
            this.btnCompactDatabase.UseVisualStyleBackColor = true;
            this.btnCompactDatabase.Click += new System.EventHandler(this.btnCompactDatabase_Click);
            // 
            // frmBackupManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(436, 513);
            this.Controls.Add(this.btnCompactDatabase);
            this.Controls.Add(this.btnImportTags);
            this.Controls.Add(this.btnExportTags);
            this.Controls.Add(this.rdbRestoreWithAdd);
            this.Controls.Add(this.rdbRestoreErasing);
            this.Controls.Add(this.btnRestoreStudents);
            this.Controls.Add(this.btnBackupStudents);
            this.Controls.Add(this.btnSaveDatabaseFile);
            this.Controls.Add(this.btnRestoreTags);
            this.Controls.Add(this.btnRestoreTopics);
            this.Controls.Add(this.btnImportTopics);
            this.Controls.Add(this.btnBackupTags);
            this.Controls.Add(this.btnExportTopics);
            this.Controls.Add(this.btnBackupTopics);
            this.Controls.Add(this.btnRestoreTables);
            this.Controls.Add(this.grpOnlyOneClass);
            this.Controls.Add(this.btnBackupTables);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmBackupManagement";
            this.Text = "Gestione Backup";
            this.Load += new System.EventHandler(this.frmBackupManagement_Load);
            this.grpOnlyOneClass.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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