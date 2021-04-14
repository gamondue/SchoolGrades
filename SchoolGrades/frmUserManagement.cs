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
        List<User> users;

        public frmUserManagement()
        {
            InitializeComponent();
        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            users = bl.GetAllUsers();
            foreach (User u in users)
            {
                lstUser.Items.Add(u);
            }
 
        }
        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUser.DataSource = bl.GetAllUsers();
            currentUser = (User)sender;
            FromClassToUi(); 
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
            throw new NotImplementedException();
        }

        private void FromClassToUi()
        {
            txtFirstName.Text = currentUser.FirstName;
            txtLastName.Text = currentUser.LastName;
            txtEmail.Text = currentUser.Email;
            txtDescription.Text = currentUser.Description;
        }
    }
}
