
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
            this.components = new System.ComponentModel.Container();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnNuovo = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDisabilita = new System.Windows.Forms.Button();
            this.lblCambiamentoCorretto = new System.Windows.Forms.Label();
            this.lblErrore = new System.Windows.Forms.Label();
            this.btnConferma = new System.Windows.Forms.Button();
            this.txtVecchiaPassword = new System.Windows.Forms.TextBox();
            this.txtNuovaPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstUser
            // 
            this.lstUser.ForeColor = System.Drawing.Color.DarkBlue;
            this.lstUser.FormattingEnabled = true;
            this.lstUser.ItemHeight = 20;
            this.lstUser.Location = new System.Drawing.Point(12, 12);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(158, 324);
            this.lstUser.TabIndex = 0;
            this.lstUser.SelectedIndexChanged += new System.EventHandler(this.lstUser_SelectedIndexChanged);
            this.lstUser.DoubleClick += new System.EventHandler(this.lstUser_DoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(459, 294);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 46);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(207, 222);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(176, 27);
            this.txtLastName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cognome";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Enabled = false;
            this.btnChangePassword.Location = new System.Drawing.Point(207, 294);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(199, 46);
            this.btnChangePassword.TabIndex = 4;
            this.btnChangePassword.Text = "Cambia password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(207, 146);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(176, 27);
            this.txtFirstName.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(426, 222);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(317, 27);
            this.txtDescription.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(426, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(426, 135);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(317, 27);
            this.txtEmail.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(207, 59);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(176, 27);
            this.txtUsername.TabIndex = 14;
            // 
            // btnNuovo
            // 
            this.btnNuovo.Location = new System.Drawing.Point(590, 294);
            this.btnNuovo.Name = "btnNuovo";
            this.btnNuovo.Size = new System.Drawing.Size(153, 45);
            this.btnNuovo.TabIndex = 15;
            this.btnNuovo.Text = "Nuovo utente";
            this.btnNuovo.UseVisualStyleBackColor = true;
            this.btnNuovo.Click += new System.EventHandler(this.btnNuovo_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(426, 59);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(63, 27);
            this.txtId.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(442, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "ID";
            // 
            // btnDisabilita
            // 
            this.btnDisabilita.Location = new System.Drawing.Point(809, 295);
            this.btnDisabilita.Name = "btnDisabilita";
            this.btnDisabilita.Size = new System.Drawing.Size(110, 45);
            this.btnDisabilita.TabIndex = 19;
            this.btnDisabilita.Text = "Disabilita";
            this.btnDisabilita.UseVisualStyleBackColor = true;
            this.btnDisabilita.Click += new System.EventHandler(this.btnDisabilita_Click);
            // 
            // lblCambiamentoCorretto
            // 
            this.lblCambiamentoCorretto.AutoSize = true;
            this.lblCambiamentoCorretto.ForeColor = System.Drawing.Color.Green;
            this.lblCambiamentoCorretto.Location = new System.Drawing.Point(904, 10);
            this.lblCambiamentoCorretto.Name = "lblCambiamentoCorretto";
            this.lblCambiamentoCorretto.Size = new System.Drawing.Size(294, 20);
            this.lblCambiamentoCorretto.TabIndex = 26;
            this.lblCambiamentoCorretto.Text = "La password è stata cambiata con successo";
            this.lblCambiamentoCorretto.Visible = false;
            // 
            // lblErrore
            // 
            this.lblErrore.AutoSize = true;
            this.lblErrore.ForeColor = System.Drawing.Color.Red;
            this.lblErrore.Location = new System.Drawing.Point(975, 314);
            this.lblErrore.Name = "lblErrore";
            this.lblErrore.Size = new System.Drawing.Size(199, 20);
            this.lblErrore.TabIndex = 25;
            this.lblErrore.Text = "La vecchia password è errata";
            this.lblErrore.Visible = false;
            // 
            // btnConferma
            // 
            this.btnConferma.Enabled = false;
            this.btnConferma.Location = new System.Drawing.Point(948, 236);
            this.btnConferma.Name = "btnConferma";
            this.btnConferma.Size = new System.Drawing.Size(253, 45);
            this.btnConferma.TabIndex = 24;
            this.btnConferma.Text = "Conferma Cambiamento";
            this.btnConferma.UseVisualStyleBackColor = true;
            this.btnConferma.Click += new System.EventHandler(this.btnConferma_Click);
            // 
            // txtVecchiaPassword
            // 
            this.txtVecchiaPassword.Location = new System.Drawing.Point(904, 85);
            this.txtVecchiaPassword.Name = "txtVecchiaPassword";
            this.txtVecchiaPassword.ReadOnly = true;
            this.txtVecchiaPassword.Size = new System.Drawing.Size(327, 27);
            this.txtVecchiaPassword.TabIndex = 23;
            this.txtVecchiaPassword.UseSystemPasswordChar = true;
            // 
            // txtNuovaPassword
            // 
            this.txtNuovaPassword.Location = new System.Drawing.Point(904, 185);
            this.txtNuovaPassword.Name = "txtNuovaPassword";
            this.txtNuovaPassword.ReadOnly = true;
            this.txtNuovaPassword.Size = new System.Drawing.Size(327, 27);
            this.txtNuovaPassword.TabIndex = 22;
            this.txtNuovaPassword.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(985, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Vecchia password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(995, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Nuova password";
            // 
            // frmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1328, 372);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNuovaPassword);
            this.Controls.Add(this.txtVecchiaPassword);
            this.Controls.Add(this.btnConferma);
            this.Controls.Add(this.lblErrore);
            this.Controls.Add(this.lblCambiamentoCorretto);
            this.Controls.Add(this.btnDisabilita);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnNuovo);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstUser);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Name = "frmUserManagement";
            this.Text = "Gestione utenti";
            this.Load += new System.EventHandler(this.frmUserManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnNuovo;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDisabilita;
        private System.Windows.Forms.Label lblCambiamentoCorretto;
        private System.Windows.Forms.Label lblErrore;
        private System.Windows.Forms.Button btnConferma;
        private System.Windows.Forms.TextBox txtVecchiaPassword;
        private System.Windows.Forms.TextBox txtNuovaPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}