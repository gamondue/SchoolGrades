namespace SchoolGrades
{
    partial class frmEditLookupTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditLookupTable));
            this.dgwTable = new System.Windows.Forms.DataGridView();
            this.BtnSalva = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwTable
            // 
            this.dgwTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgwTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTable.Location = new System.Drawing.Point(3, 64);
            this.dgwTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwTable.Name = "dgwTable";
            this.dgwTable.RowHeadersWidth = 51;
            this.dgwTable.RowTemplate.Height = 24;
            this.dgwTable.Size = new System.Drawing.Size(996, 344);
            this.dgwTable.TabIndex = 1;
            // 
            // BtnSalva
            // 
            this.BtnSalva.Location = new System.Drawing.Point(913, 12);
            this.BtnSalva.Name = "BtnSalva";
            this.BtnSalva.Size = new System.Drawing.Size(75, 45);
            this.BtnSalva.TabIndex = 2;
            this.BtnSalva.Text = "Salva";
            this.BtnSalva.UseVisualStyleBackColor = true;
            this.BtnSalva.Click += new System.EventHandler(this.BtnSalva_Click);
            // 
            // frmEditLookupTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1000, 410);
            this.Controls.Add(this.BtnSalva);
            this.Controls.Add(this.dgwTable);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEditLookupTable";
            this.Tag = "";
            this.Text = "Gestione tabelle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditLookupTable_FormClosing);
            this.Load += new System.EventHandler(this.frmEditLookupTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwTable;
        private System.Windows.Forms.Button BtnSalva;
    }
}