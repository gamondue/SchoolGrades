﻿using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using gamon.TreeMptt;
using SharedWinForms;

namespace SchoolGrades
{
    public partial class frmQuestionChoose : Form
    {
        DbAndBusiness db;
        TreeMpttDb dbMptt; 

        //SchoolSubject subj = new SchoolSubject();

        List<Tag> tagsList = new List<Tag>();

        private Question chosenQuestion = new Question();

        Topic currentTopic;
        private SchoolSubject currentSubject;
        private Class currentClass;
        private Student currentStudent;
        private Question previousQuestion;

        string keySubject, keyQuestionType;

        bool isLoading = true; 

        internal Question ChosenQuestion {get => chosenQuestion; set => chosenQuestion = value; }
        public frmMicroAssessment ParentForm { get; }
        internal frmQuestionChoose(frmMicroAssessment ParentForm,
            SchoolSubject SchoolSubject, Class Class, Student Student = null, Question Question = null)
        {
            InitializeComponent();

            DbAndBusiness db = new DbAndBusiness(Commons.PathAndFileDatabase);
            TreeMpttDb dbMptt = new TreeMpttDb(db);

            this.ParentForm = ParentForm; 
            // fills the lookup tables' combos
            cmbSchoolSubject.DisplayMember = "Name";
            cmbSchoolSubject.ValueMember = "idSchoolSubject";
            cmbSchoolSubject.DataSource = db.GetListSchoolSubjects(true);

            List<QuestionType> lq = db.GetListQuestionTypes(true);
            cmbQuestionTypes.DisplayMember = "Name";
            cmbQuestionTypes.ValueMember = "idQuestionType";
            cmbQuestionTypes.DataSource = lq;

            //currentSubject = SchoolSubject; 
            currentSubject = null; 
            currentClass = Class;
            currentStudent = Student;
            previousQuestion = Question;
            if (Question != null && Question.IdTopic != 0)
                currentTopic = db.GetTopicById(Question.IdTopic); 
        }
        private void frmQuestionChoose_Load(object sender, EventArgs e)
        {
            cmbSchoolSubject.SelectedValue = "";

            lstTags.DataSource = tagsList;

            if (currentTopic != null && previousQuestion != null)
            {
                txtTopic.Text = dbMptt.GetTopicPath(previousQuestion.IdTopic);
                txtTopicCode.Text = currentTopic.Id.ToString();
            }
            cmbStandardPeriod.SelectedIndex = 4; // !! year !! TODO set with previous value 

            isLoading = false;
            // if the query would include too many rows, don't do it 
            //if (!(currentSubject == null && (previousQuestion == null || previousQuestion.IdQuestion == 0)))
            //    updateQuestions();

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
            if (cmbStandardPeriod.Text == "")
                dateFrom = Commons.DateNull; 
            List<Question> l = db.GetFilteredQuestionsNotAsked(currentStudent, currentClass,
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
                MessageBox.Show("Scegliere una domanda nella griglia");
                return;
            }
        }
        private void btnChooseTopic_Click(object sender, EventArgs e)
        {
            Topic chosenTopic = currentTopic;
            List<Topic> oneItemList = new List<Topic>();
            oneItemList.Add(chosenTopic);
            frmTopics f = new frmTopics(frmTopics.TopicsFormType.NormalDialog,
                oneItemList, currentClass, currentSubject);
        
            f.ShowDialog();
            if (f.UserHasChosen)
            {
                chosenTopic = f.ChosenTopic;
                currentTopic = chosenTopic;
                txtTopic.Text = dbMptt.GetTopicPath(chosenTopic.Id);
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
                txtTopic.Text = dbMptt.GetTopicPath(chosenTopic.Id);
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
            List<Question> listAskedInThisLesson = db.GetFilteredQuestionsNotAsked
                (currentStudent, currentClass,currentSubject,keyQuestionType,
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
                    } else
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
        private void cmbStandardPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbStandardPeriod.SelectedIndex)
            {
                case 0:
                    { // week
                        dtpStartPeriod.Value = Commons.DateNull;
                        break;
                    }
                case 1:
                    { // week
                        dtpStartPeriod.Value = dtpEndPeriod.Value.AddDays(-7);
                        break;
                    }
                case 2:
                    {  // month
                        dtpStartPeriod.Value = dtpEndPeriod.Value.AddMonths(-1);
                        break;
                    }
                case 3:
                    {   // school year
                        // TODO calculate automatically the beginning of the school year 
                        // TODO and put in dtpStartPeriod
                        dtpStartPeriod.Value = new DateTime(2018, 09, 1);
                        break;
                    }
                case 4:
                    {   // from the beginning of the solar year. 
                        // TODO use the periods stores in SchoolPeriods table 
                        dtpStartPeriod.Value = new DateTime(2019, 01, 01);
                        break;
                    }
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

                Topic topic = db.GetTopicById(question.IdTopic);

                SchoolSubject subject = db.GetSchoolSubject(question.IdSchoolSubject);

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
        private void BtnComb_Click(object sender, EventArgs e)
        {
            if(!CommonsWinForms.CheckIfStudentChosen(currentStudent))
            {
                return; 
            }
            if (!CommonsWinForms.CheckIfSubjectChosen(currentSubject))
            {
                return;
            }

            frmKnotsToTheComb frm = new frmKnotsToTheComb(ParentForm, currentStudent.IdStudent, currentSubject,
                currentClass.SchoolYear);
            frm.Show();
            ////////if (frm.ChosenQuestion != null)
            ////////{
            ////////    ChosenQuestion = frm.ChosenQuestion;
            ////////    this.Close();
            ////////}
        }
    }
}
