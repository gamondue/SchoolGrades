using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmUsersManagement : Form
    {
        User currentUser;

        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();

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
            currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]);
        }

        private void InfoUtente_Click(object sender, EventArgs e)
        {
            
        }

        private void EliminaUtente_Click(object sender, EventArgs e)
        {
            for(int i=0;i < lstUsers.Items.Count;i++)
                if (listOfAllUsers[i].ToString().ToUpper() == lstUsers.Items[lstUsers.SelectedIndex].ToString().ToUpper())
                {
                    listOfAllUsers.RemoveAt(i);
                    lstUsers.Items.RemoveAt(lstUsers.SelectedIndex);
                    return;
                }

            MessageBox.Show("Errore", "Non è stato possibile eliminare l'utente",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void AggiungiUtente_Click(object sender, EventArgs e)
        {
            if(PasswordInfo.Text.Length >5 && SurnameInfo.Text !=""&& NameInfo.Text !="")
            {
                foreach(User user in listOfAllUsers)
                {
                    //if(user.FirstName== SurnameInfo.Text 
                }
            }
        }

        
    }
}
