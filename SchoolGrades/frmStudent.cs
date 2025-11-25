using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmStudent : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Student CurrentStudent { get => currentStudent; set => currentStudent = value; }
        Student currentStudent = new();
        private bool isDialog;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool UserHasChosen = false;

        public frmStudent(Student Student, bool IsDialog)
        {
            InitializeComponent();
            if (Student != null)
                currentStudent = Student;
            isDialog = IsDialog;
        }
        private void frmStudent_Load(object sender, EventArgs e)
        {
            if (currentStudent != null)
            {
                FromCurrentStudentToUi(currentStudent);
            }
            if (isDialog)
            {
                btnChoose.Visible = true;
            }
            else
            {
                btnChoose.Visible = false;
            }
            txtLastName.Focus();
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
            FromUiToCurrentStudent();
            List<Student> dt = Commons.bl.GetStudentsLike(currentStudent);
            dgwSearchedStudents.DataSource = dt;
        }
        private void FromCurrentStudentToUi(Student currentStudent)
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
        private void FromUiToCurrentStudent()
        {
            // read in currentStudent the data from the UI textboxes
            currentStudent.IdStudent = Safe.Int(txtIdStudent.Text);
            currentStudent.LastName = Safe.String(txtLastName.Text);
            currentStudent.FirstName = Safe.String(txtFirstName.Text);
            currentStudent.City = Safe.String(txtCity.Text);
            currentStudent.Origin = Safe.String(txtOrigin.Text);
            currentStudent.Email = Safe.String(txtEmail.Text);
            //currentStudent.Drawable = Safe.Bool(txtDrawable.Text);
            currentStudent.BirthDate = Safe.DateTime(txtBirthDate.Text);
            currentStudent.BirthPlace = Safe.String(txtBirthPlace.Text);
            currentStudent.Disabled = Safe.Bool(chkDisabled.Checked);
            currentStudent.HasSpecialNeeds = Safe.Bool(chkHasSpecialNeeds.Checked);
            currentStudent.BirthPlace = Safe.String(txtBirthPlace.Text);
            currentStudent.StreetAddress = Safe.String(txtStreetAddress.Text);
            currentStudent.ZipCode = Safe.String(txtZipCode.Text);
            currentStudent.County = Safe.String(txtCounty.Text);
            currentStudent.State = Safe.String(txtState.Text);
            currentStudent.Telephone = Safe.String(txtTelephone.Text);
            currentStudent.Gender = Safe.String(txtGender.Text);
            currentStudent.MobileTelephone = Safe.String(txtMobileTelephone.Text);
        }
        private void btnFindHomonym_Click(object sender, EventArgs e)
        {
            List<Student> dt = Commons.bl.GetStudentsHomonyms(new Student(txtLastName.Text, txtFirstName.Text));
            dgwSearchedStudents.DataSource = dt;
        }
        private void dgwSearchedStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwSearchedStudents_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwSearchedStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwSearchedStudents_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                // sigle click on the row writes data int the textboxes
                List<Student> ls = (List<Student>)dgwSearchedStudents.DataSource;
                int key = (int)(ls[e.RowIndex].IdStudent);
                Student s = Commons.bl.GetStudent(key);
                s.ClassAbbreviation = ls[e.RowIndex].ClassAbbreviation;
                s.SchoolYear = ls[e.RowIndex].SchoolYear;
                FromCurrentStudentToUi(s);
                currentStudent = s;
            }
        }
        private void dgwSearchedStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                // double click on the stident's row opens the class of tha row
                List<Student> l = (List<Student>)dgwSearchedStudents.DataSource;
                int key = (int)(l[e.RowIndex].IdStudent);
                Student s = Commons.bl.GetStudent(key);
                s.ClassAbbreviation = l[e.RowIndex].ClassAbbreviation;
                s.SchoolYear = l[e.RowIndex].SchoolYear;
                FromCurrentStudentToUi(s);
                currentStudent = s;
                if (s != null && s.SchoolYear != null && !string.IsNullOrEmpty(s.ClassAbbreviation))
                {
                    // open the class management form, passing the class of tje clicked sudent
                    Class c = Commons.bl.GetClass("", s.SchoolYear, s.ClassAbbreviation);
                    frmClassesManagement f = new frmClassesManagement(c);
                    f.ShowDialog();
                }
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
            if (currentStudent != null && currentStudent.IdStudent > 0)
            {
                // !!!! TODO: implementare la verifica se lo studente è già associato ad una classe od a voti
                //if (Commons.bl.StudentHasGrades(currentStudent))
                //{
                //    MessageBox.Show("Lo studente " + currentStudent.ToString() + " ha dei voti associati e non può essere +
                //    " eliminato");
                //}
            }
            if (MessageBox.Show("Eliminare lo studente " + currentStudent.ToString() + "?",
                "Eliminazione studente", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("Eliminare lo studente anche dalle tabelle in cui viene riferito?",
                    "Eliminazione studente da tabelle referenziate", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Commons.bl.DeleteStudent(currentStudent, true);
                }
                else
                {
                    Commons.bl.DeleteStudent(currentStudent, false);
                }
                btnNew_Click(null, null);
            }
            else
            {
                MessageBox.Show("Selezionare uno studente da eliminare");
            }
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            currentStudent = null;
            btnSave_Click(null, null);
        }
    }
}
