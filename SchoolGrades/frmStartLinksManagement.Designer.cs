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
            this.DgwLinks = new System.Windows.Forms.DataGridView();
            this.lblStartLink = new System.Windows.Forms.Label();
            this.TxtStartLink = new System.Windows.Forms.TextBox();
            this.btnSaveLinks = new System.Windows.Forms.Button();
            this.btnRemoveLink = new System.Windows.Forms.Button();
            this.btnAddLink = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbClasses = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbSchoolYear = new System.Windows.Forms.ComboBox();
            this.TxtOfficialSchoolAbbreviation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtLinkDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnChooseStartLink = new System.Windows.Forms.Button();
            this.BtnFileToLaunch = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TxtPathStartLink = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgwLinks)).BeginInit();
            this.SuspendLayout();
            // 
            // DgwLinks
            // 
            this.DgwLinks.AllowUserToAddRows = false;
            this.DgwLinks.AllowUserToDeleteRows = false;
            this.DgwLinks.AllowUserToOrderColumns = true;
            this.DgwLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgwLinks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.DgwLinks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgwLinks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgwLinks.Location = new System.Drawing.Point(0, 135);
            this.DgwLinks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgwLinks.Name = "DgwLinks";
            this.DgwLinks.RowTemplate.Height = 24;
            this.DgwLinks.Size = new System.Drawing.Size(946, 509);
            this.DgwLinks.TabIndex = 1;
            this.DgwLinks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwLinks_CellClick);
            this.DgwLinks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwLinks_CellContentClick);
            this.DgwLinks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwLinks_CellDoubleClick);
            this.DgwLinks.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwLinks_RowEnter);
            // 
            // lblStartLink
            // 
            this.lblStartLink.AutoSize = true;
            this.lblStartLink.Location = new System.Drawing.Point(0, 107);
            this.lblStartLink.Name = "lblStartLink";
            this.lblStartLink.Size = new System.Drawing.Size(145, 18);
            this.lblStartLink.TabIndex = 7;
            this.lblStartLink.Text = "Link o file da lanciare";
            // 
            // TxtStartLink
            // 
            this.TxtStartLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtStartLink.Location = new System.Drawing.Point(151, 104);
            this.TxtStartLink.Name = "TxtStartLink";
            this.TxtStartLink.Size = new System.Drawing.Size(739, 24);
            this.TxtStartLink.TabIndex = 6;
            this.TxtStartLink.TextChanged += new System.EventHandler(this.txtStartLink_TextChanged);
            this.TxtStartLink.DoubleClick += new System.EventHandler(this.txtStartLink_DoubleClick);
            // 
            // btnSaveLinks
            // 
            this.btnSaveLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveLinks.Location = new System.Drawing.Point(880, 37);
            this.btnSaveLinks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveLinks.Name = "btnSaveLinks";
            this.btnSaveLinks.Size = new System.Drawing.Size(66, 30);
            this.btnSaveLinks.TabIndex = 10;
            this.btnSaveLinks.Text = "salva";
            this.btnSaveLinks.UseVisualStyleBackColor = true;
            this.btnSaveLinks.Click += new System.EventHandler(this.btnSaveLinks_Click);
            // 
            // btnRemoveLink
            // 
            this.btnRemoveLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveLink.Location = new System.Drawing.Point(837, 37);
            this.btnRemoveLink.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveLink.Name = "btnRemoveLink";
            this.btnRemoveLink.Size = new System.Drawing.Size(37, 30);
            this.btnRemoveLink.TabIndex = 9;
            this.btnRemoveLink.Text = "-";
            this.btnRemoveLink.UseVisualStyleBackColor = true;
            this.btnRemoveLink.Click += new System.EventHandler(this.btnRemoveLink_Click);
            // 
            // btnAddLink
            // 
            this.btnAddLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLink.Location = new System.Drawing.Point(792, 38);
            this.btnAddLink.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddLink.Name = "btnAddLink";
            this.btnAddLink.Size = new System.Drawing.Size(39, 29);
            this.btnAddLink.TabIndex = 8;
            this.btnAddLink.Text = "+";
            this.btnAddLink.UseVisualStyleBackColor = true;
            this.btnAddLink.Click += new System.EventHandler(this.btnAddLink_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cartella start link";
            // 
            // CmbClasses
            // 
            this.CmbClasses.FormattingEnabled = true;
            this.CmbClasses.Location = new System.Drawing.Point(272, 37);
            this.CmbClasses.Name = "CmbClasses";
            this.CmbClasses.Size = new System.Drawing.Size(102, 26);
            this.CmbClasses.TabIndex = 84;
            this.CmbClasses.SelectedIndexChanged += new System.EventHandler(this.CmbClasses_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(156, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 18);
            this.label7.TabIndex = 90;
            this.label7.Text = "Anno scolastico";
            // 
            // CmbSchoolYear
            // 
            this.CmbSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.CmbSchoolYear.FormattingEnabled = true;
            this.CmbSchoolYear.Location = new System.Drawing.Point(159, 37);
            this.CmbSchoolYear.Margin = new System.Windows.Forms.Padding(4);
            this.CmbSchoolYear.Name = "CmbSchoolYear";
            this.CmbSchoolYear.Size = new System.Drawing.Size(89, 25);
            this.CmbSchoolYear.TabIndex = 83;
            this.CmbSchoolYear.SelectedIndexChanged += new System.EventHandler(this.CmbSchoolYear_SelectedIndexChanged);
            // 
            // TxtOfficialSchoolAbbreviation
            // 
            this.TxtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOfficialSchoolAbbreviation.Location = new System.Drawing.Point(2, 38);
            this.TxtOfficialSchoolAbbreviation.Margin = new System.Windows.Forms.Padding(4);
            this.TxtOfficialSchoolAbbreviation.Name = "TxtOfficialSchoolAbbreviation";
            this.TxtOfficialSchoolAbbreviation.ReadOnly = true;
            this.TxtOfficialSchoolAbbreviation.Size = new System.Drawing.Size(135, 24);
            this.TxtOfficialSchoolAbbreviation.TabIndex = 89;
            this.TxtOfficialSchoolAbbreviation.Text = "FOIS01100L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(0, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 18);
            this.label4.TabIndex = 88;
            this.label4.Text = "Codice Scuola";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(473, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 18);
            this.label5.TabIndex = 87;
            this.label5.Text = "Descrizione link";
            // 
            // TxtLinkDescription
            // 
            this.TxtLinkDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLinkDescription.Location = new System.Drawing.Point(476, 41);
            this.TxtLinkDescription.Margin = new System.Windows.Forms.Padding(4);
            this.TxtLinkDescription.Name = "TxtLinkDescription";
            this.TxtLinkDescription.Size = new System.Drawing.Size(309, 24);
            this.TxtLinkDescription.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(269, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 18);
            this.label6.TabIndex = 86;
            this.label6.Text = "Sigla Classe";
            // 
            // BtnChooseStartLink
            // 
            this.BtnChooseStartLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnChooseStartLink.BackColor = System.Drawing.Color.Transparent;
            this.BtnChooseStartLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChooseStartLink.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnChooseStartLink.Location = new System.Drawing.Point(892, 70);
            this.BtnChooseStartLink.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnChooseStartLink.Name = "BtnChooseStartLink";
            this.BtnChooseStartLink.Size = new System.Drawing.Size(54, 32);
            this.BtnChooseStartLink.TabIndex = 148;
            this.BtnChooseStartLink.Text = "..";
            this.BtnChooseStartLink.UseVisualStyleBackColor = false;
            this.BtnChooseStartLink.Visible = false;
            this.BtnChooseStartLink.Click += new System.EventHandler(this.BtnPathRetrictedApplication_Click);
            // 
            // BtnFileToLaunch
            // 
            this.BtnFileToLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFileToLaunch.BackColor = System.Drawing.Color.Transparent;
            this.BtnFileToLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFileToLaunch.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnFileToLaunch.Location = new System.Drawing.Point(892, 100);
            this.BtnFileToLaunch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnFileToLaunch.Name = "BtnFileToLaunch";
            this.BtnFileToLaunch.Size = new System.Drawing.Size(54, 32);
            this.BtnFileToLaunch.TabIndex = 149;
            this.BtnFileToLaunch.Text = "..";
            this.BtnFileToLaunch.UseVisualStyleBackColor = false;
            this.BtnFileToLaunch.Click += new System.EventHandler(this.BtnFileToLaunch_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // TxtPathStartLink
            // 
            this.TxtPathStartLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPathStartLink.Location = new System.Drawing.Point(123, 74);
            this.TxtPathStartLink.Name = "TxtPathStartLink";
            this.TxtPathStartLink.ReadOnly = true;
            this.TxtPathStartLink.Size = new System.Drawing.Size(767, 24);
            this.TxtPathStartLink.TabIndex = 13;
            this.TxtPathStartLink.TextChanged += new System.EventHandler(this.TxtPathStartLink_TextChanged);
            this.TxtPathStartLink.DoubleClick += new System.EventHandler(this.TxtPathStartLink_DoubleClick);
            // 
            // frmStartLinksManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(948, 647);
            this.Controls.Add(this.BtnFileToLaunch);
            this.Controls.Add(this.BtnChooseStartLink);
            this.Controls.Add(this.CmbClasses);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbSchoolYear);
            this.Controls.Add(this.TxtOfficialSchoolAbbreviation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtLinkDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtPathStartLink);
            this.Controls.Add(this.btnSaveLinks);
            this.Controls.Add(this.btnRemoveLink);
            this.Controls.Add(this.btnAddLink);
            this.Controls.Add(this.lblStartLink);
            this.Controls.Add(this.TxtStartLink);
            this.Controls.Add(this.DgwLinks);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStartLinksManagement";
            this.Text = "Start links";
            this.Load += new System.EventHandler(this.frmStartLinksManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgwLinks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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