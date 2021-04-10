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
            grbUpdates.Visible = true;
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
                        throw new ArgumentException("The password must have at least 7 characters.");
                    else
                    {
                        currentUser.Password = txtNewPw.Text;
                        bl.ChangePassword(currentUser);
                    }

                bl.UpdateUser(currentUser);
                grbUpdates.Visible = false;
                lstUsers.SelectedIndex.ToString().Replace(lstUsers.SelectedIndex.ToString(), currentUser.Username);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A problem has occured:\n" + ex.Message, "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            grbUpdates.Visible = true;
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
                    throw new ArgumentException("The new user must have a username!");
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
                        throw new ArgumentException("The password must have at least 7 characters.");
                    else
                        newUser.Password = txtNewPw.Text;
                else
                    throw new ArgumentException("The new user must have a password!");

                bl.CreateUser(newUser);
                listOfAllUsers.Add(newUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A problem has occured:\n" + ex.Message, "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
