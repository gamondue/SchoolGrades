using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        public frmGradesClassSummary(Class Class, GradeType GradeType, SchoolSubject Subject)
        {
            InitializeComponent();

            currentClass = Class;
            currentGradeType = GradeType;
            currentSubject = Subject;

            // fill the combos of lookup tables
            List<GradeType> listGradeTypes = Commons.bl.GetListGradeTypes();
            cmbSummaryGradeType.DisplayMemberPath = "Name";
            cmbSummaryGradeType.SelectedValuePath = "idGradeType";
            cmbSummaryGradeType.ItemsSource = listGradeTypes;
            cmbSummaryGradeType.SelectedItem = currentGradeType;

            List<SchoolSubject> listSubjects = Commons.bl.GetListSchoolSubjects(false);
            cmbSchoolSubjects.DisplayMemberPath = "Name";
            cmbSchoolSubjects.SelectedValuePath = "idSchoolSubject";
            cmbSchoolSubjects.ItemsSource = listSubjects;
            cmbSchoolSubjects.SelectedItem = currentSubject;

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
        private void frmGradesClassSummary_Loaded(object sender, EventArgs e)
        {
            // classes label  
            lblCurrentClass.Content = currentClass.ToString();
            lblSum.Content = "";

            cmbSummaryGradeType.SelectedValue = currentGradeType.IdGradeType;
            cmbSchoolSubjects.SelectedValue = currentSubject.IdSchoolSubject;

            RetrieveData(FindCheckedRadioButton());
        }
        private void cmbSummaryGradeType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cmbSchoolSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchoolSubjects.SelectedItem != null)
            {
                currentSubject = ((SchoolSubject)(cmbSchoolSubjects.SelectedItem));
                Color b = CommonsWpf.ColorFromNumber(currentSubject.Color);
                this.Background = CommonsWpf.BrushFromColor(b);
            }
        }
        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void RetrieveData(RadioButton rdb)
        {
            DataTable dt = null;
            if (cmbSummaryGradeType.SelectedItem != null && cmbSchoolSubjects.SelectedItem != null)
            {
                if (rdb == rdbMissing)
                {
                    dt = Commons.bl.GetStudentsWithNoMicrogrades(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.SelectedDate.Value,
                        dtpEndPeriod.SelectedDate.Value
                        );
                    dgwGrades.ItemsSource = dt.AsDataView();
                }
                else if (rdb == rdbShowGrades)
                {
                    dt = Commons.bl.GetGradesOfClass(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.SelectedDate.Value, dtpEndPeriod.SelectedDate.Value
                        );
                    dgwGrades.ItemsSource = dt.AsDataView();
                    lblSum.Content = "";
                    txtSummaryDatum.Text = "";
                }
                else if (rdb == rdbShowWeights)
                {
                    dt = Commons.bl.GetWeightedAveragesOfClass(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.SelectedDate.Value, dtpEndPeriod.SelectedDate.Value
                        );
                    dgwGrades.ItemsSource = dt.AsDataView();
                    double sumLeftToClose = 0;
                    double maxGradesFraction = 0;
                    foreach (DataRow row in (dt.Rows))
                    {
                        double gf = (double)row["GradesFraction"];
                        if (gf > maxGradesFraction)
                            maxGradesFraction = gf;
                        sumLeftToClose += (double)row["LeftToCloseAssesments"];
                    }
                    int nGrades = (int)Math.Round(maxGradesFraction + 0.10);
                    lblSum.Content = "Mancanti a fine giro";
                    txtSummaryDatum.Text = (sumLeftToClose / nGrades).ToString("#.00");
                }
                else if (rdb == rdbShowWeightedGrades)
                {
                    dt = Commons.bl.GetGradesWeightedAveragesOfClassByAverage(currentClass,
                    ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                    ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                    dtpStartPeriod.SelectedDate.Value, dtpEndPeriod.SelectedDate.Value
                    );
                    dgwGrades.ItemsSource = dt.AsDataView();
                    lblSum.Content = "";
                    txtSummaryDatum.Text = "";
                }
                else if (rdb == rdbShowWeightsOnOpenGrades)
                {
                    dt = Commons.bl.GetGradesWeightsOfClassOnOpenGrades(currentClass,
                        ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType,
                        ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                        dtpStartPeriod.SelectedDate.Value, dtpEndPeriod.SelectedDate.Value
                        );
                    dgwGrades.ItemsSource = dt.AsDataView();
                    lblSum.Content = "";
                    txtSummaryDatum.Text = "";

                    setRowNumbers(dgwGrades);
                }
                if (dgwGrades.ItemsSource != null)
                    txtNStudents.Text = dt.Rows.Count.ToString();
            }
        }
        private void setRowNumbers(DataGrid dgv)
        {
            foreach (DataGridRow row in dgv.Items)
            {
                //////////row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
        private void cmbSchoolPeriod_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
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
            foreach (object o in stkChosenQuery.Children)
            {
                RadioButton rdb = (RadioButton)o;
                if ((bool)rdb.IsChecked)
                {
                    rdbFound = rdb;
                    break;
                }
            }
            return rdbFound;
        }
        //private void rdbShowGrades_CheckedChanged(object sender, EventArgs e)
        //{
        //    RetrieveData(rdbShowGrades);
        //}
        //private void rdbShowWeightedGrades_CheckedChanged(object sender, EventArgs e)
        //{
        //    RetrieveData(rdbShowWeightedGrades);
        //}
        //private void rdbShowWeights_CheckedChanged(object sender, EventArgs e)
        //{
        //    RetrieveData(rdbShowWeights);
        //}
        //private void rdbShowWeightsOnOpenGrades_CheckedChanged(object sender, EventArgs e)
        //{
        //    RetrieveData(rdbShowWeightsOnOpenGrades);
        //}
        //private void rdbMissing_CheckedChanged(object sender, EventArgs e)
        //{
        //    RetrieveData(rdbMissing);
        //}
        private void btnSaveOnFile_Click(object sender, EventArgs e)
        {
            // find the kind of table we have to save
            RadioButton rb = (RadioButton)(FindCheckedRadioButton());
            string tipoTabella = rb.Content.ToString();
            //temp = "'" + temp + "'";
            string FileName = System.IO.Path.Combine(Commons.PathDatabase,
                DateTime.Now.ToString("yyyy.MM.dd_") + currentClass.Abbreviation + "_" +
                currentSubject + "_" +
                ((GradeType)(cmbSummaryGradeType.SelectedItem)).IdGradeType + "_" +
                tipoTabella + "_" +
                dtpStartPeriod.SelectedDate.Value.ToString("yyyy.MM.dd_") +
                dtpEndPeriod.SelectedDate.Value.ToString("yyyy.MM.dd") +
                ".csv");
            var itemsSource = (dgwGrades.ItemsSource);
            // TODO fix here:
            //////DataTable dt = itemsSource.Table; 
            //////Commons.bl.SaveTableOnCvs(dt, FileName);
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
                    if (!((bool)rdbMissing.IsChecked))
                    {
                        int IdQuestion = (int)((Grade)dgwGrades.Items[RowIndex]).IdQuestion;
                        frmMicroAssessment fg = new frmMicroAssessment(IdQuestion);
                        fg.Show();
                    }
                    else
                    {
                        int IdStudent = (int)((Student)dgwGrades.Items[RowIndex]).IdStudent;
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
        private void rdb_Click(object sender, RoutedEventArgs e)
        {
            RetrieveData((RadioButton)sender);
        }
        private void btnReadData_Click(object sender, RoutedEventArgs e)
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
