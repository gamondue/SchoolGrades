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
    public partial class frmTestManagement : Form
    {
        List<Test> listTests = new List<Test>();
        Test currentTest;
        public frmTestManagement()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            currentTest = new Test();

            // !!!!!!!!!!!
            currentTest = Commons.bl.GetTest(1);
            // !!!!!!!!!!!

            List<QuestionType> lq = Commons.bl.GetListQuestionTypes(true);
            cmbQuestionTypes.DisplayMember = "Name";
            cmbQuestionTypes.ValueMember = "idQuestionType";
            cmbQuestionTypes.DataSource = lq;
            cmbQuestionTypes.SelectedValue = "close"; 

            RefreshUi();
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            txtIdTest.Text = ""; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ReadDataFromUI(); 
            Commons.bl.SaveTest(currentTest);
            RefreshUi(); 
        }

        private void RefreshUi()
        {
            dgwTests.DataSource = Commons.bl.GetTests();

            txtIdTest.Text = currentTest.IdTest.ToString();
            txtTestName.Text = currentTest.Name;
            txtTestDescription.Text = currentTest.Desc;

            if (currentTest.IdTest != 0)
            {
                dgwQuestions.DataSource = Commons.bl.GetAllQuestionsOfATest(currentTest.IdTest); 
            }
            // !!!! put the rest of the data !!!!
        }

        private void ReadDataFromUI()
        {
            if (txtIdTest.Text != "")
            {
                currentTest.IdTest = int.Parse(txtIdTest.Text);
            }
            currentTest.Name = txtTestName.Text;
            currentTest.Desc = txtTestDescription.Text;
        }
        private void dgwTests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwTests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwTests.Rows[e.RowIndex].Selected = true;

                List < Test > ls = (List<Test>)(dgwTests.DataSource);
                Test currentTest = ls[e.RowIndex];
                //Test currentTest = new Test();
                //currentTest = db.GetTest(1); 

                RefreshUi(); 
            }
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            Question dummy = new Question();
            dummy.IdQuestionType = (string)cmbQuestionTypes.SelectedValue; 
            frmQuestionChoose scelta = new frmQuestionChoose(null, null, null, dummy);
            scelta.ShowDialog();
            if (scelta.ChosenQuestion != null && scelta.ChosenQuestion.IdQuestion != 0)
            {
                Commons.bl.AddQuestionToTest(currentTest, scelta.ChosenQuestion);
            }
            scelta.Dispose();
        }
        private void updateQuestions()
        {
            RefreshUi();
        }

        private void btnGradeTest_Click(object sender, EventArgs e)
        {
            frmTestAssessing gt = new frmTestAssessing(); // !!!!! pass the test !!!!!!
                gt.Show(); 
        }

        private void dgwQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwQuestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                /////////////dgwTests.Rows[e.RowIndex].Selected = true;
                List<Question> lq = (List<Question>)(dgwQuestions.DataSource);
                Question chosenQuestion = lq[e.RowIndex];

                //// begin temporary !!!
                //List<Question> lq = (List<Question>)(dgwQuestions.DataSource);
                ////Question chosenQuestion = lq[e.RowIndex];
                //Question chosenQuestion = db.
                //// end temporary !!!

                frmQuestion fq = new frmQuestion(frmQuestion.QuestionFormType.EditOneQuestion, chosenQuestion, null, null, null);
                fq.Show();
            }
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (dgwQuestions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare una domanda da togliere dalla prova!");
                return; 
            }
            int indexSelected = dgwQuestions.SelectedRows[0].Index;
            List <Question> l = (List<Question>)dgwQuestions.DataSource; 
            int? idQuestionToRemove = l[indexSelected].IdQuestion; 
            Commons.bl.RemoveQuestionFromTest(idQuestionToRemove, currentTest.IdTest);
        }
    }
}
