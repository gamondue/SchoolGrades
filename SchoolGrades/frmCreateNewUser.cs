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
    public partial class frmCreateNewUser : Form
    {
        private bool utenteAbilitato;
        private SchoolGrades.BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        public frmCreateNewUser()
        {
            InitializeComponent();
        }

        private void frmCreateNewUser_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtUsername.Text = txtName.Text + txtLastName.Text + bl.GetAllUsers().Count.ToString();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            txtUsername.Text = txtName.Text + txtLastName.Text + bl.GetAllUsers().Count.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                User user = new User(txtUsername.Text, txtPassword.Text);
                user.Description = txtDescription.Text;
                user.IdUserCategory = bl.GetAllUsers().Count;
                user.FirstName = txtName.Text;
                user.LastName = txtLastName.Text;
                user.IsEnabled = utenteAbilitato;
                user.Email = txtEmail.Text;
                bl.CreateUser(user);
                bl.UpdateUser(user);
                frmUserManagement frm = new frmUserManagement();
                frm.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Password non corrispondenti", "Le password di conferma non corrisponde a quella inserita", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            utenteAbilitato = chkEnabled.Checked;
        }
    }
}
