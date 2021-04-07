using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmUserManagement : Form
    {
        User currentUser;
        SchoolGrades.BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();

        public frmUserManagement()
        {
            InitializeComponent();
            currentUser = new User("", "");

        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            // starts when the calling program calls Show()
            foreach(User user in bl.GetAllUsers())
            {
                lstUser.Items.Add(user.Username);
            }
 
        }
        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string changedUser = sender.ToString();
            changedUser = changedUser.Substring(changedUser.LastIndexOf(' '));
            currentUser = bl.GetUser(changedUser);
            FromClassToUi();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FromUiToClass(); 
            bl.UpdateUser(currentUser); 
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            currentUser.IsEnabled = true;
            btnEnable.Enabled = false;
            btnDisable.Enabled = true;
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            currentUser.IsEnabled = false;
            btnDisable.Enabled = false;
            btnEnable.Enabled = true;
        }

        private void txtNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Length < 1)
                    throw new Exception("New User must have a username");
                User newUser = new User(txtUsername.Text, txtPassword.Text);

                if (txtLastName.Text.Length > 1)
                    newUser.LastName = txtLastName.Text;
                if (txtDescription.Text.Length > 1)
                    newUser.Description = txtDescription.Text;
                if (txtEmail.Text.Length > 1)
                    newUser.Email = txtEmail.Text;
                if (txtFirstName.Text.Length > 1)
                    newUser.FirstName = txtFirstName.Text;

                bl.CreateUser(newUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is problem!" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Read the Class User from UI
        /// </summary>
        private void FromUiToClass()
        {
            if (txtUsername.Text.Length > 1)
                currentUser.Username = txtUsername.Text;
            if (txtLastName.Text.Length > 1)
                currentUser.LastName = txtLastName.Text;
            if (txtDescription.Text.Length > 1)
                currentUser.Username = txtDescription.Text;
            if (txtEmail.Text.Length > 1)
                currentUser.Email = txtEmail.Text;
            if (txtFirstName.Text.Length > 1)
                currentUser.FirstName = txtFirstName.Text;

            currentUser.Password = txtPassword.Text;

            bl.ChangePassword(currentUser);
            bl.UpdateUser(currentUser);
        }

        private void FromClassToUi()
        {
            txtLastName.Text = currentUser.LastName;
            txtFirstName.Text = currentUser.FirstName;
            txtUsername.Text = currentUser.Username;
            txtEmail.Text = currentUser.Email;
            txtDescription.Text = currentUser.Description;
        }
    }
}
