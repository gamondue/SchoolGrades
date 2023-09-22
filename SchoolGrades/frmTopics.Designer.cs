namespace SchoolGrades
{
    partial class frmTopics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopics));
            trwTopics = new System.Windows.Forms.TreeView();
            btnSaveTree = new System.Windows.Forms.Button();
            lblDescription = new System.Windows.Forms.Label();
            txtTopicDescription = new System.Windows.Forms.TextBox();
            txtTopicName = new System.Windows.Forms.TextBox();
            btnChoose = new System.Windows.Forms.Button();
            lblEdits = new System.Windows.Forms.Label();
            lblFind = new System.Windows.Forms.Label();
            txtTopicSearchString = new System.Windows.Forms.TextBox();
            btnFind = new System.Windows.Forms.Button();
            lblExplain = new System.Windows.Forms.Label();
            btnDelete = new System.Windows.Forms.Button();
            btnAddNodeSon = new System.Windows.Forms.Button();
            rdbOrSearch = new System.Windows.Forms.RadioButton();
            rdbAndSearch = new System.Windows.Forms.RadioButton();
            rdbStringSearch = new System.Windows.Forms.RadioButton();
            btnAddNodeBrother = new System.Windows.Forms.Button();
            btnFindUnderNode = new System.Windows.Forms.Button();
            chkFindAll = new System.Windows.Forms.CheckBox();
            btnArgFreemind = new System.Windows.Forms.Button();
            btnQuestions = new System.Windows.Forms.Button();
            splcHorizontal = new System.Windows.Forms.SplitContainer();
            chkSearchInDescriptions = new System.Windows.Forms.CheckBox();
            chkCaseInsensitive = new System.Windows.Forms.CheckBox();
            chkAllWord = new System.Windows.Forms.CheckBox();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splcHorizontal).BeginInit();
            splcHorizontal.Panel1.SuspendLayout();
            splcHorizontal.Panel2.SuspendLayout();
            splcHorizontal.SuspendLayout();
            SuspendLayout();
            // 
            // trwTopics
            // 
            trwTopics.AllowDrop = true;
            trwTopics.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trwTopics.Location = new System.Drawing.Point(0, 4);
            trwTopics.Name = "trwTopics";
            trwTopics.Size = new System.Drawing.Size(475, 510);
            trwTopics.TabIndex = 2;
            // 
            // btnSaveTree
            // 
            btnSaveTree.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSaveTree.Location = new System.Drawing.Point(508, 251);
            btnSaveTree.Name = "btnSaveTree";
            btnSaveTree.Size = new System.Drawing.Size(124, 61);
            btnSaveTree.TabIndex = 4;
            btnSaveTree.Text = "Salva argomenti (F5)";
            toolTip1.SetToolTip(btnSaveTree, "Salvataggio di tutti gli argomenti");
            btnSaveTree.UseVisualStyleBackColor = true;
            btnSaveTree.Click += btnSave_Click;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new System.Drawing.Point(3, 81);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(87, 18);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Descrizione";
            // 
            // txtTopicDescription
            // 
            txtTopicDescription.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTopicDescription.Location = new System.Drawing.Point(0, 99);
            txtTopicDescription.Multiline = true;
            txtTopicDescription.Name = "txtTopicDescription";
            txtTopicDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtTopicDescription.Size = new System.Drawing.Size(475, 110);
            txtTopicDescription.TabIndex = 4;
            // 
            // txtTopicName
            // 
            txtTopicName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTopicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtTopicName.Location = new System.Drawing.Point(0, 39);
            txtTopicName.Multiline = true;
            txtTopicName.Name = "txtTopicName";
            txtTopicName.Size = new System.Drawing.Size(475, 39);
            txtTopicName.TabIndex = 3;
            // 
            // btnChoose
            // 
            btnChoose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnChoose.Location = new System.Drawing.Point(508, 455);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(124, 61);
            btnChoose.TabIndex = 7;
            btnChoose.Text = "Scegli";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click;
            // 
            // lblEdits
            // 
            lblEdits.AutoSize = true;
            lblEdits.Location = new System.Drawing.Point(3, 17);
            lblEdits.Name = "lblEdits";
            lblEdits.Size = new System.Drawing.Size(81, 18);
            lblEdits.TabIndex = 7;
            lblEdits.Text = "Argomento";
            // 
            // lblFind
            // 
            lblFind.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblFind.AutoSize = true;
            lblFind.Location = new System.Drawing.Point(500, 0);
            lblFind.Name = "lblFind";
            lblFind.Size = new System.Drawing.Size(46, 18);
            lblFind.TabIndex = 9;
            lblFind.Text = "Trova";
            // 
            // txtTopicSearchString
            // 
            txtTopicSearchString.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtTopicSearchString.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtTopicSearchString.Location = new System.Drawing.Point(503, 21);
            txtTopicSearchString.Multiline = true;
            txtTopicSearchString.Name = "txtTopicSearchString";
            txtTopicSearchString.Size = new System.Drawing.Size(139, 39);
            txtTopicSearchString.TabIndex = 1;
            // 
            // btnFind
            // 
            btnFind.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFind.Location = new System.Drawing.Point(508, 115);
            btnFind.Name = "btnFind";
            btnFind.Size = new System.Drawing.Size(124, 61);
            btnFind.TabIndex = 2;
            btnFind.Text = "Trova (F3)";
            toolTip1.SetToolTip(btnFind, "Effettua ricerca");
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // lblExplain
            // 
            lblExplain.AutoSize = true;
            lblExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblExplain.Location = new System.Drawing.Point(3, 4);
            lblExplain.Name = "lblExplain";
            lblExplain.Size = new System.Drawing.Size(267, 13);
            lblExplain.TabIndex = 10;
            lblExplain.Text = "Drag per spostare su nodo padre, Ctrl Drag per fratello. ";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnDelete.Location = new System.Drawing.Point(508, 659);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(124, 61);
            btnDelete.TabIndex = 126;
            btnDelete.Text = "Elimina (Canc)";
            toolTip1.SetToolTip(btnDelete, "Cancella l'argomento selezionato e tutti i suoi figli");
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAddNodeSon
            // 
            btnAddNodeSon.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddNodeSon.Location = new System.Drawing.Point(508, 319);
            btnAddNodeSon.Name = "btnAddNodeSon";
            btnAddNodeSon.Size = new System.Drawing.Size(124, 61);
            btnAddNodeSon.TabIndex = 127;
            btnAddNodeSon.Text = "Aggiungi figlio (Ins)";
            toolTip1.SetToolTip(btnAddNodeSon, "Aggiungi nuovo argomento sotto al selezionato");
            btnAddNodeSon.UseVisualStyleBackColor = true;
            btnAddNodeSon.Click += btnAddNode_Click;
            // 
            // rdbOrSearch
            // 
            rdbOrSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rdbOrSearch.AutoSize = true;
            rdbOrSearch.Enabled = false;
            rdbOrSearch.Location = new System.Drawing.Point(586, 21);
            rdbOrSearch.Name = "rdbOrSearch";
            rdbOrSearch.Size = new System.Drawing.Size(40, 22);
            rdbOrSearch.TabIndex = 153;
            rdbOrSearch.Text = " ||";
            rdbOrSearch.UseVisualStyleBackColor = true;
            rdbOrSearch.Visible = false;
            // 
            // rdbAndSearch
            // 
            rdbAndSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rdbAndSearch.AutoSize = true;
            rdbAndSearch.Enabled = false;
            rdbAndSearch.Location = new System.Drawing.Point(627, 21);
            rdbAndSearch.Name = "rdbAndSearch";
            rdbAndSearch.Size = new System.Drawing.Size(50, 22);
            rdbAndSearch.TabIndex = 152;
            rdbAndSearch.Text = " &&&&";
            rdbAndSearch.UseVisualStyleBackColor = true;
            rdbAndSearch.Visible = false;
            // 
            // rdbStringSearch
            // 
            rdbStringSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rdbStringSearch.AutoSize = true;
            rdbStringSearch.Checked = true;
            rdbStringSearch.Location = new System.Drawing.Point(539, 21);
            rdbStringSearch.Name = "rdbStringSearch";
            rdbStringSearch.Size = new System.Drawing.Size(46, 22);
            rdbStringSearch.TabIndex = 151;
            rdbStringSearch.TabStop = true;
            rdbStringSearch.Text = "Txt";
            rdbStringSearch.UseVisualStyleBackColor = true;
            rdbStringSearch.Visible = false;
            // 
            // btnAddNodeBrother
            // 
            btnAddNodeBrother.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddNodeBrother.Location = new System.Drawing.Point(508, 387);
            btnAddNodeBrother.Name = "btnAddNodeBrother";
            btnAddNodeBrother.Size = new System.Drawing.Size(124, 61);
            btnAddNodeBrother.TabIndex = 154;
            btnAddNodeBrother.Text = "Agg. fratello (Shift+Ins)";
            toolTip1.SetToolTip(btnAddNodeBrother, "Aggiungi nuovo argomento a fianco del selezionato");
            btnAddNodeBrother.UseVisualStyleBackColor = true;
            btnAddNodeBrother.Click += btnAddNodeBrother_Click;
            // 
            // btnFindUnderNode
            // 
            btnFindUnderNode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFindUnderNode.Location = new System.Drawing.Point(508, 183);
            btnFindUnderNode.Name = "btnFindUnderNode";
            btnFindUnderNode.Size = new System.Drawing.Size(124, 61);
            btnFindUnderNode.TabIndex = 155;
            btnFindUnderNode.Text = "Trova sotto (Shift+F3)";
            toolTip1.SetToolTip(btnFindUnderNode, "Ricerca sotto il nodo selezionato");
            btnFindUnderNode.UseVisualStyleBackColor = true;
            btnFindUnderNode.Click += btnFindUnderNode_Click;
            // 
            // chkFindAll
            // 
            chkFindAll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkFindAll.AutoSize = true;
            chkFindAll.Location = new System.Drawing.Point(555, -1);
            chkFindAll.Name = "chkFindAll";
            chkFindAll.Size = new System.Drawing.Size(87, 22);
            chkFindAll.TabIndex = 156;
            chkFindAll.Text = "trova tutti";
            toolTip1.SetToolTip(chkFindAll, "Trova e segna ogni occorrenza  della stringa");
            chkFindAll.UseVisualStyleBackColor = true;
            // 
            // btnArgFreemind
            // 
            btnArgFreemind.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnArgFreemind.Location = new System.Drawing.Point(508, 523);
            btnArgFreemind.Name = "btnArgFreemind";
            btnArgFreemind.Size = new System.Drawing.Size(124, 61);
            btnArgFreemind.TabIndex = 157;
            btnArgFreemind.Text = "Argom. Freemind";
            btnArgFreemind.UseVisualStyleBackColor = true;
            btnArgFreemind.Click += btnArgFreemind_Click;
            // 
            // btnQuestions
            // 
            btnQuestions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnQuestions.Location = new System.Drawing.Point(508, 591);
            btnQuestions.Name = "btnQuestions";
            btnQuestions.Size = new System.Drawing.Size(124, 61);
            btnQuestions.TabIndex = 158;
            btnQuestions.Text = "Domande";
            btnQuestions.UseVisualStyleBackColor = true;
            btnQuestions.Click += btnQuestions_Click;
            // 
            // splcHorizontal
            // 
            splcHorizontal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splcHorizontal.Location = new System.Drawing.Point(9, 0);
            splcHorizontal.Name = "splcHorizontal";
            splcHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splcHorizontal.Panel1
            // 
            splcHorizontal.Panel1.Controls.Add(trwTopics);
            // 
            // splcHorizontal.Panel2
            // 
            splcHorizontal.Panel2.Controls.Add(lblEdits);
            splcHorizontal.Panel2.Controls.Add(txtTopicDescription);
            splcHorizontal.Panel2.Controls.Add(lblExplain);
            splcHorizontal.Panel2.Controls.Add(txtTopicName);
            splcHorizontal.Panel2.Controls.Add(lblDescription);
            splcHorizontal.Size = new System.Drawing.Size(478, 732);
            splcHorizontal.SplitterDistance = 519;
            splcHorizontal.TabIndex = 159;
            // 
            // chkSearchInDescriptions
            // 
            chkSearchInDescriptions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkSearchInDescriptions.AutoSize = true;
            chkSearchInDescriptions.Checked = true;
            chkSearchInDescriptions.CheckState = System.Windows.Forms.CheckState.Checked;
            chkSearchInDescriptions.Location = new System.Drawing.Point(529, 66);
            chkSearchInDescriptions.Name = "chkSearchInDescriptions";
            chkSearchInDescriptions.Size = new System.Drawing.Size(97, 22);
            chkSearchInDescriptions.TabIndex = 162;
            chkSearchInDescriptions.Text = "In Descriz.";
            toolTip1.SetToolTip(chkSearchInDescriptions, "Ricerca anche in descrizione");
            chkSearchInDescriptions.UseVisualStyleBackColor = true;
            // 
            // chkCaseInsensitive
            // 
            chkCaseInsensitive.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkCaseInsensitive.AutoSize = true;
            chkCaseInsensitive.Checked = true;
            chkCaseInsensitive.CheckState = System.Windows.Forms.CheckState.Checked;
            chkCaseInsensitive.Location = new System.Drawing.Point(566, 87);
            chkCaseInsensitive.Name = "chkCaseInsensitive";
            chkCaseInsensitive.Size = new System.Drawing.Size(82, 22);
            chkCaseInsensitive.TabIndex = 161;
            chkCaseInsensitive.Text = "ma && mi";
            toolTip1.SetToolTip(chkCaseInsensitive, "Ricerca case insensitive");
            chkCaseInsensitive.UseVisualStyleBackColor = true;
            // 
            // chkAllWord
            // 
            chkAllWord.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkAllWord.AutoSize = true;
            chkAllWord.Location = new System.Drawing.Point(499, 87);
            chkAllWord.Name = "chkAllWord";
            chkAllWord.Size = new System.Drawing.Size(70, 22);
            chkAllWord.TabIndex = 160;
            chkAllWord.Text = "Parola";
            toolTip1.SetToolTip(chkAllWord, "Ricerca a parola intera");
            chkAllWord.UseVisualStyleBackColor = true;
            // 
            // frmTopics
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(654, 732);
            Controls.Add(chkSearchInDescriptions);
            Controls.Add(chkCaseInsensitive);
            Controls.Add(chkAllWord);
            Controls.Add(splcHorizontal);
            Controls.Add(btnQuestions);
            Controls.Add(btnArgFreemind);
            Controls.Add(chkFindAll);
            Controls.Add(btnFindUnderNode);
            Controls.Add(btnAddNodeBrother);
            Controls.Add(rdbOrSearch);
            Controls.Add(rdbAndSearch);
            Controls.Add(rdbStringSearch);
            Controls.Add(btnAddNodeSon);
            Controls.Add(btnDelete);
            Controls.Add(btnFind);
            Controls.Add(lblFind);
            Controls.Add(txtTopicSearchString);
            Controls.Add(btnChoose);
            Controls.Add(btnSaveTree);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmTopics";
            Text = "Argomenti";
            Load += frmTopics_Load;
            KeyDown += frmTopics_KeyDown;
            splcHorizontal.Panel1.ResumeLayout(false);
            splcHorizontal.Panel2.ResumeLayout(false);
            splcHorizontal.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splcHorizontal).EndInit();
            splcHorizontal.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TreeView trwTopics;
        private System.Windows.Forms.Button btnSaveTree;
        private System.Windows.Forms.Button btnAddNodeSon;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTopicName;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Label lblEdits;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.TextBox txtTopicSearchString;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblExplain;
        private System.Windows.Forms.RadioButton rdbOrSearch;
        private System.Windows.Forms.RadioButton rdbAndSearch;
        private System.Windows.Forms.RadioButton rdbStringSearch;
        private System.Windows.Forms.Button btnAddNodeBrother;
        private System.Windows.Forms.Button btnFindUnderNode;
        private System.Windows.Forms.CheckBox chkFindAll;
        private System.Windows.Forms.Button btnArgFreemind;
        private System.Windows.Forms.Button btnQuestions;
        private System.Windows.Forms.TextBox txtTopicDescription;
        private System.Windows.Forms.SplitContainer splcHorizontal;
        private System.Windows.Forms.CheckBox chkSearchInDescriptions;
        private System.Windows.Forms.CheckBox chkCaseSensitive;
        private System.Windows.Forms.CheckBox chkAllWord;
        private System.Windows.Forms.CheckBox chkCaseInSensitive;
        private System.Windows.Forms.CheckBox chkCaseInsensitive;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}