using gamon;
using gamon.TreeMptt;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SchoolGrades.Localization;

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

            topicTreeMptt = new TreeMptt(null, Commons.PathAndFileDatabase, null, null, null, null,
                null, null, null, null, null, null, null, DragDropEffects.None);
        }
        private void frmBackupManagement_Load(object sender, EventArgs e)
        {
            LocalizeForm();
            
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
            MessageBox.Show(Loc.Get("Backup_TablesSaved"));
        }
        private void btnClassBackup_Click(object sender, EventArgs e)
        {
            if (currentClass == null)
            {
                MessageBox.Show(Loc.Get("Backup_SelectClass"));
                return;
            }
            string imagesFolder = Commons.bl.CreateOneClassOnlyDatabase(currentClass);
            if (imagesFolder != "")
                Commons.ProcessStartLink(imagesFolder);
            else
                MessageBox.Show(Loc.Get("Backup_ClassFolderNotFound"));
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
            //DataTable students = db.GetClass(currentSchool, currentYear, lstClasses.SelectedItem.ToString());
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
            MessageBox.Show(Loc.Get("Backup_TablesRestored"));
        }
        private void btnBackupTopics_Click(object sender, EventArgs e)
        {
            //db.BackupTableTsv("Topics");
            Commons.bl.BackupTableXml("Topics");
            MessageBox.Show(Loc.Get("Backup_TopicsSaved"));
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
            MessageBox.Show(Loc.Get("Backup_TagsSaved"));
        }
        private void btnImportTopics_Click(object sender, EventArgs e)
        {
            // !!!! TODO fix using Regex.Split(string, ...) !!!!
            MessageBox.Show(Loc.Get("Common_ToFix"));
            return;

            List<Topic> ListTopics = new List<Topic>();
            string[] topics = TextFile.FileToArray(Commons.PathDatabase + "\\Argomenti_DA IMPORTARE.tsv");
            if (topics == null)
            {
                MessageBox.Show(Loc.Get("Backup_CannotOpenTopicsFile"));
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
            MessageBox.Show(Loc.Get("Backup_SaveToFinalize"));
            frmTopics ft = new frmTopics(frmTopics.TopicsFormType.ImportWithErase,
                null, null, null, ListTopics);
            ft.ShowDialog();
            ft.Dispose();
        }
        private void btnRestoreTopics_Click(object sender, EventArgs e)
        {
            //db.RestoreTableTsv("Topics", rdbRestoreErasing.Checked);
            Commons.bl.RestoreTableXml("Topics", rdbRestoreErasing.Checked);
            MessageBox.Show(Loc.Get("Backup_TopicsRestored"));
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
            MessageBox.Show(Loc.Get("Backup_TagsRestored"));
        }
        private void btnBackupStudents_Click(object sender, EventArgs e)
        {
            //db.BackupAllStudentsDataTsv();
            Commons.bl.BackupAllStudentsDataXml();
            MessageBox.Show(Loc.Get("Backup_StudentsSaved"));
        }
        private void btnExportTags_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Loc.Get("Common_ToDo"));
        }
        private void btnImportTags_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Loc.Get("Common_ToDo"));
        }
        private void btnRestoreStudents_Click(object sender, EventArgs e)
        {
            //db.RestoreAllStudentsDataTsv(rdbRestoreErasing.Checked);
            Commons.bl.RestoreAllStudentsDataXml(rdbRestoreErasing.Checked);
            MessageBox.Show(Loc.Get("Backup_StudentsRestored"));
        }
        private void btnCompactDatabase_Click(object sender, EventArgs e)
        {
            Commons.bl.CompactDatabase();
            Application.Exit();
        }
        private void BtnMakeDemo_Click(object sender, EventArgs e)
        {
            string prompt = string.Format(Loc.Get("Backup_DemoPrompt"), Commons.PathImages);
            if (MessageBox.Show(prompt, Loc.Get("Backup_DemoPromptTitle"), MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            // make a list of selected classes and the same classes next year 
            List<Class> classes = new();
            foreach (Class c in lstClasses.SelectedItems)
            {
                // add selected class
                classes.Add(c);
                // gets this same class in next year (if any..)
                Class temp = Commons.bl.GetThisClassNextYear(c);
                if (temp.Abbreviation != null)
                {
                    // if exists, add same class, next year to the classes 
                    classes.Add(temp);
                }
            }
            if (classes == null)
            {
                MessageBox.Show(Loc.Get("Backup_SelectAtLeastOneClass"));
                return;
            }
            string demoDatabase = Commons.bl.GetDemoDatabaseName();

            if (File.Exists(demoDatabase))
            {
                if (MessageBox.Show(string.Format(Loc.Get("Backup_FileExistsOverwrite"), demoDatabase), 
                    Loc.Get("Common_EmptyString"),
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(demoDatabase);
                }
                else
                    return;
            }
            Commons.bl.CreateDemoDatabase(demoDatabase, classes);
            MessageBox.Show(string.Format(Loc.Get("Backup_DemoCreated"), demoDatabase));
        }
        private void BtnNewDatabase_Click(object sender, EventArgs e)
        {
            string newDatabasePathName = Commons.PathDatabase;
            if (!Directory.Exists(newDatabasePathName))
                Directory.CreateDirectory(newDatabasePathName);

            string NewDatabasePathName = newDatabasePathName +
                "\\SchoolGradesNew.sqlite";

            if (File.Exists(NewDatabasePathName))
            {
                if (System.Windows.Forms.MessageBox.Show(string.Format(Loc.Get("Backup_FileExistsOverwrite"), NewDatabasePathName), 
                    Loc.Get("Common_EmptyString"),
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(NewDatabasePathName);
                }
                else
                    return;
            }
            Commons.bl.CreateNewDatabaseFromExisting(NewDatabasePathName);
            MessageBox.Show(Loc.Get("Backup_NewDatabaseCreated"));
        }
        private void LocalizeForm()
        {
            try
            {
                // Form title - using existing key
                this.Text = Loc.Get("Setup_BackupManagement");

                // Buttons
                btnBackupTables.Text = Loc.Get("Backup_BackupTables");
                btnRestoreTables.Text = Loc.Get("Backup_RestoreTables");
                btnBackupTopics.Text = Loc.Get("Backup_BackupTopics");
                btnRestoreTopics.Text = Loc.Get("Backup_RestoreTopics");
                btnExportTopics.Text = Loc.Get("Backup_ExportTopics");
                btnImportTopics.Text = Loc.Get("Backup_ImportTopics");
                btnBackupTags.Text = Loc.Get("Backup_BackupTags");
                btnRestoreTags.Text = Loc.Get("Backup_RestoreTags");
                btnExportTags.Text = Loc.Get("Backup_ExportTags");
                btnImportTags.Text = Loc.Get("Backup_ImportTags");
                btnBackupStudents.Text = Loc.Get("Backup_BackupStudents");
                btnRestoreStudents.Text = Loc.Get("Backup_RestoreStudents");
                btnClassBackup.Text = Loc.Get("Backup_ClassBackup");
                btnSaveDatabaseFile.Text = Loc.Get("Backup_SaveDatabaseFile");
                btnCompactDatabase.Text = Loc.Get("Backup_CompactDatabase");
                btnMakeDemo.Text = Loc.Get("Backup_MakeDemo");
                BtnNewDatabase.Text = Loc.Get("Backup_NewDatabase");

                // GroupBox
                grpOnlyOneClass.Text = Loc.Get("Backup_OnlyOneClassGroup");

                // RadioButtons
                rdbRestoreErasing.Text = Loc.Get("Backup_RestoreErasing");
                rdbRestoreWithAdd.Text = Loc.Get("Backup_RestoreAdding");

                // Tooltips
                toolTip1.SetToolTip(btnClassBackup, Loc.Get("Backup_Tooltip_ClassBackup"));
                toolTip1.SetToolTip(btnMakeDemo, Loc.Get("Backup_Tooltip_MakeDemo"));
                toolTip1.SetToolTip(BtnNewDatabase, Loc.Get("Backup_Tooltip_NewDatabase"));
                toolTip1.SetToolTip(btnSaveDatabaseFile, Loc.Get("Backup_Tooltip_SaveDatabaseFile"));
                toolTip1.SetToolTip(btnCompactDatabase, Loc.Get("Backup_Tooltip_CompactDatabase"));
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"frmBackupManagement.LocalizeForm: {ex.Message}");
            }
        }
    }
}
