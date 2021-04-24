using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmUsersManagement : Form
    {
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();

        List<User> listOfAllUsers = new List<User>();

        int index = 0;

        public frmUsersManagement()
        {
            InitializeComponent();
            btnInserisciUser.Enabled = false;
        }

        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            listOfAllUsers = bl.GetAllUsers();
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]); 
        }

        private void btnInserisciUser_Click(object sender, EventArgs e)
        {
            try
            {
                listOfAllUsers.Add(new User(txtUserName.Text, txtFirstName.Text, txtLastName.Text, txtDescription.Text, txtEmail.Text));
                lstUsers.Items.Add(listOfAllUsers.ToArray()[index].ToString());
                index++;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRORE: {ex.Message}", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally
            {
                ClearAll();
                txtUserName.Focus();
            }
        }

        private void DataCheck()
        {
            if (txtEmail.Text.Contains("@") && txtEmail.Text.Contains(".com") || txtEmail.Text.Contains(".it"))
                if (txtFirstName.Text.Length != 0 && txtLastName.Text.Length != 0 && txtUserName.Text.Length != 0 && txtDescription.Text.Length != 0 && txtEmail.Text.Length != 0)
                    btnInserisciUser.Enabled = true;
                else
                    btnInserisciUser.Enabled = false;
            else
                btnInserisciUser.Enabled = false;
        }

        private void ClearAll()
        {
            txtDescription.Clear();
            txtEmail.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtUserName.Clear();
            DataCheck();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            DataCheck();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            DataCheck();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            DataCheck();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            DataCheck();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            DataCheck();
        }
    }
}
