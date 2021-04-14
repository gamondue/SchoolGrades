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
        SchoolGrades.BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        public frmUserManagement()
        {
            InitializeComponent();
        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            // starts when the calling program calls Show()
            if(lstUser.Items.Count==0 || lstUser.SelectedItem == null)
                lstUser.DataSource = bl.GetAllUsers();
            if (lstUser.SelectedItem == null)
                AbilitaOrDisabilitaTxtBox(false);
            else
                AbilitaOrDisabilitaTxtBox(true);
        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentUser = (User)lstUser.SelectedItem;
            FromClassToUi();
            btnCreate.Visible = false;
            btnCreateUser.Enabled = true;
            txtUsername.ReadOnly = true;
            txtPassword.ReadOnly = true;
            if (currentUser.IsEnabled == true)
                checkBoxEnabled.Checked = true;
            else
                checkBoxEnabled.Checked = false;
        }

        private void FromClassToUi()
        {
            txtLastName.Text = currentUser.LastName;
            txtFirstName.Text = currentUser.FirstName;
            txtDescription.Text = currentUser.Description;
            txtUsername.Text = currentUser.Username;
            txtPassword.Text = currentUser.Password;
            txtEmail.Text = currentUser.Email;
            txtIDUserCategory.Text = lstUser.SelectedIndex.ToString();
        }
        private void FromUiToClass()
        {
            currentUser.LastName = txtLastName.Text;
            currentUser.FirstName = txtFirstName.Text;
            currentUser.Username = txtUsername.Text;
            currentUser.Password = txtPassword.Text;
            currentUser.Email = txtEmail.Text;
            currentUser.CreationTime = DateTime.Now;
            currentUser.Description = txtDescription.Text;
            currentUser.IdUserCategory = lstUser.SelectedIndex;
            if (checkBoxEnabled.Checked)
                currentUser.IsEnabled = true;
            else
                currentUser.IsEnabled = false;
        }
        /// <summary>
        /// Read the Class User from UI
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            FromUiToClass();
            if (checkBoxEnabled.Checked)
                currentUser.IsEnabled = true;
            else
                currentUser.IsEnabled = false;
            bl.UpdateUser(currentUser);
            currentUser.LastChange = DateTime.Now;
            lstUser.DataSource = bl.GetAllUsers();
        }
        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            SvuotaCampi();
            AbilitaOrDisabilitaTxtBox(true);
            btnCreate.Visible = true;
            btnCreate.Enabled = false;
            btnCreateUser.Enabled = false;
            btnChange.Visible = false;
            btnChange.Enabled = false;
            txtUsername.ReadOnly = false;
            txtPassword.ReadOnly = false;
            btnSave.Enabled = false;
            btnChangePassword.Enabled = false;
            lblPasswordConfirm.Visible = true;
            txtPasswordConfirm.Visible = true;
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            btnCreate.Visible = false;
            User u = new User(string.Empty, string.Empty);
            currentUser = u;
            FromUiToClass();
            bl.CreateUser(currentUser);
            if (checkBoxEnabled.Checked)
                currentUser.IsEnabled = true;
            else
                currentUser.IsEnabled = false;
            bl.UpdateUser(currentUser);
            btnCreateUser.Enabled = true;
            btnSave.Enabled = true;
            btnChangePassword.Enabled = true;
            lblPasswordConfirm.Visible = false;
            txtPasswordConfirm.Visible = false;
            txtPasswordConfirm.Text = string.Empty;
            lstUser.DataSource = bl.GetAllUsers();
        }
        private void txtMenu_TextChanged(object sender, EventArgs e)
        {
            ControlloCampi();
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            AbilitaOrDisabilitaTxtBox(false);
            btnCreateUser.Enabled = false;
            btnChange.Enabled = false;
            btnChange.Visible = true;
            btnCreate.Visible = false;
            btnCreate.Enabled = false;
            btnSave.Enabled = false;
            btnChangePassword.Enabled = false;
            txtPassword.Enabled = true;
            txtPassword.ReadOnly = false;
            lblPasswordConfirm.Visible = true;
            txtPasswordConfirm.Visible = true;
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            btnChange.Visible = false;
            User u = new User(string.Empty, string.Empty);
            currentUser = u;
            FromUiToClass();
            currentUser.Password = txtPassword.Text;
            bl.ChangePassword(currentUser);
            btnCreateUser.Enabled = true;
            btnSave.Enabled = true;
            btnChangePassword.Enabled = true;
            lstUser.DataSource = bl.GetAllUsers();
            AbilitaOrDisabilitaTxtBox(true);
            txtPassword.ReadOnly = true;
            lblPasswordConfirm.Visible = false;
            txtPasswordConfirm.Visible = false;
            txtPasswordConfirm.Text = string.Empty;
            currentUser.LastPasswordChange = DateTime.Now;
        }

        //metodi aggiuntivi
        private void SvuotaCampi()
        {
            txtLastName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtIDUserCategory.Text = string.Empty;
        }
        private void ControlloCampi()
        {
            if (txtLastName.Text != string.Empty &&
                txtFirstName.Text != string.Empty &&
                txtDescription.Text != string.Empty &&
                txtUsername.Text != string.Empty &&
                txtPassword.Text != string.Empty &&
                txtEmail.Text != string.Empty &&
                txtPasswordConfirm.Text != string.Empty &&
                txtPasswordConfirm.Text == txtPassword.Text)
            {
                btnCreate.Enabled = true;
                btnChange.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
                btnChange.Enabled = false;
            }
        }
        private void AbilitaOrDisabilitaTxtBox(bool p)
        {
            txtLastName.Enabled = p;
            txtFirstName.Enabled = p;
            txtDescription.Enabled = p;
            txtEmail.Enabled = p;
            txtUsername.Enabled = p;
            txtPassword.Enabled = p;
            txtIDUserCategory.Enabled = p;
            checkBoxEnabled.Enabled = p;
        }

    }
}
