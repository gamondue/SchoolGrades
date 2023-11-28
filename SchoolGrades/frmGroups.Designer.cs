namespace SchoolGrades
{
    partial class frmGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroups));
            this.txtGroups = new System.Windows.Forms.TextBox();
            this.btnCreateFileGroups = new System.Windows.Forms.Button();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.lblStudentsPerGroup = new System.Windows.Forms.Label();
            this.txtStudentsPerGroup = new System.Windows.Forms.TextBox();
            this.grpGroups = new System.Windows.Forms.GroupBox();
            this.rdbGradesBalanced = new System.Windows.Forms.RadioButton();
            this.rbdGroupsRandom = new System.Windows.Forms.RadioButton();
            this.rdbGroupsBestGradesTogether = new System.Windows.Forms.RadioButton();
            this.btnCreateGroups = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNGroups = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalStudentsToGroup = new System.Windows.Forms.TextBox();
            this.grpPeriodOfQuestionsTopics = new System.Windows.Forms.GroupBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            this.dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            this.cmbSchoolPeriod = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpGroups.SuspendLayout();
            this.grpPeriodOfQuestionsTopics.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGroups
            // 
            this.txtGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroups.Location = new System.Drawing.Point(0, 210);
            this.txtGroups.Multiline = true;
            this.txtGroups.Name = "txtGroups";
            this.txtGroups.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGroups.Size = new System.Drawing.Size(535, 527);
            this.txtGroups.TabIndex = 0;
            // 
            // btnCreateFileGroups
            // 
            this.btnCreateFileGroups.Location = new System.Drawing.Point(205, 12);
            this.btnCreateFileGroups.Name = "btnCreateFileGroups";
            this.btnCreateFileGroups.Size = new System.Drawing.Size(75, 53);
            this.btnCreateFileGroups.TabIndex = 1;
            this.btnCreateFileGroups.Text = "Crea file";
            this.btnCreateFileGroups.UseVisualStyleBackColor = true;
            this.btnCreateFileGroups.Click += new System.EventHandler(this.btnCreateFileGroups_Click);
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(12, 21);
            this.txtClass.Name = "txtClass";
            this.txtClass.ReadOnly = true;
            this.txtClass.Size = new System.Drawing.Size(160, 24);
            this.txtClass.TabIndex = 2;
            // 
            // lblStudentsPerGroup
            // 
            this.lblStudentsPerGroup.AutoSize = true;
            this.lblStudentsPerGroup.Location = new System.Drawing.Point(15, 157);
            this.lblStudentsPerGroup.Name = "lblStudentsPerGroup";
            this.lblStudentsPerGroup.Size = new System.Drawing.Size(94, 18);
            this.lblStudentsPerGroup.TabIndex = 140;
            this.lblStudentsPerGroup.Text = "Allievi/gruppo";
            // 
            // txtStudentsPerGroup
            // 
            this.txtStudentsPerGroup.Location = new System.Drawing.Point(115, 154);
            this.txtStudentsPerGroup.Name = "txtStudentsPerGroup";
            this.txtStudentsPerGroup.Size = new System.Drawing.Size(46, 24);
            this.txtStudentsPerGroup.TabIndex = 139;
            this.txtStudentsPerGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStudentsPerGroup.TextChanged += new System.EventHandler(this.txtStudentsPerGroup_TextChanged);
            // 
            // grpGroups
            // 
            this.grpGroups.Controls.Add(this.rdbGradesBalanced);
            this.grpGroups.Controls.Add(this.rbdGroupsRandom);
            this.grpGroups.Controls.Add(this.rdbGroupsBestGradesTogether);
            this.grpGroups.ForeColor = System.Drawing.Color.DarkBlue;
            this.grpGroups.Location = new System.Drawing.Point(12, 57);
            this.grpGroups.Name = "grpGroups";
            this.grpGroups.Size = new System.Drawing.Size(183, 94);
            this.grpGroups.TabIndex = 138;
            this.grpGroups.TabStop = false;
            this.grpGroups.Text = "Criteri raggruppamento";
            this.grpGroups.Enter += new System.EventHandler(this.grpGroups_Enter);
            // 
            // rdbGradesBalanced
            // 
            this.rdbGradesBalanced.AutoSize = true;
            this.rdbGradesBalanced.Location = new System.Drawing.Point(6, 64);
            this.rdbGradesBalanced.Name = "rdbGradesBalanced";
            this.rdbGradesBalanced.Size = new System.Drawing.Size(116, 22);
            this.rdbGradesBalanced.TabIndex = 5;
            this.rdbGradesBalanced.Text = "Voti equilibrati";
            this.rdbGradesBalanced.UseVisualStyleBackColor = true;
            this.rdbGradesBalanced.CheckedChanged += new System.EventHandler(this.rbdTypeOfGroupings_CheckedChanged);
            // 
            // rbdGroupsRandom
            // 
            this.rbdGroupsRandom.AutoSize = true;
            this.rbdGroupsRandom.Checked = true;
            this.rbdGroupsRandom.Location = new System.Drawing.Point(6, 18);
            this.rbdGroupsRandom.Name = "rbdGroupsRandom";
            this.rbdGroupsRandom.Size = new System.Drawing.Size(72, 22);
            this.rbdGroupsRandom.TabIndex = 1;
            this.rbdGroupsRandom.TabStop = true;
            this.rbdGroupsRandom.Text = "A caso";
            this.rbdGroupsRandom.UseVisualStyleBackColor = true;
            this.rbdGroupsRandom.CheckedChanged += new System.EventHandler(this.rbdTypeOfGroupings_CheckedChanged);
            // 
            // rdbGroupsBestGradesTogether
            // 
            this.rdbGroupsBestGradesTogether.AutoSize = true;
            this.rdbGroupsBestGradesTogether.Location = new System.Drawing.Point(6, 41);
            this.rdbGroupsBestGradesTogether.Name = "rdbGroupsBestGradesTogether";
            this.rdbGroupsBestGradesTogether.Size = new System.Drawing.Size(128, 22);
            this.rdbGroupsBestGradesTogether.TabIndex = 0;
            this.rdbGroupsBestGradesTogether.Text = "Voti alti insieme";
            this.rdbGroupsBestGradesTogether.UseVisualStyleBackColor = true;
            this.rdbGroupsBestGradesTogether.CheckedChanged += new System.EventHandler(this.rbdTypeOfGroupings_CheckedChanged);
            // 
            // btnCreateGroups
            // 
            this.btnCreateGroups.Location = new System.Drawing.Point(205, 154);
            this.btnCreateGroups.Name = "btnCreateGroups";
            this.btnCreateGroups.Size = new System.Drawing.Size(75, 53);
            this.btnCreateGroups.TabIndex = 141;
            this.btnCreateGroups.Text = "Crea gruppi";
            this.btnCreateGroups.UseVisualStyleBackColor = true;
            this.btnCreateGroups.Click += new System.EventHandler(this.btnCreateGroups_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 143;
            this.label1.Text = "N gruppi";
            // 
            // txtNGroups
            // 
            this.txtNGroups.Location = new System.Drawing.Point(115, 180);
            this.txtNGroups.Name = "txtNGroups";
            this.txtNGroups.Size = new System.Drawing.Size(46, 24);
            this.txtNGroups.TabIndex = 142;
            this.txtNGroups.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNGroups.TextChanged += new System.EventHandler(this.txtNGroups_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 145;
            this.label2.Text = "All. da raggr.";
            // 
            // txtTotalStudentsToGroup
            // 
            this.txtTotalStudentsToGroup.Enabled = false;
            this.txtTotalStudentsToGroup.Location = new System.Drawing.Point(220, 115);
            this.txtTotalStudentsToGroup.Name = "txtTotalStudentsToGroup";
            this.txtTotalStudentsToGroup.Size = new System.Drawing.Size(46, 24);
            this.txtTotalStudentsToGroup.TabIndex = 144;
            this.txtTotalStudentsToGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtTotalStudentsToGroup, "N.allievi da dividere in gruppi");
            // 
            // grpPeriodOfQuestionsTopics
            // 
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.lblEnd);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.lblStart);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.dtpEndPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.dtpStartPeriod);
            this.grpPeriodOfQuestionsTopics.Controls.Add(this.cmbSchoolPeriod);
            this.grpPeriodOfQuestionsTopics.Enabled = false;
            this.grpPeriodOfQuestionsTopics.Location = new System.Drawing.Point(291, 57);
            this.grpPeriodOfQuestionsTopics.Name = "grpPeriodOfQuestionsTopics";
            this.grpPeriodOfQuestionsTopics.Size = new System.Drawing.Size(234, 128);
            this.grpPeriodOfQuestionsTopics.TabIndex = 147;
            this.grpPeriodOfQuestionsTopics.TabStop = false;
            this.grpPeriodOfQuestionsTopics.Text = "Periodo dei voti";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(65, 61);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(36, 18);
            this.lblEnd.TabIndex = 157;
            this.lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(65, 24);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(42, 18);
            this.lblStart.TabIndex = 156;
            this.lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            this.dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            this.dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndPeriod.Location = new System.Drawing.Point(117, 56);
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
            this.dtpStartPeriod.Location = new System.Drawing.Point(117, 21);
            this.dtpStartPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtpStartPeriod.Name = "dtpStartPeriod";
            this.dtpStartPeriod.Size = new System.Drawing.Size(111, 24);
            this.dtpStartPeriod.TabIndex = 154;
            this.dtpStartPeriod.Value = new System.DateTime(2019, 1, 24, 0, 0, 0, 0);
            this.dtpStartPeriod.ValueChanged += new System.EventHandler(this.dtpStartPeriod_ValueChanged);
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
            this.cmbSchoolPeriod.Location = new System.Drawing.Point(6, 92);
            this.cmbSchoolPeriod.Name = "cmbSchoolPeriod";
            this.cmbSchoolPeriod.Size = new System.Drawing.Size(222, 26);
            this.cmbSchoolPeriod.TabIndex = 153;
            this.cmbSchoolPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolPeriod_SelectedIndexChanged);
            // 
            // frmGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(537, 737);
            this.Controls.Add(this.grpPeriodOfQuestionsTopics);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalStudentsToGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNGroups);
            this.Controls.Add(this.btnCreateGroups);
            this.Controls.Add(this.lblStudentsPerGroup);
            this.Controls.Add(this.txtStudentsPerGroup);
            this.Controls.Add(this.grpGroups);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.btnCreateFileGroups);
            this.Controls.Add(this.txtGroups);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGroups";
            this.Text = "Gruppi";
            this.Load += new System.EventHandler(this.frmGroups_Load);
            this.grpGroups.ResumeLayout(false);
            this.grpGroups.PerformLayout();
            this.grpPeriodOfQuestionsTopics.ResumeLayout(false);
            this.grpPeriodOfQuestionsTopics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGroups;
        private System.Windows.Forms.Button btnCreateFileGroups;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblStudentsPerGroup;
        private System.Windows.Forms.TextBox txtStudentsPerGroup;
        private System.Windows.Forms.GroupBox grpGroups;
        private System.Windows.Forms.RadioButton rdbGradesBalanced;
        private System.Windows.Forms.RadioButton rbdGroupsRandom;
        private System.Windows.Forms.RadioButton rdbGroupsBestGradesTogether;
        private System.Windows.Forms.Button btnCreateGroups;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNGroups;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalStudentsToGroup;
        private System.Windows.Forms.GroupBox grpPeriodOfQuestionsTopics;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpEndPeriod;
        private System.Windows.Forms.DateTimePicker dtpStartPeriod;
        private System.Windows.Forms.ComboBox cmbSchoolPeriod;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}