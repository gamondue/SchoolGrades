using gamon.TreeMptt;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmQuestionChoose : Form
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

#if SQL_SERVER
            TreeMpttDb_SqlServer dbMptt = new();
#else
            TreeMpttDb_SqLite dbMptt = new TreeMpttDb_SqLite();
#endif

            this.ParentForm = MicroAssessmentParent;
            // fills the lookup tables' combos
            cmbSchoolSubject.DisplayMember = "Name";
            cmbSchoolSubject.ValueMember = "idSchoolSubject";
            cmbSchoolSubject.DataSource = Commons.bl.GetListSchoolSubjects(true);

            List<QuestionType> lq = Commons.bl.GetListQuestionTypes(true);
            cmbQuestionTypes.DisplayMember = "Name";
            cmbQuestionTypes.ValueMember = "idQuestionType";
            cmbQuestionTypes.DataSource = lq;

            //currentSubject = SchoolSubject; 
            currentSubject = null;
            currentClass = Class;
            currentStudent = Student;
            previousQuestion = Question;
            if (Question != null && Question.IdTopic != 0)
            {
                currentTopic = Commons.bl.GetTopicById(Question.IdTopic);
            }
        }
        private void frmQuestionChoose_Load(object sender, EventArgs e)
        {
            cmbSchoolSubject.SelectedValue = "";

            lstTags.DataSource = tagsList;

            List<SchoolPeriod> listPeriods = Commons.bl.GetSchoolPeriods(currentClass.SchoolYear);
            cmbSchoolPeriod.DataSource = listPeriods;
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
                txtTopic.Text = dbMptt.GetNodePath(previousQuestion.IdTopic);
                txtTopicCode.Text = currentTopic.Id.ToString();
                updateQuestions();
            }
            LessonTimer.Interval = 1000;
            if (Commons.IsTimerLessonActive)
                LessonTimer.Start();
        }
        private void btnAddQuestion_Click(object sender, EventArgs e)
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
        private void btnCopyQuestion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function not implemented yet");
        }
        private void btnAddTag_Click(object sender, EventArgs e)
        {
            frmTag t = new frmTag(true);
            t.ShowDialog();
            if (t.haveChosen)
            {
                tagsList.Add(t.currentTag);
                lstTags.DataSource = null;
                lstTags.DataSource = tagsList;
                Commons.LastTagsChosen = tagsList;
            }
            updateQuestions();
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
        private void LoadDatagrids(string keySubject, string keyQuestionType)
        {
            //dgwQuestions.DataSource = db.GetFilteredQuestions(tagsList, keySubject,
            //    keyQuestionType, currentTopic, rdbManyTopics.Checked, rdbAnd.Checked);
            DateTime dateFrom = dtpStartPeriod.Value;
            DateTime dateTo = dtpEndPeriod.Value;
            if (cmbSchoolPeriod.Text == "")
                dateFrom = Commons.DateNull;
            if (currentSubject == null)
                currentSubject = new SchoolSubject();
            if (currentTopic == null)
                currentTopic = new Topic();
            List<Question> l = Commons.bl.GetFilteredQuestionsNotAskedToStudent(currentStudent, currentClass,
                currentSubject, keyQuestionType, tagsList, currentTopic,
                rdbManyTopics.Checked, rdbAnd.Checked, txtSearchText.Text,
                dateFrom, dateTo);
            dgwQuestions.DataSource = l;
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
            updateQuestions();
        }
        private void cmbSchoolSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSubject = (SchoolSubject)cmbSchoolSubject.SelectedItem; // new SchoolSubject();

            this.BackColor = CommonsWinForms.ColorFromNumber(currentSubject);

            updateQuestions();
        }
        private void cmbQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateQuestions();
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (dgwQuestions.SelectedRows.Count > 0)
            {
                List<Question> ls = (List<Question>)(dgwQuestions.DataSource);
                ChosenQuestion = ls[dgwQuestions.SelectedRows[0].Index];

                this.Close();
            }
            else
            {
                MessageBox.Show("Scegliere una domanda nella griglia");
                return;
            }
        }
        private void btnChooseTopic_Click(object sender, EventArgs e)
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
            f.Dispose();
        }
        private void btnDontUseTopic_Click(object sender, EventArgs e)
        {
            currentTopic = null;
            txtTopic.Text = "";
            txtTopicCode.Text = "";

            updateQuestions();
        }
        private void btnChooseByPeriod_Click(object sender, EventArgs e)
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
            f.Dispose();
        }
        private void btnRandomQuestion_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            //if (currentStudent == null)
            //{
            //    MessageBox.Show("Studente non definito\r\n" + 
            //        "Non è possibile scegliere fra le domande fatte ad uno studente");
            //    return; 
            //}
            DateTime dateFrom = dtpStartPeriod.Value;
            DateTime dateTo = dtpEndPeriod.Value;
            List<Question> listAskedInThisLesson = Commons.bl.GetFilteredQuestionsNotAskedToStudent
                (currentStudent, currentClass, currentSubject, keyQuestionType,
                tagsList, currentTopic,
                rdbManyTopics.Checked, rdbAnd.Checked,
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
        private void rdbOr_CheckedChanged(object sender, EventArgs e)
        {
            updateQuestions();
        }
        private void rdbOneTopic_CheckedChanged(object sender, EventArgs e)
        {
            updateQuestions();
        }
        private void cmbSchoolPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSchoolPeriod = (SchoolPeriod)(cmbSchoolPeriod.SelectedValue);
            if (currentSchoolPeriod.IdSchoolPeriodType != "N")
            {
                dtpStartPeriod.Value = (DateTime)currentSchoolPeriod.DateStart;
                dtpEndPeriod.Value = (DateTime)currentSchoolPeriod.DateFinish;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "month")
            {
                dtpStartPeriod.Value = DateTime.Now.AddMonths(-1);
                dtpEndPeriod.Value = DateTime.Now;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "week")
            {
                dtpStartPeriod.Value = DateTime.Now.AddDays(-7);
                dtpEndPeriod.Value = DateTime.Now;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "year")
            {
                dtpStartPeriod.Value = DateTime.Now.AddYears(-1);
                dtpEndPeriod.Value = DateTime.Now;
            }
            updateQuestions();
        }
        private void dtpEndPeriod_ValueChanged(object sender, EventArgs e)
        {

        }
        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchText.Text.Length > 3)
                updateQuestions();
        }
        private void dgwQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwQuestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwQuestions.Rows[e.RowIndex].Selected = true;
            }
        }
        private void dgwQuestions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                List<Question> ls = (List<Question>)(dgwQuestions.DataSource);
                Question question = ls[e.RowIndex];

                Topic topic = Commons.bl.GetTopicById(question.IdTopic);

                SchoolSubject subject = Commons.bl.GetSchoolSubject(question.IdSchoolSubject);

                frmQuestion frm = new frmQuestion(
                    frmQuestion.QuestionFormType.EditOneQuestion,
                    question, subject, currentClass, topic);
                frm.ShowDialog();

                frmQuestionChoose_Load(null, null);
            }
        }
        private void LessonTimer_Tick(object sender, EventArgs e)
        {
            // TODO !!!! avoid this interrupt when the timer is disabled in main form !!!!
            LblLessonTime.BackColor = ((frmMain)Application.OpenForms[0]).CurrentLessonTimeColor;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            updateQuestions();
        }

        private void btnQuestionsDone_Click(object sender, EventArgs e)
        {
            //dgwQuestions.DataSource = db.GetFilteredQuestions(tagsList, keySubject,
            //    keyQuestionType, currentTopic, rdbManyTopics.Checked, rdbAnd.Checked);
            DateTime dateFrom = dtpStartPeriod.Value;
            DateTime dateTo = dtpEndPeriod.Value;
            if (cmbSchoolPeriod.Text == "")
                dateFrom = Commons.DateNull;
            if (currentSubject == null)
                currentSubject = new SchoolSubject();
            if (currentTopic == null)
                currentTopic = new Topic();
            List<Question> l = Commons.bl.GetFilteredQuestionsAskedToClass(currentClass,
                currentSubject, keyQuestionType, tagsList, currentTopic,
                rdbManyTopics.Checked, rdbAnd.Checked, txtSearchText.Text,
                dateFrom, dateTo);
            dgwQuestions.DataSource = l;
        }
        private void btnKnotsToTheComb_Click(object sender, EventArgs e)
        {
            if (!CommonsWinForms.CheckIfStudentChosen(currentStudent))
            {
                return;
            }
            if (!CommonsWinForms.CheckIfSubjectChosen(currentSubject))
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
