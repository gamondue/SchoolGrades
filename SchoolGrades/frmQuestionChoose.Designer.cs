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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuestionChoose));
            this.grpTopic = new System.Windows.Forms.GroupBox();
            this.rdbManyTopics = new System.Windows.Forms.RadioButton();
            this.rdbOneTopic = new System.Windows.Forms.RadioButton();
            this.btnChooseByPeriod = new System.Windows.Forms.Button();
            this.btnDontUseTopic = new System.Windows.Forms.Button();
            this.txtTopicCode = new System.Windows.Forms.TextBox();
            this.btnChooseTopic = new System.Windows.Forms.Button();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.grpQuestions = new System.Windows.Forms.GroupBox();
            this.txtWeightInTest = new System.Windows.Forms.TextBox();
            this.lblWeightInTest = new System.Windows.Forms.Label();
            this.grpPeriodOfQuestionsTopics = new System.Windows.Forms.GroupBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            this.dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            this.rdbAmongPeriod = new System.Windows.Forms.RadioButton();
            this.cmbStandardPeriod = new System.Windows.Forms.ComboBox();
            this.dgwQuestions = new System.Windows.Forms.DataGridView();
            this.rdbOr = new System.Windows.Forms.RadioButton();
            this.rdbAnd = new System.Windows.Forms.RadioButton();
            this.btnRandomQuestion = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.btnRemoveTag = new System.Windows.Forms.Button();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.lblTags = new System.Windows.Forms.Label();
            this.btnCopyQuestion = new System.Windows.Forms.Button();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.cmbQuestionTypes = new System.Windows.Forms.ComboBox();
            this.cmbSchoolSubject = new System.Windows.Forms.ComboBox();
            this.lblSchoolSubject = new System.Windows.Forms.Label();
            this.lblQuestionType = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LblLessonTime = new System.Windows.Forms.Label();
            this.btnComb = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.lblSearchText = new System.Windows.Forms.Label();
            this.LessonTimer = new System.Windows.Forms.Timer(this.components);
            this.grpTopic.SuspendLayout();
            this.grpQuestions.SuspendLayout();
            this.grpPeriodOfQuestionsTopics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTopic
            // 
            this.grpTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTopic.Controls.Add(this.rdbManyTopics);
            this.grpTopic.Controls.Add(this.rdbOneTopic);
            this.grpTopic.Controls.Add(this.btnChooseByPeriod);
            this.grpTopic.Controls.Add(this.btnDontUseTopic);
            this.grpTopic.Controls.Add(this.txtTopicCode);
            this.grpTopic.Controls.Add(this.btnChooseTopic);
            this.grpTopic.Controls.Add(this.txtTopic);
            this.grpTopic.Location = new System.Drawing.Point(1, 52);
            this.grpTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTopic.Name = "grpTopic";
            this.grpTopic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTopic.Size = new System.Drawing.Size(1027, 70);
            this.grpTopic.TabIndex = 4;
            this.grpTopic.TabStop = false;
            this.grpTopic.Text = "Argomento per filtro";
            // 
            // rdbManyTopics
            // 
            this.rdbManyTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbManyTopics.AutoSize = true;
            this.rdbManyTopics.Checked = true;
            this.rdbManyTopics.Location = new System.Drawing.Point(813, 41);
            this.rdbManyTopics.Name = "rdbManyTopics";
            this.rdbManyTopics.Size = new System.Drawing.Size(98, 22);
            this.rdbManyTopics.TabIndex = 6;
            this.rdbManyTopics.TabStop = true;
            this.rdbManyTopics.Text = "Più argom.";
            this.toolTip1.SetToolTip(this.rdbManyTopics, "Domande che riguardano tutti gli argomenti sotto a quello scelto");
            this.rdbManyTopics.UseVisualStyleBackColor = true;
            // 
            // rdbOneTopic
            // 
            this.rdbOneTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbOneTopic.AutoSize = true;
            this.rdbOneTopic.Location = new System.Drawing.Point(813, 21);
            this.rdbOneTopic.Name = "rdbOneTopic";
            this.rdbOneTopic.Size = new System.Drawing.Size(96, 22);
            this.rdbOneTopic.TabIndex = 5;
            this.rdbOneTopic.Text = "Un argom.";
            this.toolTip1.SetToolTip(this.rdbOneTopic, "Domande che riguardano un singolo argomento");
            this.rdbOneTopic.UseVisualStyleBackColor = true;
            this.rdbOneTopic.CheckedChanged += new System.EventHandler(this.rdbOneTopic_CheckedChanged);
            // 
            // btnChooseByPeriod
            // 
            this.btnChooseByPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseByPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChooseByPeriod.Location = new System.Drawing.Point(948, 22);
            this.btnChooseByPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseByPeriod.Name = "btnChooseByPeriod";
            this.btnChooseByPeriod.Size = new System.Drawing.Size(34, 34);
            this.btnChooseByPeriod.TabIndex = 4;
            this.btnChooseByPeriod.Text = "Per.";
            this.toolTip1.SetToolTip(this.btnChooseByPeriod, "Argomenti fatti in un periodo");
            this.btnChooseByPeriod.UseVisualStyleBackColor = true;
            this.btnChooseByPeriod.Click += new System.EventHandler(this.btnChooseByPeriod_Click);
            // 
            // btnDontUseTopic
            // 
            this.btnDontUseTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDontUseTopic.Location = new System.Drawing.Point(986, 22);
            this.btnDontUseTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDontUseTopic.Name = "btnDontUseTopic";
            this.btnDontUseTopic.Size = new System.Drawing.Size(34, 34);
            this.btnDontUseTopic.TabIndex = 3;
            this.btnDontUseTopic.Text = "-";
            this.btnDontUseTopic.UseVisualStyleBackColor = true;
            this.btnDontUseTopic.Click += new System.EventHandler(this.btnDontUseTopic_Click);
            // 
            // txtTopicCode
            // 
            this.txtTopicCode.Location = new System.Drawing.Point(6, 27);
            this.txtTopicCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTopicCode.Name = "txtTopicCode";
            this.txtTopicCode.ReadOnly = true;
            this.txtTopicCode.Size = new System.Drawing.Size(90, 24);
            this.txtTopicCode.TabIndex = 2;
            this.txtTopicCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnChooseTopic
            // 
            this.btnChooseTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseTopic.Location = new System.Drawing.Point(910, 22);
            this.btnChooseTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseTopic.Name = "btnChooseTopic";
            this.btnChooseTopic.Size = new System.Drawing.Size(34, 34);
            this.btnChooseTopic.TabIndex = 1;
            this.btnChooseTopic.Text = "..";
            this.btnChooseTopic.UseVisualStyleBackColor = true;
            this.btnChooseTopic.Click += new System.EventHandler(this.btnChooseTopic_Click);
            // 
            // txtTopic
            // 
            this.txtTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopic.Location = new System.Drawing.Point(102, 27);
            this.txtTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(694, 24);
            this.txtTopic.TabIndex = 0;
            // 
            // grpQuestions
            // 
            this.grpQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpQuestions.Controls.Add(this.txtWeightInTest);
            this.grpQuestions.Controls.Add(this.lblWeightInTest);
            this.grpQuestions.Controls.Add(this.grpPeriodOfQuestionsTopics);
            this.grpQuestions.Controls.Add(this.dgwQuestions);
            this.grpQuestions.Controls.Add(this.rdbOr);
            this.grpQuestions.Controls.Add(this.rdbAnd);
            this.grpQuestions.Controls.Add(this.btnRandomQuestion);
            this.grpQuestions.Controls.Add(this.btnChoose);
            this.grpQuestions.Controls.Add(this.lstTags);
            this.grpQuestions.Controls.Add(this.btnRemoveTag);
            this.grpQuestions.Controls.Add(this.btnAddTag);
            this.grpQuestions.Controls.Add(this.lblTags);
            this.grpQuestions.Controls.Add(this.btnCopyQuestion);
            this.grpQuestions.Controls.Add(this.btnAddQuestion);
            this.grpQuestions.Location = new System.Drawing.Point(1, 130);
            this.grpQuestions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpQuestions.Name = "grpQuestions";
            this.grpQuestions.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpQuestions.Size = new System.Drawing.Size(1023, 418);
            this.grpQuestions.TabIndex = 6;
            this.grpQuestions.TabStop = false;
            this.grpQuestions.Text = "Domande";
            // 
            // txtWeightInTest
            // 
            this.txtWeightInTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeightInTest.Location = new System.Drawing.Point(696, 29);
            this.txtWeightInTest.Name = "txtWeightInTest";
            this.txtWeightInTest.Size = new System.Drawing.Size(58, 24);
            this.txtWeightInTest.TabIndex = 150;
            this.txtWeightInTest.Text = "100";
            // 
            // lblWeightInTest
            // 
            this.lblWeightInTest.AutoSize = true;
            this.lblWeightInTest.Location = new System.Drawing.Point(693, 1);
            this.lblWeightInTest.Name = "lblWeightInTest";
            this.lblWeightInTest.Size = new System.Drawing.Size(94, 18);
            this.lblWeightInTest.TabIndex = 149;
            this.lblWeightInTest.Text = "Peso nel test";
            // 
            // grpPeriodOfQuestionsTopics
            // 
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.lblEnd);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.lblStart);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.dtpEndPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.dtpStartPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.rdbAmongPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.cmbStandardPeriod);
            this.grpPeriodOfQuestionsTopics.Location = new System.Drawing.Point(125, 3);
            this.grpPeriodOfQuestionsTopics.Name = "grpPeriodOfQuestionsTopics";
            this.grpPeriodOfQuestionsTopics.Size = new System.Drawing.Size(483, 58);
            this.grpPeriodOfQuestionsTopics.TabIndex = 145;
            this.grpPeriodOfQuestionsTopics.TabStop = false;
            this.grpPeriodOfQuestionsTopics.Text = "Periodo degli argomenti delle domande";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(168, 29);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(36, 18);
            this.lblEnd.TabIndex = 157;
            this.lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(7, 29);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(42, 18);
            this.lblStart.TabIndex = 156;
            this.lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            this.dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            this.dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndPeriod.Location = new System.Drawing.Point(208, 26);
            this.dtpEndPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtpEndPeriod.Name = "dtpEndPeriod";
            this.dtpEndPeriod.Size = new System.Drawing.Size(111, 24);
            this.dtpEndPeriod.TabIndex = 155;
            this.dtpEndPeriod.ValueChanged += new System.EventHandler(this.dtpEndPeriod_ValueChanged);
            // 
            // dtpStartPeriod
            // 
            this.dtpStartPeriod.CustomFormat = "yyyy-MM-dd";
            this.dtpStartPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartPeriod.Location = new System.Drawing.Point(51, 26);
            this.dtpStartPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtpStartPeriod.Name = "dtpStartPeriod";
            this.dtpStartPeriod.Size = new System.Drawing.Size(111, 24);
            this.dtpStartPeriod.TabIndex = 154;
            // 
            // rdbAmongPeriod
            // 
            this.rdbAmongPeriod.AutoSize = true;
            this.rdbAmongPeriod.Enabled = false;
            this.rdbAmongPeriod.Location = new System.Drawing.Point(7, 62);
            this.rdbAmongPeriod.Name = "rdbAmongPeriod";
            this.rdbAmongPeriod.Size = new System.Drawing.Size(111, 22);
            this.rdbAmongPeriod.TabIndex = 2;
            this.rdbAmongPeriod.Text = "in un periodo";
            this.rdbAmongPeriod.UseVisualStyleBackColor = true;
            this.rdbAmongPeriod.Visible = false;
            // 
            // cmbStandardPeriod
            // 
            this.cmbStandardPeriod.FormattingEnabled = true;
            this.cmbStandardPeriod.Items.AddRange(new object[] {
            "",
            "Settimana",
            "Mese",
            "Anno scolastico",
            "Da nuovo anno solare"});
            this.cmbStandardPeriod.Location = new System.Drawing.Point(325, 24);
            this.cmbStandardPeriod.Name = "cmbStandardPeriod";
            this.cmbStandardPeriod.Size = new System.Drawing.Size(149, 26);
            this.cmbStandardPeriod.TabIndex = 153;
            this.cmbStandardPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbStandardPeriod_SelectedIndexChanged);
            // 
            // dgwQuestions
            // 
            this.dgwQuestions.AllowUserToAddRows = false;
            this.dgwQuestions.AllowUserToDeleteRows = false;
            this.dgwQuestions.AllowUserToOrderColumns = true;
            this.dgwQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwQuestions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwQuestions.Location = new System.Drawing.Point(6, 67);
            this.dgwQuestions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwQuestions.Name = "dgwQuestions";
            this.dgwQuestions.RowTemplate.Height = 24;
            this.dgwQuestions.Size = new System.Drawing.Size(815, 341);
            this.dgwQuestions.TabIndex = 0;
            this.dgwQuestions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwQuestions_CellClick);
            this.dgwQuestions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwQuestions_CellContentClick);
            this.dgwQuestions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwQuestions_CellDoubleClick);
            // 
            // rdbOr
            // 
            this.rdbOr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbOr.AutoSize = true;
            this.rdbOr.Checked = true;
            this.rdbOr.Location = new System.Drawing.Point(827, 24);
            this.rdbOr.Name = "rdbOr";
            this.rdbOr.Size = new System.Drawing.Size(78, 22);
            this.rdbOr.TabIndex = 8;
            this.rdbOr.TabStop = true;
            this.rdbOr.Text = "Tag OR";
            this.toolTip1.SetToolTip(this.rdbOr, "Trova tutte le domade che hanno almeno uno  dei tag elencati");
            this.rdbOr.UseVisualStyleBackColor = true;
            this.rdbOr.CheckedChanged += new System.EventHandler(this.rdbOr_CheckedChanged);
            // 
            // rdbAnd
            // 
            this.rdbAnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbAnd.AutoSize = true;
            this.rdbAnd.Location = new System.Drawing.Point(934, 24);
            this.rdbAnd.Name = "rdbAnd";
            this.rdbAnd.Size = new System.Drawing.Size(86, 22);
            this.rdbAnd.TabIndex = 7;
            this.rdbAnd.Text = "Tag AND";
            this.toolTip1.SetToolTip(this.rdbAnd, "Trova tutte le domade che hanno TUTTI i tag elencati");
            this.rdbAnd.UseVisualStyleBackColor = true;
            // 
            // btnRandomQuestion
            // 
            this.btnRandomQuestion.Location = new System.Drawing.Point(614, 21);
            this.btnRandomQuestion.Name = "btnRandomQuestion";
            this.btnRandomQuestion.Size = new System.Drawing.Size(77, 40);
            this.btnRandomQuestion.TabIndex = 144;
            this.btnRandomQuestion.Text = "Casuale";
            this.btnRandomQuestion.UseVisualStyleBackColor = true;
            this.btnRandomQuestion.Click += new System.EventHandler(this.btnRandomQuestion_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(760, 21);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(61, 40);
            this.btnChoose.TabIndex = 109;
            this.btnChoose.Text = "Scegli";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // lstTags
            // 
            this.lstTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTags.FormattingEnabled = true;
            this.lstTags.ItemHeight = 18;
            this.lstTags.Location = new System.Drawing.Point(824, 80);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(196, 328);
            this.lstTags.TabIndex = 108;
            // 
            // btnRemoveTag
            // 
            this.btnRemoveTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveTag.Location = new System.Drawing.Point(986, 45);
            this.btnRemoveTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveTag.Name = "btnRemoveTag";
            this.btnRemoveTag.Size = new System.Drawing.Size(34, 33);
            this.btnRemoveTag.TabIndex = 107;
            this.btnRemoveTag.Text = "-";
            this.btnRemoveTag.UseVisualStyleBackColor = true;
            this.btnRemoveTag.Click += new System.EventHandler(this.btnRemoveTag_Click);
            // 
            // btnAddTag
            // 
            this.btnAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTag.Location = new System.Drawing.Point(946, 45);
            this.btnAddTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(34, 33);
            this.btnAddTag.TabIndex = 1;
            this.btnAddTag.Text = "+";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // lblTags
            // 
            this.lblTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(821, 52);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(98, 18);
            this.lblTags.TabIndex = 105;
            this.lblTags.Text = "Tags per filtro";
            // 
            // btnCopyQuestion
            // 
            this.btnCopyQuestion.Location = new System.Drawing.Point(48, 21);
            this.btnCopyQuestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCopyQuestion.Name = "btnCopyQuestion";
            this.btnCopyQuestion.Size = new System.Drawing.Size(71, 40);
            this.btnCopyQuestion.TabIndex = 106;
            this.btnCopyQuestion.Text = "copia";
            this.btnCopyQuestion.UseVisualStyleBackColor = true;
            this.btnCopyQuestion.Click += new System.EventHandler(this.btnCopyQuestion_Click);
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddQuestion.Location = new System.Drawing.Point(6, 21);
            this.btnAddQuestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(36, 40);
            this.btnAddQuestion.TabIndex = 2;
            this.btnAddQuestion.Text = "+";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // cmbQuestionTypes
            // 
            this.cmbQuestionTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbQuestionTypes.FormattingEnabled = true;
            this.cmbQuestionTypes.Location = new System.Drawing.Point(253, 27);
            this.cmbQuestionTypes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbQuestionTypes.Name = "cmbQuestionTypes";
            this.cmbQuestionTypes.Size = new System.Drawing.Size(233, 26);
            this.cmbQuestionTypes.TabIndex = 104;
            this.cmbQuestionTypes.SelectedIndexChanged += new System.EventHandler(this.cmbQuestionType_SelectedIndexChanged);
            // 
            // cmbSchoolSubject
            // 
            this.cmbSchoolSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchoolSubject.FormattingEnabled = true;
            this.cmbSchoolSubject.Location = new System.Drawing.Point(7, 27);
            this.cmbSchoolSubject.Name = "cmbSchoolSubject";
            this.cmbSchoolSubject.Size = new System.Drawing.Size(233, 26);
            this.cmbSchoolSubject.TabIndex = 2;
            this.cmbSchoolSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolSubject_SelectedIndexChanged);
            // 
            // lblSchoolSubject
            // 
            this.lblSchoolSubject.AutoSize = true;
            this.lblSchoolSubject.Location = new System.Drawing.Point(4, 6);
            this.lblSchoolSubject.Name = "lblSchoolSubject";
            this.lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            this.lblSchoolSubject.TabIndex = 3;
            this.lblSchoolSubject.Text = "Materia";
            // 
            // lblQuestionType
            // 
            this.lblQuestionType.AutoSize = true;
            this.lblQuestionType.Location = new System.Drawing.Point(250, 6);
            this.lblQuestionType.Name = "lblQuestionType";
            this.lblQuestionType.Size = new System.Drawing.Size(103, 18);
            this.lblQuestionType.TabIndex = 7;
            this.lblQuestionType.Text = "Tipo domanda";
            // 
            // LblLessonTime
            // 
            this.LblLessonTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblLessonTime.BackColor = System.Drawing.Color.Transparent;
            this.LblLessonTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLessonTime.Enabled = false;
            this.LblLessonTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblLessonTime.ForeColor = System.Drawing.Color.DarkBlue;
            this.LblLessonTime.Location = new System.Drawing.Point(940, 126);
            this.LblLessonTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblLessonTime.Name = "LblLessonTime";
            this.LblLessonTime.Size = new System.Drawing.Size(77, 15);
            this.LblLessonTime.TabIndex = 143;
            this.LblLessonTime.Text = "      ";
            this.toolTip1.SetToolTip(this.LblLessonTime, "Tempo della lezione rimasto");
            // 
            // btnComb
            // 
            this.btnComb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComb.BackColor = System.Drawing.Color.Transparent;
            this.btnComb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnComb.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnComb.Location = new System.Drawing.Point(949, 21);
            this.btnComb.Margin = new System.Windows.Forms.Padding(6);
            this.btnComb.Name = "btnComb";
            this.btnComb.Size = new System.Drawing.Size(70, 37);
            this.btnComb.TabIndex = 119;
            this.btnComb.Text = "Pettine";
            this.toolTip1.SetToolTip(this.btnComb, "Domande che hanno un voto insufficiente");
            this.btnComb.UseVisualStyleBackColor = false;
            this.btnComb.Click += new System.EventHandler(this.BtnComb_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSearch.Location = new System.Drawing.Point(867, 21);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 37);
            this.btnSearch.TabIndex = 144;
            this.btnSearch.Text = "Cerca";
            this.toolTip1.SetToolTip(this.btnSearch, "Cerca fra le domande filtrate, della materia richiesta e non chieste nel periodo " +
        "indicato");
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchText
            // 
            this.txtSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchText.Location = new System.Drawing.Point(509, 28);
            this.txtSearchText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(349, 24);
            this.txtSearchText.TabIndex = 7;
            this.txtSearchText.TextChanged += new System.EventHandler(this.txtSearchText_TextChanged);
            // 
            // lblSearchText
            // 
            this.lblSearchText.AutoSize = true;
            this.lblSearchText.Location = new System.Drawing.Point(506, 6);
            this.lblSearchText.Name = "lblSearchText";
            this.lblSearchText.Size = new System.Drawing.Size(128, 18);
            this.lblSearchText.TabIndex = 105;
            this.lblSearchText.Text = "Testo da ricercare";
            // 
            // LessonTimer
            // 
            this.LessonTimer.Interval = 1000;
            this.LessonTimer.Tick += new System.EventHandler(this.LessonTimer_Tick);
            // 
            // frmQuestionChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1030, 547);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.LblLessonTime);
            this.Controls.Add(this.btnComb);
            this.Controls.Add(this.lblSearchText);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.lblQuestionType);
            this.Controls.Add(this.lblSchoolSubject);
            this.Controls.Add(this.cmbQuestionTypes);
            this.Controls.Add(this.cmbSchoolSubject);
            this.Controls.Add(this.grpQuestions);
            this.Controls.Add(this.grpTopic);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQuestionChoose";
            this.Text = "Scelta domanda";
            this.Load += new System.EventHandler(this.frmQuestionChoose_Load);
            this.grpTopic.ResumeLayout(false);
            this.grpTopic.PerformLayout();
            this.grpQuestions.ResumeLayout(false);
            this.grpQuestions.PerformLayout();
            this.grpPeriodOfQuestionsTopics.ResumeLayout(false);
            this.grpPeriodOfQuestionsTopics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwQuestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox cmbStandardPeriod;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpEndPeriod;
        private System.Windows.Forms.DateTimePicker dtpStartPeriod;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Label lblSearchText;
        private System.Windows.Forms.Button btnComb;
        private System.Windows.Forms.Label LblLessonTime;
        private System.Windows.Forms.Timer LessonTimer;
        private System.Windows.Forms.TextBox txtWeightInTest;
        private System.Windows.Forms.Label lblWeightInTest;
        private System.Windows.Forms.Button btnSearch;
    }
}