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
            if (lstUsers.SelectedIndex != -1)
            {
                btnMod.Enabled = true;
                User currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]);
                txtUsername.Text = currentUser.Username;
                txtPassword.Text = currentUser.Password;
                txtEmail.Text = currentUser.Email;
                lblDescription.Text = "Descrizione : " + currentUser.Description;
            }
            else
            {
                btnMod.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User newUser = new User(txtNewUsername.Text, txtNewPassword.Text);
            newUser.Email = txtNewEmail.Text;
            newUser.Description = txtNewDescription.Text;
            newUser.CreationTime = DateTime.Now;
            newUser.IdUserType = 0;
            newUser.IdUserCategory = listOfAllUsers.Count + 1;
            newUser.FirstName = txtNewName.Text;
            newUser.LastName = txtNewLastName.Text;
            bl.CreateUser(newUser);
            listOfAllUsers = bl.GetAllUsers();
            lstUsers.DataSource = listOfAllUsers;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]);
            User newUser = new User();
            newUser.Email = txtEmail.Text;
            newUser.Description = currentUser.Description;
            newUser.CreationTime = currentUser.CreationTime;
            newUser.IdUserType = currentUser.IdUserType;
            newUser.IdUserCategory = currentUser.IdUserCategory;
            newUser.FirstName = currentUser.LastName;
            newUser.LastName = currentUser.LastName;
            bl.UpdateUser(newUser);
            listOfAllUsers = bl.GetAllUsers();
            lstUsers.DataSource = listOfAllUsers;
        }

    }
}
