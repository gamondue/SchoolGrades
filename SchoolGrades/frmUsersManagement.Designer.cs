
namespace SchoolGrades
{
    partial class frmUsersManagement
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
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.btnCreaUtente = new System.Windows.Forms.Button();
            this.btnCambiaDatiUtente = new System.Windows.Forms.Button();
            this.btnConfermaCreazione = new System.Windows.Forms.Button();
            this.btnSalvaModifiche = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtCognome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 15;
            this.lstUsers.Location = new System.Drawing.Point(199, 11);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(132, 259);
            this.lstUsers.TabIndex = 0;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // btnCreaUtente
            // 
            this.btnCreaUtente.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCreaUtente.Location = new System.Drawing.Point(12, 12);
            this.btnCreaUtente.Name = "btnCreaUtente";
            this.btnCreaUtente.Size = new System.Drawing.Size(75, 40);
            this.btnCreaUtente.TabIndex = 1;
            this.btnCreaUtente.Text = "Crea utente";
            this.btnCreaUtente.UseVisualStyleBackColor = false;
            this.btnCreaUtente.Click += new System.EventHandler(this.btnCreaUtente_Click);
            // 
            // btnCambiaDatiUtente
            // 
            this.btnCambiaDatiUtente.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCambiaDatiUtente.Location = new System.Drawing.Point(93, 12);
            this.btnCambiaDatiUtente.Name = "btnCambiaDatiUtente";
            this.btnCambiaDatiUtente.Size = new System.Drawing.Size(100, 40);
            this.btnCambiaDatiUtente.TabIndex = 2;
            this.btnCambiaDatiUtente.Text = "Cambia dati utente";
            this.btnCambiaDatiUtente.UseVisualStyleBackColor = false;
            this.btnCambiaDatiUtente.Click += new System.EventHandler(this.btnCambiaDatiUtente_Click);
            // 
            // btnConfermaCreazione
            // 
            this.btnConfermaCreazione.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnConfermaCreazione.Location = new System.Drawing.Point(120, 298);
            this.btnConfermaCreazione.Name = "btnConfermaCreazione";
            this.btnConfermaCreazione.Size = new System.Drawing.Size(73, 40);
            this.btnConfermaCreazione.TabIndex = 3;
            this.btnConfermaCreazione.Text = "Conferma creazione";
            this.btnConfermaCreazione.UseVisualStyleBackColor = false;
            this.btnConfermaCreazione.Click += new System.EventHandler(this.btnConfermaCreazione_Click);
            // 
            // btnSalvaModifiche
            // 
            this.btnSalvaModifiche.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSalvaModifiche.Location = new System.Drawing.Point(17, 298);
            this.btnSalvaModifiche.Name = "btnSalvaModifiche";
            this.btnSalvaModifiche.Size = new System.Drawing.Size(75, 40);
            this.btnSalvaModifiche.TabIndex = 4;
            this.btnSalvaModifiche.Text = "Salva modifiche";
            this.btnSalvaModifiche.UseVisualStyleBackColor = false;
            this.btnSalvaModifiche.Click += new System.EventHandler(this.btnSalvaModifiche_Click);
            // 
            // btnChiudi
            // 
            this.btnChiudi.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnChiudi.Location = new System.Drawing.Point(256, 298);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(75, 40);
            this.btnChiudi.TabIndex = 5;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.UseVisualStyleBackColor = false;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtUsername.Location = new System.Drawing.Point(93, 86);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 23);
            this.txtUsername.TabIndex = 6;
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNome.Location = new System.Drawing.Point(93, 115);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 23);
            this.txtNome.TabIndex = 7;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtEmail.Location = new System.Drawing.Point(93, 173);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 23);
            this.txtEmail.TabIndex = 8;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtDescrizione.Location = new System.Drawing.Point(93, 202);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(100, 52);
            this.txtDescrizione.TabIndex = 9;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPassword.Location = new System.Drawing.Point(93, 260);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 23);
            this.txtPassword.TabIndex = 10;
            // 
            // txtCognome
            // 
            this.txtCognome.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtCognome.Location = new System.Drawing.Point(93, 144);
            this.txtCognome.Name = "txtCognome";
            this.txtCognome.Size = new System.Drawing.Size(100, 23);
            this.txtCognome.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nome utente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nome:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cognome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "E-mail:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Descrizione:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Password:";
            // 
            // frmUsersManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(340, 344);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCognome);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnSalvaModifiche);
            this.Controls.Add(this.btnConfermaCreazione);
            this.Controls.Add(this.btnCambiaDatiUtente);
            this.Controls.Add(this.btnCreaUtente);
            this.Controls.Add(this.lstUsers);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmUsersManagement";
            this.Text = "frmUsersManagement";
            this.Load += new System.EventHandler(this.frmUsersManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Button btnCreaUtente;
        private System.Windows.Forms.Button btnCambiaDatiUtente;
        private System.Windows.Forms.Button btnConfermaCreazione;
        private System.Windows.Forms.Button btnSalvaModifiche;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtCognome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}