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
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            this.dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            this.lblSchoolSubject = new System.Windows.Forms.Label();
            this.dgwTopics = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSchoolSubject = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnRandomTopic = new System.Windows.Forms.Button();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtSchoolYear = new System.Windows.Forms.TextBox();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.chkVisualizePath = new System.Windows.Forms.CheckBox();
            this.cmbSchoolPeriod = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTopics)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(555, 15);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(36, 18);
            this.lblEnd.TabIndex = 134;
            this.lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(394, 15);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(42, 18);
            this.lblStart.TabIndex = 133;
            this.lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            this.dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            this.dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndPeriod.Location = new System.Drawing.Point(595, 12);
            this.dtpEndPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtpEndPeriod.Name = "dtpEndPeriod";
            this.dtpEndPeriod.Size = new System.Drawing.Size(111, 24);
            this.dtpEndPeriod.TabIndex = 132;
            // 
            // dtpStartPeriod
            // 
            this.dtpStartPeriod.CustomFormat = "yyyy-MM-dd";
            this.dtpStartPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartPeriod.Location = new System.Drawing.Point(438, 12);
            this.dtpStartPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtpStartPeriod.Name = "dtpStartPeriod";
            this.dtpStartPeriod.Size = new System.Drawing.Size(111, 24);
            this.dtpStartPeriod.TabIndex = 131;
            // 
            // lblSchoolSubject
            // 
            this.lblSchoolSubject.AutoSize = true;
            this.lblSchoolSubject.Location = new System.Drawing.Point(5, 16);
            this.lblSchoolSubject.Name = "lblSchoolSubject";
            this.lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            this.lblSchoolSubject.TabIndex = 136;
            this.lblSchoolSubject.Text = "Materia";
            // 
            // dgwTopics
            // 
            this.dgwTopics.AllowUserToAddRows = false;
            this.dgwTopics.AllowUserToDeleteRows = false;
            this.dgwTopics.AllowUserToOrderColumns = true;
            this.dgwTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwTopics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTopics.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwTopics.Location = new System.Drawing.Point(2, 48);
            this.dgwTopics.Margin = new System.Windows.Forms.Padding(4);
            this.dgwTopics.Name = "dgwTopics";
            this.dgwTopics.RowTemplate.Height = 24;
            this.dgwTopics.Size = new System.Drawing.Size(1158, 582);
            this.dgwTopics.TabIndex = 139;
            this.dgwTopics.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwTopics_CellClick);
            this.dgwTopics.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwTopics_CellContentClick);
            this.dgwTopics.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwTopics_CellContentDoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(912, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 35);
            this.btnSearch.TabIndex = 140;
            this.btnSearch.Text = "Cerca";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSchoolSubject
            // 
            this.txtSchoolSubject.Location = new System.Drawing.Point(68, 12);
            this.txtSchoolSubject.Name = "txtSchoolSubject";
            this.txtSchoolSubject.ReadOnly = true;
            this.txtSchoolSubject.Size = new System.Drawing.Size(82, 24);
            this.txtSchoolSubject.TabIndex = 141;
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoose.Location = new System.Drawing.Point(1085, 6);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 35);
            this.btnChoose.TabIndex = 142;
            this.btnChoose.Text = "Scegli";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnRandomTopic
            // 
            this.btnRandomTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRandomTopic.Location = new System.Drawing.Point(1004, 6);
            this.btnRandomTopic.Name = "btnRandomTopic";
            this.btnRandomTopic.Size = new System.Drawing.Size(75, 35);
            this.btnRandomTopic.TabIndex = 143;
            this.btnRandomTopic.Text = "Casuale";
            this.btnRandomTopic.UseVisualStyleBackColor = true;
            this.btnRandomTopic.Click += new System.EventHandler(this.btnRandomTopic_Click);
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(216, 12);
            this.txtClass.Name = "txtClass";
            this.txtClass.ReadOnly = true;
            this.txtClass.Size = new System.Drawing.Size(59, 24);
            this.txtClass.TabIndex = 145;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(156, 16);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(54, 18);
            this.lblClass.TabIndex = 144;
            this.lblClass.Text = "Classe";
            // 
            // txtSchoolYear
            // 
            this.txtSchoolYear.Location = new System.Drawing.Point(329, 12);
            this.txtSchoolYear.Name = "txtSchoolYear";
            this.txtSchoolYear.ReadOnly = true;
            this.txtSchoolYear.Size = new System.Drawing.Size(59, 24);
            this.txtSchoolYear.TabIndex = 147;
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.Location = new System.Drawing.Point(281, 16);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(42, 18);
            this.lblSchoolYear.TabIndex = 146;
            this.lblSchoolYear.Text = "Anno";
            // 
            // chkVisualizePath
            // 
            this.chkVisualizePath.AutoSize = true;
            this.chkVisualizePath.Location = new System.Drawing.Point(818, 59);
            this.chkVisualizePath.Name = "chkVisualizePath";
            this.chkVisualizePath.Size = new System.Drawing.Size(89, 22);
            this.chkVisualizePath.TabIndex = 151;
            this.chkVisualizePath.Text = "Vedi Path";
            this.chkVisualizePath.UseVisualStyleBackColor = true;
            this.chkVisualizePath.Visible = false;
            // 
            // cmbStandardPeriod
            // 
            this.cmbSchoolPeriod.FormattingEnabled = true;
            this.cmbSchoolPeriod.Items.AddRange(new object[] {
            "",
            "Settimana",
            "Mese",
            "Anno scolastico",
            "Da nuovo anno solare"});
            this.cmbSchoolPeriod.Location = new System.Drawing.Point(717, 10);
            this.cmbSchoolPeriod.Name = "cmbStandardPeriod";
            this.cmbSchoolPeriod.Size = new System.Drawing.Size(190, 26);
            this.cmbSchoolPeriod.TabIndex = 152;
            this.cmbSchoolPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbStandardPeriod_SelectedIndexChanged);
            // 
            // frmTopicChooseByPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1161, 633);
            this.Controls.Add(this.cmbSchoolPeriod);
            this.Controls.Add(this.chkVisualizePath);
            this.Controls.Add(this.txtSchoolYear);
            this.Controls.Add(this.lblSchoolYear);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.btnRandomTopic);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.txtSchoolSubject);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSchoolSubject);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpEndPeriod);
            this.Controls.Add(this.dtpStartPeriod);
            this.Controls.Add(this.dgwTopics);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTopicChooseByPeriod";
            this.Text = "Scelta argomenti fatti in un periodo";
            this.Load += new System.EventHandler(this.frmTopicChooseByPeriod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTopics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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