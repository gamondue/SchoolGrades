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
            cmbClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            cmbClasses.FormattingEnabled = true;
            cmbClasses.Location = new System.Drawing.Point(6, 63);
            cmbClasses.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            cmbClasses.Name = "cmbClasses";
            cmbClasses.Size = new System.Drawing.Size(167, 37);
            cmbClasses.TabIndex = 101;
            cmbClasses.SelectedIndexChanged += CmbClasses_SelectedIndexChanged;
            // 
            // TxtOfficialSchoolAbbreviation
            // 
            TxtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            TxtOfficialSchoolAbbreviation.Location = new System.Drawing.Point(150, 263);
            TxtOfficialSchoolAbbreviation.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            TxtOfficialSchoolAbbreviation.Name = "TxtOfficialSchoolAbbreviation";
            TxtOfficialSchoolAbbreviation.ReadOnly = true;
            TxtOfficialSchoolAbbreviation.Size = new System.Drawing.Size(223, 33);
            TxtOfficialSchoolAbbreviation.TabIndex = 98;
            TxtOfficialSchoolAbbreviation.Text = "FOIS01100L";
            TxtOfficialSchoolAbbreviation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label4.ForeColor = System.Drawing.Color.DarkBlue;
            label4.Location = new System.Drawing.Point(13, 272);
            label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(126, 22);
            label4.TabIndex = 97;
            label4.Text = "Codice Scuola";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label1.ForeColor = System.Drawing.Color.DarkBlue;
            label1.Location = new System.Drawing.Point(6, 28);
            label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(155, 22);
            label1.TabIndex = 94;
            label1.Text = "Sigla Classe prec.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label3.ForeColor = System.Drawing.Color.DarkBlue;
            label3.Location = new System.Drawing.Point(10, 28);
            label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(69, 22);
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
            DgwStudents.Location = new System.Drawing.Point(7, 410);
            DgwStudents.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            DgwStudents.MultiSelect = false;
            DgwStudents.Name = "DgwStudents";
            DgwStudents.RowHeadersWidth = 62;
            DgwStudents.RowTemplate.Height = 24;
            DgwStudents.Size = new System.Drawing.Size(1727, 648);
            DgwStudents.TabIndex = 104;
            // 
            // SaveThisStudent
            // 
            SaveThisStudent.HeaderText = "Column1";
            SaveThisStudent.MinimumWidth = 8;
            SaveThisStudent.Name = "SaveThisStudent";
            SaveThisStudent.Width = 8;
            // 
            // lblChooseNextStudents
            // 
            lblChooseNextStudents.AutoSize = true;
            lblChooseNextStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            lblChooseNextStudents.ForeColor = System.Drawing.Color.DarkBlue;
            lblChooseNextStudents.Location = new System.Drawing.Point(3, 372);
            lblChooseNextStudents.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            lblChooseNextStudents.Name = "lblChooseNextStudents";
            lblChooseNextStudents.Size = new System.Drawing.Size(467, 26);
            lblChooseNextStudents.TabIndex = 105;
            lblChooseNextStudents.Text = "Allievi da INCLUDERE nella classe successiva";
            // 
            // BtnClassNew
            // 
            BtnClassNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnClassNew.BackColor = System.Drawing.Color.Transparent;
            BtnClassNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            BtnClassNew.ForeColor = System.Drawing.Color.DarkBlue;
            BtnClassNew.Location = new System.Drawing.Point(857, 272);
            BtnClassNew.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            BtnClassNew.Name = "BtnClassNew";
            BtnClassNew.Size = new System.Drawing.Size(134, 120);
            BtnClassNew.TabIndex = 106;
            BtnClassNew.Text = "Nuova classe";
            BtnClassNew.UseVisualStyleBackColor = false;
            BtnClassNew.Click += BtnClassNew_Click;
            // 
            // BtnClassMigration
            // 
            BtnClassMigration.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnClassMigration.BackColor = System.Drawing.Color.Transparent;
            BtnClassMigration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            BtnClassMigration.ForeColor = System.Drawing.Color.DarkBlue;
            BtnClassMigration.Location = new System.Drawing.Point(1454, 272);
            BtnClassMigration.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            BtnClassMigration.Name = "BtnClassMigration";
            BtnClassMigration.Size = new System.Drawing.Size(134, 120);
            BtnClassMigration.TabIndex = 107;
            BtnClassMigration.Text = "Prepara classe";
            BtnClassMigration.UseVisualStyleBackColor = false;
            BtnClassMigration.Click += BtnClassMigration_Click;
            // 
            // txtSchoolYearNext
            // 
            txtSchoolYearNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            txtSchoolYearNext.Location = new System.Drawing.Point(10, 63);
            txtSchoolYearNext.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            txtSchoolYearNext.Name = "txtSchoolYearNext";
            txtSchoolYearNext.Size = new System.Drawing.Size(145, 33);
            txtSchoolYearNext.TabIndex = 108;
            // 
            // BtnClassGeneration
            // 
            BtnClassGeneration.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnClassGeneration.BackColor = System.Drawing.Color.Transparent;
            BtnClassGeneration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            BtnClassGeneration.ForeColor = System.Drawing.Color.DarkBlue;
            BtnClassGeneration.Location = new System.Drawing.Point(1183, 272);
            BtnClassGeneration.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            BtnClassGeneration.Name = "BtnClassGeneration";
            BtnClassGeneration.Size = new System.Drawing.Size(134, 120);
            BtnClassGeneration.TabIndex = 110;
            BtnClassGeneration.Text = "Genera classe";
            BtnClassGeneration.UseVisualStyleBackColor = false;
            BtnClassGeneration.Visible = false;
            BtnClassGeneration.Click += BtnClassGeneration_Click;
            // 
            // lblClassDescription
            // 
            lblClassDescription.AutoSize = true;
            lblClassDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            lblClassDescription.ForeColor = System.Drawing.Color.DarkBlue;
            lblClassDescription.Location = new System.Drawing.Point(590, 110);
            lblClassDescription.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            lblClassDescription.Name = "lblClassDescription";
            lblClassDescription.Size = new System.Drawing.Size(217, 22);
            lblClassDescription.TabIndex = 113;
            lblClassDescription.Text = "Descrizione nuova Classe";
            lblClassDescription.Visible = false;
            // 
            // txtClassDescriptionNext
            // 
            txtClassDescriptionNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            txtClassDescriptionNext.Location = new System.Drawing.Point(187, 63);
            txtClassDescriptionNext.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            txtClassDescriptionNext.Name = "txtClassDescriptionNext";
            txtClassDescriptionNext.Size = new System.Drawing.Size(595, 33);
            txtClassDescriptionNext.TabIndex = 112;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label6.ForeColor = System.Drawing.Color.DarkBlue;
            label6.Location = new System.Drawing.Point(10, 28);
            label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(123, 22);
            label6.TabIndex = 114;
            label6.Text = "Id nuovo anno";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label7.ForeColor = System.Drawing.Color.DarkBlue;
            label7.Location = new System.Drawing.Point(407, 113);
            label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(157, 22);
            label7.TabIndex = 116;
            label7.Text = "Sigla Classe succ.";
            // 
            // txtClassAbbreviationNext
            // 
            txtClassAbbreviationNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            txtClassAbbreviationNext.Location = new System.Drawing.Point(6, 63);
            txtClassAbbreviationNext.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            txtClassAbbreviationNext.Name = "txtClassAbbreviationNext";
            txtClassAbbreviationNext.Size = new System.Drawing.Size(165, 33);
            txtClassAbbreviationNext.TabIndex = 117;
            // 
            // BtnStudentNew
            // 
            BtnStudentNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnStudentNew.BackColor = System.Drawing.Color.Transparent;
            BtnStudentNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            BtnStudentNew.ForeColor = System.Drawing.Color.DarkBlue;
            BtnStudentNew.Location = new System.Drawing.Point(997, 272);
            BtnStudentNew.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            BtnStudentNew.Name = "BtnStudentNew";
            BtnStudentNew.Size = new System.Drawing.Size(134, 120);
            BtnStudentNew.TabIndex = 118;
            BtnStudentNew.Text = "Nuovo allievo";
            BtnStudentNew.UseVisualStyleBackColor = false;
            BtnStudentNew.Visible = false;
            BtnStudentNew.Click += BtnStudentNew_Click;
            // 
            // cmbSchoolYearCurrents
            // 
            cmbSchoolYearCurrents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            cmbSchoolYearCurrents.ForeColor = System.Drawing.Color.DarkBlue;
            cmbSchoolYearCurrents.FormattingEnabled = true;
            cmbSchoolYearCurrents.Location = new System.Drawing.Point(10, 58);
            cmbSchoolYearCurrents.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            cmbSchoolYearCurrents.Name = "cmbSchoolYearCurrents";
            cmbSchoolYearCurrents.Size = new System.Drawing.Size(147, 37);
            cmbSchoolYearCurrents.TabIndex = 120;
            cmbSchoolYearCurrents.SelectedIndexChanged += CmbSchoolYear_SelectedIndexChanged;
            // 
            // btnAssociateSchoolPeriodsToTheYear
            // 
            btnAssociateSchoolPeriodsToTheYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAssociateSchoolPeriodsToTheYear.BackColor = System.Drawing.Color.Transparent;
            btnAssociateSchoolPeriodsToTheYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            btnAssociateSchoolPeriodsToTheYear.ForeColor = System.Drawing.Color.DarkBlue;
            btnAssociateSchoolPeriodsToTheYear.Location = new System.Drawing.Point(1590, 272);
            btnAssociateSchoolPeriodsToTheYear.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            btnAssociateSchoolPeriodsToTheYear.Name = "btnAssociateSchoolPeriodsToTheYear";
            btnAssociateSchoolPeriodsToTheYear.Size = new System.Drawing.Size(134, 120);
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
            groupBox1.Location = new System.Drawing.Point(3, 22);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox1.Size = new System.Drawing.Size(924, 117);
            groupBox1.TabIndex = 122;
            groupBox1.TabStop = false;
            groupBox1.Text = "Anno scolastico precedente";
            // 
            // txtYearDescriptionCurrent
            // 
            txtYearDescriptionCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            txtYearDescriptionCurrent.Location = new System.Drawing.Point(167, 62);
            txtYearDescriptionCurrent.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            txtYearDescriptionCurrent.Name = "txtYearDescriptionCurrent";
            txtYearDescriptionCurrent.Size = new System.Drawing.Size(141, 33);
            txtYearDescriptionCurrent.TabIndex = 124;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label8.ForeColor = System.Drawing.Color.DarkBlue;
            label8.Location = new System.Drawing.Point(316, 28);
            label8.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(48, 22);
            label8.TabIndex = 123;
            label8.Text = "Note";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label2.ForeColor = System.Drawing.Color.DarkBlue;
            label2.Location = new System.Drawing.Point(167, 28);
            label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(153, 22);
            label2.TabIndex = 122;
            label2.Text = "Descrizione breve";
            // 
            // txtYearNotesCurrent
            // 
            txtYearNotesCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            txtYearNotesCurrent.Location = new System.Drawing.Point(316, 62);
            txtYearNotesCurrent.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            txtYearNotesCurrent.Name = "txtYearNotesCurrent";
            txtYearNotesCurrent.Size = new System.Drawing.Size(595, 33);
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
            groupBox2.Location = new System.Drawing.Point(3, 140);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox2.Size = new System.Drawing.Size(924, 117);
            groupBox2.TabIndex = 123;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nuovo anno scolastico";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label10.ForeColor = System.Drawing.Color.DarkBlue;
            label10.Location = new System.Drawing.Point(316, 28);
            label10.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(48, 22);
            label10.TabIndex = 125;
            label10.Text = "Note";
            // 
            // txtYearDescriptionNext
            // 
            txtYearDescriptionNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            txtYearDescriptionNext.Location = new System.Drawing.Point(167, 63);
            txtYearDescriptionNext.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            txtYearDescriptionNext.Name = "txtYearDescriptionNext";
            txtYearDescriptionNext.Size = new System.Drawing.Size(141, 33);
            txtYearDescriptionNext.TabIndex = 125;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label5.ForeColor = System.Drawing.Color.DarkBlue;
            label5.Location = new System.Drawing.Point(167, 28);
            label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(153, 22);
            label5.TabIndex = 116;
            label5.Text = "Descrizione breve";
            // 
            // txtYearNotesNext
            // 
            txtYearNotesNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            txtYearNotesNext.Location = new System.Drawing.Point(316, 63);
            txtYearNotesNext.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            txtYearNotesNext.Name = "txtYearNotesNext";
            txtYearNotesNext.Size = new System.Drawing.Size(595, 33);
            txtYearNotesNext.TabIndex = 115;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(txtClassDescriptionCurrent);
            groupBox3.Controls.Add(cmbClasses);
            groupBox3.Controls.Add(label1);
            groupBox3.Location = new System.Drawing.Point(931, 17);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox3.Size = new System.Drawing.Size(806, 117);
            groupBox3.TabIndex = 125;
            groupBox3.TabStop = false;
            groupBox3.Text = "Classe precedente";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label9.ForeColor = System.Drawing.Color.DarkBlue;
            label9.Location = new System.Drawing.Point(187, 28);
            label9.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(103, 22);
            label9.TabIndex = 115;
            label9.Text = "Descrizione";
            // 
            // txtClassDescriptionCurrent
            // 
            txtClassDescriptionCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            txtClassDescriptionCurrent.Location = new System.Drawing.Point(187, 63);
            txtClassDescriptionCurrent.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            txtClassDescriptionCurrent.Name = "txtClassDescriptionCurrent";
            txtClassDescriptionCurrent.Size = new System.Drawing.Size(595, 33);
            txtClassDescriptionCurrent.TabIndex = 114;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(txtClassDescriptionNext);
            groupBox4.Controls.Add(txtClassAbbreviationNext);
            groupBox4.Location = new System.Drawing.Point(936, 140);
            groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox4.Size = new System.Drawing.Size(806, 117);
            groupBox4.TabIndex = 126;
            groupBox4.TabStop = false;
            groupBox4.Text = "Nuova classe";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label11.ForeColor = System.Drawing.Color.DarkBlue;
            label11.Location = new System.Drawing.Point(187, 28);
            label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(103, 22);
            label11.TabIndex = 115;
            label11.Text = "Descrizione";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label12.ForeColor = System.Drawing.Color.DarkBlue;
            label12.Location = new System.Drawing.Point(6, 28);
            label12.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(50, 22);
            label12.TabIndex = 94;
            label12.Text = "Sigla";
            // 
            // frmNewYear
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(1743, 1060);
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
            Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
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