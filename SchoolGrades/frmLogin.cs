<<<<<<< HEAD
﻿using DbClasses;
using SchoolGrades.DbClasses;
=======
﻿using SchoolGrades.DbClasses;
>>>>>>> login
using System;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmLogin : Form
    {
<<<<<<< HEAD

        DbAndBusiness db = new DbAndBusiness();
=======
        DbAndBusiness db = new DbAndBusiness(); 
>>>>>>> login

        public frmLogin()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
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
=======
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

        private void frmLogin_Load(object sender, EventArgs e)
        {

>>>>>>> login
        }
    }
}
