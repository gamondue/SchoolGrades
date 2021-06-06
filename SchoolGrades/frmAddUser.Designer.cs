
namespace SchoolGrades
{
    partial class frmAddUser
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
            this.mtUsername = new MetroFramework.Controls.MetroLabel();
            this.btnSaveUser = new MetroFramework.Controls.MetroButton();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.mtPassword = new MetroFramework.Controls.MetroLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.mtName = new MetroFramework.Controls.MetroLabel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.mtEmail = new MetroFramework.Controls.MetroLabel();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.mtSurname = new MetroFramework.Controls.MetroLabel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtIdCategory = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtIdSalt = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnBrowseImage = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mtUsername
            // 
            this.mtUsername.AutoSize = true;
            this.mtUsername.Location = new System.Drawing.Point(25, 63);
            this.mtUsername.Name = "mtUsername";
            this.mtUsername.Size = new System.Drawing.Size(73, 20);
            this.mtUsername.TabIndex = 0;
            this.mtUsername.Text = "Username";
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.BackColor = System.Drawing.Color.Blue;
            this.btnSaveUser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveUser.Location = new System.Drawing.Point(683, 410);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(94, 29);
            this.btnSaveUser.TabIndex = 0;
            this.btnSaveUser.Text = "Save user";
            this.btnSaveUser.UseCustomBackColor = true;
            this.btnSaveUser.UseCustomForeColor = true;
            this.btnSaveUser.UseSelectable = true;
            this.btnSaveUser.UseVisualStyleBackColor = false;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(115, 63);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(239, 27);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(115, 108);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(239, 27);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // mtPassword
            // 
            this.mtPassword.AutoSize = true;
            this.mtPassword.Location = new System.Drawing.Point(25, 108);
            this.mtPassword.Name = "mtPassword";
            this.mtPassword.Size = new System.Drawing.Size(66, 20);
            this.mtPassword.TabIndex = 2;
            this.mtPassword.Text = "Password";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(115, 154);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(239, 27);
            this.txtName.TabIndex = 5;
            // 
            // mtName
            // 
            this.mtName.AutoSize = true;
            this.mtName.Location = new System.Drawing.Point(25, 154);
            this.mtName.Name = "mtName";
            this.mtName.Size = new System.Drawing.Size(47, 20);
            this.mtName.TabIndex = 4;
            this.mtName.Text = "Name";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(115, 247);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(239, 27);
            this.txtEmail.TabIndex = 9;
            // 
            // mtEmail
            // 
            this.mtEmail.AutoSize = true;
            this.mtEmail.Location = new System.Drawing.Point(25, 247);
            this.mtEmail.Name = "mtEmail";
            this.mtEmail.Size = new System.Drawing.Size(42, 20);
            this.mtEmail.TabIndex = 8;
            this.mtEmail.Text = "Email";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(115, 201);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(239, 27);
            this.txtSurname.TabIndex = 7;
            // 
            // mtSurname
            // 
            this.mtSurname.AutoSize = true;
            this.mtSurname.Location = new System.Drawing.Point(25, 201);
            this.mtSurname.Name = "mtSurname";
            this.mtSurname.Size = new System.Drawing.Size(64, 20);
            this.mtSurname.TabIndex = 6;
            this.mtSurname.Text = "Surname";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDescription.Location = new System.Drawing.Point(115, 295);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(239, 144);
            this.txtDescription.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(428, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(349, 221);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 295);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(79, 20);
            this.metroLabel1.TabIndex = 25;
            this.metroLabel1.Text = "Description";
            // 
            // txtIdCategory
            // 
            this.txtIdCategory.Location = new System.Drawing.Point(538, 377);
            this.txtIdCategory.Name = "txtIdCategory";
            this.txtIdCategory.Size = new System.Drawing.Size(239, 27);
            this.txtIdCategory.TabIndex = 29;
            this.txtIdCategory.UseSystemPasswordChar = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(427, 377);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(110, 20);
            this.metroLabel2.TabIndex = 28;
            this.metroLabel2.Text = "Id user category";
            // 
            // txtIdSalt
            // 
            this.txtIdSalt.Location = new System.Drawing.Point(538, 332);
            this.txtIdSalt.Name = "txtIdSalt";
            this.txtIdSalt.Size = new System.Drawing.Size(239, 27);
            this.txtIdSalt.TabIndex = 27;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(427, 332);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(44, 20);
            this.metroLabel3.TabIndex = 26;
            this.metroLabel3.Text = "Id salt";
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBrowseImage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowseImage.Location = new System.Drawing.Point(683, 290);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(94, 29);
            this.btnBrowseImage.TabIndex = 30;
            this.btnBrowseImage.Text = "Browse image";
            this.btnBrowseImage.UseCustomBackColor = true;
            this.btnBrowseImage.UseCustomForeColor = true;
            this.btnBrowseImage.UseSelectable = true;
            this.btnBrowseImage.UseVisualStyleBackColor = false;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.txtIdCategory);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtIdSalt);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
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
            this.Controls.Add(this.btnSaveUser);
            this.MaximizeBox = false;
            this.Name = "frmAddUser";
            this.Text = "ADD USER";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel mtUsername;
        private MetroFramework.Controls.MetroButton btnSaveUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private MetroFramework.Controls.MetroLabel mtPassword;
        private System.Windows.Forms.TextBox txtName;
        private MetroFramework.Controls.MetroLabel mtName;
        private System.Windows.Forms.TextBox txtEmail;
        private MetroFramework.Controls.MetroLabel mtEmail;
        private System.Windows.Forms.TextBox txtSurname;
        private MetroFramework.Controls.MetroLabel mtSurname;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TextBox txtIdCategory;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.TextBox txtIdSalt;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnBrowseImage;
    }
}