using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmUsersManagement : Form
    {
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        int nextIdUserCategory = 1;

        List<User> listOfAllUsers; 

        public frmUsersManagement()
        {
            InitializeComponent();
        }

        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            RefreshUsers();   
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]);           
            txtUsername.Text = currentUser.Username;
            txtFirstName.Text = currentUser.FirstName;
            txtLastName.Text = currentUser.LastName;
            txtEmail.Text = currentUser.Email;
            txtDescription.Text = currentUser.Description;
            txtPassword.Text = "";
            txtCreationTime.Text = currentUser.CreationTime.ToString();
            txtLastModify.Text = currentUser.LastChange.ToString();
            txtLastPasswordChange.Text = currentUser.LastPasswordChange.ToString();
            txtIdUserCategory.Text = currentUser.IdUserCategory.ToString();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            User newUser = new User(txtUsername.Text, txtPassword.Text);
            newUser.FirstName = txtFirstName.Text;
            newUser.LastName = txtLastName.Text;
            newUser.Email = txtEmail.Text;
            newUser.Description = txtDescription.Text;
            newUser.IdUserCategory = nextIdUserCategory++;
            bl.CreateUser(newUser);
            RefreshUsers();
        }

        private void btnModifyUser_Click(object sender, EventArgs e)
        {
            User newUser = new User(txtUsername.Text, "");
            newUser.FirstName = txtFirstName.Text;
            newUser.LastName = txtLastName.Text;
            newUser.Email = txtEmail.Text;
            newUser.Description = txtDescription.Text;
            bl.UpdateUser(newUser);
            RefreshUsers();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            User currentUser = (User)lstUsers.SelectedItem;
            currentUser.Password = txtPassword.Text;
            bl.ChangePassword(currentUser);
            RefreshUsers();
        }

        private void RefreshUsers()
        {
            listOfAllUsers = bl.GetAllUsers();
            lstUsers.DataSource = listOfAllUsers;
            User lastUser = (User)lstUsers.Items[lstUsers.Items.Count - 1];
            nextIdUserCategory = (int)lastUser.IdUserCategory + 1;
        }
    }
}
