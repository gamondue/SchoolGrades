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
    public partial class frmUserMenagment : Form
    {
        User currentUser;
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        List<User> listOfAllUsers;
        public frmUserMenagment()
        {
            InitializeComponent();
        }

        private void frmUserMenagment_Load(object sender, EventArgs e)
        {
            listOfAllUsers = bl.GetAllUsers();
            lstUser.DataSource = listOfAllUsers;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtLastName.Text == "" || txtFirstName.Text == "")
            {
                FromUiToClass();
                bl.UpdateUser(currentUser);
            }
        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUser.SelectedIndex != 0)
            {
                btnAbilita.Enabled = true;
                btnDisabilita.Enabled = true;
                btnModifica.Enabled = true;
            }

            currentUser = (User)(listOfAllUsers[lstUser.SelectedIndex]);
            FromClassToUi();
        }

        private void FromUiToClass()
        {
            currentUser.LastName = txtLastName.Text;
            currentUser.FirstName = txtFirstName.Text;
            currentUser.Description = txtDescription.Text;
            currentUser.Email = txtEmail.Text;
            currentUser.Username = txtUsername.Text;
        }
        private void FromClassToUi()
        {
            txtLastName.Text = currentUser.LastName;
            txtFirstName.Text = currentUser.FirstName;
            txtEmail.Text = currentUser.Email;
            txtDescription.Text = currentUser.Description;
            txtUsername.Text = currentUser.Username;
        }

        private void btnAbilita_Click(object sender, EventArgs e)
        {
            currentUser.IsEnabled = true;
        }
        private void btnDisabilita_Click(object sender, EventArgs e)
        {
            currentUser.IsEnabled = false;
        }


        /*
        private void txt_Click(object sender, EventArgs e)
        {
            if(lstUser.SelectedIndex != 0)
            {
                lstUser.SelectedIndex = 0;
                txtFirstName.Clear();
                txtLastName.Clear();
            }
        }
        */
    }
}
