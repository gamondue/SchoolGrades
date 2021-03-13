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
                this.Close();
            }
        }
    }
}
