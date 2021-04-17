 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmUsersManagement : MetroFramework.Forms.MetroForm
    {
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        DataLayer.DataLayer dl = new DataLayer.DataLayer();
        BindingList<User> listOfAllusers;

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
                MessageBox.Show("Errore nel caricamento del form Users managment:\n" + ex.Message,"Users management",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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
            if (grdUsers.SelectedRows == null)
            {
                MessageBox.Show("Nessun utente selezionato da eliminare. ", "Elimina utente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdUsers.Rows.RemoveAt(grdUsers.SelectedRows[0].Index);
            //listOfAllusers.RemoveAt(grdUsers.SelectedRows[0].Index);
        }

        private void mtRefresh_Click(object sender, EventArgs e)
        {
            grdUsers.Columns.Clear();
            LoadGridViewData();
        }

        private void mtSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Do you want to save the changes?","Saving all",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    grdUsers.DataSource = listOfAllusers;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Saving all", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal int? GridRows()
        {
            return grdUsers.Rows.Count;
        }
        internal int? GridColumns()
        {
            return grdUsers.Columns.Count;
        }

        internal void LoadGridViewData()
        {
            try
            {
                grdUsers.DataSource = null;
                grdUsers.Columns.Clear();
                listOfAllusers = new BindingList<User>(dl.GetAllUsers());
                grdUsers.DataSource = listOfAllusers;
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

        private void grdUsers_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 14 && e.RowIndex >= 0)
            {
                //int stdId = int.Parse(grdUsers.Rows[e.RowIndex].Cells[0].Value.ToString()); // cambiare a seconda di cosa vogliamo leggere
                string stdId = grdUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
                UserDetails userDetails = new UserDetails(stdId, this);
                userDetails.StartPosition = FormStartPosition.Manual;

                Rectangle pos = Screen.PrimaryScreen.Bounds;
                userDetails.Location = new Point(pos.Width - userDetails.Width);
                userDetails.ShowDialog();
            }
        }
    }
}
