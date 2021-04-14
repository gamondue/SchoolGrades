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
            User u = new User("admin", "1234");
            bl.CreateUser(u);
            u.IdUserCategory = 1;
            bl.UpdateUser(u);
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (bl.UserHasLoginPermission(txtUsername.Text, 
                txtPassword.Text))
            {
                frmMain f = new frmMain();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Digitare credenziali corrette!");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (bl.UserHasLoginPermission(txtUsername.Text, txtPassword.Text))
            {
                frmUserManagement f = new frmUserManagement();
                f.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Digitare credenziali corrette!");
        }
    }
}
