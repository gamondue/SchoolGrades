
namespace SchoolGrades
{
    partial class UserDetails
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.mtEmail = new MetroFramework.Controls.MetroLabel();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.mtSurname = new MetroFramework.Controls.MetroLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.mtName = new MetroFramework.Controls.MetroLabel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.mtPassword = new MetroFramework.Controls.MetroLabel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.mtUsername = new MetroFramework.Controls.MetroLabel();
            this.txtIdCategory = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtIdSalt = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnSaveUser = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.lblUpdatingUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(136, 244);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(239, 27);
            this.txtEmail.TabIndex = 19;
            // 
            // mtEmail
            // 
            this.mtEmail.AutoSize = true;
            this.mtEmail.Location = new System.Drawing.Point(20, 247);
            this.mtEmail.Name = "mtEmail";
            this.mtEmail.Size = new System.Drawing.Size(42, 20);
            this.mtEmail.TabIndex = 18;
            this.mtEmail.Text = "Email";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(136, 198);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(239, 27);
            this.txtSurname.TabIndex = 17;
            // 
            // mtSurname
            // 
            this.mtSurname.AutoSize = true;
            this.mtSurname.Location = new System.Drawing.Point(20, 201);
            this.mtSurname.Name = "mtSurname";
            this.mtSurname.Size = new System.Drawing.Size(64, 20);
            this.mtSurname.TabIndex = 16;
            this.mtSurname.Text = "Surname";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(136, 151);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(239, 27);
            this.txtName.TabIndex = 15;
            // 
            // mtName
            // 
            this.mtName.AutoSize = true;
            this.mtName.Location = new System.Drawing.Point(20, 154);
            this.mtName.Name = "mtName";
            this.mtName.Size = new System.Drawing.Size(47, 20);
            this.mtName.TabIndex = 14;
            this.mtName.Text = "Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(136, 105);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(239, 27);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // mtPassword
            // 
            this.mtPassword.AutoSize = true;
            this.mtPassword.Location = new System.Drawing.Point(20, 108);
            this.mtPassword.Name = "mtPassword";
            this.mtPassword.Size = new System.Drawing.Size(66, 20);
            this.mtPassword.TabIndex = 12;
            this.mtPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(136, 60);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(239, 27);
            this.txtUsername.TabIndex = 11;
            // 
            // mtUsername
            // 
            this.mtUsername.AutoSize = true;
            this.mtUsername.Location = new System.Drawing.Point(20, 63);
            this.mtUsername.Name = "mtUsername";
            this.mtUsername.Size = new System.Drawing.Size(73, 20);
            this.mtUsername.TabIndex = 10;
            this.mtUsername.Text = "Username";
            // 
            // txtIdCategory
            // 
            this.txtIdCategory.Location = new System.Drawing.Point(136, 336);
            this.txtIdCategory.Name = "txtIdCategory";
            this.txtIdCategory.Size = new System.Drawing.Size(239, 27);
            this.txtIdCategory.TabIndex = 33;
            this.txtIdCategory.UseSystemPasswordChar = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(20, 336);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(110, 20);
            this.metroLabel2.TabIndex = 32;
            this.metroLabel2.Text = "Id user category";
            // 
            // txtIdSalt
            // 
            this.txtIdSalt.Location = new System.Drawing.Point(136, 291);
            this.txtIdSalt.Name = "txtIdSalt";
            this.txtIdSalt.Size = new System.Drawing.Size(239, 27);
            this.txtIdSalt.TabIndex = 31;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(20, 294);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(44, 20);
            this.metroLabel3.TabIndex = 30;
            this.metroLabel3.Text = "Id salt";
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.BackColor = System.Drawing.Color.Blue;
            this.btnSaveUser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveUser.Location = new System.Drawing.Point(136, 387);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(94, 29);
            this.btnSaveUser.TabIndex = 34;
            this.btnSaveUser.Text = "Save user";
            this.btnSaveUser.UseCustomBackColor = true;
            this.btnSaveUser.UseCustomForeColor = true;
            this.btnSaveUser.UseSelectable = true;
            this.btnSaveUser.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Location = new System.Drawing.Point(281, 387);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseCustomBackColor = true;
            this.btnCancel.UseCustomForeColor = true;
            this.btnCancel.UseSelectable = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblUpdatingUser
            // 
            this.lblUpdatingUser.AutoSize = true;
            this.lblUpdatingUser.Location = new System.Drawing.Point(136, 423);
            this.lblUpdatingUser.Name = "lblUpdatingUser";
            this.lblUpdatingUser.Size = new System.Drawing.Size(0, 20);
            this.lblUpdatingUser.TabIndex = 36;
            // 
            // UserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 450);
            this.Controls.Add(this.lblUpdatingUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveUser);
            this.Controls.Add(this.txtIdCategory);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtIdSalt);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.mtEmail);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.mtSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.mtName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.mtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.mtUsername);
            this.Name = "UserDetails";
            this.Text = "User details";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private MetroFramework.Controls.MetroLabel mtEmail;
        private System.Windows.Forms.TextBox txtSurname;
        private MetroFramework.Controls.MetroLabel mtSurname;
        private System.Windows.Forms.TextBox txtName;
        private MetroFramework.Controls.MetroLabel mtName;
        private System.Windows.Forms.TextBox txtPassword;
        private MetroFramework.Controls.MetroLabel mtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private MetroFramework.Controls.MetroLabel mtUsername;
        private System.Windows.Forms.TextBox txtIdCategory;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.TextBox txtIdSalt;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnSaveUser;
        private MetroFramework.Controls.MetroButton btnCancel;
        private System.Windows.Forms.Label lblUpdatingUser;
    }
}