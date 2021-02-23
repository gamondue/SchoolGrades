namespace SchoolGrades
{
    partial class frmImages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImages));
            this.DgwLessonsImages = new System.Windows.Forms.DataGridView();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.txtLessonDesc = new System.Windows.Forms.TextBox();
            this.txtSchoolSubject = new System.Windows.Forms.TextBox();
            this.lblLessonDesc = new System.Windows.Forms.Label();
            this.lblLessonDate = new System.Windows.Forms.Label();
            this.lblLessonCode = new System.Windows.Forms.Label();
            this.txtLessonCode = new System.Windows.Forms.TextBox();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.txtSchoolYear = new System.Windows.Forms.TextBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtOfficialSchoolAbbreviation = new System.Windows.Forms.TextBox();
            this.lblSchoolCode = new System.Windows.Forms.Label();
            this.lblClassAbbreviation = new System.Windows.Forms.Label();
            this.lblSchoolSubject = new System.Windows.Forms.Label();
            this.txtLessonDate = new System.Windows.Forms.TextBox();
            this.txtPathImportImage = new System.Windows.Forms.TextBox();
            this.btnPathImportImage = new System.Windows.Forms.Button();
            this.lblFileImportName = new System.Windows.Forms.Label();
            this.txtFileImportImage = new System.Windows.Forms.TextBox();
            this.lblPathDatabase = new System.Windows.Forms.Label();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.rdbAutoRename = new System.Windows.Forms.RadioButton();
            this.rdbManualRename = new System.Windows.Forms.RadioButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnChooseFileImage = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.lblSubFolderStorage = new System.Windows.Forms.Label();
            this.txtSubFolderStorage = new System.Windows.Forms.TextBox();
            this.btnSubFolderStorage = new System.Windows.Forms.Button();
            this.chkMantainOldFileName = new System.Windows.Forms.CheckBox();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.grpPeriodOfQuestionsTopics = new System.Windows.Forms.GroupBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            this.dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            this.rdbAmongPeriod = new System.Windows.Forms.RadioButton();
            this.cmbSchoolPeriod = new System.Windows.Forms.ComboBox();
            this.BtnPreviousImage = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnFirstImage = new System.Windows.Forms.Button();
            this.BtnLastImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgwLessonsImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpPeriodOfQuestionsTopics.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgwLessonsImages
            // 
            this.DgwLessonsImages.AllowUserToAddRows = false;
            this.DgwLessonsImages.AllowUserToDeleteRows = false;
            this.DgwLessonsImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgwLessonsImages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.DgwLessonsImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgwLessonsImages.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgwLessonsImages.Location = new System.Drawing.Point(0, 0);
            this.DgwLessonsImages.Name = "DgwLessonsImages";
            this.DgwLessonsImages.Size = new System.Drawing.Size(1221, 90);
            this.DgwLessonsImages.TabIndex = 128;
            this.DgwLessonsImages.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwLessonsImages_CellClick);
            this.DgwLessonsImages.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwLessonsImages_CellContentClick);
            this.DgwLessonsImages.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwLessonsImages_RowEnter);
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(0, 3);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(1221, 282);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 129;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            this.picImage.DoubleClick += new System.EventHandler(this.picImage_DoubleClick);
            // 
            // txtLessonDesc
            // 
            this.txtLessonDesc.Location = new System.Drawing.Point(285, 79);
            this.txtLessonDesc.Name = "txtLessonDesc";
            this.txtLessonDesc.ReadOnly = true;
            this.txtLessonDesc.Size = new System.Drawing.Size(357, 24);
            this.txtLessonDesc.TabIndex = 142;
            // 
            // txtSchoolSubject
            // 
            this.txtSchoolSubject.Enabled = false;
            this.txtSchoolSubject.Location = new System.Drawing.Point(356, 30);
            this.txtSchoolSubject.Name = "txtSchoolSubject";
            this.txtSchoolSubject.ReadOnly = true;
            this.txtSchoolSubject.Size = new System.Drawing.Size(286, 24);
            this.txtSchoolSubject.TabIndex = 141;
            // 
            // lblLessonDesc
            // 
            this.lblLessonDesc.AutoSize = true;
            this.lblLessonDesc.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLessonDesc.Location = new System.Drawing.Point(282, 58);
            this.lblLessonDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLessonDesc.Name = "lblLessonDesc";
            this.lblLessonDesc.Size = new System.Drawing.Size(170, 18);
            this.lblLessonDesc.TabIndex = 140;
            this.lblLessonDesc.Text = "Annotazioni sulla lezione";
            // 
            // lblLessonDate
            // 
            this.lblLessonDate.AutoSize = true;
            this.lblLessonDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLessonDate.Location = new System.Drawing.Point(105, 58);
            this.lblLessonDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLessonDate.Name = "lblLessonDate";
            this.lblLessonDate.Size = new System.Drawing.Size(39, 18);
            this.lblLessonDate.TabIndex = 139;
            this.lblLessonDate.Text = "Data";
            // 
            // lblLessonCode
            // 
            this.lblLessonCode.AutoSize = true;
            this.lblLessonCode.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLessonCode.Location = new System.Drawing.Point(-1, 58);
            this.lblLessonCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLessonCode.Name = "lblLessonCode";
            this.lblLessonCode.Size = new System.Drawing.Size(92, 18);
            this.lblLessonCode.TabIndex = 138;
            this.lblLessonCode.Text = "Cod.Lezione";
            // 
            // txtLessonCode
            // 
            this.txtLessonCode.Enabled = false;
            this.txtLessonCode.Location = new System.Drawing.Point(2, 79);
            this.txtLessonCode.Name = "txtLessonCode";
            this.txtLessonCode.ReadOnly = true;
            this.txtLessonCode.Size = new System.Drawing.Size(100, 24);
            this.txtLessonCode.TabIndex = 137;
            this.txtLessonCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSchoolYear.Location = new System.Drawing.Point(141, 9);
            this.lblSchoolYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(84, 18);
            this.lblSchoolYear.TabIndex = 136;
            this.lblSchoolYear.Text = "Anno Scol. ";
            // 
            // txtSchoolYear
            // 
            this.txtSchoolYear.Enabled = false;
            this.txtSchoolYear.Location = new System.Drawing.Point(144, 30);
            this.txtSchoolYear.Name = "txtSchoolYear";
            this.txtSchoolYear.ReadOnly = true;
            this.txtSchoolYear.Size = new System.Drawing.Size(100, 24);
            this.txtSchoolYear.TabIndex = 135;
            // 
            // txtClass
            // 
            this.txtClass.Enabled = false;
            this.txtClass.Location = new System.Drawing.Point(250, 30);
            this.txtClass.Name = "txtClass";
            this.txtClass.ReadOnly = true;
            this.txtClass.Size = new System.Drawing.Size(100, 24);
            this.txtClass.TabIndex = 134;
            // 
            // txtOfficialSchoolAbbreviation
            // 
            this.txtOfficialSchoolAbbreviation.Enabled = false;
            this.txtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOfficialSchoolAbbreviation.Location = new System.Drawing.Point(2, 30);
            this.txtOfficialSchoolAbbreviation.Margin = new System.Windows.Forms.Padding(4);
            this.txtOfficialSchoolAbbreviation.Name = "txtOfficialSchoolAbbreviation";
            this.txtOfficialSchoolAbbreviation.ReadOnly = true;
            this.txtOfficialSchoolAbbreviation.Size = new System.Drawing.Size(135, 24);
            this.txtOfficialSchoolAbbreviation.TabIndex = 133;
            this.txtOfficialSchoolAbbreviation.Text = "FOIS01100L";
            // 
            // lblSchoolCode
            // 
            this.lblSchoolCode.AutoSize = true;
            this.lblSchoolCode.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSchoolCode.Location = new System.Drawing.Point(-1, 9);
            this.lblSchoolCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSchoolCode.Name = "lblSchoolCode";
            this.lblSchoolCode.Size = new System.Drawing.Size(105, 18);
            this.lblSchoolCode.TabIndex = 132;
            this.lblSchoolCode.Text = "Codice Scuola";
            // 
            // lblClassAbbreviation
            // 
            this.lblClassAbbreviation.AutoSize = true;
            this.lblClassAbbreviation.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblClassAbbreviation.Location = new System.Drawing.Point(247, 9);
            this.lblClassAbbreviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClassAbbreviation.Name = "lblClassAbbreviation";
            this.lblClassAbbreviation.Size = new System.Drawing.Size(90, 18);
            this.lblClassAbbreviation.TabIndex = 131;
            this.lblClassAbbreviation.Text = "Sigla Classe";
            // 
            // lblSchoolSubject
            // 
            this.lblSchoolSubject.AutoSize = true;
            this.lblSchoolSubject.Location = new System.Drawing.Point(353, 9);
            this.lblSchoolSubject.Name = "lblSchoolSubject";
            this.lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            this.lblSchoolSubject.TabIndex = 130;
            this.lblSchoolSubject.Text = "Materia";
            // 
            // txtLessonDate
            // 
            this.txtLessonDate.Location = new System.Drawing.Point(108, 79);
            this.txtLessonDate.Name = "txtLessonDate";
            this.txtLessonDate.ReadOnly = true;
            this.txtLessonDate.Size = new System.Drawing.Size(171, 24);
            this.txtLessonDate.TabIndex = 143;
            // 
            // txtPathImportImage
            // 
            this.txtPathImportImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPathImportImage.Location = new System.Drawing.Point(2, 130);
            this.txtPathImportImage.Margin = new System.Windows.Forms.Padding(4);
            this.txtPathImportImage.Name = "txtPathImportImage";
            this.txtPathImportImage.Size = new System.Drawing.Size(640, 24);
            this.txtPathImportImage.TabIndex = 146;
            this.txtPathImportImage.TextChanged += new System.EventHandler(this.txtPathImportImage_TextChanged);
            this.txtPathImportImage.DoubleClick += new System.EventHandler(this.txtPathImportImage_DoubleClick);
            // 
            // btnPathImportImage
            // 
            this.btnPathImportImage.BackColor = System.Drawing.Color.Transparent;
            this.btnPathImportImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPathImportImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnPathImportImage.Location = new System.Drawing.Point(652, 121);
            this.btnPathImportImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPathImportImage.Name = "btnPathImportImage";
            this.btnPathImportImage.Size = new System.Drawing.Size(54, 40);
            this.btnPathImportImage.TabIndex = 147;
            this.btnPathImportImage.Text = "..";
            this.btnPathImportImage.UseVisualStyleBackColor = false;
            this.btnPathImportImage.Click += new System.EventHandler(this.btnPathImportImage_Click);
            // 
            // lblFileImportName
            // 
            this.lblFileImportName.AutoSize = true;
            this.lblFileImportName.Location = new System.Drawing.Point(-1, 158);
            this.lblFileImportName.Name = "lblFileImportName";
            this.lblFileImportName.Size = new System.Drawing.Size(211, 18);
            this.lblFileImportName.TabIndex = 145;
            this.lblFileImportName.Text = "File dell\'immagine da importare";
            // 
            // txtFileImportImage
            // 
            this.txtFileImportImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFileImportImage.Location = new System.Drawing.Point(2, 179);
            this.txtFileImportImage.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileImportImage.Name = "txtFileImportImage";
            this.txtFileImportImage.Size = new System.Drawing.Size(344, 24);
            this.txtFileImportImage.TabIndex = 144;
            // 
            // lblPathDatabase
            // 
            this.lblPathDatabase.AutoSize = true;
            this.lblPathDatabase.Location = new System.Drawing.Point(-1, 108);
            this.lblPathDatabase.Name = "lblPathDatabase";
            this.lblPathDatabase.Size = new System.Drawing.Size(216, 18);
            this.lblPathDatabase.TabIndex = 148;
            this.lblPathDatabase.Text = "Cartella importazione immagine";
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.Color.Transparent;
            this.btnAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnAddImage.Location = new System.Drawing.Point(586, 165);
            this.btnAddImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(54, 40);
            this.btnAddImage.TabIndex = 149;
            this.btnAddImage.Text = "+";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // rdbAutoRename
            // 
            this.rdbAutoRename.AutoSize = true;
            this.rdbAutoRename.Checked = true;
            this.rdbAutoRename.Location = new System.Drawing.Point(420, 165);
            this.rdbAutoRename.Name = "rdbAutoRename";
            this.rdbAutoRename.Size = new System.Drawing.Size(167, 22);
            this.rdbAutoRename.TabIndex = 150;
            this.rdbAutoRename.TabStop = true;
            this.rdbAutoRename.Text = "Nome file automatico";
            this.rdbAutoRename.UseVisualStyleBackColor = true;
            this.rdbAutoRename.CheckedChanged += new System.EventHandler(this.rdbAutoRename_CheckedChanged);
            // 
            // rdbManualRename
            // 
            this.rdbManualRename.AutoSize = true;
            this.rdbManualRename.Location = new System.Drawing.Point(420, 183);
            this.rdbManualRename.Name = "rdbManualRename";
            this.rdbManualRename.Size = new System.Drawing.Size(137, 22);
            this.rdbManualRename.TabIndex = 151;
            this.rdbManualRename.Text = "Stesso nome file";
            this.rdbManualRename.UseVisualStyleBackColor = true;
            this.rdbManualRename.CheckedChanged += new System.EventHandler(this.rdbManualRename_CheckedChanged);
            // 
            // btnChooseFileImage
            // 
            this.btnChooseFileImage.BackColor = System.Drawing.Color.Transparent;
            this.btnChooseFileImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChooseFileImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnChooseFileImage.Location = new System.Drawing.Point(357, 165);
            this.btnChooseFileImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnChooseFileImage.Name = "btnChooseFileImage";
            this.btnChooseFileImage.Size = new System.Drawing.Size(54, 40);
            this.btnChooseFileImage.TabIndex = 152;
            this.btnChooseFileImage.Text = "..";
            this.btnChooseFileImage.UseVisualStyleBackColor = false;
            this.btnChooseFileImage.Click += new System.EventHandler(this.btnChooseFileImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtCaption
            // 
            this.txtCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCaption.Location = new System.Drawing.Point(0, 292);
            this.txtCaption.Margin = new System.Windows.Forms.Padding(4);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(1221, 24);
            this.txtCaption.TabIndex = 153;
            // 
            // lblSubFolderStorage
            // 
            this.lblSubFolderStorage.AutoSize = true;
            this.lblSubFolderStorage.Location = new System.Drawing.Point(713, 108);
            this.lblSubFolderStorage.Name = "lblSubFolderStorage";
            this.lblSubFolderStorage.Size = new System.Drawing.Size(274, 18);
            this.lblSubFolderStorage.TabIndex = 155;
            this.lblSubFolderStorage.Text = "Sottocartella memorizzazione immagine";
            this.lblSubFolderStorage.Visible = false;
            // 
            // txtSubFolderStorage
            // 
            this.txtSubFolderStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSubFolderStorage.Location = new System.Drawing.Point(716, 130);
            this.txtSubFolderStorage.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubFolderStorage.Name = "txtSubFolderStorage";
            this.txtSubFolderStorage.Size = new System.Drawing.Size(440, 24);
            this.txtSubFolderStorage.TabIndex = 154;
            this.txtSubFolderStorage.Visible = false;
            this.txtSubFolderStorage.TextChanged += new System.EventHandler(this.txtSubFolderStorage_TextChanged);
            this.txtSubFolderStorage.DoubleClick += new System.EventHandler(this.txtSubFolderStorage_DoubleClick);
            // 
            // btnSubFolderStorage
            // 
            this.btnSubFolderStorage.BackColor = System.Drawing.Color.Transparent;
            this.btnSubFolderStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSubFolderStorage.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSubFolderStorage.Location = new System.Drawing.Point(1166, 121);
            this.btnSubFolderStorage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSubFolderStorage.Name = "btnSubFolderStorage";
            this.btnSubFolderStorage.Size = new System.Drawing.Size(54, 40);
            this.btnSubFolderStorage.TabIndex = 156;
            this.btnSubFolderStorage.Text = "..";
            this.btnSubFolderStorage.UseVisualStyleBackColor = false;
            this.btnSubFolderStorage.Visible = false;
            this.btnSubFolderStorage.Click += new System.EventHandler(this.btnSubFolderStorage_Click);
            // 
            // chkMantainOldFileName
            // 
            this.chkMantainOldFileName.AutoSize = true;
            this.chkMantainOldFileName.Checked = true;
            this.chkMantainOldFileName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMantainOldFileName.Location = new System.Drawing.Point(883, 174);
            this.chkMantainOldFileName.Name = "chkMantainOldFileName";
            this.chkMantainOldFileName.Size = new System.Drawing.Size(207, 22);
            this.chkMantainOldFileName.TabIndex = 158;
            this.chkMantainOldFileName.Text = "conserva nome file vecchio";
            this.chkMantainOldFileName.UseVisualStyleBackColor = true;
            this.chkMantainOldFileName.Visible = false;
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRemoveImage.Location = new System.Drawing.Point(652, 165);
            this.btnRemoveImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(54, 40);
            this.btnRemoveImage.TabIndex = 159;
            this.btnRemoveImage.Text = "-";
            this.btnRemoveImage.UseVisualStyleBackColor = false;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSave.Location = new System.Drawing.Point(652, 71);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 40);
            this.btnSave.TabIndex = 160;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 215);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DgwLessonsImages);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.picImage);
            this.splitContainer1.Panel2.Controls.Add(this.txtCaption);
            this.splitContainer1.Size = new System.Drawing.Size(1221, 417);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 161;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(651, 24);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(26, 34);
            this.btnPrevious.TabIndex = 163;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(680, 24);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(26, 34);
            this.btnNext.TabIndex = 162;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // grpPeriodOfQuestionsTopics
            // 
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.lblEnd);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.lblStart);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.dtpEndPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.dtpStartPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.rdbAmongPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.cmbSchoolPeriod);
            this.grpPeriodOfQuestionsTopics.Location = new System.Drawing.Point(716, 12);
            this.grpPeriodOfQuestionsTopics.Name = "grpPeriodOfQuestionsTopics";
            this.grpPeriodOfQuestionsTopics.Size = new System.Drawing.Size(356, 95);
            this.grpPeriodOfQuestionsTopics.TabIndex = 164;
            this.grpPeriodOfQuestionsTopics.TabStop = false;
            this.grpPeriodOfQuestionsTopics.Text = "Periodo delle lezioni";
            this.grpPeriodOfQuestionsTopics.Enter += new System.EventHandler(this.grpPeriodOfQuestionsTopics_Enter);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(188, 24);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(36, 18);
            this.lblEnd.TabIndex = 157;
            this.lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(6, 24);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(42, 18);
            this.lblStart.TabIndex = 156;
            this.lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            this.dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            this.dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndPeriod.Location = new System.Drawing.Point(230, 22);
            this.dtpEndPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtpEndPeriod.Name = "dtpEndPeriod";
            this.dtpEndPeriod.Size = new System.Drawing.Size(111, 24);
            this.dtpEndPeriod.TabIndex = 155;
            this.dtpEndPeriod.Value = new System.DateTime(2019, 6, 7, 0, 0, 0, 0);
            // 
            // dtpStartPeriod
            // 
            this.dtpStartPeriod.CustomFormat = "yyyy-MM-dd";
            this.dtpStartPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartPeriod.Location = new System.Drawing.Point(54, 21);
            this.dtpStartPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtpStartPeriod.Name = "dtpStartPeriod";
            this.dtpStartPeriod.Size = new System.Drawing.Size(111, 24);
            this.dtpStartPeriod.TabIndex = 154;
            this.dtpStartPeriod.Value = new System.DateTime(2019, 1, 24, 0, 0, 0, 0);
            // 
            // rdbAmongPeriod
            // 
            this.rdbAmongPeriod.AutoSize = true;
            this.rdbAmongPeriod.Enabled = false;
            this.rdbAmongPeriod.Location = new System.Drawing.Point(6, 56);
            this.rdbAmongPeriod.Name = "rdbAmongPeriod";
            this.rdbAmongPeriod.Size = new System.Drawing.Size(91, 22);
            this.rdbAmongPeriod.TabIndex = 2;
            this.rdbAmongPeriod.Text = "in periodo";
            this.rdbAmongPeriod.UseVisualStyleBackColor = true;
            this.rdbAmongPeriod.Visible = false;
            // 
            // cmbSchoolPeriod
            // 
            this.cmbSchoolPeriod.FormattingEnabled = true;
            this.cmbSchoolPeriod.Items.AddRange(new object[] {
            "",
            "Settimana",
            "Mese",
            "Anno scolastico",
            "Da nuovo anno solare"});
            this.cmbSchoolPeriod.Location = new System.Drawing.Point(123, 55);
            this.cmbSchoolPeriod.Name = "cmbSchoolPeriod";
            this.cmbSchoolPeriod.Size = new System.Drawing.Size(218, 26);
            this.cmbSchoolPeriod.TabIndex = 153;
            // 
            // BtnPreviousImage
            // 
            this.BtnPreviousImage.Location = new System.Drawing.Point(757, 168);
            this.BtnPreviousImage.Name = "BtnPreviousImage";
            this.BtnPreviousImage.Size = new System.Drawing.Size(36, 34);
            this.BtnPreviousImage.TabIndex = 166;
            this.BtnPreviousImage.Text = "<";
            this.BtnPreviousImage.UseVisualStyleBackColor = true;
            this.BtnPreviousImage.Click += new System.EventHandler(this.BtnPreviousImage_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(799, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 34);
            this.button2.TabIndex = 165;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnNextImage_Click);
            // 
            // BtnFirstImage
            // 
            this.BtnFirstImage.Location = new System.Drawing.Point(715, 168);
            this.BtnFirstImage.Name = "BtnFirstImage";
            this.BtnFirstImage.Size = new System.Drawing.Size(36, 34);
            this.BtnFirstImage.TabIndex = 168;
            this.BtnFirstImage.Text = "<<";
            this.BtnFirstImage.UseVisualStyleBackColor = true;
            this.BtnFirstImage.Click += new System.EventHandler(this.BtnFirstImage_Click);
            // 
            // BtnLastImage
            // 
            this.BtnLastImage.Location = new System.Drawing.Point(841, 168);
            this.BtnLastImage.Name = "BtnLastImage";
            this.BtnLastImage.Size = new System.Drawing.Size(36, 34);
            this.BtnLastImage.TabIndex = 167;
            this.BtnLastImage.Text = ">>";
            this.BtnLastImage.UseVisualStyleBackColor = true;
            this.BtnLastImage.Click += new System.EventHandler(this.BtnLastImage_Click);
            // 
            // frmImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1226, 632);
            this.Controls.Add(this.BtnFirstImage);
            this.Controls.Add(this.BtnLastImage);
            this.Controls.Add(this.BtnPreviousImage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.grpPeriodOfQuestionsTopics);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemoveImage);
            this.Controls.Add(this.chkMantainOldFileName);
            this.Controls.Add(this.btnSubFolderStorage);
            this.Controls.Add(this.lblSubFolderStorage);
            this.Controls.Add(this.txtSubFolderStorage);
            this.Controls.Add(this.btnChooseFileImage);
            this.Controls.Add(this.rdbManualRename);
            this.Controls.Add(this.rdbAutoRename);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.lblPathDatabase);
            this.Controls.Add(this.txtPathImportImage);
            this.Controls.Add(this.btnPathImportImage);
            this.Controls.Add(this.lblFileImportName);
            this.Controls.Add(this.txtFileImportImage);
            this.Controls.Add(this.txtLessonDate);
            this.Controls.Add(this.txtLessonDesc);
            this.Controls.Add(this.txtSchoolSubject);
            this.Controls.Add(this.lblLessonDesc);
            this.Controls.Add(this.lblLessonDate);
            this.Controls.Add(this.lblLessonCode);
            this.Controls.Add(this.txtLessonCode);
            this.Controls.Add(this.lblSchoolYear);
            this.Controls.Add(this.txtSchoolYear);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.txtOfficialSchoolAbbreviation);
            this.Controls.Add(this.lblSchoolCode);
            this.Controls.Add(this.lblClassAbbreviation);
            this.Controls.Add(this.lblSchoolSubject);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmImages";
            this.Text = "Immagini";
            this.Load += new System.EventHandler(this.frmImages_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmImages_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DgwLessonsImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpPeriodOfQuestionsTopics.ResumeLayout(false);
            this.grpPeriodOfQuestionsTopics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgwLessonsImages;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.TextBox txtLessonDesc;
        private System.Windows.Forms.TextBox txtSchoolSubject;
        private System.Windows.Forms.Label lblLessonDesc;
        private System.Windows.Forms.Label lblLessonDate;
        private System.Windows.Forms.Label lblLessonCode;
        private System.Windows.Forms.TextBox txtLessonCode;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.TextBox txtSchoolYear;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.TextBox txtOfficialSchoolAbbreviation;
        private System.Windows.Forms.Label lblSchoolCode;
        private System.Windows.Forms.Label lblClassAbbreviation;
        private System.Windows.Forms.Label lblSchoolSubject;
        private System.Windows.Forms.TextBox txtLessonDate;
        private System.Windows.Forms.TextBox txtPathImportImage;
        private System.Windows.Forms.Button btnPathImportImage;
        private System.Windows.Forms.Label lblFileImportName;
        private System.Windows.Forms.TextBox txtFileImportImage;
        private System.Windows.Forms.Label lblPathDatabase;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.RadioButton rdbAutoRename;
        private System.Windows.Forms.RadioButton rdbManualRename;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnChooseFileImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.Label lblSubFolderStorage;
        private System.Windows.Forms.TextBox txtSubFolderStorage;
        private System.Windows.Forms.Button btnSubFolderStorage;
        private System.Windows.Forms.CheckBox chkMantainOldFileName;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox grpPeriodOfQuestionsTopics;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpEndPeriod;
        private System.Windows.Forms.DateTimePicker dtpStartPeriod;
        private System.Windows.Forms.RadioButton rdbAmongPeriod;
        private System.Windows.Forms.ComboBox cmbSchoolPeriod;
        private System.Windows.Forms.Button BtnPreviousImage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnFirstImage;
        private System.Windows.Forms.Button BtnLastImage;
    }
}