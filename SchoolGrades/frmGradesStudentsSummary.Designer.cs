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
            colorDialog1 = new System.Windows.Forms.ColorDialog();
            dgwGrades = new System.Windows.Forms.DataGridView();
            lblCurrentStudent = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            grpComplessivo = new System.Windows.Forms.GroupBox();
            lblTypeOfGrade = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            textBox4 = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            textBox3 = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            cmbGradeType = new System.Windows.Forms.ComboBox();
            lblSchoolSubject = new System.Windows.Forms.Label();
            cmbSchoolSubjects = new System.Windows.Forms.ComboBox();
            grpPeriodOfQuestionsTopics = new System.Windows.Forms.GroupBox();
            lblEnd = new System.Windows.Forms.Label();
            lblStart = new System.Windows.Forms.Label();
            dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            rdbAmongPeriod = new System.Windows.Forms.RadioButton();
            cmbSchoolPeriod = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            TxtIdStudent = new System.Windows.Forms.TextBox();
            dgwNotes = new System.Windows.Forms.DataGridView();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            label5 = new System.Windows.Forms.Label();
            txtSumOfWeights = new System.Windows.Forms.TextBox();
            lblAverage = new System.Windows.Forms.Label();
            txtWeightedAverage = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            btnEraseAnnotation = new System.Windows.Forms.Button();
            btnAddAnnotation = new System.Windows.Forms.Button();
            label9 = new System.Windows.Forms.Label();
            txtAnnotation = new System.Windows.Forms.TextBox();
            chkCurrentAnnotationActive = new System.Windows.Forms.CheckBox();
            chkShowOnlyActive = new System.Windows.Forms.CheckBox();
            label4 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtIdStudentsAnnotation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)dgwGrades).BeginInit();
            grpComplessivo.SuspendLayout();
            grpPeriodOfQuestionsTopics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwNotes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // dgwGrades
            // 
            dgwGrades.AllowUserToAddRows = false;
            dgwGrades.AllowUserToDeleteRows = false;
            dgwGrades.AllowUserToOrderColumns = true;
            dgwGrades.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwGrades.Location = new System.Drawing.Point(0, 151);
            dgwGrades.Margin = new System.Windows.Forms.Padding(4);
            dgwGrades.Name = "dgwGrades";
            dgwGrades.ReadOnly = true;
            dgwGrades.RowTemplate.Height = 24;
            dgwGrades.Size = new System.Drawing.Size(923, 215);
            dgwGrades.TabIndex = 77;
            dgwGrades.CellClick += dgwGrades_CellClick;
            dgwGrades.CellContentClick += dgwGrades_CellContentClick;
            dgwGrades.CellDoubleClick += dgwGrades_CellDoubleClick;
            dgwGrades.CellEndEdit += dgwVoti_CellEndEdit;
            // 
            // lblCurrentStudent
            // 
            lblCurrentStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblCurrentStudent.BackColor = System.Drawing.Color.Transparent;
            lblCurrentStudent.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblCurrentStudent.ForeColor = System.Drawing.Color.DarkBlue;
            lblCurrentStudent.Location = new System.Drawing.Point(93, 4);
            lblCurrentStudent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblCurrentStudent.Name = "lblCurrentStudent";
            lblCurrentStudent.Size = new System.Drawing.Size(827, 46);
            lblCurrentStudent.TabIndex = 90;
            lblCurrentStudent.Text = "Allievo";
            lblCurrentStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.DarkBlue;
            label2.Location = new System.Drawing.Point(5, 5);
            label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(118, 34);
            label2.TabIndex = 96;
            label2.Text = "Voti di tipo ";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpComplessivo
            // 
            grpComplessivo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpComplessivo.Controls.Add(lblTypeOfGrade);
            grpComplessivo.Controls.Add(label8);
            grpComplessivo.Controls.Add(textBox4);
            grpComplessivo.Controls.Add(label6);
            grpComplessivo.Controls.Add(textBox3);
            grpComplessivo.Controls.Add(label7);
            grpComplessivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            grpComplessivo.ForeColor = System.Drawing.Color.DarkBlue;
            grpComplessivo.Location = new System.Drawing.Point(0, 374);
            grpComplessivo.Margin = new System.Windows.Forms.Padding(4);
            grpComplessivo.Name = "grpComplessivo";
            grpComplessivo.Padding = new System.Windows.Forms.Padding(4);
            grpComplessivo.Size = new System.Drawing.Size(919, 99);
            grpComplessivo.TabIndex = 97;
            grpComplessivo.TabStop = false;
            grpComplessivo.Text = "Riepilogo complessivo";
            // 
            // lblTypeOfGrade
            // 
            lblTypeOfGrade.BackColor = System.Drawing.Color.Transparent;
            lblTypeOfGrade.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblTypeOfGrade.ForeColor = System.Drawing.Color.DarkBlue;
            lblTypeOfGrade.Location = new System.Drawing.Point(141, 26);
            lblTypeOfGrade.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblTypeOfGrade.Name = "lblTypeOfGrade";
            lblTypeOfGrade.Size = new System.Drawing.Size(319, 34);
            lblTypeOfGrade.TabIndex = 158;
            lblTypeOfGrade.Text = "lblTypeOfGrade";
            lblTypeOfGrade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(704, 37);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(82, 15);
            label8.TabIndex = 157;
            label8.Text = "Media pesata";
            // 
            // textBox4
            // 
            textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBox4.Location = new System.Drawing.Point(800, 26);
            textBox4.Margin = new System.Windows.Forms.Padding(4);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(100, 37);
            textBox4.TabIndex = 156;
            textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(513, 34);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(77, 15);
            label6.TabIndex = 155;
            label6.Text = "Somma pesi";
            // 
            // textBox3
            // 
            textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBox3.Location = new System.Drawing.Point(597, 26);
            textBox3.Margin = new System.Windows.Forms.Padding(4);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(100, 37);
            textBox3.TabIndex = 154;
            textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.ForeColor = System.Drawing.Color.DarkBlue;
            label7.Location = new System.Drawing.Point(13, 29);
            label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(118, 34);
            label7.TabIndex = 153;
            label7.Text = "Voti di tipo ";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbGradeType
            // 
            cmbGradeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cmbGradeType.ForeColor = System.Drawing.Color.DarkBlue;
            cmbGradeType.FormattingEnabled = true;
            cmbGradeType.Items.AddRange(new object[] { "Voticini", "Orali", "Scritti", "Pratici", "Scritto-grafici" });
            cmbGradeType.Location = new System.Drawing.Point(129, 5);
            cmbGradeType.Margin = new System.Windows.Forms.Padding(4);
            cmbGradeType.Name = "cmbGradeType";
            cmbGradeType.Size = new System.Drawing.Size(373, 34);
            cmbGradeType.TabIndex = 95;
            cmbGradeType.SelectedIndexChanged += cmbGradeType_SelectedIndexChanged;
            // 
            // lblSchoolSubject
            // 
            lblSchoolSubject.BackColor = System.Drawing.Color.Transparent;
            lblSchoolSubject.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblSchoolSubject.ForeColor = System.Drawing.Color.DarkBlue;
            lblSchoolSubject.Location = new System.Drawing.Point(5, 48);
            lblSchoolSubject.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblSchoolSubject.Name = "lblSchoolSubject";
            lblSchoolSubject.Size = new System.Drawing.Size(118, 31);
            lblSchoolSubject.TabIndex = 101;
            lblSchoolSubject.Text = "Materia";
            lblSchoolSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSchoolSubjects
            // 
            cmbSchoolSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cmbSchoolSubjects.ForeColor = System.Drawing.Color.DarkBlue;
            cmbSchoolSubjects.FormattingEnabled = true;
            cmbSchoolSubjects.Items.AddRange(new object[] { "Voticini", "Orali", "Scritti", "Pratici", "Scritto-grafici" });
            cmbSchoolSubjects.Location = new System.Drawing.Point(129, 45);
            cmbSchoolSubjects.Margin = new System.Windows.Forms.Padding(4);
            cmbSchoolSubjects.Name = "cmbSchoolSubjects";
            cmbSchoolSubjects.Size = new System.Drawing.Size(373, 34);
            cmbSchoolSubjects.TabIndex = 100;
            cmbSchoolSubjects.SelectedIndexChanged += cmbSchoolSubjects_SelectedIndexChanged;
            // 
            // grpPeriodOfQuestionsTopics
            // 
            grpPeriodOfQuestionsTopics.Controls.Add(lblEnd);
            grpPeriodOfQuestionsTopics.Controls.Add(lblStart);
            grpPeriodOfQuestionsTopics.Controls.Add(dtpEndPeriod);
            grpPeriodOfQuestionsTopics.Controls.Add(dtpStartPeriod);
            grpPeriodOfQuestionsTopics.Controls.Add(rdbAmongPeriod);
            grpPeriodOfQuestionsTopics.Controls.Add(cmbSchoolPeriod);
            grpPeriodOfQuestionsTopics.Location = new System.Drawing.Point(3, 86);
            grpPeriodOfQuestionsTopics.Name = "grpPeriodOfQuestionsTopics";
            grpPeriodOfQuestionsTopics.Size = new System.Drawing.Size(606, 58);
            grpPeriodOfQuestionsTopics.TabIndex = 147;
            grpPeriodOfQuestionsTopics.TabStop = false;
            grpPeriodOfQuestionsTopics.Text = "Periodo dei voti";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new System.Drawing.Point(179, 26);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new System.Drawing.Size(36, 18);
            lblEnd.TabIndex = 157;
            lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new System.Drawing.Point(10, 26);
            lblStart.Name = "lblStart";
            lblStart.Size = new System.Drawing.Size(42, 18);
            lblStart.TabIndex = 156;
            lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpEndPeriod.Location = new System.Drawing.Point(219, 23);
            dtpEndPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            dtpEndPeriod.Name = "dtpEndPeriod";
            dtpEndPeriod.Size = new System.Drawing.Size(111, 24);
            dtpEndPeriod.TabIndex = 155;
            dtpEndPeriod.Value = new System.DateTime(2019, 6, 7, 0, 0, 0, 0);
            // 
            // dtpStartPeriod
            // 
            dtpStartPeriod.CustomFormat = "yyyy-MM-dd";
            dtpStartPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpStartPeriod.Location = new System.Drawing.Point(62, 23);
            dtpStartPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            dtpStartPeriod.Name = "dtpStartPeriod";
            dtpStartPeriod.Size = new System.Drawing.Size(111, 24);
            dtpStartPeriod.TabIndex = 154;
            dtpStartPeriod.Value = new System.DateTime(2019, 1, 24, 0, 0, 0, 0);
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
            cmbSchoolPeriod.Location = new System.Drawing.Point(341, 21);
            cmbSchoolPeriod.Name = "cmbSchoolPeriod";
            cmbSchoolPeriod.Size = new System.Drawing.Size(264, 26);
            cmbSchoolPeriod.TabIndex = 153;
            cmbSchoolPeriod.SelectedIndexChanged += cmbSchoolPeriod_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.DarkBlue;
            label1.Location = new System.Drawing.Point(6, 2);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 15);
            label1.TabIndex = 156;
            label1.Text = "Id allievo";
            // 
            // TxtIdStudent
            // 
            TxtIdStudent.Location = new System.Drawing.Point(6, 20);
            TxtIdStudent.Margin = new System.Windows.Forms.Padding(4);
            TxtIdStudent.Name = "TxtIdStudent";
            TxtIdStudent.ReadOnly = true;
            TxtIdStudent.Size = new System.Drawing.Size(77, 24);
            TxtIdStudent.TabIndex = 155;
            TxtIdStudent.TabStop = false;
            TxtIdStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgwNotes
            // 
            dgwNotes.AllowUserToAddRows = false;
            dgwNotes.AllowUserToDeleteRows = false;
            dgwNotes.AllowUserToOrderColumns = true;
            dgwNotes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwNotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwNotes.Location = new System.Drawing.Point(10, 120);
            dgwNotes.Margin = new System.Windows.Forms.Padding(4);
            dgwNotes.Name = "dgwNotes";
            dgwNotes.RowTemplate.Height = 24;
            dgwNotes.Size = new System.Drawing.Size(913, 129);
            dgwNotes.TabIndex = 157;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splitContainer1.Location = new System.Drawing.Point(3, 53);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(txtSumOfWeights);
            splitContainer1.Panel1.Controls.Add(lblAverage);
            splitContainer1.Panel1.Controls.Add(grpComplessivo);
            splitContainer1.Panel1.Controls.Add(grpPeriodOfQuestionsTopics);
            splitContainer1.Panel1.Controls.Add(txtWeightedAverage);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(dgwGrades);
            splitContainer1.Panel1.Controls.Add(cmbGradeType);
            splitContainer1.Panel1.Controls.Add(cmbSchoolSubjects);
            splitContainer1.Panel1.Controls.Add(lblSchoolSubject);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnSave);
            splitContainer1.Panel2.Controls.Add(btnEraseAnnotation);
            splitContainer1.Panel2.Controls.Add(btnAddAnnotation);
            splitContainer1.Panel2.Controls.Add(label9);
            splitContainer1.Panel2.Controls.Add(txtAnnotation);
            splitContainer1.Panel2.Controls.Add(chkCurrentAnnotationActive);
            splitContainer1.Panel2.Controls.Add(dgwNotes);
            splitContainer1.Panel2.Controls.Add(chkShowOnlyActive);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(txtIdStudentsAnnotation);
            splitContainer1.Size = new System.Drawing.Size(928, 734);
            splitContainer1.SplitterDistance = 477;
            splitContainer1.TabIndex = 157;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(693, 95);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(92, 18);
            label5.TabIndex = 151;
            label5.Text = "Somma pesi";
            label5.Visible = false;
            // 
            // txtSumOfWeights
            // 
            txtSumOfWeights.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtSumOfWeights.Location = new System.Drawing.Point(796, 86);
            txtSumOfWeights.Margin = new System.Windows.Forms.Padding(4);
            txtSumOfWeights.Name = "txtSumOfWeights";
            txtSumOfWeights.Size = new System.Drawing.Size(100, 37);
            txtSumOfWeights.TabIndex = 150;
            txtSumOfWeights.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtSumOfWeights.Visible = false;
            // 
            // lblAverage
            // 
            lblAverage.AutoSize = true;
            lblAverage.Location = new System.Drawing.Point(516, 14);
            lblAverage.Name = "lblAverage";
            lblAverage.Size = new System.Drawing.Size(96, 18);
            lblAverage.TabIndex = 149;
            lblAverage.Text = "Media pesata";
            // 
            // txtWeightedAverage
            // 
            txtWeightedAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtWeightedAverage.Location = new System.Drawing.Point(516, 45);
            txtWeightedAverage.Margin = new System.Windows.Forms.Padding(4);
            txtWeightedAverage.Name = "txtWeightedAverage";
            txtWeightedAverage.Size = new System.Drawing.Size(100, 37);
            txtWeightedAverage.TabIndex = 148;
            txtWeightedAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSave.Location = new System.Drawing.Point(543, 14);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(62, 37);
            btnSave.TabIndex = 183;
            btnSave.Text = "Salva";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnEraseAnnotation
            // 
            btnEraseAnnotation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnEraseAnnotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnEraseAnnotation.Location = new System.Drawing.Point(477, 14);
            btnEraseAnnotation.Name = "btnEraseAnnotation";
            btnEraseAnnotation.Size = new System.Drawing.Size(62, 37);
            btnEraseAnnotation.TabIndex = 182;
            btnEraseAnnotation.Text = "-";
            btnEraseAnnotation.UseVisualStyleBackColor = true;
            // 
            // btnAddAnnotation
            // 
            btnAddAnnotation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddAnnotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnAddAnnotation.Location = new System.Drawing.Point(411, 14);
            btnAddAnnotation.Name = "btnAddAnnotation";
            btnAddAnnotation.Size = new System.Drawing.Size(62, 37);
            btnAddAnnotation.TabIndex = 181;
            btnAddAnnotation.Text = "+";
            btnAddAnnotation.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label9.ForeColor = System.Drawing.Color.DarkBlue;
            label9.Location = new System.Drawing.Point(10, 19);
            label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(271, 38);
            label9.TabIndex = 180;
            label9.Text = "Annotazione";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAnnotation
            // 
            txtAnnotation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtAnnotation.Location = new System.Drawing.Point(9, 60);
            txtAnnotation.Multiline = true;
            txtAnnotation.Name = "txtAnnotation";
            txtAnnotation.Size = new System.Drawing.Size(914, 53);
            txtAnnotation.TabIndex = 177;
            // 
            // chkCurrentAnnotationActive
            // 
            chkCurrentAnnotationActive.AutoSize = true;
            chkCurrentAnnotationActive.Checked = true;
            chkCurrentAnnotationActive.CheckState = System.Windows.Forms.CheckState.Checked;
            chkCurrentAnnotationActive.Location = new System.Drawing.Point(617, 7);
            chkCurrentAnnotationActive.Name = "chkCurrentAnnotationActive";
            chkCurrentAnnotationActive.Size = new System.Drawing.Size(62, 22);
            chkCurrentAnnotationActive.TabIndex = 179;
            chkCurrentAnnotationActive.Text = "Attiva";
            chkCurrentAnnotationActive.UseVisualStyleBackColor = true;
            // 
            // chkShowOnlyActive
            // 
            chkShowOnlyActive.AutoSize = true;
            chkShowOnlyActive.Checked = true;
            chkShowOnlyActive.CheckState = System.Windows.Forms.CheckState.Checked;
            chkShowOnlyActive.Location = new System.Drawing.Point(617, 29);
            chkShowOnlyActive.Name = "chkShowOnlyActive";
            chkShowOnlyActive.Size = new System.Drawing.Size(162, 22);
            chkShowOnlyActive.TabIndex = 178;
            chkShowOnlyActive.Text = "visualizza solo attive";
            chkShowOnlyActive.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(864, 6);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(64, 18);
            label4.TabIndex = 175;
            label4.Text = "Id annot.";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(866, 27);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(59, 24);
            textBox1.TabIndex = 174;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(792, 6);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(64, 18);
            label3.TabIndex = 175;
            label3.Text = "Id annot.";
            // 
            // txtIdStudentsAnnotation
            // 
            txtIdStudentsAnnotation.Location = new System.Drawing.Point(795, 27);
            txtIdStudentsAnnotation.Name = "txtIdStudentsAnnotation";
            txtIdStudentsAnnotation.ReadOnly = true;
            txtIdStudentsAnnotation.Size = new System.Drawing.Size(59, 24);
            txtIdStudentsAnnotation.TabIndex = 174;
            // 
            // frmGradesStudentsSummary
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(929, 784);
            Controls.Add(lblCurrentStudent);
            Controls.Add(splitContainer1);
            Controls.Add(label1);
            Controls.Add(TxtIdStudent);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmGradesStudentsSummary";
            Text = "Riepilogo voti allievo";
            FormClosing += frmGradesSummary_FormClosing;
            Load += frmGradesStudentsSummary_Load;
            ((System.ComponentModel.ISupportInitialize)dgwGrades).EndInit();
            grpComplessivo.ResumeLayout(false);
            grpComplessivo.PerformLayout();
            grpPeriodOfQuestionsTopics.ResumeLayout(false);
            grpPeriodOfQuestionsTopics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwNotes).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridView dgwGrades;
        private System.Windows.Forms.Label lblCurrentStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpComplessivo;
        private System.Windows.Forms.ComboBox cmbGradeType;
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtSumOfWeights;
        private System.Windows.Forms.Label lblTypeOfGrade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.TextBox txtWeightedAverage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEraseAnnotation;
        private System.Windows.Forms.Button btnAddAnnotation;
        private System.Windows.Forms.Label label9;
    }
}