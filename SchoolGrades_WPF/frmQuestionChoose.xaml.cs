using gamon.TreeMptt;
using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
//using gamon.TreeMptt;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmQuestionChoose.xaml
    /// </summary>
    public partial class frmQuestionChoose : Window
    {
        TreeMpttDb_SqLite dbMptt;

        List<Tag> tagsList = new List<Tag>();

        private Question chosenQuestion = new Question();

        Topic currentTopic;
        private SchoolSubject currentSubject;
        private Class currentClass;
        private Student currentStudent;
        private Question previousQuestion;

        string keySubject, keyQuestionType;

        bool isLoading = true;
        private SchoolPeriod currentSchoolPeriod;

        internal Question ChosenQuestion { get => chosenQuestion; set => chosenQuestion = value; }
        public frmMicroAssessment ParentForm { get; }
        internal frmQuestionChoose(SchoolSubject SchoolSubject, Class Class,
                    Student Student = null, Question Question = null,
                    frmMicroAssessment MicroAssessmentParent = null, frmMain MainParent = null)
        {
            InitializeComponent();

            //dbMptt = new TreeMpttDb_SqLite(dl);
            this.ParentForm = MicroAssessmentParent;
            // fills the lookup tables' combos
            cmbSchoolSubject.ItemsSource = "Name";
            cmbSchoolSubject.SelectedItem = "idSchoolSubject";
            cmbSchoolSubject.ItemsSource = Commons.bl.GetListSchoolSubjects(true);

            List<QuestionType> lq = Commons.bl.GetListQuestionTypes(true);
            cmbQuestionTypes.ItemsSource = "Name";
            cmbQuestionTypes.SelectedItem = "idQuestionType";
            cmbQuestionTypes.ItemsSource = lq;

            //currentSubject = SchoolSubject; 
            currentSubject = null;
            currentClass = Class;
            currentStudent = Student;
            previousQuestion = Question;
            if (Question != null && Question.IdTopic != 0)
            {
                //currentTopic = Commons.bl.GetTopicById(Question.IdTopic);
            }
            frmQuestionChoose_Loaded();
        }
        private void frmQuestionChoose_Loaded()
        {
            cmbSchoolSubject.SelectedValue = "";

            lstTags.ItemsSource = tagsList;

            List<SchoolPeriod> listPeriods = Commons.bl.GetSchoolPeriods(currentClass.SchoolYear);
            cmbSchoolPeriod.ItemsSource = listPeriods;
            // select the combo item of the partial period of the DateTime.Now
            foreach (SchoolPeriod sp in listPeriods)
            {
                if (sp.DateFinish > DateTime.Now && sp.DateStart < DateTime.Now
                     && sp.IdSchoolPeriodType == "P")
                {
                    cmbSchoolPeriod.SelectedItem = sp;
                }
            }

            isLoading = false;
            // if the query would include too many rows, don't do it 
            //if (!(currentSubject == null && (previousQuestion == null || previousQuestion.IdQuestion == 0)))
            //    updateQuestions();

            if (currentTopic != null && previousQuestion != null)
            {
                //     txtTopic.Text = dbMptt.GetNodePath(previousQuestion.IdTopic);
                txtTopicCode.Text = currentTopic.Id.ToString();
                updateQuestions();
            }
            //  LessonTimer.Interval = 1000;
            if (Commons.IsTimerLessonActive) { }
            //     LessonTimer.Start();
        }
        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            Question q = new Question();
            if (cmbQuestionTypes.SelectedItem != null)
            {
                q.IdQuestionType = ((QuestionType)cmbQuestionTypes.SelectedItem).IdQuestionType;
            }
            frmQuestion domanda = new frmQuestion(frmQuestion.QuestionFormType.CreateSeveralQuestions,
                 q, currentSubject, currentClass, currentTopic);
            domanda.ShowDialog();

            if (domanda.UserHasChosen)
            {
                ChosenQuestion = domanda.currentQuestion;
                this.Close();
            }
            updateQuestions();
        }
        private void btnAddTag_Click(object sender, RoutedEventArgs e)
        {
            //////////frmTag t = new frmTag(true);
            //////////t.ShowDialog();
            //////////if (t.haveChosen)
            //////////{
            //////////    tagsList.Add(t.currentTag);
            //////////    lstTags.ItemsSource = null;
            //////////    lstTags.ItemsSource = tagsList;
            //////////    Commons.LastTagsChosen = tagsList;
            //////////}
            //////////updateQuestions();
        }
        private void btnCopyQuestion_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Function not implemented yet");
        }
        private void updateQuestions()
        {
            if (isLoading)
                return;
            if (cmbSchoolSubject.SelectedItem == null)
                keySubject = "";
            else
                keySubject = ((SchoolSubject)cmbSchoolSubject.SelectedItem).IdSchoolSubject;

            if (cmbQuestionTypes.SelectedItem == null)
                keyQuestionType = "";
            else
                keyQuestionType = ((QuestionType)cmbQuestionTypes.SelectedItem).IdQuestionType;

            LoadDatagrids(keySubject, keyQuestionType);
        }
        private void btnRemoveTag_Click(object sender, RoutedEventArgs e)
        {
            //////////if (lstTags.SelectedItem == null)
            //////////{
            //////////    MessageBox.Show("Evidenziare il tag che si vuole eliminare");
            //////////    return;
            //////////}
            //////////else
            //////////{
            //////////    tagsList.Remove((Tag)lstTags.SelectedItem);
            //////////    lstTags.ItemsSource = null;
            //////////    lstTags.ItemsSource = tagsList;
            //////////    Commons.LastTagsChosen = tagsList;
            //////////}
            //////////updateQuestions();
        }
        private void cmbSchoolSubject_SelectionChanged(object sender, RoutedEventArgs e)
        {
            currentSubject = (SchoolSubject)cmbSchoolSubject.SelectedItem; // new SchoolSubject();
            Color BackColor = CommonsWpf.ColorFromNumber(currentSubject.Color);
            this.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(BackColor.A, BackColor.R, BackColor.G, BackColor.B));
            updateQuestions();
        }
        private void cmbQuestionTypes_SelectionChanged(object sender, RoutedEventArgs e)
        {
            updateQuestions();
        }
        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            if (dgwQuestions.SelectedItems.Count > 0)
            {
                List<Question> ls = (List<Question>)(dgwQuestions.ItemsSource);
                //////////////////ChosenQuestion = ls[dgwQuestions.SelectedItems[0].Index];

                this.Close();
            }
            else
            {
                MessageBox.Show("Scegliere una domanda nella griglia");
                return;
            }
        }
        private void btnChooseTopic_Click(object sender, RoutedEventArgs e)
        {
            Topic chosenTopic = currentTopic;
            List<Topic> oneItemList = new List<Topic>();
            oneItemList.Add(chosenTopic);
            frmTopics f = new frmTopics(frmTopics.TopicsFormType.ChooseTopic,
               currentClass, currentSubject, null, oneItemList);

            f.ShowDialog();
            if (f.UserHasChosen)
            {
                chosenTopic = f.ChosenTopic;
                currentTopic = chosenTopic;
                txtTopic.Text = dbMptt.GetNodePath(chosenTopic.Id);
                txtTopicCode.Text = chosenTopic.Id.ToString();
                updateQuestions();
            }
            //f.Dispose();
        }
        private void btnDontUseTopic_Click(object sender, RoutedEventArgs e)
        {
            currentTopic = null;
            txtTopic.Text = "";
            txtTopicCode.Text = "";

            updateQuestions();
        }
        private void btnChooseByPeriod_Click(object sender, RoutedEventArgs e)
        {
            if (currentClass == null)
            {
                MessageBox.Show("Scegliere la classe per vedere gli argomenti che ha fatto");
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
                txtTopicCode.Text = chosenTopic.Id.ToString();
                updateQuestions();
            }
            //f.Dispose();
        }
        private void btnRandomQuestion_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            //////////if (currentStudent == null)
            //////////{
            //////////    MessageBox.Show("Studente non definito\r\n" + 
            //////////        "Non è possibile scegliere fra le domande fatte ad uno studente");
            //////////    return; 
            //////////}
            DateTime dateFrom = dtpStartPeriod.SelectedDate.Value;
            DateTime dateTo = dtpEndPeriod.SelectedDate.Value;
            List<Question> listAskedInThisLesson = Commons.bl.GetFilteredQuestionsNotAskedToStudent
                (currentStudent, currentClass, currentSubject, keyQuestionType,
                tagsList, currentTopic,
                (bool)rdbManyTopics.IsChecked, (bool)rdbAnd.IsChecked,
                txtSearchText.Text,
                dateFrom, dateTo);
            // !!!! verify if it really works !!!! 
            if (listAskedInThisLesson.Count > 0)
            {
                bool found;
                // keeps drawing until a question not already done comes out 
                // gives up after a number of attempts equal to the number of questions
                // available 
                int attempts = 0;
                do
                {
                    int indexRandom = r.Next(listAskedInThisLesson.Count);
                    ChosenQuestion = listAskedInThisLesson[indexRandom];

                    if (Commons.QuestionsAlreadyMadeThisTime != null)
                    {
                        found = false;
                        foreach (Question q in Commons.QuestionsAlreadyMadeThisTime)
                            if (q.IdQuestion == chosenQuestion.IdQuestion)
                            {
                                found = true;
                                break;
                            }
                    }
                    else
                    {
                        found = false;
                    }
                    attempts++;
                } while (found && attempts < listAskedInThisLesson.Count);
            }
            else
            {
                Console.Beep();
            }
            this.Close();
        }
        private void rdbOr_Click(object sender, RoutedEventArgs e)
        {
            updateQuestions();
        }
        //private void rdbOr_CheckedChanged(object sender, EventArgs e)
        //{
        //    updateQuestions();
        //}
        private void rdbOneTopic_Click(object sender, RoutedEventArgs e)
        {
            updateQuestions();
        }
        //private void rdbOneTopic_CheckedChanged(object sender, EventArgs e)
        //{
        //    updateQuestions();
        //}
        private void LoadDatagrids(string keySubject, string keyQuestionType)
        {
            //dgwQuestions.ItemsSource = db.GetFilteredQuestions(tagsList, keySubject,
            //    keyQuestionType, currentTopic, rdbManyTopics.IsChecked, rdbAnd.IsChecked);
            DateTime dateFrom = dtpStartPeriod.SelectedDate.Value;
            DateTime dateTo = dtpEndPeriod.SelectedDate.Value;
            if (cmbSchoolPeriod.Text == "")
                dateFrom = Commons.DateNull;
            if (currentSubject == null)
                currentSubject = new SchoolSubject();
            if (currentTopic == null)
                currentTopic = new Topic();
            List<Question> l = Commons.bl.GetFilteredQuestionsNotAskedToStudent(currentStudent, currentClass,
                currentSubject, keyQuestionType, tagsList, currentTopic,
                (bool)rdbManyTopics.IsChecked, (bool)rdbAnd.IsChecked, txtSearchText.Text,
                dateFrom, dateTo);
            dgwQuestions.ItemsSource = l;
        }
        private void cmbSchoolPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSchoolPeriod = (SchoolPeriod)(cmbSchoolPeriod.SelectedValue);
            if (currentSchoolPeriod.IdSchoolPeriodType != "N")
            {
                dtpStartPeriod.SelectedDate = (DateTime)currentSchoolPeriod.DateStart;
                dtpEndPeriod.SelectedDate = (DateTime)currentSchoolPeriod.DateFinish;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "month")
            {
                dtpStartPeriod.SelectedDate = DateTime.Now.AddMonths(-1);
                dtpEndPeriod.SelectedDate = DateTime.Now;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "week")
            {
                dtpStartPeriod.SelectedDate = DateTime.Now.AddDays(-7);
                dtpEndPeriod.SelectedDate = DateTime.Now;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "year")
            {
                dtpStartPeriod.SelectedDate = DateTime.Now.AddYears(-1);
                dtpEndPeriod.SelectedDate = DateTime.Now;
            }
            updateQuestions();
        }
        //private void rdbOr_CheckedChanged(object sender, EventArgs e)
        //{
        //    updateQuestions();
        //}
        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchText.Text.Length > 3)
                updateQuestions();
        }
        //private void dgwQuestions_CellClick(object sender, RoutedEvent e)
        //{
        //                DataGrid grid = (DataGrid)sender;
        //int RowIndex = grid.SelectedIndex;
        //    if (RowIndex > -1)
        //    {
        //        dgwQuestions.Items[RowIndex].Selected = true;
        //    }
        //}
        private void dgwQuestions_CellDoubleClick(object sender, RoutedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                List<Question> ls = (List<Question>)(dgwQuestions.ItemsSource);
                Question question = ls[RowIndex];

                Topic topic = Commons.bl.GetTopicById(question.IdTopic);

                SchoolSubject subject = Commons.bl.GetSchoolSubject(question.IdSchoolSubject);

                frmQuestion frm = new frmQuestion(
                    frmQuestion.QuestionFormType.EditOneQuestion,
                    question, subject, currentClass, topic);
                frm.ShowDialog();

                frmQuestionChoose_Loaded();
            }
        }
        private void LessonTimer_Tick(object sender, EventArgs e)
        {
            //// TODO !!!! avoid this interrupt when the timer is disabled in main form !!!!
            //LblLessonTime.Background = ((frmMain)Application.OpenForms[0]).CurrentLessonTimeColor;
        }
        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    updateQuestions();
        //}
        private void btnQuestionsDone_Click(object sender, EventArgs e)
        {
            //dgwQuestions.ItemsSource = db.GetFilteredQuestions(tagsList, keySubject,
            //    keyQuestionType, currentTopic, rdbManyTopics.IsChecked, rdbAnd.IsChecked);
            DateTime dateFrom = dtpStartPeriod.SelectedDate.Value;
            DateTime dateTo = dtpEndPeriod.SelectedDate.Value;
            if (cmbSchoolPeriod.Text == "")
                dateFrom = Commons.DateNull;
            if (currentSubject == null)
                currentSubject = new SchoolSubject();
            if (currentTopic == null)
                currentTopic = new Topic();
            List<Question> l = Commons.bl.GetFilteredQuestionsAskedToClass(currentClass,
                currentSubject, keyQuestionType, tagsList, currentTopic,
                (bool)rdbManyTopics.IsChecked, (bool)rdbAnd.IsChecked, txtSearchText.Text,
                dateFrom, dateTo);
            dgwQuestions.ItemsSource = l;
        }
        private void btnKnotsToTheComb_Click(object sender, EventArgs e)
        {
            if (!CommonsWpf.CheckIfStudentChosen(currentStudent))
            {
                return;
            }
            if (!CommonsWpf.CheckIfSubjectChosen(currentSubject))
            {
                return;
            }

            frmKnotsToTheComb frm = new frmKnotsToTheComb(ParentForm, currentStudent.IdStudent, currentSubject,
                currentClass.SchoolYear);
            frm.ShowDialog();
            if (frm.ChosenQuestion != null)
            {
                chosenQuestion = frm.ChosenQuestion;
                this.Close();
            }
        }
    }
}
