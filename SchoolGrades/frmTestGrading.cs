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
    public partial class frmTestGrading : Form
    {
        Test currentTest;
        Class currentClass;
        Student currentStudent;
        Question currentQuestion;

        public frmTestGrading()
        {
            InitializeComponent();

        }

        private void frmTestAssessment_Load(object sender, EventArgs e)
        {
            currentTest = Commons.bl.GetTest(1); //!!!!!!!!!!!!!!
            currentClass = Commons.bl.GetClass(Commons.IdSchool, "19-20", "IFTS"); //!!!!!!!!!!!!!!

            GradeTest(); 
            RefreshUi();
        }

        private void GradeTest()
        {
            List<Student> studentsThatAnswered = Commons.bl.GetAllStudentsThatAnsweredToATest(currentTest, currentClass);
            List<Question> allQuestions = Commons.bl.GetAllQuestionsOfATest(currentTest.IdTest);

            dgwTestResults.Rows.Clear();        // !!!! erase when fully debugged //
            dgwTestResults.Columns.Clear();     // !!!! erase when fully debugged //

            int gridRow = 0, gridColumn = 0;
            GridAddData(gridRow, gridColumn, "Domande e risposte");
            gridRow++;
            gridColumn = 1; 

            List<Answer> correctQuestionAnswers;
            // showing the correct answers and weights of the questions
            foreach (Question q in allQuestions)
            {
                correctQuestionAnswers = Commons.bl.GetAllCorrectAnswersToThisQuestionOfThisTest(
                    q.IdQuestion, currentTest.IdTest);

                GridAddData(gridRow, gridColumn, q.Text);
                GridAddData(gridRow, gridColumn + 1, "Risposte esatte");
                GridAddData(gridRow, gridColumn + 2, "Costo errore");

                // scan all the correct answers to this question 
                for (int iAnswer = 0; iAnswer < correctQuestionAnswers.Count; iAnswer++)
                {
                    GridAddData(gridRow + iAnswer + 1, gridColumn,
                        ((iAnswer + 1).ToString() + "- " + correctQuestionAnswers[iAnswer].Text));
                    GridAddData(gridRow + iAnswer + 1, gridColumn + 1,
                        correctQuestionAnswers[iAnswer].IsCorrect.ToString());
                    GridAddData(gridRow + iAnswer + 1, gridColumn + 2,
                        correctQuestionAnswers[iAnswer].ErrorCost.ToString());
                }

                // show the weight of the question
                GridAddData(gridRow + correctQuestionAnswers.Count + 1, gridColumn, "Peso della domanda");
                GridAddData(gridRow + correctQuestionAnswers.Count + 1, gridColumn +1, q.Weight.ToString());
                gridColumn += 3;
            }
            gridRow += 7;
            gridColumn = 0; 
            GridAddData(gridRow, gridColumn, "Correzione delle risposte degli allievi");
            gridRow++;
            // showing and grading the answers of the students
            foreach (Student s in studentsThatAnswered)
            {
                GridAddData(gridRow, gridColumn, s.LastName + " " + s.FirstName);
                GridAddData(gridRow, gridColumn + 3, "Risposta allievo");
                GridAddData(gridRow, gridColumn + 3, "Costo errori");

                double weightedSum = 0;
                double sumOfWeights = 0;
                gridColumn = 0;

                // grading of students' answers
                foreach (Question q in allQuestions)
                {
                    correctQuestionAnswers = Commons.bl.GetAllCorrectAnswersToThisQuestionOfThisTest(
                        q.IdQuestion, currentTest.IdTest);
                    List<StudentsAnswer> studentsQuestionAnswers = Commons.bl.GetAllAnswersOfAStudentToAQuestionOfThisTest(
                        s.IdStudent, q.IdQuestion, currentTest.IdTest);

                    int budgetOfQuestion = 100;
                    gridColumn++;

                    GridAddData(gridRow, gridColumn, q.Text);

                    // scan all the correct answers to this question 
                    for (int iCorrectAnswer = 0; iCorrectAnswer < correctQuestionAnswers.Count; iCorrectAnswer++)
                    {
                        GridAddData(gridRow + iCorrectAnswer + 1, gridColumn,
                                (correctQuestionAnswers[iCorrectAnswer].Text));
                        bool found = false;
                        int budgetDecreaseForThisAnswer;
                        int iStudentAnswer; 
                        // scan all the answers that the current student has given to this question 
                        for (iStudentAnswer = 0; iStudentAnswer < studentsQuestionAnswers.Count;
                            iStudentAnswer++)
                        {
                            if (correctQuestionAnswers[iCorrectAnswer].IdAnswer ==
                                studentsQuestionAnswers[iStudentAnswer].IdAnswer)
                            {
                                found = true;
                                break; 
                            }
                        }
                        if (found)
                        { 
                            if (correctQuestionAnswers[iCorrectAnswer].IsCorrect ==
                                studentsQuestionAnswers[iStudentAnswer].StudentsBoolAnswer)
                            {   // if answer is correct it doesn't decrease the budget
                                budgetDecreaseForThisAnswer = 0; 
                            }
                            else
                            {   // if not correct it decreases the budget of ErrorCost
                                budgetDecreaseForThisAnswer = (int)correctQuestionAnswers[iCorrectAnswer].ErrorCost;
                                budgetOfQuestion -= budgetDecreaseForThisAnswer;
                            }
                            GridAddData(gridRow + iCorrectAnswer + 1, gridColumn + 1,
                                studentsQuestionAnswers[iStudentAnswer].StudentsBoolAnswer.ToString());
                        }
                        else
                        {   // no answer: question is spoiled 
                            budgetDecreaseForThisAnswer = 100;
                            budgetOfQuestion -= budgetDecreaseForThisAnswer; 
                            GridAddData(gridRow + iCorrectAnswer + 1, gridColumn + 1, "No ans");
                        }
                        GridAddData(gridRow + iCorrectAnswer + 1, gridColumn + 2,
                            budgetDecreaseForThisAnswer.ToString());
                        GridAddData(gridRow + iCorrectAnswer + 1, gridColumn,
                            correctQuestionAnswers[iCorrectAnswer].Text);

                        if (budgetOfQuestion < 0)
                            budgetOfQuestion = 0;
                    }
                    GridAddData(gridRow + 5, gridColumn + 1, "Punti per domanda");
                    GridAddData(gridRow + 5, gridColumn + 2, budgetOfQuestion.ToString());

                    weightedSum += (double)q.Weight * budgetOfQuestion; // currently mean is NOT Weigthed !!!!
                    sumOfWeights += (double)q.Weight;

                    gridColumn += 2;
                }

                // weighted mean
                double weightedMean = weightedSum / sumOfWeights;

                GridAddData(gridRow, gridColumn + 1, "Media pesata");
                GridAddData(gridRow + 1, gridColumn + 1, weightedMean.ToString());

                gridRow += 7;
                gridColumn = 0;
            }
        }

        private void GridAddData(int GridRow, int GridColumn, string DataToShow)
        {
            // if you don't do the next, it would add the row as the first row
            dgwTestResults.AllowUserToAddRows = false;  
            while (dgwTestResults.Columns.Count <= GridColumn)
            {
                dgwTestResults.Columns.Add("", "");
            }
            while (dgwTestResults.Rows.Count <= GridRow)
            {   
                dgwTestResults.Rows.Add("", "");
            }
            dgwTestResults.Rows[GridRow].Cells[GridColumn].Value = DataToShow;
        }

        private void RefreshUi()
        {
            ////////////////////throw new NotImplementedException();
        }

        private void btnRecalc_Click(object sender, EventArgs e)
        {
            dgwTestResults.Columns.Clear();
            dgwTestResults.Rows.Clear();
            GradeTest(); 
        }

        private void dgwTestResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtCurrentCell.Text = dgwTestResults.SelectedCells[0].Value.ToString(); 
            }
        }
        private void btnMakeFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO !!!!"); 
        }
    }
}
