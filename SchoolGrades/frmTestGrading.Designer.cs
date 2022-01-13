namespace SchoolGrades
{
    partial class frmTestGrading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestGrading));
            this.lblIdClass = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdTest = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCnc = new System.Windows.Forms.TextBox();
            this.btnRecalc = new System.Windows.Forms.Button();
            this.dgwTestResults = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCurrentCell = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMakeFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTestResults)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIdClass
            // 
            this.lblIdClass.AutoSize = true;
            this.lblIdClass.Location = new System.Drawing.Point(115, 4);
            this.lblIdClass.Name = "lblIdClass";
            this.lblIdClass.Size = new System.Drawing.Size(105, 18);
            this.lblIdClass.TabIndex = 7;
            this.lblIdClass.Text = "Codice Classe";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 24);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Codice Test";
            // 
            // txtIdTest
            // 
            this.txtIdTest.Location = new System.Drawing.Point(3, 25);
            this.txtIdTest.Name = "txtIdTest";
            this.txtIdTest.Size = new System.Drawing.Size(100, 24);
            this.txtIdTest.TabIndex = 4;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(796, 453);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(81, 41);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(792, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "C.N.C.";
            // 
            // txtCnc
            // 
            this.txtCnc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCnc.Location = new System.Drawing.Point(796, 25);
            this.txtCnc.Name = "txtCnc";
            this.txtCnc.Size = new System.Drawing.Size(81, 24);
            this.txtCnc.TabIndex = 9;
            this.txtCnc.Text = "1";
            // 
            // btnRecalc
            // 
            this.btnRecalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecalc.Location = new System.Drawing.Point(796, 406);
            this.btnRecalc.Name = "btnRecalc";
            this.btnRecalc.Size = new System.Drawing.Size(81, 41);
            this.btnRecalc.TabIndex = 11;
            this.btnRecalc.Text = "Ricalcola";
            this.btnRecalc.UseVisualStyleBackColor = true;
            this.btnRecalc.Click += new System.EventHandler(this.btnRecalc_Click);
            // 
            // dgwTestResults
            // 
            this.dgwTestResults.AllowUserToAddRows = false;
            this.dgwTestResults.AllowUserToDeleteRows = false;
            this.dgwTestResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwTestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTestResults.Location = new System.Drawing.Point(3, 55);
            this.dgwTestResults.Name = "dgwTestResults";
            this.dgwTestResults.RowTemplate.Height = 24;
            this.dgwTestResults.Size = new System.Drawing.Size(787, 439);
            this.dgwTestResults.TabIndex = 12;
            this.dgwTestResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwTestResults_CellContentClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(796, 359);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 41);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtCurrentCell
            // 
            this.txtCurrentCell.Location = new System.Drawing.Point(226, 25);
            this.txtCurrentCell.Name = "txtCurrentCell";
            this.txtCurrentCell.Size = new System.Drawing.Size(564, 24);
            this.txtCurrentCell.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Valore cella (click per visualizzare) ";
            // 
            // btnMakeFile
            // 
            this.btnMakeFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeFile.Enabled = false;
            this.btnMakeFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMakeFile.Location = new System.Drawing.Point(796, 312);
            this.btnMakeFile.Name = "btnMakeFile";
            this.btnMakeFile.Size = new System.Drawing.Size(81, 41);
            this.btnMakeFile.TabIndex = 16;
            this.btnMakeFile.Text = "Genera file";
            this.btnMakeFile.UseVisualStyleBackColor = true;
            this.btnMakeFile.Click += new System.EventHandler(this.btnMakeFile_Click);
            // 
            // frmTestGrading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(885, 506);
            this.Controls.Add(this.btnMakeFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCurrentCell);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgwTestResults);
            this.Controls.Add(this.btnRecalc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCnc);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lblIdClass);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdTest);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTestGrading";
            this.Text = "Valutazione di una prova";
            this.Load += new System.EventHandler(this.frmTestAssessment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTestResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdClass;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdTest;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCnc;
        private System.Windows.Forms.Button btnRecalc;
        private System.Windows.Forms.DataGridView dgwTestResults;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCurrentCell;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMakeFile;
    }
}