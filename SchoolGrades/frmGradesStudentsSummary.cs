using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmGradesStudentsSummary : Form
    {
        private Student currentStudent;
        private Grade currentGrade = new Grade(); 
        private string currentSchoolYear;
        private GradeType currentGradeType;
        private SchoolSubject currentSchoolSubject;
        private StudentAnnotation currentAnnotation;
        private SchoolPeriod currentSchoolPeriod; 

        public frmGradesStudentsSummary(Student Student, string IdSchoolYear,
            GradeType GradeType, SchoolSubject SchoolSubject)
        {
            InitializeComponent();
            currentStudent = Student;
            currentSchoolYear = IdSchoolYear;
            currentGradeType = GradeType;
            currentSchoolSubject = SchoolSubject;

            lblCurrentStudent.Text = $"{Student.LastName} {Student.FirstName}";
            currentAnnotation = new StudentAnnotation();
        }
        private void frmGradesStudentsSummary_Load(object sender, EventArgs e)
        {
            if (currentStudent == null)
            {
                MessageBox.Show("Non è stato passato nessun studente");
                this.Close(); 
            } 

            // student's name label 
            lblCurrentStudent.Text = currentStudent.ToString();
            TxtIdStudent.Text = currentStudent.IdStudent.ToString(); 
            //lblSum.Text = "";

            // fill the combos of lookup tables
            List<GradeType> listGrades = Commons.bl.GetListGradeTypes();
            cmbSummaryGradeType.DisplayMember = "Name";
            cmbSummaryGradeType.ValueMember = "idGradeType";
            cmbSummaryGradeType.DataSource = listGrades;
            cmbSummaryGradeType.SelectedValue = currentGradeType.IdGradeType;

            List<SchoolSubject> listSubjects = Commons.bl.GetListSchoolSubjects(false);
            cmbSchoolSubjects.DisplayMember = "Name";
            cmbSchoolSubjects.ValueMember = "idSchoolSubject";
            cmbSchoolSubjects.DataSource = listSubjects;
            cmbSchoolSubjects.SelectedValue = currentSchoolSubject.IdSchoolSubject;

            List<SchoolPeriod> listPeriods = Commons.bl.GetSchoolPeriods(currentSchoolYear);
            cmbSchoolPeriod.DataSource = listPeriods;

            dgwNotes.DataSource = Commons.bl.AnnotationsAboutThisStudent(currentStudent, currentSchoolYear,
                chkShowOnlyActive.Checked);
            TxtIdStudent.Text = currentStudent.IdStudent.ToString(); 
            RefreshData();
        }
        private void CalculateWeightedAverage()
        {
            // !!!! fix !!!! 
            ////////////if (dgwGrades.DataSource != null)
            ////////////{
            ////////////    double sommaPesata = 0;
            ////////////    double sommaPesi = 0;
            ////////////    foreach (DataRow riga in ((DataTable)dgwGrades.DataSource).Rows)
            ////////////    {
            ////////////        sommaPesata += (double)riga["value"] * (double)riga["weight"];
            ////////////        sommaPesi += (double)riga["weight"];
            ////////////    }
            ////////////    double mediaPesata = sommaPesata / sommaPesi;
            ////////////    txtMediaDomande.Text = mediaPesata.ToString("#.##");
            ////////////}
            ////////////else
            ////////////{
            ////////////    txtMediaDomande.Text = "";
            ////////////}
        }
        private void btnDettagliVoto_Click(object sender, EventArgs e)
        {
            DataRow riga = ((DataTable) dgwGrades.DataSource).Rows[dgwGrades.CurrentRow.Index]; 
            int idSelectedGrade = (int) riga["idGrade"];
            frmMicroAssessment f = new frmMicroAssessment(idSelectedGrade);
            f.ShowDialog();
        }
        private void frmGradesSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable t = (DataTable)dgwGrades.DataSource;
            if (t != null)
            {
                //t.AcceptChanges();
                DataTable modifiche = t.GetChanges();
                if (modifiche != null)
                {
                    foreach (DataRow riga in modifiche.Rows)
                    {
                        // crea un nuovo voto per ciascuna riga salvata
                        // il vecchio voto assume peso 0, il nuovo, lo stesso peso della riga precedente
                        Commons.bl.CloneGrade(riga);
                    }
                }
            }
        }
        private void cmbTipoVotoRiepilogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void RefreshData()
        {
            if (cmbSummaryGradeType.SelectedItem != null && cmbSchoolSubjects.SelectedItem != null)
            {
                dgwGrades.DataSource = Commons.bl.GetGradesOfStudent(currentStudent, currentSchoolYear,
                    ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                    ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                    dtpStartPeriod.Value, dtpEndPeriod.Value
                    );
            }
            CalculateWeightedAverage();
        }
        private void cmbSchoolSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchoolSubjects.SelectedItem == null)
            {
                return; 
            }
            string IdCurrentSubject = ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject;
            int col = (int)Commons.bl.GetSchoolSubject(IdCurrentSubject).Color;
            Color bgColor = Color.FromArgb((col & 0xFF0000) >> 16, (col & 0xFF00) >> 8, col & 0xFF);
            this.BackColor = bgColor;
            RefreshData();
        }
        private void cmbSchoolPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSchoolPeriod = (SchoolPeriod)(cmbSchoolPeriod.SelectedValue);
            if (currentSchoolPeriod.IdSchoolPeriodType != "N")
            {
                dtpStartPeriod.Value = (DateTime)currentSchoolPeriod.DateStart;
                dtpEndPeriod.Value = (DateTime)currentSchoolPeriod.DateFinish;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "month")
            {
                dtpStartPeriod.Value = DateTime.Now.AddMonths(-1);
                dtpEndPeriod.Value = DateTime.Now;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "week")
            {
                dtpStartPeriod.Value = DateTime.Now.AddDays(-7);
                dtpEndPeriod.Value = DateTime.Now;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "year")
            {
                dtpStartPeriod.Value = DateTime.Now.AddYears(-1);
                dtpEndPeriod.Value = DateTime.Now;
            }
            RefreshData();
        }
        private void dgwGrades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwVoti_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateWeightedAverage();
        }
        private void dgwGrades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmGrade f = new frmGrade(currentStudent, currentGrade); 
            f.Show();
        }
        private void dgwGrades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                dgwGrades.Rows[e.RowIndex].Selected = true;
                currentGrade.IdGrade = (int?)dgwGrades.Rows[e.RowIndex].Cells["IdGrade"].Value; 
                currentGrade = Commons.bl.GetGrade(currentGrade.IdGrade); 
            }
        }
    }
}
