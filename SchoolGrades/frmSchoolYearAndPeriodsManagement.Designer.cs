
namespace SchoolGrades
{
    partial class frmSchoolYearAndPeriodsManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSchoolYearAndPeriodsManagement));
            this.grpPeriodOfQuestionsTopics = new System.Windows.Forms.GroupBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            this.dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            this.dgwSchoolPeriods = new System.Windows.Forms.DataGridView();
            this.btnNewYear = new System.Windows.Forms.Button();
            this.txtSchoolYear = new System.Windows.Forms.TextBox();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.btnNewPeriod = new System.Windows.Forms.Button();
            this.btnDeletePeriod = new System.Windows.Forms.Button();
            this.txtIdSchoolPeriod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveSchoolPeriod = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSchoolPeriodTypes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdbQuadrimester = new System.Windows.Forms.RadioButton();
            this.rdbTrimester = new System.Windows.Forms.RadioButton();
            this.grpPeriodOfQuestionsTopics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSchoolPeriods)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPeriodOfQuestionsTopics
            // 
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.lblEnd);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.lblStart);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.dtpEndPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.dtpStartPeriod);
            this.grpPeriodOfQuestionsTopics.Location = new System.Drawing.Point(171, 12);
            this.grpPeriodOfQuestionsTopics.Name = "grpPeriodOfQuestionsTopics";
            this.grpPeriodOfQuestionsTopics.Size = new System.Drawing.Size(209, 94);
            this.grpPeriodOfQuestionsTopics.TabIndex = 148;
            this.grpPeriodOfQuestionsTopics.TabStop = false;
            this.grpPeriodOfQuestionsTopics.Text = "Date del periodo scolastico";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(2, 61);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(36, 20);
            this.lblEnd.TabIndex = 157;
            this.lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(2, 24);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(45, 20);
            this.lblStart.TabIndex = 156;
            this.lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            this.dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            this.dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndPeriod.Location = new System.Drawing.Point(54, 56);
            this.dtpEndPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtpEndPeriod.Name = "dtpEndPeriod";
            this.dtpEndPeriod.Size = new System.Drawing.Size(111, 27);
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
            this.dtpStartPeriod.Size = new System.Drawing.Size(111, 27);
            this.dtpStartPeriod.TabIndex = 154;
            this.dtpStartPeriod.Value = new System.DateTime(2019, 1, 24, 0, 0, 0, 0);
            // 
            // dgwSchoolPeriods
            // 
            this.dgwSchoolPeriods.AllowUserToAddRows = false;
            this.dgwSchoolPeriods.AllowUserToDeleteRows = false;
            this.dgwSchoolPeriods.AllowUserToOrderColumns = true;
            this.dgwSchoolPeriods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwSchoolPeriods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwSchoolPeriods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSchoolPeriods.Location = new System.Drawing.Point(1, 164);
            this.dgwSchoolPeriods.Margin = new System.Windows.Forms.Padding(4);
            this.dgwSchoolPeriods.Name = "dgwSchoolPeriods";
            this.dgwSchoolPeriods.ReadOnly = true;
            this.dgwSchoolPeriods.RowTemplate.Height = 24;
            this.dgwSchoolPeriods.Size = new System.Drawing.Size(776, 346);
            this.dgwSchoolPeriods.TabIndex = 149;
            this.dgwSchoolPeriods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwSchoolPeriods_CellClick);
            this.dgwSchoolPeriods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwSchoolPeriods_CellContentClick);
            // 
            // btnNewYear
            // 
            this.btnNewYear.Location = new System.Drawing.Point(143, 100);
            this.btnNewYear.Name = "btnNewYear";
            this.btnNewYear.Size = new System.Drawing.Size(75, 60);
            this.btnNewYear.TabIndex = 150;
            this.btnNewYear.Text = "Nuovo anno";
            this.btnNewYear.UseVisualStyleBackColor = true;
            this.btnNewYear.Click += new System.EventHandler(this.btnNewYear_Click);
            // 
            // txtSchoolYear
            // 
            this.txtSchoolYear.Location = new System.Drawing.Point(76, 70);
            this.txtSchoolYear.Name = "txtSchoolYear";
            this.txtSchoolYear.Size = new System.Drawing.Size(59, 27);
            this.txtSchoolYear.TabIndex = 152;
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.Location = new System.Drawing.Point(28, 74);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(44, 20);
            this.lblSchoolYear.TabIndex = 151;
            this.lblSchoolYear.Text = "Anno";
            // 
            // btnNewPeriod
            // 
            this.btnNewPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewPeriod.Location = new System.Drawing.Point(784, 164);
            this.btnNewPeriod.Name = "btnNewPeriod";
            this.btnNewPeriod.Size = new System.Drawing.Size(36, 39);
            this.btnNewPeriod.TabIndex = 153;
            this.btnNewPeriod.Text = "+";
            this.btnNewPeriod.UseVisualStyleBackColor = true;
            this.btnNewPeriod.Click += new System.EventHandler(this.btnNewPeriod_Click);
            // 
            // btnDeletePeriod
            // 
            this.btnDeletePeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletePeriod.Location = new System.Drawing.Point(784, 209);
            this.btnDeletePeriod.Name = "btnDeletePeriod";
            this.btnDeletePeriod.Size = new System.Drawing.Size(36, 39);
            this.btnDeletePeriod.TabIndex = 154;
            this.btnDeletePeriod.Text = "-";
            this.btnDeletePeriod.UseVisualStyleBackColor = true;
            this.btnDeletePeriod.Click += new System.EventHandler(this.btnDeletePeriod_Click);
            // 
            // txtIdSchoolPeriod
            // 
            this.txtIdSchoolPeriod.Location = new System.Drawing.Point(76, 33);
            this.txtIdSchoolPeriod.Name = "txtIdSchoolPeriod";
            this.txtIdSchoolPeriod.ReadOnly = true;
            this.txtIdSchoolPeriod.Size = new System.Drawing.Size(59, 27);
            this.txtIdSchoolPeriod.TabIndex = 156;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 155;
            this.label1.Text = "Codice";
            // 
            // btnSaveSchoolPeriod
            // 
            this.btnSaveSchoolPeriod.Location = new System.Drawing.Point(706, 52);
            this.btnSaveSchoolPeriod.Name = "btnSaveSchoolPeriod";
            this.btnSaveSchoolPeriod.Size = new System.Drawing.Size(75, 60);
            this.btnSaveSchoolPeriod.TabIndex = 157;
            this.btnSaveSchoolPeriod.Text = "Salva periodo";
            this.btnSaveSchoolPeriod.UseVisualStyleBackColor = true;
            this.btnSaveSchoolPeriod.Click += new System.EventHandler(this.btnSaveSchoolPeriod_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(539, 33);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(140, 27);
            this.txtName.TabIndex = 159;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 158;
            this.label2.Text = "Descrizione breve";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(225, 123);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(454, 27);
            this.txtDescription.TabIndex = 161;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 160;
            this.label3.Text = "Descrizione";
            // 
            // cmbSchoolPeriodTypes
            // 
            this.cmbSchoolPeriodTypes.FormattingEnabled = true;
            this.cmbSchoolPeriodTypes.Location = new System.Drawing.Point(418, 69);
            this.cmbSchoolPeriodTypes.Name = "cmbSchoolPeriodTypes";
            this.cmbSchoolPeriodTypes.Size = new System.Drawing.Size(261, 28);
            this.cmbSchoolPeriodTypes.TabIndex = 162;
            this.cmbSchoolPeriodTypes.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolPeriodTypes_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 163;
            this.label4.Text = "Tipo";
            // 
            // rdbQuadrimester
            // 
            this.rdbQuadrimester.AutoSize = true;
            this.rdbQuadrimester.Checked = true;
            this.rdbQuadrimester.Location = new System.Drawing.Point(28, 108);
            this.rdbQuadrimester.Name = "rdbQuadrimester";
            this.rdbQuadrimester.Size = new System.Drawing.Size(111, 24);
            this.rdbQuadrimester.TabIndex = 164;
            this.rdbQuadrimester.TabStop = true;
            this.rdbQuadrimester.Text = "quadrimestri";
            this.rdbQuadrimester.UseVisualStyleBackColor = true;
            // 
            // rdbTrimester
            // 
            this.rdbTrimester.AutoSize = true;
            this.rdbTrimester.Location = new System.Drawing.Point(28, 133);
            this.rdbTrimester.Name = "rdbTrimester";
            this.rdbTrimester.Size = new System.Drawing.Size(82, 24);
            this.rdbTrimester.TabIndex = 165;
            this.rdbTrimester.Text = "trimestri";
            this.rdbTrimester.UseVisualStyleBackColor = true;
            // 
            // frmSchoolYearAndPeriodsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(825, 514);
            this.Controls.Add(this.rdbTrimester);
            this.Controls.Add(this.rdbQuadrimester);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSchoolPeriodTypes);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveSchoolPeriod);
            this.Controls.Add(this.txtIdSchoolPeriod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeletePeriod);
            this.Controls.Add(this.btnNewPeriod);
            this.Controls.Add(this.txtSchoolYear);
            this.Controls.Add(this.lblSchoolYear);
            this.Controls.Add(this.btnNewYear);
            this.Controls.Add(this.dgwSchoolPeriods);
            this.Controls.Add(this.grpPeriodOfQuestionsTopics);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSchoolYearAndPeriodsManagement";
            this.Text = "Gestione periodi scolastici";
            this.Load += new System.EventHandler(this.frmSchoolPeriodsManagement_Load);
            this.grpPeriodOfQuestionsTopics.ResumeLayout(false);
            this.grpPeriodOfQuestionsTopics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSchoolPeriods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPeriodOfQuestionsTopics;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpEndPeriod;
        private System.Windows.Forms.DateTimePicker dtpStartPeriod;
        private System.Windows.Forms.DataGridView dgwSchoolPeriods;
        private System.Windows.Forms.Button btnNewYear;
        private System.Windows.Forms.TextBox txtSchoolYear;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.Button btnNewPeriod;
        private System.Windows.Forms.Button btnDeletePeriod;
        private System.Windows.Forms.TextBox txtIdSchoolPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveSchoolPeriod;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSchoolPeriodTypes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbQuadrimester;
        private System.Windows.Forms.RadioButton rdbTrimester;
    }
}