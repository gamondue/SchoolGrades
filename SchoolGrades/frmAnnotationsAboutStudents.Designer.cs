namespace SchoolGrades
{
    partial class frmAnnotationsAboutStudents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnnotationsAboutStudents));
            dgwNotes = new System.Windows.Forms.DataGridView();
            lblCurrentStudent = new System.Windows.Forms.Label();
            txtSchoolYear = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            dgwStudents = new System.Windows.Forms.DataGridView();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            chkUseSchoolYear = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            txtIdStudent = new System.Windows.Forms.TextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            btnAddAnnotationGroup = new System.Windows.Forms.Button();
            btnRemoveAnnotationGroup = new System.Windows.Forms.Button();
            btnSaveModificationsGroup = new System.Windows.Forms.Button();
            grpSingleButtons = new System.Windows.Forms.GroupBox();
            btnSaveModificationsStudent = new System.Windows.Forms.Button();
            btnRemoveAnnotationStudent = new System.Windows.Forms.Button();
            btnAddAnnotationStudent = new System.Windows.Forms.Button();
            chkCurrentActive = new System.Windows.Forms.CheckBox();
            chkPopUp = new System.Windows.Forms.CheckBox();
            btnPrepareNew = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            txtAnnotation = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtIdAnnotation = new System.Windows.Forms.TextBox();
            chkShowOnlyActive = new System.Windows.Forms.CheckBox();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgwNotes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgwStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            grpSingleButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dgwNotes
            // 
            dgwNotes.AllowUserToAddRows = false;
            dgwNotes.AllowUserToDeleteRows = false;
            dgwNotes.AllowUserToOrderColumns = true;
            dgwNotes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwNotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwNotes.Location = new System.Drawing.Point(-1, 155);
            dgwNotes.Margin = new System.Windows.Forms.Padding(4);
            dgwNotes.Name = "dgwNotes";
            dgwNotes.RowTemplate.Height = 24;
            dgwNotes.Size = new System.Drawing.Size(831, 122);
            dgwNotes.TabIndex = 163;
            dgwNotes.CellClick += dgwNotes_CellClick;
            dgwNotes.CellContentClick += dgwNotes_CellContentClick;
            // 
            // lblCurrentStudent
            // 
            lblCurrentStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblCurrentStudent.BackColor = System.Drawing.Color.Transparent;
            lblCurrentStudent.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblCurrentStudent.ForeColor = System.Drawing.Color.DarkBlue;
            lblCurrentStudent.Location = new System.Drawing.Point(7, 3);
            lblCurrentStudent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblCurrentStudent.Name = "lblCurrentStudent";
            lblCurrentStudent.Size = new System.Drawing.Size(831, 53);
            lblCurrentStudent.TabIndex = 158;
            lblCurrentStudent.Text = "Annotazioni su allievi o gruppi";
            lblCurrentStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSchoolYear
            // 
            txtSchoolYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtSchoolYear.Enabled = false;
            txtSchoolYear.Location = new System.Drawing.Point(760, 25);
            txtSchoolYear.Name = "txtSchoolYear";
            txtSchoolYear.Size = new System.Drawing.Size(55, 24);
            txtSchoolYear.TabIndex = 169;
            txtSchoolYear.TextChanged += txtSchoolYear_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(751, 5);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 15);
            label1.TabIndex = 170;
            label1.Text = "Anno scol.";
            // 
            // dgwStudents
            // 
            dgwStudents.AllowUserToAddRows = false;
            dgwStudents.AllowUserToDeleteRows = false;
            dgwStudents.AllowUserToOrderColumns = true;
            dgwStudents.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwStudents.Location = new System.Drawing.Point(0, 0);
            dgwStudents.Margin = new System.Windows.Forms.Padding(4);
            dgwStudents.Name = "dgwStudents";
            dgwStudents.RowTemplate.Height = 24;
            dgwStudents.Size = new System.Drawing.Size(730, 220);
            dgwStudents.TabIndex = 171;
            dgwStudents.CellClick += dgwStudents_CellClick;
            dgwStudents.CellContentClick += dgwStudents_CellContentClick;
            dgwStudents.RowEnter += dgwStudents_RowEnter;
            dgwStudents.RowLeave += dgwStudents_RowLeave;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            splitContainer1.Location = new System.Drawing.Point(7, 59);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(chkUseSchoolYear);
            splitContainer1.Panel1.Controls.Add(dgwStudents);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(txtIdStudent);
            splitContainer1.Panel1.Controls.Add(txtSchoolYear);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Panel2.Controls.Add(grpSingleButtons);
            splitContainer1.Panel2.Controls.Add(chkCurrentActive);
            splitContainer1.Panel2.Controls.Add(chkPopUp);
            splitContainer1.Panel2.Controls.Add(btnPrepareNew);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(txtAnnotation);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(txtIdAnnotation);
            splitContainer1.Panel2.Controls.Add(chkShowOnlyActive);
            splitContainer1.Panel2.Controls.Add(dgwNotes);
            splitContainer1.Size = new System.Drawing.Size(831, 504);
            splitContainer1.SplitterDistance = 222;
            splitContainer1.TabIndex = 172;
            // 
            // chkUseSchoolYear
            // 
            chkUseSchoolYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkUseSchoolYear.AutoSize = true;
            chkUseSchoolYear.Checked = true;
            chkUseSchoolYear.CheckState = System.Windows.Forms.CheckState.Checked;
            chkUseSchoolYear.Location = new System.Drawing.Point(737, 31);
            chkUseSchoolYear.Name = "chkUseSchoolYear";
            chkUseSchoolYear.Size = new System.Drawing.Size(15, 14);
            chkUseSchoolYear.TabIndex = 180;
            chkUseSchoolYear.UseVisualStyleBackColor = true;
            chkUseSchoolYear.CheckedChanged += chkUseSchoolYear_CheckedChanged;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.DarkBlue;
            label2.Location = new System.Drawing.Point(755, 49);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 174;
            label2.Text = "Id allievo";
            // 
            // txtIdStudent
            // 
            txtIdStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtIdStudent.Location = new System.Drawing.Point(760, 67);
            txtIdStudent.Margin = new System.Windows.Forms.Padding(4);
            txtIdStudent.Name = "txtIdStudent";
            txtIdStudent.ReadOnly = true;
            txtIdStudent.Size = new System.Drawing.Size(55, 24);
            txtIdStudent.TabIndex = 173;
            txtIdStudent.TabStop = false;
            txtIdStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddAnnotationGroup);
            groupBox1.Controls.Add(btnRemoveAnnotationGroup);
            groupBox1.Controls.Add(btnSaveModificationsGroup);
            groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox1.Location = new System.Drawing.Point(617, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(219, 61);
            groupBox1.TabIndex = 193;
            groupBox1.TabStop = false;
            groupBox1.Text = "Annotazioni su gruppo";
            // 
            // btnAddAnnotationGroup
            // 
            btnAddAnnotationGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnAddAnnotationGroup.Location = new System.Drawing.Point(6, 20);
            btnAddAnnotationGroup.Name = "btnAddAnnotationGroup";
            btnAddAnnotationGroup.Size = new System.Drawing.Size(63, 36);
            btnAddAnnotationGroup.TabIndex = 188;
            btnAddAnnotationGroup.Text = "+ gruppo";
            btnAddAnnotationGroup.UseVisualStyleBackColor = true;
            btnAddAnnotationGroup.Click += btnAddAnnotationGroup_Click;
            // 
            // btnRemoveAnnotationGroup
            // 
            btnRemoveAnnotationGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnRemoveAnnotationGroup.Location = new System.Drawing.Point(144, 19);
            btnRemoveAnnotationGroup.Name = "btnRemoveAnnotationGroup";
            btnRemoveAnnotationGroup.Size = new System.Drawing.Size(63, 37);
            btnRemoveAnnotationGroup.TabIndex = 183;
            btnRemoveAnnotationGroup.Text = " -  gruppo";
            btnRemoveAnnotationGroup.UseVisualStyleBackColor = true;
            btnRemoveAnnotationGroup.Click += btnRemoveAnnotationGroup_Click;
            // 
            // btnSaveModificationsGroup
            // 
            btnSaveModificationsGroup.Enabled = false;
            btnSaveModificationsGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSaveModificationsGroup.Location = new System.Drawing.Point(75, 19);
            btnSaveModificationsGroup.Name = "btnSaveModificationsGroup";
            btnSaveModificationsGroup.Size = new System.Drawing.Size(63, 37);
            btnSaveModificationsGroup.TabIndex = 185;
            btnSaveModificationsGroup.Text = "salva modifica";
            btnSaveModificationsGroup.UseVisualStyleBackColor = true;
            btnSaveModificationsGroup.Click += btnSaveModificationsGroup_Click;
            // 
            // grpSingleButtons
            // 
            grpSingleButtons.Controls.Add(btnSaveModificationsStudent);
            grpSingleButtons.Controls.Add(btnRemoveAnnotationStudent);
            grpSingleButtons.Controls.Add(btnAddAnnotationStudent);
            grpSingleButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            grpSingleButtons.Location = new System.Drawing.Point(398, 15);
            grpSingleButtons.Name = "grpSingleButtons";
            grpSingleButtons.Size = new System.Drawing.Size(219, 68);
            grpSingleButtons.TabIndex = 192;
            grpSingleButtons.TabStop = false;
            grpSingleButtons.Text = "Annotazioni su singolo";
            // 
            // btnSaveModificationsStudent
            // 
            btnSaveModificationsStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSaveModificationsStudent.Location = new System.Drawing.Point(81, 18);
            btnSaveModificationsStudent.Name = "btnSaveModificationsStudent";
            btnSaveModificationsStudent.Size = new System.Drawing.Size(63, 37);
            btnSaveModificationsStudent.TabIndex = 189;
            btnSaveModificationsStudent.Text = "salva modifica";
            btnSaveModificationsStudent.UseVisualStyleBackColor = true;
            btnSaveModificationsStudent.Click += btnSaveModificationsStudent_Click;
            // 
            // btnRemoveAnnotationStudent
            // 
            btnRemoveAnnotationStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnRemoveAnnotationStudent.Location = new System.Drawing.Point(150, 18);
            btnRemoveAnnotationStudent.Name = "btnRemoveAnnotationStudent";
            btnRemoveAnnotationStudent.Size = new System.Drawing.Size(63, 37);
            btnRemoveAnnotationStudent.TabIndex = 184;
            btnRemoveAnnotationStudent.Text = " -  allievo";
            btnRemoveAnnotationStudent.UseVisualStyleBackColor = true;
            btnRemoveAnnotationStudent.Click += btnRemoveAnnotationStudent_Click;
            // 
            // btnAddAnnotationStudent
            // 
            btnAddAnnotationStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnAddAnnotationStudent.Location = new System.Drawing.Point(12, 18);
            btnAddAnnotationStudent.Name = "btnAddAnnotationStudent";
            btnAddAnnotationStudent.Size = new System.Drawing.Size(63, 37);
            btnAddAnnotationStudent.TabIndex = 185;
            btnAddAnnotationStudent.Text = " +  allievo";
            btnAddAnnotationStudent.UseVisualStyleBackColor = true;
            btnAddAnnotationStudent.Click += btnAddAnnotationStudent_Click;
            // 
            // chkCurrentActive
            // 
            chkCurrentActive.AutoSize = true;
            chkCurrentActive.Location = new System.Drawing.Point(71, 54);
            chkCurrentActive.Name = "chkCurrentActive";
            chkCurrentActive.Size = new System.Drawing.Size(62, 22);
            chkCurrentActive.TabIndex = 191;
            chkCurrentActive.Text = "Attiva";
            toolTip1.SetToolTip(chkCurrentActive, "l'annotazione è attiva");
            chkCurrentActive.UseVisualStyleBackColor = true;
            chkCurrentActive.CheckedChanged += chkCurrentActive_CheckedChanged;
            // 
            // chkPopUp
            // 
            chkPopUp.AutoSize = true;
            chkPopUp.Location = new System.Drawing.Point(144, 54);
            chkPopUp.Name = "chkPopUp";
            chkPopUp.Size = new System.Drawing.Size(110, 22);
            chkPopUp.TabIndex = 190;
            chkPopUp.Text = "Promemoria";
            toolTip1.SetToolTip(chkPopUp, "Viene visualizzata ogni volta che si visualizza la classe");
            chkPopUp.UseVisualStyleBackColor = true;
            // 
            // btnPrepareNew
            // 
            btnPrepareNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnPrepareNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPrepareNew.Location = new System.Drawing.Point(329, 33);
            btnPrepareNew.Name = "btnPrepareNew";
            btnPrepareNew.Size = new System.Drawing.Size(63, 37);
            btnPrepareNew.TabIndex = 189;
            btnPrepareNew.Text = " Prepara nuova";
            toolTip1.SetToolTip(btnPrepareNew, "Cancella i dati dell'annotazione per salvare come nuova");
            btnPrepareNew.UseVisualStyleBackColor = true;
            btnPrepareNew.Click += btnNew_Click;
            // 
            // label5
            // 
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.DarkBlue;
            label5.Location = new System.Drawing.Point(2, 5);
            label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(123, 26);
            label5.TabIndex = 187;
            label5.Text = "Annotazione";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAnnotation
            // 
            txtAnnotation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtAnnotation.Location = new System.Drawing.Point(-1, 89);
            txtAnnotation.Multiline = true;
            txtAnnotation.Name = "txtAnnotation";
            txtAnnotation.Size = new System.Drawing.Size(831, 68);
            txtAnnotation.TabIndex = 186;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 31);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(64, 18);
            label4.TabIndex = 182;
            label4.Text = "Id annot.";
            // 
            // txtIdAnnotation
            // 
            txtIdAnnotation.Location = new System.Drawing.Point(6, 52);
            txtIdAnnotation.Name = "txtIdAnnotation";
            txtIdAnnotation.ReadOnly = true;
            txtIdAnnotation.Size = new System.Drawing.Size(59, 24);
            txtIdAnnotation.TabIndex = 181;
            // 
            // chkShowOnlyActive
            // 
            chkShowOnlyActive.AutoSize = true;
            chkShowOnlyActive.Checked = true;
            chkShowOnlyActive.CheckState = System.Windows.Forms.CheckState.Checked;
            chkShowOnlyActive.Location = new System.Drawing.Point(144, 9);
            chkShowOnlyActive.Name = "chkShowOnlyActive";
            chkShowOnlyActive.Size = new System.Drawing.Size(257, 22);
            chkShowOnlyActive.TabIndex = 179;
            chkShowOnlyActive.Text = "visualizza solo le annotazioni attive";
            chkShowOnlyActive.UseVisualStyleBackColor = true;
            chkShowOnlyActive.CheckedChanged += chkShowOnlyActive_CheckedChanged;
            // 
            // frmAnnotationsAboutStudents
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(850, 575);
            Controls.Add(splitContainer1);
            Controls.Add(lblCurrentStudent);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmAnnotationsAboutStudents";
            Text = "Annotazioni sullo studente";
            Load += frmStudentsNotes_Load;
            ((System.ComponentModel.ISupportInitialize)dgwNotes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgwStudents).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            grpSingleButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgwNotes;
        private System.Windows.Forms.Label lblCurrentStudent;
        private System.Windows.Forms.TextBox txtSchoolYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgwStudents;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdStudent;
        private System.Windows.Forms.CheckBox chkAnnotationsShowActive;
        private System.Windows.Forms.CheckBox chkUseSchoolYear;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdAnnotation;
        private System.Windows.Forms.Button btnAddAnnotationStudent;
        private System.Windows.Forms.Button btnRemoveAnnotationStudent;
        private System.Windows.Forms.Button btnRemoveAnnotationGroup;
        private System.Windows.Forms.TextBox txtAnnotation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddAnnotationGroup;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSaveModificationsStudent;
        private System.Windows.Forms.Button btnSaveModificationsGroup;
        private System.Windows.Forms.CheckBox chkPopUp;
        private System.Windows.Forms.Button btnPrepareNew;
        private System.Windows.Forms.CheckBox chkCurrentActive;
        private System.Windows.Forms.CheckBox chkShowOnlyActive;
        private System.Windows.Forms.GroupBox grpSingleButtons;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}