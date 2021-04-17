using SchoolGrades.DbClasses;
using System;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        DbAndBusiness db; // must instatiate after config file reading
        BusinessLayer.BusinessLayer bl; // must instatiate after config file reading
        User User = new User();
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            db = new DbAndBusiness();
            bl = new BusinessLayer.BusinessLayer();

            // test examples
            User u;
            u = new User("pippo", "pluto");
            //u = new User("pina", "pluto");
            ////u = new User("ugo", "pina");
            //bl.CreateUser(u);
            u.Password = "mariangela";
            bl.ChangePassword(u);

            u.FirstName = "Ugo";
            u.LastName = "Fantozzi";
            u.Email = "u.fantozzi@megaditta.com";
            u.Description = "Inferiore Rag. Ugo Fantozzi";
            bl.UpdateUser(u);

            User u1 = bl.GetUser("ugo");
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            User.Username = txtUsername.Text;
            User.Password = txtPassword.Text;
            if (bl.IsUserAllowed(User))
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

        internal User GetUser()
        {
            return User;
        }

        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword();
            frmChangePassword.Show();
            this.Hide();
        }
    }
}
