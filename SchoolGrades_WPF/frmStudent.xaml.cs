using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmStudent.xaml
    /// </summary>
    public partial class frmStudent : Window
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
            if (currentStudent != null)
            {
                loadStudentData(currentStudent);
            }
            if (isDialog)
            {
                btnChoose.Visibility = Visibility.Visible;
            }
            else
            {
                btnChoose.Visibility = Visibility.Hidden;
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
                chkDisabled.IsChecked = (bool)currentStudent.Disabled;
            else
                chkDisabled.IsChecked = false;
            if (currentStudent.HasSpecialNeeds != null)
                chkHasSpecialNeeds.IsChecked = (bool)currentStudent.HasSpecialNeeds;
            else
                chkHasSpecialNeeds.IsChecked = false;

            loadPicture(currentStudent);
        }
        private void loadPicture(Student StudentToLoad)
        {
            try
            {
                CommonsWpf.loadPicture(picStudent, System.IO.Path.Combine(Commons.PathImages,
                    Commons.bl.GetFilePhoto(StudentToLoad.IdStudent, StudentToLoad.SchoolYear)));
            }
            catch
            {
                //picStudent.Image = null;
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
                currentStudent.Disabled = chkDisabled.IsChecked;
                currentStudent.HasSpecialNeeds = chkHasSpecialNeeds.IsChecked;
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

            //picStudent.Image = null;
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
            dgwSearchedStudents.ItemsSource = (System.Collections.IEnumerable)dt;
        }

        private void btnFindHomonym_Click(object sender, EventArgs e)
        {
            DataTable dt = Commons.bl.GetStudentsSameName(txtLastName.Text, txtFirstName.Text);
            dgwSearchedStudents.ItemsSource = (System.Collections.IEnumerable)dt;
        }

        private void dgwSearchedStudents_CellClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                int key = (int)((DataTable)(dgwSearchedStudents.ItemsSource)).Rows[RowIndex]["idStudent"];
                Student s = Commons.bl.GetStudent(key);
                loadStudentData(s);
                currentStudent = s;
            }
        }

        private void dgwSearchedStudents_CellContentClick(object sender, RoutedEvent e)
        {

        }

        private void dgwSearchedStudents_CellDoubleClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                int key = (int)((DataTable)(dgwSearchedStudents.ItemsSource)).Rows[RowIndex]["idStudent"];
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
