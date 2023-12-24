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
            dgwLessonsImages = new System.Windows.Forms.DataGridView();
            picImage = new System.Windows.Forms.PictureBox();
            txtLessonDesc = new System.Windows.Forms.TextBox();
            txtSchoolSubject = new System.Windows.Forms.TextBox();
            lblLessonDesc = new System.Windows.Forms.Label();
            lblLessonDate = new System.Windows.Forms.Label();
            lblLessonCode = new System.Windows.Forms.Label();
            txtLessonCode = new System.Windows.Forms.TextBox();
            lblSchoolYear = new System.Windows.Forms.Label();
            txtSchoolYear = new System.Windows.Forms.TextBox();
            txtClass = new System.Windows.Forms.TextBox();
            txtOfficialSchoolAbbreviation = new System.Windows.Forms.TextBox();
            lblSchoolCode = new System.Windows.Forms.Label();
            lblClassAbbreviation = new System.Windows.Forms.Label();
            lblSchoolSubject = new System.Windows.Forms.Label();
            txtLessonDate = new System.Windows.Forms.TextBox();
            txtPathImportImage = new System.Windows.Forms.TextBox();
            btnPathImportImage = new System.Windows.Forms.Button();
            lblFileImportName = new System.Windows.Forms.Label();
            txtFileImportImage = new System.Windows.Forms.TextBox();
            lblPathDatabase = new System.Windows.Forms.Label();
            btnAddImage = new System.Windows.Forms.Button();
            rdbAutoRename = new System.Windows.Forms.RadioButton();
            rdbManualRename = new System.Windows.Forms.RadioButton();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            btnChooseFileImage = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            txtCaption = new System.Windows.Forms.TextBox();
            lblSubFolderStorage = new System.Windows.Forms.Label();
            txtSubFolderStorage = new System.Windows.Forms.TextBox();
            btnSubFolderStorage = new System.Windows.Forms.Button();
            chkMantainOldFileName = new System.Windows.Forms.CheckBox();
            btnRemoveImage = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            btnPrevious = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            btnPreviousImage = new System.Windows.Forms.Button();
            btnNextImage = new System.Windows.Forms.Button();
            btnFirstImage = new System.Windows.Forms.Button();
            btnLastImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgwLessonsImages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // dgwLessonsImages
            // 
            dgwLessonsImages.AllowUserToAddRows = false;
            dgwLessonsImages.AllowUserToDeleteRows = false;
            dgwLessonsImages.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwLessonsImages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwLessonsImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwLessonsImages.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgwLessonsImages.Location = new System.Drawing.Point(0, 0);
            dgwLessonsImages.MultiSelect = false;
            dgwLessonsImages.Name = "dgwLessonsImages";
            dgwLessonsImages.ReadOnly = true;
            dgwLessonsImages.Size = new System.Drawing.Size(1221, 90);
            dgwLessonsImages.TabIndex = 128;
            dgwLessonsImages.CellClick += dgwLessonsImages_CellClick;
            dgwLessonsImages.CellContentClick += dgwLessonsImages_CellContentClick;
            dgwLessonsImages.CellDoubleClick += dgwLessonsImages_CellDoubleClick;
            dgwLessonsImages.RowEnter += dgwLessonsImages_RowEnter;
            // 
            // picImage
            // 
            picImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picImage.Location = new System.Drawing.Point(0, 3);
            picImage.Name = "picImage";
            picImage.Size = new System.Drawing.Size(1221, 282);
            picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picImage.TabIndex = 129;
            picImage.TabStop = false;
            picImage.Click += picImage_Click;
            picImage.DoubleClick += picImage_DoubleClick;
            // 
            // txtLessonDesc
            // 
            txtLessonDesc.Location = new System.Drawing.Point(285, 79);
            txtLessonDesc.Name = "txtLessonDesc";
            txtLessonDesc.ReadOnly = true;
            txtLessonDesc.Size = new System.Drawing.Size(357, 24);
            txtLessonDesc.TabIndex = 142;
            // 
            // txtSchoolSubject
            // 
            txtSchoolSubject.Enabled = false;
            txtSchoolSubject.Location = new System.Drawing.Point(356, 30);
            txtSchoolSubject.Name = "txtSchoolSubject";
            txtSchoolSubject.ReadOnly = true;
            txtSchoolSubject.Size = new System.Drawing.Size(286, 24);
            txtSchoolSubject.TabIndex = 141;
            // 
            // lblLessonDesc
            // 
            lblLessonDesc.AutoSize = true;
            lblLessonDesc.ForeColor = System.Drawing.Color.DarkBlue;
            lblLessonDesc.Location = new System.Drawing.Point(282, 58);
            lblLessonDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLessonDesc.Name = "lblLessonDesc";
            lblLessonDesc.Size = new System.Drawing.Size(170, 18);
            lblLessonDesc.TabIndex = 140;
            lblLessonDesc.Text = "Annotazioni sulla lezione";
            // 
            // lblLessonDate
            // 
            lblLessonDate.AutoSize = true;
            lblLessonDate.ForeColor = System.Drawing.Color.DarkBlue;
            lblLessonDate.Location = new System.Drawing.Point(105, 58);
            lblLessonDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLessonDate.Name = "lblLessonDate";
            lblLessonDate.Size = new System.Drawing.Size(39, 18);
            lblLessonDate.TabIndex = 139;
            lblLessonDate.Text = "Data";
            // 
            // lblLessonCode
            // 
            lblLessonCode.AutoSize = true;
            lblLessonCode.ForeColor = System.Drawing.Color.DarkBlue;
            lblLessonCode.Location = new System.Drawing.Point(-1, 58);
            lblLessonCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLessonCode.Name = "lblLessonCode";
            lblLessonCode.Size = new System.Drawing.Size(92, 18);
            lblLessonCode.TabIndex = 138;
            lblLessonCode.Text = "Cod.Lezione";
            // 
            // txtLessonCode
            // 
            txtLessonCode.Enabled = false;
            txtLessonCode.Location = new System.Drawing.Point(2, 79);
            txtLessonCode.Name = "txtLessonCode";
            txtLessonCode.ReadOnly = true;
            txtLessonCode.Size = new System.Drawing.Size(100, 24);
            txtLessonCode.TabIndex = 137;
            txtLessonCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSchoolYear
            // 
            lblSchoolYear.AutoSize = true;
            lblSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            lblSchoolYear.Location = new System.Drawing.Point(141, 9);
            lblSchoolYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSchoolYear.Name = "lblSchoolYear";
            lblSchoolYear.Size = new System.Drawing.Size(84, 18);
            lblSchoolYear.TabIndex = 136;
            lblSchoolYear.Text = "Anno Scol. ";
            // 
            // txtSchoolYear
            // 
            txtSchoolYear.Enabled = false;
            txtSchoolYear.Location = new System.Drawing.Point(144, 30);
            txtSchoolYear.Name = "txtSchoolYear";
            txtSchoolYear.ReadOnly = true;
            txtSchoolYear.Size = new System.Drawing.Size(100, 24);
            txtSchoolYear.TabIndex = 135;
            // 
            // txtClass
            // 
            txtClass.Enabled = false;
            txtClass.Location = new System.Drawing.Point(250, 30);
            txtClass.Name = "txtClass";
            txtClass.ReadOnly = true;
            txtClass.Size = new System.Drawing.Size(100, 24);
            txtClass.TabIndex = 134;
            // 
            // txtOfficialSchoolAbbreviation
            // 
            txtOfficialSchoolAbbreviation.Enabled = false;
            txtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtOfficialSchoolAbbreviation.Location = new System.Drawing.Point(2, 30);
            txtOfficialSchoolAbbreviation.Margin = new System.Windows.Forms.Padding(4);
            txtOfficialSchoolAbbreviation.Name = "txtOfficialSchoolAbbreviation";
            txtOfficialSchoolAbbreviation.ReadOnly = true;
            txtOfficialSchoolAbbreviation.Size = new System.Drawing.Size(135, 24);
            txtOfficialSchoolAbbreviation.TabIndex = 133;
            txtOfficialSchoolAbbreviation.Text = "FOIS01100L";
            // 
            // lblSchoolCode
            // 
            lblSchoolCode.AutoSize = true;
            lblSchoolCode.ForeColor = System.Drawing.Color.DarkBlue;
            lblSchoolCode.Location = new System.Drawing.Point(-1, 9);
            lblSchoolCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSchoolCode.Name = "lblSchoolCode";
            lblSchoolCode.Size = new System.Drawing.Size(105, 18);
            lblSchoolCode.TabIndex = 132;
            lblSchoolCode.Text = "Codice Scuola";
            // 
            // lblClassAbbreviation
            // 
            lblClassAbbreviation.AutoSize = true;
            lblClassAbbreviation.ForeColor = System.Drawing.Color.DarkBlue;
            lblClassAbbreviation.Location = new System.Drawing.Point(247, 9);
            lblClassAbbreviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblClassAbbreviation.Name = "lblClassAbbreviation";
            lblClassAbbreviation.Size = new System.Drawing.Size(90, 18);
            lblClassAbbreviation.TabIndex = 131;
            lblClassAbbreviation.Text = "Sigla Classe";
            // 
            // lblSchoolSubject
            // 
            lblSchoolSubject.AutoSize = true;
            lblSchoolSubject.Location = new System.Drawing.Point(353, 9);
            lblSchoolSubject.Name = "lblSchoolSubject";
            lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            lblSchoolSubject.TabIndex = 130;
            lblSchoolSubject.Text = "Materia";
            // 
            // txtLessonDate
            // 
            txtLessonDate.Location = new System.Drawing.Point(108, 79);
            txtLessonDate.Name = "txtLessonDate";
            txtLessonDate.ReadOnly = true;
            txtLessonDate.Size = new System.Drawing.Size(171, 24);
            txtLessonDate.TabIndex = 143;
            // 
            // txtPathImportImage
            // 
            txtPathImportImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtPathImportImage.Location = new System.Drawing.Point(2, 130);
            txtPathImportImage.Margin = new System.Windows.Forms.Padding(4);
            txtPathImportImage.Name = "txtPathImportImage";
            txtPathImportImage.Size = new System.Drawing.Size(640, 24);
            txtPathImportImage.TabIndex = 146;
            txtPathImportImage.TextChanged += txtPathImportImage_TextChanged;
            txtPathImportImage.DoubleClick += txtPathImportImage_DoubleClick;
            // 
            // btnPathImportImage
            // 
            btnPathImportImage.BackColor = System.Drawing.Color.Transparent;
            btnPathImportImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPathImportImage.ForeColor = System.Drawing.Color.DarkBlue;
            btnPathImportImage.Location = new System.Drawing.Point(652, 121);
            btnPathImportImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnPathImportImage.Name = "btnPathImportImage";
            btnPathImportImage.Size = new System.Drawing.Size(54, 40);
            btnPathImportImage.TabIndex = 147;
            btnPathImportImage.Text = "..";
            btnPathImportImage.UseVisualStyleBackColor = false;
            btnPathImportImage.Click += btnPathImportImage_Click;
            // 
            // lblFileImportName
            // 
            lblFileImportName.AutoSize = true;
            lblFileImportName.Location = new System.Drawing.Point(-1, 158);
            lblFileImportName.Name = "lblFileImportName";
            lblFileImportName.Size = new System.Drawing.Size(326, 18);
            lblFileImportName.TabIndex = 145;
            lblFileImportName.Text = "File dell'immagine o del documento da importare";
            // 
            // txtFileImportImage
            // 
            txtFileImportImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtFileImportImage.Location = new System.Drawing.Point(2, 179);
            txtFileImportImage.Margin = new System.Windows.Forms.Padding(4);
            txtFileImportImage.Name = "txtFileImportImage";
            txtFileImportImage.Size = new System.Drawing.Size(344, 24);
            txtFileImportImage.TabIndex = 144;
            // 
            // lblPathDatabase
            // 
            lblPathDatabase.AutoSize = true;
            lblPathDatabase.Location = new System.Drawing.Point(-1, 108);
            lblPathDatabase.Name = "lblPathDatabase";
            lblPathDatabase.Size = new System.Drawing.Size(323, 18);
            lblPathDatabase.TabIndex = 148;
            lblPathDatabase.Text = "Cartella importazione di immagine o documento";
            // 
            // btnAddImage
            // 
            btnAddImage.BackColor = System.Drawing.Color.Transparent;
            btnAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnAddImage.ForeColor = System.Drawing.Color.DarkBlue;
            btnAddImage.Location = new System.Drawing.Point(586, 165);
            btnAddImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new System.Drawing.Size(54, 40);
            btnAddImage.TabIndex = 149;
            btnAddImage.Text = "+";
            btnAddImage.UseVisualStyleBackColor = false;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // rdbAutoRename
            // 
            rdbAutoRename.AutoSize = true;
            rdbAutoRename.Checked = true;
            rdbAutoRename.Location = new System.Drawing.Point(420, 165);
            rdbAutoRename.Name = "rdbAutoRename";
            rdbAutoRename.Size = new System.Drawing.Size(167, 22);
            rdbAutoRename.TabIndex = 150;
            rdbAutoRename.TabStop = true;
            rdbAutoRename.Text = "Nome file automatico";
            rdbAutoRename.UseVisualStyleBackColor = true;
            rdbAutoRename.CheckedChanged += rdbAutoRename_CheckedChanged;
            // 
            // rdbManualRename
            // 
            rdbManualRename.AutoSize = true;
            rdbManualRename.Location = new System.Drawing.Point(420, 183);
            rdbManualRename.Name = "rdbManualRename";
            rdbManualRename.Size = new System.Drawing.Size(137, 22);
            rdbManualRename.TabIndex = 151;
            rdbManualRename.Text = "Stesso nome file";
            rdbManualRename.UseVisualStyleBackColor = true;
            rdbManualRename.CheckedChanged += rdbManualRename_CheckedChanged;
            // 
            // btnChooseFileImage
            // 
            btnChooseFileImage.BackColor = System.Drawing.Color.Transparent;
            btnChooseFileImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnChooseFileImage.ForeColor = System.Drawing.Color.DarkBlue;
            btnChooseFileImage.Location = new System.Drawing.Point(357, 165);
            btnChooseFileImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnChooseFileImage.Name = "btnChooseFileImage";
            btnChooseFileImage.Size = new System.Drawing.Size(54, 40);
            btnChooseFileImage.TabIndex = 152;
            btnChooseFileImage.Text = "..";
            btnChooseFileImage.UseVisualStyleBackColor = false;
            btnChooseFileImage.Click += btnChooseFileImage_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtCaption
            // 
            txtCaption.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtCaption.Location = new System.Drawing.Point(0, 292);
            txtCaption.Margin = new System.Windows.Forms.Padding(4);
            txtCaption.Name = "txtCaption";
            txtCaption.Size = new System.Drawing.Size(1221, 24);
            txtCaption.TabIndex = 153;
            // 
            // lblSubFolderStorage
            // 
            lblSubFolderStorage.AutoSize = true;
            lblSubFolderStorage.Location = new System.Drawing.Point(713, 108);
            lblSubFolderStorage.Name = "lblSubFolderStorage";
            lblSubFolderStorage.Size = new System.Drawing.Size(274, 18);
            lblSubFolderStorage.TabIndex = 155;
            lblSubFolderStorage.Text = "Sottocartella memorizzazione immagine";
            lblSubFolderStorage.Visible = false;
            // 
            // txtSubFolderStorage
            // 
            txtSubFolderStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSubFolderStorage.Location = new System.Drawing.Point(716, 130);
            txtSubFolderStorage.Margin = new System.Windows.Forms.Padding(4);
            txtSubFolderStorage.Name = "txtSubFolderStorage";
            txtSubFolderStorage.Size = new System.Drawing.Size(440, 24);
            txtSubFolderStorage.TabIndex = 154;
            txtSubFolderStorage.Visible = false;
            txtSubFolderStorage.TextChanged += txtSubFolderStorage_TextChanged;
            txtSubFolderStorage.DoubleClick += txtSubFolderStorage_DoubleClick;
            // 
            // btnSubFolderStorage
            // 
            btnSubFolderStorage.BackColor = System.Drawing.Color.Transparent;
            btnSubFolderStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSubFolderStorage.ForeColor = System.Drawing.Color.DarkBlue;
            btnSubFolderStorage.Location = new System.Drawing.Point(1166, 121);
            btnSubFolderStorage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnSubFolderStorage.Name = "btnSubFolderStorage";
            btnSubFolderStorage.Size = new System.Drawing.Size(54, 40);
            btnSubFolderStorage.TabIndex = 156;
            btnSubFolderStorage.Text = "..";
            btnSubFolderStorage.UseVisualStyleBackColor = false;
            btnSubFolderStorage.Visible = false;
            btnSubFolderStorage.Click += btnSubFolderStorage_Click;
            // 
            // chkMantainOldFileName
            // 
            chkMantainOldFileName.AutoSize = true;
            chkMantainOldFileName.Checked = true;
            chkMantainOldFileName.CheckState = System.Windows.Forms.CheckState.Checked;
            chkMantainOldFileName.Location = new System.Drawing.Point(883, 174);
            chkMantainOldFileName.Name = "chkMantainOldFileName";
            chkMantainOldFileName.Size = new System.Drawing.Size(207, 22);
            chkMantainOldFileName.TabIndex = 158;
            chkMantainOldFileName.Text = "conserva nome file vecchio";
            chkMantainOldFileName.UseVisualStyleBackColor = true;
            chkMantainOldFileName.Visible = false;
            // 
            // btnRemoveImage
            // 
            btnRemoveImage.BackColor = System.Drawing.Color.Transparent;
            btnRemoveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnRemoveImage.ForeColor = System.Drawing.Color.DarkBlue;
            btnRemoveImage.Location = new System.Drawing.Point(652, 165);
            btnRemoveImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnRemoveImage.Name = "btnRemoveImage";
            btnRemoveImage.Size = new System.Drawing.Size(54, 40);
            btnRemoveImage.TabIndex = 159;
            btnRemoveImage.Text = "-";
            btnRemoveImage.UseVisualStyleBackColor = false;
            btnRemoveImage.Click += btnRemoveImage_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.Transparent;
            btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSave.ForeColor = System.Drawing.Color.DarkBlue;
            btnSave.Location = new System.Drawing.Point(652, 71);
            btnSave.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(54, 40);
            btnSave.TabIndex = 160;
            btnSave.Text = "Salva";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splitContainer1.Location = new System.Drawing.Point(0, 215);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgwLessonsImages);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(picImage);
            splitContainer1.Panel2.Controls.Add(txtCaption);
            splitContainer1.Size = new System.Drawing.Size(1221, 417);
            splitContainer1.SplitterDistance = 93;
            splitContainer1.TabIndex = 161;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new System.Drawing.Point(651, 24);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new System.Drawing.Size(26, 34);
            btnPrevious.TabIndex = 163;
            btnPrevious.Text = "<";
            btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new System.Drawing.Point(680, 24);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(26, 34);
            btnNext.TabIndex = 162;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPreviousImage
            // 
            btnPreviousImage.Location = new System.Drawing.Point(757, 168);
            btnPreviousImage.Name = "btnPreviousImage";
            btnPreviousImage.Size = new System.Drawing.Size(36, 34);
            btnPreviousImage.TabIndex = 166;
            btnPreviousImage.Text = "<";
            btnPreviousImage.UseVisualStyleBackColor = true;
            btnPreviousImage.Click += btnPreviousImage_Click;
            // 
            // btnNextImage
            // 
            btnNextImage.Location = new System.Drawing.Point(799, 168);
            btnNextImage.Name = "btnNextImage";
            btnNextImage.Size = new System.Drawing.Size(36, 34);
            btnNextImage.TabIndex = 165;
            btnNextImage.Text = ">";
            btnNextImage.UseVisualStyleBackColor = true;
            btnNextImage.Click += btnNextImage_Click;
            // 
            // btnFirstImage
            // 
            btnFirstImage.Location = new System.Drawing.Point(715, 168);
            btnFirstImage.Name = "btnFirstImage";
            btnFirstImage.Size = new System.Drawing.Size(36, 34);
            btnFirstImage.TabIndex = 168;
            btnFirstImage.Text = "<<";
            btnFirstImage.UseVisualStyleBackColor = true;
            btnFirstImage.Click += btnFirstImage_Click;
            // 
            // btnLastImage
            // 
            btnLastImage.Location = new System.Drawing.Point(841, 168);
            btnLastImage.Name = "btnLastImage";
            btnLastImage.Size = new System.Drawing.Size(36, 34);
            btnLastImage.TabIndex = 167;
            btnLastImage.Text = ">>";
            btnLastImage.UseVisualStyleBackColor = true;
            btnLastImage.Click += btnLastImage_Click;
            // 
            // frmImages
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(1226, 632);
            Controls.Add(btnFirstImage);
            Controls.Add(btnLastImage);
            Controls.Add(btnPreviousImage);
            Controls.Add(btnNextImage);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(splitContainer1);
            Controls.Add(btnSave);
            Controls.Add(btnRemoveImage);
            Controls.Add(chkMantainOldFileName);
            Controls.Add(btnSubFolderStorage);
            Controls.Add(lblSubFolderStorage);
            Controls.Add(txtSubFolderStorage);
            Controls.Add(btnChooseFileImage);
            Controls.Add(rdbManualRename);
            Controls.Add(rdbAutoRename);
            Controls.Add(btnAddImage);
            Controls.Add(lblPathDatabase);
            Controls.Add(txtPathImportImage);
            Controls.Add(btnPathImportImage);
            Controls.Add(lblFileImportName);
            Controls.Add(txtFileImportImage);
            Controls.Add(txtLessonDate);
            Controls.Add(txtLessonDesc);
            Controls.Add(txtSchoolSubject);
            Controls.Add(lblLessonDesc);
            Controls.Add(lblLessonDate);
            Controls.Add(lblLessonCode);
            Controls.Add(txtLessonCode);
            Controls.Add(lblSchoolYear);
            Controls.Add(txtSchoolYear);
            Controls.Add(txtClass);
            Controls.Add(txtOfficialSchoolAbbreviation);
            Controls.Add(lblSchoolCode);
            Controls.Add(lblClassAbbreviation);
            Controls.Add(lblSchoolSubject);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmImages";
            Text = "Immagini";
            Load += frmImages_Load;
            KeyDown += frmImages_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgwLessonsImages).EndInit();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgwLessonsImages;
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
        private System.Windows.Forms.Button btnPreviousImage;
        private System.Windows.Forms.Button btnNextImage;
        private System.Windows.Forms.Button btnFirstImage;
        private System.Windows.Forms.Button btnLastImage;
    }
}