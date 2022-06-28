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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtIdStudent = new System.Windows.Forms.TextBox();
            this.dgwNotes = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblAverage = new System.Windows.Forms.Label();
            this.txtMediaDomande = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEraseAnnotation = new System.Windows.Forms.Button();
            this.btnAddAnnotation = new System.Windows.Forms.Button();
            this.txtAnnotation = new System.Windows.Forms.TextBox();
            this.chkCurrentAnnotationActive = new System.Windows.Forms.CheckBox();
            this.chkShowOnlyActive = new System.Windows.Forms.CheckBox();
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
            this.dgwGrades.Location = new System.Drawing.Point(6, 159);
            this.dgwGrades.Margin = new System.Windows.Forms.Padding(4);
            this.dgwGrades.Name = "dgwGrades";
            this.dgwGrades.RowTemplate.Height = 24;
            this.dgwGrades.Size = new System.Drawing.Size(839, 223);
            this.dgwGrades.TabIndex = 77;
            this.dgwGrades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwGrades_CellClick);
            this.dgwGrades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwGrades_CellContentClick);
            this.dgwGrades.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwGrades_CellDoubleClick);
            this.dgwGrades.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwVoti_CellEndEdit);
            // 
            // lblCurrentStudent
            // 
            this.lblCurrentStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentStudent.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentStudent.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentStudent.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCurrentStudent.Location = new System.Drawing.Point(93, 4);
            this.lblCurrentStudent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCurrentStudent.Name = "lblCurrentStudent";
            this.lblCurrentStudent.Size = new System.Drawing.Size(764, 46);
            this.lblCurrentStudent.TabIndex = 90;
            this.lblCurrentStudent.Text = "Allievo";
            this.lblCurrentStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 34);
            this.label2.TabIndex = 96;
            this.label2.Text = "Voti di tipo ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpComplessivo
            // 
            this.grpComplessivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpComplessivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.cmbSummaryGradeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSummaryGradeType.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbSummaryGradeType.FormattingEnabled = true;
            this.cmbSummaryGradeType.Items.AddRange(new object[] {
            "Voticini",
            "Orali",
            "Scritti",
            "Pratici",
            "Scritto-grafici"});
            this.cmbSummaryGradeType.Location = new System.Drawing.Point(130, 12);
            this.cmbSummaryGradeType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSummaryGradeType.Name = "cmbSummaryGradeType";
            this.cmbSummaryGradeType.Size = new System.Drawing.Size(373, 34);
            this.cmbSummaryGradeType.TabIndex = 95;
            this.cmbSummaryGradeType.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVotoRiepilogo_SelectedIndexChanged);
            // 
            // lblSchoolSubject
            // 
            this.lblSchoolSubject.BackColor = System.Drawing.Color.Transparent;
            this.lblSchoolSubject.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSchoolSubject.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSchoolSubject.Location = new System.Drawing.Point(6, 60);
            this.lblSchoolSubject.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSchoolSubject.Name = "lblSchoolSubject";
            this.lblSchoolSubject.Size = new System.Drawing.Size(118, 31);
            this.lblSchoolSubject.TabIndex = 101;
            this.lblSchoolSubject.Text = "Materia";
            this.lblSchoolSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSchoolSubjects
            // 
            this.cmbSchoolSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSchoolSubjects.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbSchoolSubjects.FormattingEnabled = true;
            this.cmbSchoolSubjects.Items.AddRange(new object[] {
            "Voticini",
            "Orali",
            "Scritti",
            "Pratici",
            "Scritto-grafici"});
            this.cmbSchoolSubjects.Location = new System.Drawing.Point(130, 57);
            this.cmbSchoolSubjects.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSchoolSubjects.Name = "cmbSchoolSubjects";
            this.cmbSchoolSubjects.Size = new System.Drawing.Size(373, 34);
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
            this.grpPeriodOfQuestionsTopics.Location = new System.Drawing.Point(6, 98);
            this.grpPeriodOfQuestionsTopics.Name = "grpPeriodOfQuestionsTopics";
            this.grpPeriodOfQuestionsTopics.Size = new System.Drawing.Size(606, 58);
            this.grpPeriodOfQuestionsTopics.TabIndex = 147;
            this.grpPeriodOfQuestionsTopics.TabStop = false;
            this.grpPeriodOfQuestionsTopics.Text = "Periodo dei voti";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(179, 26);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(36, 18);
            this.lblEnd.TabIndex = 157;
            this.lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(10, 26);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(42, 18);
            this.lblStart.TabIndex = 156;
            this.lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            this.dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            this.dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndPeriod.Location = new System.Drawing.Point(219, 23);
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
            this.dtpStartPeriod.Location = new System.Drawing.Point(62, 23);
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
            this.cmbSchoolPeriod.Location = new System.Drawing.Point(341, 21);
            this.cmbSchoolPeriod.Name = "cmbSchoolPeriod";
            this.cmbSchoolPeriod.Size = new System.Drawing.Size(264, 26);
            this.cmbSchoolPeriod.TabIndex = 153;
            this.cmbSchoolPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolPeriod_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(6, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 156;
            this.label1.Text = "Id allievo";
            // 
            // TxtIdStudent
            // 
            this.TxtIdStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtIdStudent.Location = new System.Drawing.Point(6, 20);
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
            this.dgwNotes.Location = new System.Drawing.Point(6, 122);
            this.dgwNotes.Margin = new System.Windows.Forms.Padding(4);
            this.dgwNotes.Name = "dgwNotes";
            this.dgwNotes.RowTemplate.Height = 24;
            this.dgwNotes.Size = new System.Drawing.Size(836, 112);
            this.dgwNotes.TabIndex = 157;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(8, 53);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblAverage);
            this.splitContainer1.Panel1.Controls.Add(this.txtMediaDomande);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.grpComplessivo);
            this.splitContainer1.Panel1.Controls.Add(this.dgwGrades);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSummaryGradeType);
            this.splitContainer1.Panel1.Controls.Add(this.grpPeriodOfQuestionsTopics);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSchoolSubjects);
            this.splitContainer1.Panel1.Controls.Add(this.lblSchoolSubject);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnEraseAnnotation);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddAnnotation);
            this.splitContainer1.Panel2.Controls.Add(this.txtAnnotation);
            this.splitContainer1.Panel2.Controls.Add(this.chkCurrentAnnotationActive);
            this.splitContainer1.Panel2.Controls.Add(this.dgwNotes);
            this.splitContainer1.Panel2.Controls.Add(this.chkShowOnlyActive);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txtIdStudentsAnnotation);
            this.splitContainer1.Size = new System.Drawing.Size(849, 729);
            this.splitContainer1.SplitterDistance = 487;
            this.splitContainer1.TabIndex = 157;
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(511, 29);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(96, 18);
            this.lblAverage.TabIndex = 149;
            this.lblAverage.Text = "Media pesata";
            // 
            // txtMediaDomande
            // 
            this.txtMediaDomande.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMediaDomande.Location = new System.Drawing.Point(511, 54);
            this.txtMediaDomande.Margin = new System.Windows.Forms.Padding(4);
            this.txtMediaDomande.Name = "txtMediaDomande";
            this.txtMediaDomande.Size = new System.Drawing.Size(100, 37);
            this.txtMediaDomande.TabIndex = 148;
            this.txtMediaDomande.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(441, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 37);
            this.btnSave.TabIndex = 170;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnEraseAnnotation
            // 
            this.btnEraseAnnotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEraseAnnotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEraseAnnotation.Location = new System.Drawing.Point(375, 11);
            this.btnEraseAnnotation.Name = "btnEraseAnnotation";
            this.btnEraseAnnotation.Size = new System.Drawing.Size(62, 37);
            this.btnEraseAnnotation.TabIndex = 169;
            this.btnEraseAnnotation.Text = "-";
            this.btnEraseAnnotation.UseVisualStyleBackColor = true;
            // 
            // btnAddAnnotation
            // 
            this.btnAddAnnotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAnnotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddAnnotation.Location = new System.Drawing.Point(309, 11);
            this.btnAddAnnotation.Name = "btnAddAnnotation";
            this.btnAddAnnotation.Size = new System.Drawing.Size(62, 37);
            this.btnAddAnnotation.TabIndex = 168;
            this.btnAddAnnotation.Text = "+";
            this.btnAddAnnotation.UseVisualStyleBackColor = true;
            // 
            // txtAnnotation
            // 
            this.txtAnnotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnnotation.Location = new System.Drawing.Point(6, 62);
            this.txtAnnotation.Multiline = true;
            this.txtAnnotation.Name = "txtAnnotation";
            this.txtAnnotation.Size = new System.Drawing.Size(834, 53);
            this.txtAnnotation.TabIndex = 177;
            // 
            // chkCurrentAnnotationActive
            // 
            this.chkCurrentAnnotationActive.AutoSize = true;
            this.chkCurrentAnnotationActive.Checked = true;
            this.chkCurrentAnnotationActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCurrentAnnotationActive.Location = new System.Drawing.Point(533, 10);
            this.chkCurrentAnnotationActive.Name = "chkCurrentAnnotationActive";
            this.chkCurrentAnnotationActive.Size = new System.Drawing.Size(62, 22);
            this.chkCurrentAnnotationActive.TabIndex = 179;
            this.chkCurrentAnnotationActive.Text = "Attiva";
            this.chkCurrentAnnotationActive.UseVisualStyleBackColor = true;
            // 
            // chkShowOnlyActive
            // 
            this.chkShowOnlyActive.AutoSize = true;
            this.chkShowOnlyActive.Checked = true;
            this.chkShowOnlyActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowOnlyActive.Location = new System.Drawing.Point(533, 32);
            this.chkShowOnlyActive.Name = "chkShowOnlyActive";
            this.chkShowOnlyActive.Size = new System.Drawing.Size(162, 22);
            this.chkShowOnlyActive.TabIndex = 178;
            this.chkShowOnlyActive.Text = "visualizza solo attive";
            this.chkShowOnlyActive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 38);
            this.label5.TabIndex = 176;
            this.label5.Text = "Annotazione";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(778, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 175;
            this.label4.Text = "Id annot.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(781, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(59, 24);
            this.textBox1.TabIndex = 174;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(713, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 175;
            this.label3.Text = "Id annot.";
            // 
            // txtIdStudentsAnnotation
            // 
            this.txtIdStudentsAnnotation.Location = new System.Drawing.Point(716, 32);
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
            this.ClientSize = new System.Drawing.Size(866, 784);
            this.Controls.Add(this.lblCurrentStudent);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtIdStudent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtIdStudent;
        private System.Windows.Forms.DataGridView dgwNotes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdStudentsAnnotation;
        private System.Windows.Forms.CheckBox chkCurrentAnnotationActive;
        private System.Windows.Forms.CheckBox chkShowOnlyActive;
        private System.Windows.Forms.TextBox txtAnnotation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEraseAnnotation;
        private System.Windows.Forms.Button btnAddAnnotation;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.TextBox txtMediaDomande;
    }
}