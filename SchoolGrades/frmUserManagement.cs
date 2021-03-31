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
        SchoolGrades.BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        public frmUserManagement()
        {
            InitializeComponent();
        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            // starts when the calling program calls Show()
            if(lstUser.Items.Count==0)
                lstUser.DataSource = bl.GetAllUsers();

        }
        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentUser = (User)lstUser.SelectedItem;
            FromClassToUi();
            btnCreate.Visible = false;
            btnCreateUser.Enabled = true;
            txtUsername.ReadOnly = true;
            txtPassword.ReadOnly = true;
        }

        private void FromClassToUi()
        {
            txtLastName.Text = currentUser.LastName;
            txtFirstName.Text = currentUser.FirstName;
            txtDescription.Text = currentUser.Description;
            txtUsername.Text = currentUser.Username;
            txtPassword.Text = currentUser.Password;
            txtEmail.Text = currentUser.Email;
            txtIDUserCategory.Text = currentUser.IdUserCategory.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FromUiToClass(); 
            bl.UpdateUser(currentUser); 
        }
        /// <summary>
        /// Read the Class User from UI
        /// </summary>
        private void FromUiToClass()
        {
            currentUser.LastName = txtLastName.Text;
            currentUser.FirstName = txtFirstName.Text;
            currentUser.Username = txtUsername.Text;
            currentUser.Password = txtPassword.Text;
            currentUser.Email = txtEmail.Text;
            currentUser.CreationTime = DateTime.Now;
            currentUser.Description = txtDescription.Text;
            currentUser.IdUserCategory = User.NUserCreated++;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            SvuotaCampi();
            btnCreate.Visible = true;
            txtUsername.ReadOnly = false;
            txtPassword.ReadOnly = false;
            btnCreateUser.Enabled = false;
            btnSave.Enabled = false;
            btnChangePassword.Enabled = false;
        }
        private void SvuotaCampi()
        {
            txtLastName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtIDUserCategory.Text = string.Empty;
        }
        private void ControlloCampi()
        {
            if(txtLastName.Text!=string.Empty &&
                txtFirstName.Text != string.Empty &&
                txtDescription.Text != string.Empty &&
                txtUsername.Text != string.Empty &&
                txtPassword.Text != string.Empty &&
                txtEmail.Text != string.Empty)
                btnCreate.Enabled = true;
            else
                btnCreate.Enabled = false;
        }

        private void txtMenu_TextChanged(object sender, EventArgs e)
        {
            ControlloCampi();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            btnCreate.Visible = false;
            User u = new User(string.Empty, string.Empty);
            currentUser = u;
            FromUiToClass();
            bl.CreateUser(currentUser);
            btnCreateUser.Enabled = true;
            btnSave.Enabled = true;
            btnChangePassword.Enabled = true;
            lstUser.DataSource = bl.GetAllUsers();
        }

    }
}
