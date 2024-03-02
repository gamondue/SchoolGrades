using gamon.TreeMptt;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmQuestion : Form
    {
        TreeMpttDb_SqLite dbMptt;

        internal Question currentQuestion = new Question();
        internal bool UserHasChosen;

        List<Tag> tagsList;
        List<Answer> answersList;
        private SchoolSubject currentSubject;
        private Topic currentTopic;
        //string idSchoolSubject;
        private Class currentClass;

        public enum QuestionFormType
        {
            EditOneQuestion,
            CreateSeveralQuestions,
        }
        QuestionFormType formType;

        internal frmQuestion(QuestionFormType Type, Question Question,
            SchoolSubject Subject, Class Class, Topic Topic)
        {
            InitializeComponent();

#if SQL_SERVER
            TreeMpttDb_SqlServer dbMptt = new();
#else
            TreeMpttDb_SqLite dbMptt = new TreeMpttDb_SqLite();
#endif

            // fills the lookup tables' combos
            List<QuestionType> listQuestions = Commons.bl.GetListQuestionTypes(true);
            cmbQuestionType.DisplayMember = "Name";
            cmbQuestionType.ValueMember = "idQuestionType";
            cmbQuestionType.DataSource = listQuestions;

            List<SchoolSubject> listSubjects = Commons.bl.GetListSchoolSubjects(true);
            cmbSchoolSubject.DisplayMember = "Name";
            cmbSchoolSubject.ValueMember = "idSchoolSubject";
            cmbSchoolSubject.DataSource = listSubjects;

            currentClass = Class;
            currentSubject = Subject;
            currentQuestion = Question;
            formType = Type;
            if (formType == QuestionFormType.EditOneQuestion)
            {
                currentQuestion = Commons.bl.GetQuestionById(Question.IdQuestion);
            }
            if (Topic != null && Topic.Id != null)
            {
                currentTopic = Commons.bl.GetTopicById(Topic.Id);
                if (currentTopic.Id != 0)
                    txtTopic.Text = dbMptt.GetNodePath(currentTopic.Id);
            }
        }

        private void frmQuestion_Load(object sender, EventArgs e)
        {
            if (currentSubject != null && currentSubject.IdSchoolSubject != null && currentSubject.IdSchoolSubject != "")
            {
                //string dummyId = currentSubject.IdSchoolSubject;              
                //currentSubject = db.GetSchoolSubject(dummyId);
                cmbSchoolSubject.SelectedValue = currentSubject.IdSchoolSubject;
            }

            switch (formType)
            {
                case QuestionFormType.CreateSeveralQuestions:
                    {
                        btnNewQuestion.Visible = true;
                        btnSaveQuestion.Text = "Salva";
                        break;
                    }
                case QuestionFormType.EditOneQuestion:
                    {
                        btnNewQuestion.Visible = false;
                        btnSaveQuestion.Text = "Salva e Esci";
                        break;
                    }
            }

            cmbQuestionType.SelectedValue = currentQuestion.IdQuestionType;

            if (currentQuestion != null)
            {
                if (currentQuestion.IdQuestion != 0)
                    currentQuestion = Commons.bl.GetQuestionById(currentQuestion.IdQuestion);
                txtIdQuestion.Text = currentQuestion.IdQuestion.ToString();
                txtQuestionText.Text = currentQuestion.Text;
                txtQuestionImage.Text = currentQuestion.QuestionImage;
                txtDuration.Text = currentQuestion.Duration.ToString();
                txtWeight.Text = currentQuestion.Weight.ToString();
                txtDifficulty.Text = currentQuestion.Difficulty.ToString();
                tagsList = Commons.bl.TagsOfAQuestion(currentQuestion.IdQuestion);
                lstTags.DataSource = tagsList;
                Commons.LastTagsChosen = tagsList;

                // show the path of the topic of the question 
                if (currentTopic != null)
                    txtTopic.Text = dbMptt.GetNodePath(currentTopic.Id);

                answersList = Commons.bl.GetAnswersOfAQuestion(currentQuestion.IdQuestion);
                dgwAnswers.DataSource = answersList;
            }
            else
            {
                currentQuestion = new Question();
            }

            txtImagesPath.Text = Commons.PathImages;
        }

        private void btnAddAnswer_Click(object sender, EventArgs e)
        {
            frmAnswer a = new frmAnswer(currentQuestion.IdQuestion);
            a.ShowDialog();
            if (a.currentAnswer.IdAnswer > 0)
            {
                Commons.bl.AddAnswerToQuestion(currentQuestion.IdQuestion, a.currentAnswer.IdAnswer);
            }

            RefreshData();

            List<Answer> answers = Commons.bl.GetAnswersOfAQuestion(currentQuestion.IdQuestion);
        }

        private void RefreshData()
        {
            answersList = Commons.bl.GetAnswersOfAQuestion(currentQuestion.IdQuestion);
            dgwAnswers.DataSource = answersList;
        }

        private void btnSaveQuestion_Click(object sender, EventArgs e)
        {
            SaveQuestion();
            UserHasChosen = false;

            if (formType == QuestionFormType.EditOneQuestion)
                this.Close();
        }

        private void txtQuestionText_TextChanged(object sender, EventArgs e)
        {
            txtQuestionText.BackColor = Color.White;
            currentQuestion.Text = txtQuestionText.Text;
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            txtWeight.BackColor = Color.White;
            try
            {
                currentQuestion.Weight = int.Parse(txtWeight.Text);
            }
            catch
            {
                currentQuestion.Weight = 0;
                txtWeight.Text = "";
            }
        }

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            txtDuration.BackColor = Color.White;
            try
            {
                currentQuestion.Duration = int.Parse(txtDuration.Text);
            }
            catch
            {
                currentQuestion.Duration = 0;
                txtDuration.Text = "";
            }
        }

        private void btnRemoveTag_Click(object sender, EventArgs e)
        {
            if (lstTags.SelectedItem == null)
            {
                MessageBox.Show("Evidenziare il tag che si vuole eliminare");
                return;
            }
            else
            {
                tagsList.Remove((Tag)lstTags.SelectedItem);
                lstTags.DataSource = null;
                lstTags.DataSource = tagsList;
                Commons.LastTagsChosen = tagsList;
            }
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            frmTag t = new frmTag(true);
            t.ShowDialog();
            if (t.haveChosen)
            {
                Commons.bl.AddTagToQuestion(currentQuestion.IdQuestion, t.currentTag.IdTag);
                t.Dispose();
                tagsList = Commons.bl.TagsOfAQuestion(currentQuestion.IdQuestion);
                lstTags.DataSource = tagsList;
                Commons.LastTagsChosen = tagsList;
            }
        }

        private void dgwAnswers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Answer a = answersList[e.RowIndex];
            frmAnswer f = new frmAnswer(a);
            f.ShowDialog();

            answersList = Commons.bl.GetAnswersOfAQuestion(currentQuestion.IdQuestion);
            dgwAnswers.DataSource = answersList;
        }

        private void cmbSchoolSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentQuestion.IdSchoolSubject = ((SchoolSubject)cmbSchoolSubject.SelectedItem).IdSchoolSubject;
            currentSubject = Commons.bl.GetSchoolSubject(currentQuestion.IdSchoolSubject);
            ////////Color bgColor;
            ////////if (currentSubject != null)
            ////////{
            ////////    int col = currentSubject.Color;
            ////////    bgColor = Color.FromArgb((col & 0xFF0000) >> 16, (col & 0xFF00) >> 8, col & 0xFF);
            ////////}
            ////////else
            ////////{
            ////////    bgColor = Color.PowderBlue;
            ////////}
            this.BackColor = CommonsWinForms.ColorFromNumber(currentSubject);
        }

        private void cmbQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentQuestion.IdQuestionType = ((QuestionType)cmbQuestionType.SelectedItem).IdQuestionType;
        }

        private void btnChooseTopic_Click(object sender, EventArgs e)
        {
            Topic chosenTopic;
            chosenTopic = currentTopic;
            List<Topic> oneItemList = new List<Topic>();
            oneItemList.Add(chosenTopic);
            frmTopics f = new frmTopics(frmTopics.TopicsFormType.HighlightTopics,
                currentClass, currentSubject, null, oneItemList);
            f.ShowDialog();
            if (f.UserHasChosen)
            {
                chosenTopic = f.ChosenTopic;
                currentTopic = chosenTopic;
                currentQuestion.IdTopic = chosenTopic.Id;
                txtTopic.Text = dbMptt.GetNodePath(currentTopic.Id);
            }
            f.Dispose();
        }

        private void btnChooseByPeriod_Click(object sender, EventArgs e)
        {
            if (currentClass == null)
            {
                MessageBox.Show("Scegliere una classe per avere gli argomenti fatti dalla classe");
                return;
            }
            Topic chosenTopic;
            frmTopicChooseByPeriod f = new frmTopicChooseByPeriod(
                frmTopicChooseByPeriod.TopicChooseFormType.ChooseTopicOnExit,
                currentClass, currentSubject);
            f.ShowDialog();
            if (f.TopicChosen != null)
            {
                chosenTopic = f.TopicChosen;
                currentTopic = chosenTopic;
                txtTopic.Text = dbMptt.GetNodePath(chosenTopic.Id);
            }
            f.Dispose();
        }

        private void txtDifficulty_TextChanged(object sender, EventArgs e)
        {
            txtDifficulty.BackColor = Color.White;
            try
            {
                currentQuestion.Difficulty = int.Parse(txtDifficulty.Text);
            }
            catch
            {
                currentQuestion.Difficulty = 0;
                txtDifficulty.Text = "";
            }
        }

        private void btnImportQuestions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Da Fare!!!!");
        }

        private void dgwAnswers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNewQuestion_Click(object sender, EventArgs e)
        {
            Color coloreCambiato = Color.Beige;

            // starts a new question "copying" the current one. 
            // by erasing its id it will be saved as new at save. 
            currentQuestion.IdQuestion = 0;
            txtIdQuestion.Text = "0";

            int dummyInt;
            int.TryParse(txtDifficulty.Text, out dummyInt);
            currentQuestion.Difficulty = dummyInt;
            int.TryParse(txtDuration.Text, out dummyInt);
            currentQuestion.Duration = dummyInt;
            double dummyDouble;
            double.TryParse(txtWeight.Text, out dummyDouble);
            currentQuestion.Weight = dummyDouble;

            currentQuestion.IdQuestionType = ((QuestionType)cmbQuestionType.SelectedItem).IdQuestionType;
            if (cmbSchoolSubject.SelectedItem != null)
                currentQuestion.IdSchoolSubject = ((SchoolSubject)cmbSchoolSubject.SelectedItem).IdSchoolSubject;

            tagsList = Commons.LastTagsChosen;

            //currentQuestion.idTopic = currentQuestion.idQuestion;
            //currentQuestion.image
            currentQuestion.Text = txtQuestionText.Text;

            txtQuestionText.BackColor = coloreCambiato;
            txtDifficulty.BackColor = coloreCambiato;
            txtDuration.BackColor = coloreCambiato;
            txtWeight.BackColor = coloreCambiato;
            txtQuestionText.BackColor = coloreCambiato;
            txtTopic.BackColor = coloreCambiato;
            txtIdQuestion.BackColor = Color.Red;
        }

        private void txtTopic_TextChanged(object sender, EventArgs e)
        {
            txtTopic.BackColor = Color.White;
        }

        private void btnSaveAndChoose_Click(object sender, EventArgs e)
        {
            SaveQuestion();
            UserHasChosen = true;

            this.Close();
        }

        private void SaveQuestion()
        {
            Color plainColor = Color.White;
            if (currentQuestion.IdQuestion == 0)
            {
                Question q = Commons.bl.CreateNewVoidQuestion();
                currentQuestion.IdQuestion = q.IdQuestion;
            }
            if (currentQuestion.IdTopic == 0 && currentTopic != null)
                currentQuestion.IdTopic = currentTopic.Id;

            Commons.bl.SaveQuestion(currentQuestion);
            txtQuestionText.BackColor = plainColor;
            txtIdQuestion.BackColor = plainColor;
            txtDifficulty.BackColor = plainColor;
            txtDuration.BackColor = plainColor;
            txtWeight.BackColor = plainColor;
            txtQuestionText.BackColor = plainColor;
            txtTopic.BackColor = plainColor;
        }
    }
}
