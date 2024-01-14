using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class frmAnnotationsAboutStudents : Window
    {
        private string idSchoolYear;
        private StudentAnnotation currentAnnotation;
        private List<Student> chosenStudents;
        private Student currentStudent;
        private string yearUsed;

        /// <summary>
        /// Constructor that passes a list of those to whom the annotation must apply
        /// </summary>
        /// <param name="ChosenStudents"></param>
        /// <param name="IdSchoolYear"></param>
        public frmAnnotationsAboutStudents(List<Student> ChosenStudents, string IdSchoolYear)
        {
            InitializeComponent();

            idSchoolYear = IdSchoolYear;
            this.chosenStudents = ChosenStudents;
            dgwStudents.ItemsSource = ChosenStudents;
        }
        private void frmStudentsNotes_Load(object sender, RoutedEventArgs e)
        {
            txtSchoolYear.Text = idSchoolYear;
            yearUsed = idSchoolYear;
            RefreshUI();

            if (chosenStudents.Count == 1)
            {
                // single student: select him in the grid 
                dgwStudents.SelectedIndex = 0;
                // set him as current student
                currentStudent = chosenStudents[0];
                // show his annotations
                ShowAnnotationsOfCurrentStudent();
            }
        }
        private void RefreshUI()
        {
            dgwNotes.ItemsSource = Commons.bl.AnnotationsAboutThisStudent(currentStudent, yearUsed,
                (bool)chkShowOnlyActive.IsChecked);
            if (dgwNotes.Items.Count == 0)
                currentAnnotation = new StudentAnnotation();
            WriteUI();
        }
        private void WriteUI()
        {
            if (currentAnnotation != null)
            {
                if (currentAnnotation.IdSchoolYear != null)
                    txtSchoolYear.Text = currentAnnotation.IdSchoolYear;
                txtAnnotation.Text = currentAnnotation.Annotation;
                txtIdAnnotation.Text = currentAnnotation.IdAnnotation.ToString();
                if (currentAnnotation.IsActive == null) currentAnnotation.IsActive = false;
                chkCurrentActive.IsChecked = (bool)currentAnnotation.IsActive;
                if (currentAnnotation.IsPopUp == null) currentAnnotation.IsPopUp = false;
                chkPopUp.IsChecked = (bool)currentAnnotation.IsPopUp;
            }
        }
        private void ReadUI()
        {
            if (currentAnnotation == null)
                currentAnnotation = new StudentAnnotation();

            currentAnnotation.IdSchoolYear = txtSchoolYear.Text;
            //if (txtAnnotation.Text != "")
            currentAnnotation.IdAnnotation = Safe.Int(txtIdAnnotation.Text);
            ////else
            ////    currentAnnotation.IdAnnotation = null;
            if (currentAnnotation.IdStudent != 0)
                currentAnnotation.IdStudent = Safe.Int(txtIdStudent.Text);
            else
                currentAnnotation.IdStudent = null;
            currentAnnotation.Annotation = txtAnnotation.Text;
            if (currentAnnotation.IsActive == null) currentAnnotation.IsActive = false;
            currentAnnotation.IsActive = chkCurrentActive.IsChecked;
            if (currentAnnotation.IsPopUp == null) currentAnnotation.IsPopUp = false;
            currentAnnotation.IsPopUp = chkPopUp.IsChecked;
        }
        private void txtSchoolYear_TextChanged(object sender, RoutedEventArgs e)
        {
            //ReadUI(); 
            //RefreshUI();
        }
        private void dgwNotes_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
        private void dgwNotes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
        private void dgwNotes_CellClick(object sender, RoutedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                dgwNotes.SelectedIndex = RowIndex;

                currentAnnotation = ((List<StudentAnnotation>)dgwNotes.ItemsSource)[RowIndex];
            }
            WriteUI();
        }

        private void dgwNotes_MouseDown(object sender, RoutedEvent e)
        {
            if (sender != null)
            {
                DataGrid grid = (DataGrid)sender;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    DataGridRow dgr = (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem);
                }
            }
        }
        private void btnAddAnnotation_Click(object sender, RoutedEventArgs e)
        {
            ReadUI();
            currentAnnotation.InstantTaken = DateTime.Now;
            currentAnnotation.InstantClosed = null;
            currentAnnotation.IsActive = true;
            //db.SaveAnnotation(currentAnnotation);

            RefreshUI();
        }
        private void SaveAnnotations(bool SaveMany)
        {
            if (currentAnnotation.IdAnnotation == null)
            {
                if (!SaveMany)
                {
                    if (!CommonsWpf.CheckIfStudentChosen(currentStudent))
                        return;
                    currentAnnotation.IdAnnotation = null;
                    currentAnnotation.IdAnnotation = Commons.bl.SaveAnnotation(currentAnnotation, currentStudent);
                }
                else
                {
                    foreach (Student s in chosenStudents)
                    {
                        currentAnnotation.IdAnnotation = null;
                        currentAnnotation.IdAnnotation = Commons.bl.SaveAnnotation(currentAnnotation, s);
                    }
                }
                return;
            }
            else
            {
                // if IsActive has changed from what is in database then we change dates 
                // according to the status 
                if (Commons.bl.GetAnnotation(currentAnnotation.IdAnnotation).IsActive != currentAnnotation.IsActive)
                {
                    if (currentAnnotation.IsActive == true)
                    {
                        // if it wasn't active and now it is, we set date taken now
                        currentAnnotation.InstantTaken = DateTime.Now;
                        currentAnnotation.InstantClosed = null;
                    }
                    else
                    {
                        // if it was active and now it isn't, we set the date closed now
                        currentAnnotation.InstantClosed = DateTime.Now;
                    }
                }
                if (SaveMany)
                {
                    foreach (Student s in chosenStudents)
                    {
                        Commons.bl.SaveAnnotation(currentAnnotation, s);
                    }
                }
                else
                    Commons.bl.SaveAnnotation(currentAnnotation, currentStudent);
            }
            RefreshUI();
        }
        private void ShowAnnotationsOfCurrentStudent()
        {
            txtIdStudent.Text = currentStudent.IdStudent.ToString();
            lblCurrentStudent.Text = $"{currentStudent.LastName} {currentStudent.FirstName}";
            dgwNotes.ItemsSource = Commons.bl.AnnotationsAboutThisStudent(currentStudent,
              yearUsed, (bool)chkShowOnlyActive.IsChecked);
            RefreshUI();
        }
        private void chkUseSchoolYear_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if ((bool)chkUseSchoolYear.IsChecked)
            {
                txtSchoolYear.IsEnabled = true;
                yearUsed = txtSchoolYear.Text;
            }
            else
            {
                txtSchoolYear.IsEnabled = true;
                yearUsed = null;
            }
            dgwNotes.ItemsSource = Commons.bl.AnnotationsAboutThisStudent(currentStudent,
                    yearUsed, (bool)chkShowOnlyActive.IsChecked);
        }
        private void btnAddAnnotationStudent_Click(object sender, RoutedEventArgs e)
        {
            if (txtAnnotation.Text == "")
            {
                MessageBox.Show("Testo dell'annotazione vuoto!");
                return;
            }
            if (txtIdAnnotation.Text != "")
            {   // an Id is already there 
                if (MessageBox.Show("Devo creare una nuova annotazione con lo stesso testo della precedente?",
                    "", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    return;
            }
            ReadUI();
            // null the Id to save a new annotaion 
            currentAnnotation.IdAnnotation = null;
            SaveAnnotations(false);
            RefreshUI();
        }
        private void btnAddAnnotationGroup_Click(object sender, RoutedEventArgs e)
        {
            if (txtAnnotation.Text == "")
            {
                MessageBox.Show("Testo dell'annotazione vuoto!");
                return;
            }
            ReadUI();
            currentAnnotation.IdAnnotation = null;
            SaveAnnotations(true);
            RefreshUI();
        }
        private void btnRemoveAnnotationStudent_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdAnnotation.Text == "")
            {
                MessageBox.Show("Scegliere un'annotazione da cancellare!");
                return;
            }
            if (MessageBox.Show($"Sicuro di cancellare l'annotazione {currentAnnotation.IdAnnotation}, '{currentAnnotation.Annotation}'?",
                "Attenzione", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                Commons.bl.EraseAnnotationById(currentAnnotation.IdAnnotation);
                RefreshUI();
            };
        }
        private void btnRemoveAnnotationGroup_Click(object sender, RoutedEventArgs e)
        {
            if (txtAnnotation.Text == "")
            {
                MessageBox.Show("Il testo dell'annotazione da cancellare è vuoto!");
                return;
            }
            if (MessageBox.Show($"Cancellazione di tutte le annotazioni '{txtAnnotation.Text}' in tutti gli allievi della griglia?",
                    "Attenzione", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                foreach (Student s in chosenStudents)
                {
                    Commons.bl.EraseAnnotationByText(txtAnnotation.Text, s);
                }
                RefreshUI();
            };
        }
        private void btnSaveModificationsStudent_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdAnnotation.Text == "")
            {
                MessageBox.Show("Scegliere un'annotazione da modificare");
                return;
            }
            if (txtAnnotation.Text == "")
            {
                MessageBox.Show("Testo dell'annotazione vuoto!");
                return;
            }
            ReadUI();
            currentAnnotation.IdAnnotation = Commons.bl.SaveAnnotation(currentAnnotation, currentStudent);
            RefreshUI();
        }
        private void btnSaveModificationsGroup_Click(object sender, RoutedEventArgs e)
        {
            // !!!! think how to make this !!!!
            MessageBox.Show("Da fare!");
            ////if (txtIdAnnotation.Text == "")
            ////{
            ////    MessageBox.Show("Scegliere un'annotazione da modificare");
            ////    return;
            ////}
            ////if (txtAnnotation.Text == "")
            ////{
            ////    MessageBox.Show("Testo dell'annotazione vuoto!");
            ////    return;
            ////}
            ////ReadUI();
            ////foreach (Student s in chosenStudents)
            ////{

            ////    currentAnnotation.IdAnnotation = db.UpdateAnnotationGroup(currentAnnotation, currentStudent);
            ////}
            ////RefreshUI();
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtIdAnnotation.Text = "";
            txtAnnotation.Text = "";
        }
        private void chkShowOnlyActive_CheckedChanged(object sender, RoutedEventArgs e)
        {
            ReadUI();
            if (currentStudent.IdStudent != null)
            {
                txtIdStudent.Text = currentStudent.IdStudent.ToString();
                lblCurrentStudent.Text = $"{currentStudent.LastName} {currentStudent.FirstName}";
                dgwNotes.ItemsSource = Commons.bl.AnnotationsAboutThisStudent(currentStudent,
                  yearUsed, (bool)chkShowOnlyActive.IsChecked);
            }
            RefreshUI();
        }
        private void dgwStudents_CellContentClick(object sender, RoutedEventArgs e)
        {

        }
        private void dgwStudents_CellClick(object sender, RoutedEventArgs e)
        {

        }
        private void dgwStudents_RowLeave(object sender, RoutedEventArgs e)
        {

        }
        private void dgwStudents_RowEnter(object sender, RoutedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                dgwStudents.SelectedIndex = RowIndex;
                currentStudent = chosenStudents[RowIndex];
                ShowAnnotationsOfCurrentStudent();
            }
        }
        private void chkCurrentActive_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (chkCurrentActive.IsChecked == false)
            {
                chkPopUp.IsChecked = false;
            }
        }
    }
}