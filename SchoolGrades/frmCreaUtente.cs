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
    public partial class frmCreaUtente : Form
    {
        User currentUser;
        SchoolGrades.BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        public frmCreaUtente()
        {
            InitializeComponent();
        }

        private void frmCreaUtente_Load(object sender, EventArgs e)
        {
            currentUser = new User("", "");
        }

        private void btnCreaUtente_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfermaPassword.Text)
            {
                lblErrore.Visible = true;
            }
            else
            {
                lblErrore.Visible = false;
                currentUser.CreationTime = DateTime.Now;
                FromUiToClass();
                bl.CreateUser(currentUser);
                //bl.UpdateUser(currentUser);
                this.Hide();
                this.Close();
            }
        }
        private void FromUiToClass()
        {
            currentUser.LastName = txtLastName.Text;
            currentUser.FirstName = txtFirstName.Text;
            currentUser.Email = txtEmail.Text;
            currentUser.Description = txtDescription.Text;
            currentUser.Username = txtUsername.Text;
            currentUser.Password = txtConfermaPassword.Text;
        }
    }
}
