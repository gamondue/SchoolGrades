using SchoolGrades.DbClasses;
using gamon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using gamon.TreeMptt;

namespace SchoolGrades
{
    public partial class frmBackupManagement : Form
    {
        DbAndBusiness db = new DbAndBusiness();
        TreeMptt topicTreeMptt = new TreeMptt(null, null, null, null, null, null, null, DragDropEffects.None); 

        private string schoolYear;
        Class currentClass;

        public frmBackupManagement()
        {
            InitializeComponent();
        }

        private void frmBackupManagement_Load(object sender, EventArgs e)
        {
            // dal primo anno di default del combo con gli anni
            for (int anno = 2009; anno <= DateTime.Now.Year; anno++)
            {
                CmbSchoolYear.Items.Add((anno - 2000).ToString("00") + ((anno + 1) - 2000).ToString("00"));
            }
            int nAnni = CmbSchoolYear.Items.Count;
            if (DateTime.Now.Month >= 9)
                CmbSchoolYear.SelectedItem = CmbSchoolYear.Items[nAnni - 1];
            else
                CmbSchoolYear.SelectedItem = CmbSchoolYear.Items[nAnni - 2];

            schoolYear = CmbSchoolYear.SelectedItem.ToString();

            lstClasses.DataSource = db.GetClassesOfYear(Commons.IdSchool, schoolYear);
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

            db.BackupTableXml("SchoolSubjects");
            db.BackupTableXml("TestTypes");
            db.BackupTableXml("QuestionTypes");
            //db.BackupTableXml("AnswerTypes");
            db.BackupTableXml("GradeTypes");
            db.BackupTableXml("GradeCategories");
            db.BackupTableXml("Schools");
            db.BackupTableXml("SchoolYears");
            db.BackupTableXml("SchoolPeriods");
            MessageBox.Show("Salvataggio tabelle terminato");
        }

        private void btnClassBackup_Click(object sender, EventArgs e)
        {
            if (currentClass == null)
            {
                MessageBox.Show("Scegliere la classe da tenere nel database");
                return; 
            }
            string imagesFolder = db.CreateOneClassOnlyDatabase(currentClass);
            if (imagesFolder != "")
                Commons.ProcessStartLink(imagesFolder);
            else
                MessageBox.Show("Cartella del database della classe non trovata"); 
            //MessageBox.Show("Fatto"); 
        }

        private void cmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstClasses.DataSource = db.GetClassesOfYear(Commons.IdSchool, CmbSchoolYear.Text);
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

            db.RestoreTableXml("SchoolSubjects", rdbRestoreErasing.Checked);
            db.RestoreTableXml("TestTypes", rdbRestoreErasing.Checked);
            db.RestoreTableXml("QuestionTypes", rdbRestoreErasing.Checked);
            //db.RestoreTableXml("AnswerTypes", rdbRestoreErasing.Checked);
            db.RestoreTableXml("GradeTypes", rdbRestoreErasing.Checked);
            db.RestoreTableXml("GradeCategories", rdbRestoreErasing.Checked);
            db.RestoreTableXml("Schools", rdbRestoreErasing.Checked);
            db.RestoreTableXml("SchoolYears", rdbRestoreErasing.Checked);
            db.RestoreTableXml("SchoolPeriods", rdbRestoreErasing.Checked);
            MessageBox.Show("Ripristino tabelle terminato");
        }

        private void btnBackupTopics_Click(object sender, EventArgs e)
        {
            //db.BackupTableTsv("Topics");
            db.BackupTableXml("Topics");
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
            db.BackupTableXml("Tags");
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
            frmTopics ft = new frmTopics(frmTopics.TopicsFormType.ImportWithErase, ListTopics, null, null);
            ft.ShowDialog(); 
            ft.Dispose();
        }

        private void btnRestoreTopics_Click(object sender, EventArgs e)
        {
            //db.RestoreTableTsv("Topics", rdbRestoreErasing.Checked);
            db.RestoreTableXml("Topics", rdbRestoreErasing.Checked);
            MessageBox.Show("Ripristino argomenti terminato");
        }

        private void btnSaveDatabaseFile_Click(object sender, EventArgs e)
        {
            File.Copy(Commons.PathAndFileDatabase,
                Commons.PathDatabase + "\\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + 
                "_" + Commons.FileDatabase); 
        }

        private void btnRestoreTags_Click(object sender, EventArgs e)
        {
            //db.RestoreTableTsv("Tags", rdbRestoreErasing.Checked);
            db.RestoreTableXml("Tags", rdbRestoreErasing.Checked);
            db.BackupAllStudentsDataXml();
            MessageBox.Show("Ripristino Tags terminato");
        }

        private void btnBackupStudents_Click(object sender, EventArgs e)
        {
            //db.BackupAllStudentsDataTsv();
            db.BackupAllStudentsDataXml();
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
            db.RestoreAllStudentsDataXml(rdbRestoreErasing.Checked);
            MessageBox.Show("Ripristino studenti terminato");
        }

        private void btnCompactDatabase_Click(object sender, EventArgs e)
        {
            db.CompactDatabase();
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
                ;

            Class otherClass = (Class)lstClasses.Items[lstClasses.SelectedIndex - 1]; 
            string fileDatabase = db.CreateDemoDatabase(currentClass, otherClass);
            MessageBox.Show("Creato il file " + fileDatabase + ", " +
                "che contiene le due classi DEMO1 e DEMO2, con tutte le foto, " +
                "le valutazioni e le immagini."); ; 
        }

        private void BtnNewDatabase_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Da fare!"); 
            db.NewDatabase();
            MessageBox.Show("Creato nuovo database SchoolGradesNew.sqlite"); 
        }
    }
}
