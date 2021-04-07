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
        List<User> allUsers = new List<User>();
        SchoolGrades.BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            //Starts when calling program calls Show().
            allUsers = bl.GetAllUsers();
            lstUser.DataSource = allUsers;
        }

        private void FromClassToUi()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Reads the Class User from UI.
        /// </summary>
        private void FromUiToClass()
        {
            currentUser.LastName = txtLastName.Text;
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            FromUiToClass();
            bl.UpdateUser(currentUser);
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if(!(currentUser is null))
                currentUser.IsEnabled = true;
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            if (!(currentUser is null))
                currentUser.IsEnabled = false;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtDescription.Clear();
            txtUsername.Clear();
            txtName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDescription.ReadOnly = false;
            txtUsername.ReadOnly = false;
            txtName.BackColor = Color.AliceBlue;
            txtLastName.BackColor = Color.AliceBlue;
            txtEmail.BackColor = Color.AliceBlue;
            txtDescription.BackColor = Color.AliceBlue;
            txtUsername.BackColor = Color.AliceBlue;
        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentUser = (User)sender;
            //FromClassToUi();
        }
    }
}
