using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmStudent : Form
    {
        public Student CurrentStudent { get => currentStudent; set => currentStudent = value; }
        Student currentStudent;
        private bool isDialog;
        internal bool UserHasChosen = false; public frmStudent(Student Student, bool IsDialog)
        {
            InitializeComponent();

            currentStudent = Student;
            isDialog = IsDialog;
        }
        private void frmStudent_Load(object sender, EventArgs e)
        {
            if (currentStudent != null)
            {
                ShowStudentData(currentStudent);
            }
            if (isDialog)
            {
                btnChoose.Visible = true;
            }
            else
            {
                btnChoose.Visible = false;
            }
        }
        private void ShowStudentData(Student currentStudent)
        {
            txtIdStudent.Text = currentStudent.IdStudent.ToString();
            txtLastName.Text = currentStudent.LastName;
            txtFirstName.Text = currentStudent.FirstName;
            txtCity.Text = currentStudent.City;
            txtOrigin.Text = currentStudent.Origin;
            txtEmail.Text = currentStudent.Email;
            //txtDrawable.Text = currentStudent.Drawable;
            txtBirthDate.Text = currentStudent.BirthDate.ToString();
            txtBirthPlace.Text = currentStudent.BirthPlace;
            if (currentStudent.Disabled != null)
                chkDisabled.Checked = (bool)currentStudent.Disabled;
            else
                chkDisabled.Checked = false;
            if (currentStudent.HasSpecialNeeds != null)
                chkHasSpecialNeeds.Checked = (bool)currentStudent.HasSpecialNeeds;
            else
                chkHasSpecialNeeds.Checked = false;
            txtBirthPlace.Text = currentStudent.BirthPlace;
            txtStreetAddress.Text = currentStudent.StreetAddress;
            txtZipCode.Text = currentStudent.ZipCode;
            txtCounty.Text = currentStudent.County;
            txtState.Text = currentStudent.State;
            txtTelephone.Text = currentStudent.Telephone;
            txtGender.Text = currentStudent.Gender;
            txtMobileTelephone.Text = currentStudent.MobileTelephone;

            loadPicture(currentStudent);
        }
        private void loadPicture(Student StudentToLoad)
        {
            try
            {
                // determine the path of the picture, passing it to the calling program 
                // through the property PicturePath of the Student object
                StudentToLoad.PicturePath = Commons.bl.GetFilePhoto(StudentToLoad.IdStudent,
                    StudentToLoad.SchoolYear);
                // use the PicturePath property to load the picture
                picStudent.Image = System.Drawing.Image.FromFile(Path.Combine(Commons.PathImages,
                    StudentToLoad.PicturePath));
            }
            catch
            {
                picStudent.Image = null;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentStudent == null)
                currentStudent = new Student();
            if (currentStudent.LastName != "" || currentStudent.FirstName != "")
            {
                currentStudent.LastName = txtLastName.Text;
                currentStudent.FirstName = txtFirstName.Text;
                currentStudent.City = txtCity.Text;
                currentStudent.Origin = txtOrigin.Text;
                currentStudent.Email = txtEmail.Text;
                currentStudent.Disabled = chkDisabled.Checked;
                currentStudent.HasSpecialNeeds = chkHasSpecialNeeds.Checked;
                try
                {
                    currentStudent.BirthDate = DateTime.Parse(txtBirthDate.Text);
                }
                catch { }
                currentStudent.BirthPlace = txtBirthPlace.Text;
                currentStudent.StreetAddress = txtStreetAddress.Text;
                currentStudent.ZipCode = txtZipCode.Text;
                currentStudent.County = txtCounty.Text;
                currentStudent.State = txtState.Text;
                currentStudent.Telephone = txtTelephone.Text;
                currentStudent.Gender = txtGender.Text;
                currentStudent.MobileTelephone = txtMobileTelephone.Text;
            }
            else
            {
                MessageBox.Show("Immettere Nome e Cognome del nuovo allievo");
                return;
            }
            if (txtIdStudent.Text == "" && (currentStudent.IdStudent == 0 || currentStudent.IdStudent == null))
            {
                currentStudent.IdStudent = 0;
            }
            Commons.bl.SaveStudent(currentStudent);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtIdStudent.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtCity.Text = "";
            txtOrigin.Text = "";
            txtEmail.Text = "";
            //txtDrawable.Text = currentStudent.Drawable;
            txtBirthDate.Text = "";
            txtBirthPlace.Text = "";
            txtBirthPlace.Text = "";
            txtStreetAddress.Text = "";
            txtZipCode.Text = "";
            txtCounty.Text = "";
            txtState.Text = "";
            txtTelephone.Text = "";
            txtGender.Text = "";
            txtMobileTelephone.Text = "";

            picStudent.Image = null;
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (currentStudent != null && currentStudent.IdStudent > 0)
            {
                UserHasChosen = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Salvare o scegliere lo studente");
            }
        }
        private void btnFindStudent_Click(object sender, EventArgs e)
        {
            List<Student> dt = Commons.bl.GetStudentsLike(txtLastName.Text, txtFirstName.Text);
            dgwSearchedStudents.DataSource = dt;
        }
        private void btnFindHomonym_Click(object sender, EventArgs e)
        {
            List<Student> dt = Commons.bl.GetStudentsHomonyms(new Student(txtLastName.Text, txtFirstName.Text));
            dgwSearchedStudents.DataSource = dt;
        }
        private void dgwSearchedStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                List<Student> l = (List<Student>)dgwSearchedStudents.DataSource;
                int key = (int)(l[e.RowIndex].IdStudent);

                //int key = (int)((DataTable)(dgwSearchedStudents.DataSource)).Rows[e.RowIndex]["idStudent"];
                Student s = Commons.bl.GetStudent(key);

                s.ClassAbbreviation = (string)((DataTable)(dgwSearchedStudents.DataSource)).Rows[e.RowIndex]["ClassAbbreviation"];
                s.SchoolYear = (string)((DataTable)(dgwSearchedStudents.DataSource)).Rows[e.RowIndex]["SchoolYear"];
                ShowStudentData(s);
                currentStudent = s;
            }
        }
        private void dgwSearchedStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwSearchedStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                List<Student> l = (List<Student>)dgwSearchedStudents.DataSource;
                int key = (int)(l[e.RowIndex].IdStudent);

                //int key = (int)((DataTable)(dgwSearchedStudents.DataSource)).Rows[e.RowIndex]["idStudent"];
                Student s = Commons.bl.GetStudent(key);
                ShowStudentData(s);
                currentStudent = s;
            }
        }
        //private void frmStudent_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    UserHasChosen = false;
        //}
        private void btnExitWithoutChoosing_Click(object sender, EventArgs e)
        {
            UserHasChosen = false;
            this.Close();
        }
        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DA FARE!!");
        }
    }
}
