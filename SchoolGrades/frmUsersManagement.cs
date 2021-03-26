using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmUsersManagement : MetroFramework.Forms.MetroForm
    {
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        DataLayer.DataLayer dl = new DataLayer.DataLayer();

        List<User> listOfAllUsers = new List<User>(); 

        public frmUsersManagement()
        {
            InitializeComponent();
        }

        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGridViewData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Errore nel caricamento del form Users managment\n" + ex.Message,"Users management",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            //listOfAllUsers = dl.GetAllUsers(); 
            //lstUsers.DataSource = listOfAllUsers; 
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //User currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]); 
        }

        private void mtAddUser_Click(object sender, EventArgs e)
        {
            using (frmAddUser frmAddUser = new frmAddUser())
            {
                frmAddUser.ShowDialog();
            }
        }

        private void mtDeleteUser_Click(object sender, EventArgs e)
        {

        }

        private void mtUpdateUser_Click(object sender, EventArgs e)
        {
            //User newUser = new User();
            //newUser.Username = txtUsername.Text;
            //newUser.Password = txtPassword.Text;
            //newUser.Email = txtEmail.Text;
            //newUser.Description = txtDescription.Text;
            //newUser.FirstName = txtName.Text;
            //newUser.LastName = txtSurname.Text;
            //int id;
            //int? val = Int32.TryParse(txtIdCategory.Text, out id) ? Int32.Parse(txtIdCategory.Text) : (int?)null;
            //newUser.Salt = txtIdSalt.Text;
            //dl.CreateUser(newUser);
            // TODO: AGGIORNARE LA GRID
            //listOfAllUsers = dl.GetAllUsers();
            //lstUsers.DataSource = listOfAllUsers;
            MessageBox.Show("User create succesfully!", "Add user form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //listOfAllUsers = dl.GetAllUsers();
            //lstUsers.DataSource = listOfAllUsers;
        }

        private void mtRefresh_Click(object sender, EventArgs e)
        {

        }

        private void mtSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Do you want to save the changes?","Saving all",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // !!! TODO !!!
                    
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Saving all", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadGridViewData()
        {
            try
            {
                grdUsers.DataSource = null;
                grdUsers.Columns.Clear();
                //User u = new User();
                grdUsers.DataSource = dl.GetAllUsers();
                DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
                bc.HeaderText = "Action";
                bc.Text = "Details";
                bc.Name = "Details";
                bc.UseColumnTextForButtonValue = true;
                bc.Width = 50;
                grdUsers.Columns.Add(bc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento degli utenti\n" + ex.Message, "Users management",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void grdUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.ColumnIndex == 6 && e.RowIndex >= 0)
            //{
            //    int stdId = int.Parse(grdUsers.Rows[e.RowIndex].Cells[0].Value.ToString());
            //    UserDetails userDetails = new UserDetails(stdId, this);
            //    userDetails.StartPosition = FormStartPosition.Manual;

            //    Rectangle pos = Screen.PrimaryScreen.Bounds;
            //    userDetails.StartPosition = new Point(pos.Width - userDetails.Width);
            //    userDetails.ShowDialog();
            //}
        }
    }
}
