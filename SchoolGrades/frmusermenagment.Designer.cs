
namespace SchoolGrades
{
    partial class frmusermenagment
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
            this.listUser = new System.Windows.Forms.ListBox();
            this.Save = new System.Windows.Forms.Button();
            this.txtCognome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Modifica = new System.Windows.Forms.Button();
            this.Abilita = new System.Windows.Forms.Button();
            this.Disabilita = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listUser
            // 
            this.listUser.AccessibleName = "listUser";
            this.listUser.FormattingEnabled = true;
            this.listUser.ItemHeight = 15;
            this.listUser.Location = new System.Drawing.Point(12, 12);
            this.listUser.Name = "listUser";
            this.listUser.Size = new System.Drawing.Size(157, 424);
            this.listUser.TabIndex = 0;
            this.listUser.SelectedIndexChanged += new System.EventHandler(this.listUser_SelectedIndexChanged);
            // 
            // Save
            // 
            this.Save.AccessibleName = "Salva";
            this.Save.Location = new System.Drawing.Point(198, 373);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(122, 63);
            this.Save.TabIndex = 3;
            this.Save.Text = "Salva";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // txtCognome
            // 
            this.txtCognome.AccessibleName = "txtLastName";
            this.txtCognome.Location = new System.Drawing.Point(198, 46);
            this.txtCognome.Name = "txtCognome";
            this.txtCognome.ReadOnly = true;
            this.txtCognome.Size = new System.Drawing.Size(122, 23);
            this.txtCognome.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cognome";

            // 
            // Modifica
            // 
            this.Modifica.Location = new System.Drawing.Point(328, 373);
            this.Modifica.Name = "Modifica";
            this.Modifica.Size = new System.Drawing.Size(120, 63);
            this.Modifica.TabIndex = 6;
            this.Modifica.Text = "Modifica";
            this.Modifica.UseVisualStyleBackColor = true;
            this.Modifica.Click += new System.EventHandler(this.Modifica_Click);
            // 
            // Abilita
            // 
            this.Abilita.Location = new System.Drawing.Point(456, 373);
            this.Abilita.Name = "Abilita";
            this.Abilita.Size = new System.Drawing.Size(118, 63);
            this.Abilita.TabIndex = 7;
            this.Abilita.Text = "Abilita";
            this.Abilita.UseVisualStyleBackColor = true;
            this.Abilita.Click += new System.EventHandler(this.Abilita_Click);
            // 
            // Disabilita
            // 
            this.Disabilita.Location = new System.Drawing.Point(582, 373);
            this.Disabilita.Name = "Disabilita";
            this.Disabilita.Size = new System.Drawing.Size(118, 63);
            this.Disabilita.TabIndex = 8;
            this.Disabilita.Text = "Disabilita";
            this.Disabilita.UseVisualStyleBackColor = true;
            this.Disabilita.Click += new System.EventHandler(this.Disabilita_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(398, 46);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(129, 23);
            this.txtEmail.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(198, 97);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(122, 23);
            this.txtName.TabIndex = 10;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(398, 97);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(129, 23);
            this.txtUsername.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Username";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(582, 46);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(193, 23);
            this.txtDescription.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(582, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Descrizione";
            // 
            // frmGestioniUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.Disabilita);
            this.Controls.Add(this.Abilita);
            this.Controls.Add(this.Modifica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCognome);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.listUser);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Name = "frmGestioniUser";
            this.Text = "User Login";
            this.Load += new System.EventHandler(this.frmGestioniUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listUser;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox txtCognome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Modifica;
        private System.Windows.Forms.Button Abilita;
        private System.Windows.Forms.Button Disabilita;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
    }
}