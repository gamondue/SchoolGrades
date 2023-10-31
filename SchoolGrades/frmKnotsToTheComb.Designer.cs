namespace SchoolGrades
{
    partial class frmKnotsToTheComb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKnotsToTheComb));
            txtQuestionText = new System.Windows.Forms.TextBox();
            lblStudent = new System.Windows.Forms.Label();
            dgwQuestions = new System.Windows.Forms.DataGridView();
            btnFix = new System.Windows.Forms.Button();
            btnChoose = new System.Windows.Forms.Button();
            lblSchoolSubject = new System.Windows.Forms.Label();
            cmbSchoolSubject = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgwQuestions).BeginInit();
            SuspendLayout();
            // 
            // txtQuestionText
            // 
            txtQuestionText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtQuestionText.Location = new System.Drawing.Point(12, 66);
            txtQuestionText.Margin = new System.Windows.Forms.Padding(4);
            txtQuestionText.Multiline = true;
            txtQuestionText.Name = "txtQuestionText";
            txtQuestionText.ReadOnly = true;
            txtQuestionText.Size = new System.Drawing.Size(910, 58);
            txtQuestionText.TabIndex = 116;
            txtQuestionText.TextChanged += txtQuestionText_TextChanged;
            // 
            // lblStudent
            // 
            lblStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblStudent.BackColor = System.Drawing.Color.Transparent;
            lblStudent.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStudent.ForeColor = System.Drawing.Color.DarkBlue;
            lblStudent.Location = new System.Drawing.Point(233, 9);
            lblStudent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new System.Drawing.Size(524, 53);
            lblStudent.TabIndex = 115;
            lblStudent.Text = "Allievo";
            lblStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgwQuestions
            // 
            dgwQuestions.AllowUserToAddRows = false;
            dgwQuestions.AllowUserToDeleteRows = false;
            dgwQuestions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwQuestions.Location = new System.Drawing.Point(12, 130);
            dgwQuestions.Name = "dgwQuestions";
            dgwQuestions.ReadOnly = true;
            dgwQuestions.Size = new System.Drawing.Size(910, 349);
            dgwQuestions.TabIndex = 117;
            dgwQuestions.CellClick += DgwQuestions_CellClick;
            dgwQuestions.CellContentClick += DgwQuestions_CellContentClick;
            dgwQuestions.CellDoubleClick += DgwQuestions_CellDoubleClick;
            dgwQuestions.RowEnter += DgwQuestions_RowEnter;
            // 
            // btnFix
            // 
            btnFix.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFix.Location = new System.Drawing.Point(766, 12);
            btnFix.Name = "btnFix";
            btnFix.Size = new System.Drawing.Size(75, 47);
            btnFix.TabIndex = 118;
            btnFix.Text = "Riparato";
            btnFix.UseVisualStyleBackColor = true;
            btnFix.Click += BtnFix_Click;
            // 
            // btnChoose
            // 
            btnChoose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnChoose.Location = new System.Drawing.Point(847, 12);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(75, 47);
            btnChoose.TabIndex = 119;
            btnChoose.Text = "Scegli";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click;
            // 
            // lblSchoolSubject
            // 
            lblSchoolSubject.AutoSize = true;
            lblSchoolSubject.Location = new System.Drawing.Point(9, 12);
            lblSchoolSubject.Name = "lblSchoolSubject";
            lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            lblSchoolSubject.TabIndex = 121;
            lblSchoolSubject.Text = "Materia";
            // 
            // cmbSchoolSubject
            // 
            cmbSchoolSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSchoolSubject.FormattingEnabled = true;
            cmbSchoolSubject.Location = new System.Drawing.Point(12, 33);
            cmbSchoolSubject.Name = "cmbSchoolSubject";
            cmbSchoolSubject.Size = new System.Drawing.Size(212, 26);
            cmbSchoolSubject.TabIndex = 120;
            cmbSchoolSubject.SelectedIndexChanged += cmbSchoolSubject_SelectedIndexChanged;
            // 
            // frmKnotsToTheComb
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(932, 490);
            Controls.Add(lblSchoolSubject);
            Controls.Add(cmbSchoolSubject);
            Controls.Add(btnChoose);
            Controls.Add(btnFix);
            Controls.Add(dgwQuestions);
            Controls.Add(txtQuestionText);
            Controls.Add(lblStudent);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmKnotsToTheComb";
            Text = "Nodi al pettine! ";
            Load += FrmKnotsToTheComb_Load;
            ((System.ComponentModel.ISupportInitialize)dgwQuestions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox txtQuestionText;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.DataGridView dgwQuestions;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Label lblSchoolSubject;
        private System.Windows.Forms.ComboBox cmbSchoolSubject;
    }
}