using gamon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SchoolGrades.DbClasses;
using gamon.TreeMptt;
using SharedWinForms;

namespace SchoolGrades
{
    public partial class frmLessons : Form
    {
        gamon.TreeMptt.TreeMptt topicTreeMptt;

        Lesson currentLesson = new Lesson();

        Class currentClass;

        DbAndBusiness db;

        List<Topic> listTopicsBefore;

        List<DbClasses.Image> listImages;
        private int indexImages = 0;

        private SchoolSubject currentSchoolSubject;

        bool isFormClosed = false;
        public bool IsFormClosed { get => isFormClosed; set => isFormClosed = value; }
        public frmLessons(Class CurrentClass, SchoolSubject SchoolSubject, bool ReadOnly)
        {
            InitializeComponent();

            db = new DbAndBusiness(Commons.PathAndFileDatabase); 

            currentClass = CurrentClass;
            currentLesson.IdClass = currentClass.IdClass;
            currentLesson.IdSchoolYear = currentClass.SchoolYear;
            currentLesson.IdSchoolSubject = SchoolSubject.IdSchoolSubject;
            currentSchoolSubject = SchoolSubject; 
            txtSchoolSubject.Text = SchoolSubject.Name;

            string currentIdSchoolSubject = currentSchoolSubject.IdSchoolSubject;

            if (ReadOnly)
            {
                btnSaveTree.Enabled = false;
                btnAddNode.Enabled = false;
                btnDelete.Enabled = false;
                btnLessonAdd.Enabled = false;
                btnLessonSave.Enabled = false;
                bntLessonErase.Enabled = false;
                this.Text += " (sola lettura)"; 
            }
        }
        private void frmLessons_Load(object sender, EventArgs e)
        {
            //txtLessonDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dtpLessonDate.Value = new DateTime(1980, 01, 01);

            txtSchoolYear.Text = currentClass.SchoolYear;
            txtClass.Text = currentClass.Abbreviation;

            Lesson dummyLesson = db.GetLastLesson(currentLesson);

            if (dummyLesson.IdSchoolSubject != null)
            {
                txtLessonCode.Text = dummyLesson.IdLesson.ToString();
                dtpLessonDate.Value = (DateTime)dummyLesson.Date;
                TxtLessonDesc.Text = dummyLesson.Note;

                currentLesson.IdLesson = dummyLesson.IdLesson;
                currentLesson.Date = dummyLesson.Date;
                currentLesson.Note = dummyLesson.Note;
            }
            else
            {
                //dtpLessonDate.Visible = false; 
            }
            // load data in datagrids
            RefreshUI();
            //topicTreeMptt = new TopicTreeMptt(listTopicsBefore, trwTopics,
            topicTreeMptt = new gamon.TreeMptt.TreeMptt(db, trwTopics,
                txtTopicName, txtTopicDescription, txtTopicFind, TxtTopicsDigestAndSearch,
                null, CommonsWinForms.globalPicLed, DragDropEffects.Copy);
            topicTreeMptt.AddNodesToTreeviewByBestMethod();

            // gets and checks the topics of the current lesson 
            List<Topic> TopicsToCheck = new List<Topic>();
            db.GetTopicsOfLesson(currentLesson.IdLesson, TopicsToCheck);
            int dummy = 0;
            bool dummy2 = false;
            topicTreeMptt.CheckItemsInList(trwTopics.Nodes[0],
                TopicsToCheck, ref dummy, ref dummy2);

            // gets the images associated with this lesson
            listImages = db.GetLessonsImagesList(currentLesson);
            // shows the first image
            if (listImages != null && listImages.Count > 0)
                try
                {
                    picImage.Load(Commons.PathImages + "\\" + listImages[indexImages].RelativePathAndFilename);
                }
                catch { };

            this.BackColor = Commons.ColorFromNumber(currentSchoolSubject);

            LessonTimer.Interval = 1000;
            LessonTimer.Start();
        }

