using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per GradesClassSummary.xaml
    /// </summary>
    public partial class frmGradesClassSummary : Window
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
            cmbSummaryGradeType.ItemsSource = listGradeTypes;

            List<SchoolSubject> listSubjects = Commons.bl.GetListSchoolSubjects(false);
            cmbSchoolSubjects.DisplayMember = "Name";
            cmbSchoolSubjects.ValueMember = "idSchoolSubject";
            cmbSchoolSubjects.ItemsSource = listSubjects;

            List<SchoolPeriod> listPeriods = Commons.bl.GetSchoolPeriods(Class.SchoolYear);
            cmbSchoolPeriod.ItemsSource = listPeriods;
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
            this.Background = CommonsWinForms.ColorFromNumber(currentSubject);
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
                    dgwGrades.ItemsSource = Commons.bl.GetStudentsWithNoMicrogrades(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.SelectedDate, dtpEndPeriod.SelectedDate
                        );
                }
                if (rdb == rdbShowGrades)
                {
                    dgwGrades.ItemsSource = Commons.bl.GetGradesOfClass(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.SelectedDate, dtpEndPeriod.SelectedDate
                        );
                    lblSum.Text = "";
                    txtSummaryDatum.Text = "";
                }
                else if (rdb == rdbShowWeights)
                {
                    dgwGrades.ItemsSource = Commons.bl.GetWeightedAveragesOfClass(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.SelectedDate, dtpEndPeriod.SelectedDate
                        );
                    double sumLeftToClose = 0;
                    double maxGradesFraction = 0;
                    foreach (DataRow row in ((DataTable)dgwGrades.ItemsSource).Rows)
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
                    dgwGrades.ItemsSource = Commons.bl.GetGradesWeightedAveragesOfClassByAverage(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.SelectedDate, dtpEndPeriod.SelectedDate
                        );
                    lblSum.Text = "";
                    txtSummaryDatum.Text = "";
                }
                else if (rdb == rdbShowWeightsOnOpenGrades)
                {
                    dgwGrades.ItemsSource = Commons.bl.GetGradesWeightsOfClassOnOpenGrades(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.SelectedDate, dtpEndPeriod.SelectedDate
                        );
                    lblSum.Text = "";
                    txtSummaryDatum.Text = "";

                    setRowNumbers(dgwGrades);
                }
            }
            txtNStudents.Text = ((DataTable)dgwGrades.ItemsSource).Rows.Count.ToString();
        }
        private void setRowNumbers(DataGrid dgv)
        {
            foreach (DataGridRow row in dgv.Items)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
        private void cmbSchoolPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSchoolPeriod = (SchoolPeriod)(cmbSchoolPeriod.SelectedValue);

            var res = Commons.bl.CalculateStartAndEndPeriod(currentSchoolPeriod);
            dtpStartPeriod.SelectedDate = res.startPeriod;
            dtpEndPeriod.SelectedDate = res.endPeriod;

            RetrieveData(FindCheckedRadioButton());
        }
        private RadioButton FindCheckedRadioButton()
        {
            RadioButton rdbFound = null;
            foreach (RadioButton rdb in grpChosenQuery.Controls)
            {
                if (rdb.IsChecked)
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
                dtpStartPeriod.SelectedDate.ToString("yyyy.MM.dd_") + dtpEndPeriod.SelectedDate.ToString("yyyy.MM.dd") +
                ".csv");
            Commons.bl.SaveTableOnCvs((DataTable)dgwGrades.ItemsSource, FileName);
            MessageBox.Show("Creato file: " + FileName);
        }
        private void dgwGrades_CellContentClick(object sender, RoutedEvent e)
        {
        }
        //private void dgwGrades_CellClick(object sender, RoutedEvent e)
        //{
        //                DataGrid grid = (DataGrid)sender;
        //int RowIndex = grid.SelectedIndex;
        //    if (RowIndex > -1)
        //    {
        //        dgwGrades.Items[RowIndex].Selected = true;
        //    }
        //}
        private void dgwGrades_CellDoubleClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                try
                {
                    if (!rdbMissing.IsChecked)
                    {
                        int IdQuestion = (int)dgwGrades.Items[RowIndex].Cells[0].Value;
                        frmMicroAssessment fg = new frmMicroAssessment(IdQuestion);
                        fg.Show();
                    }
                    else
                    {
                        int IdStudent = (int)dgwGrades.Items[RowIndex].Cells[0].Value;
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
            if ((bool)rdbMissing.IsChecked)
            {
                return rdbMissing;
            }
            if ((bool)rdbShowGrades.IsChecked)
            {
                return rdbShowGrades;
            }
            if ((bool)rdbShowWeightedGrades.IsChecked)
            {
                return rdbShowWeightedGrades;
            }
            if ((bool)rdbShowWeights.IsChecked)
            {
                return rdbShowWeights;
            }
            if ((bool)rdbShowWeightsOnOpenGrades.IsChecked)
            {
                return rdbShowWeightsOnOpenGrades;

            }
            return null;
        }
    }
}
