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
            this.txtQuestionText = new System.Windows.Forms.TextBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.dgwQuestions = new System.Windows.Forms.DataGridView();
            this.btnFix = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.lblSchoolSubject = new System.Windows.Forms.Label();
            this.cmbSchoolSubject = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuestionText
            // 
            this.txtQuestionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuestionText.Location = new System.Drawing.Point(12, 66);
            this.txtQuestionText.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuestionText.Multiline = true;
            this.txtQuestionText.Name = "txtQuestionText";
            this.txtQuestionText.ReadOnly = true;
            this.txtQuestionText.Size = new System.Drawing.Size(910, 58);
            this.txtQuestionText.TabIndex = 116;
            // 
            // lblStudent
            // 
            this.lblStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStudent.BackColor = System.Drawing.Color.Transparent;
            this.lblStudent.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStudent.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStudent.Location = new System.Drawing.Point(233, 9);
            this.lblStudent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(524, 53);
            this.lblStudent.TabIndex = 115;
            this.lblStudent.Text = "Allievo";
            this.lblStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgwQuestions
            // 
            this.dgwQuestions.AllowUserToAddRows = false;
            this.dgwQuestions.AllowUserToDeleteRows = false;
            this.dgwQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwQuestions.Location = new System.Drawing.Point(12, 130);
            this.dgwQuestions.Name = "dgwQuestions";
            this.dgwQuestions.ReadOnly = true;
            this.dgwQuestions.Size = new System.Drawing.Size(910, 349);
            this.dgwQuestions.TabIndex = 117;
            this.dgwQuestions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwQuestions_CellClick);
            this.dgwQuestions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwQuestions_CellContentClick);
            this.dgwQuestions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwQuestions_CellDoubleClick);
            this.dgwQuestions.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwQuestions_RowEnter);
            // 
            // btnFix
            // 
            this.btnFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFix.Location = new System.Drawing.Point(766, 12);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(75, 47);
            this.btnFix.TabIndex = 118;
            this.btnFix.Text = "Riparato";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.BtnFix_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoose.Location = new System.Drawing.Point(847, 12);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 47);
            this.btnChoose.TabIndex = 119;
            this.btnChoose.Text = "Scegli";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // lblSchoolSubject
            // 
            this.lblSchoolSubject.AutoSize = true;
            this.lblSchoolSubject.Location = new System.Drawing.Point(9, 12);
            this.lblSchoolSubject.Name = "lblSchoolSubject";
            this.lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            this.lblSchoolSubject.TabIndex = 121;
            this.lblSchoolSubject.Text = "Materia";
            // 
            // cmbSchoolSubject
            // 
            this.cmbSchoolSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchoolSubject.FormattingEnabled = true;
            this.cmbSchoolSubject.Location = new System.Drawing.Point(12, 33);
            this.cmbSchoolSubject.Name = "cmbSchoolSubject";
            this.cmbSchoolSubject.Size = new System.Drawing.Size(212, 26);
            this.cmbSchoolSubject.TabIndex = 120;
            this.cmbSchoolSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolSubject_SelectedIndexChanged);
            // 
            // frmKnotsToTheComb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(932, 490);
            this.Controls.Add(this.lblSchoolSubject);
            this.Controls.Add(this.cmbSchoolSubject);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnFix);
            this.Controls.Add(this.dgwQuestions);
            this.Controls.Add(this.txtQuestionText);
            this.Controls.Add(this.lblStudent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKnotsToTheComb";
            this.Text = "Nodi al pettine! ";
            this.Load += new System.EventHandler(this.FrmKnotsToTheComb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwQuestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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