using SchoolGrades.DbClasses;
using System;
using System.Windows.Forms;

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
        private void frmLogin_Load(object sender, EventArgs e)
        {
            bl = new BusinessLayer.BusinessLayer();
            //username = admin password = 1234
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
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            //if (bl.UserHasLoginPermission(txtUsername.Text, txtPassword.Text))
            //{
                frmUserManagement f = new frmUserManagement();
                this.Hide();
                f.ShowDialog();
            //}
            //else
            //    MessageBox.Show("Digitare credenziali corrette!");
        }
    }
}
