namespace SchoolGrades
{
    partial class frmTopicChooseByPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopicChooseByPeriod));
            lblEnd = new System.Windows.Forms.Label();
            lblStart = new System.Windows.Forms.Label();
            dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            lblSchoolSubject = new System.Windows.Forms.Label();
            dgwTopics = new System.Windows.Forms.DataGridView();
            btnSearch = new System.Windows.Forms.Button();
            txtSchoolSubject = new System.Windows.Forms.TextBox();
            btnChoose = new System.Windows.Forms.Button();
            btnRandomTopic = new System.Windows.Forms.Button();
            txtClass = new System.Windows.Forms.TextBox();
            lblClass = new System.Windows.Forms.Label();
            txtSchoolYear = new System.Windows.Forms.TextBox();
            lblSchoolYear = new System.Windows.Forms.Label();
            chkVisualizePath = new System.Windows.Forms.CheckBox();
            cmbSchoolPeriod = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgwTopics).BeginInit();
            SuspendLayout();
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new System.Drawing.Point(555, 15);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new System.Drawing.Size(36, 18);
            lblEnd.TabIndex = 134;
            lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new System.Drawing.Point(394, 15);
            lblStart.Name = "lblStart";
            lblStart.Size = new System.Drawing.Size(42, 18);
            lblStart.TabIndex = 133;
            lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpEndPeriod.Location = new System.Drawing.Point(595, 12);
            dtpEndPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            dtpEndPeriod.Name = "dtpEndPeriod";
            dtpEndPeriod.Size = new System.Drawing.Size(111, 24);
            dtpEndPeriod.TabIndex = 132;
            // 
            // dtpStartPeriod
            // 
            dtpStartPeriod.CustomFormat = "yyyy-MM-dd";
            dtpStartPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpStartPeriod.Location = new System.Drawing.Point(438, 12);
            dtpStartPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            dtpStartPeriod.Name = "dtpStartPeriod";
            dtpStartPeriod.Size = new System.Drawing.Size(111, 24);
            dtpStartPeriod.TabIndex = 131;
            // 
            // lblSchoolSubject
            // 
            lblSchoolSubject.AutoSize = true;
            lblSchoolSubject.Location = new System.Drawing.Point(5, 16);
            lblSchoolSubject.Name = "lblSchoolSubject";
            lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            lblSchoolSubject.TabIndex = 136;
            lblSchoolSubject.Text = "Materia";
            lblSchoolSubject.Click += lblSchoolSubject_Click;
            // 
            // dgwTopics
            // 
            dgwTopics.AllowUserToAddRows = false;
            dgwTopics.AllowUserToDeleteRows = false;
            dgwTopics.AllowUserToOrderColumns = true;
            dgwTopics.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwTopics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwTopics.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgwTopics.Location = new System.Drawing.Point(2, 48);
            dgwTopics.Margin = new System.Windows.Forms.Padding(4);
            dgwTopics.Name = "dgwTopics";
            dgwTopics.RowTemplate.Height = 24;
            dgwTopics.Size = new System.Drawing.Size(1158, 582);
            dgwTopics.TabIndex = 139;
            dgwTopics.CellClick += dgwTopics_CellClick;
            dgwTopics.CellContentClick += dgwTopics_CellContentClick;
            dgwTopics.CellContentDoubleClick += dgwTopics_CellContentDoubleClick;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSearch.Location = new System.Drawing.Point(912, 6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(75, 35);
            btnSearch.TabIndex = 140;
            btnSearch.Text = "Cerca";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSchoolSubject
            // 
            txtSchoolSubject.Location = new System.Drawing.Point(68, 12);
            txtSchoolSubject.Name = "txtSchoolSubject";
            txtSchoolSubject.ReadOnly = true;
            txtSchoolSubject.Size = new System.Drawing.Size(82, 24);
            txtSchoolSubject.TabIndex = 141;
            // 
            // btnChoose
            // 
            btnChoose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnChoose.Location = new System.Drawing.Point(1085, 6);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(75, 35);
            btnChoose.TabIndex = 142;
            btnChoose.Text = "Scegli";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click;
            // 
            // btnRandomTopic
            // 
            btnRandomTopic.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRandomTopic.Location = new System.Drawing.Point(1004, 6);
            btnRandomTopic.Name = "btnRandomTopic";
            btnRandomTopic.Size = new System.Drawing.Size(75, 35);
            btnRandomTopic.TabIndex = 143;
            btnRandomTopic.Text = "Casuale";
            btnRandomTopic.UseVisualStyleBackColor = true;
            btnRandomTopic.Click += btnRandomTopic_Click;
            // 
            // txtClass
            // 
            txtClass.Location = new System.Drawing.Point(216, 12);
            txtClass.Name = "txtClass";
            txtClass.ReadOnly = true;
            txtClass.Size = new System.Drawing.Size(59, 24);
            txtClass.TabIndex = 145;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new System.Drawing.Point(156, 16);
            lblClass.Name = "lblClass";
            lblClass.Size = new System.Drawing.Size(54, 18);
            lblClass.TabIndex = 144;
            lblClass.Text = "Classe";
            // 
            // txtSchoolYear
            // 
            txtSchoolYear.Location = new System.Drawing.Point(329, 12);
            txtSchoolYear.Name = "txtSchoolYear";
            txtSchoolYear.ReadOnly = true;
            txtSchoolYear.Size = new System.Drawing.Size(59, 24);
            txtSchoolYear.TabIndex = 147;
            // 
            // lblSchoolYear
            // 
            lblSchoolYear.AutoSize = true;
            lblSchoolYear.Location = new System.Drawing.Point(281, 16);
            lblSchoolYear.Name = "lblSchoolYear";
            lblSchoolYear.Size = new System.Drawing.Size(42, 18);
            lblSchoolYear.TabIndex = 146;
            lblSchoolYear.Text = "Anno";
            // 
            // chkVisualizePath
            // 
            chkVisualizePath.AutoSize = true;
            chkVisualizePath.Location = new System.Drawing.Point(818, 59);
            chkVisualizePath.Name = "chkVisualizePath";
            chkVisualizePath.Size = new System.Drawing.Size(89, 22);
            chkVisualizePath.TabIndex = 151;
            chkVisualizePath.Text = "Vedi Path";
            chkVisualizePath.UseVisualStyleBackColor = true;
            chkVisualizePath.Visible = false;
            // 
            // cmbSchoolPeriod
            // 
            cmbSchoolPeriod.FormattingEnabled = true;
            cmbSchoolPeriod.Items.AddRange(new object[] { "", "Settimana", "Mese", "Anno scolastico", "Da nuovo anno solare" });
            cmbSchoolPeriod.Location = new System.Drawing.Point(717, 10);
            cmbSchoolPeriod.Name = "cmbSchoolPeriod";
            cmbSchoolPeriod.Size = new System.Drawing.Size(190, 26);
            cmbSchoolPeriod.TabIndex = 152;
            cmbSchoolPeriod.SelectedIndexChanged += cmbStandardPeriod_SelectedIndexChanged;
            // 
            // frmTopicChooseByPeriod
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(1161, 633);
            Controls.Add(cmbSchoolPeriod);
            Controls.Add(chkVisualizePath);
            Controls.Add(txtSchoolYear);
            Controls.Add(lblSchoolYear);
            Controls.Add(txtClass);
            Controls.Add(lblClass);
            Controls.Add(btnRandomTopic);
            Controls.Add(btnChoose);
            Controls.Add(txtSchoolSubject);
            Controls.Add(btnSearch);
            Controls.Add(lblSchoolSubject);
            Controls.Add(lblEnd);
            Controls.Add(lblStart);
            Controls.Add(dtpEndPeriod);
            Controls.Add(dtpStartPeriod);
            Controls.Add(dgwTopics);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmTopicChooseByPeriod";
            Text = "Scelta argomenti fatti in un periodo";
            Load += frmTopicChooseByPeriod_Load;
            ((System.ComponentModel.ISupportInitialize)dgwTopics).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpEndPeriod;
        private System.Windows.Forms.DateTimePicker dtpStartPeriod;
        private System.Windows.Forms.Label lblSchoolSubject;
        private System.Windows.Forms.DataGridView dgwTopics;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSchoolSubject;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnRandomTopic;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.TextBox txtSchoolYear;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.CheckBox chkVisualizePath;
        private System.Windows.Forms.ComboBox cmbSchoolPeriod;
    }
}