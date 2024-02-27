using gamon.TreeMptt;
using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class frmLessons : Window
    {
        bool isLoading = true;

        TreeMptt topicTreeMptt;

        Lesson currentLesson = new Lesson();

        Class currentClass;

        //List<Topic> listTopicsBefore;

        List<SchoolGrades.BusinessObjects.Image> listImages;
        private int indexImages = 0;

        private SchoolSubject currentSchoolSubject;

        bool isFormClosed = false;
        private int currentIndexLessonsGrid;
        private Lesson currentRowLessonsGrid;

        public bool IsFormClosed { get => isFormClosed; set => isFormClosed = value; }
        public frmLessons(Class CurrentClass, SchoolSubject SchoolSubject, bool ReadOnly)
        {
            InitializeComponent();

            currentClass = CurrentClass;
            currentLesson.IdClass = currentClass.IdClass;
            currentLesson.IdSchoolYear = currentClass.SchoolYear;
            currentLesson.IdSchoolSubject = SchoolSubject.IdSchoolSubject;
            currentSchoolSubject = SchoolSubject;
            txtSchoolSubject.Text = SchoolSubject.Name;

            string currentIdSchoolSubject = currentSchoolSubject.IdSchoolSubject;

            if (ReadOnly)
            {
                btnSaveTree.IsEnabled = false;
                btnAddNode.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnLessonAdd.IsEnabled = false;
                btnLessonSave.IsEnabled = false;
                bntLessonErase.IsEnabled = false;
                btnAddNodeBrother.IsEnabled = false;
                this.Title += " (sola lettura)";
            }
            frmLessons_Load();
        }
        private void frmLessons_Load()
        {
            //txtLessonDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dtpLessonDate.SelectedDate = new DateTime(1980, 01, 01);

            txtSchoolYear.Text = currentClass.SchoolYear;
            txtClass.Text = currentClass.Abbreviation;

            Lesson dummyLesson = Commons.bl.GetLastLesson(currentLesson);

            if (dummyLesson.IdSchoolSubject != null)
            {
                txtLessonCode.Text = dummyLesson.IdLesson.ToString();
                dtpLessonDate.SelectedDate = (DateTime)dummyLesson.Date;
                TxtLessonDesc.Text = dummyLesson.Note;

                currentLesson.IdLesson = dummyLesson.IdLesson;
                currentLesson.Date = dummyLesson.Date;
                currentLesson.Note = dummyLesson.Note;
            }
            else
            {
                //dtpLessonDate.IsVisible = false; 
            }
            currentIndexLessonsGrid = 0;
            // load data in datagrids
            RefreshLessons(currentIndexLessonsGrid);

            topicTreeMptt = new TreeMptt(trwTopics, txtTopicName, txtTopicDescription,
                txtTopicSearchString, txtTopicsDigest, null, CommonsWpf.globalPicLed,
                chkSearchInDescriptions, chkVerbatimString, chkAllWord, chkCaseInsensitive,
                chkMarkAllTopicsFound, DragDropEffects.Copy, true);
            topicTreeMptt.AddNodesToTreeviewByBestMethod();

            RefreshTopicsChecksAndImages();

            System.Windows.Media.Color c = CommonsWpf.ColorFromNumber(currentSchoolSubject.Color);
            SolidColorBrush br = new SolidColorBrush(System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B));
            this.Background = br;

            ////////LessonTimer.Interval = 1000;
            ////////LessonTimer.Start();

            isLoading = false;
        }
        private void RefreshLessons(int IndexInLessons)
        {
            List<SchoolGrades.BusinessObjects.Lesson> l = Commons.bl.GetLessonsOfClass(currentClass, currentLesson.IdSchoolSubject);
            dgwAllLessons.ItemsSource = l;
            if (l.Count > 0)
            {
                try
                {
                    // are these useful in WPF? 
                    //dgwAllLessons.ClearSelection();
                    //dgwAllLessons.Items[IndexInLessons].Selected = true;
                }
                catch
                {

                }
            }
            else
            {
            }
            RefreshTopicsInOneLesson();
            RefreshTopicsChecksAndImages();
            if (dgwAllLessons.Columns.Count > 5)
            {
                ////////dgwAllLessons.Columns[0].IsVisible = false;
                ////////dgwAllLessons.Columns[1].IsVisible = true;
                ////////dgwAllLessons.Columns[2].IsVisible = false;
                ////////dgwAllLessons.Columns[3].IsVisible = false;
                ////////dgwAllLessons.Columns[4].IsVisible = true;
                ////////dgwAllLessons.Columns[5].IsVisible = false;
            }
        }
        private void RefreshTopicsInOneLesson()
        {
            dgwOneLesson.ItemsSource = Commons.bl.GetTopicsOfOneLessonOfClass(currentClass,
                    currentLesson);
            if (dgwOneLesson.Columns.Count > 5)
            {
                ////////dgwOneLesson.Columns[0].IsVisible = false;
                ////////dgwOneLesson.Columns[1].IsVisible = true;
                ////////dgwOneLesson.Columns[2].IsVisible = true;
                ////////dgwOneLesson.Columns[3].IsVisible = false;
                ////////dgwOneLesson.Columns[4].IsVisible = false;
                ////////dgwOneLesson.Columns[5].IsVisible = false;
                ////////dgwOneLesson.Columns[6].IsVisible = false;
            }
        }
        private void RefreshTopicsChecksAndImages()
        {
            if (topicTreeMptt != null)
            {
                topicTreeMptt.UncheckAllItemsUnderNode_Recursive((TreeViewItem)trwTopics.Items[0]);
                // gets and checks the topics of the current lesson 
                List<Topic> TopicsToCheck = Commons.bl.GetTopicsOfLesson(currentLesson.IdLesson);
                int dummy = 0;
                bool dummy2 = false;
                topicTreeMptt.CheckItemsInList_Recursive((TreeViewItem)trwTopics.Items[0],
                TopicsToCheck, ref dummy, ref dummy2);
                // gets the images associated with this lesson
                listImages = Commons.bl.GetListLessonsImages(currentLesson);
                // shows the first image
                if (listImages != null && listImages.Count > 0)
                    try
                    {
                        CommonsWpf.loadPicture(picImage,
                            Path.Combine(Commons.PathImages, listImages[indexImages].RelativePathAndFilename));
                    }
                    catch { }
                else
                {
                    picImage.Source = null;
                }
            }
        }
        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            // ricerca 
            topicTreeMptt.FindNodes(txtTopicSearchString.Text);
        }
        private void btnAddNode_Click(object sender, RoutedEventArgs e)
        {
            topicTreeMptt.AddNewNode("Nuovo argomento", true);
            // set focus to the name textBox
            txtTopicName.Focus();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            topicTreeMptt.DeleteNodeSelected();
        }
        private void btnSaveTree_Click(object sender, RoutedEventArgs e)
        {
            if (!topicTreeMptt.HasChanges)
            {
                MessageBox.Show("Nessuna modifica fatta agli argomenti");
                return;
            }
            topicTreeMptt.SaveTreeFromTreeViewByParent();
            MessageBox.Show("Salvataggio fatto");
        }
        //private void ExportSubtreeToClipboard()
        //{
        //    TreeViewItem item = (TreeViewItem)(trwTopics.SelectedItem);
        //    if (item.Tag == null)
        //    {
        //        MessageBox.Show("Scegliere un argomento.\r\n" +
        //            "Verranno messi in clipboard gli argomenti dell'albero sotto l'argomento scelto");
        //        return;
        //    }
        //    string tree = null;
        //    Topic InitialNode = (Topic)item.Tag;

        //    topicTreeMptt.ExportSubtreeToText(InitialNode);

        //    Clipboard.SetText(tree);

        //    MessageBox.Show("Albero copiato nella clipboard");
        //}
        private void btnLessonAdd_Click(object sender, RoutedEventArgs e)
        {
            //dtpLessonDate.IsVisible = true;
            //if dtpLessonDate has its default date, no lesson is present in database
            DateTime dummy = new DateTime(1980, 1, 1);
            if (dtpLessonDate.SelectedDate == dummy.Date)
            {
                // first time, no lesson present, put current date in the control
                // the control will be used to know the date of the new lesson 
                dtpLessonDate.SelectedDate = DateTime.Now;
                currentLesson.Date = dtpLessonDate.SelectedDate;
                return;
            }
            else
            {
                if (currentLesson.Date != dtpLessonDate.SelectedDate)
                {
                    // date of current lesson and date in control dtpLessonDate are different
                    // hence the user has changed the date to save a new lesson in a date different 
                    // from today
                    // ask for confirmation of saving in the new date
                    if (MessageBox.Show("Creare una nuova lezione nella data del\n" +
                        dtpLessonDate.SelectedDate + " (Sì)\n" +
                        "Non salvare nulla (No)",
                        "Creazione in data diversa")
                        == MessageBoxResult.No)
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
                        "Creazione in data odierna")
                        == MessageBoxResult.No)
                    {
                        return;
                    }
                    else
                    {
                        // create the new lesson today 
                        dtpLessonDate.SelectedDate = DateTime.Now;
                    }
                }
            }
            Lesson l = Commons.bl.GetLessonInDate(currentClass, currentSchoolSubject.IdSchoolSubject,
                (DateTime)dtpLessonDate.SelectedDate);

            if (l.IdLesson > 0)
            {
                // found a lesson with the same date => block creation of the new lesson
                MessageBox.Show("Il programma non registra due lezioni diverse nello stesso giorno.\n" +
                    "Nulla verrà salvato ora. Usare il bottone 'Salva'.",
                    "ATTENZIONE");
                return;
            }
            currentLesson = new Lesson();
            currentLesson.Date = dtpLessonDate.SelectedDate;
            currentLesson.IdClass = currentClass.IdClass;
            currentLesson.IdSchoolSubject = currentSchoolSubject.IdSchoolSubject;
            currentLesson.IdSchoolYear = txtSchoolYear.Text;
            currentLesson.IdLesson = Commons.bl.NewLesson(currentLesson);
            TxtLessonDesc.Text = "";
            txtLessonCode.Text = currentLesson.IdLesson.ToString();
            dtpLessonDate.SelectedDate = (DateTime)currentLesson.Date;
            topicTreeMptt.UncheckAllItemsUnderNode_Recursive((TreeViewItem)trwTopics.Items[0]);

            //  refresh database data in grids 
            RefreshLessons(0);
        }
        //private void txtLessonDesc_TextChanged(object sender, RoutedEventArgs e)
        //{

        //}
        private void btnLessonSave_Click(object sender, RoutedEventArgs e)
        {
            //int currentIndexLessonsGrid = -1;
            //if (dgwAllLessons.SelectedItem != null)
            //{
            //    currentIndexLessonsGrid = ((TreeViewItem)dgwAllLessons.Items[currentIndexLessonsGrid]).index;
            //}
            btnLessonSave.IsEnabled = false;
            // save anyway (should be better to control if it is necessary)  
            if (!topicTreeMptt.HasChanges)
            {
                MessageBox.Show("Nessuna modifica fatta agli argomenti");
            }
            else
                topicTreeMptt.SaveTreeFromTreeViewByParent();

            if (txtLessonCode.Text == "")
            {
                MessageBox.Show("ATTENZIONE: Creare una nuova lezione!");
                btnLessonSave.IsEnabled = true;
                return;
            }

            if (((DateTime)dtpLessonDate.SelectedDate).Day != DateTime.Now.Day)
            {
                if (MessageBox.Show("La data della lezione non è quella di oggi." +
                    "\r\nVuoi salvarla comunque (Sì) o non salvarla (No)?",
                    "", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    btnLessonSave.IsEnabled = true;
                    return;
                }
            }
            currentLesson.Date = dtpLessonDate.SelectedDate;
            currentLesson.Note = TxtLessonDesc.Text;

            // save the lesson (the topics could have been changed)
            Commons.bl.SaveLesson(currentLesson);

            // save the topics of the lesson
            // we find the checked items in treeviw, we start from the beginning 
            List<Topic> topicsOfTheLesson = new List<Topic>();
            int dummy = 0;
            topicTreeMptt.FindCheckedItems_Recursive((TreeViewItem)trwTopics.Items[0],
                topicsOfTheLesson, ref dummy);
            if (topicsOfTheLesson.Count > 0)
                Commons.bl.SaveTopicsOfLesson(currentLesson.IdLesson, topicsOfTheLesson);

            //  refresh database data in grids 
            if (currentIndexLessonsGrid != -1)
                RefreshLessons(currentIndexLessonsGrid);
            RefreshTopicsChecksAndImages();

            btnLessonSave.IsEnabled = true;
        }
        private void btnCopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TxtLessonDesc.Text + ". " + txtTopicsDigest.Text);
        }
        private void btnStartLinks_Click(object sender, RoutedEventArgs e)
        {
            List<StartLink> ll = Commons.bl.GetStartLinksOfClass(currentClass);
            foreach (StartLink link in ll)
            {
                try
                {
                    if (link.Link.Substring(0, 4) == "http")
                        Commons.ProcessStartLink(link.Link);
                    else
                        //Commons.ProcessStartLink(Commons.PathStartLinks + "\\" + link);
                        Commons.ProcessStartLink(Path.Combine(currentClass.PathRestrictedApplication, link.Link));
                }
                catch
                {
                    Console.Beep();
                }
            }
        }
        private void picImage_Click(object sender, RoutedEventArgs e)
        {

        }
        private void picImage_DoubleClick(object sender, RoutedEventArgs e)
        {
            if (listImages.Count > 0)
            {
                string fileName = Path.Combine(Commons.PathImages, listImages[indexImages].RelativePathAndFilename);
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
        private void btnManageImages_Click(object sender, RoutedEventArgs e)
        {
            if (txtLessonCode.Text == "")
            {
                MessageBox.Show("Creare prima una nuova lezione");
                return;
            }
            ////////frmImages fi = new frmImages(frmImages.ImagesFormType.NormalManagement
            ////////    , currentLesson, currentClass, listImages, currentSchoolSubject);
            ////////fi.ShowDialog();
            listImages = Commons.bl.GetListLessonsImages(currentLesson);
            if (listImages.Count > 0)
            {
                indexImages = 0;
                if (listImages.Count > 0)
                {

                    string nomeFile = Path.Combine(Commons.PathImages, listImages[indexImages].RelativePathAndFilename);
                    try
                    {
                        CommonsWpf.loadPicture(picImage,
                            Path.Combine(Commons.PathImages, listImages[indexImages].RelativePathAndFilename));
                        //picImage.Load(nomeFile);
                    }
                    catch
                    {
                        MessageBox.Show("Non è possible aprire il file " + nomeFile + " !");
                    }
                }
            }
            else
            {
                picImage.Source = null;
            }
        }
        //private void dgwOneLesson_CellContentClick(object sender, RoutedEventArgs e)
        //{
        //    ////////            DataGrid grid = (DataGrid)sender;
        //////////int RowIndex = grid.SelectedIndex;
        //////////    if (RowIndex > -1)
        //    ////////{
        //    ////////    Topic row = ((List<Topic>)dgwOneLesson.ItemsSource)[RowIndex];
        //    ////////    topicTreeMptt.FindNodeById(row.Id);
        //    ////////}
        //}
        private void frmLessonsTopics_KeyDown(object sender, KeyEventArgs e)
        {
            checkGeneralKeysForTopicsTree(e);
        }
        private void checkGeneralKeysForTopicsTree(KeyEventArgs e)
        {
            ////////if (e.KeyCode == Keys.F3)
            ////////    topicTreeMptt.FindNodes(txtTopicSearchString.Text, chkMarkAllNodesFound.IsChecked,
            ////////        true, false, false, false);
            ////////if (e.KeyCode == Keys.F5)
            ////////{
            ////////    btnSaveTree_Click(null, null);
            ////////}
        }
        private void checkSpecificKeysForTopicsTree(KeyEventArgs e)
        {
            ////////if (e.KeyCode == Keys.Right)
            ////////{
            ////////    NextImage();
            ////////}
            ////////if (e.KeyCode == Keys.Left)
            ////////{
            ////////    PreviousImage();
            ////////}

            ////////if (e.KeyCode == Keys.F3)
            ////////    topicTreeMptt.FindNodes(txtTopicSearchString.Text, chkMarkAllNodesFound.IsChecked,
            ////////        true, false, false, false);
            ////////if (e.KeyCode == Keys.F5)
            ////////{
            ////////    btnSaveTree_Click(null, null);
            ////////}
        }
        private void PreviousImage()
        {
            if (listImages.Count > 0)
            {
                if (indexImages == 0)
                    indexImages = listImages.Count;
                indexImages--;
                try
                {
                    CommonsWpf.loadPicture(picImage,
                        Path.Combine(Commons.PathImages, listImages[indexImages].RelativePathAndFilename));
                    //picImage.Load(Path.Combine(Commons.PathImages, listImages[indexImages].RelativePathAndFilename));
                }
                catch
                {
                    Console.Beep();
                }
            }
        }
        private void NextImage()
        {
            if (listImages.Count > 0)
            {
                indexImages = ++indexImages % listImages.Count;
                try
                {
                    CommonsWpf.loadPicture(picImage,
                        Path.Combine(Commons.PathImages, listImages[indexImages].RelativePathAndFilename));
                    //picImage.Load(Path.Combine(Commons.PathImages, listImages[indexImages].RelativePathAndFilename));
                }
                catch
                {
                    Console.Beep();
                }
            }
        }
        private void btnTopicsNotDone_Click(object sender, RoutedEventArgs e)
        {
            if (trwTopics.SelectedItem == null)
            {
                MessageBox.Show("Scegliere un argomento.\r\n" +
                    "Verranno evidenziati gli argomenti sotto l'argomento scelto che NON sono stati fatti");
                return;
            }
            List<Topic> listNonDone = Commons.bl.GetTopicsNotDoneFromThisTopic(currentClass,
                (Topic)((TreeViewItem)trwTopics.SelectedItem).Tag, currentSchoolSubject);
            int dummy = 0; bool dummy2 = false;
            topicTreeMptt.HighlightNodesInList((TreeViewItem)trwTopics.Items[0],
                 listNonDone, ref dummy, ref dummy2);
        }
        private void btnTopicsDone_Click(object sender, RoutedEventArgs e)
        {
            if (trwTopics.SelectedItem == null)
            {
                MessageBox.Show("Scegliere un argomento con click.\r\n" +
                    "Verranno evidenziati gli argomenti fatti sotto l'argomento scelto che sono stati fatti");
                return;
            }
            List<Topic> listDone = Commons.bl.GetTopicsDoneFromThisTopic(currentClass, ((Topic)((TreeViewItem)trwTopics.SelectedItem).Tag), currentSchoolSubject);
            int dummy = 0; bool dummy2 = false;
            topicTreeMptt.HighlightNodesInList((TreeViewItem)trwTopics.Items[0],
                 listDone, ref dummy, ref dummy2);
        }
        private void bntLessonErase_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Vuole davvero  eliminare la lezione:\r\n" + txtLessonCode.Text +
                ",'" + TxtLessonDesc.Text + "'?", "Cancellazione", MessageBoxButton.YesNo)
                != MessageBoxResult.Yes)
            {
                return;
            }
            currentRowLessonsGrid = (Lesson)dgwAllLessons.Items[currentIndexLessonsGrid];
            // !! TODO !! add message box to ask for image files deletion
            Commons.bl.EraseLesson(int.Parse(txtLessonCode.Text), false);
            RefreshLessons(currentIndexLessonsGrid);
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            NextImage();
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            PreviousImage();
        }
        private void frmLessons_FormClosed(object sender, RoutedEventArgs e)
        {
            IsFormClosed = true;
        }
        private void btnArgFreemind_Click(object sender, RoutedEventArgs e)
        {
            //ExportSubtreeToClipboard();
            topicTreeMptt.ExportSubtreeToClipboard();
        }
        private void LessonTimer_Tick(object sender, RoutedEventArgs e)
        {
            ////////if (Application.OpenForms[0] != null)
            ////////{
            ////////    lblLessonTime.Background = ((frmMain)Application.OpenForms[0]).CurrentLessonTimeColor;
            ////////}
        }
        private void dgwAllLessons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if (grid != null)
            {
                int RowIndex = grid.SelectedIndex;
                if (RowIndex > -1)
                {

                    txtTopicsDigest.Text = "";
                    List<Lesson> l = ((List<Lesson>)(dgwAllLessons.ItemsSource));

                    if (currentLesson.IdLesson != l[RowIndex].IdLesson)
                    {
                        currentLesson.IdLesson = l[RowIndex].IdLesson;
                        currentLesson.Note = l[RowIndex].Note;
                        currentLesson.Date = l[RowIndex].Date;

                        TxtLessonDesc.Text = currentLesson.Note;
                        dtpLessonDate.Text = ((DateTime)currentLesson.Date).ToString();
                        txtLessonCode.Text = currentLesson.IdLesson.ToString();

                        RefreshTopicsInOneLesson();
                        RefreshTopicsChecksAndImages();
                    }
                }
            }
        }
        //////private void BtnSearchAmongTopics_Click(object sender, RoutedEventArgs e)
        //////{
        //////    int rowToBeSearchedIndex;

        //////    if (dgwAllLessons.SelectedItems == null)
        //////        rowToBeSearchedIndex = 0;
        //////    else
        //////        rowToBeSearchedIndex = dgwAllLessons.SelectedItems[0].Index;
        //////    int indexWhenBeginning = rowToBeSearchedIndex;
        //////    rowToBeSearchedIndex = ++rowToBeSearchedIndex % dgwAllLessons.Items.Count;
        //////    bool allScanned = false;
        //////    while (!allScanned)
        //////    {
        //////        DataGridRow row = dgwAllLessons.Items[rowToBeSearchedIndex];
        //////        if (((string)row.Cells["Note"].Value).Contains(txtTopicsDigest.Text))
        //////        {
        //////            dgwAllLessons.ClearSelection();
        //////            row.Selected = true;
        //////            break;
        //////        }
        //////        rowToBeSearchedIndex = ++rowToBeSearchedIndex % dgwAllLessons.Items.Count;
        //////        if (rowToBeSearchedIndex == indexWhenBeginning)
        //////            allScanned = true;
        //////    }

        //////}
        private void btnOpenImagesFolder_Click(object sender, RoutedEventArgs e)
        {
            string folder = Path.Combine(Commons.PathImages,
                currentClass.SchoolYear + currentClass.Abbreviation,
                "Lessons", currentSchoolSubject.IdSchoolSubject);
            try
            {
                Commons.ProcessStartLink(folder);
            }
            catch
            {
                MessageBox.Show("La cartella non è stata ancora creata.\nIl programma la creerà automaticamente quando verrà salvata la prima immagine.");
            }
        }
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Da fare!");
        }
        private void btnAddNodeBrother_Click(object sender, RoutedEventArgs e)
        {
            topicTreeMptt.AddNewNode("Nuovo argomento", false);
            // set focus to the name textBox
            ////txtTopicName.Focus();
        }
        private void btnFindUnderNode_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Da fare!");
            //return; 
            topicTreeMptt.FindNodeUnderNode(txtTopicSearchString.Text);
        }
        private void chksSearch_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (!isLoading)
            {
                // event fired when any of the checkboxes related to search is changed 

                // fire a new search 
                topicTreeMptt.ResetSearch();
                topicTreeMptt.FindNodes(txtTopicSearchString.Text);
            }
        }
    }
}
