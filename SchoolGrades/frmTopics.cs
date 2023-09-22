using gamon.TreeMptt;
using SchoolGrades.BusinessObjects;
using SharedWinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmTopics : Form
    {
        gamon.TreeMptt.TreeMptt topicTreeMptt;

        //List<Topic> listTopicsInternal;
        List<Topic> listTopicsExternal;
        //Class currentClass; 
        SchoolSubject currentSubject;
        Class currentClass;
        Question currentQuestion;

        frmMain parentForm;

        public bool UserHasChosen { get; internal set; }
        internal Topic ChosenTopic { get => chosenTopic; }
        public TopicsFormType ShowTopicsDone { get; }
        public enum TopicsFormType
        {
            ShowAndManagement,
            HighlightTopics,
            ImportWithErase,
            ImportWithoutErase,
            SearchTopics,
            ChooseTopic
        }
        TopicsFormType formType;
        private Topic chosenTopic;
        public frmTopics(TopicsFormType FormType,
            Class Class, SchoolSubject Subject,
            Question Question = null, List<Topic> ListTopicsExternal = null,
            frmMain ParentForm = null)
        {
            InitializeComponent();

            if (ListTopicsExternal != null)
            {
                currentSubject = Subject;
                if (currentSubject == null || currentSubject.Name == null)
                    currentSubject = null;
                else
                {
                    Color bgColor = Commons.ColorFromNumber(currentSubject);
                    this.BackColor = bgColor;
                }
                currentClass = Class;
                formType = FormType;
                listTopicsExternal = ListTopicsExternal;
            }
            else
            {
                formType = FormType;
                currentClass = Class;
                currentQuestion = Question;
                currentSubject = Subject;
                if (currentSubject == null || currentSubject.Name == null)
                    currentSubject = null;
                else
                {
                    Color bgColor = Commons.ColorFromNumber(currentSubject);
                    this.BackColor = bgColor;
                }
                if (formType == TopicsFormType.HighlightTopics)
                {
                    btnSaveTree.Visible = false;
                    btnAddNodeSon.Visible = false;
                    btnAddNodeBrother.Visible = false;
                    btnChoose.Visible = false;
                    btnDelete.Visible = false;
                }
                else if (formType == TopicsFormType.ChooseTopic)
                {
                    btnSaveTree.Visible = false;
                    btnAddNodeSon.Visible = false;
                    btnAddNodeBrother.Visible = false;
                    btnChoose.Visible = true;
                    btnDelete.Visible = false;
                }
            }
            this.parentForm = ParentForm;
        }
        private void frmTopics_Load(object sender, EventArgs e)
        {
            topicTreeMptt = new TreeMptt(Commons.dl, trwTopics,
                txtTopicName, txtTopicDescription, txtTopicSearchString, null,
                null, CommonsWinForms.globalPicLed, chkSearchInDescriptions,
                chkAllWord, chkCaseInsensitive, chkFindAll, DragDropEffects.Copy);
            // list read from database 
            topicTreeMptt.AddNodesToTreeviewByBestMethod();
            switch (formType)
            {
                case TopicsFormType.HighlightTopics:
                    {
                        topicTreeMptt.ClearBackColorOnClick = false;
                        //btnChoose.Visible = true; 
                        // highlists the topics done by the current class in the current subject
                        List<Topic> listDone = Commons.bl.GetTopicsDoneFromThisTopic(currentClass,
                                ((Topic)trwTopics.Nodes[0].Tag), currentSubject);
                        int dummy = 0; bool dummy2 = false;
                        topicTreeMptt.HighlightNodesInList(trwTopics.Nodes[0],
                             listDone, ref dummy, ref dummy2);
                        if (listTopicsExternal != null && listTopicsExternal[0] != null)
                        {
                            topicTreeMptt.FindNodeById(listTopicsExternal[0].Id);
                        }
                        // hide the buttons 
                        btnSaveTree.Visible = false;
                        btnAddNodeSon.Visible = false;
                        btnAddNodeBrother.Visible = false;
                        btnChoose.Visible = false;
                        btnDelete.Visible = false;
                        btnQuestions.Visible = true;
                        // disable function keys
                        topicTreeMptt.FunctionKeysEnabled = true;
                        break;
                    }
                case TopicsFormType.ShowAndManagement:
                    {
                        btnQuestions.Visible = false;
                        btnChoose.Visible = false;
                        break;
                    }
                case TopicsFormType.ImportWithErase:
                    {
                        // Form used for import 
                        btnChoose.Visible = false;
                        btnQuestions.Visible = false;

                        topicTreeMptt.ImportToTreewiewFromList(listTopicsExternal,
                            null);
                        return;
                    }
                case TopicsFormType.SearchTopics:
                    {
                        topicTreeMptt.FindNodeById(listTopicsExternal[0].Id);
                        // just the first node
                        return;
                    }
                case TopicsFormType.ChooseTopic:
                    {
                        topicTreeMptt.ClearBackColorOnClick = false;
                        // highlists the topics done by the current class in the current subject
                        List<Topic> listDone = Commons.bl.GetTopicsDoneFromThisTopic(currentClass,
                                ((Topic)trwTopics.Nodes[0].Tag), currentSubject);
                        int dummy = 0; bool dummy2 = false;
                        topicTreeMptt.HighlightNodesInList(trwTopics.Nodes[0],
                             listDone, ref dummy, ref dummy2);
                        if (listTopicsExternal != null && listTopicsExternal[0] != null)
                        {
                            topicTreeMptt.FindNodeById(listTopicsExternal[0].Id);
                        }
                        // hide the buttons 
                        btnSaveTree.Visible = false;
                        btnAddNodeSon.Visible = false;
                        btnAddNodeBrother.Visible = false;
                        btnChoose.Visible = true;
                        btnDelete.Visible = false;
                        btnQuestions.Visible = true; // ??????????????
                        // disable function keys
                        topicTreeMptt.FunctionKeysEnabled = false;
                        break;
                    }
            }
            // list read from database 
            //topicTreeMptt.LoadTreeFromDatabase();
            UserHasChosen = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!topicTreeMptt.HasChanges)
            {
                MessageBox.Show("Nessuna modifica fatta agli argomenti");
                return;
            }
            if (formType == TopicsFormType.ImportWithErase)
                topicTreeMptt.SaveTreeFromScratch();
            else
                topicTreeMptt.SaveTreeFromTreeViewByParent();

            MessageBox.Show("Salvataggio fatto");
        }
        private void btnAddNode_Click(object sender, EventArgs e)
        {
            // add a completely new node
            System.Windows.Forms.TreeNode t = topicTreeMptt.AddNewNode("Nuovo argomento", true);
            txtTopicName.Focus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            topicTreeMptt.DeleteNodeFromButton();
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (trwTopics.SelectedNode != null)
            {
                UserHasChosen = true;
                Topic t = (Topic)(trwTopics.SelectedNode.Tag);
                chosenTopic = t;
                this.Close();
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            topicTreeMptt.FindNodes(txtTopicSearchString.Text, chkFindAll.Checked,
                chkSearchInDescriptions.Checked,
                chkAllWord.Checked, chkCaseInsensitive.Checked);
        }
        private System.Windows.Forms.TreeNode FindTopicName(int Key, System.Windows.Forms.TreeNode StartNode)
        {
            throw new NotImplementedException();
        }
        private void frmTopics_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Return || e.KeyCode == Keys.F3)
            if (e.KeyCode == Keys.F3)
                topicTreeMptt.FindNodes(txtTopicSearchString.Text, false);
            if (e.KeyCode == Keys.F5)
            {
                btnSave_Click(null, null);
            }
        }
        private void btnAddNodeBrother_Click(object sender, EventArgs e)
        {
            topicTreeMptt.AddNewNode("Nuovo argomento", false);
            // set focus to the name textBox
            txtTopicName.Focus();
        }
        private void btnFindUnderNode_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Da fare!");
            //return;

            topicTreeMptt.FindNodeUnderNode(txtTopicSearchString.Text, chkFindAll.Checked);
        }
        private void btnArgFreemind_Click(object sender, EventArgs e)
        {

        }
        private void btnQuestions_Click(object sender, EventArgs e)
        {
            if (topicTreeMptt.TreeView.SelectedNode == null)
            {
                MessageBox.Show("Scegliere un argomento per trovare le domande al di sotto di esso");
                return;
            }
            if (currentQuestion == null)
                currentQuestion = new Question();
            currentQuestion.IdTopic = ((Topic)topicTreeMptt.TreeView.SelectedNode.Tag).Id;
            frmQuestionChoose fq = new frmQuestionChoose(currentSubject,
                currentClass, null, currentQuestion, null, parentForm);
            fq.ShowDialog();
            if (fq.ChosenQuestion != null && fq.ChosenQuestion.IdQuestion != 0)
            {
                if (parentForm != null)
                    parentForm.CurrentQuestion = fq.ChosenQuestion;
                //parentForm.txtQuestion.Text = currentQuestion.Text;
                //parentForm.lstTimeInterval.Text = currentQuestion.Duration.ToString();
            }
        }
    }
}
