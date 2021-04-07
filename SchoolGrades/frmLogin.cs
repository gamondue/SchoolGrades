using SchoolGrades.DbClasses;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SchoolGrades
{

    public partial class frmLogin : Form
    {
        DbAndBusiness db; // must instatiate after config file reading
        BusinessLayer.BusinessLayer bl; // must instatiate after config file reading
        User u;

        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            db = new DbAndBusiness(); 
            bl = new BusinessLayer.BusinessLayer();

            

            //u = new User("pippo", "pluto");
            //u = new User("pina", "pluto");
            u = new User("ugo", "pina");
            bl.CreateUser(u);
            u.Password = "mariangela";
            //u.Password = Criptazione(u.Password); //criptazione
            bl.ChangePassword(u);

            u.FirstName = "Ugo";
            u.LastName = "Fantozzi";
            u.Email = "u.fantozzi@megaditta.com";
            u.Description = "Inferiore Rag. Ugo Fantozzi";
            bl.UpdateUser(u);

            User u1 = bl.GetUser("ugo");
        }

        //private string Criptazione(string password)
        //{
        //    using (SHA256 hash = SHA256.Create())
        //    {
        //        byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        StringBuilder builder = new StringBuilder();
        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString("x2"));
        //        }
        //        return builder.ToString();
        //    }
        //}

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (bl.UserHasLoginPermission(txtUsername.Text, 
                txtPassword.Text) && bl.IsUserAllowed(u) == true)
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {

        }
    }
}
