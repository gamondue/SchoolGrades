using SchoolGrades.BusinessObjects;
using System;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            // test examples
            User u;
            u = new User("pippo", "pluto");
            //u = new User("pina", "pluto");
            ////u = new User("ugo", "pina");
            //Commons.bl.CreateUser(u);
            u.Password = "mariangela";
            Commons.bl.ChangePassword(u);

            u.FirstName = "Ugo";
            u.LastName = "Fantozzi";
            u.Email = "u.fantozzi@megaditta.com";
            u.Description = "Inferiore Rag. Ugo Fantozzi";
            Commons.bl.UpdateUser(u);

            User u1 = Commons.bl.GetUser("ugo");
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Commons.bl.HasUserLoginPermission(txtUsername.Text,
                txtPassword.Text))
            {
                //frmMain f = new frmMain(Commons.PathAndFileDatabase);
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
    }
}
