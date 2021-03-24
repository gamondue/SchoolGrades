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
        SchoolGrades.BusinessLayer.BusinessLayer bl = new SchoolGrades.BusinessLayer.BusinessLayer();

        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            // starts when the calling program calls Show()
 
        }

        private void btnOK_Click(object sender, EventArgs e)
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
            throw new NotImplementedException();
        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUser.DataSource = bl.GetAllUsers();
            currentUser = (User)sender;
            FromClassToUi();
        }
    }
}
