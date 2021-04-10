using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmUsersManagement : Form
    {
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();

        List<User> listOfAllUsers;
        User currentUser;
        public frmUsersManagement()
        {
            InitializeComponent();
            grbUpdates.Visible = false;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            listOfAllUsers = bl.GetAllUsers();
            lstUsers.DataSource = listOfAllUsers;
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentUser = (listOfAllUsers[lstUsers.SelectedIndex]);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (!grbUpdates.Visible)
                grbUpdates.Visible = true;
            else
                grbUpdates.Visible = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Length < 1)
                    throw new Exception("The new utent must contains an username!");
                if (txtPassword.Text.Length < 6)
                    throw new Exception("Password must contains min 6 characters.");
                User newUser = new User(txtUsername.Text, txtPassword.Text);

                if (txtLastName.Text.Length > 1)
                    newUser.LastName = txtLastName.Text;
                if (rtxtDescription.Text.Length > 1)
                    newUser.Description = rtxtDescription.Text;
                if (txtEmail.Text.Length > 1)
                    newUser.Email = txtEmail.Text;
                if (txtFirstName.Text.Length > 1)
                    newUser.FirstName = txtFirstName.Text;

                listOfAllUsers.Add(newUser);
                bl.CreateUser(newUser);

            }
            catch (Exception ex)
            {
                MessageBox.Show("There is a problem!" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Prima aggiorniamo proprietà dello User, e poi tramite il metodo della classe Business layer
        // "Update User" aggiorna il database.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Length > 1)
                    currentUser.Username = txtUsername.Text;
                if (txtLastName.Text.Length > 1)
                    currentUser.LastName = txtLastName.Text;
                if (rtxtDescription.Text.Length > 1)
                    currentUser.Username = rtxtDescription.Text;
                if (txtEmail.Text.Length > 1)
                    currentUser.Email = txtEmail.Text;
                if (txtFirstName.Text.Length > 1)
                    currentUser.FirstName = txtFirstName.Text;
                if (txtPassword.Text.Length < 6)
                {
                    txtPassword.Focus();
                    throw new Exception("Password must contains min 6 characters.");
                }

                currentUser.Password = txtPassword.Text;

                bl.ChangePassword(currentUser);
                bl.UpdateUser(currentUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is problem!" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShow.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnDeleteSelctedUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Da implementare", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Maybe usando GetUser(username) ?
            //try
            //{
            //    if (lstUsers.SelectedIndex < 0)
            //        throw new Exception("No user selected!");

            //    string userToDelete = lstUsers.SelectedItem.ToString();


            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("There is problem!" + ex.Message,
            //         "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