        private void RefreshUI()
        {
            DgwAllLessons.DataSource = db.GetLessonsOfClass(currentClass,
                currentLesson);
            DgwAllLessons.Columns[0].Visible = true;
            DgwAllLessons.Columns[1].Visible = true;
            DgwAllLessons.Columns[2].Visible = false;
            DgwAllLessons.Columns[3].Visible = false;
            DgwAllLessons.Columns[4].Visible = true;
            DgwAllLessons.Columns[5].Visible = false;

            dgwOneLesson.DataSource = db.GetTopicsOfOneLessonOfClass(currentClass,
                currentLesson);
            dgwOneLesson.Columns[0].Visible = false;
            dgwOneLesson.Columns[1].Visible = true;
            dgwOneLesson.Columns[2].Visible = true;
            dgwOneLesson.Columns[3].Visible = false;
            dgwOneLesson.Columns[4].Visible = false;
            dgwOneLesson.Columns[5].Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            topicTreeMptt.FindItem(txtTopicFind.Text); 
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            topicTreeMptt.AddNewNode("Nuovo argomento");
            // set focus to the name textBox
            txtTopicName.Focus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            topicTreeMptt.DeleteNode();
        }
        private void btnSaveTree_Click(object sender, EventArgs e)
        {
            topicTreeMptt.SaveTreeFromTreeViewControlByParent();
            MessageBox.Show("Salvataggio fatto");
        }
        // !!!! TODO: this should stay into the TTMPT tree class !!!!
        private void txtTopicName_TextChanged(object sender, EventArgs e)
        {
            // if the change is due to selection in the tree, don't change
            if (TreeMptt.HasNodeBeenSelectedFromTree)
            {
                TreeMptt.HasNodeBeenSelectedFromTree = false;
                return;
            }
            if (trwTopics.SelectedNode == null)
            {
                MessageBox.Show("Aggiungere il primo argomento o selezionarne uno");
                return;
            }
            // if the text is multiline and at the beginning of the new line there is 
            // an indentation: ask to import a subtree, if yes then create subtree
            if (!txtTopicName.Text.Contains("\r\n")
                && !(txtTopicName.Text.Contains("    ") || txtTopicName.Text.Contains("\t"))
                )
            {
                Topic t = (Topic)(trwTopics.SelectedNode.Tag);
                t.Name = txtTopicName.Text;
                t.Changed = true;
            }
            else
            {
                if (MessageBox.Show("Testo formattato come un albero di FreeMind.\nDevo importare un sottoalbero in questo punto?",
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    topicTreeMptt.ImportSubtreeFromText(txtTopicName.Text);
                    int positionOfTab = txtTopicName.Text.IndexOf("\r\n");
                    trwTopics.SelectedNode.Text = txtTopicName.Text.Substring(0, positionOfTab);
                    ((Topic)(trwTopics.SelectedNode.Tag)).Name = txtTopicName.Text.Substring(0, positionOfTab);
                }
                else
                {
                    trwTopics.SelectedNode.Text = txtTopicName.Text;
                }
            }
        }

        private void ExportSubtreeToClipboard()
        {
            if (topicTreeMptt.TreeView.SelectedNode.Tag == null)
            {
                MessageBox.Show("Scegliere un argomento.\r\n" +
                    "Verranno messi in clipboard gli argomenti dell'albero sotto l'argomento scelto");
                return;
            }
            string tree = null;
            Topic InitialNode = (Topic)topicTreeMptt.TreeView.SelectedNode.Tag;

            topicTreeMptt.ExportSubtreeToText(InitialNode); 

            Clipboard.SetText(tree);

            MessageBox.Show("Albero copiato nella clipboard");
        }

        private void btnLessonAdd_Click(object sender, EventArgs e)
        { 
            dtpLessonDate.Visible = true;
            // if dtpLessonDate has its default date, no lesson is present in database 
            DateTime dummy = new DateTime(1980, 1, 1); 
            if (dtpLessonDate.Value.Date == dummy.Date) 
            {
                // first time, no lesson present, put current date in the control
                // the control will be used to know the date of the new lesson 
                dtpLessonDate.Value = DateTime.Now;
                currentLesson.Date = dtpLessonDate.Value; 
            }
            else
            {
                if (currentLesson.Date != dtpLessonDate.Value)
                {
                    // date of current lesson and date in control dtpLessonDate are different
                    // hence the user has changed the date to save a new lesson in a date different 
                    // from today
                    // ask for confirmation of saving in the new date
                    if (MessageBox.Show("Creare una nuova lezione nella data del\n" + 
                        dtpLessonDate.Value.ToString("dd-MM-yyyy") + " (Sì)\n" +
                        "Non salvare nulla (No)",
                        "Creazione in data diversa", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1)
                        == DialogResult.No)
                    {
                        return; 
                    }
                }
                else
                {
                    // the date of the current lesson is the same displayed
                    // then we'll create a new lesson for today 
                    if (MessageBox.Show("Creare una nuova lezione nella data di oggi (Sì)" +
                        "\nNon salvare nulla (No)",
                        "Creazione in data odierna", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1)
                        == DialogResult.No)
                    {
                        return; 
                    }
                    else
                    {
                        // create the new lesson today 
                        dtpLessonDate.Value = DateTime.Now;
                    }
                }
            }
            Lesson l = db.GetLessonInDate(currentClass, currentSchoolSubject.IdSchoolSubject,
                dtpLessonDate.Value); 

            if (l.IdLesson > 0)
            {
                // found a lesson with the same date => block creation of the new lesson
                MessageBox.Show("Il programma non registra due lezioni diverse nello stesso giorno.\n" +
                    "Nulla verrà salvato ora. Usare il bottone 'Salva'.",
                    "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            currentLesson = new Lesson();
            currentLesson.Date = dtpLessonDate.Value;
            currentLesson.IdClass = currentClass.IdClass;
            currentLesson.IdSchoolSubject = currentSchoolSubject.IdSchoolSubject;
            currentLesson.IdSchoolYear = txtSchoolYear.Text;
            currentLesson.IdLesson = db.NewLesson(currentLesson);
            TxtLessonDesc.Text = "";
            txtLessonCode.Text = currentLesson.IdLesson.ToString();
            dtpLessonDate.Value = (DateTime)currentLesson.Date;
            topicTreeMptt.UncheckAllItemsUnderNode(trwTopics.Nodes[0]);
            
            //  refresh database data in grids 
            RefreshUI();
        }

        private void txtLessonDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLessonSave_Click(object sender, EventArgs e)
        {
            btnLessonSave.Enabled = false;
            // save anyway (should be better to control if it is necessary)  
            topicTreeMptt.SaveTreeFromTreeViewControlByParent(); 

            if (txtLessonCode.Text == "")
            {
                MessageBox.Show("ATTENZIONE: Creare una nuova lezione!");
                return; 
            }

            if (dtpLessonDate.Value.Day != DateTime.Now.Day)
            {
                if (MessageBox.Show("La data della lezione non è quella di oggi." +
                    "\r\nVuoi salvarla comunque (Sì) o non salvarla (No)?",
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1)
                    == DialogResult.No)
                    return;
            }
            currentLesson.Date = dtpLessonDate.Value;
            currentLesson.Note = TxtLessonDesc.Text;
            
            // save the lesson (the topics could have been changed)
            db.SaveLesson(currentLesson);

            // save the topics of the lesson
            // we find the checked items in treeviw, we start from the beginning 
            List<Topic> topicsOfTheLesson = new List<Topic>();
            int dummy = 0; 
            topicTreeMptt.FindCheckedItems(trwTopics.Nodes[0], 
                topicsOfTheLesson, ref dummy);
            db.SaveTopicsOfLesson(currentLesson.IdLesson, topicsOfTheLesson);

            //  refresh database data in grids 
            RefreshUI();

            // reset check signs
            topicTreeMptt.UncheckAllItemsUnderNode(trwTopics.Nodes[0]);
            // restore current checksigns from database 
            List<Topic> TopicsToCheck = new List<Topic>();
            db.GetTopicsOfLesson(currentLesson.IdLesson, TopicsToCheck);
            dummy = 0;
            bool dummy2 = false;
            topicTreeMptt.CheckItemsInList(trwTopics.Nodes[0],
                TopicsToCheck, ref dummy, ref dummy2);
            btnLessonSave.Enabled = true;
            //MessageBox.Show("Fatto"); 

            //this.Close(); // TODO avoid this when the process of saving without
            //              // closing the form will be relaiable
        }
        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TxtLessonDesc.Text + ". " + TxtTopicsDigestAndSearch.Text);
        }
        private void btnStartLinks_Click(object sender, EventArgs e)
        {
            List<string> ll = db.GetStartLinksOfClass(currentClass); 
            foreach(string link in ll)
            {
                try
                {
                    if (link.Substring(0, 4) == "http")
                        Commons.ProcessStartLink(link);
                    else
                        //Commons.ProcessStartLink(Commons.PathStartLinks + "\\" + link);
                        Commons.ProcessStartLink(currentClass.PathRestrictedApplication + "\\" + link);
                }
                catch
                {
                    Console.Beep();
                }
            }
        }
        private void txtTopicDescription_TextChanged(object sender, EventArgs e)
        {
            if (gamon.TreeMptt.TreeMptt.HasNodeBeenSelectedFromTree)
                return;
            if (trwTopics.SelectedNode != null)
            {
                Topic t = (Topic)(trwTopics.SelectedNode.Tag);
                t.Desc = txtTopicDescription.Text;
                t.Changed = true;
            }
            else
            {
                MessageBox.Show("Selezionare un argomento"); 
            }
        }

        private void picImage_Click(object sender, EventArgs e)
        {

        }
        private void picImage_DoubleClick(object sender, EventArgs e)
        {
            if (listImages.Count > 0)
            {
                string fileName = Commons.PathImages + "\\" + listImages[indexImages].RelativePathAndFilename;
                if (File.Exists(fileName))
                {
                    Commons.ProcessStartLink(fileName);
                }
                else
                {
                    Console.Beep();
                    MessageBox.Show("Il file memorizzato dal database non esite più\n" + fileName); 
                }
            }
        }

        private void btnManageImages_Click(object sender, EventArgs e)
        {
            if(txtLessonCode.Text=="")
            {
                MessageBox.Show("Creare prima una nuova lezione");
                return; 
            }
            frmImages fi = new frmImages(frmImages.ImagesFormType.NormalManagement
                , currentLesson, currentClass, listImages, currentSchoolSubject);
            fi.ShowDialog();
            listImages = db.GetLessonsImagesList(currentLesson);
            indexImages = 0;
            if (listImages.Count > 0)
            {
                string nomeFile = Commons.PathImages + "\\" + listImages[indexImages].RelativePathAndFilename;
                try
                {
                    picImage.Load(nomeFile);
                }
                catch
                {
                    MessageBox.Show("Non è possible aprire il file " + nomeFile +  " !");
                }
            }
        }

        private void dgwOneLesson_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataRow row = ((DataTable)(dgwOneLesson.DataSource)).Rows[e.RowIndex];
                topicTreeMptt.FindItemById((int)row["idTopic"]);
            }
        }
        private void frmLessonsTopics_KeyDown(object sender, KeyEventArgs e)
        {
            checkGeneralKeysForTopicsTree(e);
        }
        private void checkGeneralKeysForTopicsTree(KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Right)
            //{
            //    NextImage();
            //}
            //if (e.KeyCode == Keys.Left)
            //{
            //    PreviousImage();
            //}

