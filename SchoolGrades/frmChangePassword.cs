using System;
using SchoolGrades.DbClasses;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmChangePassword : Form
    {
        DbAndBusiness db; // must instatiate after config file reading
        BusinessLayer.BusinessLayer bl; // must instatiate after config file reading

        public frmChangePassword()
        {
            InitializeComponent();
        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            Commons.ReadConfigFile();

            while (!System.IO.File.Exists(Commons.PathAndFileDatabase))
            {
                MessageBox.Show("Configurazione del programma.\r\nSe necessario sistemare le cartelle (si possono anche lasciare così), poi scegliere il file di dati .sqlite e premere 'Salva configurazione'");
                FrmSetup f = new FrmSetup();
                f.ShowDialog();
                //return; 
            }
            db = new DbAndBusiness();
            bl = new BusinessLayer.BusinessLayer();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (bl.IsUserAllowed(new User(txtUsername.Text,
                txtOldPassword.Text)))
            {
                bl.ChangePassword(new User(txtUsername.Text, txtNewPassword.Text));
                this.Close();
            }
            else
            {
                MessageBox.Show("Digitare credenziali corrette!");
            }

        }
    }
}
