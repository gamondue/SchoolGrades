namespace SchoolGrades
{
    partial class frmSchoolSubjectManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSchoolSubjectManagement));
            this.DgwSubjects = new System.Windows.Forms.DataGridView();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.picSubjectColor = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnErase = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgwSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSubjectColor)).BeginInit();
            this.SuspendLayout();
            // 
            // DgwSubjects
            // 
            this.DgwSubjects.AllowUserToAddRows = false;
            this.DgwSubjects.AllowUserToDeleteRows = false;
            this.DgwSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgwSubjects.Location = new System.Drawing.Point(3, 61);
            this.DgwSubjects.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DgwSubjects.Name = "DgwSubjects";
            this.DgwSubjects.Size = new System.Drawing.Size(1125, 276);
            this.DgwSubjects.TabIndex = 0;
            this.DgwSubjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwSubjects_CellClick);
            this.DgwSubjects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.btn_CellContentClick);
            this.DgwSubjects.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwSubjects_CellLeave);
            // 
            // picSubjectColor
            // 
            this.picSubjectColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSubjectColor.Location = new System.Drawing.Point(1134, 61);
            this.picSubjectColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picSubjectColor.Name = "picSubjectColor";
            this.picSubjectColor.Size = new System.Drawing.Size(59, 60);
            this.picSubjectColor.TabIndex = 2;
            this.picSubjectColor.TabStop = false;
            this.picSubjectColor.Click += new System.EventHandler(this.picSubjectColor_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1106, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 48);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnErase
            // 
            this.btnErase.Location = new System.Drawing.Point(982, 3);
            this.btnErase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(48, 48);
            this.btnErase.TabIndex = 4;
            this.btnErase.Text = "-";
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(926, 3);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 48);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmSchoolSubjectManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1200, 340);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnErase);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picSubjectColor);
            this.Controls.Add(this.DgwSubjects);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmSchoolSubjectManagement";
            this.Text = "Gestione materie";
            this.Load += new System.EventHandler(this.frmSchoolSubjectManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgwSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSubjectColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgwSubjects;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox picSubjectColor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.Button btnAdd;
    }
}