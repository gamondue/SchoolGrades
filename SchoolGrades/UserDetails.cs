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
    public partial class UserDetails : MetroFramework.Forms.MetroForm
    {
        DataLayer.DataLayer dl = new DataLayer.DataLayer("");
        string userId = null;
        frmUsersManagement home = null;

        public UserDetails(string id, frmUsersManagement s)
        {
            InitializeComponent();
            userId = id;
            home = s;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            try
            {
                dl.UpdateUserOverride(txtUsername.Text,txtSurname.Text,txtName.Text,txtPassword.Text,txtEmail.Text," ",DateTime.Now,DateTime.Now,DateTime.Now,txtIdSalt.Text,true,int.Parse(txtIdCategory.Text));
                lblUpdatingUser.ForeColor = Color.LawnGreen;
                lblUpdatingUser.Text = "Updating user done.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "User detail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {
            try
            {

                User user = new User(txtUsername.Text,txtPassword.Text);
                DataTable dt = dl.GetUserByUserId(user.Username); // userId

                if(dt.Rows.Count > 0)
                {
                    txtUsername.Text = dt.Rows[0]["Username"].ToString();
                    txtSurname.Text = dt.Rows[0]["LastName"].ToString();
                    txtName.Text = dt.Rows[0]["FirstName"].ToString();
                    txtPassword.Text = dt.Rows[0]["Password"].ToString();
                    string des = dt.Rows[0]["Description"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    DateTime? dataTime = (DateTime)dt.Rows[0]["CreationeTime"];
                    DateTime? change = (DateTime)dt.Rows[0]["LastChange"];
                    DateTime? passwChange = (DateTime)dt.Rows[0]["LastPasswordChange"];
                    txtIdSalt.Text = dt.Rows[0]["Salt"].ToString();
                    txtIdCategory.Text = dt.Rows[0]["IdUserCategory"].ToString();
                    bool? en = (bool)dt.Rows[0]["IsEnabled"];
                    int? id = int.Parse(dt.Rows[0]["IdUserType"].ToString());
                    string img = dt.Rows[0]["ImageUrl"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,"User detail",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }
    }
}
