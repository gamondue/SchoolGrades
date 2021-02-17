namespace SchoolGrades
{
    partial class frmTestManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestManagement));
            this.lblQuestionType = new System.Windows.Forms.Label();
            this.lblSchoolSubject = new System.Windows.Forms.Label();
            this.cmbQuestionTypes = new System.Windows.Forms.ComboBox();
            this.cmbSchoolSubject = new System.Windows.Forms.ComboBox();
            this.txtIdTest = new System.Windows.Forms.TextBox();
            this.lblIdCode = new System.Windows.Forms.Label();
            this.chk = new System.Windows.Forms.CheckBox();
            this.CmbSchoolYear = new System.Windows.Forms.ComboBox();
            this.lblCodYear = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTestType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTestName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTestDescription = new System.Windows.Forms.TextBox();
            this.btnAddTest = new System.Windows.Forms.Button();
            this.btnSaveTests = new System.Windows.Forms.Button();
            this.dgwQuestions = new System.Windows.Forms.DataGridView();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.btnSaveQuestion = new System.Windows.Forms.Button();
            this.dgwTests = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCopyTest = new System.Windows.Forms.Button();
            this.btnGradeTest = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTests)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuestionType
            // 
            this.lblQuestionType.AutoSize = true;
            this.lblQuestionType.Location = new System.Drawing.Point(129, 284);
            this.lblQuestionType.Name = "lblQuestionType";
            this.lblQuestionType.Size = new System.Drawing.Size(103, 18);
            this.lblQuestionType.TabIndex = 107;
            this.lblQuestionType.Text = "Tipo domanda";
            // 
            // lblSchoolSubject
            // 
            this.lblSchoolSubject.AutoSize = true;
            this.lblSchoolSubject.Location = new System.Drawing.Point(121, 57);
            this.lblSchoolSubject.Name = "lblSchoolSubject";
            this.lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            this.lblSchoolSubject.TabIndex = 106;
            this.lblSchoolSubject.Text = "Materia";
            // 
            // cmbQuestionTypes
            // 
            this.cmbQuestionTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbQuestionTypes.FormattingEnabled = true;
            this.cmbQuestionTypes.Location = new System.Drawing.Point(238, 281);
            this.cmbQuestionTypes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbQuestionTypes.Name = "cmbQuestionTypes";
            this.cmbQuestionTypes.Size = new System.Drawing.Size(233, 26);
            this.cmbQuestionTypes.TabIndex = 108;
            // 
            // cmbSchoolSubject
            // 
            this.cmbSchoolSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchoolSubject.FormattingEnabled = true;
            this.cmbSchoolSubject.Location = new System.Drawing.Point(184, 53);
            this.cmbSchoolSubject.Name = "cmbSchoolSubject";
            this.cmbSchoolSubject.Size = new System.Drawing.Size(233, 26);
            this.cmbSchoolSubject.TabIndex = 105;
            // 
            // txtIdTest
            // 
            this.txtIdTest.Location = new System.Drawing.Point(184, 22);
            this.txtIdTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIdTest.Name = "txtIdTest";
            this.txtIdTest.ReadOnly = true;
            this.txtIdTest.Size = new System.Drawing.Size(90, 24);
            this.txtIdTest.TabIndex = 110;
            this.txtIdTest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIdCode
            // 
            this.lblIdCode.AutoSize = true;
            this.lblIdCode.Location = new System.Drawing.Point(105, 25);
            this.lblIdCode.Name = "lblIdCode";
            this.lblIdCode.Size = new System.Drawing.Size(77, 18);
            this.lblIdCode.TabIndex = 111;
            this.lblIdCode.Text = "Cod.prova";
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Location = new System.Drawing.Point(12, 283);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(101, 22);
            this.chk.TabIndex = 112;
            this.chk.Text = "checkBox1";
            this.chk.UseVisualStyleBackColor = true;
            // 
            // CmbSchoolYear
            // 
            this.CmbSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.CmbSchoolYear.FormattingEnabled = true;
            this.CmbSchoolYear.Location = new System.Drawing.Point(12, 46);
            this.CmbSchoolYear.Name = "CmbSchoolYear";
            this.CmbSchoolYear.Size = new System.Drawing.Size(72, 26);
            this.CmbSchoolYear.TabIndex = 114;
            // 
            // lblCodYear
            // 
            this.lblCodYear.AutoSize = true;
            this.lblCodYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCodYear.Location = new System.Drawing.Point(12, 25);
            this.lblCodYear.Name = "lblCodYear";
            this.lblCodYear.Size = new System.Drawing.Size(74, 18);
            this.lblCodYear.TabIndex = 113;
            this.lblCodYear.Text = "Cod.Anno";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 116;
            this.label1.Text = "Tipo di prova";
            // 
            // cmbTestType
            // 
            this.cmbTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTestType.FormattingEnabled = true;
            this.cmbTestType.Location = new System.Drawing.Point(528, 53);
            this.cmbTestType.Name = "cmbTestType";
            this.cmbTestType.Size = new System.Drawing.Size(233, 26);
            this.cmbTestType.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 18);
            this.label2.TabIndex = 119;
            this.label2.Text = "Nome";
            // 
            // txtTestName
            // 
            this.txtTestName.Location = new System.Drawing.Point(348, 22);
            this.txtTestName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(90, 24);
            this.txtTestName.TabIndex = 118;
            this.txtTestName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 121;
            this.label3.Text = "Descrizione";
            // 
            // txtTestDescription
            // 
            this.txtTestDescription.Location = new System.Drawing.Point(545, 22);
            this.txtTestDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTestDescription.Name = "txtTestDescription";
            this.txtTestDescription.Size = new System.Drawing.Size(138, 24);
            this.txtTestDescription.TabIndex = 120;
            this.txtTestDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAddTest
            // 
            this.btnAddTest.Location = new System.Drawing.Point(1012, 46);
            this.btnAddTest.Name = "btnAddTest";
            this.btnAddTest.Size = new System.Drawing.Size(39, 35);
            this.btnAddTest.TabIndex = 122;
            this.btnAddTest.Text = "+";
            this.btnAddTest.UseVisualStyleBackColor = true;
            this.btnAddTest.Click += new System.EventHandler(this.btnAddTest_Click);
            // 
            // btnSaveTests
            // 
            this.btnSaveTests.Location = new System.Drawing.Point(1057, 46);
            this.btnSaveTests.Name = "btnSaveTests";
            this.btnSaveTests.Size = new System.Drawing.Size(70, 35);
            this.btnSaveTests.TabIndex = 123;
            this.btnSaveTests.Text = "Salva";
            this.btnSaveTests.UseVisualStyleBackColor = true;
            this.btnSaveTests.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgwQuestions
            // 
            this.dgwQuestions.AllowUserToAddRows = false;
            this.dgwQuestions.AllowUserToDeleteRows = false;
            this.dgwQuestions.AllowUserToOrderColumns = true;
            this.dgwQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwQuestions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwQuestions.Location = new System.Drawing.Point(11, 312);
            this.dgwQuestions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwQuestions.Name = "dgwQuestions";
            this.dgwQuestions.RowTemplate.Height = 24;
            this.dgwQuestions.Size = new System.Drawing.Size(1116, 229);
            this.dgwQuestions.TabIndex = 125;
            this.dgwQuestions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwQuestions_CellClick);
            this.dgwQuestions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwQuestions_CellContentClick);
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(1012, 276);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(39, 35);
            this.btnAddQuestion.TabIndex = 126;
            this.btnAddQuestion.Text = "+";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // btnSaveQuestion
            // 
            this.btnSaveQuestion.Location = new System.Drawing.Point(1057, 276);
            this.btnSaveQuestion.Name = "btnSaveQuestion";
            this.btnSaveQuestion.Size = new System.Drawing.Size(70, 35);
            this.btnSaveQuestion.TabIndex = 127;
            this.btnSaveQuestion.Text = "Salva";
            this.btnSaveQuestion.UseVisualStyleBackColor = true;
            // 
            // dgwTests
            // 
            this.dgwTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTests.Location = new System.Drawing.Point(11, 85);
            this.dgwTests.Name = "dgwTests";
            this.dgwTests.RowTemplate.Height = 24;
            this.dgwTests.Size = new System.Drawing.Size(1116, 185);
            this.dgwTests.TabIndex = 128;
            this.dgwTests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwTests_CellContentClick);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(483, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 35);
            this.button1.TabIndex = 129;
            this.button1.Text = "Stampa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnCopyTest
            // 
            this.btnCopyTest.Enabled = false;
            this.btnCopyTest.Location = new System.Drawing.Point(556, 276);
            this.btnCopyTest.Name = "btnCopyTest";
            this.btnCopyTest.Size = new System.Drawing.Size(67, 35);
            this.btnCopyTest.TabIndex = 130;
            this.btnCopyTest.Text = "Copia";
            this.btnCopyTest.UseVisualStyleBackColor = true;
            // 
            // btnGradeTest
            // 
            this.btnGradeTest.Location = new System.Drawing.Point(863, 44);
            this.btnGradeTest.Name = "btnGradeTest";
            this.btnGradeTest.Size = new System.Drawing.Size(79, 35);
            this.btnGradeTest.TabIndex = 131;
            this.btnGradeTest.Text = "Correggi";
            this.btnGradeTest.UseVisualStyleBackColor = true;
            this.btnGradeTest.Click += new System.EventHandler(this.btnGradeTest_Click);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Location = new System.Drawing.Point(851, 276);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(39, 35);
            this.btnDeleteQuestion.TabIndex = 132;
            this.btnDeleteQuestion.Text = "-";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // frmTestManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1140, 554);
            this.Controls.Add(this.btnDeleteQuestion);
            this.Controls.Add(this.btnGradeTest);
            this.Controls.Add(this.btnCopyTest);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgwTests);
            this.Controls.Add(this.btnSaveQuestion);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.dgwQuestions);
            this.Controls.Add(this.btnSaveTests);
            this.Controls.Add(this.btnAddTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTestDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTestName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTestType);
            this.Controls.Add(this.CmbSchoolYear);
            this.Controls.Add(this.lblCodYear);
            this.Controls.Add(this.chk);
            this.Controls.Add(this.lblIdCode);
            this.Controls.Add(this.txtIdTest);
            this.Controls.Add(this.lblQuestionType);
            this.Controls.Add(this.lblSchoolSubject);
            this.Controls.Add(this.cmbQuestionTypes);
            this.Controls.Add(this.cmbSchoolSubject);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTestManagement";
            this.Text = "Gestione prove";
            this.Load += new System.EventHandler(this.frmTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestionType;
        private System.Windows.Forms.Label lblSchoolSubject;
        private System.Windows.Forms.ComboBox cmbQuestionTypes;
        private System.Windows.Forms.ComboBox cmbSchoolSubject;
        private System.Windows.Forms.TextBox txtIdTest;
        private System.Windows.Forms.Label lblIdCode;
        private System.Windows.Forms.CheckBox chk;
        private System.Windows.Forms.ComboBox CmbSchoolYear;
        private System.Windows.Forms.Label lblCodYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTestType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTestDescription;
        private System.Windows.Forms.Button btnAddTest;
        private System.Windows.Forms.Button btnSaveTests;
        private System.Windows.Forms.DataGridView dgwQuestions;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Button btnSaveQuestion;
        private System.Windows.Forms.DataGridView dgwTests;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCopyTest;
        private System.Windows.Forms.Button btnGradeTest;
        private System.Windows.Forms.Button btnDeleteQuestion;
    }
}