using gamon;
using SchoolGrades.BusinessObjects;
using SharedWinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class FrmSetup : Form
    {
        public bool NewDatabaseFile { get; private set; }

        public FrmSetup()
        {
            InitializeComponent();
            NewDatabaseFile = false;
        }
        private void frmSetup_Load(object sender, EventArgs e)
        {
            //CommonsWinForms.ReadConfigFile();
            TxtPathDatabase.Text = Commons.PathDatabase;
            TxtFileDatabase.Text = Path.GetFileName(Commons.PathAndFileDatabase);
            TxtPathImages.Text = Commons.PathImages;
            //TxtPathStartLinks.Text = Commons.PathStartLinks; // not longer used

            TxtPathDocuments.Text = Commons.PathDocuments;
            chkSaveBackup.Checked = CommonsWinForms.SaveBackupWhenExiting;
        }
        private void BtnTabelle_Click(object sender, EventArgs e)
        {
            frmTables f = new frmTables();
            f.ShowDialog();
        }
        private void BtnClassi_Click(object sender, EventArgs e)
        {
            frmClassesManagement f = new frmClassesManagement();
            f.ShowDialog();
        }
        private void btnBackupManagement_Click(object sender, EventArgs e)
        {
            frmBackupManagement f = new frmBackupManagement();
            f.ShowDialog();
        }
        private void btnScegliFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = TxtPathDatabase.Text;
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtFileDatabase.Text = Path.GetFileName(openFileDialog1.FileName);
                TxtPathDatabase.Text = Path.GetDirectoryName(openFileDialog1.FileName);
            }
            Commons.DatabaseFileName_Current = TxtFileDatabase.Text;
            Commons.PathAndFileDatabase = Path.Combine(Commons.PathDatabase, Commons.DatabaseFileName_Current);
        }
        private void btnCartellaImmagini_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = TxtPathImages.Text;
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtPathImages.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteConfigFile();
        }
        internal void WriteConfigFile()
        {
            string[] dati = new string[6];
            try
            {
                if (!Directory.Exists(Commons.PathConfig))
                    Directory.CreateDirectory(Commons.PathConfig);

                if (!Directory.Exists(Commons.PathLogs))
                    Directory.CreateDirectory(Commons.PathLogs);

                Commons.DatabaseFileName_Current = dati[0] = TxtFileDatabase.Text;

                Commons.PathImages = dati[1] = TxtPathImages.Text;
                if (!Directory.Exists(Commons.PathImages))
                    Directory.CreateDirectory(Commons.PathImages);

                // postition 2 was held by PathStartLinks, that is not longer used,
                // substituted by PathRestrictedApp  (attribute of the single school class) 
                //dati[2] = Commons.PathRestrictedApp; 

                Commons.PathDatabase = dati[3] = TxtPathDatabase.Text;
                if (!Directory.Exists(Commons.PathDatabase))
                    Directory.CreateDirectory(Commons.PathDatabase);

                Commons.PathDocuments = dati[4] = TxtPathDocuments.Text;
                if (!Directory.Exists(Commons.PathDocuments))
                {
                    if (Commons.PathDocuments != "")
                        Directory.CreateDirectory(Commons.PathDocuments);
                    else
                        Commons.PathDocuments = ".";
                }

                CommonsWinForms.SaveBackupWhenExiting = chkSaveBackup.Checked;
                dati[5] = CommonsWinForms.SaveBackupWhenExiting.ToString();

                //////////Commons.PathAndFileDatabase = Path.Combine(Commons.PathDatabase, Commons.DatabaseFileName_Current);
                // TODO !!! if the file doesn't exist copies the sample empty database. Eventually redo this code, it is ugly and not functional !!!!
                ////if(!File.Exists(Commons.PathAndFileDatabase))
                ////    File.Copy(".\\" + Commons.TeachersDatabaseFileName, Commons.PathAndFileDatabase);
#if DEBUG
                TextFile.ArrayToFile(Commons.PathAndFileConfig + "_DEBUG", dati, false);
#else
                TextFile.ArrayToFile(Commons.PathAndFileConfig, dati, false);
#endif

                MessageBox.Show("File di configurazione salvato in " + Commons.PathAndFileConfig +
                    "\n\nIl programma verrà chiuso.");

                Application.Exit();
            }
            catch (Exception e)
            {
                string err = "WriteConfigFile(): " + e.Message;
                Commons.ErrorLog(err);
                throw new Exception(err);
                //throw new FileNotFoundException(@"[Error in program's directories] \r\n" + e.Message);
                //return;
            }
            //Application.Exit();
            NewDatabaseFile = true;
            this.Close();
        }
        private void btnPathQuestions_Click(object sender, EventArgs e)
        {
            //folderBrowserDialog1.SelectedPath = TxtPathStartLinks.Text;
            //DialogResult r = folderBrowserDialog1.ShowDialog();
            //if (r == System.Windows.Forms.DialogResult.OK)
            //{
            //    TxtPathStartLinks.Text = folderBrowserDialog1.SelectedPath;
            //}
        }
        private void btnPathDatabase_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = TxtPathDatabase.Text;
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtPathDatabase.Text = folderBrowserDialog1.SelectedPath;
            }
            Commons.PathDatabase = TxtPathDatabase.Text;
            Commons.PathAndFileDatabase = Path.Combine(Commons.PathDatabase, Commons.DatabaseFileName_Current);
        }
        private void btnTopicsManagement_Click(object sender, EventArgs e)
        {
            frmTopics f = new frmTopics(frmTopics.TopicsFormType.ShowAndManagement, null, null);
            f.ShowDialog();
            f.Dispose();
        }
        private void btnTagsManagement_Click(object sender, EventArgs e)
        {
            frmTag t = new frmTag(false);
            t.ShowDialog();
        }
        private void btnStartLinksManagenet_Click(object sender, EventArgs e)
        {
            Class dummy = new Class();
            //dummy.IdSchool = 
            //dummy.SchoolYear = curre
            frmStartLinksManagement frm = new frmStartLinksManagement(dummy);
            frm.ShowDialog();
        }
        private void btnQuestionManagement_Click(object sender, EventArgs e)
        {
            //frmQuestion form = new frmQuestion(frmQuestion.QuestionFormType.CreateSeveralQuestions,
            //    null, null, null, null); 
            frmQuestionChoose form = new frmQuestionChoose(null, null, null);
            form.ShowDialog();
        }
        private void btnTestManagement_Click(object sender, EventArgs e)
        {
            frmTestManagement frm = new frmTestManagement();
            frm.ShowDialog();
        }
        private void btnRecoverTopics_Click(object sender, EventArgs e)
        {
            frmTopicsRecover rt = new frmTopicsRecover();
            rt.ShowDialog();
        }
        private void btnPathDocuments_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = TxtPathDocuments.Text;
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtPathDocuments.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void btnEraseConfigurationFile_Click(object sender, EventArgs e)
        {
            File.Delete(Commons.PathAndFileConfig);
            //this.Close();
            Application.Exit();
        }
        private void btnSchoolSubjectManagement_Click(object sender, EventArgs e)
        {
            frmSchoolSubjectManagement f = new frmSchoolSubjectManagement();
            f.ShowDialog();
        }
        private void btnOpenConfigurationFolder_Click(object sender, EventArgs e)
        {
            Commons.ProcessStartLink(Commons.PathConfig);
        }
        private void BtnUseDemo_Click(object sender, EventArgs e)
        {

        }
        private void TxtPathDatabase_TextChanged(object sender, EventArgs e)
        {

        }
        private void TxtPathImages_TextChanged(object sender, EventArgs e)
        {

        }
        private void TxtPathDocuments_TextChanged(object sender, EventArgs e)
        {

        }
        private void TxtPaths_DoubleClick(object sender, EventArgs e)
        {
            Commons.ProcessStartLink(((TextBox)sender).Text);
        }
        private void TxtFileDatabase_TextChanged(object sender, EventArgs e)
        {

        }
        private void TxtPathStartLinks_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnUsersManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Form da completare!");
            frmUsersManagement f = new frmUsersManagement();
            f.Show();
        }
        private void btnSchoolPeriodsManagement_Click(object sender, EventArgs e)
        {
            frmSchoolYearAndPeriodsManagement f = new frmSchoolYearAndPeriodsManagement();
            f.ShowDialog();
        }
        private void btnResetDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ATTENZIONE: devo cancellare TUTTO il database?\n(Tutti i dati verranno persi!)",
                "CANCELLAZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                Commons.bl.PurgeDatabase();
            }
        }
    }
}
