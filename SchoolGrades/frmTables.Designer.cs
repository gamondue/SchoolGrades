namespace SchoolGrades
{
    partial class frmTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTables));
            this.rdbSchoolSubjects = new System.Windows.Forms.RadioButton();
            this.rdbTestTypes = new System.Windows.Forms.RadioButton();
            this.rdbGradeTypes = new System.Windows.Forms.RadioButton();
            this.rdbSchools = new System.Windows.Forms.RadioButton();
            this.rdbQuestionTypes = new System.Windows.Forms.RadioButton();
            this.rdbGradeCategories = new System.Windows.Forms.RadioButton();
            this.rdbSchoolYears = new System.Windows.Forms.RadioButton();
            this.rdbAnswerTypes = new System.Windows.Forms.RadioButton();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbSchoolSubjects
            // 
            this.rdbSchoolSubjects.AutoSize = true;
            this.rdbSchoolSubjects.Location = new System.Drawing.Point(2, 3);
            this.rdbSchoolSubjects.Name = "rdbSchoolSubjects";
            this.rdbSchoolSubjects.Size = new System.Drawing.Size(75, 22);
            this.rdbSchoolSubjects.TabIndex = 0;
            this.rdbSchoolSubjects.TabStop = true;
            this.rdbSchoolSubjects.Text = "Materie";
            this.rdbSchoolSubjects.UseVisualStyleBackColor = true;
            this.rdbSchoolSubjects.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbTestTypes
            // 
            this.rdbTestTypes.AutoSize = true;
            this.rdbTestTypes.Location = new System.Drawing.Point(2, 37);
            this.rdbTestTypes.Name = "rdbTestTypes";
            this.rdbTestTypes.Size = new System.Drawing.Size(105, 22);
            this.rdbTestTypes.TabIndex = 1;
            this.rdbTestTypes.TabStop = true;
            this.rdbTestTypes.Text = "Tipi di prove";
            this.rdbTestTypes.UseVisualStyleBackColor = true;
            this.rdbTestTypes.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbGradeTypes
            // 
            this.rdbGradeTypes.AutoSize = true;
            this.rdbGradeTypes.Location = new System.Drawing.Point(2, 157);
            this.rdbGradeTypes.Name = "rdbGradeTypes";
            this.rdbGradeTypes.Size = new System.Drawing.Size(91, 22);
            this.rdbGradeTypes.TabIndex = 2;
            this.rdbGradeTypes.TabStop = true;
            this.rdbGradeTypes.Text = "Tipi di voti";
            this.rdbGradeTypes.UseVisualStyleBackColor = true;
            this.rdbGradeTypes.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbSchools
            // 
            this.rdbSchools.AutoSize = true;
            this.rdbSchools.Location = new System.Drawing.Point(2, 238);
            this.rdbSchools.Name = "rdbSchools";
            this.rdbSchools.Size = new System.Drawing.Size(72, 22);
            this.rdbSchools.TabIndex = 3;
            this.rdbSchools.TabStop = true;
            this.rdbSchools.Text = "Scuole";
            this.rdbSchools.UseVisualStyleBackColor = true;
            this.rdbSchools.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbQuestionTypes
            // 
            this.rdbQuestionTypes.AutoSize = true;
            this.rdbQuestionTypes.Location = new System.Drawing.Point(2, 71);
            this.rdbQuestionTypes.Name = "rdbQuestionTypes";
            this.rdbQuestionTypes.Size = new System.Drawing.Size(130, 22);
            this.rdbQuestionTypes.TabIndex = 4;
            this.rdbQuestionTypes.TabStop = true;
            this.rdbQuestionTypes.Text = "Tipi di domande";
            this.rdbQuestionTypes.UseVisualStyleBackColor = true;
            this.rdbQuestionTypes.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbGradeCategories
            // 
            this.rdbGradeCategories.AutoSize = true;
            this.rdbGradeCategories.Location = new System.Drawing.Point(2, 191);
            this.rdbGradeCategories.Name = "rdbGradeCategories";
            this.rdbGradeCategories.Size = new System.Drawing.Size(132, 22);
            this.rdbGradeCategories.TabIndex = 5;
            this.rdbGradeCategories.TabStop = true;
            this.rdbGradeCategories.Text = "Categorie di voti";
            this.rdbGradeCategories.UseVisualStyleBackColor = true;
            this.rdbGradeCategories.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbSchoolYears
            // 
            this.rdbSchoolYears.AutoSize = true;
            this.rdbSchoolYears.Location = new System.Drawing.Point(2, 277);
            this.rdbSchoolYears.Name = "rdbSchoolYears";
            this.rdbSchoolYears.Size = new System.Drawing.Size(120, 22);
            this.rdbSchoolYears.TabIndex = 7;
            this.rdbSchoolYears.TabStop = true;
            this.rdbSchoolYears.Text = "Anni scolastici";
            this.rdbSchoolYears.UseVisualStyleBackColor = true;
            this.rdbSchoolYears.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbAnswerTypes
            // 
            this.rdbAnswerTypes.AutoSize = true;
            this.rdbAnswerTypes.Enabled = false;
            this.rdbAnswerTypes.Location = new System.Drawing.Point(2, 105);
            this.rdbAnswerTypes.Name = "rdbAnswerTypes";
            this.rdbAnswerTypes.Size = new System.Drawing.Size(121, 22);
            this.rdbAnswerTypes.TabIndex = 8;
            this.rdbAnswerTypes.TabStop = true;
            this.rdbAnswerTypes.Text = "Tipi di risposte";
            this.rdbAnswerTypes.UseVisualStyleBackColor = true;
            this.rdbAnswerTypes.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(242, 138);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 60);
            this.btnOpen.TabIndex = 9;
            this.btnOpen.Text = "Apri tabella";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // frmTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(352, 348);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.rdbAnswerTypes);
            this.Controls.Add(this.rdbSchoolYears);
            this.Controls.Add(this.rdbGradeCategories);
            this.Controls.Add(this.rdbQuestionTypes);
            this.Controls.Add(this.rdbSchools);
            this.Controls.Add(this.rdbGradeTypes);
            this.Controls.Add(this.rdbTestTypes);
            this.Controls.Add(this.rdbSchoolSubjects);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmTables";
            this.Text = "Tabelle";
            this.Load += new System.EventHandler(this.frmTables_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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