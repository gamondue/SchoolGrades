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
            if(lstUsers.SelectedIndex != -1)
            {
                btnCambiaCredenziali.Enabled = true;
                User currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]);
                txtUtente.Text = currentUser.Username;
                txtPass.Text = currentUser.Password;
                txtMail.Text = currentUser.Email;
                lblDescrizione.Text = "Descrizione : " + currentUser.Description;
            }
            else
            {
                btnCambiaCredenziali.Enabled = false;
            }
            
        }

        private void btnCambiaCredenziali_Click(object sender, EventArgs e)
        {
            User currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]);
            User newUser = new User(txtUtente.Text, txtPass.Text);
            newUser.Email = txtMail.Text;
            newUser.Description = currentUser.Description;
            newUser.CreationTime = currentUser.CreationTime;
            newUser.IdUserType = currentUser.IdUserType;
            newUser.IdUserCategory = currentUser.IdUserCategory;
            newUser.FirstName = currentUser.LastName;
            newUser.LastName = currentUser.LastName;
            bl.UpdateUser(newUser);
        }

        private void btnCreaUtente_Click(object sender, EventArgs e)
        {
            User newUser = new User(txtNewUser.Text, txtNewPass.Text);
            newUser.Email = txtNewMail.Text;
            newUser.Description = txtDescription.Text;
            newUser.CreationTime = DateTime.Now;
            newUser.IdUserType = 0;
            newUser.IdUserCategory = listOfAllUsers.Count+1;
            newUser.FirstName = txtName.Text;
            newUser.LastName = txtSurname.Text;
            bl.CreateUser(newUser);
            listOfAllUsers = bl.GetAllUsers();
            lstUsers.DataSource = listOfAllUsers;
        }
    }
}
