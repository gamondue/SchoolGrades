namespace SchoolGrades
{
    partial class frmQuestionChoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuestionChoose));
            grpTopic = new System.Windows.Forms.GroupBox();
            rdbManyTopics = new System.Windows.Forms.RadioButton();
            rdbOneTopic = new System.Windows.Forms.RadioButton();
            btnChooseByPeriod = new System.Windows.Forms.Button();
            btnDontUseTopic = new System.Windows.Forms.Button();
            txtTopicCode = new System.Windows.Forms.TextBox();
            btnChooseTopic = new System.Windows.Forms.Button();
            txtTopic = new System.Windows.Forms.TextBox();
            grpQuestions = new System.Windows.Forms.GroupBox();
            txtWeightInTest = new System.Windows.Forms.TextBox();
            lblWeightInTest = new System.Windows.Forms.Label();
            grpPeriodOfQuestionsTopics = new System.Windows.Forms.GroupBox();
            lblEnd = new System.Windows.Forms.Label();
            lblStart = new System.Windows.Forms.Label();
            dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            rdbAmongPeriod = new System.Windows.Forms.RadioButton();
            cmbSchoolPeriod = new System.Windows.Forms.ComboBox();
            dgwQuestions = new System.Windows.Forms.DataGridView();
            rdbOr = new System.Windows.Forms.RadioButton();
            rdbAnd = new System.Windows.Forms.RadioButton();
            btnRandomQuestion = new System.Windows.Forms.Button();
            btnChoose = new System.Windows.Forms.Button();
            lstTags = new System.Windows.Forms.ListBox();
            btnRemoveTag = new System.Windows.Forms.Button();
            btnAddTag = new System.Windows.Forms.Button();
            lblTags = new System.Windows.Forms.Label();
            btnCopyQuestion = new System.Windows.Forms.Button();
            btnAddQuestion = new System.Windows.Forms.Button();
            cmbQuestionTypes = new System.Windows.Forms.ComboBox();
            cmbSchoolSubject = new System.Windows.Forms.ComboBox();
            lblSchoolSubject = new System.Windows.Forms.Label();
            lblQuestionType = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            LblLessonTime = new System.Windows.Forms.Label();
            btnKnotsToTheComb = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            btnQuestionsDone = new System.Windows.Forms.Button();
            txtSearchText = new System.Windows.Forms.TextBox();
            lblSearchText = new System.Windows.Forms.Label();
            LessonTimer = new System.Windows.Forms.Timer(components);
            grpTopic.SuspendLayout();
            grpQuestions.SuspendLayout();
            grpPeriodOfQuestionsTopics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwQuestions).BeginInit();
            SuspendLayout();
            // 
            // grpTopic
            // 
            grpTopic.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpTopic.Controls.Add(rdbManyTopics);
            grpTopic.Controls.Add(rdbOneTopic);
            grpTopic.Controls.Add(btnChooseByPeriod);
            grpTopic.Controls.Add(btnDontUseTopic);
            grpTopic.Controls.Add(txtTopicCode);
            grpTopic.Controls.Add(btnChooseTopic);
            grpTopic.Controls.Add(txtTopic);
            grpTopic.Location = new System.Drawing.Point(1, 52);
            grpTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpTopic.Name = "grpTopic";
            grpTopic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpTopic.Size = new System.Drawing.Size(1027, 70);
            grpTopic.TabIndex = 4;
            grpTopic.TabStop = false;
            grpTopic.Text = "Argomento per filtro";
            // 
            // rdbManyTopics
            // 
            rdbManyTopics.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rdbManyTopics.AutoSize = true;
            rdbManyTopics.Checked = true;
            rdbManyTopics.Location = new System.Drawing.Point(813, 41);
            rdbManyTopics.Name = "rdbManyTopics";
            rdbManyTopics.Size = new System.Drawing.Size(98, 22);
            rdbManyTopics.TabIndex = 6;
            rdbManyTopics.TabStop = true;
            rdbManyTopics.Text = "Più argom.";
            toolTip1.SetToolTip(rdbManyTopics, "Domande che riguardano tutti gli argomenti sotto a quello scelto");
            rdbManyTopics.UseVisualStyleBackColor = true;
            // 
            // rdbOneTopic
            // 
            rdbOneTopic.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rdbOneTopic.AutoSize = true;
            rdbOneTopic.Location = new System.Drawing.Point(813, 21);
            rdbOneTopic.Name = "rdbOneTopic";
            rdbOneTopic.Size = new System.Drawing.Size(96, 22);
            rdbOneTopic.TabIndex = 5;
            rdbOneTopic.Text = "Un argom.";
            toolTip1.SetToolTip(rdbOneTopic, "Domande che riguardano un singolo argomento");
            rdbOneTopic.UseVisualStyleBackColor = true;
            rdbOneTopic.CheckedChanged += rdbOneTopic_CheckedChanged;
            // 
            // btnChooseByPeriod
            // 
            btnChooseByPeriod.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnChooseByPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            btnChooseByPeriod.Location = new System.Drawing.Point(948, 22);
            btnChooseByPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnChooseByPeriod.Name = "btnChooseByPeriod";
            btnChooseByPeriod.Size = new System.Drawing.Size(34, 34);
            btnChooseByPeriod.TabIndex = 4;
            btnChooseByPeriod.Text = "Per.";
            toolTip1.SetToolTip(btnChooseByPeriod, "Argomenti fatti in un periodo");
            btnChooseByPeriod.UseVisualStyleBackColor = true;
            btnChooseByPeriod.Click += btnChooseByPeriod_Click;
            // 
            // btnDontUseTopic
            // 
            btnDontUseTopic.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDontUseTopic.Location = new System.Drawing.Point(986, 22);
            btnDontUseTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnDontUseTopic.Name = "btnDontUseTopic";
            btnDontUseTopic.Size = new System.Drawing.Size(34, 34);
            btnDontUseTopic.TabIndex = 3;
            btnDontUseTopic.Text = "-";
            toolTip1.SetToolTip(btnDontUseTopic, "Cancella argomento");
            btnDontUseTopic.UseVisualStyleBackColor = true;
            btnDontUseTopic.Click += btnDontUseTopic_Click;
            // 
            // txtTopicCode
            // 
            txtTopicCode.Location = new System.Drawing.Point(6, 27);
            txtTopicCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtTopicCode.Name = "txtTopicCode";
            txtTopicCode.ReadOnly = true;
            txtTopicCode.Size = new System.Drawing.Size(90, 24);
            txtTopicCode.TabIndex = 2;
            txtTopicCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnChooseTopic
            // 
            btnChooseTopic.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnChooseTopic.Location = new System.Drawing.Point(910, 22);
            btnChooseTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnChooseTopic.Name = "btnChooseTopic";
            btnChooseTopic.Size = new System.Drawing.Size(34, 34);
            btnChooseTopic.TabIndex = 1;
            btnChooseTopic.Text = "..";
            toolTip1.SetToolTip(btnChooseTopic, "Scelta argomento fra quelli fatti");
            btnChooseTopic.UseVisualStyleBackColor = true;
            btnChooseTopic.Click += btnChooseTopic_Click;
            // 
            // txtTopic
            // 
            txtTopic.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTopic.Location = new System.Drawing.Point(102, 27);
            txtTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtTopic.Name = "txtTopic";
            txtTopic.Size = new System.Drawing.Size(705, 24);
            txtTopic.TabIndex = 0;
            // 
            // grpQuestions
            // 
            grpQuestions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpQuestions.Controls.Add(txtWeightInTest);
            grpQuestions.Controls.Add(lblWeightInTest);
            grpQuestions.Controls.Add(grpPeriodOfQuestionsTopics);
            grpQuestions.Controls.Add(dgwQuestions);
            grpQuestions.Controls.Add(rdbOr);
            grpQuestions.Controls.Add(rdbAnd);
            grpQuestions.Controls.Add(btnRandomQuestion);
            grpQuestions.Controls.Add(btnChoose);
            grpQuestions.Controls.Add(lstTags);
            grpQuestions.Controls.Add(btnRemoveTag);
            grpQuestions.Controls.Add(btnAddTag);
            grpQuestions.Controls.Add(lblTags);
            grpQuestions.Controls.Add(btnCopyQuestion);
            grpQuestions.Controls.Add(btnAddQuestion);
            grpQuestions.Location = new System.Drawing.Point(1, 130);
            grpQuestions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpQuestions.Name = "grpQuestions";
            grpQuestions.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpQuestions.Size = new System.Drawing.Size(1023, 418);
            grpQuestions.TabIndex = 6;
            grpQuestions.TabStop = false;
            grpQuestions.Text = "Domande";
            // 
            // txtWeightInTest
            // 
            txtWeightInTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtWeightInTest.Location = new System.Drawing.Point(696, 29);
            txtWeightInTest.Name = "txtWeightInTest";
            txtWeightInTest.Size = new System.Drawing.Size(47, 24);
            txtWeightInTest.TabIndex = 150;
            txtWeightInTest.Text = "100";
            // 
            // lblWeightInTest
            // 
            lblWeightInTest.AutoSize = true;
            lblWeightInTest.Location = new System.Drawing.Point(693, 1);
            lblWeightInTest.Name = "lblWeightInTest";
            lblWeightInTest.Size = new System.Drawing.Size(94, 18);
            lblWeightInTest.TabIndex = 149;
            lblWeightInTest.Text = "Peso nel test";
            // 
            // grpPeriodOfQuestionsTopics
            // 
            grpPeriodOfQuestionsTopics.Controls.Add(lblEnd);
            grpPeriodOfQuestionsTopics.Controls.Add(lblStart);
            grpPeriodOfQuestionsTopics.Controls.Add(dtpEndPeriod);
            grpPeriodOfQuestionsTopics.Controls.Add(dtpStartPeriod);
            grpPeriodOfQuestionsTopics.Controls.Add(rdbAmongPeriod);
            grpPeriodOfQuestionsTopics.Controls.Add(cmbSchoolPeriod);
            grpPeriodOfQuestionsTopics.Enabled = false;
            grpPeriodOfQuestionsTopics.Location = new System.Drawing.Point(125, 3);
            grpPeriodOfQuestionsTopics.Name = "grpPeriodOfQuestionsTopics";
            grpPeriodOfQuestionsTopics.Size = new System.Drawing.Size(483, 58);
            grpPeriodOfQuestionsTopics.TabIndex = 145;
            grpPeriodOfQuestionsTopics.TabStop = false;
            grpPeriodOfQuestionsTopics.Text = "Periodo degli argomenti delle domande";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new System.Drawing.Point(168, 29);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new System.Drawing.Size(36, 18);
            lblEnd.TabIndex = 157;
            lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new System.Drawing.Point(7, 29);
            lblStart.Name = "lblStart";
            lblStart.Size = new System.Drawing.Size(42, 18);
            lblStart.TabIndex = 156;
            lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpEndPeriod.Location = new System.Drawing.Point(208, 26);
            dtpEndPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            dtpEndPeriod.Name = "dtpEndPeriod";
            dtpEndPeriod.Size = new System.Drawing.Size(111, 24);
            dtpEndPeriod.TabIndex = 155;
            dtpEndPeriod.ValueChanged += dtpEndPeriod_ValueChanged;
            // 
            // dtpStartPeriod
            // 
            dtpStartPeriod.CustomFormat = "yyyy-MM-dd";
            dtpStartPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpStartPeriod.Location = new System.Drawing.Point(51, 26);
            dtpStartPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            dtpStartPeriod.Name = "dtpStartPeriod";
            dtpStartPeriod.Size = new System.Drawing.Size(111, 24);
            dtpStartPeriod.TabIndex = 154;
            // 
            // rdbAmongPeriod
            // 
            rdbAmongPeriod.AutoSize = true;
            rdbAmongPeriod.Enabled = false;
            rdbAmongPeriod.Location = new System.Drawing.Point(7, 62);
            rdbAmongPeriod.Name = "rdbAmongPeriod";
            rdbAmongPeriod.Size = new System.Drawing.Size(111, 22);
            rdbAmongPeriod.TabIndex = 2;
            rdbAmongPeriod.Text = "in un periodo";
            rdbAmongPeriod.UseVisualStyleBackColor = true;
            rdbAmongPeriod.Visible = false;
            // 
            // cmbSchoolPeriod
            // 
            cmbSchoolPeriod.FormattingEnabled = true;
            cmbSchoolPeriod.Items.AddRange(new object[] { "", "Settimana", "Mese", "Anno scolastico", "Da nuovo anno solare" });
            cmbSchoolPeriod.Location = new System.Drawing.Point(325, 24);
            cmbSchoolPeriod.Name = "cmbSchoolPeriod";
            cmbSchoolPeriod.Size = new System.Drawing.Size(149, 26);
            cmbSchoolPeriod.TabIndex = 153;
            cmbSchoolPeriod.SelectedIndexChanged += cmbSchoolPeriod_SelectedIndexChanged;
            // 
            // dgwQuestions
            // 
            dgwQuestions.AllowUserToAddRows = false;
            dgwQuestions.AllowUserToDeleteRows = false;
            dgwQuestions.AllowUserToOrderColumns = true;
            dgwQuestions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwQuestions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgwQuestions.Location = new System.Drawing.Point(6, 67);
            dgwQuestions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dgwQuestions.Name = "dgwQuestions";
            dgwQuestions.RowTemplate.Height = 24;
            dgwQuestions.Size = new System.Drawing.Size(815, 341);
            dgwQuestions.TabIndex = 0;
            dgwQuestions.CellClick += dgwQuestions_CellClick;
            dgwQuestions.CellContentClick += dgwQuestions_CellContentClick;
            dgwQuestions.CellDoubleClick += dgwQuestions_CellDoubleClick;
            // 
            // rdbOr
            // 
            rdbOr.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rdbOr.AutoSize = true;
            rdbOr.Checked = true;
            rdbOr.Location = new System.Drawing.Point(827, 24);
            rdbOr.Name = "rdbOr";
            rdbOr.Size = new System.Drawing.Size(78, 22);
            rdbOr.TabIndex = 8;
            rdbOr.TabStop = true;
            rdbOr.Text = "Tag OR";
            toolTip1.SetToolTip(rdbOr, "Trova tutte le domade che hanno almeno uno  dei tag elencati");
            rdbOr.UseVisualStyleBackColor = true;
            rdbOr.CheckedChanged += rdbOr_CheckedChanged;
            // 
            // rdbAnd
            // 
            rdbAnd.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rdbAnd.AutoSize = true;
            rdbAnd.Location = new System.Drawing.Point(934, 24);
            rdbAnd.Name = "rdbAnd";
            rdbAnd.Size = new System.Drawing.Size(86, 22);
            rdbAnd.TabIndex = 7;
            rdbAnd.Text = "Tag AND";
            toolTip1.SetToolTip(rdbAnd, "Trova tutte le domade che hanno TUTTI i tag elencati");
            rdbAnd.UseVisualStyleBackColor = true;
            // 
            // btnRandomQuestion
            // 
            btnRandomQuestion.Location = new System.Drawing.Point(614, 21);
            btnRandomQuestion.Name = "btnRandomQuestion";
            btnRandomQuestion.Size = new System.Drawing.Size(77, 40);
            btnRandomQuestion.TabIndex = 144;
            btnRandomQuestion.Text = "Casuale";
            btnRandomQuestion.UseVisualStyleBackColor = true;
            btnRandomQuestion.Click += btnRandomQuestion_Click;
            // 
            // btnChoose
            // 
            btnChoose.Location = new System.Drawing.Point(749, 21);
            btnChoose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(72, 40);
            btnChoose.TabIndex = 109;
            btnChoose.Text = "Scegli";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click;
            // 
            // lstTags
            // 
            lstTags.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lstTags.FormattingEnabled = true;
            lstTags.Location = new System.Drawing.Point(824, 80);
            lstTags.Name = "lstTags";
            lstTags.Size = new System.Drawing.Size(196, 328);
            lstTags.TabIndex = 108;
            // 
            // btnRemoveTag
            // 
            btnRemoveTag.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRemoveTag.Location = new System.Drawing.Point(986, 45);
            btnRemoveTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnRemoveTag.Name = "btnRemoveTag";
            btnRemoveTag.Size = new System.Drawing.Size(34, 33);
            btnRemoveTag.TabIndex = 107;
            btnRemoveTag.Text = "-";
            btnRemoveTag.UseVisualStyleBackColor = true;
            btnRemoveTag.Click += btnRemoveTag_Click;
            // 
            // btnAddTag
            // 
            btnAddTag.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddTag.Location = new System.Drawing.Point(946, 45);
            btnAddTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAddTag.Name = "btnAddTag";
            btnAddTag.Size = new System.Drawing.Size(34, 33);
            btnAddTag.TabIndex = 1;
            btnAddTag.Text = "+";
            btnAddTag.UseVisualStyleBackColor = true;
            btnAddTag.Click += btnAddTag_Click;
            // 
            // lblTags
            // 
            lblTags.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblTags.AutoSize = true;
            lblTags.Location = new System.Drawing.Point(821, 52);
            lblTags.Name = "lblTags";
            lblTags.Size = new System.Drawing.Size(98, 18);
            lblTags.TabIndex = 105;
            lblTags.Text = "Tags per filtro";
            // 
            // btnCopyQuestion
            // 
            btnCopyQuestion.Location = new System.Drawing.Point(48, 21);
            btnCopyQuestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnCopyQuestion.Name = "btnCopyQuestion";
            btnCopyQuestion.Size = new System.Drawing.Size(71, 40);
            btnCopyQuestion.TabIndex = 106;
            btnCopyQuestion.Text = "copia";
            btnCopyQuestion.UseVisualStyleBackColor = true;
            btnCopyQuestion.Click += btnCopyQuestion_Click;
            // 
            // btnAddQuestion
            // 
            btnAddQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnAddQuestion.Location = new System.Drawing.Point(6, 21);
            btnAddQuestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAddQuestion.Name = "btnAddQuestion";
            btnAddQuestion.Size = new System.Drawing.Size(36, 40);
            btnAddQuestion.TabIndex = 2;
            btnAddQuestion.Text = "+";
            btnAddQuestion.UseVisualStyleBackColor = true;
            btnAddQuestion.Click += btnAddQuestion_Click;
            // 
            // cmbQuestionTypes
            // 
            cmbQuestionTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbQuestionTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            cmbQuestionTypes.FormattingEnabled = true;
            cmbQuestionTypes.Location = new System.Drawing.Point(246, 27);
            cmbQuestionTypes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cmbQuestionTypes.Name = "cmbQuestionTypes";
            cmbQuestionTypes.Size = new System.Drawing.Size(233, 26);
            cmbQuestionTypes.TabIndex = 104;
            cmbQuestionTypes.SelectedIndexChanged += cmbQuestionType_SelectedIndexChanged;
            // 
            // cmbSchoolSubject
            // 
            cmbSchoolSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSchoolSubject.FormattingEnabled = true;
            cmbSchoolSubject.Location = new System.Drawing.Point(7, 27);
            cmbSchoolSubject.Name = "cmbSchoolSubject";
            cmbSchoolSubject.Size = new System.Drawing.Size(233, 26);
            cmbSchoolSubject.TabIndex = 2;
            cmbSchoolSubject.SelectedIndexChanged += cmbSchoolSubject_SelectedIndexChanged;
            // 
            // lblSchoolSubject
            // 
            lblSchoolSubject.AutoSize = true;
            lblSchoolSubject.Location = new System.Drawing.Point(4, 6);
            lblSchoolSubject.Name = "lblSchoolSubject";
            lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            lblSchoolSubject.TabIndex = 3;
            lblSchoolSubject.Text = "Materia";
            // 
            // lblQuestionType
            // 
            lblQuestionType.AutoSize = true;
            lblQuestionType.Location = new System.Drawing.Point(243, 6);
            lblQuestionType.Name = "lblQuestionType";
            lblQuestionType.Size = new System.Drawing.Size(103, 18);
            lblQuestionType.TabIndex = 7;
            lblQuestionType.Text = "Tipo domanda";
            // 
            // LblLessonTime
            // 
            LblLessonTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            LblLessonTime.BackColor = System.Drawing.Color.Transparent;
            LblLessonTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            LblLessonTime.Enabled = false;
            LblLessonTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            LblLessonTime.ForeColor = System.Drawing.Color.DarkBlue;
            LblLessonTime.Location = new System.Drawing.Point(940, 126);
            LblLessonTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblLessonTime.Name = "LblLessonTime";
            LblLessonTime.Size = new System.Drawing.Size(77, 15);
            LblLessonTime.TabIndex = 143;
            LblLessonTime.Text = "      ";
            toolTip1.SetToolTip(LblLessonTime, "Tempo della lezione rimasto");
            // 
            // btnKnotsToTheComb
            // 
            btnKnotsToTheComb.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnKnotsToTheComb.BackColor = System.Drawing.Color.Transparent;
            btnKnotsToTheComb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            btnKnotsToTheComb.ForeColor = System.Drawing.Color.DarkBlue;
            btnKnotsToTheComb.Location = new System.Drawing.Point(886, 22);
            btnKnotsToTheComb.Margin = new System.Windows.Forms.Padding(6);
            btnKnotsToTheComb.Name = "btnKnotsToTheComb";
            btnKnotsToTheComb.Size = new System.Drawing.Size(70, 37);
            btnKnotsToTheComb.TabIndex = 119;
            btnKnotsToTheComb.Text = "Pettine";
            toolTip1.SetToolTip(btnKnotsToTheComb, "Domande che hanno un voto insufficiente");
            btnKnotsToTheComb.UseVisualStyleBackColor = false;
            btnKnotsToTheComb.Click += btnKnotsToTheComb_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSearch.BackColor = System.Drawing.Color.Transparent;
            btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            btnSearch.ForeColor = System.Drawing.Color.DarkBlue;
            btnSearch.Location = new System.Drawing.Point(814, 22);
            btnSearch.Margin = new System.Windows.Forms.Padding(6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(70, 37);
            btnSearch.TabIndex = 144;
            btnSearch.Text = "Cerca";
            toolTip1.SetToolTip(btnSearch, "Cerca fra le domande filtrate, della materia richiesta e non chieste nel periodo indicato");
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnQuestionsDone
            // 
            btnQuestionsDone.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnQuestionsDone.BackColor = System.Drawing.Color.Transparent;
            btnQuestionsDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            btnQuestionsDone.ForeColor = System.Drawing.Color.DarkBlue;
            btnQuestionsDone.Location = new System.Drawing.Point(958, 22);
            btnQuestionsDone.Margin = new System.Windows.Forms.Padding(6);
            btnQuestionsDone.Name = "btnQuestionsDone";
            btnQuestionsDone.Size = new System.Drawing.Size(70, 37);
            btnQuestionsDone.TabIndex = 145;
            btnQuestionsDone.Text = "Fatte";
            toolTip1.SetToolTip(btnQuestionsDone, "Trova domande già fatte nel periodo indicato");
            btnQuestionsDone.UseVisualStyleBackColor = false;
            btnQuestionsDone.Click += btnQuestionsDone_Click;
            // 
            // txtSearchText
            // 
            txtSearchText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtSearchText.Location = new System.Drawing.Point(485, 28);
            txtSearchText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtSearchText.Name = "txtSearchText";
            txtSearchText.Size = new System.Drawing.Size(323, 24);
            txtSearchText.TabIndex = 7;
            txtSearchText.TextChanged += txtSearchText_TextChanged;
            // 
            // lblSearchText
            // 
            lblSearchText.AutoSize = true;
            lblSearchText.Location = new System.Drawing.Point(482, 5);
            lblSearchText.Name = "lblSearchText";
            lblSearchText.Size = new System.Drawing.Size(128, 18);
            lblSearchText.TabIndex = 105;
            lblSearchText.Text = "Testo da ricercare";
            // 
            // LessonTimer
            // 
            LessonTimer.Interval = 1000;
            LessonTimer.Tick += LessonTimer_Tick;
            // 
            // frmQuestionChoose
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(1030, 547);
            Controls.Add(btnQuestionsDone);
            Controls.Add(btnSearch);
            Controls.Add(LblLessonTime);
            Controls.Add(btnKnotsToTheComb);
            Controls.Add(lblSearchText);
            Controls.Add(txtSearchText);
            Controls.Add(lblQuestionType);
            Controls.Add(lblSchoolSubject);
            Controls.Add(cmbQuestionTypes);
            Controls.Add(cmbSchoolSubject);
            Controls.Add(grpQuestions);
            Controls.Add(grpTopic);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmQuestionChoose";
            Text = "Scelta domanda";
            Load += frmQuestionChoose_Load;
            grpTopic.ResumeLayout(false);
            grpTopic.PerformLayout();
            grpQuestions.ResumeLayout(false);
            grpQuestions.PerformLayout();
            grpPeriodOfQuestionsTopics.ResumeLayout(false);
            grpPeriodOfQuestionsTopics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwQuestions).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpTopic;
        private System.Windows.Forms.Button btnChooseTopic;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.GroupBox grpQuestions;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.DataGridView dgwQuestions;
        private System.Windows.Forms.ComboBox cmbQuestionTypes;
        private System.Windows.Forms.Button btnCopyQuestion;
        private System.Windows.Forms.ComboBox cmbSchoolSubject;
        private System.Windows.Forms.Label lblSchoolSubject;
        private System.Windows.Forms.Label lblQuestionType;
        private System.Windows.Forms.Button btnRemoveTag;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnDontUseTopic;
        private System.Windows.Forms.TextBox txtTopicCode;
        private System.Windows.Forms.Button btnChooseByPeriod;
        private System.Windows.Forms.Button btnRandomQuestion;
        private System.Windows.Forms.RadioButton rdbManyTopics;
        private System.Windows.Forms.RadioButton rdbOneTopic;
        private System.Windows.Forms.RadioButton rdbOr;
        private System.Windows.Forms.RadioButton rdbAnd;
        private System.Windows.Forms.GroupBox grpPeriodOfQuestionsTopics;
        private System.Windows.Forms.RadioButton rdbAmongPeriod;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbSchoolPeriod;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpEndPeriod;
        private System.Windows.Forms.DateTimePicker dtpStartPeriod;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Label lblSearchText;
        private System.Windows.Forms.Button btnKnotsToTheComb;
        private System.Windows.Forms.Label LblLessonTime;
        private System.Windows.Forms.Timer LessonTimer;
        private System.Windows.Forms.TextBox txtWeightInTest;
        private System.Windows.Forms.Label lblWeightInTest;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnQuestionsDone;
    }
}