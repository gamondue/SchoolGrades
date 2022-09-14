namespace SchoolGrades
{
    partial class frmNewYear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewYear));
            this.cmbClasses = new System.Windows.Forms.ComboBox();
            this.TxtOfficialSchoolAbbreviation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DgwStudents = new System.Windows.Forms.DataGridView();
            this.SaveThisStudent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblChooseNextStudents = new System.Windows.Forms.Label();
            this.BtnClassNew = new System.Windows.Forms.Button();
            this.BtnClassMigration = new System.Windows.Forms.Button();
            this.txtSchoolYearNext = new System.Windows.Forms.TextBox();
            this.BtnClassGeneration = new System.Windows.Forms.Button();
            this.lblClassDescription = new System.Windows.Forms.Label();
            this.txtClassDescriptionNext = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClassAbbreviationNext = new System.Windows.Forms.TextBox();
            this.BtnStudentNew = new System.Windows.Forms.Button();
            this.cmbSchoolYearCurrents = new System.Windows.Forms.ComboBox();
            this.btnAssociateSchoolPeriodsToTheYear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtYearDescriptionCurrent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYearNotesCurrent = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtYearDescriptionNext = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYearNotesNext = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtClassDescriptionCurrent = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgwStudents)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbClasses
            // 
            this.cmbClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbClasses.FormattingEnabled = true;
            this.cmbClasses.Location = new System.Drawing.Point(4, 38);
            this.cmbClasses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbClasses.Name = "cmbClasses";
            this.cmbClasses.Size = new System.Drawing.Size(118, 26);
            this.cmbClasses.TabIndex = 101;
            this.cmbClasses.SelectedIndexChanged += new System.EventHandler(this.CmbClasses_SelectedIndexChanged);
            // 
            // TxtOfficialSchoolAbbreviation
            // 
            this.TxtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtOfficialSchoolAbbreviation.Location = new System.Drawing.Point(105, 158);
            this.TxtOfficialSchoolAbbreviation.Margin = new System.Windows.Forms.Padding(5);
            this.TxtOfficialSchoolAbbreviation.Name = "TxtOfficialSchoolAbbreviation";
            this.TxtOfficialSchoolAbbreviation.ReadOnly = true;
            this.TxtOfficialSchoolAbbreviation.Size = new System.Drawing.Size(157, 24);
            this.TxtOfficialSchoolAbbreviation.TabIndex = 98;
            this.TxtOfficialSchoolAbbreviation.Text = "FOIS01100L";
            this.TxtOfficialSchoolAbbreviation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(9, 163);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 97;
            this.label4.Text = "Codice Scuola";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 94;
            this.label1.Text = "Sigla Classe prec.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(7, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 103;
            this.label3.Text = "Id anno";
            // 
            // DgwStudents
            // 
            this.DgwStudents.AllowUserToAddRows = false;
            this.DgwStudents.AllowUserToDeleteRows = false;
            this.DgwStudents.AllowUserToOrderColumns = true;
            this.DgwStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgwStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.DgwStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgwStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaveThisStudent});
            this.DgwStudents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgwStudents.Location = new System.Drawing.Point(5, 246);
            this.DgwStudents.Margin = new System.Windows.Forms.Padding(5);
            this.DgwStudents.MultiSelect = false;
            this.DgwStudents.Name = "DgwStudents";
            this.DgwStudents.RowTemplate.Height = 24;
            this.DgwStudents.Size = new System.Drawing.Size(1209, 389);
            this.DgwStudents.TabIndex = 104;
            // 
            // SaveThisStudent
            // 
            this.SaveThisStudent.HeaderText = "Column1";
            this.SaveThisStudent.Name = "SaveThisStudent";
            this.SaveThisStudent.Width = 5;
            // 
            // lblChooseNextStudents
            // 
            this.lblChooseNextStudents.AutoSize = true;
            this.lblChooseNextStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChooseNextStudents.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblChooseNextStudents.Location = new System.Drawing.Point(2, 223);
            this.lblChooseNextStudents.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblChooseNextStudents.Name = "lblChooseNextStudents";
            this.lblChooseNextStudents.Size = new System.Drawing.Size(313, 18);
            this.lblChooseNextStudents.TabIndex = 105;
            this.lblChooseNextStudents.Text = "Allievi da INCLUDERE nella classe successiva";
            // 
            // BtnClassNew
            // 
            this.BtnClassNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClassNew.BackColor = System.Drawing.Color.Transparent;
            this.BtnClassNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnClassNew.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnClassNew.Location = new System.Drawing.Point(600, 163);
            this.BtnClassNew.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.BtnClassNew.Name = "BtnClassNew";
            this.BtnClassNew.Size = new System.Drawing.Size(94, 72);
            this.BtnClassNew.TabIndex = 106;
            this.BtnClassNew.Text = "Nuova classe";
            this.BtnClassNew.UseVisualStyleBackColor = false;
            this.BtnClassNew.Click += new System.EventHandler(this.BtnClassNew_Click);
            // 
            // BtnClassMigration
            // 
            this.BtnClassMigration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClassMigration.BackColor = System.Drawing.Color.Transparent;
            this.BtnClassMigration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnClassMigration.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnClassMigration.Location = new System.Drawing.Point(1018, 163);
            this.BtnClassMigration.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.BtnClassMigration.Name = "BtnClassMigration";
            this.BtnClassMigration.Size = new System.Drawing.Size(94, 72);
            this.BtnClassMigration.TabIndex = 107;
            this.BtnClassMigration.Text = "Prepara classe";
            this.BtnClassMigration.UseVisualStyleBackColor = false;
            this.BtnClassMigration.Click += new System.EventHandler(this.BtnClassMigration_Click);
            // 
            // txtSchoolYearNext
            // 
            this.txtSchoolYearNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSchoolYearNext.Location = new System.Drawing.Point(7, 38);
            this.txtSchoolYearNext.Margin = new System.Windows.Forms.Padding(5);
            this.txtSchoolYearNext.Name = "txtSchoolYearNext";
            this.txtSchoolYearNext.Size = new System.Drawing.Size(103, 24);
            this.txtSchoolYearNext.TabIndex = 108;
            // 
            // BtnClassGeneration
            // 
            this.BtnClassGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClassGeneration.BackColor = System.Drawing.Color.Transparent;
            this.BtnClassGeneration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnClassGeneration.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnClassGeneration.Location = new System.Drawing.Point(828, 163);
            this.BtnClassGeneration.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.BtnClassGeneration.Name = "BtnClassGeneration";
            this.BtnClassGeneration.Size = new System.Drawing.Size(94, 72);
            this.BtnClassGeneration.TabIndex = 110;
            this.BtnClassGeneration.Text = "Genera classe";
            this.BtnClassGeneration.UseVisualStyleBackColor = false;
            this.BtnClassGeneration.Visible = false;
            this.BtnClassGeneration.Click += new System.EventHandler(this.BtnClassGeneration_Click);
            // 
            // lblClassDescription
            // 
            this.lblClassDescription.AutoSize = true;
            this.lblClassDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClassDescription.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblClassDescription.Location = new System.Drawing.Point(413, 66);
            this.lblClassDescription.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblClassDescription.Name = "lblClassDescription";
            this.lblClassDescription.Size = new System.Drawing.Size(148, 15);
            this.lblClassDescription.TabIndex = 113;
            this.lblClassDescription.Text = "Descrizione nuova Classe";
            this.lblClassDescription.Visible = false;
            // 
            // txtClassDescriptionNext
            // 
            this.txtClassDescriptionNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClassDescriptionNext.Location = new System.Drawing.Point(131, 38);
            this.txtClassDescriptionNext.Margin = new System.Windows.Forms.Padding(5);
            this.txtClassDescriptionNext.Name = "txtClassDescriptionNext";
            this.txtClassDescriptionNext.Size = new System.Drawing.Size(418, 24);
            this.txtClassDescriptionNext.TabIndex = 112;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(7, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 114;
            this.label6.Text = "Id nuovo anno";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(285, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 15);
            this.label7.TabIndex = 116;
            this.label7.Text = "Sigla Classe succ.";
            // 
            // txtClassAbbreviationNext
            // 
            this.txtClassAbbreviationNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClassAbbreviationNext.Location = new System.Drawing.Point(4, 38);
            this.txtClassAbbreviationNext.Margin = new System.Windows.Forms.Padding(5);
            this.txtClassAbbreviationNext.Name = "txtClassAbbreviationNext";
            this.txtClassAbbreviationNext.Size = new System.Drawing.Size(117, 24);
            this.txtClassAbbreviationNext.TabIndex = 117;
            // 
            // BtnStudentNew
            // 
            this.BtnStudentNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStudentNew.BackColor = System.Drawing.Color.Transparent;
            this.BtnStudentNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnStudentNew.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnStudentNew.Location = new System.Drawing.Point(698, 163);
            this.BtnStudentNew.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.BtnStudentNew.Name = "BtnStudentNew";
            this.BtnStudentNew.Size = new System.Drawing.Size(94, 72);
            this.BtnStudentNew.TabIndex = 118;
            this.BtnStudentNew.Text = "Nuovo allievo";
            this.BtnStudentNew.UseVisualStyleBackColor = false;
            this.BtnStudentNew.Visible = false;
            this.BtnStudentNew.Click += new System.EventHandler(this.BtnStudentNew_Click);
            // 
            // cmbSchoolYearCurrents
            // 
            this.cmbSchoolYearCurrents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSchoolYearCurrents.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbSchoolYearCurrents.FormattingEnabled = true;
            this.cmbSchoolYearCurrents.Location = new System.Drawing.Point(7, 35);
            this.cmbSchoolYearCurrents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbSchoolYearCurrents.Name = "cmbSchoolYearCurrents";
            this.cmbSchoolYearCurrents.Size = new System.Drawing.Size(104, 26);
            this.cmbSchoolYearCurrents.TabIndex = 120;
            this.cmbSchoolYearCurrents.SelectedIndexChanged += new System.EventHandler(this.CmbSchoolYear_SelectedIndexChanged);
            // 
            // btnAssociateSchoolPeriodsToTheYear
            // 
            this.btnAssociateSchoolPeriodsToTheYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssociateSchoolPeriodsToTheYear.BackColor = System.Drawing.Color.Transparent;
            this.btnAssociateSchoolPeriodsToTheYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAssociateSchoolPeriodsToTheYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnAssociateSchoolPeriodsToTheYear.Location = new System.Drawing.Point(1113, 163);
            this.btnAssociateSchoolPeriodsToTheYear.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnAssociateSchoolPeriodsToTheYear.Name = "btnAssociateSchoolPeriodsToTheYear";
            this.btnAssociateSchoolPeriodsToTheYear.Size = new System.Drawing.Size(94, 72);
            this.btnAssociateSchoolPeriodsToTheYear.TabIndex = 121;
            this.btnAssociateSchoolPeriodsToTheYear.Text = "Prepara periodi dell\'anno";
            this.btnAssociateSchoolPeriodsToTheYear.UseVisualStyleBackColor = false;
            this.btnAssociateSchoolPeriodsToTheYear.Click += new System.EventHandler(this.btnAssociateSchoolPeriodsToTheYear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtYearDescriptionCurrent);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtYearNotesCurrent);
            this.groupBox1.Controls.Add(this.cmbSchoolYearCurrents);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(2, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 70);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anno scolastico precedente";
            // 
            // txtYearDescriptionCurrent
            // 
            this.txtYearDescriptionCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtYearDescriptionCurrent.Location = new System.Drawing.Point(117, 37);
            this.txtYearDescriptionCurrent.Margin = new System.Windows.Forms.Padding(5);
            this.txtYearDescriptionCurrent.Name = "txtYearDescriptionCurrent";
            this.txtYearDescriptionCurrent.Size = new System.Drawing.Size(100, 24);
            this.txtYearDescriptionCurrent.TabIndex = 124;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Location = new System.Drawing.Point(221, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 123;
            this.label8.Text = "Note";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(117, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 122;
            this.label2.Text = "Descrizione breve";
            // 
            // txtYearNotesCurrent
            // 
            this.txtYearNotesCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtYearNotesCurrent.Location = new System.Drawing.Point(221, 37);
            this.txtYearNotesCurrent.Margin = new System.Windows.Forms.Padding(5);
            this.txtYearNotesCurrent.Name = "txtYearNotesCurrent";
            this.txtYearNotesCurrent.Size = new System.Drawing.Size(418, 24);
            this.txtYearNotesCurrent.TabIndex = 121;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtYearDescriptionNext);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtYearNotesNext);
            this.groupBox2.Controls.Add(this.txtSchoolYearNext);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(2, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 70);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nuovo anno scolastico";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.Location = new System.Drawing.Point(221, 17);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 15);
            this.label10.TabIndex = 125;
            this.label10.Text = "Note";
            // 
            // txtYearDescriptionNext
            // 
            this.txtYearDescriptionNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtYearDescriptionNext.Location = new System.Drawing.Point(117, 38);
            this.txtYearDescriptionNext.Margin = new System.Windows.Forms.Padding(5);
            this.txtYearDescriptionNext.Name = "txtYearDescriptionNext";
            this.txtYearDescriptionNext.Size = new System.Drawing.Size(100, 24);
            this.txtYearDescriptionNext.TabIndex = 125;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(117, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 116;
            this.label5.Text = "Descrizione breve";
            // 
            // txtYearNotesNext
            // 
            this.txtYearNotesNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtYearNotesNext.Location = new System.Drawing.Point(221, 38);
            this.txtYearNotesNext.Margin = new System.Windows.Forms.Padding(5);
            this.txtYearNotesNext.Name = "txtYearNotesNext";
            this.txtYearNotesNext.Size = new System.Drawing.Size(418, 24);
            this.txtYearNotesNext.TabIndex = 115;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtClassDescriptionCurrent);
            this.groupBox3.Controls.Add(this.cmbClasses);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(652, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(564, 70);
            this.groupBox3.TabIndex = 125;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Classe precedente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(131, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 115;
            this.label9.Text = "Descrizione";
            // 
            // txtClassDescriptionCurrent
            // 
            this.txtClassDescriptionCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClassDescriptionCurrent.Location = new System.Drawing.Point(131, 38);
            this.txtClassDescriptionCurrent.Margin = new System.Windows.Forms.Padding(5);
            this.txtClassDescriptionCurrent.Name = "txtClassDescriptionCurrent";
            this.txtClassDescriptionCurrent.Size = new System.Drawing.Size(418, 24);
            this.txtClassDescriptionCurrent.TabIndex = 114;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtClassDescriptionNext);
            this.groupBox4.Controls.Add(this.txtClassAbbreviationNext);
            this.groupBox4.Location = new System.Drawing.Point(655, 84);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(564, 70);
            this.groupBox4.TabIndex = 126;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nuova classe";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.DarkBlue;
            this.label11.Location = new System.Drawing.Point(131, 17);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 15);
            this.label11.TabIndex = 115;
            this.label11.Text = "Descrizione";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.DarkBlue;
            this.label12.Location = new System.Drawing.Point(4, 17);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 15);
            this.label12.TabIndex = 94;
            this.label12.Text = "Sigla";
            // 
            // frmNewYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1220, 636);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAssociateSchoolPeriodsToTheYear);
            this.Controls.Add(this.BtnStudentNew);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblClassDescription);
            this.Controls.Add(this.BtnClassGeneration);
            this.Controls.Add(this.BtnClassMigration);
            this.Controls.Add(this.BtnClassNew);
            this.Controls.Add(this.lblChooseNextStudents);
            this.Controls.Add(this.DgwStudents);
            this.Controls.Add(this.TxtOfficialSchoolAbbreviation);
            this.Controls.Add(this.label4);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmNewYear";
            this.Text = "Nuovo anno scolastico";
            this.Load += new System.EventHandler(this.frmNewYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgwStudents)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClasses;
        private System.Windows.Forms.TextBox TxtOfficialSchoolAbbreviation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgwStudents;
        private System.Windows.Forms.Label lblChooseNextStudents;
        private System.Windows.Forms.Button BtnClassNew;
        private System.Windows.Forms.Button BtnClassMigration;
        private System.Windows.Forms.TextBox txtSchoolYearNext;
        private System.Windows.Forms.Button BtnClassGeneration;
        private System.Windows.Forms.Label lblClassDescription;
        private System.Windows.Forms.TextBox txtClassDescriptionNext;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtClassAbbreviationNext;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SaveThisStudent;
        private System.Windows.Forms.Button BtnStudentNew;
        private System.Windows.Forms.ComboBox cmbSchoolYearCurrents;
        private System.Windows.Forms.Button btnAssociateSchoolPeriodsToTheYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtYearDescriptionCurrent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYearNotesCurrent;
        private System.Windows.Forms.TextBox txtYearDescriptionNext;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYearNotesNext;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtClassDescriptionCurrent;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}