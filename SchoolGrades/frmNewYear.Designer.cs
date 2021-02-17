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
            this.CmbClasses = new System.Windows.Forms.ComboBox();
            this.TxtOfficialSchoolAbbreviation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DgwStudents = new System.Windows.Forms.DataGridView();
            this.SaveThisStudent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblChooseNextStudents = new System.Windows.Forms.Label();
            this.BtnClassNew = new System.Windows.Forms.Button();
            this.BtnClassMigration = new System.Windows.Forms.Button();
            this.TxtSchoolYearNext = new System.Windows.Forms.TextBox();
            this.BtnClassGenerate = new System.Windows.Forms.Button();
            this.lblClassDescription = new System.Windows.Forms.Label();
            this.TxtClassDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtClassNext = new System.Windows.Forms.TextBox();
            this.BtnStudentNew = new System.Windows.Forms.Button();
            this.CmbPresentSchoolYear = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgwStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbClasses
            // 
            this.CmbClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbClasses.FormattingEnabled = true;
            this.CmbClasses.Location = new System.Drawing.Point(247, 26);
            this.CmbClasses.Name = "CmbClasses";
            this.CmbClasses.Size = new System.Drawing.Size(102, 26);
            this.CmbClasses.TabIndex = 101;
            this.CmbClasses.SelectedIndexChanged += new System.EventHandler(this.CmbClasses_SelectedIndexChanged);
            // 
            // TxtOfficialSchoolAbbreviation
            // 
            this.TxtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOfficialSchoolAbbreviation.Location = new System.Drawing.Point(4, 27);
            this.TxtOfficialSchoolAbbreviation.Margin = new System.Windows.Forms.Padding(4);
            this.TxtOfficialSchoolAbbreviation.Name = "TxtOfficialSchoolAbbreviation";
            this.TxtOfficialSchoolAbbreviation.ReadOnly = true;
            this.TxtOfficialSchoolAbbreviation.Size = new System.Drawing.Size(135, 24);
            this.TxtOfficialSchoolAbbreviation.TabIndex = 98;
            this.TxtOfficialSchoolAbbreviation.Text = "FOIS01100L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(2, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 97;
            this.label4.Text = "Codice Scuola";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(244, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 94;
            this.label1.Text = "Sigla Classe prec.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(147, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 103;
            this.label3.Text = "Anno precedente";
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
            this.DgwStudents.Location = new System.Drawing.Point(4, 147);
            this.DgwStudents.Margin = new System.Windows.Forms.Padding(4);
            this.DgwStudents.MultiSelect = false;
            this.DgwStudents.Name = "DgwStudents";
            this.DgwStudents.RowTemplate.Height = 24;
            this.DgwStudents.Size = new System.Drawing.Size(793, 403);
            this.DgwStudents.TabIndex = 104;
            this.DgwStudents.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DgwStudents_RowsAdded);
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
            this.lblChooseNextStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseNextStudents.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblChooseNextStudents.Location = new System.Drawing.Point(1, 120);
            this.lblChooseNextStudents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChooseNextStudents.Name = "lblChooseNextStudents";
            this.lblChooseNextStudents.Size = new System.Drawing.Size(288, 18);
            this.lblChooseNextStudents.TabIndex = 105;
            this.lblChooseNextStudents.Text = "Allievi da escudere dalla classe successiva";
            // 
            // BtnClassNew
            // 
            this.BtnClassNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClassNew.BackColor = System.Drawing.Color.Transparent;
            this.BtnClassNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClassNew.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnClassNew.Location = new System.Drawing.Point(716, 6);
            this.BtnClassNew.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnClassNew.Name = "BtnClassNew";
            this.BtnClassNew.Size = new System.Drawing.Size(81, 62);
            this.BtnClassNew.TabIndex = 106;
            this.BtnClassNew.Text = "Nuova classe";
            this.BtnClassNew.UseVisualStyleBackColor = false;
            this.BtnClassNew.Click += new System.EventHandler(this.BtnClassNew_Click);
            // 
            // BtnClassMigration
            // 
            this.BtnClassMigration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClassMigration.BackColor = System.Drawing.Color.Transparent;
            this.BtnClassMigration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClassMigration.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnClassMigration.Location = new System.Drawing.Point(552, 76);
            this.BtnClassMigration.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnClassMigration.Name = "BtnClassMigration";
            this.BtnClassMigration.Size = new System.Drawing.Size(81, 62);
            this.BtnClassMigration.TabIndex = 107;
            this.BtnClassMigration.Text = "Prepara classe";
            this.BtnClassMigration.UseVisualStyleBackColor = false;
            this.BtnClassMigration.Click += new System.EventHandler(this.BtnClassMigration_Click);
            // 
            // TxtSchoolYearNext
            // 
            this.TxtSchoolYearNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSchoolYearNext.Location = new System.Drawing.Point(147, 76);
            this.TxtSchoolYearNext.Margin = new System.Windows.Forms.Padding(4);
            this.TxtSchoolYearNext.Name = "TxtSchoolYearNext";
            this.TxtSchoolYearNext.Size = new System.Drawing.Size(89, 24);
            this.TxtSchoolYearNext.TabIndex = 108;
            // 
            // BtnClassGenerate
            // 
            this.BtnClassGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClassGenerate.BackColor = System.Drawing.Color.Transparent;
            this.BtnClassGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClassGenerate.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnClassGenerate.Location = new System.Drawing.Point(716, 76);
            this.BtnClassGenerate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnClassGenerate.Name = "BtnClassGenerate";
            this.BtnClassGenerate.Size = new System.Drawing.Size(81, 62);
            this.BtnClassGenerate.TabIndex = 110;
            this.BtnClassGenerate.Text = "Genera classe";
            this.BtnClassGenerate.UseVisualStyleBackColor = false;
            this.BtnClassGenerate.Click += new System.EventHandler(this.BtnClassGenerate_Click);
            // 
            // lblClassDescription
            // 
            this.lblClassDescription.AutoSize = true;
            this.lblClassDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassDescription.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblClassDescription.Location = new System.Drawing.Point(353, 8);
            this.lblClassDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClassDescription.Name = "lblClassDescription";
            this.lblClassDescription.Size = new System.Drawing.Size(112, 15);
            this.lblClassDescription.TabIndex = 113;
            this.lblClassDescription.Text = "Descrizione Classe";
            this.lblClassDescription.Visible = false;
            // 
            // TxtClassDescription
            // 
            this.TxtClassDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtClassDescription.Location = new System.Drawing.Point(356, 27);
            this.TxtClassDescription.Margin = new System.Windows.Forms.Padding(4);
            this.TxtClassDescription.Name = "TxtClassDescription";
            this.TxtClassDescription.Size = new System.Drawing.Size(359, 24);
            this.TxtClassDescription.TabIndex = 112;
            this.TxtClassDescription.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(147, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 114;
            this.label6.Text = "Anno successivo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(244, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 15);
            this.label7.TabIndex = 116;
            this.label7.Text = "Sigla Classe succ.";
            // 
            // TxtClassNext
            // 
            this.TxtClassNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtClassNext.Location = new System.Drawing.Point(248, 76);
            this.TxtClassNext.Margin = new System.Windows.Forms.Padding(4);
            this.TxtClassNext.Name = "TxtClassNext";
            this.TxtClassNext.Size = new System.Drawing.Size(101, 24);
            this.TxtClassNext.TabIndex = 117;
            // 
            // BtnStudentNew
            // 
            this.BtnStudentNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStudentNew.BackColor = System.Drawing.Color.Transparent;
            this.BtnStudentNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStudentNew.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnStudentNew.Location = new System.Drawing.Point(365, 231);
            this.BtnStudentNew.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnStudentNew.Name = "BtnStudentNew";
            this.BtnStudentNew.Size = new System.Drawing.Size(81, 62);
            this.BtnStudentNew.TabIndex = 118;
            this.BtnStudentNew.Text = "Nuovo allievo";
            this.BtnStudentNew.UseVisualStyleBackColor = false;
            this.BtnStudentNew.Visible = false;
            this.BtnStudentNew.Click += new System.EventHandler(this.BtnStudentNew_Click);
            // 
            // CmbPresentSchoolYear
            // 
            this.CmbPresentSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPresentSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.CmbPresentSchoolYear.FormattingEnabled = true;
            this.CmbPresentSchoolYear.Location = new System.Drawing.Point(147, 26);
            this.CmbPresentSchoolYear.Name = "CmbPresentSchoolYear";
            this.CmbPresentSchoolYear.Size = new System.Drawing.Size(90, 26);
            this.CmbPresentSchoolYear.TabIndex = 120;
            this.CmbPresentSchoolYear.SelectedIndexChanged += new System.EventHandler(this.CmbSchoolYear_SelectedIndexChanged);
            // 
            // frmNewYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(802, 551);
            this.Controls.Add(this.CmbPresentSchoolYear);
            this.Controls.Add(this.BtnStudentNew);
            this.Controls.Add(this.TxtClassNext);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblClassDescription);
            this.Controls.Add(this.TxtClassDescription);
            this.Controls.Add(this.BtnClassGenerate);
            this.Controls.Add(this.TxtSchoolYearNext);
            this.Controls.Add(this.BtnClassMigration);
            this.Controls.Add(this.BtnClassNew);
            this.Controls.Add(this.lblChooseNextStudents);
            this.Controls.Add(this.DgwStudents);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbClasses);
            this.Controls.Add(this.TxtOfficialSchoolAbbreviation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewYear";
            this.Text = "Nuovo anno scolastico";
            this.Load += new System.EventHandler(this.frmNewYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgwStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbClasses;
        private System.Windows.Forms.TextBox TxtOfficialSchoolAbbreviation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgwStudents;
        private System.Windows.Forms.Label lblChooseNextStudents;
        private System.Windows.Forms.Button BtnClassNew;
        private System.Windows.Forms.Button BtnClassMigration;
        private System.Windows.Forms.TextBox TxtSchoolYearNext;
        private System.Windows.Forms.Button BtnClassGenerate;
        private System.Windows.Forms.Label lblClassDescription;
        private System.Windows.Forms.TextBox TxtClassDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtClassNext;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SaveThisStudent;
        private System.Windows.Forms.Button BtnStudentNew;
        private System.Windows.Forms.ComboBox CmbPresentSchoolYear;
    }
}