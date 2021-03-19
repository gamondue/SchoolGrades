using System;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class FrmRegisterUser : Form
    {
        DbAndBusiness db; // must instatiate after config file reading
        BusinessLayer.BusinessLayer bl; // must instatiate after config file reading

        public FrmRegisterUser()
        {
            InitializeComponent();
        }

        private void FrmRegisterUser_Load(object sender, EventArgs e)
        {
            db = new DbAndBusiness();
            bl = new BusinessLayer.BusinessLayer();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            User newUser = new User(txtUsername.Text,bl.CalculateHash(txtPassword.Text),txtFirstName.Text,txtLastName.Text,txtEmail.Text,txtDescription.Text);
            bl.CreateUser(newUser);
            this.Close();
        }
    }
}
