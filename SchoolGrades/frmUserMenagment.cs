using SchoolGrades.DbClasses;
using System;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmusermenagment : Form
    {

        User currentUser;
        SchoolGrades.BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        public frmusermenagment()
        {
            InitializeComponent();
        }

        private void frmGestioniUser_Load(object sender, EventArgs e)
        {
           
        }

        private void listUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            listUser.DataSource = bl.GetAllUsers(currentUser);
            currentUser = (User)sender;
            FromClassToUi();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            FromUiToClass();
            bl.UpdateUser(currentUser);
            txtCognome.ReadOnly = true;
            txtCognome.ReadOnly = true;
            txtName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDescription.ReadOnly = true;
            txtUsername.ReadOnly = true;
        }

        private void FromUiToClass()
        {
            currentUser.LastName = txtCognome.Text;
            currentUser.FirstName = txtName.Text;
            currentUser.Email = txtEmail.Text;
            currentUser.Description = txtDescription.Text;
            currentUser.Username = txtUsername.Text;
            
        }

        private void FromClassToUi()
        {
            txtCognome.Text = currentUser.LastName;
            txtName.Text = currentUser.FirstName;
            txtEmail.Text = currentUser.Email;
            txtDescription.Text = currentUser.Description;
            txtUsername.Text = currentUser.Username;
        }

        private void Abilita_Click(object sender, EventArgs e)
        {
            currentUser.IsEnabled = true;
        }

        private void Disabilita_Click(object sender, EventArgs e)
        {
            currentUser.IsEnabled = false;
        }

        private void Modifica_Click(object sender, EventArgs e)
        {
            txtCognome.ReadOnly = false;
            txtCognome.ReadOnly = false;
            txtName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDescription.ReadOnly = false;
            txtUsername.ReadOnly = false;
        }
    }
}
