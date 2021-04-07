
namespace SchoolGrades
{
    partial class frmGestionePassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtVecchiaPassword = new System.Windows.Forms.TextBox();
            this.txtNuovaPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVerificaPassword = new System.Windows.Forms.Button();
            this.btnConfermaPassword = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUtente = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(48, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inserire la vecchia password:";
            // 
            // txtVecchiaPassword
            // 
            this.txtVecchiaPassword.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtVecchiaPassword.Location = new System.Drawing.Point(310, 147);
            this.txtVecchiaPassword.Name = "txtVecchiaPassword";
            this.txtVecchiaPassword.Size = new System.Drawing.Size(293, 31);
            this.txtVecchiaPassword.TabIndex = 1;
            // 
            // txtNuovaPassword
            // 
            this.txtNuovaPassword.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNuovaPassword.Location = new System.Drawing.Point(310, 240);
            this.txtNuovaPassword.Name = "txtNuovaPassword";
            this.txtNuovaPassword.ReadOnly = true;
            this.txtNuovaPassword.Size = new System.Drawing.Size(293, 31);
            this.txtNuovaPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(48, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inserire la nuova password:";
            // 
            // btnVerificaPassword
            // 
            this.btnVerificaPassword.Location = new System.Drawing.Point(766, 150);
            this.btnVerificaPassword.Name = "btnVerificaPassword";
            this.btnVerificaPassword.Size = new System.Drawing.Size(94, 29);
            this.btnVerificaPassword.TabIndex = 4;
            this.btnVerificaPassword.Text = "verifica";
            this.btnVerificaPassword.UseVisualStyleBackColor = true;
            this.btnVerificaPassword.Click += new System.EventHandler(this.btnVerificaPassword_Click);
            // 
            // btnConfermaPassword
            // 
            this.btnConfermaPassword.Enabled = false;
            this.btnConfermaPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConfermaPassword.Location = new System.Drawing.Point(407, 329);
            this.btnConfermaPassword.Name = "btnConfermaPassword";
            this.btnConfermaPassword.Size = new System.Drawing.Size(274, 47);
            this.btnConfermaPassword.TabIndex = 5;
            this.btnConfermaPassword.Text = "Conferma nuova password";
            this.btnConfermaPassword.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(254, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Utente:";
            // 
            // lblUtente
            // 
            this.lblUtente.AutoSize = true;
            this.lblUtente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUtente.Location = new System.Drawing.Point(364, 36);
            this.lblUtente.Name = "lblUtente";
            this.lblUtente.Size = new System.Drawing.Size(125, 28);
            this.lblUtente.TabIndex = 7;
            this.lblUtente.Text = "UtenteScelto";
            // 
            // frmGestionePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 450);
            this.Controls.Add(this.lblUtente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConfermaPassword);
            this.Controls.Add(this.btnVerificaPassword);
            this.Controls.Add(this.txtNuovaPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVecchiaPassword);
            this.Controls.Add(this.label1);
            this.Name = "frmGestionePassword";
            this.Text = "Inserire la vecchia password:";
            this.Load += new System.EventHandler(this.frmGestionePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVecchiaPassword;
        private System.Windows.Forms.TextBox txtNuovaPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVerificaPassword;
        private System.Windows.Forms.Button btnConfermaPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUtente;
    }
}