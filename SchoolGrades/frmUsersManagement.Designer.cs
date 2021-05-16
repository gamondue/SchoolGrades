
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
            this.label1 = new System.Windows.Forms.Label();
            this.textboxFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textboxLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textboxEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.savePassword = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.changePassword = new System.Windows.Forms.Button();
            this.newUser = new System.Windows.Forms.Button();
            this.saveInformation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 18;
            this.lstUsers.Location = new System.Drawing.Point(13, 11);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(154, 256);
            this.lstUsers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Last name:";
            // 
            // textboxFirstName
            // 
            this.textboxFirstName.Location = new System.Drawing.Point(284, 9);
            this.textboxFirstName.Name = "textboxFirstName";
            this.textboxFirstName.Size = new System.Drawing.Size(200, 24);
            this.textboxFirstName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "First name:";
            // 
            // textboxLastName
            // 
            this.textboxLastName.Location = new System.Drawing.Point(612, 9);
            this.textboxLastName.Name = "textboxLastName";
            this.textboxLastName.Size = new System.Drawing.Size(200, 24);
            this.textboxLastName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "E-mail:";
            // 
            // textboxEmail
            // 
            this.textboxEmail.Location = new System.Drawing.Point(284, 56);
            this.textboxEmail.Name = "textboxEmail";
            this.textboxEmail.Size = new System.Drawing.Size(528, 24);
            this.textboxEmail.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(284, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(528, 24);
            this.textBox1.TabIndex = 8;
            // 
            // savePassword
            // 
            this.savePassword.Location = new System.Drawing.Point(196, 209);
            this.savePassword.Name = "savePassword";
            this.savePassword.Size = new System.Drawing.Size(118, 52);
            this.savePassword.TabIndex = 9;
            this.savePassword.Text = "Save Password";
            this.savePassword.UseVisualStyleBackColor = true;
            this.savePassword.Click += new System.EventHandler(this.savePassword_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Password:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(284, 153);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(528, 24);
            this.textBox2.TabIndex = 11;
            // 
            // changePassword
            // 
            this.changePassword.Location = new System.Drawing.Point(358, 209);
            this.changePassword.Name = "changePassword";
            this.changePassword.Size = new System.Drawing.Size(118, 52);
            this.changePassword.TabIndex = 12;
            this.changePassword.Text = "Change Password";
            this.changePassword.UseVisualStyleBackColor = true;
            this.changePassword.Click += new System.EventHandler(this.changePassword_Click);
            // 
            // newUser
            // 
            this.newUser.Location = new System.Drawing.Point(525, 209);
            this.newUser.Name = "newUser";
            this.newUser.Size = new System.Drawing.Size(118, 52);
            this.newUser.TabIndex = 13;
            this.newUser.Text = "New User";
            this.newUser.UseVisualStyleBackColor = true;
            this.newUser.Click += new System.EventHandler(this.newUser_Click);
            // 
            // saveInformation
            // 
            this.saveInformation.Location = new System.Drawing.Point(694, 209);
            this.saveInformation.Name = "saveInformation";
            this.saveInformation.Size = new System.Drawing.Size(118, 52);
            this.saveInformation.TabIndex = 14;
            this.saveInformation.Text = "Save Information";
            this.saveInformation.UseVisualStyleBackColor = true;
            this.saveInformation.Click += new System.EventHandler(this.saveInformation_Click);
            // 
            // frmUsersManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(858, 290);
            this.Controls.Add(this.saveInformation);
            this.Controls.Add(this.newUser);
            this.Controls.Add(this.changePassword);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.savePassword);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textboxEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textboxLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textboxFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstUsers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmUsersManagement";
            this.Text = "frmUsersManagement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textboxLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textboxEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button savePassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button changePassword;
        private System.Windows.Forms.Button newUser;
        private System.Windows.Forms.Button saveInformation;
    }
}