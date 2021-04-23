using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmUsersManagement : Form
    {
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        User currentUser;

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
            currentUser = listOfAllUsers[lstUsers.SelectedIndex]; 
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            grbUpdates.Enabled = true;
            btnConfirmCreation.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewUsername.Text.Length != 0)
                    currentUser.Username = txtNewUsername.Text;
                if (txtNewLN.Text.Length != 0)
                    currentUser.LastName = txtNewLN.Text;
                if (rTxtNewDescription.Text.Length != 0)
                    currentUser.Description = rTxtNewDescription.Text;
                if (txtNewEmail.Text.Length != 0)
                    currentUser.Email = txtNewEmail.Text;
                if (txtNewFirst.Text.Length != 0)
                    currentUser.FirstName = txtNewFirst.Text;
                if (txtNewPw.Text.Length != 0)
                    if (txtNewPw.Text.Length < 7)
                        throw new ArgumentException("La password deve avere almeno 7 caratteri.");
                    else
                    {
                        currentUser.Password = txtNewPw.Text;
                        bl.ChangePassword(currentUser);
                    }

                bl.UpdateUser(currentUser);
                listOfAllUsers = bl.GetAllUsers();
                lstUsers.DataSource = listOfAllUsers;
                grbUpdates.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Si è verificato un problema:\n" + ex.Message, "ERRORE", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            grbUpdates.Enabled = true;
            btnSave.Enabled = false;
            btnModifica.Enabled = false;
        }

        private void btnConfirmCreation_Click(object sender, EventArgs e)
        {
            try
            {
                User newUser = new User();

                if (txtNewUsername.Text.Length != 0)
                    newUser.Username = txtNewUsername.Text;
                else
                    throw new ArgumentException("Il nuovo utente deve avere un username!");
                if (txtNewLN.Text.Length != 0)
                    newUser.LastName = txtNewLN.Text;
                if (rTxtNewDescription.Text.Length != 0)
                    newUser.Description = rTxtNewDescription.Text;
                if (txtNewEmail.Text.Length != 0)
                    newUser.Email = txtNewEmail.Text;
                if (txtNewFirst.Text.Length != 0)
                    newUser.FirstName = txtNewFirst.Text;
                if (txtNewPw.Text.Length != 0)
                    if (txtNewPw.Text.Length < 7)
                        throw new ArgumentException("La password deve avere almeno 7 caratteri.");
                    else
                        newUser.Password = txtNewPw.Text;
                else
                    throw new ArgumentException("Il nuovo utente deve avere una password!");

                bl.CreateUser(newUser);
                listOfAllUsers = bl.GetAllUsers();
                lstUsers.DataSource = listOfAllUsers;
                grbUpdates.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Si è verificato un problema:\n" + ex.Message, "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //private void ShowInfo(ListBox l)
        //{
        //    User u = (User)l.SelectedIndex;
        //}
    }
}
