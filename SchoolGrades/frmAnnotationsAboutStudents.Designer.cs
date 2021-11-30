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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnnotationsAboutStudents));
            this.dgwNotes = new System.Windows.Forms.DataGridView();
            this.lblCurrentStudent = new System.Windows.Forms.Label();
            this.txtSchoolYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgwStudents = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkUseSchoolYear = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdStudent = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddAnnotationGroup = new System.Windows.Forms.Button();
            this.btnRemoveAnnotationGroup = new System.Windows.Forms.Button();
            this.btnSaveModificationsGroup = new System.Windows.Forms.Button();
            this.grpSingleButtons = new System.Windows.Forms.GroupBox();
            this.btnSaveModificationsStudent = new System.Windows.Forms.Button();
            this.btnRemoveAnnotationStudent = new System.Windows.Forms.Button();
            this.btnAddAnnotationStudent = new System.Windows.Forms.Button();
            this.chkCurrentActive = new System.Windows.Forms.CheckBox();
            this.chkPopUp = new System.Windows.Forms.CheckBox();
            this.btnPrepareNew = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAnnotation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdAnnotation = new System.Windows.Forms.TextBox();
            this.chkShowOnlyActive = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgwNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpSingleButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwNotes
            // 
            this.dgwNotes.AllowUserToAddRows = false;
            this.dgwNotes.AllowUserToDeleteRows = false;
            this.dgwNotes.AllowUserToOrderColumns = true;
            this.dgwNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwNotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwNotes.Location = new System.Drawing.Point(-1, 155);
            this.dgwNotes.Margin = new System.Windows.Forms.Padding(4);
            this.dgwNotes.Name = "dgwNotes";
            this.dgwNotes.RowTemplate.Height = 24;
            this.dgwNotes.Size = new System.Drawing.Size(831, 122);
            this.dgwNotes.TabIndex = 163;
            this.dgwNotes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwNotes_CellClick);
            this.dgwNotes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwNotes_CellContentClick);
            // 
            // lblCurrentStudent
            // 
            this.lblCurrentStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentStudent.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentStudent.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentStudent.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCurrentStudent.Location = new System.Drawing.Point(7, 3);
            this.lblCurrentStudent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCurrentStudent.Name = "lblCurrentStudent";
            this.lblCurrentStudent.Size = new System.Drawing.Size(831, 53);
            this.lblCurrentStudent.TabIndex = 158;
            this.lblCurrentStudent.Text = "Annotazioni su allievi o gruppi";
            this.lblCurrentStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSchoolYear
            // 
            this.txtSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSchoolYear.Enabled = false;
            this.txtSchoolYear.Location = new System.Drawing.Point(760, 25);
            this.txtSchoolYear.Name = "txtSchoolYear";
            this.txtSchoolYear.Size = new System.Drawing.Size(55, 24);
            this.txtSchoolYear.TabIndex = 169;
            this.txtSchoolYear.TextChanged += new System.EventHandler(this.txtSchoolYear_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(751, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 170;
            this.label1.Text = "Anno scol.";
            // 
            // dgwStudents
            // 
            this.dgwStudents.AllowUserToAddRows = false;
            this.dgwStudents.AllowUserToDeleteRows = false;
            this.dgwStudents.AllowUserToOrderColumns = true;
            this.dgwStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwStudents.Location = new System.Drawing.Point(0, 0);
            this.dgwStudents.Margin = new System.Windows.Forms.Padding(4);
            this.dgwStudents.Name = "dgwStudents";
            this.dgwStudents.RowTemplate.Height = 24;
            this.dgwStudents.Size = new System.Drawing.Size(730, 220);
            this.dgwStudents.TabIndex = 171;
            this.dgwStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwStudents_CellClick);
            this.dgwStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwStudents_CellContentClick);
            this.dgwStudents.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwStudents_RowEnter);
            this.dgwStudents.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwStudents_RowLeave);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(7, 59);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chkUseSchoolYear);
            this.splitContainer1.Panel1.Controls.Add(this.dgwStudents);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtIdStudent);
            this.splitContainer1.Panel1.Controls.Add(this.txtSchoolYear);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.grpSingleButtons);
            this.splitContainer1.Panel2.Controls.Add(this.chkCurrentActive);
            this.splitContainer1.Panel2.Controls.Add(this.chkPopUp);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrepareNew);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.txtAnnotation);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.txtIdAnnotation);
            this.splitContainer1.Panel2.Controls.Add(this.chkShowOnlyActive);
            this.splitContainer1.Panel2.Controls.Add(this.dgwNotes);
            this.splitContainer1.Size = new System.Drawing.Size(831, 504);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 172;
            // 
            // chkUseSchoolYear
            // 
            this.chkUseSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUseSchoolYear.AutoSize = true;
            this.chkUseSchoolYear.Checked = true;
            this.chkUseSchoolYear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseSchoolYear.Location = new System.Drawing.Point(737, 31);
            this.chkUseSchoolYear.Name = "chkUseSchoolYear";
            this.chkUseSchoolYear.Size = new System.Drawing.Size(15, 14);
            this.chkUseSchoolYear.TabIndex = 180;
            this.chkUseSchoolYear.UseVisualStyleBackColor = true;
            this.chkUseSchoolYear.CheckedChanged += new System.EventHandler(this.chkUseSchoolYear_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(755, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 174;
            this.label2.Text = "Id allievo";
            // 
            // txtIdStudent
            // 
            this.txtIdStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdStudent.Location = new System.Drawing.Point(760, 67);
            this.txtIdStudent.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdStudent.Name = "txtIdStudent";
            this.txtIdStudent.ReadOnly = true;
            this.txtIdStudent.Size = new System.Drawing.Size(55, 24);
            this.txtIdStudent.TabIndex = 173;
            this.txtIdStudent.TabStop = false;
            this.txtIdStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddAnnotationGroup);
            this.groupBox1.Controls.Add(this.btnRemoveAnnotationGroup);
            this.groupBox1.Controls.Add(this.btnSaveModificationsGroup);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(617, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 61);
            this.groupBox1.TabIndex = 193;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Annotazioni su gruppo";
            // 
            // btnAddAnnotationGroup
            // 
            this.btnAddAnnotationGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddAnnotationGroup.Location = new System.Drawing.Point(6, 20);
            this.btnAddAnnotationGroup.Name = "btnAddAnnotationGroup";
            this.btnAddAnnotationGroup.Size = new System.Drawing.Size(63, 36);
            this.btnAddAnnotationGroup.TabIndex = 188;
            this.btnAddAnnotationGroup.Text = "+ gruppo";
            this.btnAddAnnotationGroup.UseVisualStyleBackColor = true;
            this.btnAddAnnotationGroup.Click += new System.EventHandler(this.btnAddAnnotationGroup_Click);
            // 
            // btnRemoveAnnotationGroup
            // 
            this.btnRemoveAnnotationGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveAnnotationGroup.Location = new System.Drawing.Point(144, 19);
            this.btnRemoveAnnotationGroup.Name = "btnRemoveAnnotationGroup";
            this.btnRemoveAnnotationGroup.Size = new System.Drawing.Size(63, 37);
            this.btnRemoveAnnotationGroup.TabIndex = 183;
            this.btnRemoveAnnotationGroup.Text = " -  gruppo";
            this.btnRemoveAnnotationGroup.UseVisualStyleBackColor = true;
            this.btnRemoveAnnotationGroup.Click += new System.EventHandler(this.btnRemoveAnnotationGroup_Click);
            // 
            // btnSaveModificationsGroup
            // 
            this.btnSaveModificationsGroup.Enabled = false;
            this.btnSaveModificationsGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveModificationsGroup.Location = new System.Drawing.Point(75, 19);
            this.btnSaveModificationsGroup.Name = "btnSaveModificationsGroup";
            this.btnSaveModificationsGroup.Size = new System.Drawing.Size(63, 37);
            this.btnSaveModificationsGroup.TabIndex = 185;
            this.btnSaveModificationsGroup.Text = "salva modifica";
            this.btnSaveModificationsGroup.UseVisualStyleBackColor = true;
            this.btnSaveModificationsGroup.Click += new System.EventHandler(this.btnSaveModificationsGroup_Click);
            // 
            // grpSingleButtons
            // 
            this.grpSingleButtons.Controls.Add(this.btnSaveModificationsStudent);
            this.grpSingleButtons.Controls.Add(this.btnRemoveAnnotationStudent);
            this.grpSingleButtons.Controls.Add(this.btnAddAnnotationStudent);
            this.grpSingleButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpSingleButtons.Location = new System.Drawing.Point(398, 15);
            this.grpSingleButtons.Name = "grpSingleButtons";
            this.grpSingleButtons.Size = new System.Drawing.Size(219, 68);
            this.grpSingleButtons.TabIndex = 192;
            this.grpSingleButtons.TabStop = false;
            this.grpSingleButtons.Text = "Annotazioni su singolo";
            // 
            // btnSaveModificationsStudent
            // 
            this.btnSaveModificationsStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveModificationsStudent.Location = new System.Drawing.Point(81, 18);
            this.btnSaveModificationsStudent.Name = "btnSaveModificationsStudent";
            this.btnSaveModificationsStudent.Size = new System.Drawing.Size(63, 37);
            this.btnSaveModificationsStudent.TabIndex = 189;
            this.btnSaveModificationsStudent.Text = "salva modifica";
            this.btnSaveModificationsStudent.UseVisualStyleBackColor = true;
            this.btnSaveModificationsStudent.Click += new System.EventHandler(this.btnSaveModificationsStudent_Click);
            // 
            // btnRemoveAnnotationStudent
            // 
            this.btnRemoveAnnotationStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveAnnotationStudent.Location = new System.Drawing.Point(150, 18);
            this.btnRemoveAnnotationStudent.Name = "btnRemoveAnnotationStudent";
            this.btnRemoveAnnotationStudent.Size = new System.Drawing.Size(63, 37);
            this.btnRemoveAnnotationStudent.TabIndex = 184;
            this.btnRemoveAnnotationStudent.Text = " -  allievo";
            this.btnRemoveAnnotationStudent.UseVisualStyleBackColor = true;
            this.btnRemoveAnnotationStudent.Click += new System.EventHandler(this.btnRemoveAnnotationStudent_Click);
            // 
            // btnAddAnnotationStudent
            // 
            this.btnAddAnnotationStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddAnnotationStudent.Location = new System.Drawing.Point(12, 18);
            this.btnAddAnnotationStudent.Name = "btnAddAnnotationStudent";
            this.btnAddAnnotationStudent.Size = new System.Drawing.Size(63, 37);
            this.btnAddAnnotationStudent.TabIndex = 185;
            this.btnAddAnnotationStudent.Text = " +  allievo";
            this.btnAddAnnotationStudent.UseVisualStyleBackColor = true;
            this.btnAddAnnotationStudent.Click += new System.EventHandler(this.btnAddAnnotationStudent_Click);
            // 
            // chkCurrentActive
            // 
            this.chkCurrentActive.AutoSize = true;
            this.chkCurrentActive.Location = new System.Drawing.Point(71, 54);
            this.chkCurrentActive.Name = "chkCurrentActive";
            this.chkCurrentActive.Size = new System.Drawing.Size(62, 22);
            this.chkCurrentActive.TabIndex = 191;
            this.chkCurrentActive.Text = "Attiva";
            this.toolTip1.SetToolTip(this.chkCurrentActive, "l\'annotazione è attiva");
            this.chkCurrentActive.UseVisualStyleBackColor = true;
            this.chkCurrentActive.CheckedChanged += new System.EventHandler(this.chkCurrentActive_CheckedChanged);
            // 
            // chkPopUp
            // 
            this.chkPopUp.AutoSize = true;
            this.chkPopUp.Location = new System.Drawing.Point(144, 54);
            this.chkPopUp.Name = "chkPopUp";
            this.chkPopUp.Size = new System.Drawing.Size(110, 22);
            this.chkPopUp.TabIndex = 190;
            this.chkPopUp.Text = "Promemoria";
            this.toolTip1.SetToolTip(this.chkPopUp, "Viene visualizzata ogni volta che si visualizza la classe");
            this.chkPopUp.UseVisualStyleBackColor = true;
            // 
            // btnPrepareNew
            // 
            this.btnPrepareNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrepareNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrepareNew.Location = new System.Drawing.Point(329, 33);
            this.btnPrepareNew.Name = "btnPrepareNew";
            this.btnPrepareNew.Size = new System.Drawing.Size(63, 37);
            this.btnPrepareNew.TabIndex = 189;
            this.btnPrepareNew.Text = " Prepara nuova";
            this.toolTip1.SetToolTip(this.btnPrepareNew, "Cancella i dati dell\'annotazione per salvare come nuova");
            this.btnPrepareNew.UseVisualStyleBackColor = true;
            this.btnPrepareNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(2, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 26);
            this.label5.TabIndex = 187;
            this.label5.Text = "Annotazione";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAnnotation
            // 
            this.txtAnnotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnnotation.Location = new System.Drawing.Point(-1, 89);
            this.txtAnnotation.Multiline = true;
            this.txtAnnotation.Name = "txtAnnotation";
            this.txtAnnotation.Size = new System.Drawing.Size(831, 68);
            this.txtAnnotation.TabIndex = 186;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 182;
            this.label4.Text = "Id annot.";
            // 
            // txtIdAnnotation
            // 
            this.txtIdAnnotation.Location = new System.Drawing.Point(6, 52);
            this.txtIdAnnotation.Name = "txtIdAnnotation";
            this.txtIdAnnotation.ReadOnly = true;
            this.txtIdAnnotation.Size = new System.Drawing.Size(59, 24);
            this.txtIdAnnotation.TabIndex = 181;
            // 
            // chkShowOnlyActive
            // 
            this.chkShowOnlyActive.AutoSize = true;
            this.chkShowOnlyActive.Checked = true;
            this.chkShowOnlyActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowOnlyActive.Location = new System.Drawing.Point(144, 9);
            this.chkShowOnlyActive.Name = "chkShowOnlyActive";
            this.chkShowOnlyActive.Size = new System.Drawing.Size(257, 22);
            this.chkShowOnlyActive.TabIndex = 179;
            this.chkShowOnlyActive.Text = "visualizza solo le annotazioni attive";
            this.chkShowOnlyActive.UseVisualStyleBackColor = true;
            this.chkShowOnlyActive.CheckedChanged += new System.EventHandler(this.chkShowOnlyActive_CheckedChanged);
            // 
            // frmAnnotationsAboutStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(850, 575);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblCurrentStudent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAnnotationsAboutStudents";
            this.Text = "Annotazioni sullo studente";
            this.Load += new System.EventHandler(this.frmStudentsNotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStudents)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpSingleButtons.ResumeLayout(false);
            this.ResumeLayout(false);

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