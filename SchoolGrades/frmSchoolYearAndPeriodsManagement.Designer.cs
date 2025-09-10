
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSchoolYearAndPeriodsManagement));
            grpPeriodOfQuestionsTopics = new System.Windows.Forms.GroupBox();
            lblEnd = new System.Windows.Forms.Label();
            lblStart = new System.Windows.Forms.Label();
            dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            dgwSchoolPeriods = new System.Windows.Forms.DataGridView();
            btnNewYear = new System.Windows.Forms.Button();
            txtSchoolYear = new System.Windows.Forms.TextBox();
            lblSchoolYear = new System.Windows.Forms.Label();
            btnNewPeriod = new System.Windows.Forms.Button();
            btnDeletePeriod = new System.Windows.Forms.Button();
            txtIdSchoolPeriod = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            btnSaveSchoolPeriod = new System.Windows.Forms.Button();
            txtName = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtDescription = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            cmbSchoolPeriodTypes = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            rdbQuadrimester = new System.Windows.Forms.RadioButton();
            rdbTrimester = new System.Windows.Forms.RadioButton();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            grpPeriodOfQuestionsTopics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwSchoolPeriods).BeginInit();
            SuspendLayout();
            // 
            // grpPeriodOfQuestionsTopics
            // 
            grpPeriodOfQuestionsTopics.Controls.Add(lblEnd);
            grpPeriodOfQuestionsTopics.Controls.Add(lblStart);
            grpPeriodOfQuestionsTopics.Controls.Add(dtpEndPeriod);
            grpPeriodOfQuestionsTopics.Controls.Add(dtpStartPeriod);
            grpPeriodOfQuestionsTopics.Location = new System.Drawing.Point(171, 12);
            grpPeriodOfQuestionsTopics.Name = "grpPeriodOfQuestionsTopics";
            grpPeriodOfQuestionsTopics.Size = new System.Drawing.Size(209, 94);
            grpPeriodOfQuestionsTopics.TabIndex = 148;
            grpPeriodOfQuestionsTopics.TabStop = false;
            grpPeriodOfQuestionsTopics.Text = "Date del periodo scolastico";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new System.Drawing.Point(2, 61);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new System.Drawing.Size(36, 20);
            lblEnd.TabIndex = 157;
            lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new System.Drawing.Point(2, 24);
            lblStart.Name = "lblStart";
            lblStart.Size = new System.Drawing.Size(45, 20);
            lblStart.TabIndex = 156;
            lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpEndPeriod.Location = new System.Drawing.Point(54, 56);
            dtpEndPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            dtpEndPeriod.Name = "dtpEndPeriod";
            dtpEndPeriod.Size = new System.Drawing.Size(111, 27);
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
            dtpStartPeriod.Size = new System.Drawing.Size(111, 27);
            dtpStartPeriod.TabIndex = 154;
            dtpStartPeriod.Value = new System.DateTime(2019, 1, 24, 0, 0, 0, 0);
            // 
            // dgwSchoolPeriods
            // 
            dgwSchoolPeriods.AllowUserToAddRows = false;
            dgwSchoolPeriods.AllowUserToDeleteRows = false;
            dgwSchoolPeriods.AllowUserToOrderColumns = true;
            dgwSchoolPeriods.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwSchoolPeriods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwSchoolPeriods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwSchoolPeriods.Location = new System.Drawing.Point(1, 164);
            dgwSchoolPeriods.Margin = new System.Windows.Forms.Padding(4);
            dgwSchoolPeriods.Name = "dgwSchoolPeriods";
            dgwSchoolPeriods.ReadOnly = true;
            dgwSchoolPeriods.RowTemplate.Height = 24;
            dgwSchoolPeriods.Size = new System.Drawing.Size(776, 346);
            dgwSchoolPeriods.TabIndex = 149;
            dgwSchoolPeriods.CellClick += dgwSchoolPeriods_CellClick;
            dgwSchoolPeriods.CellContentClick += dgwSchoolPeriods_CellContentClick;
            // 
            // btnNewYear
            // 
            btnNewYear.Location = new System.Drawing.Point(1, 100);
            btnNewYear.Name = "btnNewYear";
            btnNewYear.Size = new System.Drawing.Size(75, 60);
            btnNewYear.TabIndex = 150;
            btnNewYear.Text = "Periodi anno";
            toolTip1.SetToolTip(btnNewYear, "Genera tutti i periodi \"standard\" dell'anno");
            btnNewYear.UseVisualStyleBackColor = true;
            btnNewYear.Click += btnNewYear_Click;
            // 
            // txtSchoolYear
            // 
            txtSchoolYear.Location = new System.Drawing.Point(76, 70);
            txtSchoolYear.Name = "txtSchoolYear";
            txtSchoolYear.Size = new System.Drawing.Size(59, 27);
            txtSchoolYear.TabIndex = 152;
            // 
            // lblSchoolYear
            // 
            lblSchoolYear.AutoSize = true;
            lblSchoolYear.Location = new System.Drawing.Point(28, 74);
            lblSchoolYear.Name = "lblSchoolYear";
            lblSchoolYear.Size = new System.Drawing.Size(44, 20);
            lblSchoolYear.TabIndex = 151;
            lblSchoolYear.Text = "Anno";
            // 
            // btnNewPeriod
            // 
            btnNewPeriod.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNewPeriod.Location = new System.Drawing.Point(784, 164);
            btnNewPeriod.Name = "btnNewPeriod";
            btnNewPeriod.Size = new System.Drawing.Size(36, 39);
            btnNewPeriod.TabIndex = 153;
            btnNewPeriod.Text = "+";
            btnNewPeriod.UseVisualStyleBackColor = true;
            btnNewPeriod.Click += btnNewPeriod_Click;
            // 
            // btnDeletePeriod
            // 
            btnDeletePeriod.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDeletePeriod.Location = new System.Drawing.Point(784, 209);
            btnDeletePeriod.Name = "btnDeletePeriod";
            btnDeletePeriod.Size = new System.Drawing.Size(36, 39);
            btnDeletePeriod.TabIndex = 154;
            btnDeletePeriod.Text = "-";
            btnDeletePeriod.UseVisualStyleBackColor = true;
            btnDeletePeriod.Click += btnDeletePeriod_Click;
            // 
            // txtIdSchoolPeriod
            // 
            txtIdSchoolPeriod.Location = new System.Drawing.Point(76, 33);
            txtIdSchoolPeriod.Name = "txtIdSchoolPeriod";
            txtIdSchoolPeriod.ReadOnly = true;
            txtIdSchoolPeriod.Size = new System.Drawing.Size(59, 27);
            txtIdSchoolPeriod.TabIndex = 156;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 36);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 20);
            label1.TabIndex = 155;
            label1.Text = "Codice";
            // 
            // btnSaveSchoolPeriod
            // 
            btnSaveSchoolPeriod.Location = new System.Drawing.Point(702, 56);
            btnSaveSchoolPeriod.Name = "btnSaveSchoolPeriod";
            btnSaveSchoolPeriod.Size = new System.Drawing.Size(75, 73);
            btnSaveSchoolPeriod.TabIndex = 157;
            btnSaveSchoolPeriod.Text = "Salva singolo periodo";
            toolTip1.SetToolTip(btnSaveSchoolPeriod, "Salva il periodo i cui dati sono nella finestra");
            btnSaveSchoolPeriod.UseVisualStyleBackColor = true;
            btnSaveSchoolPeriod.Click += btnSaveSchoolPeriod_Click;
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(539, 33);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(140, 27);
            txtName.TabIndex = 159;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(373, 38);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(127, 20);
            label2.TabIndex = 158;
            label2.Text = "Descrizione breve";
            // 
            // txtDescription
            // 
            txtDescription.Location = new System.Drawing.Point(225, 123);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(454, 27);
            txtDescription.TabIndex = 161;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(225, 100);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(86, 20);
            label3.TabIndex = 160;
            label3.Text = "Descrizione";
            // 
            // cmbSchoolPeriodTypes
            // 
            cmbSchoolPeriodTypes.FormattingEnabled = true;
            cmbSchoolPeriodTypes.Location = new System.Drawing.Point(418, 69);
            cmbSchoolPeriodTypes.Name = "cmbSchoolPeriodTypes";
            cmbSchoolPeriodTypes.Size = new System.Drawing.Size(261, 28);
            cmbSchoolPeriodTypes.TabIndex = 162;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(373, 74);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(39, 20);
            label4.TabIndex = 163;
            label4.Text = "Tipo";
            // 
            // rdbQuadrimester
            // 
            rdbQuadrimester.AutoSize = true;
            rdbQuadrimester.Checked = true;
            rdbQuadrimester.Location = new System.Drawing.Point(82, 105);
            rdbQuadrimester.Name = "rdbQuadrimester";
            rdbQuadrimester.Size = new System.Drawing.Size(111, 24);
            rdbQuadrimester.TabIndex = 164;
            rdbQuadrimester.TabStop = true;
            rdbQuadrimester.Text = "quadrimestri";
            rdbQuadrimester.UseVisualStyleBackColor = true;
            // 
            // rdbTrimester
            // 
            rdbTrimester.AutoSize = true;
            rdbTrimester.Location = new System.Drawing.Point(82, 126);
            rdbTrimester.Name = "rdbTrimester";
            rdbTrimester.Size = new System.Drawing.Size(82, 24);
            rdbTrimester.TabIndex = 165;
            rdbTrimester.Text = "trimestri";
            rdbTrimester.UseVisualStyleBackColor = true;
            // 
            // frmSchoolYearAndPeriodsManagement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(825, 514);
            Controls.Add(rdbTrimester);
            Controls.Add(rdbQuadrimester);
            Controls.Add(label4);
            Controls.Add(cmbSchoolPeriodTypes);
            Controls.Add(txtDescription);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(btnSaveSchoolPeriod);
            Controls.Add(txtIdSchoolPeriod);
            Controls.Add(label1);
            Controls.Add(btnDeletePeriod);
            Controls.Add(btnNewPeriod);
            Controls.Add(txtSchoolYear);
            Controls.Add(lblSchoolYear);
            Controls.Add(btnNewYear);
            Controls.Add(dgwSchoolPeriods);
            Controls.Add(grpPeriodOfQuestionsTopics);
            Font = new System.Drawing.Font("Segoe UI", 11.25F);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "frmSchoolYearAndPeriodsManagement";
            Text = "Gestione periodi scolastici";
            Load += frmSchoolPeriodsManagement_Load;
            grpPeriodOfQuestionsTopics.ResumeLayout(false);
            grpPeriodOfQuestionsTopics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwSchoolPeriods).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.ToolTip toolTip1;
    }
}