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
            txtSearch = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            txtIdTag = new System.Windows.Forms.TextBox();
            lblIdTag = new System.Windows.Forms.Label();
            lblTag = new System.Windows.Forms.Label();
            txtTag = new System.Windows.Forms.TextBox();
            lblDesc = new System.Windows.Forms.Label();
            txtDesc = new System.Windows.Forms.TextBox();
            btnNew = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnChoose = new System.Windows.Forms.Button();
            dgwExistingTags = new System.Windows.Forms.DataGridView();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DEsc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgwExistingTags).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new System.Drawing.Point(2, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(189, 24);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.DarkBlue;
            label1.Location = new System.Drawing.Point(197, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(59, 18);
            label1.TabIndex = 2;
            label1.Text = "Ricerca";
            // 
            // txtIdTag
            // 
            txtIdTag.Location = new System.Drawing.Point(201, 79);
            txtIdTag.Name = "txtIdTag";
            txtIdTag.ReadOnly = true;
            txtIdTag.Size = new System.Drawing.Size(102, 24);
            txtIdTag.TabIndex = 3;
            // 
            // lblIdTag
            // 
            lblIdTag.AutoSize = true;
            lblIdTag.ForeColor = System.Drawing.Color.DarkBlue;
            lblIdTag.Location = new System.Drawing.Point(197, 47);
            lblIdTag.Name = "lblIdTag";
            lblIdTag.Size = new System.Drawing.Size(55, 18);
            lblIdTag.TabIndex = 4;
            lblIdTag.Text = "Codice";
            // 
            // lblTag
            // 
            lblTag.AutoSize = true;
            lblTag.ForeColor = System.Drawing.Color.DarkBlue;
            lblTag.Location = new System.Drawing.Point(315, 47);
            lblTag.Name = "lblTag";
            lblTag.Size = new System.Drawing.Size(33, 18);
            lblTag.TabIndex = 6;
            lblTag.Text = "Tag";
            // 
            // txtTag
            // 
            txtTag.Location = new System.Drawing.Point(315, 79);
            txtTag.Name = "txtTag";
            txtTag.Size = new System.Drawing.Size(189, 24);
            txtTag.TabIndex = 5;
            txtTag.TextChanged += txtTag_TextChanged;
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.ForeColor = System.Drawing.Color.DarkBlue;
            lblDesc.Location = new System.Drawing.Point(197, 119);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new System.Drawing.Size(87, 18);
            lblDesc.TabIndex = 8;
            lblDesc.Text = "Descrizione";
            // 
            // txtDesc
            // 
            txtDesc.Location = new System.Drawing.Point(197, 151);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new System.Drawing.Size(307, 114);
            txtDesc.TabIndex = 7;
            txtDesc.TextChanged += txtDesc_TextChanged;
            // 
            // btnNew
            // 
            btnNew.ForeColor = System.Drawing.Color.DarkBlue;
            btnNew.Location = new System.Drawing.Point(197, 288);
            btnNew.Name = "btnNew";
            btnNew.Size = new System.Drawing.Size(75, 39);
            btnNew.TabIndex = 9;
            btnNew.Text = "Nuovo";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnSave
            // 
            btnSave.ForeColor = System.Drawing.Color.DarkBlue;
            btnSave.Location = new System.Drawing.Point(313, 288);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 39);
            btnSave.TabIndex = 10;
            btnSave.Text = "Salva";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnChoose
            // 
            btnChoose.ForeColor = System.Drawing.Color.DarkBlue;
            btnChoose.Location = new System.Drawing.Point(429, 288);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(75, 39);
            btnChoose.TabIndex = 11;
            btnChoose.Text = "Scegli";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click;
            // 
            // dgwExistingTags
            // 
            dgwExistingTags.AllowUserToAddRows = false;
            dgwExistingTags.AllowUserToDeleteRows = false;
            dgwExistingTags.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwExistingTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwExistingTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Column1, TagName, DEsc });
            dgwExistingTags.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgwExistingTags.Location = new System.Drawing.Point(4, 47);
            dgwExistingTags.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dgwExistingTags.Name = "dgwExistingTags";
            dgwExistingTags.RowHeadersVisible = false;
            dgwExistingTags.RowTemplate.Height = 24;
            dgwExistingTags.Size = new System.Drawing.Size(187, 571);
            dgwExistingTags.TabIndex = 12;
            dgwExistingTags.CellContentClick += dgwExistingTags_CellContentClick;
            dgwExistingTags.CellDoubleClick += dgwExistingTags_CellDoubleClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.Visible = false;
            // 
            // TagName
            // 
            TagName.HeaderText = "Tag";
            TagName.Name = "TagName";
            TagName.Visible = false;
            // 
            // DEsc
            // 
            DEsc.HeaderText = "Descrizione";
            DEsc.Name = "DEsc";
            DEsc.Visible = false;
            // 
            // frmTag
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(517, 621);
            Controls.Add(dgwExistingTags);
            Controls.Add(btnChoose);
            Controls.Add(btnSave);
            Controls.Add(btnNew);
            Controls.Add(lblDesc);
            Controls.Add(txtDesc);
            Controls.Add(lblTag);
            Controls.Add(txtTag);
            Controls.Add(lblIdTag);
            Controls.Add(txtIdTag);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmTag";
            Text = "Tag";
            Load += frmTag_Load;
            ((System.ComponentModel.ISupportInitialize)dgwExistingTags).EndInit();
            ResumeLayout(false);
            PerformLayout();
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