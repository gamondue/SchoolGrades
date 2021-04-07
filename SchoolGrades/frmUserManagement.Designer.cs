
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
            this.lbFirstName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnDisable = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.lbEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbDescrption = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnEnable = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lbUsername = new System.Windows.Forms.Label();
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
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Location = new System.Drawing.Point(156, 82);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(53, 20);
            this.lbFirstName.TabIndex = 5;
            this.lbFirstName.Text = "Nome:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(156, 105);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(132, 27);
            this.txtName.TabIndex = 6;
            // 
            // btnDisable
            // 
            this.btnDisable.Enabled = false;
            this.btnDisable.Location = new System.Drawing.Point(262, 345);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(100, 71);
            this.btnDisable.TabIndex = 7;
            this.btnDisable.Text = "DIsabilita";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(474, 345);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(100, 71);
            this.btnModifica.TabIndex = 8;
            this.btnModifica.Text = "Modifica";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(411, 16);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(49, 20);
            this.lbEmail.TabIndex = 9;
            this.lbEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(411, 38);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(127, 27);
            this.txtEmail.TabIndex = 10;
            // 
            // lbDescrption
            // 
            this.lbDescrption.AutoSize = true;
            this.lbDescrption.Location = new System.Drawing.Point(411, 86);
            this.lbDescrption.Name = "lbDescrption";
            this.lbDescrption.Size = new System.Drawing.Size(89, 20);
            this.lbDescrption.TabIndex = 11;
            this.lbDescrption.Text = "Descrizione:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(411, 108);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(127, 27);
            this.txtDescription.TabIndex = 12;
            // 
            // btnEnable
            // 
            this.btnEnable.Enabled = false;
            this.btnEnable.Location = new System.Drawing.Point(368, 345);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(100, 71);
            this.btnEnable.TabIndex = 13;
            this.btnEnable.Text = "Abilita";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(284, 187);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(132, 27);
            this.txtUsername.TabIndex = 15;
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(284, 164);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(78, 20);
            this.lbUsername.TabIndex = 14;
            this.lbUsername.Text = "Username:";
            // 
            // frmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.btnEnable);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lbDescrption);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.btnDisable);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbFirstName);
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
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lbDescrption;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lbUsername;
    }
}