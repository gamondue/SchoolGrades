using SchoolGrades.BusinessObjects;
using gamon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using gamon.TreeMptt;

namespace SchoolGrades
{
    public partial class frmBackupManagement : Form
    {
        TreeMptt topicTreeMptt; 

        private string schoolYear;
        Class currentClass;

        public frmBackupManagement()
        {
            InitializeComponent();

            TreeMpttDb dbMptt = new TreeMpttDb(Commons.dl);

            topicTreeMptt = new TreeMptt(Commons.dl, null, null, null, null, null, 
                null, null, null, null, null, null, DragDropEffects.None);
        }
        private void frmBackupManagement_Load(object sender, EventArgs e)
        {
            List<SchoolYear> ly = Commons.bl.GetSchoolYearsThatHaveClasses();
            CmbSchoolYear.DataSource = ly;
            if (ly.Count > 0)
                CmbSchoolYear.SelectedItem = ly[ly.Count - 1];

            schoolYear = CmbSchoolYear.SelectedItem.ToString();

            lstClasses.DataSource = Commons.bl.GetClassesOfYear(Commons.IdSchool, schoolYear);
        }
        private void btnBackupTables_Click(object sender, EventArgs e)
        {
            //db.BackupTableTsv("SchoolSubjects");
            //db.BackupTableTsv("TestTypes");
            //db.BackupTableTsv("QuestionTypes");
            ////db.BackupTableTsv("AnswerTypes");
            //db.BackupTableTsv("GradeTypes");
            //db.BackupTableTsv("GradeCategories");
            //db.BackupTableTsv("Schools");
            //db.BackupTableTsv("SchoolYears");
            //db.BackupTableTsv("SchoolPeriods");

            Commons.bl.BackupTableXml("SchoolSubjects");
            Commons.bl.BackupTableXml("TestTypes");
            Commons.bl.BackupTableXml("QuestionTypes");
            //Commons.bl.BackupTableXml("AnswerTypes");
            Commons.bl.BackupTableXml("GradeTypes");
            Commons.bl.BackupTableXml("GradeCategories");
            Commons.bl.BackupTableXml("Schools");
            Commons.bl.BackupTableXml("SchoolYears");
            Commons.bl.BackupTableXml("SchoolPeriods");
            MessageBox.Show("Salvataggio tabelle terminato");
        }
        private void btnClassBackup_Click(object sender, EventArgs e)
        {
            if (currentClass == null)
            {
                MessageBox.Show("Scegliere la classe da tenere nel database");
                return; 
            }
            string imagesFolder = Commons.bl.CreateOneClassOnlyDatabase(currentClass);
            if (imagesFolder != "")
                Commons.ProcessStartLink(imagesFolder);
            else
                MessageBox.Show("Cartella del database della classe non trovata"); 
            //MessageBox.Show("Fatto"); 
        }
        private void cmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstClasses.DataSource = Commons.bl.GetClassesOfYear(Commons.IdSchool, CmbSchoolYear.Text);
        }
        private void lstClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //classeCorrente = new Classe(nomeFile); 
            currentClass = (Class)lstClasses.SelectedItem;
        }
        private void lstClassi_DoubleClick(object sender, EventArgs e)
        {
            //DataTable students = db.GetClass(school, schoolYear, lstClasses.SelectedItem.ToString());
        }
        private void btnRestoreTables_Click(object sender, EventArgs e)
        {
            //db.RestoreTableTsv("SchoolSubjects", rdbRestoreErasing.Checked);
            //db.RestoreTableTsv("TestTypes", rdbRestoreErasing.Checked);
            //db.RestoreTableTsv("QuestionTypes", rdbRestoreErasing.Checked);
            ////db.RestoreTableTsv("AnswerTypes", rdbRestoreErasing.Checked);
            //db.RestoreTableTsv("GradeTypes", rdbRestoreErasing.Checked);
            //db.RestoreTableTsv("GradeCategories", rdbRestoreErasing.Checked);
            //db.RestoreTableTsv("Schools", rdbRestoreErasing.Checked);
            //db.RestoreTableTsv("SchoolYears", rdbRestoreErasing.Checked);
            //db.RestoreTableTsv("SchoolPeriods", rdbRestoreErasing.Checked);

            Commons.bl.RestoreTableXml("SchoolSubjects", rdbRestoreErasing.Checked);
            Commons.bl.RestoreTableXml("TestTypes", rdbRestoreErasing.Checked);
            Commons.bl.RestoreTableXml("QuestionTypes", rdbRestoreErasing.Checked);
            //db.RestoreTableXml("AnswerTypes", rdbRestoreErasing.Checked);
            Commons.bl.RestoreTableXml("GradeTypes", rdbRestoreErasing.Checked);
            Commons.bl.RestoreTableXml("GradeCategories", rdbRestoreErasing.Checked);
            Commons.bl.RestoreTableXml("Schools", rdbRestoreErasing.Checked);
            Commons.bl.RestoreTableXml("SchoolYears", rdbRestoreErasing.Checked);
            Commons.bl.RestoreTableXml("SchoolPeriods", rdbRestoreErasing.Checked);
            MessageBox.Show("Ripristino tabelle terminato");
        }
        private void btnBackupTopics_Click(object sender, EventArgs e)
        {
            //db.BackupTableTsv("Topics");
            Commons.bl.BackupTableXml("Topics");
            MessageBox.Show("Backup argomenti terminato");
        }
        private void btnExportTopics_Click(object sender, EventArgs e)
        {
            //Topic initial = ((Topic)trwTopics.SelectedNode.Tag);
            string tree = topicTreeMptt.CreateTextTreeOfDescendants(0, int.MaxValue, true);
            TextFile.StringToFile(Commons.PathDatabase + "\\Argomenti.tsv", tree, false);
        }
        private void btnBackupTags_Click(object sender, EventArgs e)
        {
            //db.BackupTableTsv("Tags");
            Commons.bl.BackupTableXml("Tags");
            MessageBox.Show("Backup Tags terminato");
        }
        private void btnImportTopics_Click(object sender, EventArgs e)
        {
            // !!!! TODO fix using Regex.Split(string, ...) !!!!
            MessageBox.Show("To fix!");
            return; 

            List<Topic> ListTopics = new List<Topic>(); 
            string[] topics = TextFile.FileToArray(Commons.PathDatabase + "\\Argomenti_DA IMPORTARE.tsv");
            if(topics == null)
            {
                MessageBox.Show("Non è stato possibile aprire il file Argomenti_DA IMPORTARE.tsv"); 
                return; 
            }
            foreach(string line in topics)
            {
                Topic t = new Topic();
                string[] fields = line.Split('\t'); 
                // count tabs in the beginning of the line
                int nTabs = 0; 
                while (fields[nTabs] == "" && nTabs < fields.Length-1)
                {
                    nTabs++; 
                }
                if (fields[nTabs] != "")
                {
                    // store temporarily the level in field Parent node ID 
                    // (not used for other in this phase)
                    t.ParentNodeNew = nTabs;  // it is the level count 
                    t.Name = fields[nTabs++];
                    if(nTabs < fields.Length && fields[nTabs] != "")
                        t.Desc = fields[nTabs];
                    ListTopics.Add(t);
                }
            }
            MessageBox.Show("Salvare per rendere definitiva l'importazione."); 
            frmTopics ft = new frmTopics(frmTopics.TopicsFormType.ImportWithErase, 
                null, null, null, ListTopics);
            ft.ShowDialog(); 
            ft.Dispose();
        }
        private void btnRestoreTopics_Click(object sender, EventArgs e)
        {
            //db.RestoreTableTsv("Topics", rdbRestoreErasing.Checked);
            Commons.bl.RestoreTableXml("Topics", rdbRestoreErasing.Checked);
            MessageBox.Show("Ripristino argomenti terminato");
        }
        private void btnSaveDatabaseFile_Click(object sender, EventArgs e)
        {
            File.Copy(Commons.PathAndFileDatabase,
                Commons.PathDatabase + "\\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + 
                "_" + Commons.DatabaseFileName_Current); 
        }
        private void btnRestoreTags_Click(object sender, EventArgs e)
        {
            //db.RestoreTableTsv("Tags", rdbRestoreErasing.Checked);
            Commons.bl.RestoreTableXml("Tags", rdbRestoreErasing.Checked);
            Commons.bl.BackupAllStudentsDataXml();
            MessageBox.Show("Ripristino Tags terminato");
        }
        private void btnBackupStudents_Click(object sender, EventArgs e)
        {
            //db.BackupAllStudentsDataTsv();
            Commons.bl.BackupAllStudentsDataXml();
            MessageBox.Show("Backup studenti terminato");
        }
        private void btnExportTags_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Da fare");
        }
        private void btnImportTags_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Da fare");
        }
        private void btnRestoreStudents_Click(object sender, EventArgs e)
        {
            //db.RestoreAllStudentsDataTsv(rdbRestoreErasing.Checked);
            Commons.bl.RestoreAllStudentsDataXml(rdbRestoreErasing.Checked);
            MessageBox.Show("Ripristino studenti terminato");
        }
        private void btnCompactDatabase_Click(object sender, EventArgs e)
        {
            Commons.bl.CompactDatabase();
            Application.Exit();
        }
        private void BtnMakeDemo_Click(object sender, EventArgs e)
        {
            int indexNextClass = lstClasses.SelectedIndex - 1;
            if (indexNextClass < 0)
            {
                MessageBox.Show("Scegliere una classe a partire almeno dalla seconda della lista");
                return;
            }
            if (currentClass == null)
            {
                MessageBox.Show("Scegliere la classe da usare per generare il database demo");
                return;
            }
            if (MessageBox.Show("Verranno generate due classi demo nell'anno corrente, " +
                "con i dati manipolati della classe selezionata e di quella PRIMA nella lista, e le foto " +
                "prese da " + Commons.PathImages + "\\DemoPictures.\n\nDevo procedere con la generazione (Sì)" +
                " od interrompere (No)?","Continua?", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return; 

            Class otherClass = (Class)lstClasses.Items[lstClasses.SelectedIndex - 1];

            string newDatabasePathName = Commons.PathDatabase;
            if (!Directory.Exists(newDatabasePathName))
                Directory.CreateDirectory(newDatabasePathName);

            string newDatabaseFullName = newDatabasePathName +
                "\\Demo_SchoolGrades_" + currentClass.SchoolYear + "_" + DateTime.Now.Date.ToString("yy-MM-dd") + ".sqlite";

            if (File.Exists(newDatabaseFullName))
            {
                if (System.Windows.Forms.MessageBox.Show("Il file " + newDatabaseFullName + " esiste già." +
                    "\nDevo re-inizializzarlo (Sì) o non creare il database (No)?", "",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(newDatabaseFullName);
                }
                else
                    return;
            }
            string fileDatabase = Commons.bl.CreateDemoDatabase(newDatabaseFullName, otherClass, currentClass);
            MessageBox.Show("Creato il file " + fileDatabase + ", " +
                "che contiene le due classi 1DEMO e 2DEMO, con tutte le foto, " +
                "le valutazioni e le immagini."); ; 
        }
        private void BtnNewDatabase_Click(object sender, EventArgs e)
        {
            string newDatabasePathName = Commons.PathDatabase;
            if (!Directory.Exists(newDatabasePathName))
                Directory.CreateDirectory(newDatabasePathName);

            string newDatabaseFullName = newDatabasePathName +
                "\\SchoolGradesNew.sqlite";

            if (File.Exists(newDatabaseFullName))
            {
                //!!!!TODO make the next code indipendent from UI!!!!
                if (System.Windows.Forms.MessageBox.Show("Il file " + newDatabaseFullName + " esiste già." +
                    "\nDevo re-inizializzarlo (Sì) o non creare il database (No)?", "",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(newDatabaseFullName);
                }
                else
                    return;
            }
            Commons.bl.CreateNewDatabase(newDatabaseFullName);
            MessageBox.Show("Creato nuovo database SchoolGradesNew.sqlite"); 
        }
    }
}
