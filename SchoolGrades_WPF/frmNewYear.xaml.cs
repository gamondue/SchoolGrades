using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class frmNewYear : Window
    {
        string idStartYear;
        private School currentSchool;

        private SchoolYear currentSchoolYear = new SchoolYear();
        private Class currentClass = new Class();

        private SchoolYear nextSchoolYear = new SchoolYear();
        private Class nextClass = new Class();

        private bool loading;
        public frmNewYear(string IdStartYear)
        {
            InitializeComponent();
            idStartYear = IdStartYear;
        }

        private void frmNewYear_Load(object sender, RoutedEventArgs e)
        {
            loading = true;
            // school data
            currentSchool = Commons.bl.GetSchool(TxtOfficialSchoolAbbreviation.Text);

            // years's data in combo
            List<SchoolYear> ly = Commons.bl.GetSchoolYearsThatHaveClasses();
            cmbSchoolYearCurrents.DataContext = ly;
            if (ly.Count > 0)
                cmbSchoolYearCurrents.SelectedItem = ly[ly.Count - 1];
            cmbSchoolYearCurrents.SelectedItem = idStartYear;
            currentSchoolYear = (SchoolYear)cmbSchoolYearCurrents.SelectedItem;

            cmbClasses.DataContext = Commons.bl.GetClassesOfYear(
                currentSchool.IdSchool, currentSchoolYear.IdSchoolYear);
            cmbClasses.SelectedIndex = 0;

            currentClass = (Class)cmbClasses.SelectedItem;

            //nextClass = new Class(); 
            //nextSchoolYear = new SchoolYear();

            loading = false;
            nextSchoolYear = Commons.bl.GenerateNewYearData(currentSchoolYear);
            nextClass = Commons.bl.GenerateNewClassData(currentClass);
            FromClassesToUi();
        }
        private void FromClassesToUi()
        {
            txtYearDescriptionCurrent.Text = currentSchoolYear.ShortDescription;
            txtYearNotesCurrent.Text = currentSchoolYear.Notes;

            txtSchoolYearNext.Text = nextSchoolYear.IdSchoolYear;
            txtYearDescriptionNext.Text = nextSchoolYear.ShortDescription;
            txtYearNotesNext.Text = nextSchoolYear.Notes;

            if (currentClass != null)
                txtClassDescriptionCurrent.Text = currentClass.Description;

            txtClassAbbreviationNext.Text = nextClass.Abbreviation;
            txtClassDescriptionNext.Text = nextClass.Description;
        }
        private void FromUiToClasses()
        {
            currentSchoolYear.ShortDescription = txtYearDescriptionCurrent.Text;
            currentSchoolYear.Notes = txtYearNotesCurrent.Text;

            nextSchoolYear.ShortDescription = txtYearDescriptionNext.Text;
            nextSchoolYear.Notes = txtYearNotesNext.Text;

            currentClass.Description = txtClassDescriptionCurrent.Text;

            nextClass.Abbreviation = txtClassAbbreviationNext.Text;
            nextClass.Description = txtClassDescriptionNext.Text;
        }
        private void BtnClassMigration_Click(object sender, RoutedEventArgs e)
        {
            BtnStudentNew.Visibility = Visibility.Visible;
            if (cmbClasses.Text == "")
            {
                MessageBox.Show("Scegliere una classe di partenza");
                return;
            }
            Class c = (Class)cmbClasses.SelectedItem;
            if (c != null)
            {
                DgwStudents.ItemsSource = Commons.bl.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text,
                    cmbSchoolYearCurrents.Text, cmbClasses.Text, true);

                currentClass = (Class)cmbClasses.SelectedItem;
                // check all the student's rows 
                foreach (Student dr in DgwStudents.Items)
                {
                    Student st = dr;
                    st.IdClass = 0;
                    st.RegisterNumber = "";
                    st.SchoolYear = txtSchoolYearNext.Text;
                    st.ClassAbbreviation = txtClassAbbreviationNext.Text;

                    st.Disabled = false;
                    st.Eligible = false;

                }
                //txtClassDescriptionNext.Text = currentSchool.Name + " " + txtSchoolYearNext.Text +
                //    " " + txtClassAbbreviationNext.Text;
                //txtClassDescriptionNext.Visibility = Visibility.Visible;
                //lblClassDescription.Visibility = Visibility.Visible; 
                DgwStudents.Items.Clear();
                MessageBox.Show("Aggiustare i dati della classe e degli studenti\r\nSegnare gli studenti da INCLUDERE " +
                    "nella nuova classe, con il segno di spunta a sinistra, poi premere 'Genera classe'" +
                    "\r\nPer aggiungere allievi tornare alla finestra precedente di gestione classi" +
                    "\r\nPremendo 'Annulla' non si importerà la classe",
                    "Modifiche classe", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            }
            btnClassGeneration.Visibility = Visibility.Visible;
            btnClassMigration.Visibility = Visibility.Hidden;
        }
        private void BtnClassGeneration_Click(object sender, RoutedEventArgs e)
        {
            if (txtClassAbbreviationNext.Text == "")
            {
                MessageBox.Show("Scrivere la sigla della nuova classe!");
                return;
            }

            if (txtClassDescriptionNext.Text == "")
                txtClassDescriptionNext.Text = currentSchool.Desc + " " + txtSchoolYearNext.Text + " " + txtClassAbbreviationNext.Text;

            List<Student> SelectedStudents = new List<Student>();
            //foreach (DataGridRow r in DgwStudents.Items)
            //{
            //    // don't include students whose rows are non checked
            //    if ((bool)r.Cells["SaveThisStudent"].Value == true)
            //    {
            //        SelectedStudents.Add((Student)r.DataBoundItem);
            //    }
            //}
            Commons.bl.GenerateNewClassFromPrevious(SelectedStudents, txtClassAbbreviationNext.Text, txtClassDescriptionNext.Text,
                nextSchoolYear, cmbSchoolYearCurrents.Text, TxtOfficialSchoolAbbreviation.Text);

            MessageBox.Show("Creazione classe " + txtClassAbbreviationNext.Text + " " + txtSchoolYearNext.Text + " terminata");
            //BtnStudentNew.Visibility = Visibility.Hidden;
            FromUiToClasses();
        }
        //private void BtnStudentNew_Click(object sender, RoutedEventArgs e)
        //{
        //    frmStudent sf = new frmStudent(null, true);
        //    sf.ShowDialog();

        //    if (sf.UserHasChosen)
        //    {
        //        List<Student> ls = (List<Student>)DgwStudents.ItemsSource;
        //        ls.Add(sf.CurrentStudent);
        //        DgwStudents.ItemsSource = null;
        //        DgwStudents.ItemsSource  = ls;
        //        DgwStudents.Items.Clear();
        //    }
        //}
        private void BtnClassNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("!!!! TO DO !!!!");
        }
        private void TxtSchoolYearPresent_TextChanged(object sender, RoutedEventArgs e)
        {

        }
        private void TxtSchoolYearPresent_Leave(object sender, RoutedEventArgs e)
        {

        }
        private void CmbSchoolYear_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            currentSchoolYear = (SchoolYear)cmbSchoolYearCurrents.SelectedItem;
            if (!loading)
            {
                nextSchoolYear = Commons.bl.GenerateNewYearData(currentSchoolYear);
                FromClassesToUi();
                cmbClasses.ItemsSource = null;
                cmbClasses.ItemsSource = Commons.bl.GetClassesOfYear(
                    currentSchool.IdSchool, currentSchoolYear.IdSchoolYear);
            }
        }
        private void CmbClasses_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (!loading)
            {
                btnClassMigration.Visibility = Visibility.Visible;
                currentClass = (Class)cmbClasses.SelectedItem;
                try
                {
                    nextClass = Commons.bl.GenerateNewClassData(currentClass);
                }
                catch
                {
                    nextClass.Abbreviation = "";
                }
                FromClassesToUi();
            }
        }
        private void btnAssociateSchoolPeriodsToTheYear_Click(object sender, RoutedEventArgs e)
        {
            frmSchoolYearAndPeriodsManagement f = new frmSchoolYearAndPeriodsManagement(txtSchoolYearNext.Text);
            f.ShowDialog();
        }

        private void btnClassGeneration_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAssociateSchoolPeriodToTheYear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClassMigration_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClassNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStudentNew_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

