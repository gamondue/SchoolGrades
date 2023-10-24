namespace SchoolGrades
{
    partial class frmStartLinksManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStartLinksManagement));
            DgwLinks = new System.Windows.Forms.DataGridView();
            lblStartLink = new System.Windows.Forms.Label();
            TxtStartLink = new System.Windows.Forms.TextBox();
            btnSaveLinks = new System.Windows.Forms.Button();
            btnRemoveLink = new System.Windows.Forms.Button();
            btnAddLink = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            CmbClasses = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            CmbSchoolYear = new System.Windows.Forms.ComboBox();
            TxtOfficialSchoolAbbreviation = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            TxtLinkDescription = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            BtnChooseStartLink = new System.Windows.Forms.Button();
            BtnFileToLaunch = new System.Windows.Forms.Button();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            TxtPathStartLink = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)DgwLinks).BeginInit();
            SuspendLayout();
            // 
            // DgwLinks
            // 
            DgwLinks.AllowUserToAddRows = false;
            DgwLinks.AllowUserToDeleteRows = false;
            DgwLinks.AllowUserToOrderColumns = true;
            DgwLinks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DgwLinks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            DgwLinks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgwLinks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            DgwLinks.Location = new System.Drawing.Point(0, 135);
            DgwLinks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            DgwLinks.Name = "DgwLinks";
            DgwLinks.RowTemplate.Height = 24;
            DgwLinks.Size = new System.Drawing.Size(946, 509);
            DgwLinks.TabIndex = 1;
            DgwLinks.CellClick += DgwLinks_CellClick;
            DgwLinks.CellContentClick += DgwLinks_CellContentClick;
            DgwLinks.CellDoubleClick += DgwLinks_CellDoubleClick;
            DgwLinks.RowEnter += DgwLinks_RowEnter;
            // 
            // lblStartLink
            // 
            lblStartLink.AutoSize = true;
            lblStartLink.Location = new System.Drawing.Point(0, 107);
            lblStartLink.Name = "lblStartLink";
            lblStartLink.Size = new System.Drawing.Size(145, 18);
            lblStartLink.TabIndex = 7;
            lblStartLink.Text = "Link o file da lanciare";
            // 
            // TxtStartLink
            // 
            TxtStartLink.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TxtStartLink.Location = new System.Drawing.Point(151, 104);
            TxtStartLink.Name = "TxtStartLink";
            TxtStartLink.Size = new System.Drawing.Size(739, 24);
            TxtStartLink.TabIndex = 6;
            TxtStartLink.TextChanged += txtStartLink_TextChanged;
            TxtStartLink.DoubleClick += txtStartLink_DoubleClick;
            // 
            // btnSaveLinks
            // 
            btnSaveLinks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSaveLinks.Location = new System.Drawing.Point(880, 37);
            btnSaveLinks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSaveLinks.Name = "btnSaveLinks";
            btnSaveLinks.Size = new System.Drawing.Size(66, 30);
            btnSaveLinks.TabIndex = 10;
            btnSaveLinks.Text = "salva";
            btnSaveLinks.UseVisualStyleBackColor = true;
            btnSaveLinks.Click += btnSaveLinks_Click;
            // 
            // btnRemoveLink
            // 
            btnRemoveLink.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRemoveLink.Location = new System.Drawing.Point(837, 37);
            btnRemoveLink.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnRemoveLink.Name = "btnRemoveLink";
            btnRemoveLink.Size = new System.Drawing.Size(37, 30);
            btnRemoveLink.TabIndex = 9;
            btnRemoveLink.Text = "-";
            btnRemoveLink.UseVisualStyleBackColor = true;
            btnRemoveLink.Click += btnRemoveLink_Click;
            // 
            // btnAddLink
            // 
            btnAddLink.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddLink.Location = new System.Drawing.Point(792, 38);
            btnAddLink.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAddLink.Name = "btnAddLink";
            btnAddLink.Size = new System.Drawing.Size(39, 29);
            btnAddLink.TabIndex = 8;
            btnAddLink.Text = "+";
            btnAddLink.UseVisualStyleBackColor = true;
            btnAddLink.Click += btnAddLink_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(0, 77);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(117, 18);
            label3.TabIndex = 14;
            label3.Text = "Cartella start link";
            // 
            // CmbClasses
            // 
            CmbClasses.FormattingEnabled = true;
            CmbClasses.Location = new System.Drawing.Point(272, 37);
            CmbClasses.Name = "CmbClasses";
            CmbClasses.Size = new System.Drawing.Size(102, 26);
            CmbClasses.TabIndex = 84;
            CmbClasses.SelectedIndexChanged += CmbClasses_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.ForeColor = System.Drawing.Color.DarkBlue;
            label7.Location = new System.Drawing.Point(156, 16);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(114, 18);
            label7.TabIndex = 90;
            label7.Text = "Anno scolastico";
            // 
            // CmbSchoolYear
            // 
            CmbSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CmbSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            CmbSchoolYear.FormattingEnabled = true;
            CmbSchoolYear.Location = new System.Drawing.Point(159, 37);
            CmbSchoolYear.Margin = new System.Windows.Forms.Padding(4);
            CmbSchoolYear.Name = "CmbSchoolYear";
            CmbSchoolYear.Size = new System.Drawing.Size(89, 25);
            CmbSchoolYear.TabIndex = 83;
            CmbSchoolYear.SelectedIndexChanged += CmbSchoolYear_SelectedIndexChanged;
            // 
            // TxtOfficialSchoolAbbreviation
            // 
            TxtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TxtOfficialSchoolAbbreviation.Location = new System.Drawing.Point(2, 38);
            TxtOfficialSchoolAbbreviation.Margin = new System.Windows.Forms.Padding(4);
            TxtOfficialSchoolAbbreviation.Name = "TxtOfficialSchoolAbbreviation";
            TxtOfficialSchoolAbbreviation.ReadOnly = true;
            TxtOfficialSchoolAbbreviation.Size = new System.Drawing.Size(135, 24);
            TxtOfficialSchoolAbbreviation.TabIndex = 89;
            TxtOfficialSchoolAbbreviation.Text = "FOIS01100L";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.DarkBlue;
            label4.Location = new System.Drawing.Point(0, 16);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(105, 18);
            label4.TabIndex = 88;
            label4.Text = "Codice Scuola";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.Color.DarkBlue;
            label5.Location = new System.Drawing.Point(473, 19);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(113, 18);
            label5.TabIndex = 87;
            label5.Text = "Descrizione link";
            // 
            // TxtLinkDescription
            // 
            TxtLinkDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TxtLinkDescription.Location = new System.Drawing.Point(476, 41);
            TxtLinkDescription.Margin = new System.Windows.Forms.Padding(4);
            TxtLinkDescription.Name = "TxtLinkDescription";
            TxtLinkDescription.Size = new System.Drawing.Size(309, 24);
            TxtLinkDescription.TabIndex = 85;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.Color.DarkBlue;
            label6.Location = new System.Drawing.Point(269, 16);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(90, 18);
            label6.TabIndex = 86;
            label6.Text = "Sigla Classe";
            // 
            // BtnChooseStartLink
            // 
            BtnChooseStartLink.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnChooseStartLink.BackColor = System.Drawing.Color.Transparent;
            BtnChooseStartLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BtnChooseStartLink.ForeColor = System.Drawing.Color.DarkBlue;
            BtnChooseStartLink.Location = new System.Drawing.Point(892, 70);
            BtnChooseStartLink.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            BtnChooseStartLink.Name = "BtnChooseStartLink";
            BtnChooseStartLink.Size = new System.Drawing.Size(54, 32);
            BtnChooseStartLink.TabIndex = 148;
            BtnChooseStartLink.Text = "..";
            BtnChooseStartLink.UseVisualStyleBackColor = false;
            BtnChooseStartLink.Visible = false;
            BtnChooseStartLink.Click += BtnPathRetrictedApplication_Click;
            // 
            // BtnFileToLaunch
            // 
            BtnFileToLaunch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnFileToLaunch.BackColor = System.Drawing.Color.Transparent;
            BtnFileToLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BtnFileToLaunch.ForeColor = System.Drawing.Color.DarkBlue;
            BtnFileToLaunch.Location = new System.Drawing.Point(892, 100);
            BtnFileToLaunch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            BtnFileToLaunch.Name = "BtnFileToLaunch";
            BtnFileToLaunch.Size = new System.Drawing.Size(54, 32);
            BtnFileToLaunch.TabIndex = 149;
            BtnFileToLaunch.Text = "..";
            BtnFileToLaunch.UseVisualStyleBackColor = false;
            BtnFileToLaunch.Click += BtnFileToLaunch_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // TxtPathStartLink
            // 
            TxtPathStartLink.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TxtPathStartLink.Location = new System.Drawing.Point(123, 74);
            TxtPathStartLink.Name = "TxtPathStartLink";
            TxtPathStartLink.ReadOnly = true;
            TxtPathStartLink.Size = new System.Drawing.Size(767, 24);
            TxtPathStartLink.TabIndex = 13;
            TxtPathStartLink.TextChanged += TxtPathStartLink_TextChanged;
            TxtPathStartLink.DoubleClick += TxtPathStartLink_DoubleClick;
            // 
            // frmStartLinksManagement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(948, 647);
            Controls.Add(BtnFileToLaunch);
            Controls.Add(BtnChooseStartLink);
            Controls.Add(CmbClasses);
            Controls.Add(label7);
            Controls.Add(CmbSchoolYear);
            Controls.Add(TxtOfficialSchoolAbbreviation);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(TxtLinkDescription);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(TxtPathStartLink);
            Controls.Add(btnSaveLinks);
            Controls.Add(btnRemoveLink);
            Controls.Add(btnAddLink);
            Controls.Add(lblStartLink);
            Controls.Add(TxtStartLink);
            Controls.Add(DgwLinks);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmStartLinksManagement";
            Text = "Start links";
            Load += frmStartLinksManagement_Load;
            ((System.ComponentModel.ISupportInitialize)DgwLinks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView DgwLinks;
        private System.Windows.Forms.Label lblStartLink;
        private System.Windows.Forms.TextBox TxtStartLink;
        private System.Windows.Forms.Button btnSaveLinks;
        private System.Windows.Forms.Button btnRemoveLink;
        private System.Windows.Forms.Button btnAddLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbClasses;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbSchoolYear;
        private System.Windows.Forms.TextBox TxtOfficialSchoolAbbreviation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtLinkDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnChooseStartLink;
        private System.Windows.Forms.Button BtnFileToLaunch;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox TxtPathStartLink;
    }
}