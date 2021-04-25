using SchoolGrades.DbClasses;
using SharedWinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmAnnotationsAboutStudents : Form
    {
        DbAndBusiness db;
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

            db = new DbAndBusiness(db.DatabaseName); 

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
            dgwNotes.DataSource = db.AnnotationsAboutThisStudent(currentStudent, yearUsed,
                chkAnnotationsShowActive.Checked);
        }

        private void ReadUI()
        {
            if (currentAnnotation == null)
                currentAnnotation = new StudentAnnotation();

            currentAnnotation.IsActive = chkCurrentAnnotationActive.Checked;
            currentAnnotation.IdSchoolYear = txtSchoolYear.Text;
            if (txtAnnotation.Text != "")
                currentAnnotation.IdAnnotation = SafeDb.SafeInt(txtIdAnnotation.Text);
            else
                currentAnnotation.IdAnnotation = null;
            if (currentAnnotation.IdStudent != 0)
                currentAnnotation.IdStudent = SafeDb.SafeInt(txtIdStudent.Text);
            else
                currentAnnotation.IdStudent = null;
            currentAnnotation.Annotation = txtAnnotation.Text;
        }

        private void txtSchoolYear_TextChanged(object sender, EventArgs e)
        {
            ReadUI(); 
            RefreshUI();
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

                txtIdAnnotation.Text = currentAnnotation.IdAnnotation.ToString();
                txtAnnotation.Text = currentAnnotation.Annotation;
                chkCurrentAnnotationActive.Checked = (bool)currentAnnotation.IsActive;
                txtSchoolYear.Text = currentAnnotation.IdSchoolYear;
                txtIdStudent.Text = currentAnnotation.IdStudent.ToString();
                chkCurrentAnnotationActive.Checked = (bool)currentAnnotation.IsActive; 
            }
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
                    currentAnnotation.IdAnnotation = db.SaveAnnotation(currentAnnotation, currentStudent);
                }
                else
                {
                    foreach (Student s in chosenStudents)
                    {
                        currentAnnotation.IdAnnotation = null;
                        currentAnnotation.IdAnnotation = db.SaveAnnotation(currentAnnotation, s);
                    }
                }
                return;
            }
            else
            {
                // if IsActive has changed from what is in database then we change dates 
                // according to the status 
                if (db.GetAnnotation(currentAnnotation.IdAnnotation).IsActive != currentAnnotation.IsActive)
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
                        db.SaveAnnotation(currentAnnotation, s);
                    }
                }
                else
                    db.SaveAnnotation(currentAnnotation, currentStudent);
            }
            RefreshUI(); 
        }

        private void ShowAnnotationsOfCurrentStudent()
        {
            txtIdStudent.Text = currentStudent.IdStudent.ToString();
            lblCurrentStudent.Text = $"{currentStudent.LastName} {currentStudent.FirstName}";
            dgwNotes.DataSource = db.AnnotationsAboutThisStudent(currentStudent,
              yearUsed, chkAnnotationsShowActive.Checked);
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
            dgwNotes.DataSource = db.AnnotationsAboutThisStudent(currentStudent,
                    yearUsed, chkAnnotationsShowActive.Checked);
        }

        private void btnAddAnnotationStudent_Click(object sender, EventArgs e)
        {
            if (txtAnnotation.Text == "")
            {
                MessageBox.Show("Testo dell'annotazione vuoto!");
                return;
            }
            ReadUI();
            // null the Id to save new annotaion 
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
                db.EraseAnnotationById(currentAnnotation.IdAnnotation);
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
                    db.EraseAnnotationByText(txtAnnotation.Text, s);
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
            currentAnnotation.IdAnnotation = db.SaveAnnotation(currentAnnotation, currentStudent);
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

        private void chkAnnotationsShowActive_CheckedChanged(object sender, EventArgs e)
        {
            ReadUI();
            if (currentStudent.IdStudent != null)
            {
                txtIdStudent.Text = currentStudent.IdStudent.ToString();
                lblCurrentStudent.Text = $"{currentStudent.LastName} {currentStudent.FirstName}";
                dgwNotes.DataSource = db.AnnotationsAboutThisStudent(currentStudent,
                  yearUsed, chkAnnotationsShowActive.Checked);
            }
            RefreshUI();
        }
        private void dgwStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwStudents.Rows[e.RowIndex].Selected = true;
                currentStudent = chosenStudents[e.RowIndex];
                ShowAnnotationsOfCurrentStudent();
            }
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
    }
}
