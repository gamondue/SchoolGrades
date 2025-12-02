using gamon.TreeMptt;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using SchoolGrades.Localization;

namespace SchoolGrades
{
    public partial class frmQuestionChoose : Form
    {
        TreeMpttDb dbMptt;

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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
     internal Question ChosenQuestion { get => chosenQuestion; set => chosenQuestion = value; }

   [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public frmMicroAssessment ParentForm { get; }

  internal frmQuestionChoose(SchoolSubject SchoolSubject, Class Class,
            Student Student = null, Question Question = null,
            frmMicroAssessment MicroAssessmentParent = null, frmMain MainParent = null)
        {
            InitializeComponent();
            LocalizeForm();
#if SQL_SERVER
            dbMptt = new TreeMpttDb_SqlServer("Dummy. To be detarmined");
#else
            dbMptt = new TreeMpttDb_SqLite(Commons.PathAndFileDatabase);
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
            ////////// if no period is selected then we select the "month" period
            ////////if (cmbSchoolPeriod.SelectedItem == null)
            ////////    cmbSchoolPeriod.SelectedItem = listPeriods["month"];
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
            MessageBox.Show(Loc.Get("QuestionChoose_FunctionNotImplemented"));
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
                MessageBox.Show(Loc.Get("QuestionChoose_SelectTag"));
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

            this.BackColor = Commons.ColorFromNumber(currentSubject);

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
                MessageBox.Show(Loc.Get("QuestionChoose_SelectQuestion"));
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
                MessageBox.Show(Loc.Get("QuestionChoose_SelectClass"));
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
            if (!Commons.CheckIfStudentChosen(currentStudent))
            {
                return;
            }
            if (!Commons.CheckIfSubjectChosen(currentSubject))
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
        private void LocalizeForm()
        {
            try
            {
                // Form title
                this.Text = Loc.Get("QuestionChoose_Title");

                // Labels
                lblSchoolSubject.Text = Loc.Get("QuestionChoose_Subject");
                lblQuestionType.Text = Loc.Get("QuestionChoose_QuestionType");
                lblTags.Text = Loc.Get("QuestionChoose_Tags");
                lblSearchText.Text = Loc.Get("QuestionChoose_SearchText");
                lblWeightInTest.Text = Loc.Get("QuestionChoose_WeightInTest");
                lblStart.Text = Loc.Get("QuestionChoose_DateFrom");
                lblEnd.Text = Loc.Get("QuestionChoose_DateTo");

                // GroupBoxes
                grpTopic.Text = Loc.Get("QuestionChoose_TopicGroup");
                grpQuestions.Text = Loc.Get("QuestionChoose_QuestionsGroup");
                grpPeriodOfQuestionsTopics.Text = Loc.Get("QuestionChoose_PeriodGroup");

                // Buttons
                btnAddQuestion.Text = Loc.Get("QuestionChoose_AddQuestion");
                btnCopyQuestion.Text = Loc.Get("QuestionChoose_CopyQuestion");
                btnAddTag.Text = Loc.Get("QuestionChoose_AddTag");
                btnRemoveTag.Text = Loc.Get("QuestionChoose_RemoveTag");
                btnChoose.Text = Loc.Get("QuestionChoose_Choose");
                btnChooseTopic.Text = Loc.Get("QuestionChoose_ChooseTopic");
                btnDontUseTopic.Text = Loc.Get("QuestionChoose_DontUseTopic");
                btnChooseByPeriod.Text = Loc.Get("QuestionChoose_ChooseByPeriod");
                btnRandomQuestion.Text = Loc.Get("QuestionChoose_RandomQuestion");
                btnQuestionsDone.Text = Loc.Get("QuestionChoose_QuestionsDone");
                btnKnotsToTheComb.Text = Loc.Get("QuestionChoose_KnotsToTheComb");
                btnSearch.Text = Loc.Get("QuestionChoose_Search");

                // RadioButtons
                rdbOneTopic.Text = Loc.Get("QuestionChoose_OneTopic");
                rdbManyTopics.Text = Loc.Get("QuestionChoose_ManyTopics");
                rdbAnd.Text = Loc.Get("QuestionChoose_And");
                rdbOr.Text = Loc.Get("QuestionChoose_Or");

                // Tooltips - Buttons
                toolTip1.SetToolTip(btnAddQuestion, Loc.Get("QuestionChoose_Tooltip_AddQuestion"));
                toolTip1.SetToolTip(btnCopyQuestion, Loc.Get("QuestionChoose_Tooltip_CopyQuestion"));
                toolTip1.SetToolTip(btnAddTag, Loc.Get("QuestionChoose_Tooltip_AddTag"));
                toolTip1.SetToolTip(btnRemoveTag, Loc.Get("QuestionChoose_Tooltip_RemoveTag"));
                toolTip1.SetToolTip(btnChoose, Loc.Get("QuestionChoose_Tooltip_Choose"));
                toolTip1.SetToolTip(btnChooseTopic, Loc.Get("QuestionChoose_Tooltip_ChooseTopic"));
                toolTip1.SetToolTip(btnDontUseTopic, Loc.Get("QuestionChoose_Tooltip_DontUseTopic"));
                toolTip1.SetToolTip(btnChooseByPeriod, Loc.Get("QuestionChoose_Tooltip_ChooseByPeriod"));
                toolTip1.SetToolTip(btnRandomQuestion, Loc.Get("QuestionChoose_Tooltip_RandomQuestion"));
                toolTip1.SetToolTip(btnQuestionsDone, Loc.Get("QuestionChoose_Tooltip_QuestionsDone"));
                toolTip1.SetToolTip(btnKnotsToTheComb, Loc.Get("QuestionChoose_Tooltip_KnotsToTheComb"));
                toolTip1.SetToolTip(btnSearch, Loc.Get("QuestionChoose_Tooltip_Search"));

                // Tooltips - Altri controlli
                toolTip1.SetToolTip(cmbSchoolSubject, Loc.Get("QuestionChoose_Tooltip_Subject"));
                toolTip1.SetToolTip(cmbQuestionTypes, Loc.Get("QuestionChoose_Tooltip_QuestionType"));
                toolTip1.SetToolTip(txtSearchText, Loc.Get("QuestionChoose_Tooltip_SearchText"));
                toolTip1.SetToolTip(LblLessonTime, Loc.Get("QuestionChoose_Tooltip_LessonTime"));

                // Tooltips - RadioButtons
                toolTip1.SetToolTip(rdbOneTopic, Loc.Get("QuestionChoose_Tooltip_OneTopic"));
                toolTip1.SetToolTip(rdbManyTopics, Loc.Get("QuestionChoose_Tooltip_ManyTopics"));
                toolTip1.SetToolTip(rdbAnd, Loc.Get("QuestionChoose_Tooltip_And"));
                toolTip1.SetToolTip(rdbOr, Loc.Get("QuestionChoose_Tooltip_Or"));
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"frmQuestionChoose.LocalizeForm: {ex.Message}");
            }
        }
    }
}
