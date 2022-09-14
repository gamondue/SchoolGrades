using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using gamon.TreeMptt;
using SharedWinForms;

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
        internal frmTopics(TopicsFormType FormType, List<Topic> ListTopicsExternal, 
            Class Class, SchoolSubject Subject)
        {
            InitializeComponent();

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
        public frmTopics(TopicsFormType FormType, 
            Class CurrentClass, SchoolSubject Subject)
        {
            InitializeComponent();

            formType = FormType;
            currentClass = CurrentClass;
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
        private void frmTopics_Load(object sender, EventArgs e)
        {
            //topicTreeMptt = new TopicTreeMptt(listTopicsInternal, trwTopics,
            topicTreeMptt = new TreeMptt(Commons.dl, trwTopics,
                txtTopicName, txtDescription, txtTopicFind, null, null,
                CommonsWinForms.globalPicLed, DragDropEffects.Copy);
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
                        topicTreeMptt.HighlightTopicsInList(trwTopics.Nodes[0],
                             listDone, ref dummy, ref dummy2);
                        if (listTopicsExternal != null && listTopicsExternal[0] != null)
                        {
                            topicTreeMptt.FindItemById(listTopicsExternal[0].Id);
                        }
                        // hide the buttons 
                        btnSaveTree.Visible = false;
                        btnAddNodeSon.Visible = false;
                        btnAddNodeBrother.Visible = false;
                        btnChoose.Visible = false;
                        btnDelete.Visible = false;
                        // disable function keys
                        topicTreeMptt.FunctionKeysEnabled = false;
                        break;
                    }
                case TopicsFormType.ShowAndManagement:
                    {
                        btnChoose.Visible = false;
                        break;
                    }
                case TopicsFormType.ImportWithErase:
                    {
                        // Form used for import 
                        btnChoose.Visible = false;

                        topicTreeMptt.ImportToTreewiewFromList(listTopicsExternal,
                            null);
                        return;
                    }
                case TopicsFormType.SearchTopics:
                    {
                        topicTreeMptt.FindItemById(listTopicsExternal[0].Id);
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
                        topicTreeMptt.HighlightTopicsInList(trwTopics.Nodes[0],
                             listDone, ref dummy, ref dummy2);
                        if (listTopicsExternal != null && listTopicsExternal[0] != null)
                        {
                            topicTreeMptt.FindItemById(listTopicsExternal[0].Id);
                        }
                        // hide the buttons 
                        btnSaveTree.Visible = false;
                        btnAddNodeSon.Visible = false;
                        btnAddNodeBrother.Visible = false;
                        btnChoose.Visible = true;
                        btnDelete.Visible = false;
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
            if (formType == TopicsFormType.ImportWithErase)
                topicTreeMptt.SaveTreeFromScratch();
            else
                topicTreeMptt.SaveTreeFromTreeViewControlByParent();

            MessageBox.Show("Salvataggio fatto");
        }
        private void btnAddNode_Click(object sender, EventArgs e)
        {
            // add a completely new node
            System.Windows.Forms.TreeNode t = topicTreeMptt.AddNewNode("Nuovo argomento", true);
            //txtTopicName.Text = t.Name;
            txtTopicName.Focus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            topicTreeMptt.DeleteNodeClick();
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
            topicTreeMptt.FindItem(txtTopicFind.Text, false);
        }
        private System.Windows.Forms.TreeNode FindTopicName(int Key, System.Windows.Forms.TreeNode StartNode)
        {
            throw new NotImplementedException();
        }
        private void frmTopics_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Return || e.KeyCode == Keys.F3)
            if (e.KeyCode == Keys.F3)
                topicTreeMptt.FindItem(txtTopicFind.Text, false);
            if (e.KeyCode == Keys.F5)
            {
                btnSave_Click(null, null);
            }
        }
        private void lblExplain_Click(object sender, EventArgs e)
        {

        }
        private void trwTopics_AfterSelect(object sender, TreeViewEventArgs e)
        {

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

            topicTreeMptt.FindItemUnderNode(txtTopicFind.Text, chkFindAll.Checked);
        }

        private void btnArgFreemind_Click(object sender, EventArgs e)
        {

        }
    }
}
