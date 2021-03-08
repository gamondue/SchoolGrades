using DbClasses;
using SchoolGrades.DbClasses;
using System;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmLogin : Form
    {

        DbAndBusiness db = new DbAndBusiness();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Autentica())
            {
                frmMain f = new frmMain();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Digitare credenziali corrette!");
                this.Close();
            }
        }

        private bool Autentica()
        {
            User u = db.GetUser(txtUsername.Text);

            if (u != null && txtUsername.Text == u.Username && txtPassword.Text == u.Password)
                return true;
            else
                return false; 
        }
    }
}
