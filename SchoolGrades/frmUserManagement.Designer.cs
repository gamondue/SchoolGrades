
namespace SchoolGrades
{
    partial class frmUserManagement
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
            this.lstUser = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lbCognomeUtente = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstUser
            // 
            this.lstUser.FormattingEnabled = true;
            this.lstUser.ItemHeight = 20;
            this.lstUser.Location = new System.Drawing.Point(12, 12);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(120, 404);
            this.lstUser.TabIndex = 0;
            this.lstUser.SelectedIndexChanged += new System.EventHandler(this.lstUser_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(156, 345);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 71);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Salva";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(156, 35);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnly = true;
            this.txtLastName.Size = new System.Drawing.Size(132, 27);
            this.txtLastName.TabIndex = 2;
            // 
            // lbCognomeUtente
            // 
            this.lbCognomeUtente.AutoSize = true;
            this.lbCognomeUtente.Location = new System.Drawing.Point(156, 12);
            this.lbCognomeUtente.Name = "lbCognomeUtente";
            this.lbCognomeUtente.Size = new System.Drawing.Size(77, 20);
            this.lbCognomeUtente.TabIndex = 4;
            this.lbCognomeUtente.Text = "Cognome:";
            // 
            // frmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbCognomeUtente);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstUser);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Name = "frmUserManagement";
            this.Text = "Gestione Utenti";
            this.Load += new System.EventHandler(this.frmUserManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lbCognomeUtente;
    }
}