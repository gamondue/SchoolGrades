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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (UtenteAutorizzato(txtUsername.Text, txtPassword.Text))
            {
                frmMain f = new frmMain();
                f.Show();
            }
            else
            {
                MessageBox.Show("Digitare le giuste credenziali!");
            }
        }

        private bool UtenteAutorizzato(string Username, string Password)
        {
            return db.IsUserAllowed(new User(Username, Password)); 
        }
    }
}
