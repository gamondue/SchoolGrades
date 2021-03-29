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
        List<User> listaUtenti;
        User currentUser;
        SchoolGrades.BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer(); 

        public frmUserManagement()
        {
            InitializeComponent();
        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            // starts when the calling program calls Show()
            listaUtenti = bl.GetAllUsers();
            ListaUtenti.DataSource = listaUtenti;
        }
        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentUser = listaUtenti[ListaUtenti.SelectedIndex];
            FromClassToUi();
        }

        private void FromClassToUi()
        {
            txtEmail.Text = currentUser.Email;
            txtDescription.Text = currentUser.Description;
            txtPass.Text = currentUser.Password;
            txtName.Text = currentUser.FirstName;
            txtLastName.Text = currentUser.LastName;
            txtUsername.Text = currentUser.Username;
            if ((bool)currentUser.IsEnabled)
            {
                chkIsUserEnabled.Checked = true;
            }
            else
            {
                chkIsUserEnabled.Checked = false;
            }
            txtID.Text = currentUser.IdUserCategory.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FromUiToClass(); 
            bl.UpdateUser(currentUser); 
        }
        /// <summary>
        /// Read the Class User from UI
        /// </summary>
        private void FromUiToClass()
        {
            currentUser.LastName = txtLastName.Text;
            currentUser.FirstName = txtName.Text;
            currentUser.Email = txtEmail.Text;
            currentUser.Username = txtUsername.Text;
            currentUser.LastChange = DateTime.Now;
            currentUser.Description = txtDescription.Text;
            currentUser.Email = txtEmail.Text;
            if (chkIsUserEnabled.Checked)
            {
                currentUser.IsEnabled = true;
            }
            currentUser.IdUserCategory = Convert.ToInt32(txtID.Text);
        }
    }
}
