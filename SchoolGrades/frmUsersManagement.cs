using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmUsersManagement : Form
    {
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
            User currentUser = (User)(listOfAllUsers[lstUsers.SelectedIndex]);
            textBox1.Text = currentUser.Username;
            textBox2.Text = currentUser.Password;
            textBox3.Text = currentUser.FirstName;
            textBox4.Text = currentUser.LastName;
            textBox6.Text = currentUser.Email;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            User newUser = new User(user, pass);
            newUser.FirstName = textBox3.Text;
            newUser.LastName = textBox4.Text;
            newUser.Email = textBox6.Text;
            listOfAllUsers.Add(newUser);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listOfAllUsers[lstUsers.SelectedIndex].Username = textBox1.Text;
            listOfAllUsers[lstUsers.SelectedIndex].Password = textBox2.Text;
            listOfAllUsers[lstUsers.SelectedIndex].FirstName = textBox3.Text;
            listOfAllUsers[lstUsers.SelectedIndex].LastName = textBox4.Text;
            listOfAllUsers[lstUsers.SelectedIndex].Email = textBox6.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listOfAllUsers.Remove(listOfAllUsers[lstUsers.SelectedIndex]);
            Update_List();
        }

        private void Update_List()
        {
            lstUsers.Items.Clear();
            listOfAllUsers = bl.GetAllUsers();
            lstUsers.DataSource = listOfAllUsers;
        }
    }
}
