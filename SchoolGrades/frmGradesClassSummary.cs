using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmGradesClassSummary : Form
    {
        private Class currentClass;
        private GradeType currentGradeType;
        private SchoolSubject currentSubject;
        private SchoolPeriod currentSchoolPeriod;

        public frmGradesClassSummary(Class Class, GradeType GradeType,
            SchoolSubject Subject)
        {
            InitializeComponent();

            currentClass = Class;
            currentGradeType = GradeType;
            currentSubject = Subject;

            // fill the combos of lookup tables
            List<GradeType> listGradeTypes = Commons.bl.GetListGradeTypes();
            cmbSummaryGradeType.DisplayMember = "Name";
            cmbSummaryGradeType.ValueMember = "idGradeType";
            cmbSummaryGradeType.DataSource = listGradeTypes;

            List<SchoolSubject> listSubjects = Commons.bl.GetListSchoolSubjects(false);
            cmbSchoolSubjects.DisplayMember = "Name";
            cmbSchoolSubjects.ValueMember = "idSchoolSubject";
            cmbSchoolSubjects.DataSource = listSubjects;

            List<SchoolPeriod> listPeriods = Commons.bl.GetSchoolPeriods(Class.SchoolYear);
            cmbSchoolPeriod.DataSource = listPeriods;
            // select the combo item of the partial period of the DateTime.Now
            foreach (SchoolPeriod sp in listPeriods)
            {
                if (sp.DateFinish > DateTime.Now && sp.DateStart < DateTime.Now
                    && sp.IdSchoolPeriodType == "P")
                {
                    cmbSchoolPeriod.SelectedItem = sp;
                }
            }
            currentClass = Class;
            currentGradeType = GradeType;
            currentSubject = Subject;
        }
        private void frmGradesClassSummary_Load(object sender, EventArgs e)
        {
            // classes label  
            lblCurrentClass.Text = currentClass.ToString();
            lblSum.Text = "";

            cmbSummaryGradeType.SelectedValue = currentGradeType.IdGradeType;
            cmbSchoolSubjects.SelectedValue = currentSubject.IdSchoolSubject;

            RetrieveData(FindCheckedRadioButton());
        }
        private void cmbSummaryGradeType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cmbSchoolSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSubject = ((SchoolSubject)(cmbSchoolSubjects.SelectedItem));
            this.BackColor = CommonsWinForms.ColorFromNumber(currentSubject);
        }
        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void RetrieveData(RadioButton rdb)
        {
            if (cmbSummaryGradeType.SelectedItem != null && cmbSchoolSubjects.SelectedItem != null)
            {
                if (rdb == rdbMissing)
                {
                    dgwGrades.DataSource = Commons.bl.GetStudentsWithNoMicrogrades(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.Value, dtpEndPeriod.Value
                        );
                }
                if (rdb == rdbShowGrades)
                {
                    dgwGrades.DataSource = Commons.bl.GetGradesOfClass(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.Value, dtpEndPeriod.Value
                        );
                    lblSum.Text = "";
                    txtSummaryDatum.Text = "";
                }
                else if (rdb == rdbShowWeights)
                {
                    dgwGrades.DataSource = Commons.bl.GetWeightedAveragesOfClass(currentClass,
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
                    txtSummaryDatum.Text = (sumLeftToClose / nGrades).ToString("#.00");
                }
                else if (rdb == rdbShowWeightedGrades)
                {
                    dgwGrades.DataSource = Commons.bl.GetGradesWeightedAveragesOfClassByAverage(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.Value, dtpEndPeriod.Value
                        );
                    lblSum.Text = "";
                    txtSummaryDatum.Text = "";
                }
                else if (rdb == rdbShowWeightsOnOpenGrades)
                {
                    dgwGrades.DataSource = Commons.bl.GetGradesWeightsOfClassOnOpenGrades(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.Value, dtpEndPeriod.Value
                        );
                    lblSum.Text = "";
                    txtSummaryDatum.Text = "";

                    setRowNumbers(dgwGrades);
                }
            }
            txtNStudents.Text = ((DataTable)dgwGrades.DataSource).Rows.Count.ToString();
        }
        private void setRowNumbers(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
        private void cmbSchoolPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSchoolPeriod = (SchoolPeriod)(cmbSchoolPeriod.SelectedValue);

            var res = Commons.bl.CalculateStartAndEndPeriod(currentSchoolPeriod);
            dtpStartPeriod.Value = res.startPeriod;
            dtpEndPeriod.Value = res.endPeriod;

            RetrieveData(FindCheckedRadioButton());
        }
        private RadioButton FindCheckedRadioButton()
        {
            RadioButton rdbFound = null;
            foreach (RadioButton rdb in grpChosenQuery.Controls)
            {
                if (rdb.Checked)
                {
                    rdbFound = rdb;
                    break;
                }
            }
            return rdbFound;
        }
        private void rdbShowGrades_CheckedChanged(object sender, EventArgs e)
        {
            //RetrieveData(rdbShowGrades);
        }
        private void rdbShowWeightedGrades_CheckedChanged(object sender, EventArgs e)
        {
            //RetrieveData(rdbShowWeightedGrades);
        }
        private void rdbShowWeights_CheckedChanged(object sender, EventArgs e)
        {
            //RetrieveData(rdbShowWeights);
        }
        private void rdbShowWeightsOnOpenGrades_CheckedChanged(object sender, EventArgs e)
        {
            //RetrieveData(rdbShowWeightsOnOpenGrades);
        }
        private void rdbMissing_CheckedChanged(object sender, EventArgs e)
        {
            //RetrieveData(rdbMissing);
        }
        private void btnSaveOnFile_Click(object sender, EventArgs e)
        {
            // find the kind of table we have to save
            string tipoTabella = FindCheckedRadioButton().Text;
            //temp = "'" + temp + "'";
            string FileName = Path.Combine(Commons.PathDatabase,
                DateTime.Now.ToString("yyyy.MM.dd_") + currentClass.Abbreviation + "_" +
                currentSubject + "_" +
                ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType + "_" +
                tipoTabella + "_" +
                dtpStartPeriod.Value.ToString("yyyy.MM.dd_") + dtpEndPeriod.Value.ToString("yyyy.MM.dd") +
                ".csv");
            Commons.bl.SaveTableOnCvs((DataTable)dgwGrades.DataSource, FileName);
            MessageBox.Show("Creato file: " + FileName);
        }
        private void dgwGrades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dgwGrades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwGrades.Rows[e.RowIndex].Selected = true;
            }
        }
        private void dgwGrades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                try
                {
                    if (!rdbMissing.Checked)
                    {
                        int IdQuestion = (int)dgwGrades.Rows[e.RowIndex].Cells[0].Value;
                        frmMicroAssessment fg = new frmMicroAssessment(IdQuestion);
                        fg.Show();
                    }
                    else
                    {
                        int IdStudent = (int)dgwGrades.Rows[e.RowIndex].Cells[0].Value;
                        Student currentStudent = Commons.bl.GetStudent(IdStudent);
                        frmMicroAssessment fg = new frmMicroAssessment(null,
                            currentClass, currentStudent,
                            currentGradeType, currentSubject, null);
                        fg.Show();
                    }
                }
                catch
                {
                    MessageBox.Show("Selezionare un voto da visualizzare.");
                }
            }
        }
        private void rdb_Click(object sender, EventArgs e)
        {
            RetrieveData((RadioButton)sender);
        }
        private void btnReadData_Click(object sender, EventArgs e)
        {
            RetrieveData(ActiveRadioButton());
        }
        private RadioButton ActiveRadioButton()
        {
            if (rdbMissing.Checked)
            {
                return rdbMissing;
            }
            if (rdbShowGrades.Checked)
            {
                return rdbShowGrades;
            }
            if (rdbShowWeightedGrades.Checked)
            {
                return rdbShowWeightedGrades;
            }
            if (rdbShowWeights.Checked)
            {
                return rdbShowWeights;
            }
            if (rdbShowWeightsOnOpenGrades.Checked)
            {
                return rdbShowWeightsOnOpenGrades;

            }
            return null;
        }
    }
}
