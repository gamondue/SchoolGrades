using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmGradesStudentsSummary : Form
    {
        DbAndBusiness db;
        private Student currentStudent;
        private string currentSchoolYear;
        private GradeType currentGradeType;
        private SchoolSubject currentSchoolSubject;
        private StudentAnnotation currentAnnotation; 

        public frmGradesStudentsSummary(Student Student, string IdSchoolYear,
            GradeType GradeType, SchoolSubject SchoolSubject)
        {
            InitializeComponent();
            db = new  DbAndBusiness(Commons.PathAndFileDatabase);
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
            lblSum.Text = "";

            // fill the combos of lookup tables
            List<GradeType> listGrades = db.GetListGradeTypes();
            cmbSummaryGradeType.DisplayMember = "Name";
            cmbSummaryGradeType.ValueMember = "idGradeType";
            cmbSummaryGradeType.DataSource = listGrades;
            cmbSummaryGradeType.SelectedValue = currentGradeType.IdGradeType;

            List<SchoolSubject> listSubjects = db.GetListSchoolSubjects(false);
            cmbSchoolSubjects.DisplayMember = "Name";
            cmbSchoolSubjects.ValueMember = "idGradeType";
            cmbSchoolSubjects.DataSource = listSubjects;
            cmbSchoolSubjects.SelectedValue = currentSchoolSubject.IdSchoolSubject;

            List<SchoolPeriod> listPeriods = db.GetSchoolPeriods(currentSchoolYear);
            cmbSchoolPeriod.DataSource = listPeriods;

            dgwNotes.DataSource = db.AnnotationsAboutThisStudent(currentStudent, currentSchoolYear,
                chkAnnotationsShowActive.Checked);

            RefreshData();
        }

        private void dgwVoti_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateWeightedAverage();
        }

        private void CalculateWeightedAverage()
        {
            if (dgwGrades.DataSource != null)
            {
                double sommaPesata = 0;
                double sommaPesi = 0;
                foreach (DataRow riga in ((DataTable)dgwGrades.DataSource).Rows)
                {
                    sommaPesata += (double)riga["value"] * (double)riga["weight"];
                    sommaPesi += (double)riga["weight"];
                }
                double mediaPesata = sommaPesata / sommaPesi;
                txtMediaMicroDomande.Text = mediaPesata.ToString("#.##");
            }
            else
            {
                txtMediaMicroDomande.Text = "";
            }
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
                        db.CloneGrade(riga);
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
                if (cmbSummaryGradeType.SelectedItem != null && cmbSchoolSubjects.SelectedItem != null)
                {
                    if (rdbShowGrades.Checked)
                    {
                        dgwGrades.DataSource = db.GetGradesOfStudent(currentStudent, currentSchoolYear,
                            ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                            ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                            dtpStartPeriod.Value, dtpEndPeriod.Value
                            );
                        lblSum.Text = "";
                        txtMediaMicroDomande.Text = "";
                    }
                    else if (rdbShowWeights.Checked)
                    {
                        dgwGrades.DataSource = db.GetWeightedAveragesOfStudent(currentStudent,
                            ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                            ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                            dtpStartPeriod.Value, dtpEndPeriod.Value
                            );
                        double sumLeftToClose = 0;
                        double maxGradesFraction = 0;
                        foreach (DataRow row in ((DataTable)dgwGrades.DataSource).Rows)
                        {
                            double gf = (double)row["GradesFraction"];
                            if (gf > maxGradesFraction)
                                maxGradesFraction = gf;
                            sumLeftToClose += (double)row["LeftToCloseAssesments"];
                        }
                        int nGrades = (int)Math.Round(maxGradesFraction + 0.10);
                        lblSum.Text = "Mancanti a fine giro";
                        txtMediaMicroDomande.Text = (sumLeftToClose / nGrades).ToString();
                    }
                    else if (rdbShowWeightedGrades.Checked)
                    {
                        dgwGrades.DataSource = db.GetGradesWeightedAveragesOfStudent(currentStudent,
                            ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                            ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                            dtpStartPeriod.Value, dtpEndPeriod.Value
                            );
                        lblSum.Text = "";
                        txtMediaMicroDomande.Text = "";
                    }
                    else if (rdbShowWeightsOnOpenGrades.Checked)
                    {
                        dgwGrades.DataSource = db.GetGradesWeightsOfStudentOnOpenGrades(currentStudent,
                            ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                            ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                            dtpStartPeriod.Value, dtpEndPeriod.Value
                            );
                        lblSum.Text = "";
                        txtMediaMicroDomande.Text = "";

                        setRowNumbers(dgwGrades);
                    }
                }
            }
        }

        private void cmbSchoolSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchoolSubjects.SelectedItem == null)
            {
                return; 
            }
            string IdCurrentSubject = ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject;
            int col = (int)db.GetSchoolSubject(IdCurrentSubject).Color;
            Color bgColor = Color.FromArgb((col & 0xFF0000) >> 16, (col & 0xFF00) >> 8, col & 0xFF);
            this.BackColor = bgColor;
            RefreshData();
        }

        private void cmbSchoolPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void rdbShowGrades_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void rdbShowWeightedGrades_CheckedChanged(object sender, EventArgs e)
        {
            txtMediaMicroDomande.Text = "";
        }

        private void rdbShowWeights_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData(); 
        }

        private void setRowNumbers(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void chkAnnotationsShowActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgwGrades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            TxtIdStudent.Text = currentStudent.IdStudent.ToString();

        }
    }
}
