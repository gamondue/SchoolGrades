using gamon;
using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmBackupManagement.xaml
    /// </summary>
    public partial class frmBackupManagement : Window
    {
        //TreeMptt topicTreeMptt;

        private string schoolYear;
        Class currentClass;
        public frmBackupManagement()
        {
            InitializeComponent();

            //TreeMpttDb dbMptt = new TreeMpttDb(Commons.dl);

            //topicTreeMptt = new TreeMptt(Cooms.dl, null, null, null, null, null,
            // null, null, null, null, null, null, DragDropEffects.None);
        }

        private void frmBackupManagament_Loaded(object sender, RoutedEventArgs e)
        {
            //List<SchoolYear> ly = Commons.bl.GetSchoolYearsThatHaveClasses();
            //CmbSchoolYear.ItemsSource = ly;
            //if (ly.Count > 0)
            //    CmbSchoolYear.SelectedItem = ly[ly.Count - 1];

            schoolYear = cmbSchoolYear.SelectedItem.ToString();

            //lstClasses.ItemsSource = Commons.bl.GetClassesOfYear(Commons.IdSchool, schoolYear);
        }

        private void btnBackupTables_Click(object sender, RoutedEventArgs e)
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

            //Commons.bl.BackupTableXml("SchoolSubjects");
            //Commons.bl.BackupTableXml("TestTypes");
            //Commons.bl.BackupTableXml("QuestionTypes");
            //Commons.bl.BackupTableXml("AnswerTypes");
            //Commons.bl.BackupTableXml("GradeTypes");
            //Commons.bl.BackupTableXml("GradeCategories");
            //Commons.bl.BackupTableXml("Schools");
            //Commons.bl.BackupTableXml("SchoolYears");
            //Commons.bl.BackupTableXml("SchoolPeriods");
            MessageBox.Show("Salvataggio tabelle terminato");
        }

        private void btnClassBackup_Click(object sender, RoutedEventArgs e)
        {
            if (currentClass == null)
            {
                MessageBox.Show("Scegliere la classe da tenere nel database");
                return;
            }
            //string imagesFolder = Commons.bl.CreateOneClassOnlyDatabase(currentClass);
            //if(imagesFolder !="")
            //    Commons.ProcessStartLink(imagesFolder)
            //else
            MessageBox.Show("Cartella del database della classe non trovata");
            //MessageBox.Show("Fatto"); 
        }

        private void CmbSchoolYear_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // lstClasses.ItemsSource = Commons.bl.GetClassesOfYear(Commons.IdSchool, CmbSchoolYear.Text);
        }

        private void lstClasses_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //classeCorrente = new Classe(nomeFile); 
            currentClass = (Class)lstClasses.SelectedItem;
        }

        private void lstClasses_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //DataTable students = db.GetClass(school, schoolYear, lstClasses.SelectedItem.ToString());
        }

        private void btnRestoreTables_Click(object sender, RoutedEventArgs e)
        {
            //db.RestoreTableTsv("SchoolSubjects", rdbRestoreErasing.IsChecked);
            //db.RestoreTableTsv("TestTypes", rdbRestoreErasing.IsChecked);
            //db.RestoreTableTsv("QuestionTypes", rdbRestoreErasing.IsChecked);
            ////db.RestoreTableTsv("AnswerTypes", rdbRestoreErasing.IsChecked);
            //db.RestoreTableTsv("GradeTypes", rdbRestoreErasing.IsChecked);
            //db.RestoreTableTsv("GradeCategories", rdbRestoreErasing.IsChecked);
            //db.RestoreTableTsv("Schools", rdbRestoreErasing.IsChecked);
            //db.RestoreTableTsv("SchoolYears", rdbRestoreErasing.IsChecked);
            //db.RestoreTableTsv("SchoolPeriods", rdbRestoreErasing.IsChecked);

            //Commons.bl.RestoreTableXml("SchoolSubjects", rdbRestoreErasing.IsChecked);
            //Commons.bl.RestoreTableXml("TestTypes", rdbRestoreErasing.IsChecked);
            //Commons.bl.RestoreTableXml("QuestionTypes", rdbRestoreErasing.IsChecked);
            //db.RestoreTableXml("AnswerTypes", rdbRestoreErasing.IsChecked);
            //Commons.bl.RestoreTableXml("GradeTypes", rdbRestoreErasing.IsChecked);
            //Commons.bl.RestoreTableXml("GradeCategories", rdbRestoreErasing.IsChecked);
            //Commons.bl.RestoreTableXml("Schools", rdbRestoreErasing.IsChecked);
            //Commons.bl.RestoreTableXml("SchoolYears", rdbRestoreErasing.IsChecked);
            //Commons.bl.RestoreTableXml("SchoolPeriods", rdbRestoreErasing.IsChecked);
            //MessageBox.Show("Ripristino tabelle terminato");
        }

        private void btnBackupTopics_Click(object sender, RoutedEventArgs e)
        {
            //db.BackupTableTsv("Topics");
            Commons.bl.BackupTableXml("Topics");
            MessageBox.Show("Backup argomenti terminato");
        }

        private void btnExportTopics_Click(object sender, RoutedEventArgs e)
        {
            //Topic initial = ((Topic)trwTopics.SelectedItem.Tag);
            //string tree = topicTreeMptt.CreateTextTreeOfDescendants(0, int.MaxValue, true);
            //TextFile.StringToFile(Commons.PathDatabase + "\\Argomenti.tsv", tree, false);
        }

        private void btnImportTopics_Click(object sender, RoutedEventArgs e)
        {
            // !!!! TODO fix using Regex.Split(string, ...) !!!!
            MessageBox.Show("To fix!");
            return;

            List<Topic> ListTopics = new List<Topic>();
            string[] topics = TextFile.FileToArray(Commons.PathDatabase + "\\Argomenti_DA IMPORTARE.tsv");
            if (topics == null)
            {
                MessageBox.Show("Non è stato possibile aprire il file Argomenti_DA IMPORTARE.tsv");
                return;
            }
            foreach (string line in topics)
            {
                Topic t = new Topic();
                string[] fields = line.Split('\t');
                // count tabs in the beginning of the line
                int nTabs = 0;
                while (fields[nTabs] == "" && nTabs < fields.Length - 1)
                {
                    nTabs++;
                }
                if (fields[nTabs] != "")
                {
                    // store temporarily the level in field Parent node ID 
                    // (not used for other in this phase)
                    t.ParentNodeNew = nTabs;  // it is the level count 
                    t.Name = fields[nTabs++];
                    if (nTabs < fields.Length && fields[nTabs] != "")
                        t.Desc = fields[nTabs];
                    ListTopics.Add(t);
                }
            }
            MessageBox.Show("Salvare per rendere definitiva l'importazione.");
            //frmTopics ft = new frmTopics(frmTopics.TopicsFormType.ImportWithErase,
            //    null, null, null, ListTopics);
            //ft.ShowDialog();
            //ft.Dispose();
        }

        private void btnRestoreTopics_Click(object sender, RoutedEventArgs e)
        {
            //db.RestoreTableTsv("Topics", rdbRestoreErasing.IsChecked);
            //Commons.bl.RestoreTableXml("Topics", rdbRestoreErasing.IsChecked);
            MessageBox.Show("Ripristino argomenti terminato");
        }

        private void btnSaveDatabaseFile_Click(object sender, RoutedEventArgs e)
        {
            File.Copy(Commons.PathAndFileDatabase,
                Commons.PathDatabase + "\\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") +
                "_" + Commons.DatabaseFileName_Current);
        }

        private void btnRestoreTags_Click(object sender, RoutedEventArgs e)
        {
            //db.RestoreTableTsv("Tags", rdbRestoreErasing.IsChecked);
            //Commons.bl.RestoreTableXml("Tags", rdbRestoreErasing.IsChecked);
            Commons.bl.BackupAllStudentsDataXml();
            MessageBox.Show("Ripristino Tags terminato");
        }

        private void btnBackupStudents_Click(object sender, RoutedEventArgs e)
        {
            //db.BackupAllStudentsDataTsv();
            Commons.bl.BackupAllStudentsDataXml();
            MessageBox.Show("Backup studenti terminato");
        }

        private void btnExportTags_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Da fare");
        }

        private void btnImportTags_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Da fare");
        }

        private void btnRestoreStudents_Click(object sender, RoutedEventArgs e)
        {
            //db.RestoreAllStudentsDataTsv(rdbRestoreErasing.IsChecked);
            //Commons.bl.RestoreAllStudentsDataXml(rdbRestoreErasing.IsChecked);
            MessageBox.Show("Ripristino studenti terminato");
        }

        private void btnCompactDatabase_Click(object sender, RoutedEventArgs e)
        {
            Commons.bl.CompactDatabase();
            //Application.Exit();
        }

        private void btnMakeDemo_Click(object sender, RoutedEventArgs e)
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
            //if (MessageBox.Show("Verranno generate due classi demo nell'anno corrente, " +
            //    "con i dati manipolati della classe selezionata e di quella PRIMA nella lista, e le foto " +
            //    "prese da " + Commons.PathImages + "\\DemoPictures.\n\nDevo procedere con la generazione (Sì)" +
            //" od interrompere (No)?", "Continua?", MessageBoxButton.YesNo,
            //MessageBoxImage.Question,
            //MessageBoxDefaultButton.Button2) != MessageBoxResult.Yes)
            return;

            Class otherClass = (Class)lstClasses.Items[lstClasses.SelectedIndex - 1];

            string newDatabasePathName = Commons.PathDatabase;
            if (!Directory.Exists(newDatabasePathName))
                Directory.CreateDirectory(newDatabasePathName);

            string newDatabaseFullName = newDatabasePathName +
                "\\Demo_SchoolGrades_" + currentClass.SchoolYear + "_" + DateTime.Now.Date.ToString("yy-MM-dd") + ".sqlite";

            //if (File.Exists(newDatabaseFullName))
            //{
            //if (System.Windows.Forms.MessageBox.Show("Il file " + newDatabaseFullName + " esiste già." +
            //"\nDevo re-inizializzarlo (Sì) o non creare il database (No)?", "",
            //System.Windows.Forms.MessageBoxButton.YesNo,
            //MessageBoxImage.Question) == MessageBoxResult.Yes)
            //{
            // File.Delete(newDatabaseFullName);
            //}
            // else
            //   return;
            // }
            //string fileDatabase = Commons.bl.CreateDemoDatabase(newDatabaseFullName, otherClass, currentClass);
            //MessageBox.Show("Creato il file " + fileDatabase + ", " +
            //    "che contiene le due classi 1DEMO e 2DEMO, con tutte le foto, " +
            //    "le valutazioni e le immagini."); ;
        }

        private void btnNewDatabase_Click(object sender, RoutedEventArgs e)
        {
            string newDatabasePathName = Commons.PathDatabase;
            if (!Directory.Exists(newDatabasePathName))
                Directory.CreateDirectory(newDatabasePathName);

            string newDatabaseFullName = newDatabasePathName +
                "\\SchoolGradesNew.sqlite";

            if (File.Exists(newDatabaseFullName))
            {
                //!!!!TODO make the next code indipendent from UI!!!!
                //       if (System.Windows.Forms.MessageBox.Show("Il file " + newDatabaseFullName + " esiste già." +
                //           "\nDevo re-inizializzarlo (Sì) o non creare il database (No)?", "",
                //           System.Windows.Forms.MessageBoxButton.YesNo,
                //           MessageBoxImage.Question) == MessageBoxResult.Yes)
                //       {
                //           File.Delete(newDatabaseFullName);
                //       }
                //       else
                //           return;
            }
            Commons.bl.CreateNewDatabase(newDatabaseFullName);
            MessageBox.Show("Creato nuovo database SchoolGradesNew.sqlite");
        }
    }
}
