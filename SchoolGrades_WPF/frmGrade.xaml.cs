using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmGrade.xaml
    /// </summary>
    public partial class frmGrade : Window
    {
        Student currentStudent;
        Grade currentGrade;
        Question currentQuestion;

        //private string currentYear;
        //private int idQuestionParent;
        //private string idGradeType;
        ////BusinessLayer Commons.bl;
        //private string idGradeTypeParent;

        //frmMain callingForm;

        //private Class currentClass;
        //Student currentStudent;
        //GradeType currentGradeType;
        //SchoolSubject currentSchoolSubject;

        public frmGrade(Student Student, Grade Grade)
        {
            InitializeComponent();

            currentStudent = Student;
            currentGrade = Grade;
            currentQuestion = Commons.bl.GetQuestionById(currentGrade.IdQuestion);
        }
        private void frmGrade_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            lblStudent.Text = currentStudent.ToString();
            txtIdStudent.Text = currentStudent.IdStudent.ToString();
            txtSchoolSubject.Text = currentGrade.IdSchoolSubject;
            txtGradeWeight.Text = currentGrade.Weight.ToString();
            txtGrade.Text = currentGrade.Value.ToString();
            if (currentQuestion != null)
                txtQuestionText.Text = currentQuestion.Text;
            else
                txtQuestionText.Text = "";
            if (currentGrade.IdQuestion != null)
            {
                currentQuestion = Commons.bl.GetQuestionById(currentGrade.IdQuestion);
            }
            else
            {
                currentQuestion = new Question();
                currentQuestion.IdQuestion = null;
            }
        }
        private void txtQuestionText_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtQuestionText_DoubleClick(object sender, EventArgs e)
        {
            frmQuestion f = new frmQuestion(frmQuestion.QuestionFormType.EditOneQuestion, currentQuestion, null, null, null);
            f.ShowDialog();
        }
    }
}
