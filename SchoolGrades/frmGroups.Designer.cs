namespace SchoolGrades
{
    partial class frmGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroups));
            this.txtGroups = new System.Windows.Forms.TextBox();
            this.btnCreateFileGroups = new System.Windows.Forms.Button();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.lblStudentsPerGroup = new System.Windows.Forms.Label();
            this.txtStudentsPerGroup = new System.Windows.Forms.TextBox();
            this.grpGroups = new System.Windows.Forms.GroupBox();
            this.rdbGradesBalanced = new System.Windows.Forms.RadioButton();
            this.rbdGroupsRandom = new System.Windows.Forms.RadioButton();
            this.rdbGroupsBestGradesTogether = new System.Windows.Forms.RadioButton();
            this.btnCreateGroups = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNGroups = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalStudentsToGroup = new System.Windows.Forms.TextBox();
            this.grpGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGroups
            // 
            this.txtGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroups.Location = new System.Drawing.Point(0, 207);
            this.txtGroups.Multiline = true;
            this.txtGroups.Name = "txtGroups";
            this.txtGroups.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGroups.Size = new System.Drawing.Size(290, 530);
            this.txtGroups.TabIndex = 0;
            // 
            // btnCreateFileGroups
            // 
            this.btnCreateFileGroups.Location = new System.Drawing.Point(205, 12);
            this.btnCreateFileGroups.Name = "btnCreateFileGroups";
            this.btnCreateFileGroups.Size = new System.Drawing.Size(75, 53);
            this.btnCreateFileGroups.TabIndex = 1;
            this.btnCreateFileGroups.Text = "Crea file";
            this.btnCreateFileGroups.UseVisualStyleBackColor = true;
            this.btnCreateFileGroups.Click += new System.EventHandler(this.btnCreateFileGroups_Click);
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(12, 21);
            this.txtClass.Name = "txtClass";
            this.txtClass.ReadOnly = true;
            this.txtClass.Size = new System.Drawing.Size(160, 24);
            this.txtClass.TabIndex = 2;
            // 
            // lblStudentsPerGroup
            // 
            this.lblStudentsPerGroup.AutoSize = true;
            this.lblStudentsPerGroup.Location = new System.Drawing.Point(15, 157);
            this.lblStudentsPerGroup.Name = "lblStudentsPerGroup";
            this.lblStudentsPerGroup.Size = new System.Drawing.Size(94, 18);
            this.lblStudentsPerGroup.TabIndex = 140;
            this.lblStudentsPerGroup.Text = "Allievi/gruppo";
            // 
            // txtStudentsPerGroup
            // 
            this.txtStudentsPerGroup.Location = new System.Drawing.Point(115, 154);
            this.txtStudentsPerGroup.Name = "txtStudentsPerGroup";
            this.txtStudentsPerGroup.Size = new System.Drawing.Size(46, 24);
            this.txtStudentsPerGroup.TabIndex = 139;
            this.txtStudentsPerGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStudentsPerGroup.TextChanged += new System.EventHandler(this.txtStudentsPerGroup_TextChanged);
            // 
            // grpGroups
            // 
            this.grpGroups.Controls.Add(this.rdbGradesBalanced);
            this.grpGroups.Controls.Add(this.rbdGroupsRandom);
            this.grpGroups.Controls.Add(this.rdbGroupsBestGradesTogether);
            this.grpGroups.ForeColor = System.Drawing.Color.DarkBlue;
            this.grpGroups.Location = new System.Drawing.Point(12, 57);
            this.grpGroups.Name = "grpGroups";
            this.grpGroups.Size = new System.Drawing.Size(183, 94);
            this.grpGroups.TabIndex = 138;
            this.grpGroups.TabStop = false;
            this.grpGroups.Text = "Criteri raggruppamento";
            // 
            // rdbGradesBalanced
            // 
            this.rdbGradesBalanced.AutoSize = true;
            this.rdbGradesBalanced.Enabled = false;
            this.rdbGradesBalanced.Location = new System.Drawing.Point(6, 64);
            this.rdbGradesBalanced.Name = "rdbGradesBalanced";
            this.rdbGradesBalanced.Size = new System.Drawing.Size(116, 22);
            this.rdbGradesBalanced.TabIndex = 5;
            this.rdbGradesBalanced.Text = "Voti equilibrati";
            this.rdbGradesBalanced.UseVisualStyleBackColor = true;
            // 
            // rbdGroupsRandom
            // 
            this.rbdGroupsRandom.AutoSize = true;
            this.rbdGroupsRandom.Checked = true;
            this.rbdGroupsRandom.Location = new System.Drawing.Point(6, 23);
            this.rbdGroupsRandom.Name = "rbdGroupsRandom";
            this.rbdGroupsRandom.Size = new System.Drawing.Size(72, 22);
            this.rbdGroupsRandom.TabIndex = 1;
            this.rbdGroupsRandom.TabStop = true;
            this.rbdGroupsRandom.Text = "A caso";
            this.rbdGroupsRandom.UseVisualStyleBackColor = true;
            // 
            // rdbGroupsBestGradesTogether
            // 
            this.rdbGroupsBestGradesTogether.AutoSize = true;
            this.rdbGroupsBestGradesTogether.Enabled = false;
            this.rdbGroupsBestGradesTogether.Location = new System.Drawing.Point(6, 43);
            this.rdbGroupsBestGradesTogether.Name = "rdbGroupsBestGradesTogether";
            this.rdbGroupsBestGradesTogether.Size = new System.Drawing.Size(128, 22);
            this.rdbGroupsBestGradesTogether.TabIndex = 0;
            this.rdbGroupsBestGradesTogether.Text = "Voti alti insieme";
            this.rdbGroupsBestGradesTogether.UseVisualStyleBackColor = true;
            // 
            // btnCreateGroups
            // 
            this.btnCreateGroups.Location = new System.Drawing.Point(205, 148);
            this.btnCreateGroups.Name = "btnCreateGroups";
            this.btnCreateGroups.Size = new System.Drawing.Size(75, 53);
            this.btnCreateGroups.TabIndex = 141;
            this.btnCreateGroups.Text = "Crea gruppi";
            this.btnCreateGroups.UseVisualStyleBackColor = true;
            this.btnCreateGroups.Click += new System.EventHandler(this.btnCreateGroups_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 143;
            this.label1.Text = "N gruppi";
            // 
            // txtNGroups
            // 
            this.txtNGroups.Location = new System.Drawing.Point(115, 180);
            this.txtNGroups.Name = "txtNGroups";
            this.txtNGroups.Size = new System.Drawing.Size(46, 24);
            this.txtNGroups.TabIndex = 142;
            this.txtNGroups.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNGroups.TextChanged += new System.EventHandler(this.txtNGroups_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 145;
            this.label2.Text = "All. da raggr.";
            // 
            // txtTotalStudentsToGroup
            // 
            this.txtTotalStudentsToGroup.Enabled = false;
            this.txtTotalStudentsToGroup.Location = new System.Drawing.Point(218, 100);
            this.txtTotalStudentsToGroup.Name = "txtTotalStudentsToGroup";
            this.txtTotalStudentsToGroup.Size = new System.Drawing.Size(46, 24);
            this.txtTotalStudentsToGroup.TabIndex = 144;
            this.txtTotalStudentsToGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(292, 737);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalStudentsToGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNGroups);
            this.Controls.Add(this.btnCreateGroups);
            this.Controls.Add(this.lblStudentsPerGroup);
            this.Controls.Add(this.txtStudentsPerGroup);
            this.Controls.Add(this.grpGroups);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.btnCreateFileGroups);
            this.Controls.Add(this.txtGroups);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGroups";
            this.Text = "Gruppi";
            this.Load += new System.EventHandler(this.frmGroups_Load);
            this.grpGroups.ResumeLayout(false);
            this.grpGroups.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGroups;
        private System.Windows.Forms.Button btnCreateFileGroups;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblStudentsPerGroup;
        private System.Windows.Forms.TextBox txtStudentsPerGroup;
        private System.Windows.Forms.GroupBox grpGroups;
        private System.Windows.Forms.RadioButton rdbGradesBalanced;
        private System.Windows.Forms.RadioButton rbdGroupsRandom;
        private System.Windows.Forms.RadioButton rdbGroupsBestGradesTogether;
        private System.Windows.Forms.Button btnCreateGroups;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNGroups;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalStudentsToGroup;
    }
}