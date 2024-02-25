using gamon.TreeMptt;
using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmQuestion.xaml
    /// </summary>
    public partial class frmQuestion : Window
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
            TreeMpttDb_SqlServer dbMptt = new TreeMpttDb_SqLite();
#else
            TreeMpttDb_SqLite dbMptt = new TreeMpttDb_SqLite();
#endif

            // fills the lookup tables' combos
            List<QuestionType> listQuestions = Commons.bl.GetListQuestionTypes(true);
            cmbQuestionType.DisplayMemberPath = "Name";
            cmbQuestionType.SelectedValuePath = "idQuestionType";
            cmbQuestionType.ItemsSource = listQuestions;

            List<SchoolSubject> listSubjects = Commons.bl.GetListSchoolSubjects(true);
            cmbSchoolSubject.DisplayMemberPath = "Name";
            cmbSchoolSubject.SelectedValuePath = "idSchoolSubject";
            cmbSchoolSubject.ItemsSource = listSubjects;

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
                        btnNewQuestion.Visibility = Visibility.Visible;
                        btnSaveQuestion.Content = "Salva";
                        break;
                    }
                case QuestionFormType.EditOneQuestion:
                    {
                        btnNewQuestion.Visibility = Visibility.Hidden;
                        btnSaveQuestion.Content = "Salva e Esci";
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
                lstTags.ItemsSource = tagsList;
                Commons.LastTagsChosen = tagsList;

                // show the path of the topic of the question 
                if (currentTopic != null)
                    txtTopic.Text = dbMptt.GetNodePath(currentTopic.Id);

                answersList = Commons.bl.GetAnswersOfAQuestion(currentQuestion.IdQuestion);
                dgwAnswers.ItemsSource = answersList;
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
            dgwAnswers.ItemsSource = answersList;
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
            txtQuestionText.Background = Brushes.White;
            currentQuestion.Text = txtQuestionText.Text;
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            txtWeight.Background = Brushes.White;
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
            txtDuration.Background = Brushes.White;
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
                lstTags.ItemsSource = null;
                lstTags.ItemsSource = tagsList;
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
                //t.Dispose();
                tagsList = Commons.bl.TagsOfAQuestion(currentQuestion.IdQuestion);
                lstTags.ItemsSource = tagsList;
                Commons.LastTagsChosen = tagsList;
            }
        }

        private void dgwAnswers_CellDoubleClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            Answer a = answersList[RowIndex];
            frmAnswer f = new frmAnswer(a);
            f.ShowDialog();

            answersList = Commons.bl.GetAnswersOfAQuestion(currentQuestion.IdQuestion);
            dgwAnswers.ItemsSource = answersList;
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
            this.Background = CommonsWpf.BrushFromColor(CommonsWpf.ColorFromNumber(currentSubject.Color));
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
            //f.Dispose();
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
            //f.Dispose();
        }

        private void txtDifficulty_TextChanged(object sender, EventArgs e)
        {
            txtDifficulty.Background = Brushes.White;
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

        private void dgwAnswers_CellContentClick(object sender, RoutedEvent e)
        {

        }

        private void btnNewQuestion_Click(object sender, EventArgs e)
        {
            SolidColorBrush coloreCambiato = Brushes.Beige;

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

            txtQuestionText.Background = coloreCambiato;
            txtDifficulty.Background = coloreCambiato;
            txtDuration.Background = coloreCambiato;
            txtWeight.Background = coloreCambiato;
            txtQuestionText.Background = coloreCambiato;
            txtTopic.Background = coloreCambiato;
            txtIdQuestion.Background = Brushes.Red;
        }

        private void txtTopic_TextChanged(object sender, EventArgs e)
        {
            txtTopic.Background = Brushes.White;
        }

        private void btnSaveAndChoose_Click(object sender, EventArgs e)
        {
            SaveQuestion();
            UserHasChosen = true;

            this.Close();
        }

        private void SaveQuestion()
        {
            SolidColorBrush plainColor = Brushes.White;
            if (currentQuestion.IdQuestion == 0)
            {
                Question q = Commons.bl.CreateNewVoidQuestion();
                currentQuestion.IdQuestion = q.IdQuestion;
            }
            if (currentQuestion.IdTopic == 0 && currentTopic != null)
                currentQuestion.IdTopic = currentTopic.Id;

            Commons.bl.SaveQuestion(currentQuestion);
            txtQuestionText.Background = plainColor;
            txtIdQuestion.Background = plainColor;
            txtDifficulty.Background = plainColor;
            txtDuration.Background = plainColor;
            txtWeight.Background = plainColor;
            txtQuestionText.Background = plainColor;
            txtTopic.Background = plainColor;
        }
    }
}