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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLessons));
            this.lblSchoolSubject = new System.Windows.Forms.Label();
            this.txtOfficialSchoolAbbreviation = new System.Windows.Forms.TextBox();
            this.lblSchoolCode = new System.Windows.Forms.Label();
            this.lblClassAbbreviation = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtSchoolYear = new System.Windows.Forms.TextBox();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.lblLessonCode = new System.Windows.Forms.Label();
            this.txtLessonCode = new System.Windows.Forms.TextBox();
            this.lblLessonDate = new System.Windows.Forms.Label();
            this.btnLessonAdd = new System.Windows.Forms.Button();
            this.lblLessonDesc = new System.Windows.Forms.Label();
            this.grpViewTopics = new System.Windows.Forms.GroupBox();
            this.rdbNotDone = new System.Windows.Forms.RadioButton();
            this.rdbAlreadyDone = new System.Windows.Forms.RadioButton();
            this.rdbLesson = new System.Windows.Forms.RadioButton();
            this.dgwOneLesson = new System.Windows.Forms.DataGridView();
            this.txtSchoolSubject = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblFind = new System.Windows.Forms.Label();
            this.txtTopicFind = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtTopicName = new System.Windows.Forms.TextBox();
            this.btnAddNodeSon = new System.Windows.Forms.Button();
            this.btnSaveTree = new System.Windows.Forms.Button();
            this.TxtLessonDesc = new System.Windows.Forms.TextBox();
            this.dtpLessonDate = new System.Windows.Forms.DateTimePicker();
            this.dgwAllLessons = new System.Windows.Forms.DataGridView();
            this.TxtTopicsDigestAndSearch = new System.Windows.Forms.TextBox();
            this.btnCopyNoteToClipboard = new System.Windows.Forms.Button();
            this.btnStartLinks = new System.Windows.Forms.Button();
            this.txtTopicDescription = new System.Windows.Forms.TextBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnManageImages = new System.Windows.Forms.Button();
            this.splitContainerBigVertical = new System.Windows.Forms.SplitContainer();
            this.splitContainerLeftHorizontal = new System.Windows.Forms.SplitContainer();
            this.splitContainerRightHorizontal = new System.Windows.Forms.SplitContainer();
            this.trwTopics = new System.Windows.Forms.TreeView();
            this.lblExplain = new System.Windows.Forms.Label();
            this.btnTopicsDone = new System.Windows.Forms.Button();
            this.bntLessonErase = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnArgFreemind = new System.Windows.Forms.Button();
            this.lblLessonTime = new System.Windows.Forms.Label();
            this.LessonTimer = new System.Windows.Forms.Timer(this.components);
            this.btnLessonSave = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BtnOpenImagesFolder = new System.Windows.Forms.Button();
            this.rdbStringSearch = new System.Windows.Forms.RadioButton();
            this.rdbAndSearch = new System.Windows.Forms.RadioButton();
            this.rdbOrSearch = new System.Windows.Forms.RadioButton();
            this.btnFindUnderNode = new System.Windows.Forms.Button();
            this.BtnSearchAmongTopics = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.chkFindAll = new System.Windows.Forms.CheckBox();
            this.btnAddNodeBrother = new System.Windows.Forms.Button();
            this.grpViewTopics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOneLesson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAllLessons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBigVertical)).BeginInit();
            this.splitContainerBigVertical.Panel1.SuspendLayout();
            this.splitContainerBigVertical.Panel2.SuspendLayout();
            this.splitContainerBigVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeftHorizontal)).BeginInit();
            this.splitContainerLeftHorizontal.Panel1.SuspendLayout();
            this.splitContainerLeftHorizontal.Panel2.SuspendLayout();
            this.splitContainerLeftHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRightHorizontal)).BeginInit();
            this.splitContainerRightHorizontal.Panel1.SuspendLayout();
            this.splitContainerRightHorizontal.Panel2.SuspendLayout();
            this.splitContainerRightHorizontal.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSchoolSubject
            // 
            this.lblSchoolSubject.AutoSize = true;
            this.lblSchoolSubject.Location = new System.Drawing.Point(364, 22);
            this.lblSchoolSubject.Name = "lblSchoolSubject";
            this.lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            this.lblSchoolSubject.TabIndex = 5;
            this.lblSchoolSubject.Text = "Materia";
            // 
            // txtOfficialSchoolAbbreviation
            // 
            this.txtOfficialSchoolAbbreviation.Enabled = false;
            this.txtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOfficialSchoolAbbreviation.Location = new System.Drawing.Point(13, 43);
            this.txtOfficialSchoolAbbreviation.Margin = new System.Windows.Forms.Padding(4);
            this.txtOfficialSchoolAbbreviation.Name = "txtOfficialSchoolAbbreviation";
            this.txtOfficialSchoolAbbreviation.ReadOnly = true;
            this.txtOfficialSchoolAbbreviation.Size = new System.Drawing.Size(135, 24);
            this.txtOfficialSchoolAbbreviation.TabIndex = 96;
            this.txtOfficialSchoolAbbreviation.Text = "FOIS01100L";
            // 
            // lblSchoolCode
            // 
            this.lblSchoolCode.AutoSize = true;
            this.lblSchoolCode.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSchoolCode.Location = new System.Drawing.Point(10, 22);
            this.lblSchoolCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSchoolCode.Name = "lblSchoolCode";
            this.lblSchoolCode.Size = new System.Drawing.Size(105, 18);
            this.lblSchoolCode.TabIndex = 95;
            this.lblSchoolCode.Text = "Codice Scuola";
            // 
            // lblClassAbbreviation
            // 
            this.lblClassAbbreviation.AutoSize = true;
            this.lblClassAbbreviation.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblClassAbbreviation.Location = new System.Drawing.Point(258, 22);
            this.lblClassAbbreviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClassAbbreviation.Name = "lblClassAbbreviation";
            this.lblClassAbbreviation.Size = new System.Drawing.Size(90, 18);
            this.lblClassAbbreviation.TabIndex = 94;
            this.lblClassAbbreviation.Text = "Sigla Classe";
            // 
            // txtClass
            // 
            this.txtClass.Enabled = false;
            this.txtClass.Location = new System.Drawing.Point(261, 43);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(100, 24);
            this.txtClass.TabIndex = 99;
            // 
            // txtSchoolYear
            // 
            this.txtSchoolYear.Enabled = false;
            this.txtSchoolYear.Location = new System.Drawing.Point(155, 43);
            this.txtSchoolYear.Name = "txtSchoolYear";
            this.txtSchoolYear.Size = new System.Drawing.Size(100, 24);
            this.txtSchoolYear.TabIndex = 100;
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSchoolYear.Location = new System.Drawing.Point(152, 22);
            this.lblSchoolYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(84, 18);
            this.lblSchoolYear.TabIndex = 102;
            this.lblSchoolYear.Text = "Anno Scol. ";
            // 
            // lblLessonCode
            // 
            this.lblLessonCode.AutoSize = true;
            this.lblLessonCode.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLessonCode.Location = new System.Drawing.Point(10, 71);
            this.lblLessonCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLessonCode.Name = "lblLessonCode";
            this.lblLessonCode.Size = new System.Drawing.Size(92, 18);
            this.lblLessonCode.TabIndex = 105;
            this.lblLessonCode.Text = "Cod.Lezione";
            // 
            // txtLessonCode
            // 
            this.txtLessonCode.Enabled = false;
            this.txtLessonCode.Location = new System.Drawing.Point(13, 92);
            this.txtLessonCode.Name = "txtLessonCode";
            this.txtLessonCode.ReadOnly = true;
            this.txtLessonCode.Size = new System.Drawing.Size(100, 24);
            this.txtLessonCode.TabIndex = 104;
            this.txtLessonCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLessonDate
            // 
            this.lblLessonDate.AutoSize = true;
            this.lblLessonDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLessonDate.Location = new System.Drawing.Point(116, 71);
            this.lblLessonDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLessonDate.Name = "lblLessonDate";
            this.lblLessonDate.Size = new System.Drawing.Size(39, 18);
            this.lblLessonDate.TabIndex = 107;
            this.lblLessonDate.Text = "Data";
            // 
            // btnLessonAdd
            // 
            this.btnLessonAdd.Location = new System.Drawing.Point(125, 122);
            this.btnLessonAdd.Name = "btnLessonAdd";
            this.btnLessonAdd.Size = new System.Drawing.Size(101, 54);
            this.btnLessonAdd.TabIndex = 108;
            this.btnLessonAdd.Text = "Nuova lezione";
            this.btnLessonAdd.UseVisualStyleBackColor = true;
            this.btnLessonAdd.Click += new System.EventHandler(this.btnLessonAdd_Click);
            // 
            // lblLessonDesc
            // 
            this.lblLessonDesc.AutoSize = true;
            this.lblLessonDesc.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLessonDesc.Location = new System.Drawing.Point(229, 71);
            this.lblLessonDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLessonDesc.Name = "lblLessonDesc";
            this.lblLessonDesc.Size = new System.Drawing.Size(85, 18);
            this.lblLessonDesc.TabIndex = 110;
            this.lblLessonDesc.Text = "Annotazioni";
            // 
            // grpViewTopics
            // 
            this.grpViewTopics.Controls.Add(this.rdbNotDone);
            this.grpViewTopics.Controls.Add(this.rdbAlreadyDone);
            this.grpViewTopics.Controls.Add(this.rdbLesson);
            this.grpViewTopics.Location = new System.Drawing.Point(12, 23);
            this.grpViewTopics.Name = "grpViewTopics";
            this.grpViewTopics.Size = new System.Drawing.Size(150, 112);
            this.grpViewTopics.TabIndex = 111;
            this.grpViewTopics.TabStop = false;
            this.grpViewTopics.Text = "Visualizz.argomenti";
            this.grpViewTopics.Visible = false;
            // 
            // rdbNotDone
            // 
            this.rdbNotDone.AutoSize = true;
            this.rdbNotDone.Enabled = false;
            this.rdbNotDone.Location = new System.Drawing.Point(7, 80);
            this.rdbNotDone.Name = "rdbNotDone";
            this.rdbNotDone.Size = new System.Drawing.Size(81, 22);
            this.rdbNotDone.TabIndex = 2;
            this.rdbNotDone.Text = "Non fatti";
            this.rdbNotDone.UseVisualStyleBackColor = true;
            // 
            // rdbAlreadyDone
            // 
            this.rdbAlreadyDone.AutoSize = true;
            this.rdbAlreadyDone.Enabled = false;
            this.rdbAlreadyDone.Location = new System.Drawing.Point(7, 52);
            this.rdbAlreadyDone.Name = "rdbAlreadyDone";
            this.rdbAlreadyDone.Size = new System.Drawing.Size(76, 22);
            this.rdbAlreadyDone.TabIndex = 1;
            this.rdbAlreadyDone.Text = "Già fatti";
            this.rdbAlreadyDone.UseVisualStyleBackColor = true;
            // 
            // rdbLesson
            // 
            this.rdbLesson.AutoSize = true;
            this.rdbLesson.Checked = true;
            this.rdbLesson.Location = new System.Drawing.Point(7, 24);
            this.rdbLesson.Name = "rdbLesson";
            this.rdbLesson.Size = new System.Drawing.Size(78, 22);
            this.rdbLesson.TabIndex = 0;
            this.rdbLesson.TabStop = true;
            this.rdbLesson.Text = "Lezione";
            this.rdbLesson.UseVisualStyleBackColor = true;
            // 
            // dgwOneLesson
            // 
            this.dgwOneLesson.AllowUserToAddRows = false;
            this.dgwOneLesson.AllowUserToDeleteRows = false;
            this.dgwOneLesson.AllowUserToOrderColumns = true;
            this.dgwOneLesson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwOneLesson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwOneLesson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwOneLesson.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwOneLesson.Location = new System.Drawing.Point(0, 1);
            this.dgwOneLesson.Name = "dgwOneLesson";
            this.dgwOneLesson.RowHeadersWidth = 51;
            this.dgwOneLesson.Size = new System.Drawing.Size(318, 126);
            this.dgwOneLesson.TabIndex = 112;
            this.dgwOneLesson.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwOneLesson_CellContentClick);
            // 
            // txtSchoolSubject
            // 
            this.txtSchoolSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSchoolSubject.Enabled = false;
            this.txtSchoolSubject.Location = new System.Drawing.Point(367, 43);
            this.txtSchoolSubject.Name = "txtSchoolSubject";
            this.txtSchoolSubject.Size = new System.Drawing.Size(413, 24);
            this.txtSchoolSubject.TabIndex = 113;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(807, 250);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(130, 45);
            this.btnFind.TabIndex = 121;
            this.btnFind.Text = "Trova (F3)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lblFind
            // 
            this.lblFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(798, 168);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(46, 18);
            this.lblFind.TabIndex = 121;
            this.lblFind.Text = "Trova";
            // 
            // txtTopicFind
            // 
            this.txtTopicFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopicFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTopicFind.Location = new System.Drawing.Point(798, 189);
            this.txtTopicFind.Multiline = true;
            this.txtTopicFind.Name = "txtTopicFind";
            this.txtTopicFind.Size = new System.Drawing.Size(139, 39);
            this.txtTopicFind.TabIndex = 120;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(807, 609);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 50);
            this.btnDelete.TabIndex = 125;
            this.btnDelete.Text = "Elimina (Canc)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtTopicName
            // 
            this.txtTopicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTopicName.Location = new System.Drawing.Point(0, 343);
            this.txtTopicName.Multiline = true;
            this.txtTopicName.Name = "txtTopicName";
            this.txtTopicName.Size = new System.Drawing.Size(448, 27);
            this.txtTopicName.TabIndex = 122;
            this.toolTip1.SetToolTip(this.txtTopicName, "Argomento di lezione");
            // 
            // btnAddNodeSon
            // 
            this.btnAddNodeSon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNodeSon.Location = new System.Drawing.Point(807, 400);
            this.btnAddNodeSon.Name = "btnAddNodeSon";
            this.btnAddNodeSon.Size = new System.Drawing.Size(130, 45);
            this.btnAddNodeSon.TabIndex = 124;
            this.btnAddNodeSon.Text = "Aggiungi figlio (Ins)";
            this.btnAddNodeSon.UseVisualStyleBackColor = true;
            this.btnAddNodeSon.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // btnSaveTree
            // 
            this.btnSaveTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveTree.Location = new System.Drawing.Point(807, 350);
            this.btnSaveTree.Name = "btnSaveTree";
            this.btnSaveTree.Size = new System.Drawing.Size(130, 45);
            this.btnSaveTree.TabIndex = 123;
            this.btnSaveTree.Text = "Salva argomenti (F5)";
            this.btnSaveTree.UseVisualStyleBackColor = true;
            this.btnSaveTree.Click += new System.EventHandler(this.btnSaveTree_Click);
            // 
            // TxtLessonDesc
            // 
            this.TxtLessonDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLessonDesc.Location = new System.Drawing.Point(229, 92);
            this.TxtLessonDesc.Multiline = true;
            this.TxtLessonDesc.Name = "TxtLessonDesc";
            this.TxtLessonDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtLessonDesc.Size = new System.Drawing.Size(463, 84);
            this.TxtLessonDesc.TabIndex = 123;
            this.toolTip1.SetToolTip(this.TxtLessonDesc, "Descrizione della lezione");
            // 
            // dtpLessonDate
            // 
            this.dtpLessonDate.CustomFormat = "dd-MM-yyyy";
            this.dtpLessonDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLessonDate.Location = new System.Drawing.Point(119, 92);
            this.dtpLessonDate.Name = "dtpLessonDate";
            this.dtpLessonDate.Size = new System.Drawing.Size(107, 24);
            this.dtpLessonDate.TabIndex = 125;
            // 
            // dgwAllLessons
            // 
            this.dgwAllLessons.AllowUserToAddRows = false;
            this.dgwAllLessons.AllowUserToDeleteRows = false;
            this.dgwAllLessons.AllowUserToOrderColumns = true;
            this.dgwAllLessons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwAllLessons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwAllLessons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAllLessons.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwAllLessons.Location = new System.Drawing.Point(0, 3);
            this.dgwAllLessons.Name = "dgwAllLessons";
            this.dgwAllLessons.RowHeadersWidth = 51;
            this.dgwAllLessons.Size = new System.Drawing.Size(318, 277);
            this.dgwAllLessons.TabIndex = 127;
            this.dgwAllLessons.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwAllLessons_CellClick);
            this.dgwAllLessons.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwAllLessons_CellContentClick);
            this.dgwAllLessons.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwAllLessons_RowEnter);
            // 
            // TxtTopicsDigestAndSearch
            // 
            this.TxtTopicsDigestAndSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTopicsDigestAndSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtTopicsDigestAndSearch.Location = new System.Drawing.Point(1, 0);
            this.TxtTopicsDigestAndSearch.Multiline = true;
            this.TxtTopicsDigestAndSearch.Name = "TxtTopicsDigestAndSearch";
            this.TxtTopicsDigestAndSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtTopicsDigestAndSearch.Size = new System.Drawing.Size(316, 69);
            this.TxtTopicsDigestAndSearch.TabIndex = 128;
            this.toolTip1.SetToolTip(this.TxtTopicsDigestAndSearch, "Testo da ricercare negli argomenti OPPURE argomenti selezionati (generati automat" +
        "icamente)");
            // 
            // btnCopyNoteToClipboard
            // 
            this.btnCopyNoteToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyNoteToClipboard.Location = new System.Drawing.Point(673, 67);
            this.btnCopyNoteToClipboard.Name = "btnCopyNoteToClipboard";
            this.btnCopyNoteToClipboard.Size = new System.Drawing.Size(108, 25);
            this.btnCopyNoteToClipboard.TabIndex = 129;
            this.btnCopyNoteToClipboard.Text = "Clipboard";
            this.btnCopyNoteToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyNoteToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // btnStartLinks
            // 
            this.btnStartLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartLinks.Location = new System.Drawing.Point(673, 18);
            this.btnStartLinks.Name = "btnStartLinks";
            this.btnStartLinks.Size = new System.Drawing.Size(108, 25);
            this.btnStartLinks.TabIndex = 131;
            this.btnStartLinks.Text = "Start links";
            this.btnStartLinks.UseVisualStyleBackColor = true;
            this.btnStartLinks.Click += new System.EventHandler(this.btnStartLinks_Click);
            // 
            // txtTopicDescription
            // 
            this.txtTopicDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopicDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTopicDescription.Location = new System.Drawing.Point(0, 2);
            this.txtTopicDescription.Multiline = true;
            this.txtTopicDescription.Name = "txtTopicDescription";
            this.txtTopicDescription.Size = new System.Drawing.Size(448, 104);
            this.txtTopicDescription.TabIndex = 132;
            this.toolTip1.SetToolTip(this.txtTopicDescription, "Descrizione argomenti di lezione");
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(786, 12);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(155, 88);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 133;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            this.picImage.DoubleClick += new System.EventHandler(this.picImage_DoubleClick);
            // 
            // btnManageImages
            // 
            this.btnManageImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManageImages.Location = new System.Drawing.Point(854, 106);
            this.btnManageImages.Name = "btnManageImages";
            this.btnManageImages.Size = new System.Drawing.Size(87, 56);
            this.btnManageImages.TabIndex = 134;
            this.btnManageImages.Text = "Immagini e documenti";
            this.btnManageImages.UseVisualStyleBackColor = true;
            this.btnManageImages.Click += new System.EventHandler(this.btnManageImages_Click);
            // 
            // splitContainerBigVertical
            // 
            this.splitContainerBigVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerBigVertical.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainerBigVertical.Location = new System.Drawing.Point(12, 179);
            this.splitContainerBigVertical.Name = "splitContainerBigVertical";
            // 
            // splitContainerBigVertical.Panel1
            // 
            this.splitContainerBigVertical.Panel1.Controls.Add(this.grpViewTopics);
            this.splitContainerBigVertical.Panel1.Controls.Add(this.splitContainerLeftHorizontal);
            this.splitContainerBigVertical.Panel1.Controls.Add(this.TxtTopicsDigestAndSearch);
            // 
            // splitContainerBigVertical.Panel2
            // 
            this.splitContainerBigVertical.Panel2.Controls.Add(this.splitContainerRightHorizontal);
            this.splitContainerBigVertical.Size = new System.Drawing.Size(775, 480);
            this.splitContainerBigVertical.SplitterDistance = 320;
            this.splitContainerBigVertical.TabIndex = 135;
            // 
            // splitContainerLeftHorizontal
            // 
            this.splitContainerLeftHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerLeftHorizontal.Location = new System.Drawing.Point(0, 68);
            this.splitContainerLeftHorizontal.Name = "splitContainerLeftHorizontal";
            this.splitContainerLeftHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLeftHorizontal.Panel1
            // 
            this.splitContainerLeftHorizontal.Panel1.Controls.Add(this.dgwAllLessons);
            // 
            // splitContainerLeftHorizontal.Panel2
            // 
            this.splitContainerLeftHorizontal.Panel2.Controls.Add(this.dgwOneLesson);
            this.splitContainerLeftHorizontal.Size = new System.Drawing.Size(318, 412);
            this.splitContainerLeftHorizontal.SplitterDistance = 281;
            this.splitContainerLeftHorizontal.TabIndex = 129;
            // 
            // splitContainerRightHorizontal
            // 
            this.splitContainerRightHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerRightHorizontal.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainerRightHorizontal.Location = new System.Drawing.Point(3, 0);
            this.splitContainerRightHorizontal.Name = "splitContainerRightHorizontal";
            this.splitContainerRightHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRightHorizontal.Panel1
            // 
            this.splitContainerRightHorizontal.Panel1.Controls.Add(this.txtTopicName);
            this.splitContainerRightHorizontal.Panel1.Controls.Add(this.trwTopics);
            this.splitContainerRightHorizontal.Panel1.Controls.Add(this.lblExplain);
            // 
            // splitContainerRightHorizontal.Panel2
            // 
            this.splitContainerRightHorizontal.Panel2.Controls.Add(this.txtTopicDescription);
            this.splitContainerRightHorizontal.Size = new System.Drawing.Size(448, 480);
            this.splitContainerRightHorizontal.SplitterDistance = 370;
            this.splitContainerRightHorizontal.TabIndex = 129;
            // 
            // trwTopics
            // 
            this.trwTopics.AllowDrop = true;
            this.trwTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trwTopics.CheckBoxes = true;
            this.trwTopics.LabelEdit = true;
            this.trwTopics.Location = new System.Drawing.Point(0, 0);
            this.trwTopics.Name = "trwTopics";
            this.trwTopics.Size = new System.Drawing.Size(448, 321);
            this.trwTopics.TabIndex = 148;
            // 
            // lblExplain
            // 
            this.lblExplain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExplain.AutoSize = true;
            this.lblExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblExplain.Location = new System.Drawing.Point(3, 324);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(370, 13);
            this.lblExplain.TabIndex = 115;
            this.lblExplain.Text = "Drag -> padre,Ctrl Drag  -> fratello.  F2 modifica. v Argomento  vv Descrizione";
            // 
            // btnTopicsDone
            // 
            this.btnTopicsDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTopicsDone.Location = new System.Drawing.Point(807, 501);
            this.btnTopicsDone.Name = "btnTopicsDone";
            this.btnTopicsDone.Size = new System.Drawing.Size(130, 50);
            this.btnTopicsDone.TabIndex = 137;
            this.btnTopicsDone.Text = "Argomenti fatti";
            this.btnTopicsDone.UseVisualStyleBackColor = true;
            this.btnTopicsDone.Click += new System.EventHandler(this.btnTopicsDone_Click);
            // 
            // bntLessonErase
            // 
            this.bntLessonErase.Location = new System.Drawing.Point(12, 122);
            this.bntLessonErase.Name = "bntLessonErase";
            this.bntLessonErase.Size = new System.Drawing.Size(101, 54);
            this.bntLessonErase.TabIndex = 138;
            this.bntLessonErase.Text = "Elimina lezione";
            this.bntLessonErase.UseVisualStyleBackColor = true;
            this.bntLessonErase.Click += new System.EventHandler(this.bntLessonErase_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(823, 117);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(26, 34);
            this.btnNext.TabIndex = 139;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Location = new System.Drawing.Point(798, 117);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(26, 34);
            this.btnPrevious.TabIndex = 140;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnArgFreemind
            // 
            this.btnArgFreemind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArgFreemind.Location = new System.Drawing.Point(807, 553);
            this.btnArgFreemind.Name = "btnArgFreemind";
            this.btnArgFreemind.Size = new System.Drawing.Size(130, 50);
            this.btnArgFreemind.TabIndex = 141;
            this.btnArgFreemind.Text = "Argom. Freemind";
            this.btnArgFreemind.UseVisualStyleBackColor = true;
            this.btnArgFreemind.Click += new System.EventHandler(this.btnArgFreemind_Click);
            // 
            // lblLessonTime
            // 
            this.lblLessonTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLessonTime.BackColor = System.Drawing.Color.Transparent;
            this.lblLessonTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLessonTime.Enabled = false;
            this.lblLessonTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLessonTime.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLessonTime.Location = new System.Drawing.Point(702, 161);
            this.lblLessonTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLessonTime.Name = "lblLessonTime";
            this.lblLessonTime.Size = new System.Drawing.Size(77, 15);
            this.lblLessonTime.TabIndex = 142;
            this.lblLessonTime.Text = "      ";
            this.toolTip1.SetToolTip(this.lblLessonTime, "Tempo della lezione rimasto");
            // 
            // LessonTimer
            // 
            this.LessonTimer.Tick += new System.EventHandler(this.LessonTimer_Tick);
            // 
            // btnLessonSave
            // 
            this.btnLessonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLessonSave.Location = new System.Drawing.Point(702, 101);
            this.btnLessonSave.Name = "btnLessonSave";
            this.btnLessonSave.Size = new System.Drawing.Size(78, 54);
            this.btnLessonSave.TabIndex = 126;
            this.btnLessonSave.Text = "Salva lezione";
            this.btnLessonSave.UseVisualStyleBackColor = true;
            this.btnLessonSave.Click += new System.EventHandler(this.btnLessonSave_Click);
            // 
            // BtnOpenImagesFolder
            // 
            this.BtnOpenImagesFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOpenImagesFolder.Location = new System.Drawing.Point(559, 18);
            this.BtnOpenImagesFolder.Name = "BtnOpenImagesFolder";
            this.BtnOpenImagesFolder.Size = new System.Drawing.Size(108, 25);
            this.BtnOpenImagesFolder.TabIndex = 144;
            this.BtnOpenImagesFolder.Text = "Cart.immag.";
            this.toolTip1.SetToolTip(this.BtnOpenImagesFolder, "Apre la cartella che include le immagini delle lezioni della classe");
            this.BtnOpenImagesFolder.UseVisualStyleBackColor = true;
            this.BtnOpenImagesFolder.Click += new System.EventHandler(this.BtnOpenImagesFolder_Click);
            // 
            // rdbStringSearch
            // 
            this.rdbStringSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbStringSearch.AutoSize = true;
            this.rdbStringSearch.Checked = true;
            this.rdbStringSearch.Location = new System.Drawing.Point(803, 228);
            this.rdbStringSearch.Name = "rdbStringSearch";
            this.rdbStringSearch.Size = new System.Drawing.Size(46, 22);
            this.rdbStringSearch.TabIndex = 148;
            this.rdbStringSearch.TabStop = true;
            this.rdbStringSearch.Text = "Txt";
            this.toolTip1.SetToolTip(this.rdbStringSearch, "Ricerca per stringa");
            this.rdbStringSearch.UseVisualStyleBackColor = true;
            // 
            // rdbAndSearch
            // 
            this.rdbAndSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbAndSearch.AutoSize = true;
            this.rdbAndSearch.Enabled = false;
            this.rdbAndSearch.Location = new System.Drawing.Point(891, 228);
            this.rdbAndSearch.Name = "rdbAndSearch";
            this.rdbAndSearch.Size = new System.Drawing.Size(50, 22);
            this.rdbAndSearch.TabIndex = 149;
            this.rdbAndSearch.Text = " &&&&";
            this.toolTip1.SetToolTip(this.rdbAndSearch, "Ricerca per parole in And");
            this.rdbAndSearch.UseVisualStyleBackColor = true;
            // 
            // rdbOrSearch
            // 
            this.rdbOrSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbOrSearch.AutoSize = true;
            this.rdbOrSearch.Enabled = false;
            this.rdbOrSearch.Location = new System.Drawing.Point(850, 228);
            this.rdbOrSearch.Name = "rdbOrSearch";
            this.rdbOrSearch.Size = new System.Drawing.Size(40, 22);
            this.rdbOrSearch.TabIndex = 150;
            this.rdbOrSearch.Text = " ||";
            this.toolTip1.SetToolTip(this.rdbOrSearch, "Ricerca per parole in Or");
            this.rdbOrSearch.UseVisualStyleBackColor = true;
            // 
            // btnFindUnderNode
            // 
            this.btnFindUnderNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindUnderNode.Location = new System.Drawing.Point(807, 300);
            this.btnFindUnderNode.Name = "btnFindUnderNode";
            this.btnFindUnderNode.Size = new System.Drawing.Size(130, 45);
            this.btnFindUnderNode.TabIndex = 154;
            this.btnFindUnderNode.Text = "Trova sotto (Shift+F3)";
            this.toolTip1.SetToolTip(this.btnFindUnderNode, "Trova sotto il nodo selezionato");
            this.btnFindUnderNode.UseVisualStyleBackColor = true;
            this.btnFindUnderNode.Click += new System.EventHandler(this.btnFindUnderNode_Click);
            // 
            // BtnSearchAmongTopics
            // 
            this.BtnSearchAmongTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearchAmongTopics.Location = new System.Drawing.Point(559, 67);
            this.BtnSearchAmongTopics.Name = "BtnSearchAmongTopics";
            this.BtnSearchAmongTopics.Size = new System.Drawing.Size(108, 25);
            this.BtnSearchAmongTopics.TabIndex = 143;
            this.BtnSearchAmongTopics.Text = "Cerca";
            this.BtnSearchAmongTopics.UseVisualStyleBackColor = true;
            this.BtnSearchAmongTopics.Click += new System.EventHandler(this.BtnSearchAmongTopics_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.ForeColor = System.Drawing.Color.Red;
            this.btnExport.Location = new System.Drawing.Point(444, 67);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(108, 25);
            this.btnExport.TabIndex = 151;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chkFindAll
            // 
            this.chkFindAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFindAll.AutoSize = true;
            this.chkFindAll.Location = new System.Drawing.Point(887, 166);
            this.chkFindAll.Name = "chkFindAll";
            this.chkFindAll.Size = new System.Drawing.Size(50, 22);
            this.chkFindAll.TabIndex = 152;
            this.chkFindAll.Text = "tutti";
            this.chkFindAll.UseVisualStyleBackColor = true;
            // 
            // btnAddNodeBrother
            // 
            this.btnAddNodeBrother.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNodeBrother.Location = new System.Drawing.Point(807, 450);
            this.btnAddNodeBrother.Name = "btnAddNodeBrother";
            this.btnAddNodeBrother.Size = new System.Drawing.Size(130, 45);
            this.btnAddNodeBrother.TabIndex = 153;
            this.btnAddNodeBrother.Text = "Agg. fratello (Shift+Ins)";
            this.btnAddNodeBrother.UseVisualStyleBackColor = true;
            this.btnAddNodeBrother.Click += new System.EventHandler(this.btnAddNodeBrother_Click);
            // 
            // frmLessons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(945, 667);
            this.Controls.Add(this.btnFindUnderNode);
            this.Controls.Add(this.btnAddNodeBrother);
            this.Controls.Add(this.chkFindAll);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnAddNodeSon);
            this.Controls.Add(this.rdbOrSearch);
            this.Controls.Add(this.rdbAndSearch);
            this.Controls.Add(this.rdbStringSearch);
            this.Controls.Add(this.BtnOpenImagesFolder);
            this.Controls.Add(this.BtnSearchAmongTopics);
            this.Controls.Add(this.lblLessonTime);
            this.Controls.Add(this.btnLessonAdd);
            this.Controls.Add(this.btnLessonSave);
            this.Controls.Add(this.btnArgFreemind);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.bntLessonErase);
            this.Controls.Add(this.btnTopicsDone);
            this.Controls.Add(this.splitContainerBigVertical);
            this.Controls.Add(this.btnManageImages);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.btnStartLinks);
            this.Controls.Add(this.btnCopyNoteToClipboard);
            this.Controls.Add(this.dtpLessonDate);
            this.Controls.Add(this.TxtLessonDesc);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.txtTopicFind);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSaveTree);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLessons";
            this.Text = "Lezioni";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLessons_FormClosed);
            this.Load += new System.EventHandler(this.frmLessons_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLessonsTopics_KeyDown);
            this.grpViewTopics.ResumeLayout(false);
            this.grpViewTopics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOneLesson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAllLessons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.splitContainerBigVertical.Panel1.ResumeLayout(false);
            this.splitContainerBigVertical.Panel1.PerformLayout();
            this.splitContainerBigVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBigVertical)).EndInit();
            this.splitContainerBigVertical.ResumeLayout(false);
            this.splitContainerLeftHorizontal.Panel1.ResumeLayout(false);
            this.splitContainerLeftHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeftHorizontal)).EndInit();
            this.splitContainerLeftHorizontal.ResumeLayout(false);
            this.splitContainerRightHorizontal.Panel1.ResumeLayout(false);
            this.splitContainerRightHorizontal.Panel1.PerformLayout();
            this.splitContainerRightHorizontal.Panel2.ResumeLayout(false);
            this.splitContainerRightHorizontal.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRightHorizontal)).EndInit();
            this.splitContainerRightHorizontal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox TxtTopicsDigestAndSearch;
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
        private System.Windows.Forms.CheckBox chkFindAll;
        private System.Windows.Forms.Button btnAddNodeBrother;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFindUnderNode;
    }
}