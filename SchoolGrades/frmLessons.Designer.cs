namespace SchoolGrades
{
    partial class frmLessons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLessons));
            lblSchoolSubject = new System.Windows.Forms.Label();
            txtOfficialSchoolAbbreviation = new System.Windows.Forms.TextBox();
            lblSchoolCode = new System.Windows.Forms.Label();
            lblClassAbbreviation = new System.Windows.Forms.Label();
            txtClass = new System.Windows.Forms.TextBox();
            txtSchoolYear = new System.Windows.Forms.TextBox();
            lblSchoolYear = new System.Windows.Forms.Label();
            lblLessonCode = new System.Windows.Forms.Label();
            txtLessonCode = new System.Windows.Forms.TextBox();
            lblLessonDate = new System.Windows.Forms.Label();
            lblLessonDesc = new System.Windows.Forms.Label();
            grpViewTopics = new System.Windows.Forms.GroupBox();
            rdbNotDone = new System.Windows.Forms.RadioButton();
            rdbAlreadyDone = new System.Windows.Forms.RadioButton();
            rdbLesson = new System.Windows.Forms.RadioButton();
            dgwOneLesson = new System.Windows.Forms.DataGridView();
            txtSchoolSubject = new System.Windows.Forms.TextBox();
            btnFind = new System.Windows.Forms.Button();
            lblFind = new System.Windows.Forms.Label();
            txtTopicSearchString = new System.Windows.Forms.TextBox();
            btnDelete = new System.Windows.Forms.Button();
            txtTopicName = new System.Windows.Forms.TextBox();
            btnAddNodeSon = new System.Windows.Forms.Button();
            btnSaveTree = new System.Windows.Forms.Button();
            TxtLessonDesc = new System.Windows.Forms.TextBox();
            dtpLessonDate = new System.Windows.Forms.DateTimePicker();
            dgwAllLessons = new System.Windows.Forms.DataGridView();
            txtTopicsDigest = new System.Windows.Forms.TextBox();
            btnCopyNoteToClipboard = new System.Windows.Forms.Button();
            btnStartLinks = new System.Windows.Forms.Button();
            txtTopicDescription = new System.Windows.Forms.TextBox();
            picImage = new System.Windows.Forms.PictureBox();
            btnManageImages = new System.Windows.Forms.Button();
            splitContainerBigVertical = new System.Windows.Forms.SplitContainer();
            splitContainerLeftHorizontal = new System.Windows.Forms.SplitContainer();
            splitContainerRightHorizontal = new System.Windows.Forms.SplitContainer();
            trwTopics = new System.Windows.Forms.TreeView();
            lblExplain = new System.Windows.Forms.Label();
            btnTopicsDone = new System.Windows.Forms.Button();
            bntLessonErase = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            btnPrevious = new System.Windows.Forms.Button();
            btnArgFreemind = new System.Windows.Forms.Button();
            lblLessonTime = new System.Windows.Forms.Label();
            LessonTimer = new System.Windows.Forms.Timer(components);
            btnLessonSave = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            BtnOpenImagesFolder = new System.Windows.Forms.Button();
            rdbStringSearch = new System.Windows.Forms.RadioButton();
            rdbAndSearch = new System.Windows.Forms.RadioButton();
            rdbOrSearch = new System.Windows.Forms.RadioButton();
            btnFindUnderNode = new System.Windows.Forms.Button();
            chkCaseInsensitive = new System.Windows.Forms.CheckBox();
            chkMarkAllTopicsFound = new System.Windows.Forms.CheckBox();
            btnAddNodeBrother = new System.Windows.Forms.Button();
            chkAllWord = new System.Windows.Forms.CheckBox();
            chkSearchInDescriptions = new System.Windows.Forms.CheckBox();
            BtnSearchAmongTopics = new System.Windows.Forms.Button();
            btnExport = new System.Windows.Forms.Button();
            btnLessonAdd = new System.Windows.Forms.Button();
            grpViewTopics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwOneLesson).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgwAllLessons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerBigVertical).BeginInit();
            splitContainerBigVertical.Panel1.SuspendLayout();
            splitContainerBigVertical.Panel2.SuspendLayout();
            splitContainerBigVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerLeftHorizontal).BeginInit();
            splitContainerLeftHorizontal.Panel1.SuspendLayout();
            splitContainerLeftHorizontal.Panel2.SuspendLayout();
            splitContainerLeftHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerRightHorizontal).BeginInit();
            splitContainerRightHorizontal.Panel1.SuspendLayout();
            splitContainerRightHorizontal.Panel2.SuspendLayout();
            splitContainerRightHorizontal.SuspendLayout();
            SuspendLayout();
            // 
            // lblSchoolSubject
            // 
            lblSchoolSubject.AutoSize = true;
            lblSchoolSubject.Location = new System.Drawing.Point(364, 22);
            lblSchoolSubject.Name = "lblSchoolSubject";
            lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            lblSchoolSubject.TabIndex = 5;
            lblSchoolSubject.Text = "Materia";
            // 
            // txtOfficialSchoolAbbreviation
            // 
            txtOfficialSchoolAbbreviation.Enabled = false;
            txtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtOfficialSchoolAbbreviation.Location = new System.Drawing.Point(13, 43);
            txtOfficialSchoolAbbreviation.Margin = new System.Windows.Forms.Padding(4);
            txtOfficialSchoolAbbreviation.Name = "txtOfficialSchoolAbbreviation";
            txtOfficialSchoolAbbreviation.ReadOnly = true;
            txtOfficialSchoolAbbreviation.Size = new System.Drawing.Size(135, 24);
            txtOfficialSchoolAbbreviation.TabIndex = 96;
            txtOfficialSchoolAbbreviation.Text = "FOIS01100L";
            // 
            // lblSchoolCode
            // 
            lblSchoolCode.AutoSize = true;
            lblSchoolCode.ForeColor = System.Drawing.Color.DarkBlue;
            lblSchoolCode.Location = new System.Drawing.Point(10, 22);
            lblSchoolCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSchoolCode.Name = "lblSchoolCode";
            lblSchoolCode.Size = new System.Drawing.Size(105, 18);
            lblSchoolCode.TabIndex = 95;
            lblSchoolCode.Text = "Codice Scuola";
            // 
            // lblClassAbbreviation
            // 
            lblClassAbbreviation.AutoSize = true;
            lblClassAbbreviation.ForeColor = System.Drawing.Color.DarkBlue;
            lblClassAbbreviation.Location = new System.Drawing.Point(258, 22);
            lblClassAbbreviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblClassAbbreviation.Name = "lblClassAbbreviation";
            lblClassAbbreviation.Size = new System.Drawing.Size(90, 18);
            lblClassAbbreviation.TabIndex = 94;
            lblClassAbbreviation.Text = "Sigla Classe";
            // 
            // txtClass
            // 
            txtClass.Enabled = false;
            txtClass.Location = new System.Drawing.Point(261, 43);
            txtClass.Name = "txtClass";
            txtClass.Size = new System.Drawing.Size(100, 24);
            txtClass.TabIndex = 99;
            // 
            // txtSchoolYear
            // 
            txtSchoolYear.Enabled = false;
            txtSchoolYear.Location = new System.Drawing.Point(155, 43);
            txtSchoolYear.Name = "txtSchoolYear";
            txtSchoolYear.Size = new System.Drawing.Size(100, 24);
            txtSchoolYear.TabIndex = 100;
            // 
            // lblSchoolYear
            // 
            lblSchoolYear.AutoSize = true;
            lblSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            lblSchoolYear.Location = new System.Drawing.Point(152, 22);
            lblSchoolYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSchoolYear.Name = "lblSchoolYear";
            lblSchoolYear.Size = new System.Drawing.Size(84, 18);
            lblSchoolYear.TabIndex = 102;
            lblSchoolYear.Text = "Anno Scol. ";
            // 
            // lblLessonCode
            // 
            lblLessonCode.AutoSize = true;
            lblLessonCode.ForeColor = System.Drawing.Color.DarkBlue;
            lblLessonCode.Location = new System.Drawing.Point(10, 71);
            lblLessonCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLessonCode.Name = "lblLessonCode";
            lblLessonCode.Size = new System.Drawing.Size(92, 18);
            lblLessonCode.TabIndex = 105;
            lblLessonCode.Text = "Cod.Lezione";
            // 
            // txtLessonCode
            // 
            txtLessonCode.Enabled = false;
            txtLessonCode.Location = new System.Drawing.Point(13, 92);
            txtLessonCode.Name = "txtLessonCode";
            txtLessonCode.ReadOnly = true;
            txtLessonCode.Size = new System.Drawing.Size(100, 24);
            txtLessonCode.TabIndex = 104;
            txtLessonCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLessonDate
            // 
            lblLessonDate.AutoSize = true;
            lblLessonDate.ForeColor = System.Drawing.Color.DarkBlue;
            lblLessonDate.Location = new System.Drawing.Point(116, 71);
            lblLessonDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLessonDate.Name = "lblLessonDate";
            lblLessonDate.Size = new System.Drawing.Size(39, 18);
            lblLessonDate.TabIndex = 107;
            lblLessonDate.Text = "Data";
            // 
            // lblLessonDesc
            // 
            lblLessonDesc.AutoSize = true;
            lblLessonDesc.ForeColor = System.Drawing.Color.DarkBlue;
            lblLessonDesc.Location = new System.Drawing.Point(229, 71);
            lblLessonDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLessonDesc.Name = "lblLessonDesc";
            lblLessonDesc.Size = new System.Drawing.Size(138, 18);
            lblLessonDesc.TabIndex = 110;
            lblLessonDesc.Text = "Descrizione lezione";
            // 
            // grpViewTopics
            // 
            grpViewTopics.Controls.Add(rdbNotDone);
            grpViewTopics.Controls.Add(rdbAlreadyDone);
            grpViewTopics.Controls.Add(rdbLesson);
            grpViewTopics.Location = new System.Drawing.Point(113, 141);
            grpViewTopics.Name = "grpViewTopics";
            grpViewTopics.Size = new System.Drawing.Size(150, 112);
            grpViewTopics.TabIndex = 111;
            grpViewTopics.TabStop = false;
            grpViewTopics.Text = "Visualizz.argomenti";
            grpViewTopics.Visible = false;
            // 
            // rdbNotDone
            // 
            rdbNotDone.AutoSize = true;
            rdbNotDone.Enabled = false;
            rdbNotDone.Location = new System.Drawing.Point(7, 80);
            rdbNotDone.Name = "rdbNotDone";
            rdbNotDone.Size = new System.Drawing.Size(81, 22);
            rdbNotDone.TabIndex = 2;
            rdbNotDone.Text = "Non fatti";
            rdbNotDone.UseVisualStyleBackColor = true;
            // 
            // rdbAlreadyDone
            // 
            rdbAlreadyDone.AutoSize = true;
            rdbAlreadyDone.Enabled = false;
            rdbAlreadyDone.Location = new System.Drawing.Point(7, 52);
            rdbAlreadyDone.Name = "rdbAlreadyDone";
            rdbAlreadyDone.Size = new System.Drawing.Size(76, 22);
            rdbAlreadyDone.TabIndex = 1;
            rdbAlreadyDone.Text = "Già fatti";
            rdbAlreadyDone.UseVisualStyleBackColor = true;
            // 
            // rdbLesson
            // 
            rdbLesson.AutoSize = true;
            rdbLesson.Checked = true;
            rdbLesson.Location = new System.Drawing.Point(7, 24);
            rdbLesson.Name = "rdbLesson";
            rdbLesson.Size = new System.Drawing.Size(78, 22);
            rdbLesson.TabIndex = 0;
            rdbLesson.TabStop = true;
            rdbLesson.Text = "Lezione";
            rdbLesson.UseVisualStyleBackColor = true;
            // 
            // dgwOneLesson
            // 
            dgwOneLesson.AllowUserToAddRows = false;
            dgwOneLesson.AllowUserToDeleteRows = false;
            dgwOneLesson.AllowUserToOrderColumns = true;
            dgwOneLesson.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwOneLesson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwOneLesson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwOneLesson.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgwOneLesson.Location = new System.Drawing.Point(0, 1);
            dgwOneLesson.Name = "dgwOneLesson";
            dgwOneLesson.RowHeadersWidth = 51;
            dgwOneLesson.Size = new System.Drawing.Size(353, 126);
            dgwOneLesson.TabIndex = 112;
            dgwOneLesson.CellContentClick += dgwOneLesson_CellContentClick;
            // 
            // txtSchoolSubject
            // 
            txtSchoolSubject.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtSchoolSubject.Enabled = false;
            txtSchoolSubject.Location = new System.Drawing.Point(367, 43);
            txtSchoolSubject.Name = "txtSchoolSubject";
            txtSchoolSubject.Size = new System.Drawing.Size(500, 24);
            txtSchoolSubject.TabIndex = 113;
            // 
            // btnFind
            // 
            btnFind.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFind.Location = new System.Drawing.Point(894, 271);
            btnFind.Name = "btnFind";
            btnFind.Size = new System.Drawing.Size(130, 45);
            btnFind.TabIndex = 121;
            btnFind.Text = "Trova (F3)";
            toolTip1.SetToolTip(btnFind, "Effettua ricerca");
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // lblFind
            // 
            lblFind.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblFind.AutoSize = true;
            lblFind.Location = new System.Drawing.Point(885, 168);
            lblFind.Name = "lblFind";
            lblFind.Size = new System.Drawing.Size(46, 18);
            lblFind.TabIndex = 121;
            lblFind.Text = "Trova";
            // 
            // txtTopicSearchString
            // 
            txtTopicSearchString.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtTopicSearchString.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtTopicSearchString.Location = new System.Drawing.Point(885, 189);
            txtTopicSearchString.Multiline = true;
            txtTopicSearchString.Name = "txtTopicSearchString";
            txtTopicSearchString.Size = new System.Drawing.Size(139, 33);
            txtTopicSearchString.TabIndex = 120;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnDelete.Location = new System.Drawing.Point(894, 603);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(130, 50);
            btnDelete.TabIndex = 125;
            btnDelete.Text = "Elimina (Canc)";
            toolTip1.SetToolTip(btnDelete, "Cancella l'argomento selezionato e tutti i suoi figli");
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtTopicName
            // 
            txtTopicName.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTopicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtTopicName.Location = new System.Drawing.Point(0, 343);
            txtTopicName.Multiline = true;
            txtTopicName.Name = "txtTopicName";
            txtTopicName.Size = new System.Drawing.Size(500, 27);
            txtTopicName.TabIndex = 122;
            toolTip1.SetToolTip(txtTopicName, "Argomento di lezione");
            // 
            // btnAddNodeSon
            // 
            btnAddNodeSon.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddNodeSon.Location = new System.Drawing.Point(894, 409);
            btnAddNodeSon.Name = "btnAddNodeSon";
            btnAddNodeSon.Size = new System.Drawing.Size(130, 45);
            btnAddNodeSon.TabIndex = 124;
            btnAddNodeSon.Text = "Aggiungi figlio (Ins)";
            toolTip1.SetToolTip(btnAddNodeSon, "Aggiungi nuovo argomento sotto al selezionato");
            btnAddNodeSon.UseVisualStyleBackColor = true;
            btnAddNodeSon.Click += btnAddNode_Click;
            // 
            // btnSaveTree
            // 
            btnSaveTree.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSaveTree.Location = new System.Drawing.Point(894, 363);
            btnSaveTree.Name = "btnSaveTree";
            btnSaveTree.Size = new System.Drawing.Size(130, 45);
            btnSaveTree.TabIndex = 123;
            btnSaveTree.Text = "Salva argomenti (F5)";
            toolTip1.SetToolTip(btnSaveTree, "Salvataggio di tutti gli argomenti");
            btnSaveTree.UseVisualStyleBackColor = true;
            btnSaveTree.Click += btnSaveTree_Click;
            // 
            // TxtLessonDesc
            // 
            TxtLessonDesc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TxtLessonDesc.Location = new System.Drawing.Point(229, 92);
            TxtLessonDesc.Multiline = true;
            TxtLessonDesc.Name = "TxtLessonDesc";
            TxtLessonDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            TxtLessonDesc.Size = new System.Drawing.Size(550, 84);
            TxtLessonDesc.TabIndex = 123;
            toolTip1.SetToolTip(TxtLessonDesc, "Descrizione della lezione");
            // 
            // dtpLessonDate
            // 
            dtpLessonDate.CustomFormat = "dd-MM-yyyy";
            dtpLessonDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpLessonDate.Location = new System.Drawing.Point(119, 92);
            dtpLessonDate.Name = "dtpLessonDate";
            dtpLessonDate.Size = new System.Drawing.Size(107, 24);
            dtpLessonDate.TabIndex = 125;
            // 
            // dgwAllLessons
            // 
            dgwAllLessons.AllowUserToAddRows = false;
            dgwAllLessons.AllowUserToDeleteRows = false;
            dgwAllLessons.AllowUserToOrderColumns = true;
            dgwAllLessons.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwAllLessons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwAllLessons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwAllLessons.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgwAllLessons.Location = new System.Drawing.Point(0, 3);
            dgwAllLessons.Name = "dgwAllLessons";
            dgwAllLessons.RowHeadersWidth = 51;
            dgwAllLessons.Size = new System.Drawing.Size(353, 277);
            dgwAllLessons.TabIndex = 127;
            dgwAllLessons.CellClick += DgwAllLessons_CellClick;
            dgwAllLessons.CellContentClick += DgwAllLessons_CellContentClick;
            dgwAllLessons.RowEnter += DgwAllLessons_RowEnter;
            // 
            // txtTopicsDigest
            // 
            txtTopicsDigest.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTopicsDigest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtTopicsDigest.Location = new System.Drawing.Point(1, 0);
            txtTopicsDigest.Multiline = true;
            txtTopicsDigest.Name = "txtTopicsDigest";
            txtTopicsDigest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtTopicsDigest.Size = new System.Drawing.Size(351, 69);
            txtTopicsDigest.TabIndex = 128;
            toolTip1.SetToolTip(txtTopicsDigest, "Testo da ricercare negli argomenti OPPURE argomenti selezionati (generati automaticamente)");
            // 
            // btnCopyNoteToClipboard
            // 
            btnCopyNoteToClipboard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCopyNoteToClipboard.Location = new System.Drawing.Point(760, 67);
            btnCopyNoteToClipboard.Name = "btnCopyNoteToClipboard";
            btnCopyNoteToClipboard.Size = new System.Drawing.Size(108, 25);
            btnCopyNoteToClipboard.TabIndex = 129;
            btnCopyNoteToClipboard.Text = "Clipboard";
            btnCopyNoteToClipboard.UseVisualStyleBackColor = true;
            btnCopyNoteToClipboard.Click += btnCopyToClipboard_Click;
            // 
            // btnStartLinks
            // 
            btnStartLinks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnStartLinks.Location = new System.Drawing.Point(760, 18);
            btnStartLinks.Name = "btnStartLinks";
            btnStartLinks.Size = new System.Drawing.Size(108, 25);
            btnStartLinks.TabIndex = 131;
            btnStartLinks.Text = "Start links";
            btnStartLinks.UseVisualStyleBackColor = true;
            btnStartLinks.Click += btnStartLinks_Click;
            // 
            // txtTopicDescription
            // 
            txtTopicDescription.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTopicDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtTopicDescription.Location = new System.Drawing.Point(0, 2);
            txtTopicDescription.Multiline = true;
            txtTopicDescription.Name = "txtTopicDescription";
            txtTopicDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtTopicDescription.Size = new System.Drawing.Size(500, 104);
            txtTopicDescription.TabIndex = 132;
            toolTip1.SetToolTip(txtTopicDescription, "Descrizione argomenti di lezione");
            // 
            // picImage
            // 
            picImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picImage.Location = new System.Drawing.Point(873, 12);
            picImage.Name = "picImage";
            picImage.Size = new System.Drawing.Size(155, 88);
            picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picImage.TabIndex = 133;
            picImage.TabStop = false;
            picImage.Click += picImage_Click;
            picImage.DoubleClick += picImage_DoubleClick;
            // 
            // btnManageImages
            // 
            btnManageImages.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnManageImages.Location = new System.Drawing.Point(941, 106);
            btnManageImages.Name = "btnManageImages";
            btnManageImages.Size = new System.Drawing.Size(87, 56);
            btnManageImages.TabIndex = 134;
            btnManageImages.Text = "Immagini e documenti";
            btnManageImages.UseVisualStyleBackColor = true;
            btnManageImages.Click += btnManageImages_Click;
            // 
            // splitContainerBigVertical
            // 
            splitContainerBigVertical.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splitContainerBigVertical.Cursor = System.Windows.Forms.Cursors.VSplit;
            splitContainerBigVertical.Location = new System.Drawing.Point(12, 179);
            splitContainerBigVertical.Name = "splitContainerBigVertical";
            // 
            // splitContainerBigVertical.Panel1
            // 
            splitContainerBigVertical.Panel1.Controls.Add(splitContainerLeftHorizontal);
            splitContainerBigVertical.Panel1.Controls.Add(txtTopicsDigest);
            // 
            // splitContainerBigVertical.Panel2
            // 
            splitContainerBigVertical.Panel2.Controls.Add(splitContainerRightHorizontal);
            splitContainerBigVertical.Size = new System.Drawing.Size(862, 480);
            splitContainerBigVertical.SplitterDistance = 355;
            splitContainerBigVertical.TabIndex = 135;
            // 
            // splitContainerLeftHorizontal
            // 
            splitContainerLeftHorizontal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splitContainerLeftHorizontal.Location = new System.Drawing.Point(0, 68);
            splitContainerLeftHorizontal.Name = "splitContainerLeftHorizontal";
            splitContainerLeftHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLeftHorizontal.Panel1
            // 
            splitContainerLeftHorizontal.Panel1.Controls.Add(grpViewTopics);
            splitContainerLeftHorizontal.Panel1.Controls.Add(dgwAllLessons);
            // 
            // splitContainerLeftHorizontal.Panel2
            // 
            splitContainerLeftHorizontal.Panel2.Controls.Add(dgwOneLesson);
            splitContainerLeftHorizontal.Size = new System.Drawing.Size(353, 412);
            splitContainerLeftHorizontal.SplitterDistance = 281;
            splitContainerLeftHorizontal.TabIndex = 129;
            // 
            // splitContainerRightHorizontal
            // 
            splitContainerRightHorizontal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splitContainerRightHorizontal.Cursor = System.Windows.Forms.Cursors.HSplit;
            splitContainerRightHorizontal.Location = new System.Drawing.Point(3, 0);
            splitContainerRightHorizontal.Name = "splitContainerRightHorizontal";
            splitContainerRightHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRightHorizontal.Panel1
            // 
            splitContainerRightHorizontal.Panel1.Controls.Add(txtTopicName);
            splitContainerRightHorizontal.Panel1.Controls.Add(trwTopics);
            splitContainerRightHorizontal.Panel1.Controls.Add(lblExplain);
            // 
            // splitContainerRightHorizontal.Panel2
            // 
            splitContainerRightHorizontal.Panel2.Controls.Add(txtTopicDescription);
            splitContainerRightHorizontal.Size = new System.Drawing.Size(500, 480);
            splitContainerRightHorizontal.SplitterDistance = 370;
            splitContainerRightHorizontal.TabIndex = 129;
            // 
            // trwTopics
            // 
            trwTopics.AllowDrop = true;
            trwTopics.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trwTopics.CheckBoxes = true;
            trwTopics.LabelEdit = true;
            trwTopics.Location = new System.Drawing.Point(0, 0);
            trwTopics.Name = "trwTopics";
            trwTopics.Size = new System.Drawing.Size(500, 321);
            trwTopics.TabIndex = 148;
            // 
            // lblExplain
            // 
            lblExplain.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblExplain.AutoSize = true;
            lblExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblExplain.Location = new System.Drawing.Point(3, 324);
            lblExplain.Name = "lblExplain";
            lblExplain.Size = new System.Drawing.Size(370, 13);
            lblExplain.TabIndex = 115;
            lblExplain.Text = "Drag -> padre,Ctrl Drag  -> fratello.  F2 modifica. v Argomento  vv Descrizione";
            // 
            // btnTopicsDone
            // 
            btnTopicsDone.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnTopicsDone.Location = new System.Drawing.Point(894, 501);
            btnTopicsDone.Name = "btnTopicsDone";
            btnTopicsDone.Size = new System.Drawing.Size(130, 50);
            btnTopicsDone.TabIndex = 137;
            btnTopicsDone.Text = "Argomenti fatti";
            toolTip1.SetToolTip(btnTopicsDone, "Segna tutti gli argomenti fatti dalla classe ");
            btnTopicsDone.UseVisualStyleBackColor = true;
            btnTopicsDone.Click += btnTopicsDone_Click;
            // 
            // bntLessonErase
            // 
            bntLessonErase.Location = new System.Drawing.Point(12, 122);
            bntLessonErase.Name = "bntLessonErase";
            bntLessonErase.Size = new System.Drawing.Size(101, 54);
            bntLessonErase.TabIndex = 138;
            bntLessonErase.Text = "Elimina lezione";
            bntLessonErase.UseVisualStyleBackColor = true;
            bntLessonErase.Click += bntLessonErase_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNext.Location = new System.Drawing.Point(910, 117);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(26, 34);
            btnNext.TabIndex = 139;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnPrevious.Location = new System.Drawing.Point(885, 117);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new System.Drawing.Size(26, 34);
            btnPrevious.TabIndex = 140;
            btnPrevious.Text = "<";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnArgFreemind
            // 
            btnArgFreemind.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnArgFreemind.Location = new System.Drawing.Point(894, 552);
            btnArgFreemind.Name = "btnArgFreemind";
            btnArgFreemind.Size = new System.Drawing.Size(130, 50);
            btnArgFreemind.TabIndex = 141;
            btnArgFreemind.Text = "Argom. Freemind";
            toolTip1.SetToolTip(btnArgFreemind, "Mette in clipboard per trasferimento in Freemind");
            btnArgFreemind.UseVisualStyleBackColor = true;
            btnArgFreemind.Click += btnArgFreemind_Click;
            // 
            // lblLessonTime
            // 
            lblLessonTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblLessonTime.BackColor = System.Drawing.Color.Transparent;
            lblLessonTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblLessonTime.Enabled = false;
            lblLessonTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblLessonTime.ForeColor = System.Drawing.Color.DarkBlue;
            lblLessonTime.Location = new System.Drawing.Point(789, 161);
            lblLessonTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLessonTime.Name = "lblLessonTime";
            lblLessonTime.Size = new System.Drawing.Size(77, 15);
            lblLessonTime.TabIndex = 142;
            lblLessonTime.Text = "      ";
            toolTip1.SetToolTip(lblLessonTime, "Tempo della lezione rimasto");
            // 
            // LessonTimer
            // 
            LessonTimer.Tick += LessonTimer_Tick;
            // 
            // btnLessonSave
            // 
            btnLessonSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnLessonSave.Location = new System.Drawing.Point(789, 101);
            btnLessonSave.Name = "btnLessonSave";
            btnLessonSave.Size = new System.Drawing.Size(78, 54);
            btnLessonSave.TabIndex = 126;
            btnLessonSave.Text = "Salva lezione";
            btnLessonSave.UseVisualStyleBackColor = true;
            btnLessonSave.Click += btnLessonSave_Click;
            // 
            // BtnOpenImagesFolder
            // 
            BtnOpenImagesFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnOpenImagesFolder.Location = new System.Drawing.Point(646, 18);
            BtnOpenImagesFolder.Name = "BtnOpenImagesFolder";
            BtnOpenImagesFolder.Size = new System.Drawing.Size(108, 25);
            BtnOpenImagesFolder.TabIndex = 144;
            BtnOpenImagesFolder.Text = "Cart.immag.";
            toolTip1.SetToolTip(BtnOpenImagesFolder, "Apre la cartella che include le immagini delle lezioni della classe");
            BtnOpenImagesFolder.UseVisualStyleBackColor = true;
            BtnOpenImagesFolder.Click += BtnOpenImagesFolder_Click;
            // 
            // rdbStringSearch
            // 
            rdbStringSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rdbStringSearch.AutoSize = true;
            rdbStringSearch.Checked = true;
            rdbStringSearch.Location = new System.Drawing.Point(885, 45);
            rdbStringSearch.Name = "rdbStringSearch";
            rdbStringSearch.Size = new System.Drawing.Size(46, 22);
            rdbStringSearch.TabIndex = 148;
            rdbStringSearch.TabStop = true;
            rdbStringSearch.Text = "Txt";
            toolTip1.SetToolTip(rdbStringSearch, "Ricerca per stringa");
            rdbStringSearch.UseVisualStyleBackColor = true;
            rdbStringSearch.Visible = false;
            // 
            // rdbAndSearch
            // 
            rdbAndSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rdbAndSearch.AutoSize = true;
            rdbAndSearch.Enabled = false;
            rdbAndSearch.Location = new System.Drawing.Point(983, 45);
            rdbAndSearch.Name = "rdbAndSearch";
            rdbAndSearch.Size = new System.Drawing.Size(50, 22);
            rdbAndSearch.TabIndex = 149;
            rdbAndSearch.Text = " &&&&";
            toolTip1.SetToolTip(rdbAndSearch, "Ricerca per parole in And");
            rdbAndSearch.UseVisualStyleBackColor = true;
            rdbAndSearch.Visible = false;
            // 
            // rdbOrSearch
            // 
            rdbOrSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rdbOrSearch.AutoSize = true;
            rdbOrSearch.Enabled = false;
            rdbOrSearch.Location = new System.Drawing.Point(937, 45);
            rdbOrSearch.Name = "rdbOrSearch";
            rdbOrSearch.Size = new System.Drawing.Size(40, 22);
            rdbOrSearch.TabIndex = 150;
            rdbOrSearch.Text = " ||";
            toolTip1.SetToolTip(rdbOrSearch, "Ricerca per parole in Or");
            rdbOrSearch.UseVisualStyleBackColor = true;
            rdbOrSearch.Visible = false;
            // 
            // btnFindUnderNode
            // 
            btnFindUnderNode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFindUnderNode.Location = new System.Drawing.Point(894, 317);
            btnFindUnderNode.Name = "btnFindUnderNode";
            btnFindUnderNode.Size = new System.Drawing.Size(130, 45);
            btnFindUnderNode.TabIndex = 154;
            btnFindUnderNode.Text = "Trova sotto (Shift+F3)";
            toolTip1.SetToolTip(btnFindUnderNode, "Ricerca sotto il nodo selezionato");
            btnFindUnderNode.UseVisualStyleBackColor = true;
            btnFindUnderNode.Click += btnFindUnderNode_Click;
            // 
            // chkCaseInsensitive
            // 
            chkCaseInsensitive.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkCaseInsensitive.AutoSize = true;
            chkCaseInsensitive.Checked = true;
            chkCaseInsensitive.CheckState = System.Windows.Forms.CheckState.Checked;
            chkCaseInsensitive.Location = new System.Drawing.Point(947, 247);
            chkCaseInsensitive.Name = "chkCaseInsensitive";
            chkCaseInsensitive.Size = new System.Drawing.Size(82, 22);
            chkCaseInsensitive.TabIndex = 157;
            chkCaseInsensitive.Text = "ma && mi";
            toolTip1.SetToolTip(chkCaseInsensitive, "Ricerca case insensitive");
            chkCaseInsensitive.UseVisualStyleBackColor = true;
            // 
            // chkMarkAllTopicsFound
            // 
            chkMarkAllTopicsFound.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkMarkAllTopicsFound.AutoSize = true;
            chkMarkAllTopicsFound.Location = new System.Drawing.Point(974, 166);
            chkMarkAllTopicsFound.Name = "chkMarkAllTopicsFound";
            chkMarkAllTopicsFound.Size = new System.Drawing.Size(50, 22);
            chkMarkAllTopicsFound.TabIndex = 152;
            chkMarkAllTopicsFound.Text = "tutti";
            toolTip1.SetToolTip(chkMarkAllTopicsFound, "Trova e segna ogni occorrenza  della stringa");
            chkMarkAllTopicsFound.UseVisualStyleBackColor = true;
            // 
            // btnAddNodeBrother
            // 
            btnAddNodeBrother.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddNodeBrother.Location = new System.Drawing.Point(894, 455);
            btnAddNodeBrother.Name = "btnAddNodeBrother";
            btnAddNodeBrother.Size = new System.Drawing.Size(130, 45);
            btnAddNodeBrother.TabIndex = 153;
            btnAddNodeBrother.Text = "Agg. fratello (Shift+Ins)";
            toolTip1.SetToolTip(btnAddNodeBrother, "Aggiungi nuovo argomento a fianco del selezionato");
            btnAddNodeBrother.UseVisualStyleBackColor = true;
            btnAddNodeBrother.Click += btnAddNodeBrother_Click;
            // 
            // chkAllWord
            // 
            chkAllWord.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkAllWord.AutoSize = true;
            chkAllWord.Location = new System.Drawing.Point(880, 247);
            chkAllWord.Name = "chkAllWord";
            chkAllWord.Size = new System.Drawing.Size(70, 22);
            chkAllWord.TabIndex = 156;
            chkAllWord.Text = "Parola";
            toolTip1.SetToolTip(chkAllWord, "Ricerca a parola intera");
            chkAllWord.UseVisualStyleBackColor = true;
            // 
            // chkSearchInDescriptions
            // 
            chkSearchInDescriptions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkSearchInDescriptions.AutoSize = true;
            chkSearchInDescriptions.Checked = true;
            chkSearchInDescriptions.CheckState = System.Windows.Forms.CheckState.Checked;
            chkSearchInDescriptions.Location = new System.Drawing.Point(910, 226);
            chkSearchInDescriptions.Name = "chkSearchInDescriptions";
            chkSearchInDescriptions.Size = new System.Drawing.Size(97, 22);
            chkSearchInDescriptions.TabIndex = 158;
            chkSearchInDescriptions.Text = "In Descriz.";
            toolTip1.SetToolTip(chkSearchInDescriptions, "Ricerca anche in descrizione");
            chkSearchInDescriptions.UseVisualStyleBackColor = true;
            // 
            // BtnSearchAmongTopics
            // 
            BtnSearchAmongTopics.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnSearchAmongTopics.Location = new System.Drawing.Point(646, 67);
            BtnSearchAmongTopics.Name = "BtnSearchAmongTopics";
            BtnSearchAmongTopics.Size = new System.Drawing.Size(108, 25);
            BtnSearchAmongTopics.TabIndex = 143;
            BtnSearchAmongTopics.Text = "Cerca";
            BtnSearchAmongTopics.UseVisualStyleBackColor = true;
            BtnSearchAmongTopics.Click += BtnSearchAmongTopics_Click;
            // 
            // btnExport
            // 
            btnExport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnExport.ForeColor = System.Drawing.Color.Red;
            btnExport.Location = new System.Drawing.Point(531, 67);
            btnExport.Name = "btnExport";
            btnExport.Size = new System.Drawing.Size(108, 25);
            btnExport.TabIndex = 151;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnLessonAdd
            // 
            btnLessonAdd.Location = new System.Drawing.Point(125, 122);
            btnLessonAdd.Name = "btnLessonAdd";
            btnLessonAdd.Size = new System.Drawing.Size(101, 54);
            btnLessonAdd.TabIndex = 108;
            btnLessonAdd.Text = "Nuova lezione";
            btnLessonAdd.UseVisualStyleBackColor = true;
            btnLessonAdd.Click += btnLessonAdd_Click;
            // 
            // frmLessons
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(1032, 667);
            Controls.Add(chkSearchInDescriptions);
            Controls.Add(chkCaseInsensitive);
            Controls.Add(chkAllWord);
            Controls.Add(btnFindUnderNode);
            Controls.Add(btnAddNodeBrother);
            Controls.Add(chkMarkAllTopicsFound);
            Controls.Add(btnExport);
            Controls.Add(btnAddNodeSon);
            Controls.Add(rdbOrSearch);
            Controls.Add(rdbAndSearch);
            Controls.Add(rdbStringSearch);
            Controls.Add(BtnOpenImagesFolder);
            Controls.Add(BtnSearchAmongTopics);
            Controls.Add(lblLessonTime);
            Controls.Add(btnLessonAdd);
            Controls.Add(btnLessonSave);
            Controls.Add(btnArgFreemind);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(bntLessonErase);
            Controls.Add(btnTopicsDone);
            Controls.Add(splitContainerBigVertical);
            Controls.Add(btnManageImages);
            Controls.Add(picImage);
            Controls.Add(btnStartLinks);
            Controls.Add(btnCopyNoteToClipboard);
            Controls.Add(dtpLessonDate);
            Controls.Add(TxtLessonDesc);
            Controls.Add(btnFind);
            Controls.Add(lblFind);
            Controls.Add(txtTopicSearchString);
            Controls.Add(btnDelete);
            Controls.Add(btnSaveTree);
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
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmLessons";
            Text = "Lezioni";
            FormClosed += frmLessons_FormClosed;
            Load += frmLessons_Load;
            KeyDown += frmLessonsTopics_KeyDown;
            grpViewTopics.ResumeLayout(false);
            grpViewTopics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwOneLesson).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgwAllLessons).EndInit();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            splitContainerBigVertical.Panel1.ResumeLayout(false);
            splitContainerBigVertical.Panel1.PerformLayout();
            splitContainerBigVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerBigVertical).EndInit();
            splitContainerBigVertical.ResumeLayout(false);
            splitContainerLeftHorizontal.Panel1.ResumeLayout(false);
            splitContainerLeftHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerLeftHorizontal).EndInit();
            splitContainerLeftHorizontal.ResumeLayout(false);
            splitContainerRightHorizontal.Panel1.ResumeLayout(false);
            splitContainerRightHorizontal.Panel1.PerformLayout();
            splitContainerRightHorizontal.Panel2.ResumeLayout(false);
            splitContainerRightHorizontal.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerRightHorizontal).EndInit();
            splitContainerRightHorizontal.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSchoolSubject;
        private System.Windows.Forms.TextBox txtOfficialSchoolAbbreviation;
        private System.Windows.Forms.Label lblSchoolCode;
        private System.Windows.Forms.Label lblClassAbbreviation;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.TextBox txtSchoolYear;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.Label lblLessonCode;
        private System.Windows.Forms.TextBox txtLessonCode;
        private System.Windows.Forms.Label lblLessonDate;
        private System.Windows.Forms.Button btnLessonAdd;
        private System.Windows.Forms.Label lblLessonDesc;
        private System.Windows.Forms.GroupBox grpViewTopics;
        private System.Windows.Forms.RadioButton rdbNotDone;
        private System.Windows.Forms.RadioButton rdbAlreadyDone;
        private System.Windows.Forms.RadioButton rdbLesson;
        private System.Windows.Forms.DataGridView dgwOneLesson;
        private System.Windows.Forms.TextBox txtSchoolSubject;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.TextBox txtTopicFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtTopicName;
        private System.Windows.Forms.Button btnAddNodeSon;
        private System.Windows.Forms.Button btnSaveTree;
        private System.Windows.Forms.TextBox TxtLessonDesc;
        private System.Windows.Forms.DateTimePicker dtpLessonDate;
        private System.Windows.Forms.DataGridView dgwAllLessons;
        private System.Windows.Forms.TextBox txtTopicsDigest;
        private System.Windows.Forms.Button btnCopyNoteToClipboard;
        private System.Windows.Forms.Button btnStartLinks;
        private System.Windows.Forms.TextBox txtTopicDescription;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnManageImages;
        private System.Windows.Forms.SplitContainer splitContainerBigVertical;
        private System.Windows.Forms.SplitContainer splitContainerRightHorizontal;
        private System.Windows.Forms.SplitContainer splitContainerLeftHorizontal;
        private System.Windows.Forms.Button btnTopicsNotDone;
        private System.Windows.Forms.Button btnTopicsDone;
        private System.Windows.Forms.Button bntLessonErase;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblExplain;
        private System.Windows.Forms.Button btnArgFreemind;
        private System.Windows.Forms.Label lblLessonTime;
        private System.Windows.Forms.Timer LessonTimer;
        private System.Windows.Forms.Button btnLessonSave;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button BtnSearchAmongTopics;
        private System.Windows.Forms.Button BtnOpenImagesFolder;
        private System.Windows.Forms.TreeView trwTopics;
        private System.Windows.Forms.RadioButton rdbStringSearch;
        private System.Windows.Forms.RadioButton rdbAndSearch;
        private System.Windows.Forms.RadioButton rdbOrSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox chkMarkAllTopicsFound;
        private System.Windows.Forms.Button btnAddNodeBrother;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFindUnderNode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkMaiuscoleMinuscole;
        private System.Windows.Forms.CheckBox chkCaseInsensitive;
        private System.Windows.Forms.CheckBox chkAllWord;
        private System.Windows.Forms.CheckBox chkSearchInDescriptions;
        private System.Windows.Forms.TextBox txtTopicSearchString;
    }
}