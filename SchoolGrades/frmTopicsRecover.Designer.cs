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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopicsRecover));
            lblPathDatabase = new System.Windows.Forms.Label();
            txtPathNewDatabase = new System.Windows.Forms.TextBox();
            btnPathNewDatabase = new System.Windows.Forms.Button();
            lblFileDatabase = new System.Windows.Forms.Label();
            txtFileNewDatabase = new System.Windows.Forms.TextBox();
            btnFileNewDatabase = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            label6 = new System.Windows.Forms.Label();
            txtPathOldDatabase = new System.Windows.Forms.TextBox();
            btnPathOldDatabase = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            txtFileOldDatabase = new System.Windows.Forms.TextBox();
            btnFileOldDatabase = new System.Windows.Forms.Button();
            btnRecover = new System.Windows.Forms.Button();
            chkCheckChangesSameId = new System.Windows.Forms.CheckBox();
            chkErasedId = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            trwNewTopics = new System.Windows.Forms.TreeView();
            trwOldTopics = new System.Windows.Forms.TreeView();
            txtNewTopicName = new System.Windows.Forms.TextBox();
            txtOldTopicName = new System.Windows.Forms.TextBox();
            txtCodOldTopic = new System.Windows.Forms.TextBox();
            txtCodNewTopic = new System.Windows.Forms.TextBox();
            lblIdNewTopic = new System.Windows.Forms.Label();
            lblIdOldTopic = new System.Windows.Forms.Label();
            btnCopyOldNew = new System.Windows.Forms.Button();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            btnFindNew = new System.Windows.Forms.Button();
            txtSearchNew = new System.Windows.Forms.TextBox();
            txtNewDescription = new System.Windows.Forms.TextBox();
            btnFindOld = new System.Windows.Forms.Button();
            txtSearchOld = new System.Windows.Forms.TextBox();
            txtOldDescription = new System.Windows.Forms.TextBox();
            BtnSaveNewTree = new System.Windows.Forms.Button();
            picNewOnly = new System.Windows.Forms.PictureBox();
            chkNewOnly = new System.Windows.Forms.CheckBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            picOldOnly = new System.Windows.Forms.PictureBox();
            checkBox2 = new System.Windows.Forms.CheckBox();
            picSameId = new System.Windows.Forms.PictureBox();
            checkBox3 = new System.Windows.Forms.CheckBox();
            picSameName = new System.Windows.Forms.PictureBox();
            checkBox4 = new System.Windows.Forms.CheckBox();
            picSameDesc = new System.Windows.Forms.PictureBox();
            checkBox5 = new System.Windows.Forms.CheckBox();
            picSameNodeChangedParent = new System.Windows.Forms.PictureBox();
            checkBox6 = new System.Windows.Forms.CheckBox();
            picSameNodeChangedPosition = new System.Windows.Forms.PictureBox();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            btnBeheaded = new System.Windows.Forms.Button();
            btnTemporary = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picNewOnly).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOldOnly).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSameId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSameName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSameDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSameNodeChangedParent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSameNodeChangedPosition).BeginInit();
            SuspendLayout();
            // 
            // lblPathDatabase
            // 
            lblPathDatabase.AutoSize = true;
            lblPathDatabase.Location = new System.Drawing.Point(10, 10);
            lblPathDatabase.Name = "lblPathDatabase";
            lblPathDatabase.Size = new System.Drawing.Size(125, 18);
            lblPathDatabase.TabIndex = 102;
            lblPathDatabase.Text = "Cartella file nuovo";
            // 
            // txtPathNewDatabase
            // 
            txtPathNewDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtPathNewDatabase.Location = new System.Drawing.Point(13, 31);
            txtPathNewDatabase.Margin = new System.Windows.Forms.Padding(4);
            txtPathNewDatabase.Name = "txtPathNewDatabase";
            txtPathNewDatabase.Size = new System.Drawing.Size(762, 24);
            txtPathNewDatabase.TabIndex = 100;
            // 
            // btnPathNewDatabase
            // 
            btnPathNewDatabase.BackColor = System.Drawing.Color.Transparent;
            btnPathNewDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPathNewDatabase.ForeColor = System.Drawing.Color.DarkBlue;
            btnPathNewDatabase.Location = new System.Drawing.Point(785, 22);
            btnPathNewDatabase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnPathNewDatabase.Name = "btnPathNewDatabase";
            btnPathNewDatabase.Size = new System.Drawing.Size(54, 40);
            btnPathNewDatabase.TabIndex = 101;
            btnPathNewDatabase.Text = "..";
            btnPathNewDatabase.UseVisualStyleBackColor = false;
            btnPathNewDatabase.Click += btnPathNewDatabase_Click;
            // 
            // lblFileDatabase
            // 
            lblFileDatabase.AutoSize = true;
            lblFileDatabase.Location = new System.Drawing.Point(848, 10);
            lblFileDatabase.Name = "lblFileDatabase";
            lblFileDatabase.Size = new System.Drawing.Size(76, 18);
            lblFileDatabase.TabIndex = 99;
            lblFileDatabase.Text = "File nuovo";
            // 
            // txtFileNewDatabase
            // 
            txtFileNewDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtFileNewDatabase.Location = new System.Drawing.Point(851, 31);
            txtFileNewDatabase.Margin = new System.Windows.Forms.Padding(4);
            txtFileNewDatabase.Name = "txtFileNewDatabase";
            txtFileNewDatabase.Size = new System.Drawing.Size(344, 24);
            txtFileNewDatabase.TabIndex = 97;
            // 
            // btnFileNewDatabase
            // 
            btnFileNewDatabase.BackColor = System.Drawing.Color.Transparent;
            btnFileNewDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnFileNewDatabase.ForeColor = System.Drawing.Color.DarkBlue;
            btnFileNewDatabase.Location = new System.Drawing.Point(1205, 22);
            btnFileNewDatabase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnFileNewDatabase.Name = "btnFileNewDatabase";
            btnFileNewDatabase.Size = new System.Drawing.Size(54, 40);
            btnFileNewDatabase.TabIndex = 98;
            btnFileNewDatabase.Text = "..";
            btnFileNewDatabase.UseVisualStyleBackColor = false;
            btnFileNewDatabase.Click += btnFileNewDatabase_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(9, 68);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(135, 18);
            label6.TabIndex = 125;
            label6.Text = "Cartella file vecchio";
            // 
            // txtPathOldDatabase
            // 
            txtPathOldDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtPathOldDatabase.Location = new System.Drawing.Point(12, 89);
            txtPathOldDatabase.Margin = new System.Windows.Forms.Padding(4);
            txtPathOldDatabase.Name = "txtPathOldDatabase";
            txtPathOldDatabase.Size = new System.Drawing.Size(762, 24);
            txtPathOldDatabase.TabIndex = 123;
            // 
            // btnPathOldDatabase
            // 
            btnPathOldDatabase.BackColor = System.Drawing.Color.Transparent;
            btnPathOldDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPathOldDatabase.ForeColor = System.Drawing.Color.DarkBlue;
            btnPathOldDatabase.Location = new System.Drawing.Point(784, 80);
            btnPathOldDatabase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnPathOldDatabase.Name = "btnPathOldDatabase";
            btnPathOldDatabase.Size = new System.Drawing.Size(54, 40);
            btnPathOldDatabase.TabIndex = 124;
            btnPathOldDatabase.Text = "..";
            btnPathOldDatabase.UseVisualStyleBackColor = false;
            btnPathOldDatabase.Click += btnPathOldDatabase_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(847, 68);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(86, 18);
            label7.TabIndex = 122;
            label7.Text = "File vecchio";
            // 
            // txtFileOldDatabase
            // 
            txtFileOldDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtFileOldDatabase.Location = new System.Drawing.Point(850, 89);
            txtFileOldDatabase.Margin = new System.Windows.Forms.Padding(4);
            txtFileOldDatabase.Name = "txtFileOldDatabase";
            txtFileOldDatabase.Size = new System.Drawing.Size(344, 24);
            txtFileOldDatabase.TabIndex = 120;
            // 
            // btnFileOldDatabase
            // 
            btnFileOldDatabase.BackColor = System.Drawing.Color.Transparent;
            btnFileOldDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnFileOldDatabase.ForeColor = System.Drawing.Color.DarkBlue;
            btnFileOldDatabase.Location = new System.Drawing.Point(1204, 80);
            btnFileOldDatabase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnFileOldDatabase.Name = "btnFileOldDatabase";
            btnFileOldDatabase.Size = new System.Drawing.Size(54, 40);
            btnFileOldDatabase.TabIndex = 121;
            btnFileOldDatabase.Text = "..";
            btnFileOldDatabase.UseVisualStyleBackColor = false;
            btnFileOldDatabase.Click += btnFileOldDatabase_Click;
            // 
            // btnRecover
            // 
            btnRecover.Location = new System.Drawing.Point(12, 120);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new System.Drawing.Size(66, 46);
            btnRecover.TabIndex = 126;
            btnRecover.Text = "Importa";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
            // 
            // chkCheckChangesSameId
            // 
            chkCheckChangesSameId.AutoSize = true;
            chkCheckChangesSameId.Location = new System.Drawing.Point(158, 144);
            chkCheckChangesSameId.Name = "chkCheckChangesSameId";
            chkCheckChangesSameId.Size = new System.Drawing.Size(246, 22);
            chkCheckChangesSameId.TabIndex = 127;
            chkCheckChangesSameId.Text = "Argomenti con stesso Id cambiati";
            chkCheckChangesSameId.UseVisualStyleBackColor = true;
            // 
            // chkErasedId
            // 
            chkErasedId.AutoSize = true;
            chkErasedId.Checked = true;
            chkErasedId.CheckState = System.Windows.Forms.CheckState.Checked;
            chkErasedId.Location = new System.Drawing.Point(158, 120);
            chkErasedId.Name = "chkErasedId";
            chkErasedId.Size = new System.Drawing.Size(209, 22);
            chkErasedId.TabIndex = 128;
            chkErasedId.Text = "Argomenti con Id cancellato";
            chkErasedId.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(127, 18);
            label1.TabIndex = 129;
            label1.Text = "Albero file vecchio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(4, 11);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(117, 18);
            label2.TabIndex = 130;
            label2.Text = "Albero file nuovo";
            // 
            // trwNewTopics
            // 
            trwNewTopics.AllowDrop = true;
            trwNewTopics.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trwNewTopics.Location = new System.Drawing.Point(3, 39);
            trwNewTopics.Name = "trwNewTopics";
            trwNewTopics.Size = new System.Drawing.Size(577, 292);
            trwNewTopics.TabIndex = 131;
            // 
            // trwOldTopics
            // 
            trwOldTopics.AllowDrop = true;
            trwOldTopics.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trwOldTopics.Location = new System.Drawing.Point(3, 40);
            trwOldTopics.Name = "trwOldTopics";
            trwOldTopics.Size = new System.Drawing.Size(572, 292);
            trwOldTopics.TabIndex = 134;
            // 
            // txtNewTopicName
            // 
            txtNewTopicName.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtNewTopicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtNewTopicName.Location = new System.Drawing.Point(3, 335);
            txtNewTopicName.Multiline = true;
            txtNewTopicName.Name = "txtNewTopicName";
            txtNewTopicName.Size = new System.Drawing.Size(577, 32);
            txtNewTopicName.TabIndex = 136;
            // 
            // txtOldTopicName
            // 
            txtOldTopicName.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtOldTopicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtOldTopicName.Location = new System.Drawing.Point(3, 335);
            txtOldTopicName.Multiline = true;
            txtOldTopicName.Name = "txtOldTopicName";
            txtOldTopicName.Size = new System.Drawing.Size(572, 32);
            txtOldTopicName.TabIndex = 137;
            // 
            // txtCodOldTopic
            // 
            txtCodOldTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtCodOldTopic.Location = new System.Drawing.Point(254, 9);
            txtCodOldTopic.Margin = new System.Windows.Forms.Padding(4);
            txtCodOldTopic.Name = "txtCodOldTopic";
            txtCodOldTopic.Size = new System.Drawing.Size(70, 24);
            txtCodOldTopic.TabIndex = 138;
            txtCodOldTopic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCodNewTopic
            // 
            txtCodNewTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtCodNewTopic.Location = new System.Drawing.Point(252, 8);
            txtCodNewTopic.Margin = new System.Windows.Forms.Padding(4);
            txtCodNewTopic.Name = "txtCodNewTopic";
            txtCodNewTopic.Size = new System.Drawing.Size(70, 24);
            txtCodNewTopic.TabIndex = 139;
            txtCodNewTopic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIdNewTopic
            // 
            lblIdNewTopic.AutoSize = true;
            lblIdNewTopic.Location = new System.Drawing.Point(133, 11);
            lblIdNewTopic.Name = "lblIdNewTopic";
            lblIdNewTopic.Size = new System.Drawing.Size(112, 18);
            lblIdNewTopic.TabIndex = 140;
            lblIdNewTopic.Text = "Cod.argomento";
            // 
            // lblIdOldTopic
            // 
            lblIdOldTopic.AutoSize = true;
            lblIdOldTopic.Location = new System.Drawing.Point(136, 11);
            lblIdOldTopic.Name = "lblIdOldTopic";
            lblIdOldTopic.Size = new System.Drawing.Size(112, 18);
            lblIdOldTopic.TabIndex = 141;
            lblIdOldTopic.Text = "Cod.argomento";
            // 
            // btnCopyOldNew
            // 
            btnCopyOldNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCopyOldNew.Location = new System.Drawing.Point(1184, 209);
            btnCopyOldNew.Name = "btnCopyOldNew";
            btnCopyOldNew.Size = new System.Drawing.Size(75, 42);
            btnCopyOldNew.TabIndex = 142;
            btnCopyOldNew.Text = "<-";
            btnCopyOldNew.UseVisualStyleBackColor = true;
            btnCopyOldNew.Click += btnCopyOldNew_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splitContainer1.Location = new System.Drawing.Point(13, 172);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnFindNew);
            splitContainer1.Panel1.Controls.Add(txtSearchNew);
            splitContainer1.Panel1.Controls.Add(txtNewDescription);
            splitContainer1.Panel1.Controls.Add(trwNewTopics);
            splitContainer1.Panel1.Controls.Add(lblIdNewTopic);
            splitContainer1.Panel1.Controls.Add(txtNewTopicName);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(txtCodNewTopic);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnFindOld);
            splitContainer1.Panel2.Controls.Add(txtSearchOld);
            splitContainer1.Panel2.Controls.Add(txtOldDescription);
            splitContainer1.Panel2.Controls.Add(trwOldTopics);
            splitContainer1.Panel2.Controls.Add(txtOldTopicName);
            splitContainer1.Panel2.Controls.Add(lblIdOldTopic);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(txtCodOldTopic);
            splitContainer1.Size = new System.Drawing.Size(1165, 482);
            splitContainer1.SplitterDistance = 583;
            splitContainer1.TabIndex = 143;
            // 
            // btnFindNew
            // 
            btnFindNew.Location = new System.Drawing.Point(363, 8);
            btnFindNew.Name = "btnFindNew";
            btnFindNew.Size = new System.Drawing.Size(75, 23);
            btnFindNew.TabIndex = 143;
            btnFindNew.Text = "Trova";
            btnFindNew.UseVisualStyleBackColor = true;
            btnFindNew.Click += btnFindNew_Click;
            // 
            // txtSearchNew
            // 
            txtSearchNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtSearchNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSearchNew.Location = new System.Drawing.Point(445, 8);
            txtSearchNew.Margin = new System.Windows.Forms.Padding(4);
            txtSearchNew.Name = "txtSearchNew";
            txtSearchNew.Size = new System.Drawing.Size(135, 24);
            txtSearchNew.TabIndex = 141;
            txtSearchNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewDescription
            // 
            txtNewDescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtNewDescription.Location = new System.Drawing.Point(3, 373);
            txtNewDescription.Multiline = true;
            txtNewDescription.Name = "txtNewDescription";
            txtNewDescription.Size = new System.Drawing.Size(577, 106);
            txtNewDescription.TabIndex = 134;
            // 
            // btnFindOld
            // 
            btnFindOld.Location = new System.Drawing.Point(359, 9);
            btnFindOld.Name = "btnFindOld";
            btnFindOld.Size = new System.Drawing.Size(75, 23);
            btnFindOld.TabIndex = 144;
            btnFindOld.Text = "Trova";
            btnFindOld.UseVisualStyleBackColor = true;
            btnFindOld.Click += btnFindOld_Click;
            // 
            // txtSearchOld
            // 
            txtSearchOld.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtSearchOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSearchOld.Location = new System.Drawing.Point(441, 8);
            txtSearchOld.Margin = new System.Windows.Forms.Padding(4);
            txtSearchOld.Name = "txtSearchOld";
            txtSearchOld.Size = new System.Drawing.Size(134, 24);
            txtSearchOld.TabIndex = 143;
            txtSearchOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOldDescription
            // 
            txtOldDescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtOldDescription.Location = new System.Drawing.Point(3, 373);
            txtOldDescription.Multiline = true;
            txtOldDescription.Name = "txtOldDescription";
            txtOldDescription.Size = new System.Drawing.Size(572, 106);
            txtOldDescription.TabIndex = 136;
            // 
            // BtnSaveNewTree
            // 
            BtnSaveNewTree.Location = new System.Drawing.Point(518, 120);
            BtnSaveNewTree.Name = "BtnSaveNewTree";
            BtnSaveNewTree.Size = new System.Drawing.Size(75, 46);
            BtnSaveNewTree.TabIndex = 144;
            BtnSaveNewTree.Text = "Salva nuovo";
            BtnSaveNewTree.UseVisualStyleBackColor = true;
            BtnSaveNewTree.Click += BtnSaveNewTree_Click;
            // 
            // picNewOnly
            // 
            picNewOnly.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            picNewOnly.BackColor = System.Drawing.Color.Pink;
            picNewOnly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picNewOnly.Location = new System.Drawing.Point(920, 137);
            picNewOnly.Name = "picNewOnly";
            picNewOnly.Size = new System.Drawing.Size(27, 29);
            picNewOnly.TabIndex = 145;
            picNewOnly.TabStop = false;
            toolTip1.SetToolTip(picNewOnly, "Nodo nuovo");
            // 
            // chkNewOnly
            // 
            chkNewOnly.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkNewOnly.AutoSize = true;
            chkNewOnly.Location = new System.Drawing.Point(926, 120);
            chkNewOnly.Name = "chkNewOnly";
            chkNewOnly.Size = new System.Drawing.Size(15, 14);
            chkNewOnly.TabIndex = 146;
            chkNewOnly.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(965, 120);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(15, 14);
            checkBox1.TabIndex = 148;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // picOldOnly
            // 
            picOldOnly.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            picOldOnly.BackColor = System.Drawing.Color.Pink;
            picOldOnly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picOldOnly.Location = new System.Drawing.Point(959, 137);
            picOldOnly.Name = "picOldOnly";
            picOldOnly.Size = new System.Drawing.Size(27, 29);
            picOldOnly.TabIndex = 147;
            picOldOnly.TabStop = false;
            toolTip1.SetToolTip(picOldOnly, "Nodo vecchio");
            // 
            // checkBox2
            // 
            checkBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            checkBox2.AutoSize = true;
            checkBox2.Location = new System.Drawing.Point(1004, 120);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(15, 14);
            checkBox2.TabIndex = 150;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // picSameId
            // 
            picSameId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            picSameId.BackColor = System.Drawing.Color.Pink;
            picSameId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picSameId.Location = new System.Drawing.Point(998, 137);
            picSameId.Name = "picSameId";
            picSameId.Size = new System.Drawing.Size(27, 29);
            picSameId.TabIndex = 149;
            picSameId.TabStop = false;
            toolTip1.SetToolTip(picSameId, "Stesso Id diversa descrizione");
            // 
            // checkBox3
            // 
            checkBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            checkBox3.AutoSize = true;
            checkBox3.Location = new System.Drawing.Point(1043, 120);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(15, 14);
            checkBox3.TabIndex = 152;
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // picSameName
            // 
            picSameName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            picSameName.BackColor = System.Drawing.Color.Pink;
            picSameName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picSameName.Location = new System.Drawing.Point(1037, 137);
            picSameName.Name = "picSameName";
            picSameName.Size = new System.Drawing.Size(27, 29);
            picSameName.TabIndex = 151;
            picSameName.TabStop = false;
            toolTip1.SetToolTip(picSameName, "Stesso nome");
            // 
            // checkBox4
            // 
            checkBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            checkBox4.AutoSize = true;
            checkBox4.Location = new System.Drawing.Point(1082, 120);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new System.Drawing.Size(15, 14);
            checkBox4.TabIndex = 154;
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // picSameDesc
            // 
            picSameDesc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            picSameDesc.BackColor = System.Drawing.Color.Pink;
            picSameDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picSameDesc.Location = new System.Drawing.Point(1076, 137);
            picSameDesc.Name = "picSameDesc";
            picSameDesc.Size = new System.Drawing.Size(27, 29);
            picSameDesc.TabIndex = 153;
            picSameDesc.TabStop = false;
            toolTip1.SetToolTip(picSameDesc, "Stessa descrizione");
            // 
            // checkBox5
            // 
            checkBox5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            checkBox5.AutoSize = true;
            checkBox5.Location = new System.Drawing.Point(1121, 120);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new System.Drawing.Size(15, 14);
            checkBox5.TabIndex = 156;
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // picSameNodeChangedParent
            // 
            picSameNodeChangedParent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            picSameNodeChangedParent.BackColor = System.Drawing.Color.Pink;
            picSameNodeChangedParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picSameNodeChangedParent.Location = new System.Drawing.Point(1115, 137);
            picSameNodeChangedParent.Name = "picSameNodeChangedParent";
            picSameNodeChangedParent.Size = new System.Drawing.Size(27, 29);
            picSameNodeChangedParent.TabIndex = 155;
            picSameNodeChangedParent.TabStop = false;
            toolTip1.SetToolTip(picSameNodeChangedParent, "Stesso nome con nodo padre diverso");
            // 
            // checkBox6
            // 
            checkBox6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            checkBox6.AutoSize = true;
            checkBox6.Location = new System.Drawing.Point(1160, 120);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new System.Drawing.Size(15, 14);
            checkBox6.TabIndex = 158;
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // picSameNodeChangedPosition
            // 
            picSameNodeChangedPosition.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            picSameNodeChangedPosition.BackColor = System.Drawing.Color.Pink;
            picSameNodeChangedPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picSameNodeChangedPosition.Location = new System.Drawing.Point(1154, 137);
            picSameNodeChangedPosition.Name = "picSameNodeChangedPosition";
            picSameNodeChangedPosition.Size = new System.Drawing.Size(27, 29);
            picSameNodeChangedPosition.TabIndex = 157;
            picSameNodeChangedPosition.TabStop = false;
            // 
            // btnBeheaded
            // 
            btnBeheaded.Location = new System.Drawing.Point(84, 120);
            btnBeheaded.Name = "btnBeheaded";
            btnBeheaded.Size = new System.Drawing.Size(68, 46);
            btnBeheaded.TabIndex = 167;
            btnBeheaded.Text = "No padre";
            toolTip1.SetToolTip(btnBeheaded, "Mostra i nodi dell'albero che non hanno padre");
            btnBeheaded.UseCompatibleTextRendering = true;
            btnBeheaded.UseVisualStyleBackColor = true;
            btnBeheaded.Click += btnBeheaded_Click;
            // 
            // btnTemporary
            // 
            btnTemporary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnTemporary.BackColor = System.Drawing.Color.Red;
            btnTemporary.ForeColor = System.Drawing.Color.Yellow;
            btnTemporary.Location = new System.Drawing.Point(599, 110);
            btnTemporary.Name = "btnTemporary";
            btnTemporary.Size = new System.Drawing.Size(315, 64);
            btnTemporary.TabIndex = 165;
            btnTemporary.Text = "Danger area. This code makes heavy changes to the database and is barely tested.       Backup before saving in this window!";
            toolTip1.SetToolTip(btnTemporary, "Lancio dei link e programmi legati alla classe");
            btnTemporary.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.BackColor = System.Drawing.Color.Red;
            button1.ForeColor = System.Drawing.Color.Yellow;
            button1.Location = new System.Drawing.Point(158, 1);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(436, 36);
            button1.TabIndex = 168;
            button1.Text = "PAGINA SPERIMENTALE. Codice non finito e non verificato. ";
            toolTip1.SetToolTip(button1, "Lancio dei link e programmi legati alla classe");
            button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(391, 136);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(121, 15);
            label3.TabIndex = 166;
            label3.Text = "Drag destra->sinistra";
            // 
            // frmTopicsRecover
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(1266, 652);
            Controls.Add(button1);
            Controls.Add(btnBeheaded);
            Controls.Add(label3);
            Controls.Add(btnTemporary);
            Controls.Add(checkBox6);
            Controls.Add(picSameNodeChangedPosition);
            Controls.Add(checkBox5);
            Controls.Add(picSameNodeChangedParent);
            Controls.Add(checkBox4);
            Controls.Add(picSameDesc);
            Controls.Add(checkBox3);
            Controls.Add(picSameName);
            Controls.Add(checkBox2);
            Controls.Add(picSameId);
            Controls.Add(checkBox1);
            Controls.Add(picOldOnly);
            Controls.Add(chkNewOnly);
            Controls.Add(picNewOnly);
            Controls.Add(BtnSaveNewTree);
            Controls.Add(splitContainer1);
            Controls.Add(btnCopyOldNew);
            Controls.Add(chkErasedId);
            Controls.Add(chkCheckChangesSameId);
            Controls.Add(btnRecover);
            Controls.Add(label6);
            Controls.Add(txtPathOldDatabase);
            Controls.Add(btnPathOldDatabase);
            Controls.Add(label7);
            Controls.Add(txtFileOldDatabase);
            Controls.Add(btnFileOldDatabase);
            Controls.Add(lblPathDatabase);
            Controls.Add(txtPathNewDatabase);
            Controls.Add(btnPathNewDatabase);
            Controls.Add(lblFileDatabase);
            Controls.Add(txtFileNewDatabase);
            Controls.Add(btnFileNewDatabase);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmTopicsRecover";
            Text = "Recupera argomenti";
            FormClosing += frmTopicsRecover_FormClosing;
            Load += frmTopicsRecover_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picNewOnly).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOldOnly).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSameId).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSameName).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSameDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSameNodeChangedParent).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSameNodeChangedPosition).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Button button1;
    }
}