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
            this.txtIdAnswer = new System.Windows.Forms.TextBox();
            this.lblIdAnswer = new System.Windows.Forms.Label();
            this.lblIdQuesion = new System.Windows.Forms.Label();
            this.txtIdQuestion = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblErrorCost = new System.Windows.Forms.Label();
            this.txtErrorCost = new System.Windows.Forms.TextBox();
            this.grpIsOpenAnswer = new System.Windows.Forms.GroupBox();
            this.rdbIsClosedAnswer = new System.Windows.Forms.RadioButton();
            this.rdbIsOpenAnswer = new System.Windows.Forms.RadioButton();
            this.grpIsCorrect = new System.Windows.Forms.GroupBox();
            this.rdbIsNotCorrect = new System.Windows.Forms.RadioButton();
            this.rdbIsCorrect = new System.Windows.Forms.RadioButton();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.grpIsOpenAnswer.SuspendLayout();
            this.grpIsCorrect.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIdAnswer
            // 
            this.txtIdAnswer.Location = new System.Drawing.Point(6, 41);
            this.txtIdAnswer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtIdAnswer.Name = "txtIdAnswer";
            this.txtIdAnswer.ReadOnly = true;
            this.txtIdAnswer.Size = new System.Drawing.Size(84, 28);
            this.txtIdAnswer.TabIndex = 5;
            this.txtIdAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIdAnswer
            // 
            this.lblIdAnswer.AutoSize = true;
            this.lblIdAnswer.Location = new System.Drawing.Point(6, 14);
            this.lblIdAnswer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdAnswer.Name = "lblIdAnswer";
            this.lblIdAnswer.Size = new System.Drawing.Size(70, 24);
            this.lblIdAnswer.TabIndex = 6;
            this.lblIdAnswer.Text = "Codice";
            // 
            // lblIdQuesion
            // 
            this.lblIdQuesion.AutoSize = true;
            this.lblIdQuesion.Location = new System.Drawing.Point(100, 17);
            this.lblIdQuesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdQuesion.Name = "lblIdQuesion";
            this.lblIdQuesion.Size = new System.Drawing.Size(92, 24);
            this.lblIdQuesion.TabIndex = 8;
            this.lblIdQuesion.Text = "Domanda";
            // 
            // txtIdQuestion
            // 
            this.txtIdQuestion.Location = new System.Drawing.Point(104, 41);
            this.txtIdQuestion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtIdQuestion.Name = "txtIdQuestion";
            this.txtIdQuestion.ReadOnly = true;
            this.txtIdQuestion.Size = new System.Drawing.Size(84, 28);
            this.txtIdQuestion.TabIndex = 7;
            this.txtIdQuestion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(2, 75);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(314, 24);
            this.lblText.TabIndex = 10;
            this.lblText.Text = "Testo della risposta (visibile o esatto)";
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Location = new System.Drawing.Point(2, 100);
            this.txtText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(844, 200);
            this.txtText.TabIndex = 0;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // lblErrorCost
            // 
            this.lblErrorCost.AutoSize = true;
            this.lblErrorCost.Location = new System.Drawing.Point(205, 17);
            this.lblErrorCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorCost.Name = "lblErrorCost";
            this.lblErrorCost.Size = new System.Drawing.Size(114, 24);
            this.lblErrorCost.TabIndex = 12;
            this.lblErrorCost.Text = "Costo errore";
            // 
            // txtErrorCost
            // 
            this.txtErrorCost.Location = new System.Drawing.Point(205, 41);
            this.txtErrorCost.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtErrorCost.Name = "txtErrorCost";
            this.txtErrorCost.Size = new System.Drawing.Size(84, 28);
            this.txtErrorCost.TabIndex = 11;
            this.txtErrorCost.TextChanged += new System.EventHandler(this.txtErrorCost_TextChanged);
            // 
            // grpIsOpenAnswer
            // 
            this.grpIsOpenAnswer.Controls.Add(this.rdbIsClosedAnswer);
            this.grpIsOpenAnswer.Controls.Add(this.rdbIsOpenAnswer);
            this.grpIsOpenAnswer.Location = new System.Drawing.Point(323, 6);
            this.grpIsOpenAnswer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grpIsOpenAnswer.Name = "grpIsOpenAnswer";
            this.grpIsOpenAnswer.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grpIsOpenAnswer.Size = new System.Drawing.Size(134, 88);
            this.grpIsOpenAnswer.TabIndex = 13;
            this.grpIsOpenAnswer.TabStop = false;
            this.grpIsOpenAnswer.Text = "Tipo risposta";
            // 
            // rdbIsClosedAnswer
            // 
            this.rdbIsClosedAnswer.AutoSize = true;
            this.rdbIsClosedAnswer.Location = new System.Drawing.Point(6, 57);
            this.rdbIsClosedAnswer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdbIsClosedAnswer.Name = "rdbIsClosedAnswer";
            this.rdbIsClosedAnswer.Size = new System.Drawing.Size(89, 28);
            this.rdbIsClosedAnswer.TabIndex = 1;
            this.rdbIsClosedAnswer.TabStop = true;
            this.rdbIsClosedAnswer.Text = "Chiusa";
            this.rdbIsClosedAnswer.UseVisualStyleBackColor = true;
            // 
            // rdbIsOpenAnswer
            // 
            this.rdbIsOpenAnswer.AutoSize = true;
            this.rdbIsOpenAnswer.Location = new System.Drawing.Point(6, 26);
            this.rdbIsOpenAnswer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdbIsOpenAnswer.Name = "rdbIsOpenAnswer";
            this.rdbIsOpenAnswer.Size = new System.Drawing.Size(86, 28);
            this.rdbIsOpenAnswer.TabIndex = 0;
            this.rdbIsOpenAnswer.TabStop = true;
            this.rdbIsOpenAnswer.Text = "Aperta";
            this.rdbIsOpenAnswer.UseVisualStyleBackColor = true;
            this.rdbIsOpenAnswer.CheckedChanged += new System.EventHandler(this.rdbIsOpenAnswer_CheckedChanged);
            // 
            // grpIsCorrect
            // 
            this.grpIsCorrect.Controls.Add(this.rdbIsNotCorrect);
            this.grpIsCorrect.Controls.Add(this.rdbIsCorrect);
            this.grpIsCorrect.Location = new System.Drawing.Point(455, 5);
            this.grpIsCorrect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grpIsCorrect.Name = "grpIsCorrect";
            this.grpIsCorrect.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grpIsCorrect.Size = new System.Drawing.Size(152, 88);
            this.grpIsCorrect.TabIndex = 14;
            this.grpIsCorrect.TabStop = false;
            this.grpIsCorrect.Text = "Risposta esatta";
            // 
            // rdbIsNotCorrect
            // 
            this.rdbIsNotCorrect.AutoSize = true;
            this.rdbIsNotCorrect.Location = new System.Drawing.Point(6, 57);
            this.rdbIsNotCorrect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdbIsNotCorrect.Name = "rdbIsNotCorrect";
            this.rdbIsNotCorrect.Size = new System.Drawing.Size(77, 28);
            this.rdbIsNotCorrect.TabIndex = 1;
            this.rdbIsNotCorrect.TabStop = true;
            this.rdbIsNotCorrect.Text = "False";
            this.rdbIsNotCorrect.UseVisualStyleBackColor = true;
            // 
            // rdbIsCorrect
            // 
            this.rdbIsCorrect.AutoSize = true;
            this.rdbIsCorrect.Location = new System.Drawing.Point(6, 26);
            this.rdbIsCorrect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdbIsCorrect.Name = "rdbIsCorrect";
            this.rdbIsCorrect.Size = new System.Drawing.Size(72, 28);
            this.rdbIsCorrect.TabIndex = 0;
            this.rdbIsCorrect.TabStop = true;
            this.rdbIsCorrect.Text = "Vero";
            this.rdbIsCorrect.UseVisualStyleBackColor = true;
            this.rdbIsCorrect.CheckedChanged += new System.EventHandler(this.rdbIsCorrect_CheckedChanged);
            // 
            // btnChoose
            // 
            this.btnChoose.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnChoose.Location = new System.Drawing.Point(612, 54);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 39);
            this.btnChoose.TabIndex = 17;
            this.btnChoose.Text = "Scegli";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSave.Location = new System.Drawing.Point(612, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnNew.Location = new System.Drawing.Point(756, 52);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 39);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "Nuovo";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // frmAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(842, 303);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblIdAnswer);
            this.Controls.Add(this.txtIdAnswer);
            this.Controls.Add(this.grpIsCorrect);
            this.Controls.Add(this.grpIsOpenAnswer);
            this.Controls.Add(this.lblErrorCost);
            this.Controls.Add(this.txtErrorCost);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.lblIdQuesion);
            this.Controls.Add(this.txtIdQuestion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAnswer";
            this.Text = "Risposta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAnswer_FormClosing);
            this.Load += new System.EventHandler(this.frmAnswer_Load);
            this.grpIsOpenAnswer.ResumeLayout(false);
            this.grpIsOpenAnswer.PerformLayout();
            this.grpIsCorrect.ResumeLayout(false);
            this.grpIsCorrect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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