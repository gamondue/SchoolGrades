using gamon;
using SchoolGrades.DbClasses;
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
            Commons.ReadConfigFile();
            TxtPathImages.Text = Commons.PathImages;
            TxtPathStartLinks.Text = Commons.PathStartLinks; // not longer used
            TxtPathDatabase.Text = Commons.PathDatabase;
            TxtFileDatabase.Text = Commons.FileDatabase;
            Commons.PathAndFileDatabase = Commons.PathDatabase + "\\" + Commons.FileDatabase;
            TxtPathDocuments.Text = Commons.PathDocuments;
            chkSaveBackup.Checked = Commons.SaveBackupWhenExiting; 
        }

        private void BtnTabelle_Click(object sender, EventArgs e)
        {
            frmTables f = new frmTables();
            f.ShowDialog(); 
        }

        private void BtnClassi_Click(object sender, EventArgs e)
        {
            FrmClassesManagement f = new FrmClassesManagement();
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
            Commons.FileDatabase = TxtFileDatabase.Text;
            Commons.PathAndFileDatabase = Commons.PathDatabase + "\\" + Commons.FileDatabase;
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

        private void WriteConfigFile()
        {
            string[] dati = new string[6];
            try
            {
                if (!Directory.Exists(Commons.PathConfig))
                    Directory.CreateDirectory(Commons.PathConfig);

                if (!Directory.Exists(Commons.PathLogs))
                    Directory.CreateDirectory(Commons.PathLogs);

                Commons.PathImages = dati[1] = TxtPathImages.Text;
                if (!Directory.Exists(Commons.PathImages))
                    Directory.CreateDirectory(Commons.PathImages);

                // path of the startlinks (PathStartLinks) is not longer used, substituted by PathRestrictedApp
                Commons.PathStartLinks = dati[2] = TxtPathStartLinks.Text;
                if (!Directory.Exists(Commons.PathStartLinks))
                    Directory.CreateDirectory(Commons.PathStartLinks);

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
                Commons.FileDatabase = dati[0] = TxtFileDatabase.Text;

                Commons.SaveBackupWhenExiting = chkSaveBackup.Checked;
                dati[5] = Commons.SaveBackupWhenExiting.ToString(); 

                Commons.PathAndFileDatabase = Commons.PathDatabase + "\\" + Commons.FileDatabase;
                if(!File.Exists(Commons.PathAndFileDatabase))
                    File.Copy(".\\SchoolGrades.sqlite", Commons.PathAndFileDatabase);
#if DEBUG
                TextFile.ArrayToFile(Commons.PathAndFileConfig + "_DEBUG", dati, false);
#else
                TextFile.ArrayToFile(Commons.PathAndFileConfig, dati, false);
#endif

                MessageBox.Show("File di configurazione salvato in " + Commons.PathAndFileConfig);
            }
            catch (Exception e)
            {
                Commons.ErrorLog(e.Message, false);
                return; 
                //throw new FileNotFoundException(@"[Error in program's directories] \r\n" + e.Message);
            }
            //Application.Exit();
            NewDatabaseFile = true; 
            this.Close();
        }
        private void btnPathQuestions_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = TxtPathStartLinks.Text;
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtPathStartLinks.Text = folderBrowserDialog1.SelectedPath;
            }
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
            Commons.PathAndFileDatabase = Commons.PathDatabase + "\\" + Commons.FileDatabase;
        }

        private void btnTopicsManagement_Click(object sender, EventArgs e)
        {
            frmTopics f = new frmTopics(frmTopics.TopicsFormType.NormalManagement,
                null, null, null);  
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
            FrmSchoolSubjectManagement f = new FrmSchoolSubjectManagement();
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
            MessageBox.Show("Parte da fare"); 
        }
    }
}
