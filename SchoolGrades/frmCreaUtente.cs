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
                FromUiToClass();
                currentUser.CreationTime = DateTime.Now;
                frmUserManagement.bl.CreateUser(currentUser);
                frmUserManagement.bl.UpdateUser(currentUser);
                this.Hide();
                this.Close();
                frmUserManagement s = new frmUserManagement();
                s.Show();
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
            currentUser.IsEnabled = true;
        }
    }
}
