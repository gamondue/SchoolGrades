using SchoolGrades.BusinessObjects;
using SharedWinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmAnnotationsAboutStudents : Form
    {
        private string idSchoolYear;
        private StudentAnnotation currentAnnotation;
        private List<Student> chosenStudents;
        private Student currentStudent;
        private string yearUsed;

        /// <summary>
        /// Constructor that passes a list of those to whom the annotation must apply
        /// </summary>
        /// <param name="ChosenStudents"></param>
        /// <param name="IdSchoolYear"></param>
        public frmAnnotationsAboutStudents(List<Student> ChosenStudents, string IdSchoolYear)
        {
            InitializeComponent();

            idSchoolYear = IdSchoolYear; 
            this.chosenStudents = ChosenStudents;
            dgwStudents.DataSource = ChosenStudents; 
        }
        private void frmStudentsNotes_Load(object sender, EventArgs e)
        {
            txtSchoolYear.Text = idSchoolYear;
            yearUsed = idSchoolYear; 
            RefreshUI();

            if (chosenStudents.Count == 1)
            {
                // single student: select him in the grid 
                dgwStudents.Rows[0].Selected = true;
                // set him as current student
                currentStudent = chosenStudents[0];
                // show his annotations
                ShowAnnotationsOfCurrentStudent(); 
            }
        }
        private void RefreshUI()
        {
            dgwNotes.DataSource = Commons.bl.AnnotationsAboutThisStudent(currentStudent, yearUsed,
                chkShowOnlyActive.Checked);
            if (dgwNotes.Rows.Count == 0)
                currentAnnotation = new StudentAnnotation(); 
            WriteUI(); 
        }
        private void WriteUI()
        {
            if (currentAnnotation != null)
            {
                if (currentAnnotation.IdSchoolYear != null)
                    txtSchoolYear.Text = currentAnnotation.IdSchoolYear;
                txtAnnotation.Text = currentAnnotation.Annotation;
                txtIdAnnotation.Text = currentAnnotation.IdAnnotation.ToString();
                if (currentAnnotation.IsActive == null) currentAnnotation.IsActive = false;
                chkCurrentActive.Checked = (bool)currentAnnotation.IsActive;
                if (currentAnnotation.IsPopUp == null) currentAnnotation.IsPopUp = false;
                chkPopUp.Checked = (bool)currentAnnotation.IsPopUp;
            }
        }
        private void ReadUI()
        {
            if (currentAnnotation == null)
                currentAnnotation = new StudentAnnotation();

            currentAnnotation.IdSchoolYear = txtSchoolYear.Text;
            //if (txtAnnotation.Text != "")
                currentAnnotation.IdAnnotation = Safe.Int(txtIdAnnotation.Text);
            ////else
            ////    currentAnnotation.IdAnnotation = null;
            if (currentAnnotation.IdStudent != 0)
                currentAnnotation.IdStudent = Safe.Int(txtIdStudent.Text);
            else
                currentAnnotation.IdStudent = null;
            currentAnnotation.Annotation = txtAnnotation.Text;
            if (currentAnnotation.IsActive == null) currentAnnotation.IsActive = false; 
            currentAnnotation.IsActive = chkCurrentActive.Checked;
            if (currentAnnotation.IsPopUp == null) currentAnnotation.IsPopUp = false; 
            currentAnnotation.IsPopUp = chkPopUp.Checked; 
        }
        private void txtSchoolYear_TextChanged(object sender, EventArgs e)
        {
            //ReadUI(); 
            //RefreshUI();
        }
        private void dgwNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwNotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwNotes.Rows[e.RowIndex].Selected = true;
                
                currentAnnotation = ((List<StudentAnnotation>)dgwNotes.DataSource)[e.RowIndex];
            }
            WriteUI();
        }
        private void btnAddAnnotation_Click(object sender, EventArgs e)
        {
            ReadUI();
            currentAnnotation.InstantTaken = DateTime.Now;
            currentAnnotation.InstantClosed = null; 
            currentAnnotation.IsActive = true;
            //db.SaveAnnotation(currentAnnotation);

            RefreshUI();
        }
        private void SaveAnnotations(bool SaveMany)
        {
            if (currentAnnotation.IdAnnotation == null)
            {
                if (!SaveMany)
                {
                    if (!CommonsWinForms.CheckIfStudentChosen(currentStudent))
                        return;
                    currentAnnotation.IdAnnotation = null;
                    currentAnnotation.IdAnnotation = Commons.bl.SaveAnnotation(currentAnnotation, currentStudent);
                }
                else
                {
                    foreach (Student s in chosenStudents)
                    {
                        currentAnnotation.IdAnnotation = null;
                        currentAnnotation.IdAnnotation = Commons.bl.SaveAnnotation(currentAnnotation, s);
                    }
                }
                return;
            }
            else
            {
                // if IsActive has changed from what is in database then we change dates 
                // according to the status 
                if (Commons.bl.GetAnnotation(currentAnnotation.IdAnnotation).IsActive != currentAnnotation.IsActive)
                {
                    if (currentAnnotation.IsActive == true)
                    {
                        // if it wasn't active and now it is, we set date taken now
                        currentAnnotation.InstantTaken = DateTime.Now;
                        currentAnnotation.InstantClosed = null;
                    }
                    else
                    {
                        // if it was active and now it isn't, we set the date closed now
                        currentAnnotation.InstantClosed = DateTime.Now;
                    }
                }
                if (SaveMany)
                {
                    foreach (Student s in chosenStudents)
                    {
                        Commons.bl.SaveAnnotation(currentAnnotation, s);
                    }
                }
                else
                    Commons.bl.SaveAnnotation(currentAnnotation, currentStudent);
            }
            RefreshUI(); 
        }
        private void ShowAnnotationsOfCurrentStudent()
        {
            txtIdStudent.Text = currentStudent.IdStudent.ToString();
            lblCurrentStudent.Text = $"{currentStudent.LastName} {currentStudent.FirstName}";
            dgwNotes.DataSource = Commons.bl.AnnotationsAboutThisStudent(currentStudent,
              yearUsed, chkShowOnlyActive.Checked);
            RefreshUI();
        }
        private void chkUseSchoolYear_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseSchoolYear.Checked)
            {
                txtSchoolYear.Enabled = true;
                yearUsed = txtSchoolYear.Text;
            }
            else
            {
                txtSchoolYear.Enabled = true;
                yearUsed = null;
            }
            dgwNotes.DataSource = Commons.bl.AnnotationsAboutThisStudent(currentStudent,
                    yearUsed, chkShowOnlyActive.Checked);
        }
        private void btnAddAnnotationStudent_Click(object sender, EventArgs e)
        {
            if (txtAnnotation.Text == "")
            {
                MessageBox.Show("Testo dell'annotazione vuoto!");
                return;
            }
            if (txtIdAnnotation.Text != "")
            {   // an Id is already there 
                if (MessageBox.Show("Devo creare una nuova annotazione con lo stesso testo della precedente?",
                    "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return; 
            }
            ReadUI();
            // null the Id to save a new annotaion 
            currentAnnotation.IdAnnotation = null; 
            SaveAnnotations(false);
            RefreshUI();
        }
        private void btnAddAnnotationGroup_Click(object sender, EventArgs e)
        {
            if (txtAnnotation.Text == "")
            {
                MessageBox.Show("Testo dell'annotazione vuoto!");
                return;
            }
            ReadUI();
            currentAnnotation.IdAnnotation = null; 
            SaveAnnotations(true);
            RefreshUI();
        }
        private void btnRemoveAnnotationStudent_Click(object sender, EventArgs e)
        {
            if (txtIdAnnotation.Text == "")
            {
                MessageBox.Show("Scegliere un'annotazione da cancellare!");
                return;
            }
            if (MessageBox.Show($"Sicuro di cancellare l'annotazione {currentAnnotation.IdAnnotation}, '{currentAnnotation.Annotation}'?",
                "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Commons.bl.EraseAnnotationById(currentAnnotation.IdAnnotation);
                RefreshUI();
            };
        }
        private void btnRemoveAnnotationGroup_Click(object sender, EventArgs e)
        {
            if (txtAnnotation.Text == "")
            {
                MessageBox.Show("Il testo dell'annotazione da cancellare è vuoto!");
                return;
            }
            if (MessageBox.Show($"Cancellazione di tutte le annotazioni '{txtAnnotation.Text}' in tutti gli allievi della griglia?",
                    "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                foreach (Student s in chosenStudents)
                {
                    Commons.bl.EraseAnnotationByText(txtAnnotation.Text, s);
                }
                RefreshUI();
            };
        }
        private void btnSaveModificationsStudent_Click(object sender, EventArgs e)
        {
            if (txtIdAnnotation.Text == "")
            {
                MessageBox.Show("Scegliere un'annotazione da modificare");
                return; 
            }
            if (txtAnnotation.Text == "")
            {
                MessageBox.Show("Testo dell'annotazione vuoto!");
                return;
            }
            ReadUI();
            currentAnnotation.IdAnnotation = Commons.bl.SaveAnnotation(currentAnnotation, currentStudent);
            RefreshUI();
        }
        private void btnSaveModificationsGroup_Click(object sender, EventArgs e)
        {
            // !!!! think how to make this !!!!
            MessageBox.Show("Da fare!"); 
            ////if (txtIdAnnotation.Text == "")
            ////{
            ////    MessageBox.Show("Scegliere un'annotazione da modificare");
            ////    return;
            ////}
            ////if (txtAnnotation.Text == "")
            ////{
            ////    MessageBox.Show("Testo dell'annotazione vuoto!");
            ////    return;
            ////}
            ////ReadUI();
            ////foreach (Student s in chosenStudents)
            ////{

            ////    currentAnnotation.IdAnnotation = db.UpdateAnnotationGroup(currentAnnotation, currentStudent);
            ////}
            ////RefreshUI();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtIdAnnotation.Text = "";
            txtAnnotation.Text = ""; 
        }
        private void chkShowOnlyActive_CheckedChanged(object sender, EventArgs e)
        {
            ReadUI();
            if (currentStudent.IdStudent != null)
            {
                txtIdStudent.Text = currentStudent.IdStudent.ToString();
                lblCurrentStudent.Text = $"{currentStudent.LastName} {currentStudent.FirstName}";
                dgwNotes.DataSource = Commons.bl.AnnotationsAboutThisStudent(currentStudent,
                  yearUsed, chkShowOnlyActive.Checked);
            }
            RefreshUI();
        }
        private void dgwStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwStudents_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwStudents_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwStudents.Rows[e.RowIndex].Selected = true;
                currentStudent = chosenStudents[e.RowIndex];
                ShowAnnotationsOfCurrentStudent();
            }
        }
        private void chkCurrentActive_CheckedChanged(object sender, EventArgs e)
        {
            if(chkCurrentActive.Checked == false)
            {
                chkPopUp.Checked = false; 
            }
        }
    }
}
