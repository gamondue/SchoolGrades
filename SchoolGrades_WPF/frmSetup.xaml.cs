using SchoolGrades;
using System.Windows;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmSetup.xaml
    /// </summary>
    public partial class frmSetup : Window
    {
        public bool NewDatabaseFile { get; private set; }


        public frmSetup()
        {
            InitializeComponent();
            NewDatabaseFile = false;
        }

        private void frmSetup_Load(object sender, RoutedEventArgs e)
        {
            ////CommonsWpf.ReadConfigFile();
            //TxtPathDatabase.Text = Commons.PathDatabase;
            //TxtFileDatabase.Text = System.IO.Path.GetFileName(Commons.PathAndFileDatabase);
            //TxtPathImages.Text = Commons.PathImages;
            ////TxtPathStartLinks.Text = Commons.PathStartLinks; // not longer used

            //TxtPathDocuments.Text = Commons.PathDocuments;
            //chkSaveBackup.IsChecked = Commons.SaveBackupWhenExiting;
        }
        private void btnTabelle_Click(object sender, RoutedEventArgs e)
        {
            frmTables f = new frmTables();
            f.ShowDialog();
        }
        private void btnClassi_Click(object sender, RoutedEventArgs e)
        {
            //frmClassesManagement f = new frmClassesManagement();
            //f.ShowDialog();
        }
        private void btnBackupManagement_Click(object sender, RoutedEventArgs e)
        {
            frmBackupManagement f = new frmBackupManagement();
            f.ShowDialog();
        }
        private void btnSaveConfiguration_Click(object sender, RoutedEventArgs e)
        {
            WriteConfigFile();
        }
        internal void WriteConfigFile()
        {
            //            string[] dati = new string[6];
            //            try
            //            {
            //                if (!Directory.Exists(Commons.PathConfig))
            //                    Directory.CreateDirectory(Commons.PathConfig);

            //                if (!Directory.Exists(Commons.PathLogs))
            //                    Directory.CreateDirectory(Commons.PathLogs);

            //                Commons.DatabaseFileName_Current = dati[0] = TxtFileDatabase.Text;

            //                Commons.PathImages = dati[1] = TxtPathImages.Text;
            //                if (!Directory.Exists(Commons.PathImages))
            //                    Directory.CreateDirectory(Commons.PathImages);

            //                // postition 2 was held by PathStartLinks, that is not longer used,
            //                // substituted by PathRestrictedApp  (attribute of the single school class) 
            //                //dati[2] = Commons.PathRestrictedApp; 

            //                Commons.PathDatabase = dati[3] = TxtPathDatabase.Text;
            //                if (!Directory.Exists(Commons.PathDatabase))
            //                    Directory.CreateDirectory(Commons.PathDatabase);

            //                Commons.PathDocuments = dati[4] = TxtPathDocuments.Text;
            //                if (!Directory.Exists(Commons.PathDocuments))
            //                {
            //                    if (Commons.PathDocuments != "")
            //                        Directory.CreateDirectory(Commons.PathDocuments);
            //                    else
            //                        Commons.PathDocuments = ".";
            //                }

            //                Commons.SaveBackupWhenExiting = chkSaveBackup.IsChecked;
            //                dati[5] = Commons.SaveBackupWhenExiting.ToString();

            //                //////////Commons.PathAndFileDatabase = Path.Combine(Commons.PathDatabase, Commons.DatabaseFileName_Current);
            //                // TODO !!! if the file doesn't exist copies the sample empty database. Eventually redo this code, it is ugly and not functional !!!!
            //                ////if(!File.Exists(Commons.PathAndFileDatabase))
            //                ////    File.Copy(".\\" + Commons.TeachersDatabaseFileName, Commons.PathAndFileDatabase);
            //#if DEBUG
            //                TextFile.ArrayToFile(Commons.PathAndFileConfig + "_DEBUG", dati, false);
            //#else
            //                TextFile.ArrayToFile(Commons.PathAndFileConfig, dati, false);
            //#endif

            //                MessageBox.Show("File di configurazione salvato in " + Commons.PathAndFileConfig +
            //                    "\n\nIl programma verrà chiuso.");

            //                Application.Exit();
            //            }
            //            catch (Exception e)
            //            {
            //                string err = "WriteConfigFile(): " + e.Message;
            //                Commons.ErrorLog(err);
            //                throw new Exception(err);
            //                //throw new FileNotFoundException(@"[Error in program's directories] \r\n" + e.Message);
            //                //return;
            //            }
            //            //Application.Exit();
            //            NewDatabaseFile = true;
            //            this.Close();
        }
        private void btnPathDatabase_Click(object sender, RoutedEventArgs e)
        {
            //folderBrowserDialog1.SelectedPath = TxtPathDatabase.Text;
            //DialogResult r = folderBrowserDialog1.ShowDialog();
            //if (r == System.Windows.Forms.DialogResult.OK)
            //{
            //    TxtPathDatabase.Text = folderBrowserDialog1.SelectedPath;
            //}
            //Commons.PathDatabase = TxtPathDatabase.Text;
            //Commons.PathAndFileDatabase = Path.Combine(Commons.PathDatabase, Commons.DatabaseFileName_Current);
        }
        private void btnTopicsManagement_Click(object sender, RoutedEventArgs e)
        {
            frmTopics f = new frmTopics(frmTopics.TopicsFormType.ShowAndManagement, null, null);
            f.ShowDialog();
        }
        private void btnTagsManagement_Click(object sender, RoutedEventArgs e)
        {
            //frmTag t = new frmTag(false);
            //t.ShowDialog();
        }
        private void btnStartLimksManagement_Click(object sender, RoutedEventArgs e)
        {

            //Class dummy = new Class();
            ////dummy.IdSchool = 
            ////dummy.SchoolYear = curre
            //frmStartLinksManagement frm = new frmStartLinksManagement(dummy);
            //frm.ShowDialog();
        }
        private void btnQuestionManagement_Click(object sender, RoutedEventArgs e)
        {
            //    //frmQuestion form = new frmQuestion(frmQuestion.QuestionFormType.CreateSeveralQuestions,
            //    //    null, null, null, null); 
            //    frmQuestionChoose form = new frmQuestionChoose(null, null, null);
            //    form.ShowDialog();
        }
        private void btnTestManagement_Click(object sender, RoutedEventArgs e)
        {
            //frmTestManagement frm = new frmTestManagement();
            //frm.ShowDialog();
        }
        private void btnRecoverTopics_Click(object sender, RoutedEventArgs e)
        {

            //frmTopicsRecover rt = new frmTopicsRecover();
            //rt.ShowDialog();
        }
        private void btnPathDocument_Click(object sender, RoutedEventArgs e)
        {
            //folderBrowserDialog1.SelectedPath = TxtPathDocuments.Text;
            //DialogResult r = folderBrowserDialog1.ShowDialog();
            //if (r == System.Windows.Forms.DialogResult.OK)
            //{
            //    TxtPathDocuments.Text = folderBrowserDialog1.SelectedPath;
            //}
        }
        private void btnEraseConfigurationFile_Click(object sender, RoutedEventArgs e)
        {
            //File.Delete(Commons.PathAndFileConfig);
            ////this.Close();
            //Application.Exit();
        }
        private void btnSchoolSubjectManagement_Click(object sender, RoutedEventArgs e)
        {
            //frmSchoolSubjectManagement f = new frmSchoolSubjectManagement();
            //f.ShowDialog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("ATTENZIONE: devo cancellare TUTTO il database?\n(Tutti i dati verranno persi!)",
              "CANCELLAZIONE", MessageBoxButton.YesNo, MessageBoxImage.Warning)
              == MessageBoxResult.Yes)
            {
                Commons.bl.PurgeDatabase();
            }
        }
        private void btnSchoolPeriodsManagement_Click(object sender, RoutedEventArgs e)
        {
            frmSchoolYearAndPeriodsManagement f = new frmSchoolYearAndPeriodsManagement();
            f.ShowDialog();
        }
    }
}
