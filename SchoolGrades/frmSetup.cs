using gamon;
using SchoolGrades.BusinessObjects;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmSetup : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NewDatabaseFile { get; private set; }

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
            //TxtPathStartLinks.Text = Commons.PathStartLinks; // not longer used

            TxtPathDocuments.Text = Commons.PathDocuments;
            chkSaveBackup.Checked = Commons.SaveBackupWhenExiting;
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
                // Questo previene la modifica dei dati mentre sono in uso.
                // Il timeout è una sicurezza per evitare blocchi indefiniti.
                int waitCycles = 0;
                while (Commons.BackgroundThreadIsSaving && waitCycles < 10) // Attendi max 5 secondi
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

                MessageBox.Show("File di configurazione salvato.\n\nIl programma verrà riavviato per applicare le modifiche.",
                                "Configurazione salvata", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Usa Application.Restart() per una chiusura e un riavvio più puliti
                // invece di Application.Exit(). Questo dà al programma la possibilità
                // di finalizzare le operazioni in modo più ordinato.
                NewDatabaseFile = true;
                Application.Restart();
                Environment.Exit(0); // Assicura la chiusura completa dopo il riavvio
            }
            catch (Exception e)
            {
                string err = "WriteConfigFile(): " + e.Message;
                Commons.ErrorLog(err);
                // Non rilanciare l'eccezione qui, ma mostrala all'utente
                MessageBox.Show("Si è verificato un errore durante il salvataggio della configurazione:\n" + err,
                                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
