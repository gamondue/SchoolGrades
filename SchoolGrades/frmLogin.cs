using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SchoolGrades.DbClasses;


namespace SchoolGrades
{
    public partial class frmLogin : Form
    {
        DbAndBusiness db; // must instatiate after config file reading
        BusinessLayer.BusinessLayer bl; // must instatiate after config file reading

        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (bl.UserHasLoginPermission(txtUsername.Text,
                txtPassword.Text))
            {
                frmMain f = new frmMain();
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Digitare credenziali corrette!");
            }
            this.Close();
        }

        private void btnCambia_Click(object sender, EventArgs e)
        {
            new frmUserManagement().Show();
        }

        private void frmLogin_Load_1(object sender, EventArgs e)
        {
            db = new DbAndBusiness();
            bl = new BusinessLayer.BusinessLayer();
        }
    }
}
