using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmUsersManagement : Form
    {
        User currentUser;
        //BusinessLayer Commons.bl.; 

        public frmUsersManagement()
        {
            InitializeComponent(); 

        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            // starts when the calling program calls Show()
 
        }
        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUser.DataSource = Commons.bl.GetAllUsers();
            currentUser = (User)sender;
            FromClassToUi(); 
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            FromUiToClass(); 
            Commons.bl.UpdateUser(currentUser); 
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
