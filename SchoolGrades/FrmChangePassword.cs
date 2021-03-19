using System;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class FrmChangePassword : Form
    {
        DbAndBusiness db; // must instatiate after config file reading
        BusinessLayer.BusinessLayer bl; // must instatiate after config file reading

        public FrmChangePassword()
        {
            InitializeComponent();
        }
      
        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            db = new DbAndBusiness();
            bl = new BusinessLayer.BusinessLayer();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (bl.UserHasLoginPermission(txtUsername.Text,
                txtOldPassword.Text))
            {
                bl.ChangePassword(new User(txtUsername.Text,bl.CalculateHash(txtNewPassword.Text)));
            }
            else
            {
                MessageBox.Show("Digitare credenziali corrette!");
            }
            this.Close();
        }
    }

}
