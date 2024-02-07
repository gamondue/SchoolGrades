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
    /// Logica di interazione per frmGradesStudentsSummary.xaml
    /// </summary>
    public partial class frmGradesStudentsSummary : Window
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

            lblCurrentStudent.Content = $"{Student.LastName} {Student.FirstName}";
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
            lblCurrentStudent.Content = currentStudent.ToString();
            TxtIdStudent.Text = currentStudent.IdStudent.ToString();
            //lblSum.Text = "";

            // fill the combos of lookup tables
            List<GradeType> listGrades = Commons.bl.GetListGradeTypes();
            cmbGradeType.DisplayMemberPath = "Name";
            cmbGradeType.SelectedValuePath = "idGradeType";
            cmbGradeType.ItemsSource = listGrades;
            cmbGradeType.SelectedValue = currentGradeType.IdGradeType;

            List<SchoolSubject> listSubjects = Commons.bl.GetListSchoolSubjects(false);
            cmbSchoolSubjects.DisplayMemberPath = "Name";
            cmbSchoolSubjects.SelectedValuePath = "idSchoolSubject";
            cmbSchoolSubjects.ItemsSource = listSubjects;
            cmbSchoolSubjects.SelectedValue = currentSchoolSubject.IdSchoolSubject;

            List<SchoolPeriod> listPeriods = Commons.bl.GetSchoolPeriods(currentSchoolYear);
            cmbSchoolPeriod.ItemsSource = listPeriods;

            dgwNotes.ItemsSource = Commons.bl.AnnotationsAboutThisStudent(currentStudent, currentSchoolYear,
                (bool)chkShowOnlyActive.IsChecked);
            TxtIdStudent.Text = currentStudent.IdStudent.ToString();
            RefreshData();
        }
        private void CalculateWeightedAverage()
        {
            // conviene lasciarlo qui visto che questa funzione usa DataTable, che è una classe prettamente di UI.
            if (dgwGrades.ItemsSource != null)
            {
                double weightedAverage = 0;
                double sumOfWeights = 0;
                foreach (DataRow row in ((DataTable)dgwGrades.ItemsSource).Rows)
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
        private void frmGradesSummary_FormClosing(object sender, RoutedEvent e)
        {
            //////////DataTable t = (DataTable)(dgwGrades.ItemsSource);
            //////////if (t != null)
            //////////{
            //////////    //t.AcceptChanges();
            //////////    DataTable modifiche = t.GetChanges();
            //////////    if (modifiche != null)
            //////////    {
            //////////        foreach (DataRow riga in modifiche.Items)
            //////////        {
            //////////            // crea un nuovo voto per ciascuna riga salvata
            //////////            // il vecchio voto assume peso 0, il nuovo, lo stesso peso della riga precedente
            //////////            Commons.bl.CloneGrade(riga);
            //////////        }
            //////////    }
            //////////}
        }
        private void cmbGradeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void RefreshData()
        {
            if (cmbGradeType.SelectedItem != null && cmbSchoolSubjects.SelectedItem != null)
            {
                dgwGrades.ItemsSource = (System.Collections.IEnumerable)
                    Commons.bl.GetGradesOfStudent(currentStudent, currentSchoolYear,
                    ((GradeType)(cmbGradeType.SelectedItem)).IdGradeType,
                    ((SchoolSubject)(cmbSchoolSubjects.SelectedItem)).IdSchoolSubject,
                    dtpStartPeriod.SelectedDate.Value, dtpEndPeriod.SelectedDate.Value
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
            Color bgColor = CommonsWpf.ColorFromNumber(Commons.bl.GetSchoolSubject(IdCurrentSubject).Color);
            this.Background = CommonsWpf.BrushFromColor(bgColor);
            RefreshData();
        }
        private void cmbSchoolPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSchoolPeriod = (SchoolPeriod)(cmbSchoolPeriod.SelectedValue);

            var res = Commons.bl.CalculateStartAndEndPeriod(currentSchoolPeriod);
            dtpStartPeriod.SelectedDate = res.startPeriod;
            dtpEndPeriod.SelectedDate = res.endPeriod;

            RefreshData();
        }
        private void dgwGrades_CellContentClick(object sender, RoutedEvent e)
        {

        }
        private void dgwVoti_CellEndEdit(object sender, RoutedEvent e)
        {
            CalculateWeightedAverage();
        }
        private void dgwGrades_CellDoubleClick(object sender, RoutedEvent e)
        {
            frmGrade f = new frmGrade(currentStudent, currentGrade);
            f.Show();
        }
        private void dgwGrades_CellClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                //////////dgwGrades.Items[RowIndex].Selected = true;
                currentGrade.IdGrade = (int?)((Grade)dgwGrades.Items[RowIndex]).IdGrade;
                currentGrade = Commons.bl.GetGrade(currentGrade.IdGrade);
            }
        }
    }
}
