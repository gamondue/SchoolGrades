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
            cmbClasses = new System.Windows.Forms.ComboBox();
            TxtOfficialSchoolAbbreviation = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            DgwStudents = new System.Windows.Forms.DataGridView();
            SaveThisStudent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            lblChooseNextStudents = new System.Windows.Forms.Label();
            BtnClassNew = new System.Windows.Forms.Button();
            BtnClassMigration = new System.Windows.Forms.Button();
            txtSchoolYearNext = new System.Windows.Forms.TextBox();
            BtnClassGeneration = new System.Windows.Forms.Button();
            lblClassDescription = new System.Windows.Forms.Label();
            txtClassDescriptionNext = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            txtClassAbbreviationNext = new System.Windows.Forms.TextBox();
            BtnStudentNew = new System.Windows.Forms.Button();
            cmbSchoolYearCurrents = new System.Windows.Forms.ComboBox();
            btnAssociateSchoolPeriodsToTheYear = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            txtYearDescriptionCurrent = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtYearNotesCurrent = new System.Windows.Forms.TextBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label10 = new System.Windows.Forms.Label();
            txtYearDescriptionNext = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            txtYearNotesNext = new System.Windows.Forms.TextBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label9 = new System.Windows.Forms.Label();
            txtClassDescriptionCurrent = new System.Windows.Forms.TextBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)DgwStudents).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // cmbClasses
            // 
            cmbClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cmbClasses.FormattingEnabled = true;
            cmbClasses.Location = new System.Drawing.Point(4, 38);
            cmbClasses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbClasses.Name = "cmbClasses";
            cmbClasses.Size = new System.Drawing.Size(118, 26);
            cmbClasses.TabIndex = 101;
            cmbClasses.SelectedIndexChanged += CmbClasses_SelectedIndexChanged;
            // 
            // TxtOfficialSchoolAbbreviation
            // 
            TxtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TxtOfficialSchoolAbbreviation.Location = new System.Drawing.Point(105, 158);
            TxtOfficialSchoolAbbreviation.Margin = new System.Windows.Forms.Padding(5);
            TxtOfficialSchoolAbbreviation.Name = "TxtOfficialSchoolAbbreviation";
            TxtOfficialSchoolAbbreviation.ReadOnly = true;
            TxtOfficialSchoolAbbreviation.Size = new System.Drawing.Size(157, 24);
            TxtOfficialSchoolAbbreviation.TabIndex = 98;
            TxtOfficialSchoolAbbreviation.Text = "FOIS01100L";
            TxtOfficialSchoolAbbreviation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.DarkBlue;
            label4.Location = new System.Drawing.Point(9, 163);
            label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 15);
            label4.TabIndex = 97;
            label4.Text = "Codice Scuola";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.DarkBlue;
            label1.Location = new System.Drawing.Point(4, 17);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(105, 15);
            label1.TabIndex = 94;
            label1.Text = "Sigla Classe prec.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.DarkBlue;
            label3.Location = new System.Drawing.Point(7, 17);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(48, 15);
            label3.TabIndex = 103;
            label3.Text = "Id anno";
            // 
            // DgwStudents
            // 
            DgwStudents.AllowUserToAddRows = false;
            DgwStudents.AllowUserToDeleteRows = false;
            DgwStudents.AllowUserToOrderColumns = true;
            DgwStudents.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DgwStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            DgwStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgwStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { SaveThisStudent });
            DgwStudents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            DgwStudents.Location = new System.Drawing.Point(5, 246);
            DgwStudents.Margin = new System.Windows.Forms.Padding(5);
            DgwStudents.MultiSelect = false;
            DgwStudents.Name = "DgwStudents";
            DgwStudents.RowTemplate.Height = 24;
            DgwStudents.Size = new System.Drawing.Size(1209, 389);
            DgwStudents.TabIndex = 104;
            // 
            // SaveThisStudent
            // 
            SaveThisStudent.HeaderText = "Column1";
            SaveThisStudent.Name = "SaveThisStudent";
            SaveThisStudent.Width = 5;
            // 
            // lblChooseNextStudents
            // 
            lblChooseNextStudents.AutoSize = true;
            lblChooseNextStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblChooseNextStudents.ForeColor = System.Drawing.Color.DarkBlue;
            lblChooseNextStudents.Location = new System.Drawing.Point(2, 223);
            lblChooseNextStudents.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblChooseNextStudents.Name = "lblChooseNextStudents";
            lblChooseNextStudents.Size = new System.Drawing.Size(313, 18);
            lblChooseNextStudents.TabIndex = 105;
            lblChooseNextStudents.Text = "Allievi da INCLUDERE nella classe successiva";
            // 
            // BtnClassNew
            // 
            BtnClassNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnClassNew.BackColor = System.Drawing.Color.Transparent;
            BtnClassNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BtnClassNew.ForeColor = System.Drawing.Color.DarkBlue;
            BtnClassNew.Location = new System.Drawing.Point(600, 163);
            BtnClassNew.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            BtnClassNew.Name = "BtnClassNew";
            BtnClassNew.Size = new System.Drawing.Size(94, 72);
            BtnClassNew.TabIndex = 106;
            BtnClassNew.Text = "Nuova classe";
            BtnClassNew.UseVisualStyleBackColor = false;
            BtnClassNew.Click += BtnClassNew_Click;
            // 
            // BtnClassMigration
            // 
            BtnClassMigration.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnClassMigration.BackColor = System.Drawing.Color.Transparent;
            BtnClassMigration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BtnClassMigration.ForeColor = System.Drawing.Color.DarkBlue;
            BtnClassMigration.Location = new System.Drawing.Point(1018, 163);
            BtnClassMigration.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            BtnClassMigration.Name = "BtnClassMigration";
            BtnClassMigration.Size = new System.Drawing.Size(94, 72);
            BtnClassMigration.TabIndex = 107;
            BtnClassMigration.Text = "Prepara classe";
            BtnClassMigration.UseVisualStyleBackColor = false;
            BtnClassMigration.Click += BtnClassMigration_Click;
            // 
            // txtSchoolYearNext
            // 
            txtSchoolYearNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSchoolYearNext.Location = new System.Drawing.Point(7, 38);
            txtSchoolYearNext.Margin = new System.Windows.Forms.Padding(5);
            txtSchoolYearNext.Name = "txtSchoolYearNext";
            txtSchoolYearNext.Size = new System.Drawing.Size(103, 24);
            txtSchoolYearNext.TabIndex = 108;
            // 
            // BtnClassGeneration
            // 
            BtnClassGeneration.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnClassGeneration.BackColor = System.Drawing.Color.Transparent;
            BtnClassGeneration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BtnClassGeneration.ForeColor = System.Drawing.Color.DarkBlue;
            BtnClassGeneration.Location = new System.Drawing.Point(828, 163);
            BtnClassGeneration.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            BtnClassGeneration.Name = "BtnClassGeneration";
            BtnClassGeneration.Size = new System.Drawing.Size(94, 72);
            BtnClassGeneration.TabIndex = 110;
            BtnClassGeneration.Text = "Genera classe";
            BtnClassGeneration.UseVisualStyleBackColor = false;
            BtnClassGeneration.Visible = false;
            BtnClassGeneration.Click += BtnClassGeneration_Click;
            // 
            // lblClassDescription
            // 
            lblClassDescription.AutoSize = true;
            lblClassDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblClassDescription.ForeColor = System.Drawing.Color.DarkBlue;
            lblClassDescription.Location = new System.Drawing.Point(413, 66);
            lblClassDescription.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblClassDescription.Name = "lblClassDescription";
            lblClassDescription.Size = new System.Drawing.Size(148, 15);
            lblClassDescription.TabIndex = 113;
            lblClassDescription.Text = "Descrizione nuova Classe";
            lblClassDescription.Visible = false;
            // 
            // txtClassDescriptionNext
            // 
            txtClassDescriptionNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtClassDescriptionNext.Location = new System.Drawing.Point(131, 38);
            txtClassDescriptionNext.Margin = new System.Windows.Forms.Padding(5);
            txtClassDescriptionNext.Name = "txtClassDescriptionNext";
            txtClassDescriptionNext.Size = new System.Drawing.Size(418, 24);
            txtClassDescriptionNext.TabIndex = 112;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.ForeColor = System.Drawing.Color.DarkBlue;
            label6.Location = new System.Drawing.Point(7, 17);
            label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(84, 15);
            label6.TabIndex = 114;
            label6.Text = "Id nuovo anno";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.ForeColor = System.Drawing.Color.DarkBlue;
            label7.Location = new System.Drawing.Point(285, 68);
            label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(106, 15);
            label7.TabIndex = 116;
            label7.Text = "Sigla Classe succ.";
            // 
            // txtClassAbbreviationNext
            // 
            txtClassAbbreviationNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtClassAbbreviationNext.Location = new System.Drawing.Point(4, 38);
            txtClassAbbreviationNext.Margin = new System.Windows.Forms.Padding(5);
            txtClassAbbreviationNext.Name = "txtClassAbbreviationNext";
            txtClassAbbreviationNext.Size = new System.Drawing.Size(117, 24);
            txtClassAbbreviationNext.TabIndex = 117;
            // 
            // BtnStudentNew
            // 
            BtnStudentNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnStudentNew.BackColor = System.Drawing.Color.Transparent;
            BtnStudentNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BtnStudentNew.ForeColor = System.Drawing.Color.DarkBlue;
            BtnStudentNew.Location = new System.Drawing.Point(698, 163);
            BtnStudentNew.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            BtnStudentNew.Name = "BtnStudentNew";
            BtnStudentNew.Size = new System.Drawing.Size(94, 72);
            BtnStudentNew.TabIndex = 118;
            BtnStudentNew.Text = "Nuovo allievo";
            BtnStudentNew.UseVisualStyleBackColor = false;
            BtnStudentNew.Visible = false;
            BtnStudentNew.Click += BtnStudentNew_Click;
            // 
            // cmbSchoolYearCurrents
            // 
            cmbSchoolYearCurrents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cmbSchoolYearCurrents.ForeColor = System.Drawing.Color.DarkBlue;
            cmbSchoolYearCurrents.FormattingEnabled = true;
            cmbSchoolYearCurrents.Location = new System.Drawing.Point(7, 35);
            cmbSchoolYearCurrents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbSchoolYearCurrents.Name = "cmbSchoolYearCurrents";
            cmbSchoolYearCurrents.Size = new System.Drawing.Size(104, 26);
            cmbSchoolYearCurrents.TabIndex = 120;
            cmbSchoolYearCurrents.SelectedIndexChanged += CmbSchoolYear_SelectedIndexChanged;
            // 
            // btnAssociateSchoolPeriodsToTheYear
            // 
            btnAssociateSchoolPeriodsToTheYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAssociateSchoolPeriodsToTheYear.BackColor = System.Drawing.Color.Transparent;
            btnAssociateSchoolPeriodsToTheYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnAssociateSchoolPeriodsToTheYear.ForeColor = System.Drawing.Color.DarkBlue;
            btnAssociateSchoolPeriodsToTheYear.Location = new System.Drawing.Point(1113, 163);
            btnAssociateSchoolPeriodsToTheYear.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            btnAssociateSchoolPeriodsToTheYear.Name = "btnAssociateSchoolPeriodsToTheYear";
            btnAssociateSchoolPeriodsToTheYear.Size = new System.Drawing.Size(94, 72);
            btnAssociateSchoolPeriodsToTheYear.TabIndex = 121;
            btnAssociateSchoolPeriodsToTheYear.Text = "Prepara periodi dell'anno";
            btnAssociateSchoolPeriodsToTheYear.UseVisualStyleBackColor = false;
            btnAssociateSchoolPeriodsToTheYear.Click += btnAssociateSchoolPeriodsToTheYear_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtYearDescriptionCurrent);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtYearNotesCurrent);
            groupBox1.Controls.Add(cmbSchoolYearCurrents);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new System.Drawing.Point(2, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(647, 70);
            groupBox1.TabIndex = 122;
            groupBox1.TabStop = false;
            groupBox1.Text = "Anno scolastico precedente";
            // 
            // txtYearDescriptionCurrent
            // 
            txtYearDescriptionCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtYearDescriptionCurrent.Location = new System.Drawing.Point(117, 37);
            txtYearDescriptionCurrent.Margin = new System.Windows.Forms.Padding(5);
            txtYearDescriptionCurrent.Name = "txtYearDescriptionCurrent";
            txtYearDescriptionCurrent.Size = new System.Drawing.Size(100, 24);
            txtYearDescriptionCurrent.TabIndex = 124;
            txtYearDescriptionCurrent.TextChanged += txtYearDescriptionCurrent_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label8.ForeColor = System.Drawing.Color.DarkBlue;
            label8.Location = new System.Drawing.Point(221, 17);
            label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(33, 15);
            label8.TabIndex = 123;
            label8.Text = "Note";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.DarkBlue;
            label2.Location = new System.Drawing.Point(117, 17);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(105, 15);
            label2.TabIndex = 122;
            label2.Text = "Descrizione breve";
            // 
            // txtYearNotesCurrent
            // 
            txtYearNotesCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtYearNotesCurrent.Location = new System.Drawing.Point(221, 37);
            txtYearNotesCurrent.Margin = new System.Windows.Forms.Padding(5);
            txtYearNotesCurrent.Name = "txtYearNotesCurrent";
            txtYearNotesCurrent.Size = new System.Drawing.Size(418, 24);
            txtYearNotesCurrent.TabIndex = 121;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtYearDescriptionNext);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtYearNotesNext);
            groupBox2.Controls.Add(txtSchoolYearNext);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new System.Drawing.Point(2, 84);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(647, 70);
            groupBox2.TabIndex = 123;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nuovo anno scolastico";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label10.ForeColor = System.Drawing.Color.DarkBlue;
            label10.Location = new System.Drawing.Point(221, 17);
            label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(33, 15);
            label10.TabIndex = 125;
            label10.Text = "Note";
            // 
            // txtYearDescriptionNext
            // 
            txtYearDescriptionNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtYearDescriptionNext.Location = new System.Drawing.Point(117, 38);
            txtYearDescriptionNext.Margin = new System.Windows.Forms.Padding(5);
            txtYearDescriptionNext.Name = "txtYearDescriptionNext";
            txtYearDescriptionNext.Size = new System.Drawing.Size(100, 24);
            txtYearDescriptionNext.TabIndex = 125;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.DarkBlue;
            label5.Location = new System.Drawing.Point(117, 17);
            label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(105, 15);
            label5.TabIndex = 116;
            label5.Text = "Descrizione breve";
            // 
            // txtYearNotesNext
            // 
            txtYearNotesNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtYearNotesNext.Location = new System.Drawing.Point(221, 38);
            txtYearNotesNext.Margin = new System.Windows.Forms.Padding(5);
            txtYearNotesNext.Name = "txtYearNotesNext";
            txtYearNotesNext.Size = new System.Drawing.Size(418, 24);
            txtYearNotesNext.TabIndex = 115;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(txtClassDescriptionCurrent);
            groupBox3.Controls.Add(cmbClasses);
            groupBox3.Controls.Add(label1);
            groupBox3.Location = new System.Drawing.Point(652, 10);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(564, 70);
            groupBox3.TabIndex = 125;
            groupBox3.TabStop = false;
            groupBox3.Text = "Classe precedente";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label9.ForeColor = System.Drawing.Color.DarkBlue;
            label9.Location = new System.Drawing.Point(131, 17);
            label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(72, 15);
            label9.TabIndex = 115;
            label9.Text = "Descrizione";
            // 
            // txtClassDescriptionCurrent
            // 
            txtClassDescriptionCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtClassDescriptionCurrent.Location = new System.Drawing.Point(131, 38);
            txtClassDescriptionCurrent.Margin = new System.Windows.Forms.Padding(5);
            txtClassDescriptionCurrent.Name = "txtClassDescriptionCurrent";
            txtClassDescriptionCurrent.Size = new System.Drawing.Size(418, 24);
            txtClassDescriptionCurrent.TabIndex = 114;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(txtClassDescriptionNext);
            groupBox4.Controls.Add(txtClassAbbreviationNext);
            groupBox4.Location = new System.Drawing.Point(655, 84);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(564, 70);
            groupBox4.TabIndex = 126;
            groupBox4.TabStop = false;
            groupBox4.Text = "Nuova classe";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label11.ForeColor = System.Drawing.Color.DarkBlue;
            label11.Location = new System.Drawing.Point(131, 17);
            label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(72, 15);
            label11.TabIndex = 115;
            label11.Text = "Descrizione";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label12.ForeColor = System.Drawing.Color.DarkBlue;
            label12.Location = new System.Drawing.Point(4, 17);
            label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(35, 15);
            label12.TabIndex = 94;
            label12.Text = "Sigla";
            // 
            // frmNewYear
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(1220, 636);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnAssociateSchoolPeriodsToTheYear);
            Controls.Add(BtnStudentNew);
            Controls.Add(label7);
            Controls.Add(lblClassDescription);
            Controls.Add(BtnClassGeneration);
            Controls.Add(BtnClassMigration);
            Controls.Add(BtnClassNew);
            Controls.Add(lblChooseNextStudents);
            Controls.Add(DgwStudents);
            Controls.Add(TxtOfficialSchoolAbbreviation);
            Controls.Add(label4);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "frmNewYear";
            Text = "Nuovo anno scolastico";
            Load += frmNewYear_Load;
            ((System.ComponentModel.ISupportInitialize)DgwStudents).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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