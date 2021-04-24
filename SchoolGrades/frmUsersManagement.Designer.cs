
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
            this.btnModifica = new System.Windows.Forms.Button();
            this.grbUpdates = new System.Windows.Forms.GroupBox();
            this.btnConfirmCreation = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewPw = new System.Windows.Forms.TextBox();
            this.txtNewEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewLN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewFirst = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.rTxtNewDescription = new System.Windows.Forms.TextBox();
            this.grbUpdates.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 15;
            this.lstUsers.Location = new System.Drawing.Point(25, 25);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(132, 364);
            this.lstUsers.TabIndex = 0;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // btnModifica
            // 
            this.btnModifica.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnModifica.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnModifica.Location = new System.Drawing.Point(449, 46);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(147, 39);
            this.btnModifica.TabIndex = 1;
            this.btnModifica.Text = "Change user\'s dates";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // grbUpdates
            // 
            this.grbUpdates.Controls.Add(this.rTxtNewDescription);
            this.grbUpdates.Controls.Add(this.btnConfirmCreation);
            this.grbUpdates.Controls.Add(this.btnSave);
            this.grbUpdates.Controls.Add(this.label6);
            this.grbUpdates.Controls.Add(this.txtNewPw);
            this.grbUpdates.Controls.Add(this.txtNewEmail);
            this.grbUpdates.Controls.Add(this.label4);
            this.grbUpdates.Controls.Add(this.txtNewLN);
            this.grbUpdates.Controls.Add(this.label2);
            this.grbUpdates.Controls.Add(this.txtNewFirst);
            this.grbUpdates.Controls.Add(this.label5);
            this.grbUpdates.Controls.Add(this.label3);
            this.grbUpdates.Controls.Add(this.txtNewUsername);
            this.grbUpdates.Controls.Add(this.label1);
            this.grbUpdates.Enabled = false;
            this.grbUpdates.Location = new System.Drawing.Point(250, 91);
            this.grbUpdates.Name = "grbUpdates";
            this.grbUpdates.Size = new System.Drawing.Size(409, 310);
            this.grbUpdates.TabIndex = 2;
            this.grbUpdates.TabStop = false;
            // 
            // btnConfirmCreation
            // 
            this.btnConfirmCreation.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnConfirmCreation.Location = new System.Drawing.Point(250, 274);
            this.btnConfirmCreation.Name = "btnConfirmCreation";
            this.btnConfirmCreation.Size = new System.Drawing.Size(109, 30);
            this.btnConfirmCreation.TabIndex = 13;
            this.btnConfirmCreation.Text = "Confirm Creation";
            this.btnConfirmCreation.UseVisualStyleBackColor = true;
            this.btnConfirmCreation.Click += new System.EventHandler(this.btnConfirmCreation_Click);
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSave.Location = new System.Drawing.Point(81, 274);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Password:";
            // 
            // txtNewPw
            // 
            this.txtNewPw.Location = new System.Drawing.Point(284, 26);
            this.txtNewPw.Name = "txtNewPw";
            this.txtNewPw.Size = new System.Drawing.Size(100, 23);
            this.txtNewPw.TabIndex = 10;
            // 
            // txtNewEmail
            // 
            this.txtNewEmail.Location = new System.Drawing.Point(284, 136);
            this.txtNewEmail.Name = "txtNewEmail";
            this.txtNewEmail.Size = new System.Drawing.Size(100, 23);
            this.txtNewEmail.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "E-Mail:";
            // 
            // txtNewLN
            // 
            this.txtNewLN.Location = new System.Drawing.Point(284, 84);
            this.txtNewLN.Name = "txtNewLN";
            this.txtNewLN.Size = new System.Drawing.Size(100, 23);
            this.txtNewLN.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:";
            // 
            // txtNewFirst
            // 
            this.txtNewFirst.Location = new System.Drawing.Point(75, 84);
            this.txtNewFirst.Name = "txtNewFirst";
            this.txtNewFirst.Size = new System.Drawing.Size(100, 23);
            this.txtNewFirst.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "First Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description:";
            // 
            // txtNewUsername
            // 
            this.txtNewUsername.Location = new System.Drawing.Point(75, 26);
            this.txtNewUsername.Name = "txtNewUsername";
            this.txtNewUsername.Size = new System.Drawing.Size(100, 23);
            this.txtNewUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // btnNewUser
            // 
            this.btnNewUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewUser.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnNewUser.Location = new System.Drawing.Point(331, 46);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(94, 39);
            this.btnNewUser.TabIndex = 3;
            this.btnNewUser.Text = "Create User";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(706, 378);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 32);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rTxtNewDescription
            // 
            this.rTxtNewDescription.Location = new System.Drawing.Point(75, 136);
            this.rTxtNewDescription.Multiline = true;
            this.rTxtNewDescription.Name = "rTxtNewDescription";
            this.rTxtNewDescription.Size = new System.Drawing.Size(100, 48);
            this.rTxtNewDescription.TabIndex = 14;
            // 
            // frmUsersManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(816, 422);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.grbUpdates);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.lstUsers);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmUsersManagement";
            this.Text = "frmUsersManagement";
            this.Load += new System.EventHandler(this.frmUsersManagement_Load);
            this.grbUpdates.ResumeLayout(false);
            this.grbUpdates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.GroupBox grbUpdates;
        private System.Windows.Forms.TextBox txtNewUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewLN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNewPw;
        private System.Windows.Forms.TextBox txtNewFirst;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Button btnConfirmCreation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox rTxtNewDescription;
    }
}