using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmUsersManagementListBox : MetroFramework.Forms.MetroForm
    {
        BusinessLayer bl = new BusinessLayer(Commons.PathAndFileDatabase);
        List<User> listOfAllUsers;
        DataLayer.DataLayer dl = new DataLayer.DataLayer(Commons.PathAndFileDatabase);
        
        public frmUsersManagementListBox()
        {
            InitializeComponent();
        }
        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            listOfAllUsers = dl.GetAllUsers();
            lstUsers.DataSource = listOfAllUsers;
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]);
            txtUsername.Text = currentUser.Username;
            txtName.Text = currentUser.FirstName;
            txtSurname.Text = currentUser.LastName;
            txtEmail.Text = currentUser.Email;
            txtDescription.Text = currentUser.Description;
            txtPassword.Text = "";
        }

        private void btnNewUser_Click_1(object sender, EventArgs e)
        {
            User newUser = new User(txtUsername.Text, txtPassword.Text);
            newUser.FirstName = txtName.Text;
            newUser.LastName = txtSurname.Text;
            newUser.Email = txtEmail.Text;
            newUser.Description = txtDescription.Text;
            newUser.IdUserCategory = int.Parse(txtIdCategory.Text); // TODO
            newUser.Salt = txtIdSalt.Text;
            bl.CreateUser(newUser);
            listOfAllUsers = dl.GetAllUsers();
            lstUsers.DataSource = listOfAllUsers;
        }

        private void btnModifyUser_Click_1(object sender, EventArgs e)
        {
            User newUser = new User(txtUsername.Text, "");
            newUser.FirstName = txtName.Text;
            newUser.LastName = txtSurname.Text;
            newUser.Email = txtEmail.Text;
            newUser.Description = txtDescription.Text;
            newUser.IdUserCategory = int.Parse(txtIdCategory.Text); // TODO
            newUser.Salt = txtIdSalt.Text;
            bl.UpdateUser(newUser);
            listOfAllUsers = dl.GetAllUsers();
            lstUsers.DataSource = listOfAllUsers;
        }
    }
}
