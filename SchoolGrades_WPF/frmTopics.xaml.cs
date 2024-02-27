using gamon.TreeMptt;
using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for Topics.xaml
    /// </summary>
    public partial class frmTopics : Window
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
                    Color BackColor = CommonsWpf.ColorFromNumber(currentSubject.Color);
                    SolidColorBrush br = new SolidColorBrush(System.Windows.Media.Color.FromArgb(BackColor.A, BackColor.R, BackColor.G, BackColor.B));
                    this.Background = br;
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
                    Color bgColor = CommonsWpf.ColorFromNumber(currentSubject.Color);
                    SolidColorBrush br = new SolidColorBrush(bgColor);
                    this.Background = br;
                }
                if (formType == TopicsFormType.HighlightTopics)
                {
                    btnSaveTree.Visibility = Visibility.Hidden;
                    btnAddNodeSon.Visibility = Visibility.Hidden;
                    btnAddNodeBrother.Visibility = Visibility.Hidden;
                    btnChoose.Visibility = Visibility.Hidden;
                    btnDelete.Visibility = Visibility.Hidden;
                }
                else if (formType == TopicsFormType.ChooseTopic)
                {
                    btnSaveTree.Visibility = Visibility.Hidden;
                    btnAddNodeSon.Visibility = Visibility.Hidden;
                    btnAddNodeBrother.Visibility = Visibility.Hidden;
                    btnChoose.Visibility = Visibility.Visible;
                    btnDelete.Visibility = Visibility.Hidden;
                }
            }
            this.parentForm = ParentForm;
            frmTopics_Load();
        }
        private void frmTopics_Load()
        {
            topicTreeMptt = new TreeMptt(trwTopics, txtTopicName,
                txtTopicDescription, txtTopicSearchString, null,
                null, CommonsWpf.globalPicLed, chkSearchInDescriptions,
                chkVerbatimString, chkAllWord, chkCaseInsensitive,
                chkFindAll, DragDropEffects.Copy, false);
            // list read from database 
            topicTreeMptt.AddNodesToTreeviewByBestMethod();
            switch (formType)
            {
                case TopicsFormType.HighlightTopics:
                    {
                        topicTreeMptt.ClearBackColorOnClick = false;
                        //btnChoose.Visibility = Visibility.Visible;  
                        // highlights the topics done by the current class in the current subject
                        TreeViewItem firstNodeOfTree = (TreeViewItem)topicTreeMptt.TreeView.Items[0];
                        Topic firstTopicOfTree = (Topic)(firstNodeOfTree).Tag;
                        List<Topic> listDone = Commons.bl.GetTopicsDoneFromThisTopic(currentClass
                            , firstTopicOfTree, currentSubject);
                        int dummy = 0; bool dummy2 = false;
                        topicTreeMptt.HighlightNodesInList(firstNodeOfTree,
                             listDone, ref dummy, ref dummy2);
                        if (listTopicsExternal != null && listTopicsExternal[0] != null)
                        {
                            topicTreeMptt.FindNodeById(listTopicsExternal[0].Id);
                        }
                        // hide the buttons 
                        btnSaveTree.Visibility = Visibility.Hidden;
                        btnAddNodeSon.Visibility = Visibility.Hidden;
                        btnAddNodeBrother.Visibility = Visibility.Hidden;
                        btnChoose.Visibility = Visibility.Hidden;
                        btnDelete.Visibility = Visibility.Hidden;
                        btnQuestions.Visibility = Visibility.Visible;
                        // disable function keys
                        topicTreeMptt.FunctionKeysEnabled = true;
                        break;
                    }
                case TopicsFormType.ShowAndManagement:
                    {
                        btnQuestions.Visibility = Visibility.Hidden;
                        btnChoose.Visibility = Visibility.Hidden;
                        break;
                    }
                case TopicsFormType.ImportWithErase:
                    {
                        // Form used for import 
                        btnChoose.Visibility = Visibility.Hidden;
                        btnQuestions.Visibility = Visibility.Hidden;

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
                        TreeViewItem firstNodeOfTree = (TreeViewItem)topicTreeMptt.TreeView.Items[0];
                        Topic firstTopicOfTree = (Topic)(firstNodeOfTree).Tag;
                        List<Topic> listDone = Commons.bl.GetTopicsDoneFromThisTopic(currentClass,
                                firstTopicOfTree, currentSubject);
                        int dummy = 0; bool dummy2 = false;
                        topicTreeMptt.HighlightNodesInList(firstNodeOfTree,
                             listDone, ref dummy, ref dummy2);
                        if (listTopicsExternal != null && listTopicsExternal[0] != null)
                        {
                            topicTreeMptt.FindNodeById(listTopicsExternal[0].Id);
                        }
                        // hide the buttons 
                        btnSaveTree.Visibility = Visibility.Hidden;
                        btnAddNodeSon.Visibility = Visibility.Hidden;
                        btnAddNodeBrother.Visibility = Visibility.Hidden;
                        btnChoose.Visibility = Visibility.Visible;
                        btnDelete.Visibility = Visibility.Hidden;
                        btnQuestions.Visibility = Visibility.Visible;  // ??????????????
                        // disable function keys
                        topicTreeMptt.FunctionKeysEnabled = false;
                        break;
                    }
            }
            // list read from database 
            //topicTreeMptt.LoadTreeFromDatabase();
            UserHasChosen = false;
        }
        private void btnSaveTree_Click(object sender, EventArgs e)
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
            topicTreeMptt.AddNewNode("Nuovo argomento", true);
            //////txtTopicName.Focus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            topicTreeMptt.DeleteNodeFromButton();
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (trwTopics.SelectedItem != null)
            {
                UserHasChosen = true;
                Topic t = (Topic)((TreeViewItem)topicTreeMptt.TreeView.SelectedItem).Tag;
                chosenTopic = t;
                this.Close();
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            topicTreeMptt.FindNodes(txtTopicSearchString.Text);
        }
        private void frmTopics_KeyDown(object sender, KeyEventArgs e)
        {
            ////////////if (e.KeyCode == Keys.Return || e.KeyCode == Keys.F3)
            //////////if (e.KeyCode == Keys.F3)
            //////////    topicTreeMptt.FindNodes(txtTopicSearchString.Text, false, true, false, false, false);
            //////////if (e.KeyCode == Keys.F5)
            //////////{
            //////////    btnSaveTree_Click(null, null);
            //////////}
        }
        private void btnAddNodeSon_Click(object sender, RoutedEventArgs e)
        {
            // add a completely new node
            topicTreeMptt.AddNewNode("Nuovo argomento", true);
            //txtTopicName.Focus();
        }
        private void btnAddNodeBrother_Click(object sender, EventArgs e)
        {
            topicTreeMptt.AddNewNode("Nuovo argomento", false);
            // set focus to the name textBox
            //txtTopicName.Focus();
        }
        private void btnFindUnderNode_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Da fare!");
            //return;

            topicTreeMptt.FindNodeUnderNode(txtTopicSearchString.Text);
        }
        private void btnArgFreemind_Click(object sender, EventArgs e)
        {

        }
        private void btnQuestions_Click(object sender, EventArgs e)
        {
            if (topicTreeMptt.TreeView.SelectedItem == null)
            {
                MessageBox.Show("Scegliere un argomento per trovare le domande al di sotto di esso");
                return;
            }
            if (currentQuestion == null)
                currentQuestion = new Question();
            currentQuestion.IdTopic = ((Topic)((TreeViewItem)topicTreeMptt.TreeView.SelectedItem).Tag).Id;
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