            if (e.KeyCode == Keys.F3)
                topicTreeMptt.FindItem(txtTopicFind.Text);
            if (e.KeyCode == Keys.F5)
            {
                btnSaveTree_Click(null, null);
            }
        }

        private void checkSpecificKeysForTopicsTree(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                NextImage();
            }
            if (e.KeyCode == Keys.Left)
            {
                PreviousImage();
            }

            if (e.KeyCode == Keys.F3)
                topicTreeMptt.FindItem(txtTopicFind.Text);
            if (e.KeyCode == Keys.F5)
            {
                btnSaveTree_Click(null, null);
            }

            //if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Decimal)
            //{
            //    btnDelete_Click(null, null);
            //}
            //if (e.KeyCode == Keys.Insert || e.KeyCode == Keys.NumPad0)
            //{
            //    btnAddNode_Click(null, null);
            //}
        }

        private void PreviousImage()
        {
            if (listImages.Count > 0)
            {
                if (indexImages == 0)
                    indexImages = listImages.Count;
                indexImages--;
                picImage.Load(Commons.PathImages + "\\" + listImages[indexImages].RelativePathAndFilename);
            }
        }

        private void NextImage()
        {
            if (listImages.Count > 0)
            {
                indexImages = ++indexImages % listImages.Count;
                picImage.Load(Commons.PathImages + "\\" + listImages[indexImages].RelativePathAndFilename);
            }
        }

        private void btnTopicsNotDone_Click(object sender, EventArgs e)
        {
            if (trwTopics.SelectedNode == null)
            {
                MessageBox.Show("Scegliere un argomento.\r\n" +
                    "Verranno evidenziati gli argomenti sotto l'argomento scelto che NON sono stati fatti");
                    return;
            }
            // !!!! nella query non c'è la classe. NON può funzionare !!!!
            List<Topic> listNonDone = db.GetTopicsNotDoneFromThisTopic(currentClass,
                ((Topic)trwTopics.SelectedNode.Tag), currentSchoolSubject);
            int dummy=0; bool dummy2=false; 
            topicTreeMptt.HighlightTopicsInList(trwTopics.Nodes[0],
                 listNonDone, ref dummy, ref dummy2);
        }

        private void btnTopicsDone_Click(object sender, EventArgs e)
        {
            if (trwTopics.SelectedNode == null)
            {
                MessageBox.Show("Scegliere un argomento.\r\n" +
                    "Verranno evidenziati gli argomenti sotto l'argomento scelto che sono stati fatti");
                return;
            }

            List<Topic> listDone = db.GetTopicsDoneFromThisTopic(currentClass,
                ((Topic)trwTopics.SelectedNode.Tag), currentSchoolSubject);
            int dummy = 0; bool dummy2 = false;
            topicTreeMptt.HighlightTopicsInList(trwTopics.Nodes[0],
                 listDone, ref dummy, ref dummy2);
        }

        private void bntLessonErase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vuole davvero  eliminare la lezione:\r\n" + txtLessonCode.Text +
                ",'" + TxtLessonDesc.Text + "'?", "Cancellazione", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) 
                != DialogResult.Yes)
            {
                return; 
            }
            // !! TODO !! add message box to ask for image files deletion
            db.EraseLesson(int.Parse(txtLessonCode.Text), false);
            RefreshUI();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            NextImage();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            PreviousImage();
        }
        private void frmLessons_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsFormClosed = true;
        }
        private void btnArgFreemind_Click(object sender, EventArgs e)
        {
            ExportSubtreeToClipboard(); 
        }
        private void LessonTimer_Tick(object sender, EventArgs e)
        {
            lblLessonTime.BackColor = ((frmMain)Application.OpenForms[0]).CurrentLessonTimeColor;
        }
        private void DgwAllLessons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DgwAllLessons_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DgwAllLessons.Rows[e.RowIndex].Selected = true;

                TxtTopicsDigestAndSearch.Text = "";
                DataRow row = ((DataTable)(DgwAllLessons.DataSource)).Rows[e.RowIndex];
                if (currentLesson.IdLesson != (int)row["idLesson"])
                {
                    currentLesson.IdLesson = (int)row["idLesson"];
                    currentLesson.Note = (string)row["note"];
                    currentLesson.Date = (DateTime)row["date"];

                    TxtLessonDesc.Text = currentLesson.Note;
                    dtpLessonDate.Value = (DateTime)currentLesson.Date;
                    txtLessonCode.Text = currentLesson.IdLesson.ToString();

                    dgwOneLesson.DataSource = db.GetTopicsOfOneLessonOfClass(currentClass,
                        currentLesson);

                    topicTreeMptt.UncheckAllItemsUnderNode(trwTopics.Nodes[0]);

                    // gets and checks the topics of the current lesson 
                    List<Topic> TopicsToCheck = new List<Topic>();
                    db.GetTopicsOfLesson(currentLesson.IdLesson, TopicsToCheck);
                    int dummy = 0;
                    bool dummy2 = false;
                    topicTreeMptt.CheckItemsInList(trwTopics.Nodes[0],
                        TopicsToCheck, ref dummy, ref dummy2);

                    // gets the images associated with this lesson
                    listImages = db.GetLessonsImagesList(currentLesson);
                    // shows the fist image
                    if (listImages.Count > 0)
                        try
                        {
                            picImage.Load(Commons.PathImages + "\\" + listImages[indexImages].RelativePathAndFilename);
                        }
                        catch { }
                    else
                    {
                        picImage.Image = null;
                    }
                }
            }
        }
        private void DgwAllLessons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DgwAllLessons.Rows[e.RowIndex].Selected = true;
            }
        }

        private void BtnSearchAmongTopics_Click(object sender, EventArgs e)
        {
            int rowToBeSearchedIndex;

            if (DgwAllLessons.SelectedRows == null)
                rowToBeSearchedIndex = 0;
            else
                rowToBeSearchedIndex = DgwAllLessons.SelectedRows[0].Index;
            int indexWhenBeginning = rowToBeSearchedIndex;
            rowToBeSearchedIndex = ++rowToBeSearchedIndex % DgwAllLessons.Rows.Count;
            bool allScanned = false;
            while (!allScanned)
            {
                DataGridViewRow row = DgwAllLessons.Rows[rowToBeSearchedIndex]; 
                if (((string)row.Cells["Note"].Value).Contains(TxtTopicsDigestAndSearch.Text))
                {
                    DgwAllLessons.ClearSelection(); 
                    row.Selected = true;
                    break; 
                }
                rowToBeSearchedIndex = ++rowToBeSearchedIndex % DgwAllLessons.Rows.Count;
                if (rowToBeSearchedIndex == indexWhenBeginning)
                    allScanned = true;
            }

        }

        private void BtnOpenImagesFolder_Click(object sender, EventArgs e)
        {
            string folder = Commons.PathImages + "\\" + currentClass.SchoolYear + currentClass.Abbreviation +
                "\\Lessons\\" + currentSchoolSubject.IdSchoolSubject;
            try
            {
                Commons.ProcessStartLink(folder);
            }
            catch
            {
                MessageBox.Show("La cartella non è stata ancora creata.\nIl programma la creerà automaticamente quando verrà salvata la prima immagine."); 
            }
        }
    }
}
