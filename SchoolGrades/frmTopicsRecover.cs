using gamon.TreeMptt;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmTopicsRecover : Form
    {
        gamon.TreeMptt.TreeMptt treeNew;
        gamon.TreeMptt.TreeMptt treeOld;

        //DbAndBusiness dbNew;
        //DbAndBusiness dbOld;
        DataLayer dl;

        Color colorNewOnly = Color.LightBlue;
        Color colorOldOnly = Color.Orange;
        Color colorSameId = Color.Red;
        Color colorSameName = Color.Lime;
        Color colorSameDesc = Color.LimeGreen;
        Color colorSameNodeChangedParent = Color.DarkOliveGreen;
        Color colorSameNodeChangedPosition = Color.GreenYellow;

        public frmTopicsRecover()
        {
            InitializeComponent();
        }
        private void frmTopicsRecover_Load(object sender, EventArgs e)
        {
            // Commons.ReadConfigFile();
            txtPathNewDatabase.Text = Commons.PathDatabase;
            txtPathOldDatabase.Text = Commons.PathDatabase;
            txtFileNewDatabase.Text = Commons.DatabaseFileName_Current;

            DataLayer dlNew = Commons.SetDataLayer(txtPathNewDatabase.Text + "\\" + txtFileNewDatabase.Text);
            treeNew = new TreeMptt(trwNewTopics,
                txtNewTopicName, txtNewDescription, txtSearchNew, null, txtCodNewTopic,
                CommonsWinForms.globalPicLed, null, null, null, null, null, DragDropEffects.Copy);
            treeNew.Name = "treeNew";
            treeNew.AddNodesToTreeviewByBestMethod();
            treeNew.ClearBackColorOnClick = false;

            picNewOnly.BackColor = colorNewOnly;
            picOldOnly.BackColor = colorOldOnly;
            picSameId.BackColor = colorSameId;
            picSameName.BackColor = colorSameName;
            picSameDesc.BackColor = colorSameDesc;
            picSameNodeChangedParent.BackColor = colorSameNodeChangedParent;
            picSameNodeChangedPosition.BackColor = colorSameNodeChangedPosition;
        }
        private void btnPathNewDatabase_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtPathNewDatabase.Text;
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                txtPathNewDatabase.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void btnFileNewDatabase_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = txtPathNewDatabase.Text;
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                txtFileNewDatabase.Text = Path.GetFileName(openFileDialog1.FileName);
                txtPathNewDatabase.Text = Path.GetDirectoryName(openFileDialog1.FileName);
            }
            DataLayer dlNew  = Commons.SetDataLayer(txtPathNewDatabase.Text + "\\" + txtFileNewDatabase.Text); 

            treeNew = new TreeMptt(trwNewTopics,
                txtNewTopicName, txtNewDescription, null, null, txtCodNewTopic,
                CommonsWinForms.globalPicLed, null, null, null, null, null, DragDropEffects.Copy);
            treeNew.AddNodesToTreeviewByBestMethod();
            treeNew.ClearBackColorOnClick = false;

            highligthDifferences();
        }
        private void btnPathOldDatabase_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtPathOldDatabase.Text;
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                txtPathOldDatabase.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void btnFileOldDatabase_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = txtPathOldDatabase.Text;
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                txtFileOldDatabase.Text = Path.GetFileName(openFileDialog1.FileName);
                txtPathOldDatabase.Text = Path.GetDirectoryName(openFileDialog1.FileName);
            }
            if (!File.Exists(txtPathOldDatabase.Text + "\\" + txtFileOldDatabase.Text))
            {
                Console.Beep();
                return;
            }
            ////////////DataLayer dlOld = new DataLayer(txtPathOldDatabase.Text + "\\" + txtFileOldDatabase.Text);

            treeOld = new TreeMptt(trwOldTopics,
                txtOldTopicName, txtOldDescription, txtSearchOld, null, txtCodOldTopic,
                CommonsWinForms.globalPicLed, null, null, null, null, null,
                DragDropEffects.Copy);
            treeOld.Name = "treeOld";
            treeOld.AddNodesToTreeviewByBestMethod();
            treeOld.ClearBackColorOnClick = false;

            // stop background saving thread when using this form so it will not interfere. 
            // locks a concurrent modification of syncronyzing variables 
            lock (Commons.LockBackgroundSavingVariables)
            {
                Commons.BackgroundSavingEnabled = false;
                Commons.BackgroundTaskClose = true;
            }
            // we wait for the saving Thread to finish
            // (it aborts in a point in which status is preserved)  
            Commons.BackgroundSaveThread.Join(3000);

            highligthDifferences();
        }
        private void highligthDifferences()
        {
            treeNew.ClearBackColor();
            treeOld.ClearBackColor();
            List<System.Windows.Forms.TreeNode> nodesNew = new List<System.Windows.Forms.TreeNode>();
            // recursively fill nodesNew
            treeNew.GetSubtree_Recursive(trwNewTopics.Nodes[0], nodesNew);
            // recursively fill nodesOld
            List<System.Windows.Forms.TreeNode> nodesOld = new List<System.Windows.Forms.TreeNode>();
            treeOld.GetSubtree_Recursive(trwOldTopics.Nodes[0], nodesOld);

            int indexScanNew = 0;
            int indexScanOld = 0;
            System.Windows.Forms.TreeNode nodeNew;
            System.Windows.Forms.TreeNode nodeOld;
            Topic topicNew;
            Topic topicOld;

            while (indexScanNew < nodesNew.Count - 1 && indexScanOld < nodesOld.Count - 1)
            {
                nodeNew = nodesNew[indexScanNew];
                nodeOld = nodesOld[indexScanOld];
                topicNew = (Topic)(nodeNew.Tag);
                topicOld = (Topic)(nodeOld.Tag);

                // while we have the same nodes Ids, we keep up coloring with backgrounds of same Id
                while (topicNew.Id == topicOld.Id)
                {
                    if (topicNew.Name != topicOld.Name)
                    {
                        nodeNew.BackColor = colorSameId;
                        nodeOld.BackColor = colorSameId;
                        nodeNew.Parent.Expand();
                        nodeOld.Expand();
                    }
                    if (topicNew.Name == topicOld.Name && topicNew.Desc != topicOld.Desc)
                    {
                        nodeNew.BackColor = colorSameName;
                        nodeOld.BackColor = colorSameName;
                        try
                        {
                            nodeNew.Parent.Expand();
                        }
                        catch { }
                        nodeOld.Expand();
                    }
                    else if (topicNew.Desc == topicOld.Desc)
                    {
                        if (topicNew.ParentNodeOld == topicOld.ParentNodeOld)
                        {
                            nodeNew.BackColor = colorSameDesc;
                            nodeOld.BackColor = colorSameDesc;
                        }
                        else
                        {
                            nodeNew.BackColor = colorSameNodeChangedParent;
                            nodeOld.BackColor = colorSameNodeChangedParent;
                        }
                    }
                    if (topicNew.ChildNumberOld == topicOld.ChildNumberOld)
                    {
                        nodeNew.BackColor = colorSameNodeChangedPosition;
                        nodeOld.BackColor = colorSameNodeChangedPosition;
                    }
                    if (indexScanNew == nodesNew.Count - 1 || indexScanOld == nodesOld.Count - 1)
                        break;
                    nodeNew = nodesNew[++indexScanNew];
                    nodeOld = nodesOld[++indexScanOld];
                    topicNew = (Topic)(nodeNew.Tag);
                    topicOld = (Topic)(nodeOld.Tag);
                }
                // now the nodes are different 
                // look if the current new node is in the old tree
                bool found = false;
                int indexSearchOld = 0;
                while (indexSearchOld < nodesOld.Count && !found &&
                    indexScanNew < nodesNew.Count - 1)
                {
                    nodeOld = nodesOld[indexSearchOld];
                    topicOld = (Topic)(nodeOld.Tag);

                    if (topicNew.Id == topicOld.Id)
                    {
                        found = true;
                        break;
                    }
                    indexSearchOld++;
                }
                if (found && indexScanNew < nodesNew.Count - 1)
                {   // we found the current new node in old tree 
                    // we can go on with the scanning 
                    indexScanOld = indexSearchOld;
                }
                else if (indexScanNew < nodesNew.Count - 1)
                {
                    // the current new node in not in the old tree
                    // we mark this node with "only in new" color 
                    nodeNew.BackColor = colorNewOnly;
                    nodeNew.Parent.Expand();
                    // we go to the next new node 
                    indexScanNew++;
                    indexScanOld = 0;
                }
            }
            //trwNewTopics.ExpandAll();
            //trwOldTopics.ExpandAll();
        }
        private void btnRecover_Click(object sender, EventArgs e)
        {
            //DbAndBusiness dbNew = new DbAndBusiness( txtPathNewDatabase.Text + "\\" + txtFileNewDatabase.Text);
            DataLayer dlNew = Commons.SetDataLayer(txtPathNewDatabase.Text + "\\" + txtFileNewDatabase.Text);
            List<Topic> lNew = dlNew.GetTopics();

            if (txtFileOldDatabase.Text == "")
            {
                Console.Beep();
                return;
            }

            //DbAndBusiness dbOld = new DbAndBusiness( txtPathOldDatabase.Text + "\\" + txtFileOldDatabase.Text);
            //List<Topic> lOld = dl.GetTopics();
            DataLayer dlOld = Commons.SetDataLayer(txtPathOldDatabase.Text + "\\" + txtFileOldDatabase.Text);
            List<Topic> lOld = dlOld.GetTopics();

            int newIndex = 0;
            bool newFinished = false;
            foreach (Topic tOld in lOld)
            {
                Topic tNew = lNew[newIndex];
                while (tNew.Id < tOld.Id && !newFinished)
                {
                    tNew = lNew[++newIndex];
                    if (newIndex > lNew.Count)
                    {
                        newFinished = true;
                    }
                }
                if (newFinished)
                    break;
                if (tOld.Id == tNew.Id)
                {
                    if (tOld.Name != tNew.Name || tOld.Desc != tNew.Desc)
                    {
                        if (chkCheckChangesSameId.Checked)
                            if (MessageBox.Show("Record diversi con lo stesso Id\r\n" +
                                "Nuovo record = " + tNew.Id + " " + tNew.Name + " " + tNew.Desc + "\r\n" +
                                "Vecchio record = " + tOld.Id + " " + tOld.Name + " " + tOld.Desc + "\r\n" +
                                "Sovrascrivere il nuovo record con il vecchio?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                // ???? should we save Left Right and Parent ????" 
                                dlNew.UpdateTopic(tOld, null);
                            }
                    }
                }
                else
                {
                    if (chkErasedId.Checked)
                    {
                        if (MessageBox.Show("Id non presente nel nuovo database\r\n" +
                            "Nuovo record = " + tNew.Id + " " + tNew.Name + " " + tNew.Desc + "\r\n" +
                            "Vecchio record = " + tOld.Id + " " + tOld.Name + " " + tOld.Desc + "\r\n" +
                            "Aggiungere il vecchio record nel nuovo database?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            // ???? should we save Left Right and Parent ????" 
                            dlNew.InsertTopic(tOld, null);
                        }
                    }
                }
            }
            this.Close();
        }
        private void btnCopyOldNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TO FINISH!");
            return;

            //TreeNode lastNode = trwOldTopics.Nodes[trwOldTopics.Nodes.Count - 1].
            //    Nodes[trwOldTopics.Nodes[trwOldTopics.Nodes.Count - 1].Nodes.Count - 1];

            System.Windows.Forms.TreeNode selectedOldNode = trwOldTopics.SelectedNode;
            // Clone the old node and its siblings.
            System.Windows.Forms.TreeNode clonedNode = (System.Windows.Forms.TreeNode)selectedOldNode.Clone();

            // Insert the cloned node at the index of the selected node.
            //trwNewTopics.Nodes.Insert(trwNewTopics.SelectedNode.Index, clonedNode);
            trwNewTopics.SelectedNode.Nodes.Add(clonedNode);
        }
        private void btnFindNew_Click(object sender, EventArgs e)
        {
            treeNew.FindNodes(txtSearchNew.Text, false, true, false, false, false);
        }
        private void btnFindOld_Click(object sender, EventArgs e)
        {
            treeOld.FindNodes(txtSearchOld.Text, false, true, false, false, false);
        }
        private void BtnSaveNewTree_Click(object sender, EventArgs e)
        {
            treeNew.SaveTreeFromTreeViewByParent();

            // abort the background saving that was triggered by SaveTreeFromTreeViewControlByParent
            // locks a concurrent modification of Commons.BackgroundCanStillSaveTopicsTree 
            lock (Commons.LockBackgroundSavingVariables)
            {
                Commons.BackgroundSavingEnabled = false;
                Commons.BackgroundTaskClose = true;
            }
            // we wait for the saving Thread to finish
            // (it aborts in a point in which status is preserved)  
            Commons.BackgroundSaveThread.Join(3000);

            // !!!! TODO restart the task on closing the form !!!!

            MessageBox.Show("Fatto");
        }
        private void frmTopicsRecover_FormClosing(object sender, FormClosingEventArgs e)
        {
            // when the form closes, we restart the background saving task
            // that we have left off when this form was open

            // restart the background Thread 
            startBackgroundSavingTask();
        }
        private void startBackgroundSavingTask()
        {
            // re-create and run the Thread that concurrently saves the Topics tree
            Commons.BackgroundSaveThread = new Thread(CommonsWinForms.SaveTreeMptt.SaveTreeMpttBackground);
            Commons.BackgroundSaveThread.Start();
        }
        private void btnBeheaded_Click(object sender, EventArgs e)
        {
            treeOld.ColorAllBeheadedNodes();
        }
    }
}
