using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmUserManagement : Form
    {
        User currentUser;
        bool isChangingIndex = false;
        SchoolGrades.BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer(); 

        public frmUserManagement()
        {
            InitializeComponent();
        }
        private List<User> lst;
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            // starts when the calling program calls Show()
            lst = bl.GetAllUsers();
            lstUser.DataSource = lst;
        }
        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentUser = lst[lstUser.SelectedIndex];
            FromClassToUi();
            isChangingIndex = true;
        }

        private void FromClassToUi()
        {
            txtUsername.Text = currentUser.Username;
            txtFirstName.Text = currentUser.FirstName;
            txtLastName.Text = currentUser.LastName;
            txtPassword.Text = currentUser.Password;
            txtEmail.Text = currentUser.Email;
            txtDescrizione.Text = currentUser.Description;
            txtId.Text = currentUser.IdUserCategory.ToString();
            checkBoxAbilitato.Checked = (bool)currentUser.IsEnabled;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FromUiToClass(); 
            bl.UpdateUser(currentUser);
            bl.ChangePassword(currentUser);
        }
        /// <summary>
        /// Read the Class User from UI
        /// </summary>
        private void FromUiToClass()
        {
            currentUser.Username = txtUsername.Text;
            currentUser.FirstName = txtFirstName.Text;
            currentUser.LastName = txtLastName.Text;
            currentUser.Password = txtPassword.Text;
            currentUser.Email = txtEmail.Text;
            currentUser.Description = txtDescrizione.Text;
            currentUser.IsEnabled = checkBoxAbilitato.Checked;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if(isChangingIndex)
            {
                btnSave.Enabled = true;
                btnCrea.Enabled = false;
                isChangingIndex = false;
            }
            else
            {
                btnSave.Enabled = false;
                btnCrea.Enabled = true;
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtPassword.Text = "";
                txtEmail.Text = "";
                txtDescrizione.Text = "";
                checkBoxAbilitato.Checked = false;
            }
        }

        private void btnCrea_Click(object sender, EventArgs e)
        {
            User u = new User("", "");
            currentUser = u;

            if(lst.Count == 0)
            {
                currentUser.IdUserCategory = 0;
            }
            else
            {
                currentUser.IdUserCategory = lst[lst.Count - 1].IdUserCategory + 1;
            }

            FromUiToClass();
            bl.CreateUser(currentUser);
            bl.UpdateUser(currentUser);
            btnSave.Enabled = true;
            btnCrea.Enabled = false;
            lst = bl.GetAllUsers();
            lstUser.DataSource = lst;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            currentUser.IsEnabled = checkBoxAbilitato.Checked;
            bl.UpdateUser(currentUser);
        }
    }
}
