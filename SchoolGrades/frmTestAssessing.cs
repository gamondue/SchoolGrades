using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmTestAssessing : Form
    {
        Test currentTest;
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
            dgwQuestions.DataSource = Commons.bl.GetAllQuestionsOfATest(currentTest.IdTest);
            dgwClassStudents.DataSource = Commons.bl.GetStudentsOfClassList(Commons.IdSchool,
                currentClass.SchoolYear, currentClass.Abbreviation, false);
        }

        private void dgwQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwQuestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwQuestions.Rows[e.RowIndex].Selected = true;

                List<Question> listQuestions = (List<Question>)(dgwQuestions.DataSource);
                currentQuestion = listQuestions[e.RowIndex];

                txtQuestion.Text = currentQuestion.Text;

                List<Answer> listAnswers = Commons.bl.GetAnswersOfAQuestion(currentQuestion.IdQuestion);
                dgwAnswers.DataSource = listAnswers;
                // erase all previous radio buttons in grpStudentsAnswers
                grpStudentsAnswers.Visible = false;
                while (grpStudentsAnswers.Controls.Count > 0)
                {
                    grpStudentsAnswers.Controls[0].Dispose();
                }
                grpStudentsAnswers.Visible = true;

                // the next database field must be managed, today it ISN'T!!!
                currentQuestion.IsMutex = false; // !!!!!!!!!!!!!!!!!!!!!!!!!! remove before publishing anything

                Control cntrl;
                for (int i = 0; i < listAnswers.Count; i++)
                {
                    if ((bool)currentQuestion.IsMutex)
                    {
                        cntrl = new RadioButton();
                    }
                    else
                    {
                        cntrl = new CheckBox();
                    }
                    cntrl.Location = new Point(7, i * 30 + 40);
                    cntrl.Size = new Size(grpStudentsAnswers.Size.Width - 14, cntrl.Size.Height);
                    //rb.TextAlign = ContentAlignment.MiddleLeft;
                    cntrl.Text = listAnswers[i].Text;
                    grpStudentsAnswers.Controls.Add(cntrl);

                    fillCheckBoxes();
                }
            }
        }

        private void dgwClassStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwClassStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (currentQuestion == null || currentQuestion.IdQuestion == null)
                {
                    MessageBox.Show("Scegliere una domanda");
                    return;
                }
                dgwClassStudents.Rows[e.RowIndex].Selected = true;

                List<Student> ls = (List<Student>)(dgwClassStudents.DataSource);
                currentStudent = ls[e.RowIndex];

                fillCheckBoxes();
            }
        }

        private void fillCheckBoxes()
        {
            if (currentStudent != null)
            {
                txtStudent.Text = currentStudent.LastName + " " + currentStudent.FirstName;
                List<StudentsAnswer> ans = Commons.bl.GetAllAnswersOfAStudentToAQuestionOfThisTest(
                    currentStudent.IdStudent, currentQuestion.IdQuestion, currentTest.IdTest);
                if (grpStudentsAnswers.Controls.Count != ans.Count)
                {
                    Console.Beep();
                    return;
                }
                int i = 0;
                foreach (StudentsAnswer sa in ans)
                {
                    ((CheckBox)grpStudentsAnswers.Controls[i]).Checked = (bool)sa.StudentsBoolAnswer;
                    i++;
                }
            }
        }

        private void dgwClassStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSaveStudentsAnswers_Click(object sender, EventArgs e)
        {
            if (currentStudent == null)
            {
                MessageBox.Show("Scegliere uno studente");
                return;
            }
            List<Answer> la = (List<Answer>)dgwAnswers.DataSource;
            for (int i = 0; i < la.Count; i++)
            {
                Answer a = la[i];
                if ((bool)currentQuestion.IsMutex)
                {
                    RadioButton rb = (RadioButton)grpStudentsAnswers.Controls[i];
                    Commons.bl.SaveStudentsAnswer(currentStudent, currentTest, a,
                        rb.Checked, null);
                }
                else
                {
                    CheckBox cb = (CheckBox)grpStudentsAnswers.Controls[i];
                    Commons.bl.SaveStudentsAnswer(currentStudent, currentTest, a,
                        cb.Checked, null);
                }
            }
        }
        private void btnGradeAllTest_Click(object sender, EventArgs e)
        {
            frmTestGrading fg = new frmTestGrading();
            fg.Show();
        }

        private void dgwAnswers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwAnswers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgwAnswers.Rows[e.RowIndex].Selected = true;
        }

        private void dgwAnswers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwAnswers.Rows[e.RowIndex].Selected = true;

                List<Answer> ls = (List<Answer>)(dgwAnswers.DataSource);
                Answer a = ls[e.RowIndex];

                Question q = Commons.bl.GetQuestionById(a.IdQuestion);
                frmQuestion fq = new frmQuestion(frmQuestion.QuestionFormType.EditOneQuestion,
                    q, null, null, null);
                fq.Show();
            }
        }

        private void dgwQuestions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmQuestion fc = new frmQuestion(
                frmQuestion.QuestionFormType.EditOneQuestion, currentQuestion, null, null, null);
            fc.Show();
            RefreshUi();
        }
    }
}
