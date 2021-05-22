using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmGradesClassSummary : Form
    {
        DbAndBusiness db;
        private Class currentClass;
        private GradeType currentGradeType;
        private SchoolSubject currentSubject;
        private SchoolPeriod currentSchoolPeriod;

        public frmGradesClassSummary(Class Class, GradeType GradeType, 
            SchoolSubject Subject)
        {
            InitializeComponent();

            db = new DbAndBusiness(Commons.PathAndFileDatabase);

            currentClass = Class;
            currentGradeType = GradeType;
            currentSubject = Subject;

            // fill the combos of lookup tables
            List<GradeType> listGradeTypes = db.GetListGradeTypes();
            cmbSummaryGradeType.DisplayMember = "Name";
            cmbSummaryGradeType.ValueMember = "idGradeType";
            cmbSummaryGradeType.DataSource = listGradeTypes;

            List<SchoolSubject> listSubjects = db.GetListSchoolSubjects(false);
            cmbSchoolSubjects.DisplayMember = "Name";
            cmbSchoolSubjects.ValueMember = "idSchoolSubject";
            cmbSchoolSubjects.DataSource = listSubjects;

            List<SchoolPeriod> listPeriods = db.GetSchoolPeriods(Class.SchoolYear);
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
            this.BackColor = Commons.ColorFromNumber(currentSubject);  
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
                    dgwGrades.DataSource = db.GetStudentsWithNoMicrogrades(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.Value, dtpEndPeriod.Value
                        );
                }
                if (rdb == rdbShowGrades)
                {
                    dgwGrades.DataSource = db.GetGradesOfClass(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.Value, dtpEndPeriod.Value
                        );
                    lblSum.Text = "";
                    txtMediaMicroDomande.Text = "";
                }
                else if (rdb == rdbShowWeights)
                {
                    dgwGrades.DataSource = db.GetWeightedAveragesOfClass(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject ,
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
                else if (rdb == rdbShowWeightedGrades)
                {
                    dgwGrades.DataSource = db.GetGradesWeightedAveragesOfClass(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.Value, dtpEndPeriod.Value
                        );
                    lblSum.Text = "";
                    txtMediaMicroDomande.Text = "";
                }
                else if (rdb == rdbShowWeightsOnOpenGrades)
                {
                    dgwGrades.DataSource = db.GetGradesWeightsOfClassOnOpenGrades(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.Value, dtpEndPeriod.Value
                        );
                    lblSum.Text = "";
                    txtMediaMicroDomande.Text = "";

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
            //RefreshData();
        }

        private void rdbShowWeightedGrades_CheckedChanged(object sender, EventArgs e)
        {
            //RefreshData();
        }

        private void rdbShowWeights_CheckedChanged(object sender, EventArgs e)
        {
            //RefreshData();
        }

        private void rdbShowWeightsOnOpenGrades_CheckedChanged(object sender, EventArgs e)
        {
            //RefreshData();
        }

        private void rdbMissing_CheckedChanged(object sender, EventArgs e)
        {
            //RefreshData();
        }

        private void btnSaveOnFile_Click(object sender, EventArgs e)
        {
            // find the kind of table we have to save
            string tipoTabella = FindCheckedRadioButton().Text; 
            string FileName = Commons.PathDatabase + @"\" + 
                DateTime.Now.ToString("yyyy.MM.dd_") + currentClass.Abbreviation + "_" +
                currentSubject + "_" +
                ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType + "_" +
                tipoTabella + "_" +
                dtpStartPeriod.Value.ToString("yyyy.MM.dd_") + dtpEndPeriod.Value.ToString("yyyy.MM.dd") +
                ".csv"; 
            db.SaveTableOnCvs((DataTable)dgwGrades.DataSource, FileName);
            MessageBox.Show("Creato file: " + FileName);
        }

        private void dgwGrades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgwGrades_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwGrades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdQuestion;
            if (e.RowIndex > -1)
            {
                //DataRow row = ((DataTable)(dgwGrades.DataSource)).Rows[e.RowIndex];
                try
                {
                    IdQuestion = (int)dgwGrades.CurrentRow.Cells[0].Value;
                    frmMicroAssessment fg = new frmMicroAssessment(IdQuestion);
                    fg.Show();
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
    }
}
