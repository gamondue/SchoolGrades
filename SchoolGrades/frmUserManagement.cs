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
        User currentUser;
        BusinessLayer blUser; 

        public frmUserManagement()
        {
            InitializeComponent();

            blUser = new BusinessLayer(Commons.PathAndFileDatabase);
        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            // starts when the calling program calls Show()
 
        }
        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUser.DataSource = blUser.GetAllUsers();
            currentUser = (User)sender;
            FromClassToUi(); 
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            FromUiToClass(); 
            blUser.UpdateUser(currentUser); 
        }
        /// <summary>
        /// Read UI's controls's content from the currentUser User object's properties
        /// </summary>
        private void FromClassToUi()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Read the currentUser User object properties from the UI's controls
        /// </summary>
        private void FromUiToClass()
        {
            currentUser.LastName = txtLastName.Text; 
            throw new NotImplementedException();
        }
    }
}
