namespace SchoolGrades
{
    partial class frmGradesStudentsSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGradesStudentsSummary));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.dgwGrades = new System.Windows.Forms.DataGridView();
            this.lblCurrentStudent = new System.Windows.Forms.Label();
            this.txtMediaMicroDomande = new System.Windows.Forms.TextBox();
            this.btnDettagliVoto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.grpComplessivo = new System.Windows.Forms.GroupBox();
            this.cmbSummaryGradeType = new System.Windows.Forms.ComboBox();
            this.lblSchoolSubject = new System.Windows.Forms.Label();
            this.cmbSchoolSubjects = new System.Windows.Forms.ComboBox();
            this.grpPeriodOfQuestionsTopics = new System.Windows.Forms.GroupBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            this.dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            this.rdbAmongPeriod = new System.Windows.Forms.RadioButton();
            this.cmbSchoolPeriod = new System.Windows.Forms.ComboBox();
            this.rdbShowWeightsOnOpenGrades = new System.Windows.Forms.RadioButton();
            this.lblSum = new System.Windows.Forms.Label();
            this.rdbShowWeightedGrades = new System.Windows.Forms.RadioButton();
            this.rdbShowWeights = new System.Windows.Forms.RadioButton();
            this.rdbShowGrades = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtIdStudent = new System.Windows.Forms.TextBox();
            this.dgwNotes = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEraseAnnotation = new System.Windows.Forms.Button();
            this.btnAddAnnotation = new System.Windows.Forms.Button();
            this.txtAnnotation = new System.Windows.Forms.TextBox();
            this.chkCurrentAnnotationActive = new System.Windows.Forms.CheckBox();
            this.chkAnnotationsShowActive = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdStudentsAnnotation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrades)).BeginInit();
            this.grpPeriodOfQuestionsTopics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwGrades
            // 
            this.dgwGrades.AllowUserToAddRows = false;
            this.dgwGrades.AllowUserToDeleteRows = false;
            this.dgwGrades.AllowUserToOrderColumns = true;
            this.dgwGrades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwGrades.Location = new System.Drawing.Point(0, 159);
            this.dgwGrades.Margin = new System.Windows.Forms.Padding(4);
            this.dgwGrades.Name = "dgwGrades";
            this.dgwGrades.RowTemplate.Height = 24;
            this.dgwGrades.Size = new System.Drawing.Size(845, 223);
            this.dgwGrades.TabIndex = 77;
            this.dgwGrades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwGrades_CellContentClick);
            this.dgwGrades.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwVoti_CellEndEdit);
            // 
            // lblCurrentStudent
            // 
            this.lblCurrentStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentStudent.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentStudent.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStudent.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCurrentStudent.Location = new System.Drawing.Point(7, 3);
            this.lblCurrentStudent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCurrentStudent.Name = "lblCurrentStudent";
            this.lblCurrentStudent.Size = new System.Drawing.Size(793, 46);
            this.lblCurrentStudent.TabIndex = 90;
            this.lblCurrentStudent.Text = "Allievo";
            this.lblCurrentStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMediaMicroDomande
            // 
            this.txtMediaMicroDomande.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMediaMicroDomande.Location = new System.Drawing.Point(5, 118);
            this.txtMediaMicroDomande.Margin = new System.Windows.Forms.Padding(4);
            this.txtMediaMicroDomande.Name = "txtMediaMicroDomande";
            this.txtMediaMicroDomande.Size = new System.Drawing.Size(124, 37);
            this.txtMediaMicroDomande.TabIndex = 91;
            this.txtMediaMicroDomande.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDettagliVoto
            // 
            this.btnDettagliVoto.BackColor = System.Drawing.Color.Transparent;
            this.btnDettagliVoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDettagliVoto.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnDettagliVoto.Location = new System.Drawing.Point(745, 47);
            this.btnDettagliVoto.Margin = new System.Windows.Forms.Padding(6);
            this.btnDettagliVoto.Name = "btnDettagliVoto";
            this.btnDettagliVoto.Size = new System.Drawing.Size(76, 51);
            this.btnDettagliVoto.TabIndex = 94;
            this.btnDettagliVoto.Text = "Mostra dettagli voto";
            this.btnDettagliVoto.UseVisualStyleBackColor = false;
            this.btnDettagliVoto.Click += new System.EventHandler(this.btnDettagliVoto_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(158, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 59);
            this.label2.TabIndex = 96;
            this.label2.Text = "Riepilogo dei voti di tipo ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpComplessivo
            // 
            this.grpComplessivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpComplessivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpComplessivo.ForeColor = System.Drawing.Color.DarkBlue;
            this.grpComplessivo.Location = new System.Drawing.Point(3, 384);
            this.grpComplessivo.Margin = new System.Windows.Forms.Padding(4);
            this.grpComplessivo.Name = "grpComplessivo";
            this.grpComplessivo.Padding = new System.Windows.Forms.Padding(4);
            this.grpComplessivo.Size = new System.Drawing.Size(842, 99);
            this.grpComplessivo.TabIndex = 97;
            this.grpComplessivo.TabStop = false;
            this.grpComplessivo.Text = "Riepilogo complessivo";
            // 
            // cmbSummaryGradeType
            // 
            this.cmbSummaryGradeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSummaryGradeType.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbSummaryGradeType.FormattingEnabled = true;
            this.cmbSummaryGradeType.Items.AddRange(new object[] {
            "Voticini",
            "Orali",
            "Scritti",
            "Pratici",
            "Scritto-grafici"});
            this.cmbSummaryGradeType.Location = new System.Drawing.Point(437, 17);
            this.cmbSummaryGradeType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSummaryGradeType.Name = "cmbSummaryGradeType";
            this.cmbSummaryGradeType.Size = new System.Drawing.Size(288, 34);
            this.cmbSummaryGradeType.TabIndex = 95;
            this.cmbSummaryGradeType.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVotoRiepilogo_SelectedIndexChanged);
            // 
            // lblSchoolSubject
            // 
            this.lblSchoolSubject.BackColor = System.Drawing.Color.Transparent;
            this.lblSchoolSubject.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolSubject.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSchoolSubject.Location = new System.Drawing.Point(156, 50);
            this.lblSchoolSubject.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSchoolSubject.Name = "lblSchoolSubject";
            this.lblSchoolSubject.Size = new System.Drawing.Size(271, 59);
            this.lblSchoolSubject.TabIndex = 101;
            this.lblSchoolSubject.Text = "Materia";
            this.lblSchoolSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSchoolSubjects
            // 
            this.cmbSchoolSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSchoolSubjects.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbSchoolSubjects.FormattingEnabled = true;
            this.cmbSchoolSubjects.Items.AddRange(new object[] {
            "Voticini",
            "Orali",
            "Scritti",
            "Pratici",
            "Scritto-grafici"});
            this.cmbSchoolSubjects.Location = new System.Drawing.Point(437, 62);
            this.cmbSchoolSubjects.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSchoolSubjects.Name = "cmbSchoolSubjects";
            this.cmbSchoolSubjects.Size = new System.Drawing.Size(288, 34);
            this.cmbSchoolSubjects.TabIndex = 100;
            this.cmbSchoolSubjects.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolSubjects_SelectedIndexChanged);
            // 
            // grpPeriodOfQuestionsTopics
            // 
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.lblEnd);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.lblStart);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.dtpEndPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.dtpStartPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.rdbAmongPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.cmbSchoolPeriod);
            this.grpPeriodOfQuestionsTopics.Location = new System.Drawing.Point(157, 107);
            this.grpPeriodOfQuestionsTopics.Name = "grpPeriodOfQuestionsTopics";
            this.grpPeriodOfQuestionsTopics.Size = new System.Drawing.Size(606, 58);
            this.grpPeriodOfQuestionsTopics.TabIndex = 147;
            this.grpPeriodOfQuestionsTopics.TabStop = false;
            this.grpPeriodOfQuestionsTopics.Text = "Periodo dei voti";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(171, 24);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(36, 18);
            this.lblEnd.TabIndex = 157;
            this.lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(2, 24);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(42, 18);
            this.lblStart.TabIndex = 156;
            this.lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            this.dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            this.dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndPeriod.Location = new System.Drawing.Point(211, 21);
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
            this.rdbAmongPeriod.Location = new System.Drawing.Point(7, 62);
            this.rdbAmongPeriod.Name = "rdbAmongPeriod";
            this.rdbAmongPeriod.Size = new System.Drawing.Size(111, 22);
            this.rdbAmongPeriod.TabIndex = 2;
            this.rdbAmongPeriod.Text = "in un periodo";
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
            this.cmbSchoolPeriod.Location = new System.Drawing.Point(333, 19);
            this.cmbSchoolPeriod.Name = "cmbSchoolPeriod";
            this.cmbSchoolPeriod.Size = new System.Drawing.Size(264, 26);
            this.cmbSchoolPeriod.TabIndex = 153;
            this.cmbSchoolPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolPeriod_SelectedIndexChanged);
            // 
            // rdbShowWeightsOnOpenGrades
            // 
            this.rdbShowWeightsOnOpenGrades.AutoSize = true;
            this.rdbShowWeightsOnOpenGrades.Location = new System.Drawing.Point(3, 74);
            this.rdbShowWeightsOnOpenGrades.Name = "rdbShowWeightsOnOpenGrades";
            this.rdbShowWeightsOnOpenGrades.Size = new System.Drawing.Size(142, 22);
            this.rdbShowWeightsOnOpenGrades.TabIndex = 153;
            this.rdbShowWeightsOnOpenGrades.Text = "Pesi su voti aperti";
            this.rdbShowWeightsOnOpenGrades.UseVisualStyleBackColor = true;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(3, 96);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(53, 18);
            this.lblSum.TabIndex = 152;
            this.lblSum.Text = "lblSum";
            // 
            // rdbShowWeightedGrades
            // 
            this.rdbShowWeightedGrades.AutoSize = true;
            this.rdbShowWeightedGrades.Location = new System.Drawing.Point(4, 28);
            this.rdbShowWeightedGrades.Name = "rdbShowWeightedGrades";
            this.rdbShowWeightedGrades.Size = new System.Drawing.Size(145, 22);
            this.rdbShowWeightedGrades.TabIndex = 151;
            this.rdbShowWeightedGrades.Text = "Media pesata voti ";
            this.rdbShowWeightedGrades.UseVisualStyleBackColor = true;
            this.rdbShowWeightedGrades.CheckedChanged += new System.EventHandler(this.rdbShowWeightedGrades_CheckedChanged);
            // 
            // rdbShowWeights
            // 
            this.rdbShowWeights.AutoSize = true;
            this.rdbShowWeights.Checked = true;
            this.rdbShowWeights.Location = new System.Drawing.Point(4, 51);
            this.rdbShowWeights.Name = "rdbShowWeights";
            this.rdbShowWeights.Size = new System.Drawing.Size(55, 22);
            this.rdbShowWeights.TabIndex = 150;
            this.rdbShowWeights.TabStop = true;
            this.rdbShowWeights.Text = "Pesi";
            this.rdbShowWeights.UseVisualStyleBackColor = true;
            this.rdbShowWeights.CheckedChanged += new System.EventHandler(this.rdbShowWeights_CheckedChanged);
            // 
            // rdbShowGrades
            // 
            this.rdbShowGrades.AutoSize = true;
            this.rdbShowGrades.Location = new System.Drawing.Point(4, 5);
            this.rdbShowGrades.Name = "rdbShowGrades";
            this.rdbShowGrades.Size = new System.Drawing.Size(51, 22);
            this.rdbShowGrades.TabIndex = 149;
            this.rdbShowGrades.Text = "Voti";
            this.rdbShowGrades.UseVisualStyleBackColor = true;
            this.rdbShowGrades.CheckedChanged += new System.EventHandler(this.rdbShowGrades_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(810, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 156;
            this.label1.Text = "Id allievo";
            // 
            // TxtIdStudent
            // 
            this.TxtIdStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtIdStudent.Location = new System.Drawing.Point(813, 25);
            this.TxtIdStudent.Margin = new System.Windows.Forms.Padding(4);
            this.TxtIdStudent.Name = "TxtIdStudent";
            this.TxtIdStudent.ReadOnly = true;
            this.TxtIdStudent.Size = new System.Drawing.Size(77, 24);
            this.TxtIdStudent.TabIndex = 155;
            this.TxtIdStudent.TabStop = false;
            this.TxtIdStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgwNotes
            // 
            this.dgwNotes.AllowUserToAddRows = false;
            this.dgwNotes.AllowUserToDeleteRows = false;
            this.dgwNotes.AllowUserToOrderColumns = true;
            this.dgwNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwNotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwNotes.Location = new System.Drawing.Point(0, 131);
            this.dgwNotes.Margin = new System.Windows.Forms.Padding(4);
            this.dgwNotes.Name = "dgwNotes";
            this.dgwNotes.RowTemplate.Height = 24;
            this.dgwNotes.Size = new System.Drawing.Size(849, 103);
            this.dgwNotes.TabIndex = 157;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(8, 53);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rdbShowWeightsOnOpenGrades);
            this.splitContainer1.Panel1.Controls.Add(this.rdbShowGrades);
            this.splitContainer1.Panel1.Controls.Add(this.rdbShowWeights);
            this.splitContainer1.Panel1.Controls.Add(this.rdbShowWeightedGrades);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.grpComplessivo);
            this.splitContainer1.Panel1.Controls.Add(this.lblSum);
            this.splitContainer1.Panel1.Controls.Add(this.dgwGrades);
            this.splitContainer1.Panel1.Controls.Add(this.btnDettagliVoto);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSummaryGradeType);
            this.splitContainer1.Panel1.Controls.Add(this.grpPeriodOfQuestionsTopics);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSchoolSubjects);
            this.splitContainer1.Panel1.Controls.Add(this.lblSchoolSubject);
            this.splitContainer1.Panel1.Controls.Add(this.txtMediaMicroDomande);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnEraseAnnotation);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddAnnotation);
            this.splitContainer1.Panel2.Controls.Add(this.txtAnnotation);
            this.splitContainer1.Panel2.Controls.Add(this.chkCurrentAnnotationActive);
            this.splitContainer1.Panel2.Controls.Add(this.dgwNotes);
            this.splitContainer1.Panel2.Controls.Add(this.chkAnnotationsShowActive);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txtIdStudentsAnnotation);
            this.splitContainer1.Size = new System.Drawing.Size(849, 729);
            this.splitContainer1.SplitterDistance = 487;
            this.splitContainer1.TabIndex = 157;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(433, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 37);
            this.btnSave.TabIndex = 170;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnEraseAnnotation
            // 
            this.btnEraseAnnotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEraseAnnotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEraseAnnotation.Location = new System.Drawing.Point(367, 1);
            this.btnEraseAnnotation.Name = "btnEraseAnnotation";
            this.btnEraseAnnotation.Size = new System.Drawing.Size(63, 37);
            this.btnEraseAnnotation.TabIndex = 169;
            this.btnEraseAnnotation.Text = "-";
            this.btnEraseAnnotation.UseVisualStyleBackColor = true;
            // 
            // btnAddAnnotation
            // 
            this.btnAddAnnotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAnnotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAnnotation.Location = new System.Drawing.Point(301, 1);
            this.btnAddAnnotation.Name = "btnAddAnnotation";
            this.btnAddAnnotation.Size = new System.Drawing.Size(63, 37);
            this.btnAddAnnotation.TabIndex = 168;
            this.btnAddAnnotation.Text = "+";
            this.btnAddAnnotation.UseVisualStyleBackColor = true;
            // 
            // txtAnnotation
            // 
            this.txtAnnotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnnotation.Location = new System.Drawing.Point(0, 71);
            this.txtAnnotation.Multiline = true;
            this.txtAnnotation.Name = "txtAnnotation";
            this.txtAnnotation.Size = new System.Drawing.Size(775, 53);
            this.txtAnnotation.TabIndex = 177;
            // 
            // chkCurrentAnnotationActive
            // 
            this.chkCurrentAnnotationActive.AutoSize = true;
            this.chkCurrentAnnotationActive.Checked = true;
            this.chkCurrentAnnotationActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCurrentAnnotationActive.Location = new System.Drawing.Point(779, 74);
            this.chkCurrentAnnotationActive.Name = "chkCurrentAnnotationActive";
            this.chkCurrentAnnotationActive.Size = new System.Drawing.Size(62, 22);
            this.chkCurrentAnnotationActive.TabIndex = 179;
            this.chkCurrentAnnotationActive.Text = "Attiva";
            this.chkCurrentAnnotationActive.UseVisualStyleBackColor = true;
            // 
            // chkAnnotationsShowActive
            // 
            this.chkAnnotationsShowActive.AutoSize = true;
            this.chkAnnotationsShowActive.Checked = true;
            this.chkAnnotationsShowActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAnnotationsShowActive.Location = new System.Drawing.Point(518, 43);
            this.chkAnnotationsShowActive.Name = "chkAnnotationsShowActive";
            this.chkAnnotationsShowActive.Size = new System.Drawing.Size(162, 22);
            this.chkAnnotationsShowActive.TabIndex = 178;
            this.chkAnnotationsShowActive.Text = "visualizza solo attive";
            this.chkAnnotationsShowActive.UseVisualStyleBackColor = true;
            this.chkAnnotationsShowActive.CheckedChanged += new System.EventHandler(this.chkAnnotationsShowActive_CheckedChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(-1, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 59);
            this.label5.TabIndex = 176;
            this.label5.Text = "Annotazione";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(783, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 175;
            this.label4.Text = "Id annot.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(786, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(59, 24);
            this.textBox1.TabIndex = 174;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(718, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 175;
            this.label3.Text = "Id annot.";
            // 
            // txtIdStudentsAnnotation
            // 
            this.txtIdStudentsAnnotation.Location = new System.Drawing.Point(721, 41);
            this.txtIdStudentsAnnotation.Name = "txtIdStudentsAnnotation";
            this.txtIdStudentsAnnotation.ReadOnly = true;
            this.txtIdStudentsAnnotation.Size = new System.Drawing.Size(59, 24);
            this.txtIdStudentsAnnotation.TabIndex = 174;
            // 
            // frmGradesStudentsSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(903, 784);
            this.Controls.Add(this.lblCurrentStudent);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtIdStudent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGradesStudentsSummary";
            this.Text = "Riepilogo voti allievo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGradesSummary_FormClosing);
            this.Load += new System.EventHandler(this.frmGradesStudentsSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrades)).EndInit();
            this.grpPeriodOfQuestionsTopics.ResumeLayout(false);
            this.grpPeriodOfQuestionsTopics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwNotes)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridView dgwGrades;
        private System.Windows.Forms.Label lblCurrentStudent;
        private System.Windows.Forms.TextBox txtMediaMicroDomande;
        private System.Windows.Forms.Button btnDettagliVoto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpComplessivo;
        private System.Windows.Forms.ComboBox cmbSummaryGradeType;
        private System.Windows.Forms.Label lblSchoolSubject;
        private System.Windows.Forms.ComboBox cmbSchoolSubjects;
        private System.Windows.Forms.GroupBox grpPeriodOfQuestionsTopics;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpEndPeriod;
        private System.Windows.Forms.DateTimePicker dtpStartPeriod;
        private System.Windows.Forms.RadioButton rdbAmongPeriod;
        private System.Windows.Forms.ComboBox cmbSchoolPeriod;
        private System.Windows.Forms.RadioButton rdbShowWeightsOnOpenGrades;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.RadioButton rdbShowWeightedGrades;
        private System.Windows.Forms.RadioButton rdbShowWeights;
        private System.Windows.Forms.RadioButton rdbShowGrades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtIdStudent;
        private System.Windows.Forms.DataGridView dgwNotes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdStudentsAnnotation;
        private System.Windows.Forms.CheckBox chkCurrentAnnotationActive;
        private System.Windows.Forms.CheckBox chkAnnotationsShowActive;
        private System.Windows.Forms.TextBox txtAnnotation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEraseAnnotation;
        private System.Windows.Forms.Button btnAddAnnotation;
    }
}