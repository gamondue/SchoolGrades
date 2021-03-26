
namespace SchoolGrades
{
    partial class frmUsersManagementListBox
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
            this.btnNewUser = new System.Windows.Forms.Button();
            this.btnModifyUser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.txtIdCategory = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtIdSalt = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtDescription = new System.Windows.Forms.TextBox();
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
            this.SuspendLayout();
            // 
            // btnNewUser
            // 
            this.btnNewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNewUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewUser.Location = new System.Drawing.Point(695, 505);
            this.btnNewUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(98, 36);
            this.btnNewUser.TabIndex = 29;
            this.btnNewUser.Text = "Create";
            this.btnNewUser.UseVisualStyleBackColor = false;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click_1);
            // 
            // btnModifyUser
            // 
            this.btnModifyUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnModifyUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModifyUser.Location = new System.Drawing.Point(833, 505);
            this.btnModifyUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModifyUser.Name = "btnModifyUser";
            this.btnModifyUser.Size = new System.Drawing.Size(98, 36);
            this.btnModifyUser.TabIndex = 28;
            this.btnModifyUser.Text = "Modify";
            this.btnModifyUser.UseVisualStyleBackColor = false;
            this.btnModifyUser.Click += new System.EventHandler(this.btnModifyUser_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(623, -36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 32);
            this.label3.TabIndex = 24;
            this.label3.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(409, -38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 32);
            this.label1.TabIndex = 22;
            this.label1.Text = "Username";
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 20;
            this.lstUsers.Location = new System.Drawing.Point(460, 63);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(471, 424);
            this.lstUsers.TabIndex = 15;
            // 
            // txtIdCategory
            // 
            this.txtIdCategory.Location = new System.Drawing.Point(145, 505);
            this.txtIdCategory.Name = "txtIdCategory";
            this.txtIdCategory.Size = new System.Drawing.Size(239, 27);
            this.txtIdCategory.TabIndex = 35;
            this.txtIdCategory.UseSystemPasswordChar = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(21, 505);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(110, 20);
            this.metroLabel2.TabIndex = 34;
            this.metroLabel2.Text = "Id user category";
            // 
            // txtIdSalt
            // 
            this.txtIdSalt.Location = new System.Drawing.Point(145, 456);
            this.txtIdSalt.Name = "txtIdSalt";
            this.txtIdSalt.Size = new System.Drawing.Size(239, 27);
            this.txtIdSalt.TabIndex = 33;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(21, 463);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(44, 20);
            this.metroLabel3.TabIndex = 32;
            this.metroLabel3.Text = "Id salt";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(21, 295);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(79, 20);
            this.metroLabel1.TabIndex = 47;
            this.metroLabel1.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDescription.Location = new System.Drawing.Point(145, 295);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(239, 144);
            this.txtDescription.TabIndex = 46;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(145, 247);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(239, 27);
            this.txtEmail.TabIndex = 45;
            // 
            // mtEmail
            // 
            this.mtEmail.AutoSize = true;
            this.mtEmail.Location = new System.Drawing.Point(23, 247);
            this.mtEmail.Name = "mtEmail";
            this.mtEmail.Size = new System.Drawing.Size(42, 20);
            this.mtEmail.TabIndex = 44;
            this.mtEmail.Text = "Email";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(145, 201);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(239, 27);
            this.txtSurname.TabIndex = 43;
            // 
            // mtSurname
            // 
            this.mtSurname.AutoSize = true;
            this.mtSurname.Location = new System.Drawing.Point(23, 201);
            this.mtSurname.Name = "mtSurname";
            this.mtSurname.Size = new System.Drawing.Size(64, 20);
            this.mtSurname.TabIndex = 42;
            this.mtSurname.Text = "Surname";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(145, 154);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(239, 27);
            this.txtName.TabIndex = 41;
            // 
            // mtName
            // 
            this.mtName.AutoSize = true;
            this.mtName.Location = new System.Drawing.Point(23, 154);
            this.mtName.Name = "mtName";
            this.mtName.Size = new System.Drawing.Size(47, 20);
            this.mtName.TabIndex = 40;
            this.mtName.Text = "Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(145, 108);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(239, 27);
            this.txtPassword.TabIndex = 39;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // mtPassword
            // 
            this.mtPassword.AutoSize = true;
            this.mtPassword.Location = new System.Drawing.Point(23, 108);
            this.mtPassword.Name = "mtPassword";
            this.mtPassword.Size = new System.Drawing.Size(66, 20);
            this.mtPassword.TabIndex = 38;
            this.mtPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(145, 63);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(239, 27);
            this.txtUsername.TabIndex = 37;
            // 
            // mtUsername
            // 
            this.mtUsername.AutoSize = true;
            this.mtUsername.Location = new System.Drawing.Point(23, 63);
            this.mtUsername.Name = "mtUsername";
            this.mtUsername.Size = new System.Drawing.Size(73, 20);
            this.mtUsername.TabIndex = 36;
            this.mtUsername.Text = "Username";
            // 
            // frmUsersManagementListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 555);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtDescription);
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
            this.Controls.Add(this.txtIdCategory);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtIdSalt);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.btnModifyUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstUsers);
            this.Name = "frmUsersManagementListBox";
            this.Text = "Users management";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Button btnModifyUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.TextBox txtIdCategory;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.TextBox txtIdSalt;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TextBox txtDescription;
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
    }
}