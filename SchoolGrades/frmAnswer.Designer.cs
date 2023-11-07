namespace SchoolGrades
{
    partial class frmAnswer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnswer));
            txtIdAnswer = new System.Windows.Forms.TextBox();
            lblIdAnswer = new System.Windows.Forms.Label();
            lblIdQuesion = new System.Windows.Forms.Label();
            txtIdQuestion = new System.Windows.Forms.TextBox();
            lblText = new System.Windows.Forms.Label();
            txtText = new System.Windows.Forms.TextBox();
            lblErrorCost = new System.Windows.Forms.Label();
            txtErrorCost = new System.Windows.Forms.TextBox();
            grpIsOpenAnswer = new System.Windows.Forms.GroupBox();
            rdbIsClosedAnswer = new System.Windows.Forms.RadioButton();
            rdbIsOpenAnswer = new System.Windows.Forms.RadioButton();
            grpIsCorrect = new System.Windows.Forms.GroupBox();
            rdbIsNotCorrect = new System.Windows.Forms.RadioButton();
            rdbIsCorrect = new System.Windows.Forms.RadioButton();
            btnChoose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnNew = new System.Windows.Forms.Button();
            grpIsOpenAnswer.SuspendLayout();
            grpIsCorrect.SuspendLayout();
            SuspendLayout();
            // 
            // txtIdAnswer
            // 
            txtIdAnswer.Location = new System.Drawing.Point(6, 41);
            txtIdAnswer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txtIdAnswer.Name = "txtIdAnswer";
            txtIdAnswer.ReadOnly = true;
            txtIdAnswer.Size = new System.Drawing.Size(84, 24);
            txtIdAnswer.TabIndex = 5;
            txtIdAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIdAnswer
            // 
            lblIdAnswer.AutoSize = true;
            lblIdAnswer.Location = new System.Drawing.Point(6, 14);
            lblIdAnswer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblIdAnswer.Name = "lblIdAnswer";
            lblIdAnswer.Size = new System.Drawing.Size(55, 18);
            lblIdAnswer.TabIndex = 6;
            lblIdAnswer.Text = "Codice";
            // 
            // lblIdQuesion
            // 
            lblIdQuesion.AutoSize = true;
            lblIdQuesion.Location = new System.Drawing.Point(100, 17);
            lblIdQuesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblIdQuesion.Name = "lblIdQuesion";
            lblIdQuesion.Size = new System.Drawing.Size(73, 18);
            lblIdQuesion.TabIndex = 8;
            lblIdQuesion.Text = "Domanda";
            // 
            // txtIdQuestion
            // 
            txtIdQuestion.Location = new System.Drawing.Point(104, 41);
            txtIdQuestion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txtIdQuestion.Name = "txtIdQuestion";
            txtIdQuestion.ReadOnly = true;
            txtIdQuestion.Size = new System.Drawing.Size(84, 24);
            txtIdQuestion.TabIndex = 7;
            txtIdQuestion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Location = new System.Drawing.Point(2, 75);
            lblText.Name = "lblText";
            lblText.Size = new System.Drawing.Size(252, 18);
            lblText.TabIndex = 10;
            lblText.Text = "Testo della risposta (visibile o esatto)";
            // 
            // txtText
            // 
            txtText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtText.Location = new System.Drawing.Point(2, 100);
            txtText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtText.Multiline = true;
            txtText.Name = "txtText";
            txtText.Size = new System.Drawing.Size(844, 200);
            txtText.TabIndex = 0;
            txtText.TextChanged += txtText_TextChanged;
            // 
            // lblErrorCost
            // 
            lblErrorCost.AutoSize = true;
            lblErrorCost.Location = new System.Drawing.Point(205, 17);
            lblErrorCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblErrorCost.Name = "lblErrorCost";
            lblErrorCost.Size = new System.Drawing.Size(93, 18);
            lblErrorCost.TabIndex = 12;
            lblErrorCost.Text = "Costo errore";
            // 
            // txtErrorCost
            // 
            txtErrorCost.Location = new System.Drawing.Point(205, 41);
            txtErrorCost.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txtErrorCost.Name = "txtErrorCost";
            txtErrorCost.Size = new System.Drawing.Size(84, 24);
            txtErrorCost.TabIndex = 11;
            txtErrorCost.TextChanged += txtErrorCost_TextChanged;
            // 
            // grpIsOpenAnswer
            // 
            grpIsOpenAnswer.Controls.Add(rdbIsClosedAnswer);
            grpIsOpenAnswer.Controls.Add(rdbIsOpenAnswer);
            grpIsOpenAnswer.Location = new System.Drawing.Point(323, 6);
            grpIsOpenAnswer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            grpIsOpenAnswer.Name = "grpIsOpenAnswer";
            grpIsOpenAnswer.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            grpIsOpenAnswer.Size = new System.Drawing.Size(134, 88);
            grpIsOpenAnswer.TabIndex = 13;
            grpIsOpenAnswer.TabStop = false;
            grpIsOpenAnswer.Text = "Tipo risposta";
            // 
            // rdbIsClosedAnswer
            // 
            rdbIsClosedAnswer.AutoSize = true;
            rdbIsClosedAnswer.Location = new System.Drawing.Point(6, 57);
            rdbIsClosedAnswer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            rdbIsClosedAnswer.Name = "rdbIsClosedAnswer";
            rdbIsClosedAnswer.Size = new System.Drawing.Size(72, 22);
            rdbIsClosedAnswer.TabIndex = 1;
            rdbIsClosedAnswer.TabStop = true;
            rdbIsClosedAnswer.Text = "Chiusa";
            rdbIsClosedAnswer.UseVisualStyleBackColor = true;
            // 
            // rdbIsOpenAnswer
            // 
            rdbIsOpenAnswer.AutoSize = true;
            rdbIsOpenAnswer.Location = new System.Drawing.Point(6, 26);
            rdbIsOpenAnswer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            rdbIsOpenAnswer.Name = "rdbIsOpenAnswer";
            rdbIsOpenAnswer.Size = new System.Drawing.Size(68, 22);
            rdbIsOpenAnswer.TabIndex = 0;
            rdbIsOpenAnswer.TabStop = true;
            rdbIsOpenAnswer.Text = "Aperta";
            rdbIsOpenAnswer.UseVisualStyleBackColor = true;
            rdbIsOpenAnswer.CheckedChanged += rdbIsOpenAnswer_CheckedChanged;
            // 
            // grpIsCorrect
            // 
            grpIsCorrect.Controls.Add(rdbIsNotCorrect);
            grpIsCorrect.Controls.Add(rdbIsCorrect);
            grpIsCorrect.Location = new System.Drawing.Point(455, 5);
            grpIsCorrect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            grpIsCorrect.Name = "grpIsCorrect";
            grpIsCorrect.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            grpIsCorrect.Size = new System.Drawing.Size(152, 88);
            grpIsCorrect.TabIndex = 14;
            grpIsCorrect.TabStop = false;
            grpIsCorrect.Text = "Risposta esatta";
            // 
            // rdbIsNotCorrect
            // 
            rdbIsNotCorrect.AutoSize = true;
            rdbIsNotCorrect.Location = new System.Drawing.Point(6, 57);
            rdbIsNotCorrect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            rdbIsNotCorrect.Name = "rdbIsNotCorrect";
            rdbIsNotCorrect.Size = new System.Drawing.Size(62, 22);
            rdbIsNotCorrect.TabIndex = 1;
            rdbIsNotCorrect.TabStop = true;
            rdbIsNotCorrect.Text = "False";
            rdbIsNotCorrect.UseVisualStyleBackColor = true;
            // 
            // rdbIsCorrect
            // 
            rdbIsCorrect.AutoSize = true;
            rdbIsCorrect.Location = new System.Drawing.Point(6, 26);
            rdbIsCorrect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            rdbIsCorrect.Name = "rdbIsCorrect";
            rdbIsCorrect.Size = new System.Drawing.Size(57, 22);
            rdbIsCorrect.TabIndex = 0;
            rdbIsCorrect.TabStop = true;
            rdbIsCorrect.Text = "Vero";
            rdbIsCorrect.UseVisualStyleBackColor = true;
            rdbIsCorrect.CheckedChanged += rdbIsCorrect_CheckedChanged;
            // 
            // btnChoose
            // 
            btnChoose.ForeColor = System.Drawing.Color.DarkBlue;
            btnChoose.Location = new System.Drawing.Point(612, 54);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(75, 39);
            btnChoose.TabIndex = 17;
            btnChoose.Text = "Scegli";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click;
            // 
            // btnSave
            // 
            btnSave.ForeColor = System.Drawing.Color.DarkBlue;
            btnSave.Location = new System.Drawing.Point(612, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 39);
            btnSave.TabIndex = 16;
            btnSave.Text = "Salva";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnNew
            // 
            btnNew.ForeColor = System.Drawing.Color.DarkBlue;
            btnNew.Location = new System.Drawing.Point(756, 52);
            btnNew.Name = "btnNew";
            btnNew.Size = new System.Drawing.Size(75, 39);
            btnNew.TabIndex = 15;
            btnNew.Text = "Nuovo";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // frmAnswer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(842, 303);
            Controls.Add(btnChoose);
            Controls.Add(btnSave);
            Controls.Add(btnNew);
            Controls.Add(lblIdAnswer);
            Controls.Add(txtIdAnswer);
            Controls.Add(grpIsCorrect);
            Controls.Add(grpIsOpenAnswer);
            Controls.Add(lblErrorCost);
            Controls.Add(txtErrorCost);
            Controls.Add(lblText);
            Controls.Add(txtText);
            Controls.Add(lblIdQuesion);
            Controls.Add(txtIdQuestion);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "frmAnswer";
            Text = "Risposta";
            FormClosing += frmAnswer_FormClosing;
            Load += frmAnswer_Load;
            grpIsOpenAnswer.ResumeLayout(false);
            grpIsOpenAnswer.PerformLayout();
            grpIsCorrect.ResumeLayout(false);
            grpIsCorrect.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox txtIdAnswer;
        private System.Windows.Forms.Label lblIdAnswer;
        private System.Windows.Forms.Label lblIdQuesion;
        private System.Windows.Forms.TextBox txtIdQuestion;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label lblErrorCost;
        private System.Windows.Forms.TextBox txtErrorCost;
        private System.Windows.Forms.GroupBox grpIsOpenAnswer;
        private System.Windows.Forms.RadioButton rdbIsClosedAnswer;
        private System.Windows.Forms.RadioButton rdbIsOpenAnswer;
        private System.Windows.Forms.GroupBox grpIsCorrect;
        private System.Windows.Forms.RadioButton rdbIsNotCorrect;
        private System.Windows.Forms.RadioButton rdbIsCorrect;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
    }
}