using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SchoolGrades;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmAddUser : MetroFramework.Forms.MetroForm
    {
        BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        DataLayer.DataLayer dl = new DataLayer.DataLayer();

        public frmAddUser()
        {
            InitializeComponent();
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Length == 0)
                    throw new Exception("Username non valido");
                else if (txtPassword.Text.Length == 0)
                    throw new Exception("password non valido");
                else if (txtName.Text.Length == 0)
                    throw new Exception("Nome non valido");
                else if (txtSurname.Text.Length == 0)
                    throw new Exception("Cognome non valido");
                else if (ValidateEmail())
                    throw new Exception(txtEmail.Text.Trim() + " is Invalid Email Address");
                else if (txtDescription.Text.Length == 0)
                    throw new Exception("Descrizione non valida");
                
                User newUser = new User();
                newUser.Username = txtUsername.Text;
                newUser.Password = txtPassword.Text;
                newUser.Email = txtEmail.Text;
                newUser.Description = txtDescription.Text;
                newUser.FirstName = txtName.Text;
                newUser.LastName = txtSurname.Text;
                int id;
                int? val = Int32.TryParse(txtIdCategory.Text, out id) ? Int32.Parse(txtIdCategory.Text) : (int?)null;
                newUser.Salt = txtIdSalt.Text;
                newUser.Password = bl.CalculateHash(txtPassword.Text);
                dl.CreateUser(newUser);
                MessageBox.Show("User create succesfully!", "Add user form", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,"Add user form",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private bool ValidateEmail()
        {
            string email = txtEmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return false;
            else
                return true;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
        //    using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg|PNG|*.png", ValidateNames = true })
        //    {
        //        if (ofd.ShowDialog() == DialogResult.OK)
        //        {
        //            pictureBox1.Image = System.Drawing.Image.FromFile(ofd.FileName);
        //            // BIND SOURCE: Student obj = studentBindingSource.Current as Student;
        //            User obj = 

        //            if (obj != null)
        //                obj.ImageUrl = ofd.FileName;
        //        }
        //    }
        }
    }
}
