using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        public int indexCurrentDrawn = 0;

        public List<Student> currentStudentsList;
        public List<Student> eligiblesList = new List<Student>();

        //List<frmLessons> listLessons = new List<frmLessons>();

        School school;

        private string schoolYear;

        //bool formInitializing = true;
        //bool firstTime = true;

        Student currentStudent;
        Question currentQuestion;
        GradeType currentGradeType;
        Class currentClass;

        public frmMain()
        {
            InitializeComponent();

            // set fixed file paths and names 
            Commons.PathAndFileDatabase = Path.Combine(Commons.PathExe, "Data",
                "Demo_SchoolGrades.sqlite");
            Commons.PathImages = Path.Combine(Commons.PathExe, "Images");

            CreateBusinessAndDataLayer();

            List<SchoolYear> ly = Commons.bl.GetSchoolYearsThatHaveClasses();
            cmbSchoolYear.ItemsSource = ly;
            if (ly.Count > 0)
                cmbSchoolYear.SelectedItem = ly[ly.Count - 1];

            // fill the combo of grade types 
            List<GradeType> ListGradeTypes = Commons.bl.GetListGradeTypes();
            cmbGradeType.ItemsSource = ListGradeTypes;

            // fill the combo of School subjects
            List<SchoolSubject> listSubjects = Commons.bl.GetListSchoolSubjects(true);
            cmbSchoolSubject.ItemsSource = listSubjects;
#if !DEBUG
            // capture every exception for exception logging
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            btnTemporary.Visible = false;
#endif
            frmMain_Load();
        }
        private void frmMain_Load()
        {
            lblDatabaseFile.Visibility = Visibility.Visible;
            lblLastDatabaseModification.Visibility = Visibility.Visible;
            lblLastDatabaseModification.Text = File.GetLastWriteTime(Commons.PathAndFileDatabase).ToString("yyyy-MM-dd HH:mm:ss");

            school = Commons.bl.GetSchool(Commons.IdSchool);
            if (school == null)
                return;

            if (cmbSchoolYear.SelectedItem != null)
                schoolYear = cmbSchoolYear.SelectedItem.ToString();

            lstClasses.ItemsSource = Commons.bl.GetClassesOfYear(school.IdSchool, schoolYear);

            if (lstClasses.ItemsSource == null)
                return;

            //CommonsWinForms.globalPicLed = picBackgroundSaveRunning;

            //if (chkActivateLessonClock.Checked)
            //{
            //    CalculateTimesForEndLessonWarning();
            //    timerLesson.Start();
            //}

            //string file = Commons.PathLogs + @"frmMain_parameters.txt";
            //CommonsWinForms.RestoreCurrentValuesOfAllControls(this, file);

            //txtNStudents.Text = "";

            //picStudent.BringToFront();
            //lblStudentChosen.BringToFront();
            //lblIdStudent.BringToFront();
            //txtIdStudent.BringToFront();
            //lblStudentChosen.Visible = false;
            //lblIdStudent.Visible = false;
            //txtIdStudent.Visible = false;

            lblDatabaseFile.Text = Path.GetFileName(Commons.PathAndFileDatabase);
            //formInitializing = false;
        }
        private string NewFilenameAndPath(string proposedDatabasePath)
        {
            string newDatabaseFileName = "";
            string proposedTeachersDatabaseFile = Path.Combine(proposedDatabasePath, Commons.DatabaseFileName_Teacher);
            string proposedDemoDatabaseFile = Path.Combine(proposedDatabasePath, Commons.DatabaseFileName_Demo);
            string proposedDebugDatabaseFile = Path.Combine(proposedDatabasePath, "SchoolGrades_DEBUG.sqlite");
#if DEBUG 
            if (File.Exists(proposedDebugDatabaseFile))
            {
                return proposedDebugDatabaseFile;
            }
#endif
            if (File.Exists(proposedTeachersDatabaseFile))
            {
                return proposedTeachersDatabaseFile;
            }
            if (File.Exists(proposedDemoDatabaseFile))
            {
                return proposedDemoDatabaseFile;
            }
            // look for the newest "ISO date at left" filename in folder
            newDatabaseFileName = GetNewestFileNameWithDate(proposedDatabasePath);
            if (newDatabaseFileName != "")
                return newDatabaseFileName;
            else
                return "";
        }
        private string GetNewestFileNameWithDate(string DatabasePath)
        {
            string[] files = Directory.GetFiles(DatabasePath);
            DateTime newestFileDate = DateTime.MinValue;
            string newestFileNameAndPath = "";
            foreach (string file in files)
            {
                DateTime thisFileDate = Commons.GetValidDate(Path.GetFileName(file).Substring(0, 10));
                if (thisFileDate > newestFileDate)
                {
                    newestFileDate = thisFileDate;
                    newestFileNameAndPath = file;
                }
            }
            return newestFileNameAndPath;
        }
        private bool CreateBusinessAndDataLayer()
        {
            // create Business and Data layer objects, to be used throughout the program
            // keep this order of creation. Create after reading config file
            if (!System.IO.File.Exists(Commons.PathAndFileDatabase))
            {
                string err = @"[" + Commons.PathAndFileDatabase + " not in the current nor in the dev directory]";
                Commons.ErrorLog(err);
                throw new System.IO.FileNotFoundException(err);
                return false;
            }
            Commons.dl = new DataLayer(Commons.PathAndFileDatabase);
            if (Commons.dl == null)
                return false;
            Commons.bl = new BusinessLayer();
            if (Commons.bl == null)
                return false;
            return true;
        }
        private void btnStartColorTimer_Click(object sender, RoutedEventArgs e)
        {
            StartColorTimer(chkSoundsInColorTimer.IsChecked);
        }
        private void lstClasses_DoubleClick(object sender, EventArgs e)
        {
            //SaveStudentsOfClassIfEligibleHasChanged();
            currentClass = (Class)lstClasses.SelectedItem;
            //txtIdClass.Text = currentClass.IdClass.ToString();

            ShowStudentsOfClass();
            //if (currentStudentsList != null)
            //    txtNStudents.Text = currentStudentsList.Count.ToString();
            //else
            //    txtNStudents.Text = "";

            //// play Happy Birthday when a student has his BirthDay
            //List<Student> celebrated = Commons.bl.FindStudentsOnBirthday(currentClass, DateTime.Now);
            //if (celebrated.Count > 0)
            //{
            //    try
            //    {
            //        suonatore.SoundLocation = ".\\Auguri.wav";
            //        suonatore.Play();
            //    }
            //    catch
            //    {
            //        Console.Beep(220, 1000);
            //    }
            //    foreach (Student s in celebrated)
            //    {
            //        frmStudent f = new frmStudent(s, false);
            //        f.Show();
            //        // put full screen ther form 
            //        // TODO 
            //    }
            //// show popup annotations of the students of the class
            //DataTable popUpAnnotations = Commons.bl.GetAnnotationsOfClasss(currentClass.IdClass, true, true);
            //if (popUpAnnotations.Rows.Count > 0)
            //{
            //    frmAnnotationsPopUp f = new frmAnnotationsPopUp(popUpAnnotations);
            //    f.StartPosition = FormStartPosition.CenterParent;
            //    f.Show();
            //}
        }
        private void btnTemporary_Click(object sender, RoutedEventArgs e)
        {
            // Start a specific form to test it 
        }
        public void ShowStudentsOfClass()
        {
            if (lstClasses.SelectedItem != null)
            {
                currentStudentsList = Commons.bl.GetStudentsOfClassList(school.OfficialSchoolAbbreviation, schoolYear,
                    lstClasses.SelectedItem.ToString(), false);
                eligiblesList.Clear();

                if (currentStudentsList == null)
                    return;

                RefreshStudentsGrid();
            }
        }
        private void StartColorTimer(bool? SoundEffectsInTimer)
        {
            double t = double.Parse(txtTimeInterval.Text);
            ////frmColorTimer ft = new frmColorTimer(t / 60, t / 60, (bool)SoundEffectsInTimer);
            //if (currentStudent != null)
            //{
            //    ft.FormCaption = ft.FormCaption.Replace("gamon", currentStudent.LastName);
            //}
            //ft.Show();
        }
        private void btnRandomNumber_Click(object sender, RoutedEventArgs e)
        {

        }
        private void RefreshStudentsGrid()
        {
            dgwStudents.ItemsSource = null;
            dgwStudents.ItemsSource = currentStudentsList;

            //if (dgwStudents.Columns.Count > 0)
            //{
            //    dgwStudents.Columns[1].Visible = false;

            //    //dgwStudents.Columns[4].Visible = false;
            //    dgwStudents.Columns[5].Visible = false;
            //    dgwStudents.Columns[6].Visible = false;
            //    dgwStudents.Columns[7].Visible = false;
            //    dgwStudents.Columns[8].Visible = false;
            //    dgwStudents.Columns[9].Visible = false;
            //    dgwStudents.Columns[10].Visible = false;
            //    dgwStudents.Columns[11].Visible = false;
            //    dgwStudents.Columns[12].Visible = false;
            //    dgwStudents.Columns[13].Visible = false;
            //    dgwStudents.Columns[14].Visible = false;
            //    dgwStudents.Columns[15].Visible = false;
            //    dgwStudents.Columns[16].Visible = false;

            //    dgwStudents.Columns[18].Visible = false;
            //    dgwStudents.Columns[19].Visible = false;

            //    dgwStudents.Columns[20].Visible = false;
            //    int Index = 0;
            //    foreach (Student s in currentStudentsList)
            //    {
            //        // "manually" set the check columm (0)
            //        if (s.Eligible == true)
            //        {
            //            dgwStudents.Rows[Index].Cells[0].Value = true;
            //        }
            //        else
            //        {
            //            dgwStudents.Rows[Index].Cells[0].Value = false;
            //        }
            //        Index++;
            //    }
            //}
        }
    }
}