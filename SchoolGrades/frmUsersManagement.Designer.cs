
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
            this.txtUtente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnCambiaCredenziali = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNewUser = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtNewMail = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnCreaUtente = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 15;
            this.lstUsers.Location = new System.Drawing.Point(25, 25);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(352, 364);
            this.lstUsers.TabIndex = 0;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // txtUtente
            // 
            this.txtUtente.Location = new System.Drawing.Point(498, 25);
            this.txtUtente.Name = "txtUtente";
            this.txtUtente.Size = new System.Drawing.Size(316, 23);
            this.txtUtente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "utente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "password(SHA256):";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(498, 56);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(316, 23);
            this.txtPass.TabIndex = 4;
            // 
            // btnCambiaCredenziali
            // 
            this.btnCambiaCredenziali.Location = new System.Drawing.Point(383, 143);
            this.btnCambiaCredenziali.Name = "btnCambiaCredenziali";
            this.btnCambiaCredenziali.Size = new System.Drawing.Size(431, 23);
            this.btnCambiaCredenziali.TabIndex = 5;
            this.btnCambiaCredenziali.Text = "cambia credenziali";
            this.btnCambiaCredenziali.UseVisualStyleBackColor = true;
            this.btnCambiaCredenziali.Click += new System.EventHandler(this.btnCambiaCredenziali_Click);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(498, 85);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(316, 23);
            this.txtMail.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "email";
            // 
            // lblDescrizione
            // 
            this.lblDescrizione.AutoSize = true;
            this.lblDescrizione.Location = new System.Drawing.Point(383, 125);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(70, 15);
            this.lblDescrizione.TabIndex = 9;
            this.lblDescrizione.Text = "Descrizione:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(383, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(383, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "E-Mail";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(642, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Nome";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(642, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Cognome";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(642, 336);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Descrizione";
            // 
            // txtNewUser
            // 
            this.txtNewUser.Location = new System.Drawing.Point(462, 194);
            this.txtNewUser.Name = "txtNewUser";
            this.txtNewUser.Size = new System.Drawing.Size(100, 23);
            this.txtNewUser.TabIndex = 16;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(462, 263);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(100, 23);
            this.txtNewPass.TabIndex = 17;
            // 
            // txtNewMail
            // 
            this.txtNewMail.Location = new System.Drawing.Point(462, 337);
            this.txtNewMail.Name = "txtNewMail";
            this.txtNewMail.Size = new System.Drawing.Size(100, 23);
            this.txtNewMail.TabIndex = 18;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(715, 193);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(99, 23);
            this.txtName.TabIndex = 19;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(715, 262);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(99, 23);
            this.txtSurname.TabIndex = 20;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(715, 332);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(99, 23);
            this.txtDescription.TabIndex = 21;
            // 
            // btnCreaUtente
            // 
            this.btnCreaUtente.Location = new System.Drawing.Point(383, 366);
            this.btnCreaUtente.Name = "btnCreaUtente";
            this.btnCreaUtente.Size = new System.Drawing.Size(431, 23);
            this.btnCreaUtente.TabIndex = 22;
            this.btnCreaUtente.Text = "Crea Utente";
            this.btnCreaUtente.UseVisualStyleBackColor = true;
            this.btnCreaUtente.Click += new System.EventHandler(this.btnCreaUtente_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 30);
            this.button1.TabIndex = 23;
            this.button1.Text = "Rimuovi Utente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmUsersManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 436);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreaUtente);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtNewMail);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtNewUser);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDescrizione);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.btnCambiaCredenziali);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUtente);
            this.Controls.Add(this.lstUsers);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmUsersManagement";
            this.Text = "Rimuovi Utente";
            this.Load += new System.EventHandler(this.frmUsersManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.TextBox txtUtente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnCambiaCredenziali;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNewUser;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtNewMail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnCreaUtente;
        private System.Windows.Forms.Button button1;
    }
}