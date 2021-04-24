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

        User currentUser;

        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            lstUser.DataSource = listOfAllUsers; 
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentUser = (User)(listOfAllUsers[lstUser.SelectedIndex]);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Length > 1)
                {
                    currentUser.Username = txtUsername.Text;
                }

                if (txtSurname.Text.Length > 1)
                {
                    currentUser.LastName = txtSurname.Text;
                }

                if (txtDescription.Text.Length > 1)
                {
                    currentUser.Username = txtDescription.Text;
                }

                if (txtEmail.Text.Length > 1)
                {
                    currentUser.Email = txtEmail.Text;
                }

                if (txtName.Text.Length > 1)
                {
                    currentUser.FirstName = txtName.Text;
                }

                if (txtPassword.Text.Length < 4)
                {
                    throw new Exception("Password deve contenere minimo 4 caratteri");
                }

                currentUser.Password = txtPassword.Text;

                bl.ChangePassword(currentUser);
                //bl.UpdateUser(currentUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Length < 1)
                    throw new Exception("Deve esserci un Username");
                if (txtPassword.Text.Length < 4)
                    throw new Exception("Password deve contenere minimo 4 caratteri");
                User newUser = new User(txtUsername.Text, txtPassword.Text);

                if (txtSurname.Text.Length > 1)
                {
                    newUser.LastName = txtSurname.Text;
                }

                if (txtDescription.Text.Length > 1)
                {
                    newUser.Description = txtDescription.Text;
                }

                if (txtEmail.Text.Length > 1)
                {
                    newUser.Email = txtEmail.Text;
                }

                if (txtName.Text.Length > 1)
                {
                    newUser.FirstName = txtName.Text;
                }

                bl.CreateUser(newUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
