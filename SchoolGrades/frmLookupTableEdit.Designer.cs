namespace SchoolGrades
{
    partial class frmLookupTableEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLookupTableEdit));
            dgwTable = new System.Windows.Forms.DataGridView();
            BtnSalva = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgwTable).BeginInit();
            SuspendLayout();
            // 
            // dgwTable
            // 
            dgwTable.AllowUserToDeleteRows = false;
            dgwTable.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgwTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwTable.Location = new System.Drawing.Point(3, 64);
            dgwTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dgwTable.Name = "dgwTable";
            dgwTable.RowHeadersWidth = 51;
            dgwTable.RowTemplate.Height = 24;
            dgwTable.Size = new System.Drawing.Size(1322, 344);
            dgwTable.TabIndex = 1;
            dgwTable.CellContentClick += dgwTable_CellContentClick;
            dgwTable.CellEndEdit += dgwTable_CellEndEdit;
            // 
            // BtnSalva
            // 
            BtnSalva.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnSalva.Location = new System.Drawing.Point(1250, 12);
            BtnSalva.Name = "BtnSalva";
            BtnSalva.Size = new System.Drawing.Size(75, 45);
            BtnSalva.TabIndex = 2;
            BtnSalva.Text = "Salva";
            BtnSalva.UseVisualStyleBackColor = true;
            BtnSalva.Click += BtnSalva_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(1253, 26);
            label1.TabIndex = 3;
            label1.Text = "ATTENZIONE. Le righe della tabella modificata non si possono cancellare, nè si può modificare il codice dopo averlo assegnato. ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(479, 26);
            label2.TabIndex = 4;
            label2.Text = "Pianificare con cura la scrittura di queste tabelle!";
            // 
            // frmLookupTableEdit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(1326, 410);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BtnSalva);
            Controls.Add(dgwTable);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmLookupTableEdit";
            Tag = "";
            Text = "Modifica tabelle";
            FormClosing += frmEditLookupTable_FormClosing;
            Load += frmEditLookupTable_Load;
            ((System.ComponentModel.ISupportInitialize)dgwTable).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwTable;
        private System.Windows.Forms.Button BtnSalva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}