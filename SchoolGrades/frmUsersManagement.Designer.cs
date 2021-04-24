
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
            this.EliminaUtente = new System.Windows.Forms.Button();
            this.AggiungiUtente = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PasswordInfo = new System.Windows.Forms.TextBox();
            this.SurnameInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NameInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 15;
            this.lstUsers.Location = new System.Drawing.Point(12, 11);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(132, 274);
            this.lstUsers.TabIndex = 0;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // EliminaUtente
            // 
            this.EliminaUtente.Location = new System.Drawing.Point(12, 319);
            this.EliminaUtente.Name = "EliminaUtente";
            this.EliminaUtente.Size = new System.Drawing.Size(121, 23);
            this.EliminaUtente.TabIndex = 1;
            this.EliminaUtente.Text = "Elimina Utente";
            this.EliminaUtente.UseVisualStyleBackColor = true;
            this.EliminaUtente.Click += new System.EventHandler(this.EliminaUtente_Click);
            // 
            // AggiungiUtente
            // 
            this.AggiungiUtente.Location = new System.Drawing.Point(187, 89);
            this.AggiungiUtente.Name = "AggiungiUtente";
            this.AggiungiUtente.Size = new System.Drawing.Size(121, 23);
            this.AggiungiUtente.TabIndex = 2;
            this.AggiungiUtente.Text = "Aggiungi Utente";
            this.AggiungiUtente.UseVisualStyleBackColor = true;
            this.AggiungiUtente.Click += new System.EventHandler(this.AggiungiUtente_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 290);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Informazioni Utente";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // PasswordInfo
            // 
            this.PasswordInfo.Location = new System.Drawing.Point(187, 221);
            this.PasswordInfo.Name = "PasswordInfo";
            this.PasswordInfo.PasswordChar = '*';
            this.PasswordInfo.Size = new System.Drawing.Size(121, 23);
            this.PasswordInfo.TabIndex = 5;
            // 
            // SurnameInfo
            // 
            this.SurnameInfo.Location = new System.Drawing.Point(187, 133);
            this.SurnameInfo.Name = "SurnameInfo";
            this.SurnameInfo.Size = new System.Drawing.Size(121, 23);
            this.SurnameInfo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Cognome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nome";
            // 
            // NameInfo
            // 
            this.NameInfo.Location = new System.Drawing.Point(187, 177);
            this.NameInfo.Name = "NameInfo";
            this.NameInfo.Size = new System.Drawing.Size(121, 23);
            this.NameInfo.TabIndex = 9;
            // 
            // frmUsersManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 345);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SurnameInfo);
            this.Controls.Add(this.PasswordInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AggiungiUtente);
            this.Controls.Add(this.EliminaUtente);
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
        private System.Windows.Forms.Button EliminaUtente;
        private System.Windows.Forms.Button AggiungiUtente;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox PasswordInfo;
        private System.Windows.Forms.TextBox SurnameInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameInfo;
    }
}