using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmTestAssessing.xaml
    /// </summary>
    public partial class frmTestAssessing : Window
    {
        SchoolTest currentTest;
        Class currentClass;
        Student currentStudent;
        Question currentQuestion;
        List<StudentsAnswer> currentStudentsAnswers;

        public frmTestAssessing()
        {
            InitializeComponent();
        }
        private void frmTestGrades_Load(object sender, EventArgs e)
        {
            currentTest = Commons.bl.GetTest(1); //!!!!!!!!!!!!!!
            currentClass = Commons.bl.GetClass(Commons.IdSchool, "19-20", "IFTS"); //!!!!!!!!!!!!!!

            RefreshUi();
        }
        private void RefreshUi()
        {
            dgwQuestions.ItemsSource = Commons.bl.GetAllQuestionsOfATest(currentTest.IdTest);
            dgwClassStudents.ItemsSource = Commons.bl.GetStudentsOfClassList(Commons.IdSchool,
                currentClass.SchoolYear, currentClass.Abbreviation, false);
        }
        private void dgwQuestions_CellContentClick(object sender, RoutedEvent e)
        {

        }
        private void dgwQuestions_CellClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                //////////dgwQuestions.Items[RowIndex].Selected = true;

                List<Question> listQuestions = (List<Question>)(dgwQuestions.ItemsSource);
                currentQuestion = listQuestions[RowIndex];

                txtQuestion.Text = currentQuestion.Text;

                List<Answer> listAnswers = Commons.bl.GetAnswersOfAQuestion(currentQuestion.IdQuestion);
                dgwAnswers.ItemsSource = listAnswers;
                //////////// erase all previous radio buttons in grpStudentsAnswers
                //////////grpStudentsAnswers.Visibility = Visibility.Hidden;
                //////////while (grpStudentsAnswers.Controls.Count > 0)
                //////////{
                //////////    grpStudentsAnswers.Controls[0].Dispose();
                //////////}
                //////////grpStudentsAnswers.Visibility = Visibility.Visible;

                //////////// the next database field must be managed, today it ISN'T!!!
                //////////currentQuestion.IsMutex = false; // !!!!!!!!!!!!!!!!!!!!!!!!!! remove before publishing anything

                //////////Control cntrl;
                //////////for (int i = 0; i < listAnswers.Count; i++)
                //////////{
                //////////    if ((bool)currentQuestion.IsMutex)
                //////////    {
                //////////        cntrl = new RadioButton();
                //////////    }
                //////////    else
                //////////    {
                //////////        cntrl = new CheckBox();
                //////////    }
                //////////    ////////////cntrl.Location = new Point(7, i * 30 + 40);
                //////////    ////////////cntrl.Size = new Size(grpStudentsAnswers.Size.Width - 14, cntrl.Size.Height);
                //////////    //////////////rb.TextAlign = ContentAlignment.MiddleLeft;
                //////////    ////////////cntrl.Text = listAnswers[i].Text;
                //////////    ////////////grpStudentsAnswers.Controls.Add(cntrl);

                //////////    fillCheckBoxes();
                //////////}
            }
        }
        private void dgwClassStudents_CellContentClick(object sender, RoutedEvent e)
        {

        }
        private void dgwClassStudents_CellClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                if (currentQuestion == null || currentQuestion.IdQuestion == null)
                {
                    MessageBox.Show("Scegliere una domanda");
                    return;
                }
                //////////dgwClassStudents.Items[RowIndex].Selected = true;

                List<Student> ls = (List<Student>)(dgwClassStudents.ItemsSource);
                currentStudent = ls[RowIndex];

                fillCheckBoxes();
            }
        }
        private void fillCheckBoxes()
        {
            //////////if (currentStudent != null)
            //////////{
            //////////    txtStudent.Text = currentStudent.LastName + " " + currentStudent.FirstName;
            //////////    List<StudentsAnswer> ans = Commons.bl.GetAllAnswersOfAStudentToAQuestionOfThisTest(
            //////////        currentStudent.IdStudent, currentQuestion.IdQuestion, currentTest.IdTest);
            //////////    if (grpStudentsAnswers.Controls.Count != ans.Count)
            //////////    {
            //////////        Console.Beep();
            //////////        return;
            //////////    }
            //////////    int i = 0;
            //////////    foreach (StudentsAnswer sa in ans)
            //////////    {
            //////////        ((CheckBox)grpStudentsAnswers.Controls[i]).IsChecked = (bool)sa.StudentsBoolAnswer;
            //////////        i++;
            //////////    }
            //////////}
        }
        private void dgwClassStudents_CellDoubleClick(object sender, RoutedEvent e)
        {

        }
        private void btnSaveStudentsAnswers_Click(object sender, EventArgs e)
        {
            //////////if (currentStudent == null)
            //////////{
            //////////    MessageBox.Show("Scegliere uno studente");
            //////////    return;
            //////////}
            //////////List<Answer> la = (List<Answer>)dgwAnswers.ItemsSource;
            //////////for (int i = 0; i < la.Count; i++)
            //////////{
            //////////    Answer a = la[i];
            //////////    if ((bool)currentQuestion.IsMutex)
            //////////    {
            //////////        RadioButton rb = (RadioButton)grpStudentsAnswers.Controls[i];
            //////////        Commons.bl.SaveStudentsAnswer(currentStudent, currentTest, a,
            //////////            (bool)rb.IsChecked, null);
            //////////    }
            //////////    else
            //////////    {
            //////////        CheckBox cb = (CheckBox)grpStudentsAnswers.Controls[i];
            //////////        Commons.bl.SaveStudentsAnswer(currentStudent, currentTest, a,
            //////////            (bool)cb.IsChecked, null);
            //////////    }
            //////////}
        }
        private void btnGradeAllTest_Click(object sender, EventArgs e)
        {
            frmTestGrading fg = new frmTestGrading();
            fg.Show();
        }
        private void dgwAnswers_CellContentClick(object sender, RoutedEvent e)
        {

        }

        private void dgwAnswers_CellClick(object sender, RoutedEvent e)
        {
            //dgwAnswers.Items[RowIndex].Selected = true;
        }
        private void dgwAnswers_CellDoubleClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                ////////dgwAnswers.Items[RowIndex].Selected = true;

                List<Answer> ls = (List<Answer>)(dgwAnswers.ItemsSource);
                Answer a = ls[RowIndex];

                Question q = Commons.bl.GetQuestionById(a.IdQuestion);
                frmQuestion fq = new frmQuestion(frmQuestion.QuestionFormType.EditOneQuestion,
                    q, null, null, null);
                fq.Show();
            }
        }
        private void dgwQuestions_CellDoubleClick(object sender, RoutedEvent e)
        {
            frmQuestion fc = new frmQuestion(
                frmQuestion.QuestionFormType.EditOneQuestion, currentQuestion, null, null, null);
            fc.Show();
            RefreshUi();
        }
    }
}
