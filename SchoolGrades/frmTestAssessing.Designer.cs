namespace SchoolGrades
{
    partial class frmTestAssessing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestAssessing));
            this.txtIdTest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIdClass = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgwQuestions = new System.Windows.Forms.DataGridView();
            this.dgwClassStudents = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpStudentsAnswers = new System.Windows.Forms.GroupBox();
            this.txtStudent = new System.Windows.Forms.TextBox();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.btnSaveStudentsAnswers = new System.Windows.Forms.Button();
            this.btnGradeAllTest = new System.Windows.Forms.Button();
            this.dgwAnswers = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgwQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwClassStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAnswers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIdTest
            // 
            this.txtIdTest.Location = new System.Drawing.Point(12, 26);
            this.txtIdTest.Name = "txtIdTest";
            this.txtIdTest.Size = new System.Drawing.Size(100, 24);
            this.txtIdTest.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codice Test";
            // 
            // lblIdClass
            // 
            this.lblIdClass.AutoSize = true;
            this.lblIdClass.Location = new System.Drawing.Point(124, 8);
            this.lblIdClass.Name = "lblIdClass";
            this.lblIdClass.Size = new System.Drawing.Size(105, 18);
            this.lblIdClass.TabIndex = 3;
            this.lblIdClass.Text = "Codice Classe";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 24);
            this.textBox1.TabIndex = 2;
            // 
            // dgwQuestions
            // 
            this.dgwQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwQuestions.Location = new System.Drawing.Point(3, 3);
            this.dgwQuestions.Name = "dgwQuestions";
            this.dgwQuestions.RowTemplate.Height = 24;
            this.dgwQuestions.Size = new System.Drawing.Size(520, 316);
            this.dgwQuestions.TabIndex = 4;
            this.dgwQuestions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwQuestions_CellClick);
            this.dgwQuestions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwQuestions_CellContentClick);
            this.dgwQuestions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwQuestions_CellDoubleClick);
            // 
            // dgwClassStudents
            // 
            this.dgwClassStudents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwClassStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwClassStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwClassStudents.Location = new System.Drawing.Point(0, 354);
            this.dgwClassStudents.Name = "dgwClassStudents";
            this.dgwClassStudents.RowTemplate.Height = 24;
            this.dgwClassStudents.Size = new System.Drawing.Size(523, 321);
            this.dgwClassStudents.TabIndex = 5;
            this.dgwClassStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwClassStudents_CellClick);
            this.dgwClassStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwClassStudents_CellContentClick);
            this.dgwClassStudents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwClassStudents_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Domande";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Allievi della classe";
            // 
            // grpStudentsAnswers
            // 
            this.grpStudentsAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStudentsAnswers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpStudentsAnswers.Location = new System.Drawing.Point(3, 351);
            this.grpStudentsAnswers.Name = "grpStudentsAnswers";
            this.grpStudentsAnswers.Size = new System.Drawing.Size(358, 321);
            this.grpStudentsAnswers.TabIndex = 9;
            this.grpStudentsAnswers.TabStop = false;
            this.grpStudentsAnswers.Text = "Risposte allievo";
            // 
            // txtStudent
            // 
            this.txtStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStudent.Location = new System.Drawing.Point(128, 324);
            this.txtStudent.Name = "txtStudent";
            this.txtStudent.Size = new System.Drawing.Size(315, 24);
            this.txtStudent.TabIndex = 10;
            // 
            // txtQuestion
            // 
            this.txtQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuestion.Location = new System.Drawing.Point(91, 56);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(462, 38);
            this.txtQuestion.TabIndex = 11;
            // 
            // btnSaveStudentsAnswers
            // 
            this.btnSaveStudentsAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveStudentsAnswers.Location = new System.Drawing.Point(449, 322);
            this.btnSaveStudentsAnswers.Name = "btnSaveStudentsAnswers";
            this.btnSaveStudentsAnswers.Size = new System.Drawing.Size(74, 26);
            this.btnSaveStudentsAnswers.TabIndex = 12;
            this.btnSaveStudentsAnswers.Text = "Salva";
            this.btnSaveStudentsAnswers.UseVisualStyleBackColor = true;
            this.btnSaveStudentsAnswers.Click += new System.EventHandler(this.btnSaveStudentsAnswers_Click);
            // 
            // btnGradeAllTest
            // 
            this.btnGradeAllTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGradeAllTest.Location = new System.Drawing.Point(812, 8);
            this.btnGradeAllTest.Name = "btnGradeAllTest";
            this.btnGradeAllTest.Size = new System.Drawing.Size(76, 53);
            this.btnGradeAllTest.TabIndex = 13;
            this.btnGradeAllTest.Text = "Valuta test";
            this.btnGradeAllTest.UseVisualStyleBackColor = true;
            this.btnGradeAllTest.Click += new System.EventHandler(this.btnGradeAllTest_Click);
            // 
            // dgwAnswers
            // 
            this.dgwAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwAnswers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAnswers.Location = new System.Drawing.Point(3, 0);
            this.dgwAnswers.Name = "dgwAnswers";
            this.dgwAnswers.RowTemplate.Height = 24;
            this.dgwAnswers.Size = new System.Drawing.Size(358, 339);
            this.dgwAnswers.TabIndex = 14;
            this.dgwAnswers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwAnswers_CellClick);
            this.dgwAnswers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwAnswers_CellContentClick);
            this.dgwAnswers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwAnswers_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(559, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Risposte";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 787);
            this.splitter1.TabIndex = 16;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 100);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgwQuestions);
            this.splitContainer1.Panel1.Controls.Add(this.dgwClassStudents);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtStudent);
            this.splitContainer1.Panel1.Controls.Add(this.btnSaveStudentsAnswers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgwAnswers);
            this.splitContainer1.Panel2.Controls.Add(this.grpStudentsAnswers);
            this.splitContainer1.Size = new System.Drawing.Size(894, 675);
            this.splitContainer1.SplitterDistance = 526;
            this.splitContainer1.TabIndex = 17;
            // 
            // frmTestAssessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(900, 787);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGradeAllTest);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIdClass);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdTest);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTestAssessing";
            this.Text = "Correzione Test";
            this.Load += new System.EventHandler(this.frmTestGrades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwClassStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAnswers)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIdClass;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgwQuestions;
        private System.Windows.Forms.DataGridView dgwClassStudents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpStudentsAnswers;
        private System.Windows.Forms.TextBox txtStudent;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Button btnSaveStudentsAnswers;
        private System.Windows.Forms.Button btnGradeAllTest;
        private System.Windows.Forms.DataGridView dgwAnswers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}