using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class UserDetails : MetroFramework.Forms.MetroForm
    {
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        DataLayer.DataLayer dl = new DataLayer.DataLayer();

        public UserDetails()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            //dl.UpdateUser();
            //lblUpdatingUser.Text = "Updating user";
        }
    }
}
