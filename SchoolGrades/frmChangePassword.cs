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
        DbAndBusiness db = new DbAndBusiness(); // must instatiate after config file reading
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer(); // must instatiate after config file reading

        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnChangeNewPassword_Click_1(object sender, EventArgs e)
        {
            // !!!! TODO !!!! Controlla validità user e old passw.
            if (bl.IsUserAllowed(new User(txtChangedUsername.Text, txtOldPassword.Text)))
            {
                // Crea nuovo user.
                User newUser = new User(txtChangedUsername.Text, txtNewPassword.Text);

                // !!!! TODO !!!! Sovrascrivere nel database il nuovo utente.
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
            // Scrivere nel DataBase le nuove credenziali.
        }
    }
}
