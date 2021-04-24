using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

/// <summary>
/// Andrea Siboni
/// 4L
/// </summary>
namespace SchoolGrades
{
    public partial class frmUsersManagement : Form
    {
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        User currentUser;

        List<User> listOfAllUsers; 

        public frmUsersManagement()
        {
            InitializeComponent();
        }

        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            listOfAllUsers = bl.GetAllUsers(); 
            lstUsers.DataSource = listOfAllUsers; 
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]); 
        }

        private void btnCreaUtente_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = true;
            txtNome.Enabled = true;
            txtDescrizione.Enabled = true;
            txtPassword.Enabled = true;
            txtCognome.Enabled = true;
            txtEmail.Enabled = true;
            btnSalvaModifiche.Enabled = false;
            btnConfermaCreazione.Enabled = true;
            btnCambiaDatiUtente.Enabled = false;
            txtUsername.Text = "";
            txtNome.Text = "";
            txtCognome.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            txtDescrizione.Text = "";
        }

        private void btnCambiaDatiUtente_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = true;
            txtNome.Enabled = true;
            txtDescrizione.Enabled = true;
            txtPassword.Enabled = true;
            txtCognome.Enabled = true;
            txtEmail.Enabled = true;
            btnSalvaModifiche.Enabled = true;
            btnConfermaCreazione.Enabled = false;
        }

        private void btnConfermaCreazione_Click(object sender, EventArgs e)
        {
            try
            {
                User newUser = new User();

                if (txtUsername.Text.Length != 0)
                    newUser.Username = txtUsername.Text;
                else
                    throw new ArgumentException("Il nuovo utente deve avere un username!");
                if (txtCognome.Text.Length != 0)
                    newUser.LastName = txtCognome.Text;
                if (txtDescrizione.Text.Length != 0)
                    newUser.Description = txtDescrizione.Text;
                if (txtEmail.Text.Length != 0)
                    newUser.Email = txtEmail.Text;
                if (txtNome.Text.Length != 0)
                    newUser.FirstName = txtNome.Text;
                if (txtPassword.Text.Length != 0)
                    if (txtPassword.Text.Length < 7)
                        throw new ArgumentException("La password deve avere almeno 7 caratteri.");
                    else
                        newUser.Password = txtPassword.Text;
                else
                    throw new ArgumentException("Il nuovo utente deve avere una password!");

                bl.CreateUser(newUser);
                listOfAllUsers.Add(newUser);
                listOfAllUsers = bl.GetAllUsers();
                lstUsers.DataSource = listOfAllUsers;

                txtUsername.Enabled = false;
                txtNome.Enabled = false;
                txtDescrizione.Enabled = false;
                txtPassword.Enabled = false;
                txtCognome.Enabled = false;
                txtEmail.Enabled = false;
                btnSalvaModifiche.Enabled = false;
                btnConfermaCreazione.Enabled = false;
                btnCambiaDatiUtente.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Si è verificato un problema:\n" + ex.Message, "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSalvaModifiche_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Length != 0)
                    currentUser.Username = txtUsername.Text;
                if (txtCognome.Text.Length != 0)
                    currentUser.LastName = txtCognome.Text;
                if (txtDescrizione.Text.Length != 0)
                    currentUser.Description = txtDescrizione.Text;
                if (txtEmail.Text.Length != 0)
                    currentUser.Email = txtEmail.Text;
                if (txtNome.Text.Length != 0)
                    currentUser.FirstName = txtNome.Text;
                if (txtPassword.Text.Length != 0)
                    if (txtPassword.Text.Length < 7)
                        throw new ArgumentException("La password deve avere almeno 7 caratteri.");
                    else
                    {
                        currentUser.Password = txtPassword.Text;
                        bl.ChangePassword(currentUser);
                    }

                bl.UpdateUser(currentUser);
                listOfAllUsers = bl.GetAllUsers();
                txtUsername.Enabled = false;
                txtNome.Enabled = false;
                txtDescrizione.Enabled = false;
                txtPassword.Enabled = false;
                txtCognome.Enabled = false;
                txtEmail.Enabled = false;
                btnSalvaModifiche.Enabled = false;
                btnConfermaCreazione.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Si è verificato un problema:\n" + ex.Message, "ERRORE", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
