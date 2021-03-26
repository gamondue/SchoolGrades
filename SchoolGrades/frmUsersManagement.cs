using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmUsersManagement : Form
    {
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();

        List<User> listOfAllUsers; 

        public frmUsersManagement()
        {
            InitializeComponent();
        }

        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            listOfAllUsers = bl.GetAllUsers(); 
            lstUsers.DataSource = listOfAllUsers; 
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
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            User newUser = new User(txtUsername.Text, txtPassword.Text);
            newUser.FirstName = txtFirstName.Text;
            newUser.LastName = txtLastName.Text;
            newUser.Email = txtEmail.Text;
            newUser.Description = txtDescription.Text;
            bl.CreateUser(newUser);
            listOfAllUsers = bl.GetAllUsers();
            lstUsers.DataSource = listOfAllUsers;
        }

        private void btnModifyUser_Click(object sender, EventArgs e)
        {
            User newUser = new User(txtUsername.Text, "");
            newUser.FirstName = txtFirstName.Text;
            newUser.LastName = txtLastName.Text;
            newUser.Email = txtEmail.Text;
            newUser.Description = txtDescription.Text;
            bl.UpdateUser(newUser);
            listOfAllUsers = bl.GetAllUsers();
            lstUsers.DataSource = listOfAllUsers;
        }
    }
}
