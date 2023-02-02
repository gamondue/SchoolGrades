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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopics));
            this.trwTopics = new System.Windows.Forms.TreeView();
            this.btnSaveTree = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtTopicDescription = new System.Windows.Forms.TextBox();
            this.txtTopicName = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.lblEdits = new System.Windows.Forms.Label();
            this.lblFind = new System.Windows.Forms.Label();
            this.txtTopicFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblExplain = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddNodeSon = new System.Windows.Forms.Button();
            this.rdbOrSearch = new System.Windows.Forms.RadioButton();
            this.rdbAndSearch = new System.Windows.Forms.RadioButton();
            this.rdbStringSearch = new System.Windows.Forms.RadioButton();
            this.btnAddNodeBrother = new System.Windows.Forms.Button();
            this.btnFindUnderNode = new System.Windows.Forms.Button();
            this.chkFindAll = new System.Windows.Forms.CheckBox();
            this.btnArgFreemind = new System.Windows.Forms.Button();
            this.btnQuestions = new System.Windows.Forms.Button();
            this.splcHorizontal = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splcHorizontal)).BeginInit();
            this.splcHorizontal.Panel1.SuspendLayout();
            this.splcHorizontal.Panel2.SuspendLayout();
            this.splcHorizontal.SuspendLayout();
            this.SuspendLayout();
            // 
            // trwTopics
            // 
            this.trwTopics.AllowDrop = true;
            this.trwTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trwTopics.Location = new System.Drawing.Point(0, 4);
            this.trwTopics.Name = "trwTopics";
            this.trwTopics.Size = new System.Drawing.Size(475, 510);
            this.trwTopics.TabIndex = 2;
            this.trwTopics.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trwTopics_AfterSelect);
            // 
            // btnSaveTree
            // 
            this.btnSaveTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveTree.Location = new System.Drawing.Point(508, 256);
            this.btnSaveTree.Name = "btnSaveTree";
            this.btnSaveTree.Size = new System.Drawing.Size(124, 61);
            this.btnSaveTree.TabIndex = 4;
            this.btnSaveTree.Text = "Salva argomenti (F5)";
            this.btnSaveTree.UseVisualStyleBackColor = true;
            this.btnSaveTree.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 81);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(87, 18);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Descrizione";
            // 
            // txtTopicDescription
            // 
            this.txtTopicDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopicDescription.Location = new System.Drawing.Point(0, 99);
            this.txtTopicDescription.Multiline = true;
            this.txtTopicDescription.Name = "txtTopicDescription";
            this.txtTopicDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTopicDescription.Size = new System.Drawing.Size(475, 110);
            this.txtTopicDescription.TabIndex = 4;
            // 
            // txtTopicName
            // 
            this.txtTopicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTopicName.Location = new System.Drawing.Point(0, 39);
            this.txtTopicName.Multiline = true;
            this.txtTopicName.Name = "txtTopicName";
            this.txtTopicName.Size = new System.Drawing.Size(475, 39);
            this.txtTopicName.TabIndex = 3;
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoose.Location = new System.Drawing.Point(508, 453);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(124, 61);
            this.btnChoose.TabIndex = 7;
            this.btnChoose.Text = "Scegli";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // lblEdits
            // 
            this.lblEdits.AutoSize = true;
            this.lblEdits.Location = new System.Drawing.Point(3, 17);
            this.lblEdits.Name = "lblEdits";
            this.lblEdits.Size = new System.Drawing.Size(81, 18);
            this.lblEdits.TabIndex = 7;
            this.lblEdits.Text = "Argomento";
            // 
            // lblFind
            // 
            this.lblFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(500, 0);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(46, 18);
            this.lblFind.TabIndex = 9;
            this.lblFind.Text = "Trova";
            // 
            // txtTopicFind
            // 
            this.txtTopicFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopicFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTopicFind.Location = new System.Drawing.Point(503, 21);
            this.txtTopicFind.Multiline = true;
            this.txtTopicFind.Name = "txtTopicFind";
            this.txtTopicFind.Size = new System.Drawing.Size(139, 39);
            this.txtTopicFind.TabIndex = 1;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(508, 94);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(124, 61);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Trova (F3)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lblExplain
            // 
            this.lblExplain.AutoSize = true;
            this.lblExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblExplain.Location = new System.Drawing.Point(3, 4);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(267, 13);
            this.lblExplain.TabIndex = 10;
            this.lblExplain.Text = "Drag per spostare su nodo padre, Ctrl Drag per fratello. ";
            this.lblExplain.Click += new System.EventHandler(this.lblExplain_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(508, 659);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 61);
            this.btnDelete.TabIndex = 126;
            this.btnDelete.Text = "Elimina (Canc)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddNodeSon
            // 
            this.btnAddNodeSon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNodeSon.Location = new System.Drawing.Point(508, 317);
            this.btnAddNodeSon.Name = "btnAddNodeSon";
            this.btnAddNodeSon.Size = new System.Drawing.Size(124, 61);
            this.btnAddNodeSon.TabIndex = 127;
            this.btnAddNodeSon.Text = "Aggiungi figlio (Ins)";
            this.btnAddNodeSon.UseVisualStyleBackColor = true;
            this.btnAddNodeSon.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // rdbOrSearch
            // 
            this.rdbOrSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbOrSearch.AutoSize = true;
            this.rdbOrSearch.Enabled = false;
            this.rdbOrSearch.Location = new System.Drawing.Point(550, 66);
            this.rdbOrSearch.Name = "rdbOrSearch";
            this.rdbOrSearch.Size = new System.Drawing.Size(40, 22);
            this.rdbOrSearch.TabIndex = 153;
            this.rdbOrSearch.Text = " ||";
            this.rdbOrSearch.UseVisualStyleBackColor = true;
            // 
            // rdbAndSearch
            // 
            this.rdbAndSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbAndSearch.AutoSize = true;
            this.rdbAndSearch.Enabled = false;
            this.rdbAndSearch.Location = new System.Drawing.Point(591, 66);
            this.rdbAndSearch.Name = "rdbAndSearch";
            this.rdbAndSearch.Size = new System.Drawing.Size(50, 22);
            this.rdbAndSearch.TabIndex = 152;
            this.rdbAndSearch.Text = " &&&&";
            this.rdbAndSearch.UseVisualStyleBackColor = true;
            // 
            // rdbStringSearch
            // 
            this.rdbStringSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbStringSearch.AutoSize = true;
            this.rdbStringSearch.Checked = true;
            this.rdbStringSearch.Location = new System.Drawing.Point(503, 66);
            this.rdbStringSearch.Name = "rdbStringSearch";
            this.rdbStringSearch.Size = new System.Drawing.Size(46, 22);
            this.rdbStringSearch.TabIndex = 151;
            this.rdbStringSearch.TabStop = true;
            this.rdbStringSearch.Text = "Txt";
            this.rdbStringSearch.UseVisualStyleBackColor = true;
            // 
            // btnAddNodeBrother
            // 
            this.btnAddNodeBrother.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNodeBrother.Location = new System.Drawing.Point(508, 378);
            this.btnAddNodeBrother.Name = "btnAddNodeBrother";
            this.btnAddNodeBrother.Size = new System.Drawing.Size(124, 61);
            this.btnAddNodeBrother.TabIndex = 154;
            this.btnAddNodeBrother.Text = "Agg. fratello (Shift+Ins)";
            this.btnAddNodeBrother.UseVisualStyleBackColor = true;
            this.btnAddNodeBrother.Click += new System.EventHandler(this.btnAddNodeBrother_Click);
            // 
            // btnFindUnderNode
            // 
            this.btnFindUnderNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindUnderNode.Location = new System.Drawing.Point(508, 161);
            this.btnFindUnderNode.Name = "btnFindUnderNode";
            this.btnFindUnderNode.Size = new System.Drawing.Size(124, 61);
            this.btnFindUnderNode.TabIndex = 155;
            this.btnFindUnderNode.Text = "Trova sotto (Shift+F3)";
            this.btnFindUnderNode.UseVisualStyleBackColor = true;
            this.btnFindUnderNode.Click += new System.EventHandler(this.btnFindUnderNode_Click);
            // 
            // chkFindAll
            // 
            this.chkFindAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFindAll.AutoSize = true;
            this.chkFindAll.Location = new System.Drawing.Point(508, 228);
            this.chkFindAll.Name = "chkFindAll";
            this.chkFindAll.Size = new System.Drawing.Size(87, 22);
            this.chkFindAll.TabIndex = 156;
            this.chkFindAll.Text = "trova tutti";
            this.chkFindAll.UseVisualStyleBackColor = true;
            // 
            // btnArgFreemind
            // 
            this.btnArgFreemind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArgFreemind.Location = new System.Drawing.Point(508, 520);
            this.btnArgFreemind.Name = "btnArgFreemind";
            this.btnArgFreemind.Size = new System.Drawing.Size(124, 61);
            this.btnArgFreemind.TabIndex = 157;
            this.btnArgFreemind.Text = "Argom. Freemind";
            this.btnArgFreemind.UseVisualStyleBackColor = true;
            this.btnArgFreemind.Click += new System.EventHandler(this.btnArgFreemind_Click);
            // 
            // btnQuestions
            // 
            this.btnQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuestions.Location = new System.Drawing.Point(508, 587);
            this.btnQuestions.Name = "btnQuestions";
            this.btnQuestions.Size = new System.Drawing.Size(124, 61);
            this.btnQuestions.TabIndex = 158;
            this.btnQuestions.Text = "Domande";
            this.btnQuestions.UseVisualStyleBackColor = true;
            this.btnQuestions.Click += new System.EventHandler(this.btnQuestions_Click);
            // 
            // splcHorizontal
            // 
            this.splcHorizontal.Location = new System.Drawing.Point(9, 0);
            this.splcHorizontal.Name = "splcHorizontal";
            this.splcHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splcHorizontal.Panel1
            // 
            this.splcHorizontal.Panel1.Controls.Add(this.trwTopics);
            // 
            // splcHorizontal.Panel2
            // 
            this.splcHorizontal.Panel2.Controls.Add(this.lblEdits);
            this.splcHorizontal.Panel2.Controls.Add(this.txtTopicDescription);
            this.splcHorizontal.Panel2.Controls.Add(this.lblExplain);
            this.splcHorizontal.Panel2.Controls.Add(this.txtTopicName);
            this.splcHorizontal.Panel2.Controls.Add(this.lblDescription);
            this.splcHorizontal.Size = new System.Drawing.Size(478, 732);
            this.splcHorizontal.SplitterDistance = 519;
            this.splcHorizontal.TabIndex = 159;
            // 
            // frmTopics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(654, 732);
            this.Controls.Add(this.splcHorizontal);
            this.Controls.Add(this.btnQuestions);
            this.Controls.Add(this.btnArgFreemind);
            this.Controls.Add(this.chkFindAll);
            this.Controls.Add(this.btnFindUnderNode);
            this.Controls.Add(this.btnAddNodeBrother);
            this.Controls.Add(this.rdbOrSearch);
            this.Controls.Add(this.rdbAndSearch);
            this.Controls.Add(this.rdbStringSearch);
            this.Controls.Add(this.btnAddNodeSon);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.txtTopicFind);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnSaveTree);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTopics";
            this.Text = "Argomenti";
            this.Load += new System.EventHandler(this.frmTopics_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTopics_KeyDown);
            this.splcHorizontal.Panel1.ResumeLayout(false);
            this.splcHorizontal.Panel2.ResumeLayout(false);
            this.splcHorizontal.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcHorizontal)).EndInit();
            this.splcHorizontal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox txtTopicFind;
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
    }
}