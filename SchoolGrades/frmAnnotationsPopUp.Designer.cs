
namespace SchoolGrades
{
    partial class frmAnnotationsPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnnotationsPopUp));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblCurrentStudent = new System.Windows.Forms.Label();
            this.dgwStudentsAllPopUpAnnotations = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStudentsAllPopUpAnnotations)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurrentStudent
            // 
            this.lblCurrentStudent.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentStudent.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentStudent.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCurrentStudent.Location = new System.Drawing.Point(0, -4);
            this.lblCurrentStudent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCurrentStudent.Name = "lblCurrentStudent";
            this.lblCurrentStudent.Size = new System.Drawing.Size(366, 53);
            this.lblCurrentStudent.TabIndex = 173;
            this.lblCurrentStudent.Text = "Annotazioni in evidenza";
            this.lblCurrentStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCurrentStudent.Click += new System.EventHandler(this.lblCurrentStudent_Click);
            // 
            // dgwStudentsAllPopUpAnnotations
            // 
            this.dgwStudentsAllPopUpAnnotations.AllowUserToAddRows = false;
            this.dgwStudentsAllPopUpAnnotations.AllowUserToDeleteRows = false;
            this.dgwStudentsAllPopUpAnnotations.AllowUserToOrderColumns = true;
            this.dgwStudentsAllPopUpAnnotations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwStudentsAllPopUpAnnotations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwStudentsAllPopUpAnnotations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwStudentsAllPopUpAnnotations.Location = new System.Drawing.Point(0, 53);
            this.dgwStudentsAllPopUpAnnotations.Margin = new System.Windows.Forms.Padding(4);
            this.dgwStudentsAllPopUpAnnotations.Name = "dgwStudentsAllPopUpAnnotations";
            this.dgwStudentsAllPopUpAnnotations.RowTemplate.Height = 24;
            this.dgwStudentsAllPopUpAnnotations.Size = new System.Drawing.Size(635, 203);
            this.dgwStudentsAllPopUpAnnotations.TabIndex = 171;
            this.dgwStudentsAllPopUpAnnotations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwStudentsAllPopUpAnnotations_CellClick);
            this.dgwStudentsAllPopUpAnnotations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwStudentsActivePopUpAnnotations_CellContentClick);
            this.dgwStudentsAllPopUpAnnotations.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwStudentsActivePopUpAnnotations_CellDoubleClick);
            // 
            // frmAnnotationsPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(639, 260);
            this.Controls.Add(this.dgwStudentsAllPopUpAnnotations);
            this.Controls.Add(this.lblCurrentStudent);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAnnotationsPopUp";
            this.Text = "Annotazioni in evidenza";
            this.Load += new System.EventHandler(this.frmAnnotationsPopUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwStudentsAllPopUpAnnotations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.CheckBox chkUseSchoolYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtIdStudent;
        private System.Windows.Forms.TextBox txtSchoolYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveModificationsStudent;
        private System.Windows.Forms.Button btnAddAnnotationGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveModificationsGroup;
        private System.Windows.Forms.Button btnAddAnnotationStudent;
        private System.Windows.Forms.Button btnRemoveAnnotationStudent;
        private System.Windows.Forms.Button btnRemoveAnnotationGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdAnnotation;
        private System.Windows.Forms.CheckBox chkCurrentAnnotationActive;
        private System.Windows.Forms.CheckBox chkShowOnlyActive;
        private System.Windows.Forms.TextBox txtAnnotation;
        private System.Windows.Forms.Label lblCurrentStudent;
        private System.Windows.Forms.DataGridView dgwStudentsAllPopUpAnnotations;
    }
}