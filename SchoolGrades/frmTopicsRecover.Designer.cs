namespace SchoolGrades
{
    partial class frmTopicsRecover
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopicsRecover));
            this.lblPathDatabase = new System.Windows.Forms.Label();
            this.txtPathNewDatabase = new System.Windows.Forms.TextBox();
            this.btnPathNewDatabase = new System.Windows.Forms.Button();
            this.lblFileDatabase = new System.Windows.Forms.Label();
            this.txtFileNewDatabase = new System.Windows.Forms.TextBox();
            this.btnFileNewDatabase = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPathOldDatabase = new System.Windows.Forms.TextBox();
            this.btnPathOldDatabase = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFileOldDatabase = new System.Windows.Forms.TextBox();
            this.btnFileOldDatabase = new System.Windows.Forms.Button();
            this.btnRecover = new System.Windows.Forms.Button();
            this.chkCheckChangesSameId = new System.Windows.Forms.CheckBox();
            this.chkErasedId = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trwNewTopics = new System.Windows.Forms.TreeView();
            this.trwOldTopics = new System.Windows.Forms.TreeView();
            this.txtNewTopicName = new System.Windows.Forms.TextBox();
            this.txtOldTopicName = new System.Windows.Forms.TextBox();
            this.txtCodOldTopic = new System.Windows.Forms.TextBox();
            this.txtCodNewTopic = new System.Windows.Forms.TextBox();
            this.lblIdNewTopic = new System.Windows.Forms.Label();
            this.lblIdOldTopic = new System.Windows.Forms.Label();
            this.btnCopyOldNew = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnFindNew = new System.Windows.Forms.Button();
            this.txtSearchNew = new System.Windows.Forms.TextBox();
            this.txtNewDescription = new System.Windows.Forms.TextBox();
            this.btnFindOld = new System.Windows.Forms.Button();
            this.txtSearchOld = new System.Windows.Forms.TextBox();
            this.txtOldDescription = new System.Windows.Forms.TextBox();
            this.BtnSaveNewTree = new System.Windows.Forms.Button();
            this.picNewOnly = new System.Windows.Forms.PictureBox();
            this.chkNewOnly = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.picOldOnly = new System.Windows.Forms.PictureBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.picSameId = new System.Windows.Forms.PictureBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.picSameName = new System.Windows.Forms.PictureBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.picSameDesc = new System.Windows.Forms.PictureBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.picSameNodeChangedParent = new System.Windows.Forms.PictureBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.picSameNodeChangedPosition = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnTemporary = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBeheaded = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNewOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOldOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSameId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSameName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSameDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSameNodeChangedParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSameNodeChangedPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPathDatabase
            // 
            this.lblPathDatabase.AutoSize = true;
            this.lblPathDatabase.Location = new System.Drawing.Point(10, 10);
            this.lblPathDatabase.Name = "lblPathDatabase";
            this.lblPathDatabase.Size = new System.Drawing.Size(125, 18);
            this.lblPathDatabase.TabIndex = 102;
            this.lblPathDatabase.Text = "Cartella file nuovo";
            // 
            // txtPathNewDatabase
            // 
            this.txtPathNewDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPathNewDatabase.Location = new System.Drawing.Point(13, 31);
            this.txtPathNewDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.txtPathNewDatabase.Name = "txtPathNewDatabase";
            this.txtPathNewDatabase.Size = new System.Drawing.Size(762, 24);
            this.txtPathNewDatabase.TabIndex = 100;
            // 
            // btnPathNewDatabase
            // 
            this.btnPathNewDatabase.BackColor = System.Drawing.Color.Transparent;
            this.btnPathNewDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPathNewDatabase.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnPathNewDatabase.Location = new System.Drawing.Point(785, 22);
            this.btnPathNewDatabase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPathNewDatabase.Name = "btnPathNewDatabase";
            this.btnPathNewDatabase.Size = new System.Drawing.Size(54, 40);
            this.btnPathNewDatabase.TabIndex = 101;
            this.btnPathNewDatabase.Text = "..";
            this.btnPathNewDatabase.UseVisualStyleBackColor = false;
            this.btnPathNewDatabase.Click += new System.EventHandler(this.btnPathNewDatabase_Click);
            // 
            // lblFileDatabase
            // 
            this.lblFileDatabase.AutoSize = true;
            this.lblFileDatabase.Location = new System.Drawing.Point(848, 10);
            this.lblFileDatabase.Name = "lblFileDatabase";
            this.lblFileDatabase.Size = new System.Drawing.Size(76, 18);
            this.lblFileDatabase.TabIndex = 99;
            this.lblFileDatabase.Text = "File nuovo";
            // 
            // txtFileNewDatabase
            // 
            this.txtFileNewDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFileNewDatabase.Location = new System.Drawing.Point(851, 31);
            this.txtFileNewDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileNewDatabase.Name = "txtFileNewDatabase";
            this.txtFileNewDatabase.Size = new System.Drawing.Size(344, 24);
            this.txtFileNewDatabase.TabIndex = 97;
            // 
            // btnFileNewDatabase
            // 
            this.btnFileNewDatabase.BackColor = System.Drawing.Color.Transparent;
            this.btnFileNewDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFileNewDatabase.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnFileNewDatabase.Location = new System.Drawing.Point(1205, 22);
            this.btnFileNewDatabase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnFileNewDatabase.Name = "btnFileNewDatabase";
            this.btnFileNewDatabase.Size = new System.Drawing.Size(54, 40);
            this.btnFileNewDatabase.TabIndex = 98;
            this.btnFileNewDatabase.Text = "..";
            this.btnFileNewDatabase.UseVisualStyleBackColor = false;
            this.btnFileNewDatabase.Click += new System.EventHandler(this.btnFileNewDatabase_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 18);
            this.label6.TabIndex = 125;
            this.label6.Text = "Cartella file vecchio";
            // 
            // txtPathOldDatabase
            // 
            this.txtPathOldDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPathOldDatabase.Location = new System.Drawing.Point(12, 89);
            this.txtPathOldDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.txtPathOldDatabase.Name = "txtPathOldDatabase";
            this.txtPathOldDatabase.Size = new System.Drawing.Size(762, 24);
            this.txtPathOldDatabase.TabIndex = 123;
            // 
            // btnPathOldDatabase
            // 
            this.btnPathOldDatabase.BackColor = System.Drawing.Color.Transparent;
            this.btnPathOldDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPathOldDatabase.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnPathOldDatabase.Location = new System.Drawing.Point(784, 80);
            this.btnPathOldDatabase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPathOldDatabase.Name = "btnPathOldDatabase";
            this.btnPathOldDatabase.Size = new System.Drawing.Size(54, 40);
            this.btnPathOldDatabase.TabIndex = 124;
            this.btnPathOldDatabase.Text = "..";
            this.btnPathOldDatabase.UseVisualStyleBackColor = false;
            this.btnPathOldDatabase.Click += new System.EventHandler(this.btnPathOldDatabase_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(847, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 18);
            this.label7.TabIndex = 122;
            this.label7.Text = "File vecchio";
            // 
            // txtFileOldDatabase
            // 
            this.txtFileOldDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFileOldDatabase.Location = new System.Drawing.Point(850, 89);
            this.txtFileOldDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileOldDatabase.Name = "txtFileOldDatabase";
            this.txtFileOldDatabase.Size = new System.Drawing.Size(344, 24);
            this.txtFileOldDatabase.TabIndex = 120;
            // 
            // btnFileOldDatabase
            // 
            this.btnFileOldDatabase.BackColor = System.Drawing.Color.Transparent;
            this.btnFileOldDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFileOldDatabase.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnFileOldDatabase.Location = new System.Drawing.Point(1204, 80);
            this.btnFileOldDatabase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnFileOldDatabase.Name = "btnFileOldDatabase";
            this.btnFileOldDatabase.Size = new System.Drawing.Size(54, 40);
            this.btnFileOldDatabase.TabIndex = 121;
            this.btnFileOldDatabase.Text = "..";
            this.btnFileOldDatabase.UseVisualStyleBackColor = false;
            this.btnFileOldDatabase.Click += new System.EventHandler(this.btnFileOldDatabase_Click);
            // 
            // btnRecover
            // 
            this.btnRecover.Location = new System.Drawing.Point(12, 120);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(66, 46);
            this.btnRecover.TabIndex = 126;
            this.btnRecover.Text = "Importa";
            this.btnRecover.UseVisualStyleBackColor = true;
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // chkCheckChangesSameId
            // 
            this.chkCheckChangesSameId.AutoSize = true;
            this.chkCheckChangesSameId.Location = new System.Drawing.Point(158, 144);
            this.chkCheckChangesSameId.Name = "chkCheckChangesSameId";
            this.chkCheckChangesSameId.Size = new System.Drawing.Size(246, 22);
            this.chkCheckChangesSameId.TabIndex = 127;
            this.chkCheckChangesSameId.Text = "Argomenti con stesso Id cambiati";
            this.chkCheckChangesSameId.UseVisualStyleBackColor = true;
            // 
            // chkErasedId
            // 
            this.chkErasedId.AutoSize = true;
            this.chkErasedId.Checked = true;
            this.chkErasedId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkErasedId.Location = new System.Drawing.Point(158, 120);
            this.chkErasedId.Name = "chkErasedId";
            this.chkErasedId.Size = new System.Drawing.Size(209, 22);
            this.chkErasedId.TabIndex = 128;
            this.chkErasedId.Text = "Argomenti con Id cancellato";
            this.chkErasedId.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 129;
            this.label1.Text = "Albero file vecchio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 130;
            this.label2.Text = "Albero file nuovo";
            // 
            // trwNewTopics
            // 
            this.trwNewTopics.AllowDrop = true;
            this.trwNewTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trwNewTopics.Location = new System.Drawing.Point(3, 39);
            this.trwNewTopics.Name = "trwNewTopics";
            this.trwNewTopics.Size = new System.Drawing.Size(577, 292);
            this.trwNewTopics.TabIndex = 131;
            // 
            // trwOldTopics
            // 
            this.trwOldTopics.AllowDrop = true;
            this.trwOldTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trwOldTopics.Location = new System.Drawing.Point(3, 40);
            this.trwOldTopics.Name = "trwOldTopics";
            this.trwOldTopics.Size = new System.Drawing.Size(572, 292);
            this.trwOldTopics.TabIndex = 134;
            // 
            // txtNewTopicName
            // 
            this.txtNewTopicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewTopicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNewTopicName.Location = new System.Drawing.Point(3, 335);
            this.txtNewTopicName.Multiline = true;
            this.txtNewTopicName.Name = "txtNewTopicName";
            this.txtNewTopicName.Size = new System.Drawing.Size(577, 32);
            this.txtNewTopicName.TabIndex = 136;
            // 
            // txtOldTopicName
            // 
            this.txtOldTopicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldTopicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOldTopicName.Location = new System.Drawing.Point(3, 335);
            this.txtOldTopicName.Multiline = true;
            this.txtOldTopicName.Name = "txtOldTopicName";
            this.txtOldTopicName.Size = new System.Drawing.Size(572, 32);
            this.txtOldTopicName.TabIndex = 137;
            // 
            // txtCodOldTopic
            // 
            this.txtCodOldTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCodOldTopic.Location = new System.Drawing.Point(254, 9);
            this.txtCodOldTopic.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodOldTopic.Name = "txtCodOldTopic";
            this.txtCodOldTopic.Size = new System.Drawing.Size(70, 24);
            this.txtCodOldTopic.TabIndex = 138;
            this.txtCodOldTopic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCodNewTopic
            // 
            this.txtCodNewTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCodNewTopic.Location = new System.Drawing.Point(252, 8);
            this.txtCodNewTopic.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodNewTopic.Name = "txtCodNewTopic";
            this.txtCodNewTopic.Size = new System.Drawing.Size(70, 24);
            this.txtCodNewTopic.TabIndex = 139;
            this.txtCodNewTopic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIdNewTopic
            // 
            this.lblIdNewTopic.AutoSize = true;
            this.lblIdNewTopic.Location = new System.Drawing.Point(133, 11);
            this.lblIdNewTopic.Name = "lblIdNewTopic";
            this.lblIdNewTopic.Size = new System.Drawing.Size(112, 18);
            this.lblIdNewTopic.TabIndex = 140;
            this.lblIdNewTopic.Text = "Cod.argomento";
            // 
            // lblIdOldTopic
            // 
            this.lblIdOldTopic.AutoSize = true;
            this.lblIdOldTopic.Location = new System.Drawing.Point(136, 11);
            this.lblIdOldTopic.Name = "lblIdOldTopic";
            this.lblIdOldTopic.Size = new System.Drawing.Size(112, 18);
            this.lblIdOldTopic.TabIndex = 141;
            this.lblIdOldTopic.Text = "Cod.argomento";
            // 
            // btnCopyOldNew
            // 
            this.btnCopyOldNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyOldNew.Location = new System.Drawing.Point(1184, 209);
            this.btnCopyOldNew.Name = "btnCopyOldNew";
            this.btnCopyOldNew.Size = new System.Drawing.Size(75, 42);
            this.btnCopyOldNew.TabIndex = 142;
            this.btnCopyOldNew.Text = "<-";
            this.btnCopyOldNew.UseVisualStyleBackColor = true;
            this.btnCopyOldNew.Click += new System.EventHandler(this.btnCopyOldNew_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(13, 172);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnFindNew);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearchNew);
            this.splitContainer1.Panel1.Controls.Add(this.txtNewDescription);
            this.splitContainer1.Panel1.Controls.Add(this.trwNewTopics);
            this.splitContainer1.Panel1.Controls.Add(this.lblIdNewTopic);
            this.splitContainer1.Panel1.Controls.Add(this.txtNewTopicName);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodNewTopic);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnFindOld);
            this.splitContainer1.Panel2.Controls.Add(this.txtSearchOld);
            this.splitContainer1.Panel2.Controls.Add(this.txtOldDescription);
            this.splitContainer1.Panel2.Controls.Add(this.trwOldTopics);
            this.splitContainer1.Panel2.Controls.Add(this.txtOldTopicName);
            this.splitContainer1.Panel2.Controls.Add(this.lblIdOldTopic);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtCodOldTopic);
            this.splitContainer1.Size = new System.Drawing.Size(1165, 482);
            this.splitContainer1.SplitterDistance = 583;
            this.splitContainer1.TabIndex = 143;
            // 
            // btnFindNew
            // 
            this.btnFindNew.Location = new System.Drawing.Point(363, 8);
            this.btnFindNew.Name = "btnFindNew";
            this.btnFindNew.Size = new System.Drawing.Size(75, 23);
            this.btnFindNew.TabIndex = 143;
            this.btnFindNew.Text = "Trova";
            this.btnFindNew.UseVisualStyleBackColor = true;
            this.btnFindNew.Click += new System.EventHandler(this.btnFindNew_Click);
            // 
            // txtSearchNew
            // 
            this.txtSearchNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchNew.Location = new System.Drawing.Point(445, 8);
            this.txtSearchNew.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchNew.Name = "txtSearchNew";
            this.txtSearchNew.Size = new System.Drawing.Size(135, 24);
            this.txtSearchNew.TabIndex = 141;
            this.txtSearchNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewDescription
            // 
            this.txtNewDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewDescription.Location = new System.Drawing.Point(3, 373);
            this.txtNewDescription.Multiline = true;
            this.txtNewDescription.Name = "txtNewDescription";
            this.txtNewDescription.Size = new System.Drawing.Size(577, 106);
            this.txtNewDescription.TabIndex = 134;
            // 
            // btnFindOld
            // 
            this.btnFindOld.Location = new System.Drawing.Point(359, 9);
            this.btnFindOld.Name = "btnFindOld";
            this.btnFindOld.Size = new System.Drawing.Size(75, 23);
            this.btnFindOld.TabIndex = 144;
            this.btnFindOld.Text = "Trova";
            this.btnFindOld.UseVisualStyleBackColor = true;
            this.btnFindOld.Click += new System.EventHandler(this.btnFindOld_Click);
            // 
            // txtSearchOld
            // 
            this.txtSearchOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchOld.Location = new System.Drawing.Point(441, 8);
            this.txtSearchOld.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchOld.Name = "txtSearchOld";
            this.txtSearchOld.Size = new System.Drawing.Size(134, 24);
            this.txtSearchOld.TabIndex = 143;
            this.txtSearchOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOldDescription
            // 
            this.txtOldDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldDescription.Location = new System.Drawing.Point(3, 373);
            this.txtOldDescription.Multiline = true;
            this.txtOldDescription.Name = "txtOldDescription";
            this.txtOldDescription.Size = new System.Drawing.Size(572, 106);
            this.txtOldDescription.TabIndex = 136;
            // 
            // BtnSaveNewTree
            // 
            this.BtnSaveNewTree.Location = new System.Drawing.Point(518, 120);
            this.BtnSaveNewTree.Name = "BtnSaveNewTree";
            this.BtnSaveNewTree.Size = new System.Drawing.Size(75, 46);
            this.BtnSaveNewTree.TabIndex = 144;
            this.BtnSaveNewTree.Text = "Salva nuovo";
            this.BtnSaveNewTree.UseVisualStyleBackColor = true;
            this.BtnSaveNewTree.Click += new System.EventHandler(this.BtnSaveNewTree_Click);
            // 
            // picNewOnly
            // 
            this.picNewOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picNewOnly.BackColor = System.Drawing.Color.Pink;
            this.picNewOnly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picNewOnly.Location = new System.Drawing.Point(920, 137);
            this.picNewOnly.Name = "picNewOnly";
            this.picNewOnly.Size = new System.Drawing.Size(27, 29);
            this.picNewOnly.TabIndex = 145;
            this.picNewOnly.TabStop = false;
            this.toolTip1.SetToolTip(this.picNewOnly, "Nodo nuovo");
            // 
            // chkNewOnly
            // 
            this.chkNewOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNewOnly.AutoSize = true;
            this.chkNewOnly.Location = new System.Drawing.Point(926, 120);
            this.chkNewOnly.Name = "chkNewOnly";
            this.chkNewOnly.Size = new System.Drawing.Size(15, 14);
            this.chkNewOnly.TabIndex = 146;
            this.chkNewOnly.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(965, 120);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 148;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // picOldOnly
            // 
            this.picOldOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picOldOnly.BackColor = System.Drawing.Color.Pink;
            this.picOldOnly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOldOnly.Location = new System.Drawing.Point(959, 137);
            this.picOldOnly.Name = "picOldOnly";
            this.picOldOnly.Size = new System.Drawing.Size(27, 29);
            this.picOldOnly.TabIndex = 147;
            this.picOldOnly.TabStop = false;
            this.toolTip1.SetToolTip(this.picOldOnly, "Nodo vecchio");
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(1004, 120);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 150;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // picSameId
            // 
            this.picSameId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSameId.BackColor = System.Drawing.Color.Pink;
            this.picSameId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSameId.Location = new System.Drawing.Point(998, 137);
            this.picSameId.Name = "picSameId";
            this.picSameId.Size = new System.Drawing.Size(27, 29);
            this.picSameId.TabIndex = 149;
            this.picSameId.TabStop = false;
            this.toolTip1.SetToolTip(this.picSameId, "Stesso Id diversa descrizione");
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(1043, 120);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 152;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // picSameName
            // 
            this.picSameName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSameName.BackColor = System.Drawing.Color.Pink;
            this.picSameName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSameName.Location = new System.Drawing.Point(1037, 137);
            this.picSameName.Name = "picSameName";
            this.picSameName.Size = new System.Drawing.Size(27, 29);
            this.picSameName.TabIndex = 151;
            this.picSameName.TabStop = false;
            this.toolTip1.SetToolTip(this.picSameName, "Stesso nome");
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(1082, 120);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 154;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // picSameDesc
            // 
            this.picSameDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSameDesc.BackColor = System.Drawing.Color.Pink;
            this.picSameDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSameDesc.Location = new System.Drawing.Point(1076, 137);
            this.picSameDesc.Name = "picSameDesc";
            this.picSameDesc.Size = new System.Drawing.Size(27, 29);
            this.picSameDesc.TabIndex = 153;
            this.picSameDesc.TabStop = false;
            this.toolTip1.SetToolTip(this.picSameDesc, "Stessa descrizione");
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(1121, 120);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 156;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // picSameNodeChangedParent
            // 
            this.picSameNodeChangedParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSameNodeChangedParent.BackColor = System.Drawing.Color.Pink;
            this.picSameNodeChangedParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSameNodeChangedParent.Location = new System.Drawing.Point(1115, 137);
            this.picSameNodeChangedParent.Name = "picSameNodeChangedParent";
            this.picSameNodeChangedParent.Size = new System.Drawing.Size(27, 29);
            this.picSameNodeChangedParent.TabIndex = 155;
            this.picSameNodeChangedParent.TabStop = false;
            this.toolTip1.SetToolTip(this.picSameNodeChangedParent, "Stesso nome con nodo padre diverso");
            // 
            // checkBox6
            // 
            this.checkBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(1160, 120);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 158;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // picSameNodeChangedPosition
            // 
            this.picSameNodeChangedPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSameNodeChangedPosition.BackColor = System.Drawing.Color.Pink;
            this.picSameNodeChangedPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSameNodeChangedPosition.Location = new System.Drawing.Point(1154, 137);
            this.picSameNodeChangedPosition.Name = "picSameNodeChangedPosition";
            this.picSameNodeChangedPosition.Size = new System.Drawing.Size(27, 29);
            this.picSameNodeChangedPosition.TabIndex = 157;
            this.picSameNodeChangedPosition.TabStop = false;
            // 
            // btnTemporary
            // 
            this.btnTemporary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemporary.BackColor = System.Drawing.Color.Red;
            this.btnTemporary.ForeColor = System.Drawing.Color.Yellow;
            this.btnTemporary.Location = new System.Drawing.Point(644, 120);
            this.btnTemporary.Name = "btnTemporary";
            this.btnTemporary.Size = new System.Drawing.Size(270, 50);
            this.btnTemporary.TabIndex = 165;
            this.btnTemporary.Text = "Danger area. Backup before saving in this window!";
            this.toolTip1.SetToolTip(this.btnTemporary, "Lancio dei link e programmi legati alla classe");
            this.btnTemporary.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(391, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 15);
            this.label3.TabIndex = 166;
            this.label3.Text = "Drag destra->sinistra";
            // 
            // btnBeheaded
            // 
            this.btnBeheaded.Location = new System.Drawing.Point(84, 120);
            this.btnBeheaded.Name = "btnBeheaded";
            this.btnBeheaded.Size = new System.Drawing.Size(68, 46);
            this.btnBeheaded.TabIndex = 167;
            this.btnBeheaded.Text = "No padre";
            this.toolTip1.SetToolTip(this.btnBeheaded, "Mostra i nodi dell\'albero che non hanno padre");
            this.btnBeheaded.UseCompatibleTextRendering = true;
            this.btnBeheaded.UseVisualStyleBackColor = true;
            this.btnBeheaded.Click += new System.EventHandler(this.btnBeheaded_Click);
            // 
            // frmTopicsRecover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1266, 652);
            this.Controls.Add(this.btnBeheaded);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTemporary);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.picSameNodeChangedPosition);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.picSameNodeChangedParent);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.picSameDesc);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.picSameName);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.picSameId);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.picOldOnly);
            this.Controls.Add(this.chkNewOnly);
            this.Controls.Add(this.picNewOnly);
            this.Controls.Add(this.BtnSaveNewTree);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnCopyOldNew);
            this.Controls.Add(this.chkErasedId);
            this.Controls.Add(this.chkCheckChangesSameId);
            this.Controls.Add(this.btnRecover);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPathOldDatabase);
            this.Controls.Add(this.btnPathOldDatabase);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFileOldDatabase);
            this.Controls.Add(this.btnFileOldDatabase);
            this.Controls.Add(this.lblPathDatabase);
            this.Controls.Add(this.txtPathNewDatabase);
            this.Controls.Add(this.btnPathNewDatabase);
            this.Controls.Add(this.lblFileDatabase);
            this.Controls.Add(this.txtFileNewDatabase);
            this.Controls.Add(this.btnFileNewDatabase);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTopicsRecover";
            this.Text = "Recupera argomenti";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTopicsRecover_FormClosing);
            this.Load += new System.EventHandler(this.frmTopicsRecover_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picNewOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOldOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSameId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSameName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSameDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSameNodeChangedParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSameNodeChangedPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPathDatabase;
        private System.Windows.Forms.TextBox txtPathNewDatabase;
        private System.Windows.Forms.Button btnPathNewDatabase;
        private System.Windows.Forms.Label lblFileDatabase;
        private System.Windows.Forms.TextBox txtFileNewDatabase;
        private System.Windows.Forms.Button btnFileNewDatabase;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPathOldDatabase;
        private System.Windows.Forms.Button btnPathOldDatabase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFileOldDatabase;
        private System.Windows.Forms.Button btnFileOldDatabase;
        private System.Windows.Forms.Button btnRecover;
        private System.Windows.Forms.CheckBox chkCheckChangesSameId;
        private System.Windows.Forms.CheckBox chkErasedId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView trwNewTopics;
        private System.Windows.Forms.TreeView trwOldTopics;
        private System.Windows.Forms.TextBox txtNewTopicName;
        private System.Windows.Forms.TextBox txtOldTopicName;
        private System.Windows.Forms.TextBox txtCodOldTopic;
        private System.Windows.Forms.TextBox txtCodNewTopic;
        private System.Windows.Forms.Label lblIdNewTopic;
        private System.Windows.Forms.Label lblIdOldTopic;
        private System.Windows.Forms.Button btnCopyOldNew;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtNewDescription;
        private System.Windows.Forms.TextBox txtOldDescription;
        private System.Windows.Forms.TextBox txtSearchNew;
        private System.Windows.Forms.TextBox txtSearchOld;
        private System.Windows.Forms.Button btnFindNew;
        private System.Windows.Forms.Button btnFindOld;
        private System.Windows.Forms.Button BtnSaveNewTree;
        private System.Windows.Forms.PictureBox picNewOnly;
        private System.Windows.Forms.CheckBox chkNewOnly;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox picOldOnly;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.PictureBox picSameId;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.PictureBox picSameName;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.PictureBox picSameDesc;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.PictureBox picSameNodeChangedParent;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.PictureBox picSameNodeChangedPosition;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnTemporary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBeheaded;
    }
}