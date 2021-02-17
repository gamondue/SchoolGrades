namespace SchoolGrades
{
    partial class frmClassifica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassifica));
            this.btnFile = new System.Windows.Forms.Button();
            this.lstClassifica = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(190, 484);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(86, 24);
            this.btnFile.TabIndex = 28;
            this.btnFile.Text = "Genera file";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // lstClassifica
            // 
            this.lstClassifica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstClassifica.BackColor = System.Drawing.Color.PowderBlue;
            this.lstClassifica.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lstClassifica.ForeColor = System.Drawing.Color.DarkBlue;
            this.lstClassifica.FormattingEnabled = true;
            this.lstClassifica.ItemHeight = 16;
            this.lstClassifica.Location = new System.Drawing.Point(-3, 1);
            this.lstClassifica.Name = "lstClassifica";
            this.lstClassifica.Size = new System.Drawing.Size(281, 468);
            this.lstClassifica.TabIndex = 27;
            // 
            // frmClassifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(278, 512);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.lstClassifica);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 100);
            this.Name = "frmClassifica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Ordinati";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.ListBox lstClassifica;
    }
}