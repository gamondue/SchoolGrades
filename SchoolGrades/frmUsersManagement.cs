using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmUsersManagement : Form
    {
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        DataLayer.DataLayer dl = new DataLayer.DataLayer();

        List<User> listOfAllUsers;

        public frmUsersManagement()
        {
            InitializeComponent();
        }

        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            listOfAllUsers = bl.GetAllUsers(); 
            lstUsers.DataSource = listOfAllUsers;
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show("Errore");
            }
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]); 
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (bl == null)
            {
                MessageBox.Show("Nessun utete eliminato");
            }
        }

        private void btnCrea_Click(object sender, EventArgs e)
        {
            if(bl == null)
            {
                MessageBox.Show("Nessun utente creato");
            }
        }
    }
}
