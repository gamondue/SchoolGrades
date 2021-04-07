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
        SchoolGrades.BusinessLayer.BusinessLayer bl = new SchoolGrades.BusinessLayer.BusinessLayer();
        List<User> listOfAllUsers;

        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            listOfAllUsers = bl.GetAllUsers();
            lstUser.DataSource = listOfAllUsers;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FromUiToClass();
            txtUsername.ReadOnly = true;
            txtName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDescription.ReadOnly = true;
            bl.UpdateUser(currentUser);
        }

        /// <summary>
        /// Read the Class User from UI
        /// </summary>
        
        private void FromUiToClass()
        {
            currentUser.LastName = txtLastName.Text;
            currentUser.FirstName = txtName.Text;
            currentUser.Email = txtEmail.Text;
            currentUser.Description = txtDescription.Text;
            currentUser.Username = txtUsername.Text;
        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lstUser.DataSource = bl.GetAllUsers();
            //currentUser = (User)sender;
            currentUser = (User)(listOfAllUsers[lstUser.SelectedIndex]);
            FromClassToUi();
            btnDisable.Enabled = true;
            btnEnable.Enabled = true;
        }

        private void FromClassToUi()
        {
            txtName.Text = currentUser.FirstName;
            txtLastName.Text = currentUser.LastName;
            txtDescription.Text = currentUser.Description;
            txtEmail.Text = currentUser.Email;
            txtUsername.Text = currentUser.Username;
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            currentUser.IsEnabled = false;
            bl.UpdateUser(currentUser);
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            currentUser.IsEnabled = true;
            bl.UpdateUser(currentUser);
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            txtUsername.ReadOnly = false;
            txtName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDescription.ReadOnly = false;
        }
    }
}
