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
    public partial class frmChangePassword : MetroFramework.Forms.MetroForm
    {
        DbAndBusiness db = new DbAndBusiness(Commons.PathAndFileDatabase); // must instatiate after config file reading
        BusinessLayer bl = new BusinessLayer(Commons.PathAndFileDatabase); // must instatiate after config file reading

        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnChangeNewPassword_Click_1(object sender, EventArgs e)
        {
            if (bl.IsUserAllowed(new User(txtChangedUsername.Text, txtOldPassword.Text)))
            {
                // Crea nuovo user.
                User newUser = new User(txtChangedUsername.Text, txtNewPassword.Text);
                bl.ChangePassword(newUser);
                frmMain f = new frmMain();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("impossibile cambiare password!");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }
    }
}
