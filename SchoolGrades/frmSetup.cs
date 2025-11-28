using gamon;
using SchoolGrades.BusinessObjects;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SchoolGrades.Localization;
using System.Linq;

namespace SchoolGrades
{
    public partial class frmSetup : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NewDatabaseFile { get; private set; }

        private bool _languageChanged = false;
        public frmSetup()
        {
            InitializeComponent();
            NewDatabaseFile = false;
        }
        private void frmSetup_Load(object sender, EventArgs e)
        {
            TxtPathDatabase.Text = Commons.PathDatabase;
            TxtFileDatabase.Text = Path.GetFileName(Commons.PathAndFileDatabase);
            TxtPathImages.Text = Commons.PathImages;
            TxtPathDocuments.Text = Commons.PathDocuments;
            chkSaveBackup.Checked = Commons.SaveBackupWhenExiting;

            // Initialize language combo
            InitializeLanguageCombo();

            // Localize UI elements
            LocalizeForm();
        }

        private void LocalizeForm()
        {
            try
            {
                // Form title
                this.Text = Loc.Get("Setup_Title");

                // Buttons
                btnClassesManagement.Text = Loc.Get("Setup_ClassesManagement");
                btnBackupManagement.Text = Loc.Get("Setup_BackupManagement");
                btnStudentsManagement.Text = Loc.Get("Setup_StudentsManagement");
                btnTopicsManagement.Text = Loc.Get("Setup_TopicsManagement");
                btnTagsManagement.Text = Loc.Get("Setup_TagsManagement");
                btnStartLinksManagenet.Text = Loc.Get("Setup_StartLinksManagement");
                btnSchoolSubjectManagement.Text = Loc.Get("Setup_SchoolSubjectManagement");
                btnSchoolPeriodsManagement.Text = Loc.Get("Setup_SchoolPeriodsManagement");
                btnRecoverTopics.Text = Loc.Get("Setup_RecoverTopics");
                btnUsersManagement.Text = Loc.Get("Setup_UsersManagement");
                btnQuestionManagement.Text = Loc.Get("Setup_QuestionManagement");
                btnTestManagement.Text = Loc.Get("Setup_TestManagement");
                btnTablesManagement.Text = Loc.Get("Setup_TablesManagement");
                btnSaveConfigurationFile.Text = Loc.Get("Setup_SaveConfig");
                btnOpenConfigurationFolder.Text = Loc.Get("Setup_OpenConfigFolder");
                btnEraseConfigurationFile.Text = Loc.Get("Setup_EraseConfig");
                BtnUseDemo.Text = Loc.Get("Setup_UseDemo");
                btnResetDatabase.Text = Loc.Get("Setup_ResetDatabase");

                // Labels
                lblPathDatabase.Text = Loc.Get("Setup_DatabasePath");
                lblFileDatabase.Text = Loc.Get("Setup_DatabaseFile");
                lblPathImages.Text = Loc.Get("Setup_ImagesPath");
                lblPathDocuments.Text = Loc.Get("Setup_DocumentsPath");
                lblLanguage.Text = Loc.Get("Setup_Language");

                // Checkboxes
                chkAskPassword.Text = Loc.Get("Setup_AskPassword");
                chkSaveBackup.Text = Loc.Get("Setup_SaveBackupOnExit");

                // Tooltips
                toolTip1.SetToolTip(btnClassesManagement, Loc.Get("Setup_Tooltip_ClassesManagement"));
                toolTip1.SetToolTip(btnBackupManagement, Loc.Get("Setup_Tooltip_BackupManagement"));
                toolTip1.SetToolTip(btnStudentsManagement, Loc.Get("Setup_Tooltip_StudentsManagement"));
                toolTip1.SetToolTip(btnTopicsManagement, Loc.Get("Setup_Tooltip_TopicsManagement"));
                toolTip1.SetToolTip(btnTagsManagement, Loc.Get("Setup_Tooltip_TagsManagement"));
                toolTip1.SetToolTip(btnStartLinksManagenet, Loc.Get("Setup_Tooltip_StartLinksManagement"));
                toolTip1.SetToolTip(btnRecoverTopics, Loc.Get("Setup_Tooltip_RecoverTopics"));
                toolTip1.SetToolTip(btnUsersManagement, Loc.Get("Setup_Tooltip_UsersManagement"));
                toolTip1.SetToolTip(btnQuestionManagement, Loc.Get("Setup_Tooltip_QuestionManagement"));
                toolTip1.SetToolTip(btnTestManagement, Loc.Get("Setup_Tooltip_TestManagement"));
                toolTip1.SetToolTip(btnTablesManagement, Loc.Get("Setup_Tooltip_TablesManagement"));
                toolTip1.SetToolTip(chkAskPassword, Loc.Get("Setup_Tooltip_AskPassword"));
                toolTip1.SetToolTip(chkSaveBackup, Loc.Get("Setup_Tooltip_SaveBackupOnExit"));
                toolTip1.SetToolTip(cmbLanguage, Loc.Get("Setup_Tooltip_Language"));
                toolTip1.SetToolTip(btnSchoolPeriodsManagement, Loc.Get("Setup_Tooltip_SchoolPeriodsManagement"));
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"frmSetup.LocalizeForm: Error in localization: {ex.Message}");
            }
        }
        private void btnTablesManagement_Click(object sender, EventArgs e)
        {
            frmLookupTablesChoose f = new frmLookupTablesChoose();
            f.ShowDialog();
        }
        private void btnClassesManagement_Click(object sender, EventArgs e)
        {
            frmClassesManagement f = new frmClassesManagement();
            f.ShowDialog();
        }
        private void btnBackupManagement_Click(object sender, EventArgs e)
        {
            frmBackupManagement f = new frmBackupManagement();
            f.ShowDialog();
        }
        private void btnChooseFile_Click(object sender, EventArgs e)
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
        private void btnImageFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = TxtPathImages.Text;
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtPathImages.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            WriteConfigFile();
        }
        internal void WriteConfigFile()
        {
            try
            {
                // 1. Segnala a tutti i thread in background di terminare
                Commons.BackgroundTaskClose = true;

                // 2. Attendi che i thread in background terminino effettivamente.
                int waitCycles = 0;
                while (Commons.BackgroundThreadIsSaving && waitCycles < 10)
                {
                    Thread.Sleep(500);
                    waitCycles++;
                }

                // 3. Ora che i thread sono fermi, possiamo modificare i dati in sicurezza
                string[] dati = new string[6];
                Commons.DatabaseFileName_Current = dati[0] = TxtFileDatabase.Text;
                Commons.PathDatabase = dati[3] = TxtPathDatabase.Text;
                Commons.PathImages = dati[1] = TxtPathImages.Text;
                Commons.PathDocuments = dati[4] = TxtPathDocuments.Text;
                Commons.SaveBackupWhenExiting = chkSaveBackup.Checked;
                dati[5] = Commons.SaveBackupWhenExiting.ToString();

#if DEBUG
                TextFile.ArrayToFile(Commons.PathAndFileConfig + "_DEBUG", dati, false);
#else
                TextFile.ArrayToFile(Commons.PathAndFileConfig, dati, false);
#endif

                MessageBox.Show(Loc.Get("Setup_ConfigSaved"),
                                Loc.Get("Setup_ConfigSavedTitle"), 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);

                NewDatabaseFile = true;
                Application.Restart();
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                string err = "WriteConfigFile(): " + e.Message;
                Commons.ErrorLog(err);
                MessageBox.Show(Loc.Get("Setup_ConfigError") + "\n" + err,
                                Loc.Get("Common_Error"), 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
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
            // Segnala ai thread di chiudersi prima di uscire
            Commons.BackgroundTaskClose = true;
            Thread.Sleep(500); // Dai un po' di tempo per la chiusura
            File.Delete(Commons.PathAndFileConfig);
            Application.Restart();
            Environment.Exit(0);
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
        private void TxtPaths_DoubleClick(object sender, EventArgs e)
        {
            Commons.ProcessStartLink(((TextBox)sender).Text);
        }
        private void TxtPathStartLinks_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnUsersManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Loc.Get("Setup_FormToComplete"));
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
            if (MessageBox.Show(Loc.Get("Setup_ResetDatabaseConfirm"),
                Loc.Get("Setup_ResetDatabaseTitle"), 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning, 
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Commons.bl.PurgeDatabase();
            }
        }
        private void btnStudentsManagement_Click(object sender, EventArgs e)
        {
            frmStudent f = new frmStudent(null, false);
            f.ShowDialog();
        }
        private void TxtFileDatabase_DoubleClick(object sender, EventArgs e)
        {
            string PathFileDatabase = Path.Combine(TxtPathDatabase.Text, ((TextBox)sender).Text);
            Commons.ProcessStartLink(PathFileDatabase);
        }
        private void InitializeLanguageCombo()
        {
            // Popola combo lingue usando il controllo già presente nel Designer
            var combo = cmbLanguage;
            
            // IMPORTANTE: Prima di impostare DataSource, rimuovi l'event handler
            combo.SelectedIndexChanged -= cmbLanguage_SelectedIndexChanged;

            // Popola combo lingue
            var languages = LocalizationManager.SupportedLanguages
                .Select(kvp => new { Code = kvp.Key, Name = kvp.Value })
                .ToList();

            combo.DataSource = languages;
            combo.DisplayMember = "Name";
            combo.ValueMember = "Code";
            
            // Trova l'indice corretto invece di usare SelectedValue
            var currentLang = LocalizationManager.CurrentLanguage;
            for (int i = 0; i < languages.Count; i++)
            {
                if (languages[i].Code == currentLang)
                {
                    combo.SelectedIndex = i;
                    break;
                }
            }
            
            // Ri-aggiungi l'event handler DOPO aver impostato la selezione
            combo.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            
            // Imposta il testo della label con la localizzazione
            lblLanguage.Text = Loc.Get("Setup_Language");
        }
        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo?.SelectedValue == null)
                return;

            string selectedLanguage = combo.SelectedValue.ToString();
            
            // Log per debug
            Commons.ErrorLog($"cmbLanguage_SelectedIndexChanged: Selected language = '{selectedLanguage}', Current = '{LocalizationManager.CurrentLanguage}'");

            if (selectedLanguage != LocalizationManager.CurrentLanguage)
            {
                try
                {
                    LocalizedMessageBox.ShowInformation("Messages_LanguageChangedRestart");
                    LocalizationManager.ChangeLanguage(selectedLanguage);
                    _languageChanged = true;
                }
                catch (Exception ex)
                {
                    Commons.ErrorLog($"cmbLanguage_SelectedIndexChanged: Error changing language: {ex.Message}");
                    MessageBox.Show(Loc.Get("Setup_ConfigError") + " " + ex.Message, 
                        Loc.Get("Common_Error"), 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (_languageChanged)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }
    }
}
