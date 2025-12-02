using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SchoolGrades.Localization;

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
            
            LocalizeForm();

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
                MessageBox.Show(Loc.Get("GradesStudentsSummary_NoStudentPassed"));
                this.Close();
            }

            // student's name label 
            lblCurrentStudent.Text = currentStudent.ToString();
            TxtIdStudent.Text = currentStudent.IdStudent.ToString();
            //lblSum.Text = "";

            // fill the combos of lookup tables
            List<GradeType> listGrades = Commons.bl.GetListGradeTypes();
            cmbGradeType.DisplayMember = "Name";
            cmbGradeType.ValueMember = "idGradeType";
            cmbGradeType.DataSource = listGrades;
            cmbGradeType.SelectedValue = currentGradeType.IdGradeType;

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
            // conviene lasciarlo qui visto che questa funzione usa DataTable, che è una classe prettamente di UI.
            if (dgwGrades.DataSource != null)
            {
                double weightedAverage = 0;
                double sumOfWeights = 0;
                foreach (DataRow row in ((DataTable)dgwGrades.DataSource).Rows)
                {
                    weightedAverage += (double)row["grade"] * (double)row["weight"];
                    sumOfWeights += (double)row["weight"];
                }
                double mediaPesata = weightedAverage / sumOfWeights;
                txtSumOfWeights.Text = sumOfWeights.ToString("#.##");
                txtWeightedAverage.Text = mediaPesata.ToString("#.##");
            }
            else
            {
                txtWeightedAverage.Text = "";
            }
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
        private void cmbGradeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void RefreshData()
        {
            if (cmbGradeType.SelectedItem != null && cmbSchoolSubjects.SelectedItem != null)
            {
                dgwGrades.DataSource = Commons.bl.GetGradesOfStudent(currentStudent, currentSchoolYear,
                    ((GradeType)(cmbGradeType.SelectedItem)).IdGradeType,
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

            var res = Commons.bl.CalculateStartAndEndPeriod(currentSchoolPeriod);
            dtpStartPeriod.Value = res.startPeriod;
            dtpEndPeriod.Value = res.endPeriod;

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
        private void LocalizeForm()
        {
            try
            {
                // Form title
                this.Text = Loc.Get("GradesStudentsSummary_Title");

                // Labels
                lblCurrentStudent.Text = Loc.Get("GradesStudentsSummary_Student");
                label2.Text = Loc.Get("GradesStudentsSummary_GradesOfType");
                lblSchoolSubject.Text = Loc.Get("GradesStudentsSummary_Subject");
                lblStart.Text = Loc.Get("GradesStudentsSummary_Start");
                lblEnd.Text = Loc.Get("GradesStudentsSummary_End");
                label1.Text = Loc.Get("GradesStudentsSummary_StudentId");
                label5.Text = Loc.Get("GradesStudentsSummary_WeightsSum");
                lblAverage.Text = Loc.Get("GradesStudentsSummary_WeightedAverage");
                label7.Text = Loc.Get("GradesStudentsSummary_GradesOfType");
                label6.Text = Loc.Get("GradesStudentsSummary_WeightsSum");
                label8.Text = Loc.Get("GradesStudentsSummary_WeightedAverage");
                label9.Text = Loc.Get("GradesStudentsSummary_Annotation");
                label3.Text = Loc.Get("GradesStudentsSummary_AnnotationId");
                label4.Text = Loc.Get("GradesStudentsSummary_AnnotationId");

                // GroupBoxes
                grpPeriodOfQuestionsTopics.Text = Loc.Get("GradesStudentsSummary_GradesPeriod");
                grpComplessivo.Text = Loc.Get("GradesStudentsSummary_OverallSummary");

                // Buttons
                btnAddAnnotation.Text = Loc.Get("Common_Add");
                btnEraseAnnotation.Text = Loc.Get("Common_Remove");
                btnSave.Text = Loc.Get("Common_Save");

                // CheckBoxes
                chkCurrentAnnotationActive.Text = Loc.Get("GradesStudentsSummary_Active");
                chkShowOnlyActive.Text = Loc.Get("GradesStudentsSummary_ShowOnlyActive");

                // RadioButton
                rdbAmongPeriod.Text = Loc.Get("GradesStudentsSummary_InPeriod");
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"frmGradesStudentsSummary.LocalizeForm: {ex.Message}");
            }
        }
    }
}