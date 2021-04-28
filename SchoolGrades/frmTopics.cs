using SchoolGrades.DbClasses;
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
        DbAndBusiness db;

        gamon.TreeMptt.TreeMptt topicTreeMptt;

        List<Topic> listTopicsInternal;
        List<Topic> listTopicsExternal;

        //Class currentClass; 
        SchoolSubject currentSubject;
        Class currentClass; 

        public bool UserHasChosen { get; internal set; }
        internal Topic ChosenTopic { get => chosenTopic; }

        public enum TopicsFormType
        {
            NormalManagement,
            NormalDialog,
            ImportWithErase,
            ImportWithoutErase,
            SearchForm,
        }
        TopicsFormType formType;
        private Topic chosenTopic;

        internal frmTopics(TopicsFormType FormType, List<Topic> ListTopicsExternal, 
            Class Class, SchoolSubject Subject)
        {
            InitializeComponent();

            db = new DbAndBusiness(Commons.PathAndFileDatabase);

            currentSubject = Subject;
            currentClass = Class; 
            formType = FormType;
            listTopicsExternal = ListTopicsExternal;
        }

        private void frmTopic_Load(object sender, EventArgs e)
        {
            //topicTreeMptt = new TopicTreeMptt(listTopicsInternal, trwTopics,
            topicTreeMptt = new TreeMptt(db, trwTopics,
                txtTopicName, txtDescription, txtFind, null, null,
                CommonsWinForms.globalPicLed, DragDropEffects.Copy);

            // list read from database 
            topicTreeMptt.AddNodesToTreeviewByBestMethod();

            switch (formType)
            {
                case TopicsFormType.NormalDialog:
                    {
                        btnChoose.Visible = true; 
                        // highlists the topics done by the current class in the current subject
                        List<Topic> listDone = db.GetTopicsDoneFromThisTopic(currentClass, 
                                ((Topic)trwTopics.Nodes[0].Tag), currentSubject);
                        int dummy = 0; bool dummy2 = false;
                        topicTreeMptt.HighlightTopicsInList(trwTopics.Nodes[0],
                             listDone, ref dummy, ref dummy2);
                        if (listTopicsExternal != null && listTopicsExternal[0] != null)
                        {
                            topicTreeMptt.FindItemById(listTopicsExternal[0].Id);
                        }
                        break;
                    }
                case TopicsFormType.NormalManagement:
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
                case TopicsFormType.SearchForm:
                    {
                        topicTreeMptt.FindItemById(listTopicsExternal[0].Id);
                        // just the first node

                        return;
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

            MessageBox.Show("Salvataggio in due passaggi: primo salvataggio fatto\r\n(il secondo procede in background e si può interrompere chiudendo il programma)");
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            // add a completely new node
            System.Windows.Forms.TreeNode t = topicTreeMptt.AddNewNode("Nuovo argomento");
            //txtTopicName.Text = t.Name;
            txtTopicName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            topicTreeMptt.DeleteNodeClick();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (TreeMptt.HasNodeBeenSelectedFromTree)
                return;
            Topic t = (Topic)(trwTopics.SelectedNode.Tag);
            t.Desc = txtDescription.Text;
            t.Changed = true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // if the change is due to selection in the tree, don't change
            if (TreeMptt.HasNodeBeenSelectedFromTree)
            {
                gamon.TreeMptt.TreeMptt.HasNodeBeenSelectedFromTree = false;
                return;
            }
            if (trwTopics.SelectedNode == null)
            {
                MessageBox.Show("Aggiungere il primo argomento o selezionarne uno");
                return;
            }
            Topic t = (Topic)(trwTopics.SelectedNode.Tag);
            t.Name = txtTopicName.Text;
            trwTopics.SelectedNode.Text = t.Name;
            t.Changed = true;
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
            topicTreeMptt.FindItem(txtFind.Text);
        }

        private System.Windows.Forms.TreeNode FindTopicName(int Key, System.Windows.Forms.TreeNode StartNode)
        {
            throw new NotImplementedException();
        }

        private void frmTopics_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Return || e.KeyCode == Keys.F3)
            if (e.KeyCode == Keys.F3)
                topicTreeMptt.FindItem(txtFind.Text);
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
    }
}
