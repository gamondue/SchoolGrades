using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SchoolGrades.BusinessObjects;

namespace SchoolGrades
{
    public partial class frmStudent : Form
    {
        Student currentStudent;
        private bool isDialog;

        internal bool UserHasChosen = false;

        public Student CurrentStudent { get => currentStudent; set => currentStudent = value; }
        public frmStudent(Student Student, bool IsDialog)
        {
            InitializeComponent();

            currentStudent = Student;
            isDialog = IsDialog; 
        }
        private void frmStudent_Load(object sender, EventArgs e)
        {
            if(currentStudent != null)
            {
                loadStudentData(currentStudent); 
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
        private void loadStudentData(Student currentStudent)
        {
            txtIdStudent.Text = currentStudent.IdStudent.ToString();
            txtLastName.Text = currentStudent.LastName;
            txtFirstName.Text = currentStudent.FirstName;
            txtResidence.Text = currentStudent.Residence;
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

            loadPicture(currentStudent);
        }
        private void loadPicture(Student StudentToLoad)
        {
            try
            {
                picStudent.Image = System.Drawing.Image.FromFile(Commons.PathImages + "\\" +
                    Commons.bl.GetFilePhoto(StudentToLoad.IdStudent, StudentToLoad.SchoolYear));
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
                currentStudent.Residence = txtResidence.Text;
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
            txtResidence.Text = "";
            txtOrigin.Text = "";
            txtEmail.Text = "";
            //txtDrawable.Text = currentStudent.Drawable;
            txtBirthDate.Text = "";
            txtBirthPlace.Text = "";

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
            DataTable dt = Commons.bl.FindStudentsLike(txtLastName.Text, txtFirstName.Text);
            dgwSearchedStudents.DataSource = dt;
        }

        private void btnFindHomonym_Click(object sender, EventArgs e)
        {
            DataTable dt = Commons.bl.GetStudentsSameName(txtLastName.Text, txtFirstName.Text);
            dgwSearchedStudents.DataSource = dt;
        }

        private void dgwSearchedStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int key = (int)((DataTable)(dgwSearchedStudents.DataSource)).Rows[e.RowIndex]["idStudent"];
                Student s = Commons.bl.GetStudent(key);
                loadStudentData(s);
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
                int key = (int)((DataTable)(dgwSearchedStudents.DataSource)).Rows[e.RowIndex]["idStudent"];
                Student s = Commons.bl.GetStudent(key);
                loadStudentData(s);
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
