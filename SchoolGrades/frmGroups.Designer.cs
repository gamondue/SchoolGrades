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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroups));
            txtGroups = new System.Windows.Forms.TextBox();
            btnCreateFileGroups = new System.Windows.Forms.Button();
            txtClass = new System.Windows.Forms.TextBox();
            lblStudentsPerGroup = new System.Windows.Forms.Label();
            txtStudentsPerGroup = new System.Windows.Forms.TextBox();
            grpGroups = new System.Windows.Forms.GroupBox();
            rdbGradesBalanced = new System.Windows.Forms.RadioButton();
            rbdGroupsRandom = new System.Windows.Forms.RadioButton();
            rdbGroupsBestGradesTogether = new System.Windows.Forms.RadioButton();
            btnCreateGroups = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            txtNGroups = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtTotalStudentsToGroup = new System.Windows.Forms.TextBox();
            grpPeriodOfQuestionsTopics = new System.Windows.Forms.GroupBox();
            lblEnd = new System.Windows.Forms.Label();
            lblStart = new System.Windows.Forms.Label();
            dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
            dtpStartPeriod = new System.Windows.Forms.DateTimePicker();
            cmbSchoolPeriod = new System.Windows.Forms.ComboBox();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            grpGroups.SuspendLayout();
            grpPeriodOfQuestionsTopics.SuspendLayout();
            SuspendLayout();
            // 
            // txtGroups
            // 
            txtGroups.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtGroups.Location = new System.Drawing.Point(-10, 210);
            txtGroups.Multiline = true;
            txtGroups.Name = "txtGroups";
            txtGroups.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtGroups.Size = new System.Drawing.Size(535, 527);
            txtGroups.TabIndex = 0;
            // 
            // btnCreateFileGroups
            // 
            btnCreateFileGroups.Location = new System.Drawing.Point(205, 12);
            btnCreateFileGroups.Name = "btnCreateFileGroups";
            btnCreateFileGroups.Size = new System.Drawing.Size(75, 53);
            btnCreateFileGroups.TabIndex = 1;
            btnCreateFileGroups.Text = "Crea file";
            btnCreateFileGroups.UseVisualStyleBackColor = true;
            btnCreateFileGroups.Click += btnCreateFileGroups_Click;
            // 
            // txtClass
            // 
            txtClass.Location = new System.Drawing.Point(12, 21);
            txtClass.Name = "txtClass";
            txtClass.ReadOnly = true;
            txtClass.Size = new System.Drawing.Size(160, 24);
            txtClass.TabIndex = 2;
            // 
            // lblStudentsPerGroup
            // 
            lblStudentsPerGroup.AutoSize = true;
            lblStudentsPerGroup.Location = new System.Drawing.Point(15, 157);
            lblStudentsPerGroup.Name = "lblStudentsPerGroup";
            lblStudentsPerGroup.Size = new System.Drawing.Size(94, 18);
            lblStudentsPerGroup.TabIndex = 140;
            lblStudentsPerGroup.Text = "Allievi/gruppo";
            // 
            // txtStudentsPerGroup
            // 
            txtStudentsPerGroup.Location = new System.Drawing.Point(115, 154);
            txtStudentsPerGroup.Name = "txtStudentsPerGroup";
            txtStudentsPerGroup.Size = new System.Drawing.Size(46, 24);
            txtStudentsPerGroup.TabIndex = 139;
            txtStudentsPerGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtStudentsPerGroup.TextChanged += txtStudentsPerGroup_TextChanged;
            // 
            // grpGroups
            // 
            grpGroups.Controls.Add(rdbGradesBalanced);
            grpGroups.Controls.Add(rbdGroupsRandom);
            grpGroups.Controls.Add(rdbGroupsBestGradesTogether);
            grpGroups.ForeColor = System.Drawing.Color.DarkBlue;
            grpGroups.Location = new System.Drawing.Point(12, 57);
            grpGroups.Name = "grpGroups";
            grpGroups.Size = new System.Drawing.Size(183, 94);
            grpGroups.TabIndex = 138;
            grpGroups.TabStop = false;
            grpGroups.Text = "Criteri raggruppamento";
            grpGroups.Enter += grpGroups_Enter;
            // 
            // rdbGradesBalanced
            // 
            rdbGradesBalanced.AutoSize = true;
            rdbGradesBalanced.Location = new System.Drawing.Point(6, 64);
            rdbGradesBalanced.Name = "rdbGradesBalanced";
            rdbGradesBalanced.Size = new System.Drawing.Size(116, 22);
            rdbGradesBalanced.TabIndex = 5;
            rdbGradesBalanced.Text = "Voti equilibrati";
            rdbGradesBalanced.UseVisualStyleBackColor = true;
            rdbGradesBalanced.CheckedChanged += rbdTypeOfGroupings_CheckedChanged;
            // 
            // rbdGroupsRandom
            // 
            rbdGroupsRandom.AutoSize = true;
            rbdGroupsRandom.Checked = true;
            rbdGroupsRandom.Location = new System.Drawing.Point(6, 18);
            rbdGroupsRandom.Name = "rbdGroupsRandom";
            rbdGroupsRandom.Size = new System.Drawing.Size(72, 22);
            rbdGroupsRandom.TabIndex = 1;
            rbdGroupsRandom.TabStop = true;
            rbdGroupsRandom.Text = "A caso";
            rbdGroupsRandom.UseVisualStyleBackColor = true;
            rbdGroupsRandom.CheckedChanged += rbdTypeOfGroupings_CheckedChanged;
            // 
            // rdbGroupsBestGradesTogether
            // 
            rdbGroupsBestGradesTogether.AutoSize = true;
            rdbGroupsBestGradesTogether.Location = new System.Drawing.Point(6, 41);
            rdbGroupsBestGradesTogether.Name = "rdbGroupsBestGradesTogether";
            rdbGroupsBestGradesTogether.Size = new System.Drawing.Size(128, 22);
            rdbGroupsBestGradesTogether.TabIndex = 0;
            rdbGroupsBestGradesTogether.Text = "Voti alti insieme";
            rdbGroupsBestGradesTogether.UseVisualStyleBackColor = true;
            rdbGroupsBestGradesTogether.CheckedChanged += rbdTypeOfGroupings_CheckedChanged;
            // 
            // btnCreateGroups
            // 
            btnCreateGroups.Location = new System.Drawing.Point(205, 154);
            btnCreateGroups.Name = "btnCreateGroups";
            btnCreateGroups.Size = new System.Drawing.Size(75, 53);
            btnCreateGroups.TabIndex = 141;
            btnCreateGroups.Text = "Crea gruppi";
            btnCreateGroups.UseVisualStyleBackColor = true;
            btnCreateGroups.Click += btnCreateGroups_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 183);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 18);
            label1.TabIndex = 143;
            label1.Text = "N gruppi";
            // 
            // txtNGroups
            // 
            txtNGroups.Location = new System.Drawing.Point(115, 180);
            txtNGroups.Name = "txtNGroups";
            txtNGroups.Size = new System.Drawing.Size(46, 24);
            txtNGroups.TabIndex = 142;
            txtNGroups.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtNGroups.TextChanged += txtNGroups_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(203, 94);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(89, 18);
            label2.TabIndex = 145;
            label2.Text = "All. da raggr.";
            // 
            // txtTotalStudentsToGroup
            // 
            txtTotalStudentsToGroup.Enabled = false;
            txtTotalStudentsToGroup.Location = new System.Drawing.Point(220, 115);
            txtTotalStudentsToGroup.Name = "txtTotalStudentsToGroup";
            txtTotalStudentsToGroup.Size = new System.Drawing.Size(46, 24);
            txtTotalStudentsToGroup.TabIndex = 144;
            txtTotalStudentsToGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtTotalStudentsToGroup, "N.allievi da dividere in gruppi");
            // 
            // grpPeriodOfQuestionsTopics
            // 
            grpPeriodOfQuestionsTopics.Controls.Add(lblEnd);
            grpPeriodOfQuestionsTopics.Controls.Add(lblStart);
            grpPeriodOfQuestionsTopics.Controls.Add(dtpEndPeriod);
            grpPeriodOfQuestionsTopics.Controls.Add(dtpStartPeriod);
            grpPeriodOfQuestionsTopics.Controls.Add(cmbSchoolPeriod);
            grpPeriodOfQuestionsTopics.Enabled = false;
            grpPeriodOfQuestionsTopics.Location = new System.Drawing.Point(291, 57);
            grpPeriodOfQuestionsTopics.Name = "grpPeriodOfQuestionsTopics";
            grpPeriodOfQuestionsTopics.Size = new System.Drawing.Size(234, 128);
            grpPeriodOfQuestionsTopics.TabIndex = 147;
            grpPeriodOfQuestionsTopics.TabStop = false;
            grpPeriodOfQuestionsTopics.Text = "Periodo dei voti";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new System.Drawing.Point(65, 61);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new System.Drawing.Size(36, 18);
            lblEnd.TabIndex = 157;
            lblEnd.Text = "Fine";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new System.Drawing.Point(65, 24);
            lblStart.Name = "lblStart";
            lblStart.Size = new System.Drawing.Size(42, 18);
            lblStart.TabIndex = 156;
            lblStart.Text = "Inizio";
            // 
            // dtpEndPeriod
            // 
            dtpEndPeriod.CustomFormat = "yyyy-MM-dd";
            dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpEndPeriod.Location = new System.Drawing.Point(117, 56);
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
            dtpStartPeriod.Location = new System.Drawing.Point(117, 21);
            dtpStartPeriod.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            dtpStartPeriod.Name = "dtpStartPeriod";
            dtpStartPeriod.Size = new System.Drawing.Size(111, 24);
            dtpStartPeriod.TabIndex = 154;
            dtpStartPeriod.Value = new System.DateTime(2019, 1, 24, 0, 0, 0, 0);
            dtpStartPeriod.ValueChanged += dtpStartPeriod_ValueChanged;
            // 
            // cmbSchoolPeriod
            // 
            cmbSchoolPeriod.FormattingEnabled = true;
            cmbSchoolPeriod.Items.AddRange(new object[] { "", "Settimana", "Mese", "Anno scolastico", "Da nuovo anno solare" });
            cmbSchoolPeriod.Location = new System.Drawing.Point(6, 92);
            cmbSchoolPeriod.Name = "cmbSchoolPeriod";
            cmbSchoolPeriod.Size = new System.Drawing.Size(222, 26);
            cmbSchoolPeriod.TabIndex = 153;
            cmbSchoolPeriod.SelectedIndexChanged += cmbSchoolPeriod_SelectedIndexChanged;
            // 
            // frmGroups
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(537, 737);
            Controls.Add(grpPeriodOfQuestionsTopics);
            Controls.Add(label2);
            Controls.Add(txtTotalStudentsToGroup);
            Controls.Add(label1);
            Controls.Add(txtNGroups);
            Controls.Add(btnCreateGroups);
            Controls.Add(lblStudentsPerGroup);
            Controls.Add(txtStudentsPerGroup);
            Controls.Add(grpGroups);
            Controls.Add(txtClass);
            Controls.Add(btnCreateFileGroups);
            Controls.Add(txtGroups);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmGroups";
            Text = "Gruppi";
            Load += frmGroups_Load;
            grpGroups.ResumeLayout(false);
            grpGroups.PerformLayout();
            grpPeriodOfQuestionsTopics.ResumeLayout(false);
            grpPeriodOfQuestionsTopics.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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