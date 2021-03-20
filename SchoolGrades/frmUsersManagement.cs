using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SchoolGrades.BusinessLayer;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmUsersManagement : Form
    {
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer(); 

        public frmUsersManagement()
        {
            InitializeComponent();
        }

        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = bl.GetAllUsers(); 
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserControl currentUser = (User)listBox1[listBox1.SelectedIndex]; 
        }
    }
}
