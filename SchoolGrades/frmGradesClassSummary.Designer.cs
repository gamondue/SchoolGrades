namespace SchoolGrades
{
    partial class frmGradesClassSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGradesClassSummary));
            lblCurrentClass = new System.Windows.Forms.Label();
            lblSchoolSubject = new System.Windows.Forms.Label();
            cmbSchoolSubjects = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            cmbSummaryGradeType = new System.Windows.Forms.ComboBox();
            txtSummaryDatum = new System.Windows.Forms.TextBox();
            dgwGrades = new System.Windows.Forms.DataGridView();
            rdbShowGrades = new System.Windows.Forms.RadioButton();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            rdbShowWeights = new System.Windows.Forms.RadioButton();
            rdbShowWeightedGrades = new System.Windows.Forms.RadioButton();
            rdbShowWeightsOnOpenGrades = new System.Windows.Forms.RadioButton();
            rdbMissing = new System.Windows.Forms.RadioButton();
            label6 = new System.Windows.Forms.Label();
            txtNStudents = new System.Windows.Forms.TextBox();
            lblSum = new System.Windows.Forms.Label();
            grpPeriodOfQuestionsTopics = new System.Windows.Forms.GroupBox();
            lblEnd = new System.Windows.Forms.Label();
            lblStart = new System.Windows.Forms.Label();
            dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            rdbAmongPeriod = new System.Windows.Forms.RadioButton();
            cmbSchoolPeriod = new System.Windows.Forms.ComboBox();
            btnSaveOnFile = new System.Windows.Forms.Button();
            grpChosenQuery = new System.Windows.Forms.GroupBox();
            btnReadData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgwGrades).BeginInit();
            grpPeriodOfQuestionsTopics.SuspendLayout();
            grpChosenQuery.SuspendLayout();
            SuspendLayout();
            // 
            // lblCurrentClass
            // 
            lblCurrentClass.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblCurrentClass.BackColor = System.Drawing.Color.Transparent;
            lblCurrentClass.Font = new System.Drawing.Font("Arial Black", 20.25F);
            lblCurrentClass.ForeColor = System.Drawing.Color.DarkBlue;
            lblCurrentClass.Location = new System.Drawing.Point(254, 12);
            lblCurrentClass.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblCurrentClass.Name = "lblCurrentClass";
            lblCurrentClass.Size = new System.Drawing.Size(609, 59);
            lblCurrentClass.TabIndex = 91;
            lblCurrentClass.Text = "Class";
            lblCurrentClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSchoolSubject
            // 
            lblSchoolSubject.BackColor = System.Drawing.Color.Transparent;
            lblSchoolSubject.Font = new System.Drawing.Font("Arial Black", 12F);
            lblSchoolSubject.ForeColor = System.Drawing.Color.DarkBlue;
            lblSchoolSubject.Location = new System.Drawing.Point(253, 110);
            lblSchoolSubject.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblSchoolSubject.Name = "lblSchoolSubject";
            lblSchoolSubject.Size = new System.Drawing.Size(328, 59);
            lblSchoolSubject.TabIndex = 107;
            lblSchoolSubject.Text = "Materia";
            lblSchoolSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSchoolSubjects
            // 
            cmbSchoolSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            cmbSchoolSubjects.ForeColor = System.Drawing.Color.DarkBlue;
            cmbSchoolSubjects.FormattingEnabled = true;
            cmbSchoolSubjects.Items.AddRange(new object[] { "Voticini", "Orali", "Scritti", "Pratici", "Scritto-grafici" });
            cmbSchoolSubjects.Location = new System.Drawing.Point(585, 125);
            cmbSchoolSubjects.Margin = new System.Windows.Forms.Padding(4);
            cmbSchoolSubjects.Name = "cmbSchoolSubjects";
            cmbSchoolSubjects.Size = new System.Drawing.Size(224, 28);
            cmbSchoolSubjects.TabIndex = 106;
            cmbSchoolSubjects.SelectedIndexChanged += cmbSchoolSubjects_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Arial Black", 12F);
            label2.ForeColor = System.Drawing.Color.DarkBlue;
            label2.Location = new System.Drawing.Point(253, 63);
            label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(328, 59);
            label2.TabIndex = 104;
            label2.Text = "Riepilogo dei voti di tipo ";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSummaryGradeType
            // 
            cmbSummaryGradeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            cmbSummaryGradeType.ForeColor = System.Drawing.Color.DarkBlue;
            cmbSummaryGradeType.FormattingEnabled = true;
            cmbSummaryGradeType.Items.AddRange(new object[] { "Voticini", "Orali", "Scritti", "Pratici", "Scritto-grafici" });
            cmbSummaryGradeType.Location = new System.Drawing.Point(585, 78);
            cmbSummaryGradeType.Margin = new System.Windows.Forms.Padding(4);
            cmbSummaryGradeType.Name = "cmbSummaryGradeType";
            cmbSummaryGradeType.Size = new System.Drawing.Size(224, 28);
            cmbSummaryGradeType.TabIndex = 103;
            cmbSummaryGradeType.SelectedIndexChanged += cmbSummaryGradeType_SelectedIndexChanged;
            // 
            // txtSummaryDatum
            // 
            txtSummaryDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold);
            txtSummaryDatum.Location = new System.Drawing.Point(4, 193);
            txtSummaryDatum.Margin = new System.Windows.Forms.Padding(4);
            txtSummaryDatum.Name = "txtSummaryDatum";
            txtSummaryDatum.Size = new System.Drawing.Size(105, 37);
            txtSummaryDatum.TabIndex = 102;
            txtSummaryDatum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgwGrades
            // 
            dgwGrades.AllowUserToAddRows = false;
            dgwGrades.AllowUserToDeleteRows = false;
            dgwGrades.AllowUserToOrderColumns = true;
            dgwGrades.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwGrades.Location = new System.Drawing.Point(4, 238);
            dgwGrades.Margin = new System.Windows.Forms.Padding(4);
            dgwGrades.Name = "dgwGrades";
            dgwGrades.ReadOnly = true;
            dgwGrades.RowHeadersVisible = false;
            dgwGrades.RowTemplate.Height = 24;
            dgwGrades.Size = new System.Drawing.Size(900, 482);
            dgwGrades.TabIndex = 108;
            dgwGrades.CellClick += dgwGrades_CellClick;
            dgwGrades.CellContentClick += dgwGrades_CellContentClick;
            dgwGrades.CellDoubleClick += dgwGrades_CellDoubleClick;
            // 
            // rdbShowGrades
            // 
            rdbShowGrades.AutoSize = true;
            rdbShowGrades.Location = new System.Drawing.Point(13, 46);
            rdbShowGrades.Name = "rdbShowGrades";
            rdbShowGrades.Size = new System.Drawing.Size(55, 24);
            rdbShowGrades.TabIndex = 110;
            rdbShowGrades.Text = "Voti";
            toolTip1.SetToolTip(rdbShowGrades, "Mostra ogni singolo voto");
            rdbShowGrades.UseVisualStyleBackColor = true;
            rdbShowGrades.Click += rdb_Click;
            // 
            // rdbShowWeights
            // 
            rdbShowWeights.AutoSize = true;
            rdbShowWeights.Checked = true;
            rdbShowWeights.Location = new System.Drawing.Point(13, 94);
            rdbShowWeights.Name = "rdbShowWeights";
            rdbShowWeights.Size = new System.Drawing.Size(57, 24);
            rdbShowWeights.TabIndex = 111;
            rdbShowWeights.TabStop = true;
            rdbShowWeights.Text = "Pesi";
            toolTip1.SetToolTip(rdbShowWeights, "Ordina per somma pesi e voti");
            rdbShowWeights.UseVisualStyleBackColor = true;
            rdbShowWeights.Click += rdb_Click;
            // 
            // rdbShowWeightedGrades
            // 
            rdbShowWeightedGrades.AutoSize = true;
            rdbShowWeightedGrades.Location = new System.Drawing.Point(13, 70);
            rdbShowWeightedGrades.Name = "rdbShowWeightedGrades";
            rdbShowWeightedGrades.Size = new System.Drawing.Size(70, 24);
            rdbShowWeightedGrades.TabIndex = 112;
            rdbShowWeightedGrades.Text = "Medie";
            toolTip1.SetToolTip(rdbShowWeightedGrades, "Mostra media pesata per ogni allievo");
            rdbShowWeightedGrades.UseVisualStyleBackColor = true;
            rdbShowWeightedGrades.Click += rdb_Click;
            // 
            // rdbShowWeightsOnOpenGrades
            // 
            rdbShowWeightsOnOpenGrades.AutoSize = true;
            rdbShowWeightsOnOpenGrades.Location = new System.Drawing.Point(13, 118);
            rdbShowWeightsOnOpenGrades.Name = "rdbShowWeightsOnOpenGrades";
            rdbShowWeightsOnOpenGrades.Size = new System.Drawing.Size(101, 24);
            rdbShowWeightsOnOpenGrades.TabIndex = 147;
            rdbShowWeightsOnOpenGrades.Text = "Pesi aperti";
            toolTip1.SetToolTip(rdbShowWeightsOnOpenGrades, "Ordina per somma pesi su voti aperti");
            rdbShowWeightsOnOpenGrades.UseVisualStyleBackColor = true;
            rdbShowWeightsOnOpenGrades.Click += rdb_Click;
            // 
            // rdbMissing
            // 
            rdbMissing.AutoSize = true;
            rdbMissing.Location = new System.Drawing.Point(13, 22);
            rdbMissing.Name = "rdbMissing";
            rdbMissing.Size = new System.Drawing.Size(92, 24);
            rdbMissing.TabIndex = 149;
            rdbMissing.Text = "Mancanti";
            toolTip1.SetToolTip(rdbMissing, "Mostra elenco degli alleivi che non hanno neppure un voto");
            rdbMissing.UseVisualStyleBackColor = true;
            rdbMissing.Click += rdb_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.Color.DarkBlue;
            label6.Location = new System.Drawing.Point(150, 170);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(61, 20);
            label6.TabIndex = 177;
            label6.Text = "n.Allievi";
            toolTip1.SetToolTip(label6, "Minuto di  inizio della lezione");
            // 
            // txtNStudents
            // 
            txtNStudents.ForeColor = System.Drawing.Color.DarkBlue;
            txtNStudents.Location = new System.Drawing.Point(159, 198);
            txtNStudents.Name = "txtNStudents";
            txtNStudents.Size = new System.Drawing.Size(46, 26);
            txtNStudents.TabIndex = 176;
            txtNStudents.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtNStudents, "Minuti per allarme prima della fine");
            // 
            // lblSum
            // 
            lblSum.AutoSize = true;
            lblSum.Location = new System.Drawing.Point(3, 169);
            lblSum.Name = "lblSum";
            lblSum.Size = new System.Drawing.Size(57, 20);
            lblSum.TabIndex = 113;
            lblSum.Text = "lblSum";
            // 
            // grpPeriodOfQuestionsTopics
            // 
            grpPeriodOfQuestionsTopics.Controls.Add(lblEnd);
            grpPeriodOfQuestionsTopics.Controls.Add(lblStart);
            grpPeriodOfQuestionsTopics.Controls.Add(dtpEndPeriod);
            grpPeriodOfQuestionsTopics.Controls.Add(dtpStartPeriod);
            grpPeriodOfQuestionsTopics.Controls.Add(rdbAmongPeriod);
            grpPeriodOfQuestionsTopics.Controls.Add(cmbSchoolPeriod);
            grpPeriodOfQuestionsTopics.Location = new System.Drawing.Point(252, 172);
            grpPeriodOfQuestionsTopics.Name = "grpPeriodOfQuestionsTopics";
            grpPeriodOfQuestionsTopics.Size = new System.Drawing.Size(557, 58);
            grpPeriodOfQuestionsTopics.TabIndex = 146;
            grpPeriodOfQuestionsTopics.TabStop = false;
            grpPeriodOfQuestionsTopics.Text = "Periodo dei voti";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new System.Drawing.Point(171, 24);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new System.Drawing.Size(40, 20);
            lblEnd.TabIndex = 157;
            lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new System.Drawing.Point(2, 24);
            lblStart.Name = "lblStart";
            lblStart.Size = new System.Drawing.Size(46, 20);
            lblStart.TabIndex = 156;
            lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpEndPeriod.Location = new System.Drawing.Point(211, 21);
            dtpEndPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            dtpEndPeriod.Name = "dtpEndPeriod";
            dtpEndPeriod.Size = new System.Drawing.Size(111, 26);
            dtpEndPeriod.TabIndex = 155;
            dtpEndPeriod.Value = new System.DateTime(2019, 6, 7, 0, 0, 0, 0);
            // 
            // dtpStartPeriod
            // 
            dtpStartPeriod.CustomFormat = "yyyy-MM-dd";
            dtpStartPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpStartPeriod.Location = new System.Drawing.Point(54, 21);
            dtpStartPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            dtpStartPeriod.Name = "dtpStartPeriod";
            dtpStartPeriod.Size = new System.Drawing.Size(111, 26);
            dtpStartPeriod.TabIndex = 154;
            dtpStartPeriod.Value = new System.DateTime(2019, 1, 24, 0, 0, 0, 0);
            // 
            // rdbAmongPeriod
            // 
            rdbAmongPeriod.AutoSize = true;
            rdbAmongPeriod.Enabled = false;
            rdbAmongPeriod.Location = new System.Drawing.Point(7, 62);
            rdbAmongPeriod.Name = "rdbAmongPeriod";
            rdbAmongPeriod.Size = new System.Drawing.Size(118, 24);
            rdbAmongPeriod.TabIndex = 2;
            rdbAmongPeriod.Text = "in un periodo";
            rdbAmongPeriod.UseVisualStyleBackColor = true;
            rdbAmongPeriod.Visible = false;
            // 
            // cmbSchoolPeriod
            // 
            cmbSchoolPeriod.FormattingEnabled = true;
            cmbSchoolPeriod.Items.AddRange(new object[] { "", "Settimana", "Mese", "Anno scolastico", "Da nuovo anno solare" });
            cmbSchoolPeriod.Location = new System.Drawing.Point(333, 21);
            cmbSchoolPeriod.Name = "cmbSchoolPeriod";
            cmbSchoolPeriod.Size = new System.Drawing.Size(224, 28);
            cmbSchoolPeriod.TabIndex = 153;
            cmbSchoolPeriod.SelectedIndexChanged += cmbSchoolPeriod_SelectedIndexChanged;
            // 
            // btnSaveOnFile
            // 
            btnSaveOnFile.Location = new System.Drawing.Point(150, 79);
            btnSaveOnFile.Name = "btnSaveOnFile";
            btnSaveOnFile.Size = new System.Drawing.Size(75, 71);
            btnSaveOnFile.TabIndex = 148;
            btnSaveOnFile.Text = "Salva su file CSV";
            btnSaveOnFile.UseVisualStyleBackColor = true;
            btnSaveOnFile.Click += btnSaveOnFile_Click;
            // 
            // grpChosenQuery
            // 
            grpChosenQuery.Controls.Add(rdbMissing);
            grpChosenQuery.Controls.Add(rdbShowGrades);
            grpChosenQuery.Controls.Add(rdbShowWeights);
            grpChosenQuery.Controls.Add(rdbShowWeightsOnOpenGrades);
            grpChosenQuery.Controls.Add(rdbShowWeightedGrades);
            grpChosenQuery.Location = new System.Drawing.Point(4, 12);
            grpChosenQuery.Name = "grpChosenQuery";
            grpChosenQuery.Size = new System.Drawing.Size(140, 145);
            grpChosenQuery.TabIndex = 150;
            grpChosenQuery.TabStop = false;
            // 
            // btnReadData
            // 
            btnReadData.Location = new System.Drawing.Point(829, 182);
            btnReadData.Name = "btnReadData";
            btnReadData.Size = new System.Drawing.Size(75, 49);
            btnReadData.TabIndex = 178;
            btnReadData.Text = "Leggi dati";
            btnReadData.UseVisualStyleBackColor = true;
            btnReadData.Click += btnReadData_Click;
            // 
            // frmGradesClassSummary
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(908, 721);
            Controls.Add(btnReadData);
            Controls.Add(label6);
            Controls.Add(txtNStudents);
            Controls.Add(grpChosenQuery);
            Controls.Add(btnSaveOnFile);
            Controls.Add(grpPeriodOfQuestionsTopics);
            Controls.Add(lblSum);
            Controls.Add(dgwGrades);
            Controls.Add(lblSchoolSubject);
            Controls.Add(cmbSchoolSubjects);
            Controls.Add(label2);
            Controls.Add(cmbSummaryGradeType);
            Controls.Add(txtSummaryDatum);
            Controls.Add(lblCurrentClass);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "frmGradesClassSummary";
            Text = "Riepilogo voti classe";
            Load += frmGradesClassSummary_Load;
            ((System.ComponentModel.ISupportInitialize)dgwGrades).EndInit();
            grpPeriodOfQuestionsTopics.ResumeLayout(false);
            grpPeriodOfQuestionsTopics.PerformLayout();
            grpChosenQuery.ResumeLayout(false);
            grpChosenQuery.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentClass;
        private System.Windows.Forms.Label lblSchoolSubject;
        private System.Windows.Forms.ComboBox cmbSchoolSubjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSummaryGradeType;
        private System.Windows.Forms.TextBox txtMediaMicroDomande;
        private System.Windows.Forms.DataGridView dgwGrades;
        private System.Windows.Forms.RadioButton rdbShowGrades;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton rdbShowWeights;
        private System.Windows.Forms.RadioButton rdbShowWeightedGrades;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.GroupBox grpPeriodOfQuestionsTopics;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpEndPeriod;
        private System.Windows.Forms.DateTimePicker dtpStartPeriod;
        private System.Windows.Forms.RadioButton rdbAmongPeriod;
        private System.Windows.Forms.ComboBox cmbSchoolPeriod;
        private System.Windows.Forms.RadioButton rdbShowWeightsOnOpenGrades;
        private System.Windows.Forms.Button btnSaveOnFile;
        private System.Windows.Forms.RadioButton rdbMissing;
        private System.Windows.Forms.GroupBox grpChosenQuery;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNStudents;
        private System.Windows.Forms.TextBox txtSummaryDatum;
        private System.Windows.Forms.Button btnReadData;
    }
}