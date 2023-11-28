namespace SchoolGrades
{
    partial class frmTag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTag));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdTag = new System.Windows.Forms.TextBox();
            this.lblIdTag = new System.Windows.Forms.Label();
            this.lblTag = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.dgwExistingTags = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEsc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwExistingTags)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(2, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(189, 24);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(197, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ricerca";
            // 
            // txtIdTag
            // 
            this.txtIdTag.Location = new System.Drawing.Point(201, 79);
            this.txtIdTag.Name = "txtIdTag";
            this.txtIdTag.ReadOnly = true;
            this.txtIdTag.Size = new System.Drawing.Size(102, 24);
            this.txtIdTag.TabIndex = 3;
            // 
            // lblIdTag
            // 
            this.lblIdTag.AutoSize = true;
            this.lblIdTag.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblIdTag.Location = new System.Drawing.Point(197, 47);
            this.lblIdTag.Name = "lblIdTag";
            this.lblIdTag.Size = new System.Drawing.Size(55, 18);
            this.lblIdTag.TabIndex = 4;
            this.lblIdTag.Text = "Codice";
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTag.Location = new System.Drawing.Point(315, 47);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(33, 18);
            this.lblTag.TabIndex = 6;
            this.lblTag.Text = "Tag";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(315, 79);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(189, 24);
            this.txtTag.TabIndex = 5;
            this.txtTag.TextChanged += new System.EventHandler(this.txtTag_TextChanged);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDesc.Location = new System.Drawing.Point(197, 119);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(87, 18);
            this.lblDesc.TabIndex = 8;
            this.lblDesc.Text = "Descrizione";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(197, 151);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(307, 114);
            this.txtDesc.TabIndex = 7;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // btnNew
            // 
            this.btnNew.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnNew.Location = new System.Drawing.Point(197, 288);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 39);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "Nuovo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSave.Location = new System.Drawing.Point(313, 288);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnChoose.Location = new System.Drawing.Point(429, 288);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 39);
            this.btnChoose.TabIndex = 11;
            this.btnChoose.Text = "Scegli";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // dgwExistingTags
            // 
            this.dgwExistingTags.AllowUserToAddRows = false;
            this.dgwExistingTags.AllowUserToDeleteRows = false;
            this.dgwExistingTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwExistingTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwExistingTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.TagName,
            this.DEsc});
            this.dgwExistingTags.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwExistingTags.Location = new System.Drawing.Point(4, 47);
            this.dgwExistingTags.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwExistingTags.Name = "dgwExistingTags";
            this.dgwExistingTags.RowHeadersVisible = false;
            this.dgwExistingTags.RowTemplate.Height = 24;
            this.dgwExistingTags.Size = new System.Drawing.Size(187, 571);
            this.dgwExistingTags.TabIndex = 12;
            this.dgwExistingTags.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwExistingTags_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // TagName
            // 
            this.TagName.HeaderText = "Tag";
            this.TagName.Name = "TagName";
            this.TagName.Visible = false;
            // 
            // DEsc
            // 
            this.DEsc.HeaderText = "Descrizione";
            this.DEsc.Name = "DEsc";
            this.DEsc.Visible = false;
            // 
            // frmTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(517, 621);
            this.Controls.Add(this.dgwExistingTags);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.lblIdTag);
            this.Controls.Add(this.txtIdTag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTag";
            this.Text = "Tag";
            this.Load += new System.EventHandler(this.frmTag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwExistingTags)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdTag;
        private System.Windows.Forms.Label lblIdTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.DataGridView dgwExistingTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEsc;
    }
}