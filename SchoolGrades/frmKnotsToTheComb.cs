using SchoolGrades.BusinessObjects;
using System;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmKnotsToTheComb : Form
    {
        private Question chosenQuestion = new Question();
        private frmMicroAssessment grandparentForm; 

        private Student currentStudent;
        private SchoolSubject currentSubject;
        private string currentIdSchoolYear;
        private int currentIdGrade;

        bool isLoading = true;

        internal Question ChosenQuestion { get; private set; }
        public frmKnotsToTheComb(frmMicroAssessment GrandparentForm, int? IdStudent, SchoolSubject SchoolSubject, string Year)
        {
            InitializeComponent();
            currentStudent = Commons.dl.GetStudent(IdStudent);
            lblStudent.Text = currentStudent.LastName + " " + currentStudent.FirstName; 
            currentIdSchoolYear = Year;
            currentSubject = SchoolSubject;
            grandparentForm = GrandparentForm; 

            // fills the lookup tables' combos
            cmbSchoolSubject.DisplayMember = "Name";
            cmbSchoolSubject.ValueMember = "idSchoolSubject";
            cmbSchoolSubject.DataSource = Commons.dl.GetListSchoolSubjects(true);

            currentSubject = SchoolSubject; 
            ChosenQuestion = null; 
        }
        private void FrmKnotsToTheComb_Load(object sender, EventArgs e)
        {
            if (currentSubject.IdSchoolSubject != null)
                cmbSchoolSubject.SelectedValue = currentSubject.IdSchoolSubject; 
            RefreshData(); 
        }
        private void RefreshData()
        {
            dgwQuestions.DataSource = Commons.dl.GetUnfixedGrades(currentStudent, currentSubject.IdSchoolSubject, 60);
        }
        private void DgwQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DgwQuestions_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow r = dgwQuestions.Rows[e.RowIndex];
                txtQuestionText.Text = (string)r.Cells["Text"].Value;
                currentIdGrade = (int)r.Cells["IdQuestion"].Value;
            }
        }
        private void DgwQuestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwQuestions.Rows[e.RowIndex].Selected = true; 
            }
        }
        private void DgwQuestions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // choose this question
            // !!!! TODO !!!!
        }
        private void BtnFix_Click(object sender, EventArgs e)
        {
            if (dgwQuestions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare la domanda che è stata riparata");
                return; 
            }
            DataGridViewRow r = dgwQuestions.SelectedRows[0];
            currentIdGrade = (int)r.Cells["IdGrade"].Value;
            if (MessageBox.Show("La domanda '" + (string)r.Cells["Text"].Value + "' è stata riparata?","Riparazione domanda",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Commons.bl.FixQuestionInGrade(currentIdGrade);
                RefreshData(); 
            }
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (dgwQuestions.SelectedRows.Count > 0)
            {
                //int key = int.Parse(dgwQuestions.SelectedRows[0].Cells[6].Value.ToString());
                int key = (int) dgwQuestions.SelectedRows[0].Cells[6].Value;
                ChosenQuestion = Commons.bl.GetQuestionById(key);
                if (grandparentForm != null)
                {
                    // form called by student's assessment form 
                    grandparentForm.CurrentQuestion = ChosenQuestion; 
                    grandparentForm.DisplayCurrentQuestion(); 
                }
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Scegliere una domanda nella griglia");
                return;
            }
        }
        private void cmbSchoolSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSubject = (SchoolSubject) cmbSchoolSubject.SelectedItem; 
            this.BackColor = Commons.ColorFromNumber(currentSubject);
            RefreshData();
        }
    }
}
