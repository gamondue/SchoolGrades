using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmUserManagement : Form
    {
        int IdUtente;
        User currentUser;
        SchoolGrades.BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();

        public frmUserManagement()
        {
            InitializeComponent();
        }
        List<User> listaUtenti = new List<User>();
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            // starts when the calling program calls Show()
            listaUtenti = bl.GetAllUsers();
            lstUser.DataSource = listaUtenti;       
            if (lstUser.Items.Count == 0)
            {
                currentUser = new User("","");
            }
        }
        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void lstUser_DoubleClick(object sender, EventArgs e)
        {           
            currentUser = listaUtenti[lstUser.SelectedIndex];
            IdUtente = lstUser.SelectedIndex;
            if (currentUser.IsEnabled == true)
            {
                btnDisabilita.Text = "Disabilita";
            }
            else
                btnDisabilita.Text = "Abilita";
            FromClassToUi();
        }
        private void FromClassToUi()
        {
            txtLastName.Text = currentUser.LastName;
            txtFirstName.Text = currentUser.FirstName;
            txtEmail.Text = currentUser.Email;
            txtDescription.Text = currentUser.Description;
            txtUsername.Text = currentUser.Username;
            txtId.Text = IdUtente.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FromUiToClass();
            listaUtenti[lstUser.SelectedIndex] = currentUser;
            lstUser.DataSource = listaUtenti;
            bl.UpdateUser(currentUser);
        }
        /// <summary>
        /// Read the Class User from UI
        /// </summary>
        private void FromUiToClass()
        {
            currentUser.LastName = txtLastName.Text;
            currentUser.FirstName = txtFirstName.Text;
            currentUser.Email = txtEmail.Text;
            currentUser.Description = txtDescription.Text;
            currentUser.Username = txtUsername.Text;
            
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            new frmGestionePassword().Show();
        }

        private void btnNuovo_Click(object sender, EventArgs e)
        {
            new frmCreaUtente().Show();
            FromUiToClass();
            lstUser.DataSource = bl.GetAllUsers();
            
        }

        private void btnDisabilita_Click(object sender, EventArgs e)
        {
            if (currentUser.IsEnabled == true)
            {
                currentUser.IsEnabled = false;
                btnDisabilita.Text = "Abilita";
            }
            else
            {
                currentUser.IsEnabled = true;
                btnDisabilita.Text = "Disabilita";
            }
            
        }
    }
}
