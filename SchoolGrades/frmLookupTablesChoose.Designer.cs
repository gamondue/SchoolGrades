namespace SchoolGrades
{
    partial class frmLookupTablesChoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLookupTablesChoose));
            rdbSchoolSubjects = new System.Windows.Forms.RadioButton();
            rdbTestTypes = new System.Windows.Forms.RadioButton();
            rdbGradeTypes = new System.Windows.Forms.RadioButton();
            rdbSchools = new System.Windows.Forms.RadioButton();
            rdbQuestionTypes = new System.Windows.Forms.RadioButton();
            rdbGradeCategories = new System.Windows.Forms.RadioButton();
            rdbSchoolYears = new System.Windows.Forms.RadioButton();
            rdbAnswerTypes = new System.Windows.Forms.RadioButton();
            btnOpen = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // rdbSchoolSubjects
            // 
            rdbSchoolSubjects.AutoSize = true;
            rdbSchoolSubjects.Location = new System.Drawing.Point(2, 3);
            rdbSchoolSubjects.Name = "rdbSchoolSubjects";
            rdbSchoolSubjects.Size = new System.Drawing.Size(75, 22);
            rdbSchoolSubjects.TabIndex = 0;
            rdbSchoolSubjects.TabStop = true;
            rdbSchoolSubjects.Text = "Materie";
            rdbSchoolSubjects.UseVisualStyleBackColor = true;
            rdbSchoolSubjects.CheckedChanged += rdb_CheckedChanged;
            // 
            // rdbTestTypes
            // 
            rdbTestTypes.AutoSize = true;
            rdbTestTypes.Location = new System.Drawing.Point(2, 220);
            rdbTestTypes.Name = "rdbTestTypes";
            rdbTestTypes.Size = new System.Drawing.Size(105, 22);
            rdbTestTypes.TabIndex = 1;
            rdbTestTypes.TabStop = true;
            rdbTestTypes.Text = "Tipi di prove";
            rdbTestTypes.UseVisualStyleBackColor = true;
            rdbTestTypes.CheckedChanged += rdb_CheckedChanged;
            // 
            // rdbGradeTypes
            // 
            rdbGradeTypes.AutoSize = true;
            rdbGradeTypes.Location = new System.Drawing.Point(2, 39);
            rdbGradeTypes.Name = "rdbGradeTypes";
            rdbGradeTypes.Size = new System.Drawing.Size(91, 22);
            rdbGradeTypes.TabIndex = 2;
            rdbGradeTypes.TabStop = true;
            rdbGradeTypes.Text = "Tipi di voti";
            rdbGradeTypes.UseVisualStyleBackColor = true;
            rdbGradeTypes.CheckedChanged += rdb_CheckedChanged;
            // 
            // rdbSchools
            // 
            rdbSchools.AutoSize = true;
            rdbSchools.Location = new System.Drawing.Point(2, 120);
            rdbSchools.Name = "rdbSchools";
            rdbSchools.Size = new System.Drawing.Size(72, 22);
            rdbSchools.TabIndex = 3;
            rdbSchools.TabStop = true;
            rdbSchools.Text = "Scuole";
            rdbSchools.UseVisualStyleBackColor = true;
            rdbSchools.CheckedChanged += rdb_CheckedChanged;
            // 
            // rdbQuestionTypes
            // 
            rdbQuestionTypes.AutoSize = true;
            rdbQuestionTypes.Location = new System.Drawing.Point(2, 256);
            rdbQuestionTypes.Name = "rdbQuestionTypes";
            rdbQuestionTypes.Size = new System.Drawing.Size(130, 22);
            rdbQuestionTypes.TabIndex = 4;
            rdbQuestionTypes.TabStop = true;
            rdbQuestionTypes.Text = "Tipi di domande";
            rdbQuestionTypes.UseVisualStyleBackColor = true;
            rdbQuestionTypes.CheckedChanged += rdb_CheckedChanged;
            // 
            // rdbGradeCategories
            // 
            rdbGradeCategories.AutoSize = true;
            rdbGradeCategories.Location = new System.Drawing.Point(2, 73);
            rdbGradeCategories.Name = "rdbGradeCategories";
            rdbGradeCategories.Size = new System.Drawing.Size(132, 22);
            rdbGradeCategories.TabIndex = 5;
            rdbGradeCategories.TabStop = true;
            rdbGradeCategories.Text = "Categorie di voti";
            rdbGradeCategories.UseVisualStyleBackColor = true;
            rdbGradeCategories.CheckedChanged += rdb_CheckedChanged;
            // 
            // rdbSchoolYears
            // 
            rdbSchoolYears.AutoSize = true;
            rdbSchoolYears.Location = new System.Drawing.Point(2, 159);
            rdbSchoolYears.Name = "rdbSchoolYears";
            rdbSchoolYears.Size = new System.Drawing.Size(120, 22);
            rdbSchoolYears.TabIndex = 7;
            rdbSchoolYears.TabStop = true;
            rdbSchoolYears.Text = "Anni scolastici";
            rdbSchoolYears.UseVisualStyleBackColor = true;
            rdbSchoolYears.CheckedChanged += rdb_CheckedChanged;
            // 
            // rdbAnswerTypes
            // 
            rdbAnswerTypes.AutoSize = true;
            rdbAnswerTypes.Enabled = false;
            rdbAnswerTypes.Location = new System.Drawing.Point(2, 290);
            rdbAnswerTypes.Name = "rdbAnswerTypes";
            rdbAnswerTypes.Size = new System.Drawing.Size(121, 22);
            rdbAnswerTypes.TabIndex = 8;
            rdbAnswerTypes.TabStop = true;
            rdbAnswerTypes.Text = "Tipi di risposte";
            rdbAnswerTypes.UseVisualStyleBackColor = true;
            rdbAnswerTypes.CheckedChanged += rdb_CheckedChanged;
            // 
            // btnOpen
            // 
            btnOpen.Location = new System.Drawing.Point(253, 140);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new System.Drawing.Size(75, 60);
            btnOpen.TabIndex = 9;
            btnOpen.Text = "Apri tabella";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // frmLookupTablesChoose
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(352, 348);
            Controls.Add(btnOpen);
            Controls.Add(rdbAnswerTypes);
            Controls.Add(rdbSchoolYears);
            Controls.Add(rdbGradeCategories);
            Controls.Add(rdbQuestionTypes);
            Controls.Add(rdbSchools);
            Controls.Add(rdbGradeTypes);
            Controls.Add(rdbTestTypes);
            Controls.Add(rdbSchoolSubjects);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            ForeColor = System.Drawing.Color.DarkBlue;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            Name = "frmTables";
            Text = "Tabelle";
            Load += frmTables_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbSchoolSubjects;
        private System.Windows.Forms.RadioButton rdbTestTypes;
        private System.Windows.Forms.RadioButton rdbGradeTypes;
        private System.Windows.Forms.RadioButton rdbSchools;
        private System.Windows.Forms.RadioButton rdbQuestionTypes;
        private System.Windows.Forms.RadioButton rdbGradeCategories;
        private System.Windows.Forms.RadioButton rdbSchoolYears;
        private System.Windows.Forms.RadioButton rdbAnswerTypes;
        private System.Windows.Forms.Button btnOpen;
    }
}