namespace SchoolGrades
{
    partial class frmInputBox
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
            label = new System.Windows.Forms.Label();
            textBox = new System.Windows.Forms.TextBox();
            buttonOk = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(12, 59);
            label.Name = "label";
            label.Size = new System.Drawing.Size(32, 15);
            label.TabIndex = 0;
            label.Text = "label";
            // 
            // textBox
            // 
            textBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox.Location = new System.Drawing.Point(164, 13);
            textBox.Name = "textBox";
            textBox.Size = new System.Drawing.Size(37, 33);
            textBox.TabIndex = 1;
            textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonOk
            // 
            buttonOk.Location = new System.Drawing.Point(207, 12);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(75, 34);
            buttonOk.TabIndex = 2;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new System.Drawing.Point(288, 12);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(75, 34);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // frmInputBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(518, 245);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(textBox);
            Controls.Add(label);
            Name = "frmInputBox";
            Text = "InputBox";
            Load += frmInputBox_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}