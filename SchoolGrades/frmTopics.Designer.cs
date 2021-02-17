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
            this.btnAddNode = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTopicName = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.lblEdits = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblFind = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblExplain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trwTopics
            // 
            this.trwTopics.AllowDrop = true;
            this.trwTopics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trwTopics.Location = new System.Drawing.Point(12, 12);
            this.trwTopics.Name = "trwTopics";
            this.trwTopics.Size = new System.Drawing.Size(476, 417);
            this.trwTopics.TabIndex = 2;
            this.trwTopics.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trwTopics_AfterSelect);
            // 
            // btnSaveTree
            // 
            this.btnSaveTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveTree.Location = new System.Drawing.Point(513, 217);
            this.btnSaveTree.Name = "btnSaveTree";
            this.btnSaveTree.Size = new System.Drawing.Size(124, 61);
            this.btnSaveTree.TabIndex = 4;
            this.btnSaveTree.Text = "Salva argomenti (F5)";
            this.btnSaveTree.UseVisualStyleBackColor = true;
            this.btnSaveTree.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddNode
            // 
            this.btnAddNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNode.Location = new System.Drawing.Point(513, 284);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(124, 61);
            this.btnAddNode.TabIndex = 5;
            this.btnAddNode.Text = "Aggiungi";
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 514);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(87, 18);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Descrizione";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(16, 535);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(621, 110);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // txtTopicName
            // 
            this.txtTopicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTopicName.Location = new System.Drawing.Point(16, 472);
            this.txtTopicName.Multiline = true;
            this.txtTopicName.Name = "txtTopicName";
            this.txtTopicName.Size = new System.Drawing.Size(476, 39);
            this.txtTopicName.TabIndex = 3;
            this.txtTopicName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoose.Location = new System.Drawing.Point(513, 351);
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
            this.lblEdits.Location = new System.Drawing.Point(13, 451);
            this.lblEdits.Name = "lblEdits";
            this.lblEdits.Size = new System.Drawing.Size(81, 18);
            this.lblEdits.TabIndex = 7;
            this.lblEdits.Text = "Argomento";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(513, 471);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 61);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Elimina";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblFind
            // 
            this.lblFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(505, 0);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(46, 18);
            this.lblFind.TabIndex = 9;
            this.lblFind.Text = "Trova";
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.Location = new System.Drawing.Point(508, 21);
            this.txtFind.Multiline = true;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(139, 39);
            this.txtFind.TabIndex = 1;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(513, 77);
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
            this.lblExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplain.Location = new System.Drawing.Point(9, 434);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(337, 16);
            this.lblExplain.TabIndex = 10;
            this.lblExplain.Text = "Drag per spostare su nodo padre, Ctrl Drag per fratello. ";
            this.lblExplain.Click += new System.EventHandler(this.lblExplain_Click);
            // 
            // frmTopics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(659, 657);
            this.Controls.Add(this.lblExplain);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblEdits);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.txtTopicName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnAddNode);
            this.Controls.Add(this.btnSaveTree);
            this.Controls.Add(this.trwTopics);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTopics";
            this.Text = "Argomenti";
            this.Load += new System.EventHandler(this.frmTopic_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTopics_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trwTopics;
        private System.Windows.Forms.Button btnSaveTree;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTopicName;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Label lblEdits;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblExplain;
    }
}