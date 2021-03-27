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
            txtUtente.Text = currentUser.Username;
            txtPass.Text = currentUser.Password;
            txtMail.Text = currentUser.Email;
            lblDescrizione.Text = "Descrizione : " + currentUser.Description;
        }

        private void btnCambiaCredenziali_Click(object sender, EventArgs e)
        {
            //not completed yet.
            User currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]);
            User newUser = new User(txtUtente.Text, txtPass.Text);
            newUser.Email = currentUser.Email;
            // bisogna applicare i cambiamenti al DB.
        }
    }
}
