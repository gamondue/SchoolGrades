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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGradesClassSummary));
            this.lblCurrentClass = new System.Windows.Forms.Label();
            this.lblSchoolSubject = new System.Windows.Forms.Label();
            this.cmbSchoolSubjects = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSummaryGradeType = new System.Windows.Forms.ComboBox();
            this.txtSummaryDatum = new System.Windows.Forms.TextBox();
            this.dgwGrades = new System.Windows.Forms.DataGridView();
            this.rdbShowGrades = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rdbShowWeights = new System.Windows.Forms.RadioButton();
            this.rdbShowWeightedGrades = new System.Windows.Forms.RadioButton();
            this.rdbShowWeightsOnOpenGrades = new System.Windows.Forms.RadioButton();
            this.rdbMissing = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNStudents = new System.Windows.Forms.TextBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.grpPeriodOfQuestionsTopics = new System.Windows.Forms.GroupBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            this.dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            this.rdbAmongPeriod = new System.Windows.Forms.RadioButton();
            this.cmbSchoolPeriod = new System.Windows.Forms.ComboBox();
            this.btnSaveOnFile = new System.Windows.Forms.Button();
            this.grpChosenQuery = new System.Windows.Forms.GroupBox();
            this.btnReadData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrades)).BeginInit();
            this.grpPeriodOfQuestionsTopics.SuspendLayout();
            this.grpChosenQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentClass
            // 
            this.lblCurrentClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentClass.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentClass.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentClass.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCurrentClass.Location = new System.Drawing.Point(254, 3);
            this.lblCurrentClass.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCurrentClass.Name = "lblCurrentClass";
            this.lblCurrentClass.Size = new System.Drawing.Size(609, 59);
            this.lblCurrentClass.TabIndex = 91;
            this.lblCurrentClass.Text = "Class";
            this.lblCurrentClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSchoolSubject
            // 
            this.lblSchoolSubject.BackColor = System.Drawing.Color.Transparent;
            this.lblSchoolSubject.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSchoolSubject.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSchoolSubject.Location = new System.Drawing.Point(253, 101);
            this.lblSchoolSubject.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSchoolSubject.Name = "lblSchoolSubject";
            this.lblSchoolSubject.Size = new System.Drawing.Size(244, 59);
            this.lblSchoolSubject.TabIndex = 107;
            this.lblSchoolSubject.Text = "Materia";
            this.lblSchoolSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSchoolSubjects
            // 
            this.cmbSchoolSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSchoolSubjects.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbSchoolSubjects.FormattingEnabled = true;
            this.cmbSchoolSubjects.Items.AddRange(new object[] {
            "Voticini",
            "Orali",
            "Scritti",
            "Pratici",
            "Scritto-grafici"});
            this.cmbSchoolSubjects.Location = new System.Drawing.Point(517, 113);
            this.cmbSchoolSubjects.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSchoolSubjects.Name = "cmbSchoolSubjects";
            this.cmbSchoolSubjects.Size = new System.Drawing.Size(288, 28);
            this.cmbSchoolSubjects.TabIndex = 106;
            this.cmbSchoolSubjects.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolSubjects_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(253, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 59);
            this.label2.TabIndex = 104;
            this.label2.Text = "Riepilogo dei voti di tipo ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSummaryGradeType
            // 
            this.cmbSummaryGradeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSummaryGradeType.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbSummaryGradeType.FormattingEnabled = true;
            this.cmbSummaryGradeType.Items.AddRange(new object[] {
            "Voticini",
            "Orali",
            "Scritti",
            "Pratici",
            "Scritto-grafici"});
            this.cmbSummaryGradeType.Location = new System.Drawing.Point(517, 66);
            this.cmbSummaryGradeType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSummaryGradeType.Name = "cmbSummaryGradeType";
            this.cmbSummaryGradeType.Size = new System.Drawing.Size(288, 28);
            this.cmbSummaryGradeType.TabIndex = 103;
            this.cmbSummaryGradeType.SelectedIndexChanged += new System.EventHandler(this.cmbSummaryGradeType_SelectedIndexChanged);
            // 
            // txtSummaryDatum
            // 
            this.txtSummaryDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtSummaryDatum.Location = new System.Drawing.Point(4, 175);
            this.txtSummaryDatum.Margin = new System.Windows.Forms.Padding(4);
            this.txtSummaryDatum.Name = "txtSummaryDatum";
            this.txtSummaryDatum.Size = new System.Drawing.Size(105, 37);
            this.txtSummaryDatum.TabIndex = 102;
            this.txtSummaryDatum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.dgwGrades.Location = new System.Drawing.Point(4, 220);
            this.dgwGrades.Margin = new System.Windows.Forms.Padding(4);
            this.dgwGrades.Name = "dgwGrades";
            this.dgwGrades.ReadOnly = true;
            this.dgwGrades.RowHeadersVisible = false;
            this.dgwGrades.RowTemplate.Height = 24;
            this.dgwGrades.Size = new System.Drawing.Size(900, 500);
            this.dgwGrades.TabIndex = 108;
            this.dgwGrades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwGrades_CellClick);
            this.dgwGrades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwGrades_CellContentClick);
            this.dgwGrades.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwGrades_CellDoubleClick);
            // 
            // rdbShowGrades
            // 
            this.rdbShowGrades.AutoSize = true;
            this.rdbShowGrades.Location = new System.Drawing.Point(6, 33);
            this.rdbShowGrades.Name = "rdbShowGrades";
            this.rdbShowGrades.Size = new System.Drawing.Size(55, 24);
            this.rdbShowGrades.TabIndex = 110;
            this.rdbShowGrades.Text = "Voti";
            this.toolTip1.SetToolTip(this.rdbShowGrades, "Mostra ogni singolo voto");
            this.rdbShowGrades.UseVisualStyleBackColor = true;
            this.rdbShowGrades.CheckedChanged += new System.EventHandler(this.rdbShowGrades_CheckedChanged);
            this.rdbShowGrades.Click += new System.EventHandler(this.rdb_Click);
            // 
            // rdbShowWeights
            // 
            this.rdbShowWeights.AutoSize = true;
            this.rdbShowWeights.Checked = true;
            this.rdbShowWeights.Location = new System.Drawing.Point(6, 81);
            this.rdbShowWeights.Name = "rdbShowWeights";
            this.rdbShowWeights.Size = new System.Drawing.Size(57, 24);
            this.rdbShowWeights.TabIndex = 111;
            this.rdbShowWeights.TabStop = true;
            this.rdbShowWeights.Text = "Pesi";
            this.toolTip1.SetToolTip(this.rdbShowWeights, "Ordina per somma pesi e voti");
            this.rdbShowWeights.UseVisualStyleBackColor = true;
            this.rdbShowWeights.CheckedChanged += new System.EventHandler(this.rdbShowWeights_CheckedChanged);
            this.rdbShowWeights.Click += new System.EventHandler(this.rdb_Click);
            // 
            // rdbShowWeightedGrades
            // 
            this.rdbShowWeightedGrades.AutoSize = true;
            this.rdbShowWeightedGrades.Location = new System.Drawing.Point(6, 57);
            this.rdbShowWeightedGrades.Name = "rdbShowWeightedGrades";
            this.rdbShowWeightedGrades.Size = new System.Drawing.Size(70, 24);
            this.rdbShowWeightedGrades.TabIndex = 112;
            this.rdbShowWeightedGrades.Text = "Medie";
            this.toolTip1.SetToolTip(this.rdbShowWeightedGrades, "Mostra media pesata per ogni allievo");
            this.rdbShowWeightedGrades.UseVisualStyleBackColor = true;
            this.rdbShowWeightedGrades.CheckedChanged += new System.EventHandler(this.rdbShowWeightedGrades_CheckedChanged);
            this.rdbShowWeightedGrades.Click += new System.EventHandler(this.rdb_Click);
            // 
            // rdbShowWeightsOnOpenGrades
            // 
            this.rdbShowWeightsOnOpenGrades.AutoSize = true;
            this.rdbShowWeightsOnOpenGrades.Location = new System.Drawing.Point(6, 105);
            this.rdbShowWeightsOnOpenGrades.Name = "rdbShowWeightsOnOpenGrades";
            this.rdbShowWeightsOnOpenGrades.Size = new System.Drawing.Size(101, 24);
            this.rdbShowWeightsOnOpenGrades.TabIndex = 147;
            this.rdbShowWeightsOnOpenGrades.Text = "Pesi aperti";
            this.toolTip1.SetToolTip(this.rdbShowWeightsOnOpenGrades, "Ordina per somma pesi su voti aperti");
            this.rdbShowWeightsOnOpenGrades.UseVisualStyleBackColor = true;
            this.rdbShowWeightsOnOpenGrades.CheckedChanged += new System.EventHandler(this.rdbShowWeightsOnOpenGrades_CheckedChanged);
            this.rdbShowWeightsOnOpenGrades.Click += new System.EventHandler(this.rdb_Click);
            // 
            // rdbMissing
            // 
            this.rdbMissing.AutoSize = true;
            this.rdbMissing.Location = new System.Drawing.Point(6, 9);
            this.rdbMissing.Name = "rdbMissing";
            this.rdbMissing.Size = new System.Drawing.Size(92, 24);
            this.rdbMissing.TabIndex = 149;
            this.rdbMissing.Text = "Mancanti";
            this.toolTip1.SetToolTip(this.rdbMissing, "Mostra elenco degli alleivi che non hanno neppure un voto");
            this.rdbMissing.UseVisualStyleBackColor = true;
            this.rdbMissing.CheckedChanged += new System.EventHandler(this.rdbMissing_CheckedChanged);
            this.rdbMissing.Click += new System.EventHandler(this.rdb_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(150, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 177;
            this.label6.Text = "n.Allievi";
            this.toolTip1.SetToolTip(this.label6, "Minuto di  inizio della lezione");
            // 
            // txtNStudents
            // 
            this.txtNStudents.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtNStudents.Location = new System.Drawing.Point(159, 180);
            this.txtNStudents.Name = "txtNStudents";
            this.txtNStudents.Size = new System.Drawing.Size(46, 26);
            this.txtNStudents.TabIndex = 176;
            this.txtNStudents.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtNStudents, "Minuti per allarme prima della fine");
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(3, 151);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(57, 20);
            this.lblSum.TabIndex = 113;
            this.lblSum.Text = "lblSum";
            // 
            // grpPeriodOfQuestionsTopics
            // 
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.lblEnd);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.lblStart);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.dtpEndPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.dtpStartPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.rdbAmongPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.cmbSchoolPeriod);
            this.grpPeriodOfQuestionsTopics.Location = new System.Drawing.Point(252, 154);
            this.grpPeriodOfQuestionsTopics.Name = "grpPeriodOfQuestionsTopics";
            this.grpPeriodOfQuestionsTopics.Size = new System.Drawing.Size(557, 58);
            this.grpPeriodOfQuestionsTopics.TabIndex = 146;
            this.grpPeriodOfQuestionsTopics.TabStop = false;
            this.grpPeriodOfQuestionsTopics.Text = "Periodo dei voti";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(171, 24);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(40, 20);
            this.lblEnd.TabIndex = 157;
            this.lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(2, 24);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(46, 20);
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
            this.dtpEndPeriod.Size = new System.Drawing.Size(111, 26);
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
            this.dtpStartPeriod.Size = new System.Drawing.Size(111, 26);
            this.dtpStartPeriod.TabIndex = 154;
            this.dtpStartPeriod.Value = new System.DateTime(2019, 1, 24, 0, 0, 0, 0);
            // 
            // rdbAmongPeriod
            // 
            this.rdbAmongPeriod.AutoSize = true;
            this.rdbAmongPeriod.Enabled = false;
            this.rdbAmongPeriod.Location = new System.Drawing.Point(7, 62);
            this.rdbAmongPeriod.Name = "rdbAmongPeriod";
            this.rdbAmongPeriod.Size = new System.Drawing.Size(118, 24);
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
            this.cmbSchoolPeriod.Size = new System.Drawing.Size(218, 28);
            this.cmbSchoolPeriod.TabIndex = 153;
            this.cmbSchoolPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolPeriod_SelectedIndexChanged);
            // 
            // btnSaveOnFile
            // 
            this.btnSaveOnFile.Location = new System.Drawing.Point(150, 70);
            this.btnSaveOnFile.Name = "btnSaveOnFile";
            this.btnSaveOnFile.Size = new System.Drawing.Size(75, 71);
            this.btnSaveOnFile.TabIndex = 148;
            this.btnSaveOnFile.Text = "Salva su file CSV";
            this.btnSaveOnFile.UseVisualStyleBackColor = true;
            this.btnSaveOnFile.Click += new System.EventHandler(this.btnSaveOnFile_Click);
            // 
            // grpChosenQuery
            // 
            this.grpChosenQuery.Controls.Add(this.rdbMissing);
            this.grpChosenQuery.Controls.Add(this.rdbShowGrades);
            this.grpChosenQuery.Controls.Add(this.rdbShowWeights);
            this.grpChosenQuery.Controls.Add(this.rdbShowWeightsOnOpenGrades);
            this.grpChosenQuery.Controls.Add(this.rdbShowWeightedGrades);
            this.grpChosenQuery.Location = new System.Drawing.Point(4, 6);
            this.grpChosenQuery.Name = "grpChosenQuery";
            this.grpChosenQuery.Size = new System.Drawing.Size(112, 132);
            this.grpChosenQuery.TabIndex = 150;
            this.grpChosenQuery.TabStop = false;
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(829, 164);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(75, 49);
            this.btnReadData.TabIndex = 178;
            this.btnReadData.Text = "Leggi dati";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // frmGradesClassSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(908, 721);
            this.Controls.Add(this.btnReadData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNStudents);
            this.Controls.Add(this.grpChosenQuery);
            this.Controls.Add(this.btnSaveOnFile);
            this.Controls.Add(this.grpPeriodOfQuestionsTopics);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.dgwGrades);
            this.Controls.Add(this.lblSchoolSubject);
            this.Controls.Add(this.cmbSchoolSubjects);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSummaryGradeType);
            this.Controls.Add(this.txtSummaryDatum);
            this.Controls.Add(this.lblCurrentClass);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmGradesClassSummary";
            this.Text = "Riepilogo voti classe";
            this.Load += new System.EventHandler(this.frmGradesClassSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrades)).EndInit();
            this.grpPeriodOfQuestionsTopics.ResumeLayout(false);
            this.grpPeriodOfQuestionsTopics.PerformLayout();
            this.grpChosenQuery.ResumeLayout(false);
            this.grpChosenQuery.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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