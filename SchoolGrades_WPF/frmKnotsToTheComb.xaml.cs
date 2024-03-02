using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for KnotsToTheComb.xaml
    /// </summary>
    public partial class frmKnotsToTheComb : Window
    {
        private Question chosenQuestion = new Question();
        private frmMicroAssessment grandparentForm;

        private Student currentStudent;
        private SchoolSubject currentSubject;
        private string currentIdSchoolYear;
        private int currentIdGrade;

        bool isLoading = true;

        internal Question ChosenQuestion { get; private set; }
        public frmKnotsToTheComb(frmMicroAssessment GrandparentForm, int? IdStudent, SchoolSubject SchoolSubject, string Year)
        {
            InitializeComponent();
            currentStudent = Commons.bl.GetStudent(IdStudent);
            lblStudent.Content = currentStudent.LastName + " " + currentStudent.FirstName;
            currentIdSchoolYear = Year;
            currentSubject = SchoolSubject;
            grandparentForm = GrandparentForm;

            // fills the lookup tables' combos
            cmbSchoolSubject.DisplayMemberPath = "Name";
            cmbSchoolSubject.SelectedValuePath = "idSchoolSubject";
            cmbSchoolSubject.ItemsSource = Commons.bl.GetListSchoolSubjects(true);

            currentSubject = SchoolSubject;
            ChosenQuestion = null;
        }
        private void FrmKnotsToTheComb_Load(object sender, EventArgs e)
        {
            if (currentSubject.IdSchoolSubject != null)
                cmbSchoolSubject.SelectedValue = currentSubject.IdSchoolSubject;
            RefreshData();
        }
        private void RefreshData()
        {
            dgwQuestions.ItemsSource = (System.Collections.IEnumerable)
            Commons.bl.GetUnfixedGrades(currentStudent, currentSubject.IdSchoolSubject, 60);
        }
        private void DgwQuestions_CellContentClick(object sender, RoutedEvent e)
        {

        }
        private void DgwQuestions_RowEnter(object sender, RoutedEvent e)
        {
            //////////DataGrid grid = (DataGrid)sender;
            //////////int RowIndex = grid.SelectedIndex;
            //////////if (RowIndex > -1)
            //////////{
            //////////    DataGridRow r = dgwQuestions.Items[RowIndex];
            //////////    txtQuestionText.Text = (string)r.Cells["Text"].Value;
            //////////    currentIdGrade = (int)r.Cells["IdQuestion"].Value;
            //////////}
        }
        private void DgwQuestions_CellClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                ////////dgwQuestions.Items[RowIndex].Selected = true;
            }
        }
        private void DgwQuestions_CellDoubleClick(object sender, RoutedEvent e)
        {
            // choose this question
            // !!!! TODO !!!!
        }
        private void BtnFix_Click(object sender, EventArgs e)
        {
            ////////if (dgwQuestions.SelectedItems.Count == 0)
            ////////{
            ////////    MessageBox.Show("Selezionare la domanda che è stata riparata");
            ////////    return;
            ////////}
            //////////DataGridRow r = dgwQuestions.SelectedItems[0];
            //////////currentIdGrade = (int)r.Cells["IdGrade"].Value;
            ////////Question q = ((Question)dgwQuestions.SelectedValue);

            ////////if (MessageBox.Show("La domanda '" + q.Text + "' è stata riparata?", "Riparazione domanda",
            ////////        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            ////////{
            ////////    //Commons.bl.FixQuestionInGrade(currentIdGrade);
            ////////    Commons.bl.FixQuestionInGrade(currentIdGrade);
            ////////    RefreshData();
            ////////}
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (dgwQuestions.SelectedItems.Count > 0)
            {
                //int key = int.Parse(dgwQuestions.SelectedItems[0].Cells[6].Value.ToString());
                int key = (int)((Grade)dgwQuestions.SelectedItems[0]).IdQuestion;
                ChosenQuestion = Commons.bl.GetQuestionById(key);
                if (grandparentForm != null)
                {
                    // form called by student's assessment form 
                    grandparentForm.CurrentQuestion = ChosenQuestion;
                    grandparentForm.DisplayCurrentQuestion();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Scegliere una domanda nella griglia");
                return;
            }
        }
        private void cmbSchoolSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSubject = (SchoolSubject)cmbSchoolSubject.SelectedItem;
            this.Background = CommonsWpf.BrushFromColor(CommonsWpf.ColorFromNumber(currentSubject.Color));
            RefreshData();
        }
    }
}
