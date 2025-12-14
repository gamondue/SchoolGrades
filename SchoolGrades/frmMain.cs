using gamon;
using gamon.TreeMptt;
using SchoolGrades.BusinessObjects;
using SchoolGrades.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace SchoolGrades
{
    public partial class frmMain : Form
    {
        public int indexCurrentDrawn = 0;

        public List<Student> currentStudentsList;
        public List<Student> eligiblesList = new List<Student>();
        List<frmLessons> listLessons = new List<frmLessons>();
        private School currentSchool;
        private SchoolYear currentYear;

        bool initializingForm = true;
        Question currentQuestion;
        GradeType currentGradeType;
        Class currentClass;

        Random random = new Random();

        System.Media.SoundPlayer suonatore = new System.Media.SoundPlayer();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Student CurrentStudent { get; set; }

        string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        #region fields of the ColorTimer
        int ticksPassed;
        ColorHelper.RGB colRGB = new ColorHelper.RGB();
        ColorHelper.HSL colHSL = new ColorHelper.HSL();

        Color startColor = Color.Lime;
        //Color finalColor = Color.Green;
        Color finalColor = Color.Red;
        public Color CurrentLessonTimeColor;

        float spanHue;          // Hue span to cover from start time to end
        float spanSaturation;   // Saturation to cover from start time to end
        float spanLuminance;    // differenza to cover from start time to end
        #endregion

        #region fields of the lesson timer
        private DateTime thisLessonStartTime;
        private DateTime thisLessonEndTime;
        private float timeLessonMinutes;
        private float timeLeftMinutes;
        private float timeAlarmMinutes;
        private float ticksToMinutesFactor; // multiplicator from tens of microseconds to minutes
        private int minuteStart;
        private bool alarmNotFired = true;
        #endregion

        private SchoolSubject currentSubject;

        private bool dataModified = false;

        public frmMain()
        {
            InitializeComponent();

            // Configura il ToolTip per evitare che sparisca (!!!! PROVA)
            toolTip1.AutoPopDelay = 10000;  // Resta visibile 10 secondi
            toolTip1.InitialDelay = 500;    // Appare dopo 500ms
            toolTip1.ReshowDelay = 100;     // Riappare velocemente
            toolTip1.ShowAlways = true;     // Mostra sempre

            this.Text += " v. " + version;

            Commons.CreatePaths();

            // manage the configuration file 
            string messagePrompt = "";
#if !DEBUG
            btnTemporary.Visible = false;
#endif
#if SQL_SERVER
            // SQL server database filename
#if !DEBUG
            // during the development phase use a debug database
            Commons.PathAndFileDatabase = "SchoolGrades"; 
#else
            Commons.PathAndFileDatabase = "SchoolGrades";
#endif

#else
            // SQLite database filename reading 
            // read configuration file, if doesn't work run configuration 
            bool fileRead = Commons.ReadConfigData();
            if (!fileRead)
            {
                // config file is unexistent or unreadable
                StartNewConfigurationForm();
                CloseProgramWhileTestingIfConfigurationFileIsRight();
            }
            else
            {
                // config file has been read
                string configuredPathAndFile = Commons.PathAndFileDatabase;
                string configuredFileName = Path.GetFileName(configuredPathAndFile);
                if (configuredPathAndFile != null)
                {
                    // in Commons.PathAndFileDatabase we have a name for the database file 
                    // checks if the file exists
                    if (!File.Exists(configuredPathAndFile))
                    {
                        // the file in config file doesn't exist in the filesystem 
                        messagePrompt = "Il file di database configurato:\n" + Commons.PathAndFileDatabase + "\nnon è accessibile!\n" +
                            "Sceglierne uno nella prossima finestra.";
                        MessageBox.Show(messagePrompt);
                        frmSetup f = new frmSetup();
                        f.ShowDialog();
                        CloseProgramWhileTestingIfConfigurationFileIsRight();
                    }
                    else
                    {
                        // the configured file exists, if it is a file for a single class,
                        // check if a more recent file exists and ask the user if she wants to
                        // pass to the new file 
                        DateTime fileDateInName = Commons.GetValidDateFromString(configuredFileName.Substring(0, 19));
                        if (fileDateInName != DateTime.MinValue)
                        {
                            // we found the class database with fileDate in the beginning of the name
                            // lets look if in the database folder a newer file exists
                            string newestFileName = GetNewDatabaseFilename(Path.GetDirectoryName(configuredPathAndFile));
                            // if the newest file is different from the current 
                            // propose to get it as the database 
                            if (Path.GetFileName(newestFileName) != configuredFileName && newestFileName != "")
                            {
                                messagePrompt = "Trovato un file di database più nuovo " +
                                    "rispetto a quello attualmente utilizzato.\n" +
                                    "Devo usare\n" + Commons.PathAndFileDatabase + "\ncome database?\n";
                                if (MessageBox.Show(messagePrompt, "SchoolGrades", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    == DialogResult.Yes)
                                {
                                    Commons.PathAndFileDatabase = newestFileName;
                                    CreateBusinessLayer();
                                    Commons.bl.WriteConfigData();
                                    MessageBox.Show("File di configurazione salvato in " + Commons.PathAndFileConfig);
                                }
                                return;
                            }
                        }
                    }
                }
            }
#endif
            CreateBusinessLayer();
            // TODO remove the next conditioned compilation when the SQL server program is functioning
#if !SQL_SERVER
            Commons.bl.GetSchoolYearsThatHaveClasses();
            // da togliere dopo che il DataLayer SQL server funziona
            List<SchoolYear> ly = Commons.bl.GetSchoolYearsThatHaveClasses();
            cmbSchoolYear.DataSource = ly;
            if (ly.Count > 0)
                cmbSchoolYear.SelectedItem = ly[ly.Count - 1];

            // fill the combo of grade types 
            List<GradeType> ListGradeTypes = Commons.bl.GetListGradeTypes();
            cmbGradeType.DataSource = ListGradeTypes;

            // fill the combo of School subjects
            List<SchoolSubject> listSubjects = Commons.bl.GetListSchoolSubjects(true);
            cmbSchoolSubject.DataSource = listSubjects;
#endif
        }
        private void CreateDatabasePaths(string proposedDebugDatabaseFile)
        {

        }
        private void StartNewConfigurationForm()
        {
            // something didn't work, we must choose a good filename for the database file
            string messagePrompt = "Il file di configurazione " + Commons.PathAndFileConfig +
                "\nnon esiste o non è leggibile.\n" +
                "\nSistemare le cartelle con il percorso dei file, " +
                "poi scegliere il file di dati .sqlite e premere 'Salva configurazione'," +
                "\nI nomi scelti dal programma dovrebbero essere giusti.";
            Commons.PathAndFileDatabase = GetNewDatabaseFilename(Path.Combine(Commons.PathExe, "Data"));
            MessageBox.Show(messagePrompt, "SchoolGrades", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmSetup f = new frmSetup();
            f.ShowDialog();
        }
        private void CloseProgramWhileTestingIfConfigurationFileIsRight()
        {
            // read the config file once again 
            bool fileRead = Commons.ReadConfigData();
            if (!fileRead || !File.Exists(Commons.PathAndFileDatabase))
            {
                MessageBox.Show("Configurare il programma!", "SchoolGrades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Il programma verrà chiuso. Alla ripartenza funzionerà regolarmente.");
            }
            StopAllTimers();
            Commons.StopOperationsOnBackgroundThread();
            this.Close();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Commons.globalPicLed = picBackgroundSaveRunning;
            // start the Thread that concurrently saves the Topics tree
            Commons.CreateAndStartBackgroundSavingThread();

            if (!File.Exists(Commons.PathAndFileDatabase))
                return;

            timerQuestion.Interval = 250;

            lblDatabaseFile.Visible = true;

            lblLastDatabaseModification.Visible = true;
            lblLastDatabaseModification.Text = File.GetLastWriteTime(Commons.PathAndFileDatabase).ToString("yyyy-MM-dd HH:mm:ss");
            //#if !DEBUG
            //            // capture every exception for exception logging
            //            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            //            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            //#endif

            CreateBusinessLayer();
            // da togliere dopo che il DataLayer di SQL server funziona
#if !SQL_SERVER
            currentSchool = Commons.bl.GetSchool(Commons.IdSchool);
            if (currentSchool == null)
                return;

            if (cmbSchoolYear.SelectedItem != null)
                currentYear = (SchoolYear)cmbSchoolYear.SelectedItem;

            lstClasses.DataSource = Commons.bl.GetClassesOfYear(currentSchool.IdSchool, currentYear.IdSchoolYear);

            if (lstClasses.DataSource == null)
                return;
#endif

            if (chkActivateLessonClock.Checked)
            {
                CalculateTimesForEndLessonWarning();
                timerLesson.Start();
            }

            string file = Path.Combine(Commons.PathLogs, "frmMain_parameters.txt");
            Commons.RestoreCurrentValuesOfAllControls(this, file);

            txtNStudents.Text = "";

            picStudent.BringToFront();
            lblStudentChosen.BringToFront();
            lblIdStudent.BringToFront();
            txtIdStudent.BringToFront();
            lblStudentChosen.Visible = false;
            lblIdStudent.Visible = false;
            txtIdStudent.Visible = false;

            lblDatabaseFile.Text = Path.GetFileName(Commons.PathAndFileDatabase);
            initializingForm = false;

            // Initialize localization
            LocalizeForm();
        }
        private string GetNewDatabaseFilename(string proposedDatabasePath)
        {
            // depending on the type of database file configured, determine the name of a 
            // proposed database file 
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
            newDatabaseFileName = Commons.GetNewestAmongFilesWithDateInName(proposedDatabasePath);
            if (newDatabaseFileName != "")
                return newDatabaseFileName;
            else
                return "";
        }
        private bool CreateBusinessLayer()
        {
            // create Business layer object, to be used throughout the program
#if !SQL_SERVER
            // keep this order of creation. Create after reading config file
            if (!System.IO.File.Exists(Commons.PathAndFileDatabase))
            {
                string err = @"[" + Commons.PathAndFileDatabase + " not in the current nor in the dev directory]";
                Commons.ErrorLog(err);
                throw new System.IO.FileNotFoundException(err);
                return false;
            }
#endif
            Commons.bl = new BusinessLayer();
            if (Commons.bl == null)
                return false;
            return true;
        }
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string err = sender.GetType().Name + " " + e.Exception.Message +
                "\r\n" + e.Exception.StackTrace;
            Commons.ErrorLog(err);
            throw new Exception(err);
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (sender != null)
            {
                string err = sender.GetType().Name + " " + (e.ExceptionObject as Exception).Message +
                    (e.ExceptionObject as Exception).StackTrace;
                Commons.ErrorLog(err);
                throw new Exception(err);
            }
            else
            {
                string err = (e.ExceptionObject as Exception).Message +
                    (e.ExceptionObject as Exception).StackTrace;
                Commons.ErrorLog(err);
                throw new Exception(err);
            }
        }
        private void btnComeOn_Click(object sender, EventArgs e)
        {
            if (currentClass != null)
            {
                picStudent.Image = null;
                beBrave();
            }
            else
            if (!Commons.CheckIfClassChosen(currentClass))
                return;
            if (chkSuspence.Checked)
            {
                int suspenceDelay = 4069; // in ms
                try
                {
                    suonatore.SoundLocation = ".\\Lo squalo.wav";
                    suonatore.Play();
                    Thread.Sleep(suspenceDelay);
                }
                catch
                {
                    Console.Beep(220, suspenceDelay);
                }
            }
            if (currentClass.CurrentStudent != null)
            {
                loadStudentsData(currentClass.CurrentStudent);
            }
            else
            {

            }
        }
        private void loadStudentsData(Student Student)
        {
            //if (chkStudentsListVisible.Checked)
            loadStudentsPicture(Student);
            chkStudentsListVisible.Checked = false;
            lblStudentChosen.Text = Student.ToString();
            txtRevengeFactor.Text = Student.RevengeFactorCounter.ToString();
            txtIdStudent.Text = Student.IdStudent.ToString();
        }
        private void btnDrawOrSort_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            else
            {
                // read checksigns from the grid
                ReadCheckSignsIntoCurrentStudentsList();
                dgwStudents.Visible = false;
                if (!Commons.CheckIfSubjectChosen(currentSubject))
                    return;
                if (!Commons.CheckIfTypeOfAssessmentChosen(currentGradeType))
                    return;
                Commons.bl.DrawOrSort(GetTypeOfDrawFromUi(), currentStudentsList, ref eligiblesList,
                    currentClass, currentSubject, currentGradeType, rdbMustDraw.Checked);
                if (eligiblesList.Count == 0)
                {
                    MessageBox.Show(Loc.Get("Main_NoStudentPresent"));
                    return;
                }
                indexCurrentDrawn = 0;
                MessageBox.Show(Loc.Get("Main_DrawDone"), "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ListaVisibile = false;
                dgwStudents.Visible = false;
                chkStudentsListVisible.Checked = false;
            }
        }
        private TypeOfDraw GetTypeOfDrawFromUi()
        {
            TypeOfDraw type = TypeOfDraw.EqualProbability;
            if (rdbDrawEqualProbability.Checked)
                type = TypeOfDraw.EqualProbability;
            else if (rdbDrawByWeightsSum.Checked)
                type = TypeOfDraw.WeightsSum;
            else if (rdbDrawNoOfGrades.Checked)
                type = TypeOfDraw.NoOfGrades;
            else if (rdbDrawByOldestFirst.Checked)
                type = TypeOfDraw.OldestFirst;
            else if (rdbSortByAlphbetical.Checked)
                type = TypeOfDraw.Alphabetical;
            else if (rdbDrawLowGradesFirst.Checked)
                type = TypeOfDraw.LowGradesFirst;
            else if (rdbDrawByRevengeFactor.Checked)
                type = TypeOfDraw.RevengeFactor;

            return type;
        }
        private void btnAssess_Click(object sender, EventArgs e)
        {
            if (currentClass is null)
            {
                MessageBox.Show(Loc.Get("Main_SelectClass"));
                return;
            }
            if (cmbGradeType.Text == "")
            {
                MessageBox.Show(Loc.Get("Main_SelectGradeType"));
                return;
            }
            if (currentClass.CurrentStudent is null)
            {
                MessageBox.Show(Loc.Get("Main_SelectStudent"));
                return;
            }
            if (currentSubject == null)
            {
                MessageBox.Show(Loc.Get("Main_NoDrawNoPresent"));
                return;
            }
            currentGradeType = ((GradeType)cmbGradeType.SelectedItem);
            if (currentGradeType.IdGradeTypeParent == "")
            {
                MessageBox.Show(Loc.Get("Main_WrongGradeType"));
                return;
            }
            frmMicroAssessment grade = new frmMicroAssessment(this,
                currentClass, currentClass.CurrentStudent,
                currentGradeType, currentSubject, CurrentQuestion);
            //grade.ShowDialog();
            grade.Show();

            if (grade.CurrentQuestion != null)
            {
                CurrentQuestion = grade.CurrentQuestion;
                txtQuestion.Text = CurrentQuestion.Text;
                lstTimeInterval.Text = CurrentQuestion.Duration.ToString();
                // start the timer if the question has a timer
                if (CurrentQuestion.Duration != null && CurrentQuestion.Duration > 0)
                {
                    btnStartColorTimer_Click(null, null);
                }
            }
        }
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (dgwStudents.Visible)
                AllChecked();
        }
        private void btnCheckToggle_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (dgwStudents.Visible)
                AllToggle();
        }
        private void btnCheckNone_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (dgwStudents.Visible)
                AllUnChecked();
        }
        private void btnCheckRevenge_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (dgwStudents.Visible)
                AllCheckRevenge();
        }
        private void loadStudentsPicture(Student Chosen)
        {
            try
            {
                string pictureFile = Commons.bl.GetFilePhoto(Chosen.IdStudent,
                    currentYear.IdSchoolYear);
                if (pictureFile != null)
                {
                    pictureFile = Path.Combine(Commons.PathImages, pictureFile);
                }
                picStudent.Image = System.Drawing.Image.FromFile(pictureFile);
            }
            catch
            {
                picStudent.Image = null;
                Console.Beep();
            }
        }
        private void timerQuestion_Tick(object sender, EventArgs e)
        {
            ticksPassed++;
            int msPassati = ticksPassed * timerQuestion.Interval;
            if (msPassati <= pgbTimeQuestion.Maximum) pgbTimeQuestion.Value = pgbTimeQuestion.Maximum - msPassati;
        }
        private void lstNames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void chkNameIsVisible_CheckedChanged(object sender, EventArgs e)
        {
            lblStudentChosen.Visible = chkNameIsVisible.Checked;
        }
        private void lstClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!initializingForm)
            {
                picStudent.Image = null;
                lblStudentChosen.Text = "";
                chkStudentsListVisible.Checked = true;
                dgwStudents.DataSource = null;
            }
        }
        private void lstClasses_DoubleClick(object sender, EventArgs e)
        {
            SaveStudentsOfClassIfEligibleHasChanged();
            currentClass = (Class)lstClasses.SelectedItem;
            txtIdClass.Text = currentClass.IdClass.ToString();

            ShowStudentsOfClass();
            if (currentStudentsList != null)
                txtNStudents.Text = currentStudentsList.Count.ToString();
            else
                txtNStudents.Text = "";

            // play Happy Birthday when a student has his BirthDay
            List<Student> celebrated = Commons.bl.FindStudentsOnBirthday(currentClass, DateTime.Now);
            if (celebrated.Count > 0)
            {
                try
                {
                    suonatore.SoundLocation = ".\\Auguri.wav";
                    suonatore.Play();
                }
                catch
                {
                    Console.Beep(220, 1000);
                }
                foreach (Student s in celebrated)
                {
                    frmStudent f = new frmStudent(s, false);
                    f.Show();
                    // put full screen ther form 
                    // TODO 
                }
            }
            // show popup annotations of the students of the class
            var popUpAnnotationsList = Commons.bl.GetAnnotationsOfClass(currentClass.IdClass, true, true);
            if (popUpAnnotationsList != null && popUpAnnotationsList.Count > 0)
            {
                frmAnnotationsPopUp f = new frmAnnotationsPopUp(popUpAnnotationsList);
                f.StartPosition = FormStartPosition.CenterParent;
                f.Show();
            }
        }
        private void chkPhotoVisibible_CheckedChanged(object sender, EventArgs e)
        {
            picStudent.Visible = chkPhotoVisibile.Checked;
        }
        private void chkStudentsListVisible_CheckedChanged(object sender, EventArgs e)
        {
            dgwStudents.Visible = chkStudentsListVisible.Checked;
            lblStudentChosen.Visible = !chkStudentsListVisible.Checked;
            picStudent.Visible = !chkStudentsListVisible.Checked;
            lblIdStudent.Visible = !chkStudentsListVisible.Checked;
            txtIdStudent.Visible = !chkStudentsListVisible.Checked;
        }
        private void cmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
#if !SQL_SERVER
            currentSchool = Commons.bl.GetSchool(Commons.IdSchool);
            if (cmbSchoolYear.SelectedItem != null)
                currentYear = (SchoolYear)cmbSchoolYear.SelectedItem;
            lstClasses.DataSource = Commons.bl.GetClassesOfYear(currentSchool.IdSchool, currentYear.IdSchoolYear);
            //if (lstClasses.DataSource == null)
            //    return;
#endif
        }
        //private void btnSalvaInterrogati_Click(object sender, EventArgs e)
        //{
        //    SaveStudentsOfClassIfEligibleHasChanged();
        //}
        private void btnPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = txtPathImages.Text;
            DialogResult r = folderBrowserDialog.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {

                txtPathImages.Text = folderBrowserDialog.SelectedPath;
            }
        }
        Class lastClass = new Class();
        SchoolSubject lastSubject = new SchoolSubject();
        List<string> filesInFolder = new List<string>();
        int indexImage = 0;
        private DateTime nextPopUpQuestionTime;
        private void BtnShowRandomImage_Click(object sender, EventArgs e)
        {
            if (filesInFolder.Count == 0 || currentClass != lastClass || currentSubject != lastSubject
                || indexImage == filesInFolder.Count)
            {
                indexImage = 0;
                lastClass = currentClass;
                lastSubject = currentSubject;
                filesInFolder.Clear();
                if (chkGivenFolder.Checked)
                {
                    if (txtPathImages.Text != "")
                        Commons.bl.RecusivelyFindImagesUnderPath(txtPathImages.Text, ref filesInFolder);
                }
                if (chkLessonsPictures.Checked)
                {
                    if (!Commons.CheckIfClassChosen(currentClass))
                        return;
                    if (!Commons.CheckIfSubjectChosen(currentSubject))
                        return;
                    //List<Image> lessonImages = db.GetAllImagesShownToAClassDuringLessons(currentClass, currentSubject);
                    List<BusinessObjects.Image> lessonImages = Commons.bl.GetAllImagesShownToAClassDuringLessons(currentClass, currentSubject,
                        DateTime.Now.AddMonths(-8), DateTime.Now);
                    // add the path & filename of the files foud to the list of those that we can draw
                    foreach (BusinessObjects.Image i in lessonImages)
                    {
                        filesInFolder.Add(Path.Combine(Commons.PathImages, i.RelativePathAndFilename));
                    }
                }
                if (filesInFolder.Count > 0)
                    Commons.ListShuffleRandom(filesInFolder);
            }
            if (filesInFolder.Count > 0)
            {
                Commons.ProcessStartLink(filesInFolder[indexImage]);
                indexImage++;
            }
            else
            {
                Console.Beep();
            }
            ToggleTimerBar(txtTimeInterval.Text);
        }
        // show the lists in list boxes
        public void ShowStudentsOfClass()
        {
            if (lstClasses.SelectedItem != null)
            {
                currentStudentsList = Commons.bl.GetStudentsOfClassList((Class)lstClasses.SelectedItem, false);
                eligiblesList.Clear();

                if (currentStudentsList == null)
                    return;

                RefreshStudentsGrid();
            }
        }
        private void EqualizeTheNumberOfTheGrades()
        {
            // this option equalizes the number of the grades. 
            // a student is put in the list as many times as is necessary for him 
            // to have the same number of grades of the others
            // if you give grades to every element of the list, the students will 
            // have the same number of grades
            // find the number of microgrades for each student

            List<Student> CheckedStudents = new List<Student>();
            CopyCheckedStatusIntoEligiblesList();
            eligiblesList = Commons.bl.EqualizeTheNumberOfTheGrades(currentStudentsList, currentClass, currentGradeType);
        }
        private List<Student> FillListOfChecked(List<Student> StudentsList)
        {
            List<Student> CheckedList = new List<Student>();
            // fill the list with those included in the CheckedItems collection
            foreach (Student s in StudentsList)
            {
                if (s.Eligible == true)
                    CheckedList.Add(s);
            }
            return CheckedList;
        }
        public void SaveStudentsOfClassIfEligibleHasChanged()
        {
            // check if the Eligible field has changhed since when we read the students 
            dataModified = dataModified || CheckIfAnyEligibleHasChanged();
            if (currentStudentsList != null && dataModified)
                Commons.bl.SaveStudentsOfList(currentStudentsList, null);
        }
        private bool CheckIfAnyEligibleHasChanged()
        {
            bool OneIsDifferent = false;
            if (currentClass != null)
            {
                List<Student> oldList = Commons.bl.GetStudentsOfClassList(currentClass, false);
                if (currentStudentsList != null)
                {
                    for (int i = 0; i < oldList.Count; i++)
                    {
                        if (currentStudentsList[i].Eligible != oldList[i].Eligible)
                        {
                            OneIsDifferent = true;
                            break;
                        }
                    }
                }
            }
            return OneIsDifferent;
        }
        public void AllChecked()
        {
            foreach (Student s in currentStudentsList)
            {
                s.Eligible = true;
            }
            RefreshStudentsGrid();
        }
        public void AllUnChecked()
        {
            foreach (Student s in currentStudentsList)
            {
                s.Eligible = false;
            }
            RefreshStudentsGrid();
        }
        public void AllToggle()
        {
            foreach (Student s in currentStudentsList)
            {
                s.Eligible = !s.Eligible;
            }
            RefreshStudentsGrid();
        }
        private void AllCheckRevenge()
        {
            // TODO !!!! check all the students that have a RfCounter > minimum !!!! 
            foreach (Student s in currentStudentsList)
            {
                if (s.RevengeFactorCounter > 0)
                    s.Eligible = true;
                else
                    s.Eligible = false;
            }
            RefreshStudentsGrid();
        }
        private void AllCheckNonGraded()
        {
            List<int> nonGraded = Commons.bl.GetIdStudentsNonGraded(currentClass, currentGradeType,
                currentSubject);
            foreach (Student s in currentStudentsList)
            {
                s.Eligible = false;
                foreach (int k in nonGraded)
                {
                    if (k == s.IdStudent)
                    {
                        s.Eligible = true;
                        break;
                    }
                }
            }
            RefreshStudentsGrid();
        }
        public void ResetData()
        {
            string[] vettoreOut = new string[currentStudentsList.Count];
            for (int i = 0; i < currentStudentsList.Count; i++)
            {
                currentStudentsList[i].ArithmeticMean = 0;
                currentStudentsList[i].Sum = 0;
                currentStudentsList[i].DummyNumber = 0;
            }
            SaveStudentsOfClassIfEligibleHasChanged();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Question CurrentQuestion
        {
            get => currentQuestion;
            set
            {
                currentQuestion = value;
                txtQuestion.Text = currentQuestion.Text;
                lstTimeInterval.Text = currentQuestion.Duration.ToString();
                if (currentQuestion.Duration != null && currentQuestion.Duration != 0)
                    txtTimeInterval.Text = CurrentQuestion.Duration.ToString();
            }
        }
        private void showCurrentStudent(Student alli)
        {
            currentClass.CurrentStudent = alli;

            lblStudentChosen.Text = alli.ToString();
            if (lblStudentChosen.ForeColor == Color.Green)
                lblStudentChosen.ForeColor = Color.Red;
            else
                lblStudentChosen.ForeColor = Color.Green;
        }
        /// <summary>
        /// Passes to to next to be assessed
        /// </summary>
        public void beBrave()
        {
            if (eligiblesList.Count > 0)
                if (indexCurrentDrawn < eligiblesList.Count)
                {
                    showCurrentStudent(eligiblesList[indexCurrentDrawn]);
                    indexCurrentDrawn++;
                }
                else
                {
                    MessageBox.Show(Loc.Get("Main_ListFinished"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            else
                MessageBox.Show("Nessun sorteggio o nessuno presente! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ChosenStudent(Student descStudentChosen)
        {
            showCurrentStudent(descStudentChosen);
        }
        private void btnSetup_Click(object sender, EventArgs e)
        {
            // save current students because can be used by setup windows
            SaveStudentsOfClassIfEligibleHasChanged();

            frmSetup f = new frmSetup();
            f.ShowDialog();
            // show class (could have changed by the setup windows)
            ShowStudentsOfClass();

            if (f.NewDatabaseFile)
            {
                // restart from the beginning with a new database file 
                frmMain_Load(null, null);
                lblDatabaseFile.Text = Commons.DatabaseFileName_Current;
                currentStudentsList = null;
                eligiblesList.Clear();
            }
        }
        private void btnStudentsGradesSummary_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Parte da finire");
            //return; 

            if (!Commons.CheckIfClassChosen(currentClass))
                return;
            if (!Commons.CheckIfTypeOfAssessmentChosen(currentGradeType))
                return;
            if (!Commons.CheckIfStudentChosen(CurrentStudent))
                return;

            // annotation applied to a single student
            frmGradesStudentsSummary f = new frmGradesStudentsSummary(CurrentStudent, cmbSchoolYear.Text,
                currentGradeType, (SchoolSubject)cmbSchoolSubject.SelectedItem);
            f.Show();
        }
        private void btnOldestGrade_Click(object sender, EventArgs e)
        {
            // gets all the list, but we are interested only to the first, the oldest
            List<Couple> fromOldest = Commons.bl.GetGradesOldestInClass(currentClass,
                ((GradeType)(cmbGradeType.SelectedItem)), currentSubject);
            Student trovato = null;
            int keyFirst = fromOldest[0].Key;
            foreach (Student s in currentStudentsList)
            {
                if (s.IdStudent == keyFirst)
                {
                    trovato = s;
                    break;
                }
            }
            if (trovato == null)
            {
                MessageBox.Show("Allievo con voticino più vecchio non trovato");
                return;
            }
            currentClass.CurrentStudent = trovato;
            loadStudentsData(currentClass.CurrentStudent);
        }
        private void cmbGradeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentGradeType = (GradeType)cmbGradeType.SelectedItem;
        }
        private void btnLessonsTopics_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                MessageBox.Show(Loc.Get("Main_ChooseClass"));
                return;
            }
            if (!Commons.CheckIfSubjectChosen(currentSubject))
                return;
            // open read only the forms after the first. 
            if (listLessons.Count > 0)
            {
                // delete from listLessons those forms that have been closed
                int i = 0;
                while (i < listLessons.Count)
                {
                    frmLessons fl = listLessons[i];
                    if (fl.IsFormClosed)
                    {
                        listLessons.Remove(fl);
                        fl.Dispose();
                        i--;
                    }
                    i++;
                }
            }
            frmLessons flt;
            if (listLessons.Count == 0)
                flt = new frmLessons(currentClass, (SchoolSubject)cmbSchoolSubject.SelectedItem,
                    false);
            else
                flt = new frmLessons(currentClass, (SchoolSubject)cmbSchoolSubject.SelectedItem,
                    true);
            flt.Show();
            listLessons.Add(flt);
        }
        private void cmbSchoolSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSubject = (SchoolSubject)cmbSchoolSubject.SelectedItem;
            if (currentSubject.Name == null)
                currentSubject = null;
            Color bgColor = Commons.ColorFromNumber(currentSubject);
            this.BackColor = bgColor;
            lstClasses.BackColor = bgColor;
            lstTimeInterval.BackColor = bgColor;
            picStudent.BackColor = bgColor;
            lblCodYear.BackColor = bgColor;
        }
        private void btnTopicsDone_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
                return;
            if (!Commons.CheckIfSubjectChosen(currentSubject))
                return;
            frmTopics frm = new frmTopics(frmTopics.TopicsFormType.HighlightTopics,
                currentClass, currentSubject, currentQuestion, null, (frmMain)this, true);
            frm.Show();
        }
        private void btnStartLinks_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
                return;
            List<StartLink> LinksOfClass = Commons.bl.GetStartLinksOfClass(currentClass);

            Commons.StartLinks(currentClass, LinksOfClass);
        }
        private void btnQuestion_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfSubjectChosen(currentSubject))
                return;
            frmQuestionChoose scelta = new frmQuestionChoose(currentSubject,
                currentClass, CurrentStudent, CurrentQuestion);
            scelta.ShowDialog();
            if (scelta.ChosenQuestion != null && scelta.ChosenQuestion.IdQuestion != 0)
            {
                CurrentQuestion = scelta.ChosenQuestion;
            }
            scelta.Dispose();
        }
        private void pgbTimeQuestion_Click(object sender, EventArgs e)
        {
            ToggleTimerBar(txtTimeInterval.Text);
        }
        private void ToggleTimerBar(string Time)
        {
            if (timerQuestion.Enabled && pgbTimeQuestion.Value > 0)
            {
                timerQuestion.Stop();
                pgbTimeQuestion.Value = 0;
            }
            else
            {
                int value = -1;
                if (!int.TryParse(txtTimeInterval.Text, out value))
                {
                    Console.Beep();
                    return;
                }
                if (value > 1)
                {
                    ticksPassed = 0;
                    pgbTimeQuestion.Maximum = int.Parse(Time) * 1000;
                    timerQuestion.Start();
                }
            }
        }
        private void btnMakeGroups_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
                return;
            eligiblesList = FillListOfChecked(currentStudentsList);
            if (eligiblesList.Count == 0)
            {
                MessageBox.Show(Loc.Get("Main_NoStudents"));
                return;
            }
            if (cmbSchoolSubject.SelectedIndex == 0)
            {
                MessageBox.Show(Loc.Get("Main_NoSubjectSelected"));
                return;
            }
            // clone the list of students present to the lesson 
            // by using the constructor with parameters, that CLONES! 
            List<Student> groupsList = new List<Student>(eligiblesList);
            frmGroups f = new frmGroups(groupsList, currentClass, currentSubject, currentGradeType);
            f.Show();
        }
        private void txtPathImages_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtPathImages_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Commons.ProcessStartLink(txtPathImages.Text);
            }
            catch (Exception er)
            {
                //MessageBox.Show("Errore nell'aprire la cartella " + txtEdit.Text);
                ////+ "\nErrore: " + er.ToString());
            }
        }
        private void txtPathImages_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = txtPathImages.Text;
            openFileDialog.Title = "File da visualizzare";
            openFileDialog.Filter = "Tutti i file|*.*";
            openFileDialog.FileName = "";
            DialogResult r = openFileDialog.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
                try
                {
                    picStudent.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                    txtPathImages.Text = Path.GetDirectoryName(openFileDialog.FileName);
                }
                catch
                {
                    picStudent.Image = null;
                }
            lblStudentChosen.Text = Path.GetFileName(openFileDialog.FileName);
        }
        private void txtQuestion_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtQuestion_DoubleClick(object sender, EventArgs e)
        {
            frmQuestion f = new frmQuestion(frmQuestion.QuestionFormType.EditOneQuestion,
                CurrentQuestion, currentSubject, currentClass, null);
            f.Show();
        }
        private void btnRevengeFactorPlus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Loc.Get("Main_RevengeFactorIncrease"),
                    "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (NoStudentIsChecked())
            {
                MessageBox.Show(Loc.Get("Main_CheckStudentsForRevenge"));
                return;
            }
            foreach (Student s in currentStudentsList)
            {
                if (s.Eligible == true)
                {
                    if (s.RevengeFactorCounter == null)
                        s.RevengeFactorCounter = 0;
                    s.RevengeFactorCounter++;
                    Commons.bl.UpdateStudent(s);
                }
            }
            lstClasses_DoubleClick(null, null);
        }
        private bool NoStudentIsChecked()
        {
            bool found = false;
            foreach (Student s in currentStudentsList)
            {
                if (s.Eligible == true)
                {
                    found = true;
                    break;
                }
            }
            return !found;
        }
        private void btnRevengeFactorMinus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Loc.Get("Main_RevengeFactorDecrease"),
                    "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (currentStudentsList.Count == 0)
            {
                MessageBox.Show(Loc.Get("Main_CheckStudentsForRevengeDecrease"));
                return;
            }
            foreach (Student s in currentStudentsList)
            {
                if (s.Eligible == true)
                {
                    if (s.RevengeFactorCounter == null) s.RevengeFactorCounter = 0;
                    s.RevengeFactorCounter--;
                    if (s.RevengeFactorCounter < 0)
                        s.RevengeFactorCounter = 0;
                    Commons.bl.UpdateStudent(s);
                }
            }
            lstClasses_DoubleClick(null, null);
        }
        private void rdbDrawByRevengeFactor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDrawByRevengeFactor.Checked)
            {
                try
                {
                    suonatore.SoundLocation = ".\\Rigoletto.wav";
                    suonatore.Play();
                }
                catch
                {
                    Console.Beep(220, 1000);
                }
            }
        }
        private void picStudent_DoubleClick(object sender, EventArgs e)
        {
            frmStudent fs = new frmStudent(CurrentStudent, true);
            fs.ShowDialog();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!File.Exists(Commons.PathAndFileDatabase))
                return;
            Commons.StopOperationsOnBackgroundThread();
            string file = Commons.PathLogs + @"\frmMain_parameters.txt";
            Commons.SaveCurrentValuesOfAllControls(this, ref file);
            SaveStudentsOfClassIfEligibleHasChanged();
            // save in the log folder a copy of the database, if enabled 
            if (Commons.SaveBackupWhenExiting)
            {
                File.Copy(Commons.PathAndFileDatabase,
                    Path.Combine(Commons.PathLogs, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") +
                    "_" + Commons.DatabaseFileName_Current));
            }
            Commons.TerminateBackgroundThread();
        }
        private void StopAllTimers()
        {
            timerLesson.Stop();
            timerPopUp.Stop();
            timerQuestion.Stop();
        }
        private void btnClassesGradesSummary_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (!Commons.CheckIfSubjectChosen(currentSubject))
            {
                return;
            }
            frmGradesClassSummary f;
            f = new frmGradesClassSummary(currentClass,
                currentGradeType, currentSubject);
            f.Show();
        }
        private void btnCheckNoGrade_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (!Commons.CheckIfSubjectChosen(currentSubject))
            {
                return;
            }
            if (dgwStudents.Visible)
                AllCheckNonGraded();
        }
        private void btnYearTopics_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (!Commons.CheckIfSubjectChosen(currentSubject))
            {
                return;
            }
            string filenameNoExtension = currentClass.SchoolYear +
                "_" + currentClass.Abbreviation +
                "_" + currentSubject.IdSchoolSubject + "_" +
                "all-topics";
            string createdFile;
            if (MessageBox.Show(Loc.Get("Main_CreateTextFile"),
                Loc.Get("Main_FileType"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                createdFile = Commons.bl.CreateAllTopicsDoneFile(filenameNoExtension, currentClass, currentSubject, true);
                Commons.ProcessStartLink(createdFile);
            }
            else
            {
                createdFile = Commons.bl.CreateAllTopicsDoneFile(filenameNoExtension, currentClass, currentSubject, false);
                Commons.ProcessStartLink(createdFile);
            }
            MessageBox.Show(Loc.Get("Main_FileCreated") + " " + createdFile);
        }
        private void chkEnableEndLessonWarning_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableEndLessonWarning.Checked)
            {
                CalculateTimesForEndLessonWarning();
            }
        }
        private void CalculateTimes()
        {
            // start the colored button that shows the time to the end of the lesson
            int.TryParse(txtMinuteStartLesson.Text, out minuteStart);
            float.TryParse(txtDurationLesson.Text, out timeLessonMinutes);

            float.TryParse(txtAdvanceMinutes.Text, out timeAlarmMinutes);
            if (minuteStart <= 0 || minuteStart >= 60)
            {
                minuteStart = 0;
                txtMinuteStartLesson.Text = "0";
            }
            TimeSpan duration = new TimeSpan(0, (int)timeLessonMinutes, 0);
            DateTime now = DateTime.Now;
            //DateTime oneHourBeforeNow = now.Add(new TimeSpan(-1, 0, 0));
            thisLessonStartTime = new DateTime(now.Year, now.Month,
                now.Day, now.Hour, minuteStart, 0);
            if (thisLessonStartTime > now)
                thisLessonStartTime = thisLessonStartTime.Add(new TimeSpan(-1, 0, 0));
            thisLessonEndTime = thisLessonStartTime.Add(duration);

            ticksToMinutesFactor = (float)(1.0 / 60.0) / 10000000;

            // Hue difference to cover
            spanHue = finalColor.GetHue() - startColor.GetHue();
            // Saturation difference to cover
            //spanSaturation = coloreFinale.GetSaturation() - coloreIniziale.GetSaturation(); 
            spanSaturation = 0;
            // Luminance difference to cover
            //spanLuminance = coloreFinale.GetBrightness() - coloreIniziale.GetBrightness();
            spanLuminance = 0;
            alarmNotFired = true;
        }
        private void CalculateTimesForEndLessonWarning()
        {
            // start the colored button that shows the time to the end of the lesson
            int.TryParse(txtMinuteStartLesson.Text, out minuteStart);
            float.TryParse(txtDurationLesson.Text, out timeLessonMinutes);

            float.TryParse(txtAdvanceMinutes.Text, out timeAlarmMinutes);
            if (minuteStart <= 0 || minuteStart >= 60)
            {
                minuteStart = 0;
                txtMinuteStartLesson.Text = "0";
            }
            TimeSpan duration = new TimeSpan(0, (int)timeLessonMinutes, 0);
            DateTime now = DateTime.Now;
            //DateTime oneHourBeforeNow = now.Add(new TimeSpan(-1, 0, 0));
            thisLessonStartTime = new DateTime(now.Year, now.Month,
                now.Day, now.Hour, minuteStart, 0);
            if (thisLessonStartTime > now)
                thisLessonStartTime = thisLessonStartTime.Add(new TimeSpan(-1, 0, 0));
            thisLessonEndTime = thisLessonStartTime.Add(duration);

            ticksToMinutesFactor = (float)(1.0 / 60.0) / 10000000;

            // Hue difference to cover
            spanHue = finalColor.GetHue() - startColor.GetHue();
            // Saturation difference to cover
            //spanSaturation = coloreFinale.GetSaturation() - coloreIniziale.GetSaturation(); 
            spanSaturation = 0;
            // Luminance difference to cover
            //spanLuminance = coloreFinale.GetBrightness() - coloreIniziale.GetBrightness();
            spanLuminance = 0;
            alarmNotFired = true;
        }
        private void timerLesson_Tick(object sender, EventArgs e)
        {
            timeLeftMinutes = ticksToMinutesFactor * (thisLessonEndTime.Ticks - DateTime.Now.Ticks);

            if (chkEnableEndLessonWarning.Checked)
            {
                if (timeLeftMinutes <= timeAlarmMinutes && alarmNotFired)
                {
                    alarmNotFired = false;
                    try
                    {
                        suonatore.SoundLocation = ".\\La Sveglia.wav";
                        suonatore.Play();
                    }
                    catch
                    {
                        Console.Beep(880, 1000);
                    }
                    //MessageBox.Show("Mancano meno di " + timeAlarmMinutes + " minuti alla fine della lezione");
                    MessageBox.Show(string.Format(Loc.Get("Main_MinutesToEnd"), timeAlarmMinutes));
                }
            }
            if (timeLeftMinutes >= 0)
            {
                // changes color from startColor to finalColor
                colHSL.Hue = (int)(startColor.GetHue() + spanHue * (timeLessonMinutes - timeLeftMinutes) / (timeLessonMinutes));
                colHSL.Saturation = startColor.GetSaturation() + spanSaturation * (timeLessonMinutes - timeLeftMinutes) / (timeLessonMinutes);
                colHSL.Luminance = startColor.GetBrightness() + spanLuminance * (timeLessonMinutes - timeLeftMinutes) / timeLessonMinutes;
                ColorHelper.ColorConverter.HSL2RGB(colHSL, colRGB);
                CurrentLessonTimeColor = colRGB.Color;

                btnLessonTime.BackColor = CurrentLessonTimeColor;
            }
            else
            {
                timerLesson.Stop();
                CurrentLessonTimeColor = Color.Transparent;
                btnLessonTime.BackColor = CurrentLessonTimeColor;
            }
        }
        private void chkActivateLessonClock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivateLessonClock.Checked)
                timerLesson.Enabled = true;
            else
            {
                timerLesson.Enabled = false;
                CurrentLessonTimeColor = Color.Transparent;
                btnLessonTime.BackColor = CurrentLessonTimeColor;
            }
            Commons.IsTimerLessonActive = chkActivateLessonClock.Checked;
        }
        private void btnTemporary_Click(object sender, EventArgs e)
        {
            SchoolYear sy = new();
            sy.IdSchoolYear = "23-24";
            sy.Notes = "Anno di prova";
            sy.ShortDescription = "2023-2024";
            sy.Notes = "Anno scolastico introdotto per sola prova";
            Commons.bl.AddSchoolYearIfNotExists(sy);
        }
        private void btnLessonTime_Click(object sender, EventArgs e)
        {
            txtMinuteStartLesson.Text = DateTime.Now.Minute.ToString();
            CalculateTimesForEndLessonWarning();
        }
        private void LessonAlarmChanged(object sender, EventArgs e)
        {
            CalculateTimesForEndLessonWarning();
        }
        private void txtDurationLesson_Leave(object sender, EventArgs e)
        {

        }
        private void lstTimeInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            txtTimeInterval.Text = lb.SelectedItem.ToString();
        }
        private void lstTimeInterval_DoubleClick(object sender, EventArgs e)
        {
            ToggleTimerBar(txtTimeInterval.Text);
        }
        private void StartColorTimer(bool SoundEffectsInTimer)
        {
            double t = 0; 
            if (!double.TryParse(txtTimeInterval.Text,out t))
            {
                Console.Beep();
                return;
            }
            ColorTimer ft = new ColorTimer(t / 60, t / 60, SoundEffectsInTimer);
            ft.Text = "Color Timer";
            if (CurrentStudent != null)
            {
                if (CurrentStudent.LastName == null)
                    CurrentStudent.LastName = "";
                if (CurrentStudent.FirstName == null)
                    CurrentStudent.FirstName = "";
                ft.Text = CurrentStudent.LastName + " " + CurrentStudent.FirstName;   
            }
            ft.Show();
        }
        private void btnStartColorTimer_Click(object sender, EventArgs e)
        {
            StartColorTimer(chkSoundsInColorTimer.Checked);
        }
        private void btnMosaic_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
                return;
            frmMosaic f = new frmMosaic(currentClass);
            f.Show();
        }
        private void btnStartBarTimer_Click(object sender, EventArgs e)
        {
            ToggleTimerBar(txtTimeInterval.Text);
        }
        private void btnStudentsNotes_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
                return;
            if (!Commons.CheckIfTypeOfAssessmentChosen(currentGradeType))
                return;
            // annotation can be applied to a single student or to a whole list, based on the 
            // lstNames being visible or not 
            List<Student> chosenStudents;
            if (CurrentStudent != null && !dgwStudents.Visible)
            {
                // annotation applied to a single student
                chosenStudents = new List<Student>();
                chosenStudents.Add(CurrentStudent);
            }
            else
            {
                // read checksigns from the grid
                ReadCheckSignsIntoCurrentStudentsList();
                // annotation applied to a whole list of students
                chosenStudents = FillListOfChecked(currentStudentsList);
            }
            if (chosenStudents.Count > 0)
            {
                frmAnnotationsAboutStudents f = new frmAnnotationsAboutStudents(chosenStudents, cmbSchoolYear.Text);
                f.StartPosition = FormStartPosition.CenterParent;
                f.Show();
            }
        }
        private void chkPopUpQuestionsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            timerPopUp.Interval = 1;
            timerPopUp.Enabled = chkPopUpQuestionsEnabled.Checked;
            if (timerPopUp.Enabled)
            {
                SetNewPopUpOfStudentToQuestion();
            }
        }
        private void SetNewPopUpOfStudentToQuestion()
        {
            int PopUpQuestionCentralTime;
            if (!int.TryParse(txtPopUpQuestionCentralTime.Text, out PopUpQuestionCentralTime))
            {
                txtPopUpQuestionCentralTime.Text = "";
                return;
            }
            double displacementTime = PopUpQuestionCentralTime * 0.1;
            double minutesToTheNextQuestion = PopUpQuestionCentralTime - random.NextDouble() *
                PopUpQuestionCentralTime * displacementTime / 4;
            nextPopUpQuestionTime = DateTime.Now.AddMinutes(minutesToTheNextQuestion);
            timerPopUp.Enabled = true;
        }
        private void txtPopUpQuestionCentralTime_TextChanged(object sender, EventArgs e)
        {
            if (timerPopUp.Enabled)
            {
                SetNewPopUpOfStudentToQuestion();
            }
        }
        private void timerPopUp_Tick(object sender, EventArgs e)
        {
            if (nextPopUpQuestionTime <= DateTime.Now)
            {
                timerPopUp.Enabled = false;
                if (currentClass == null)
                {
                    Console.Beep(1000, 500);
                    SetNewPopUpOfStudentToQuestion();
                    return;
                }
                if (eligiblesList.Count > 0)
                {
                    if (indexCurrentDrawn < eligiblesList.Count)
                    {
                        // make a question to a random student
                        // draws the student wiyh the criterion set in the U.I. 
                        btnComeOn_Click(null, null);
                        chkPhotoVisibile.Checked = true;
                        btnAssess_Click(null, null);
                        // tell the user that he has a new student chosen 
                        Console.Beep(400, 800);
                        // prepare for the next popup question 
                        SetNewPopUpOfStudentToQuestion();
                        return;
                    }
                    else
                    {
                        Console.Beep(2000, 500);
                        SetNewPopUpOfStudentToQuestion();
                        return;
                    }
                }
                else
                {
                    //Console.Beep(3000, 500);
                    SetNewPopUpOfStudentToQuestion();
                    return;
                }
            }
        }
        private void btnRandomNumber_Click(object sender, EventArgs e)
        {
            frmRandom f = new frmRandom();
            f.Show();
        }
        private void chkSoundsInColorTimer_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Chiudere la finestra timer a colori per cambiare lo stato dei suoni"); 
        }
        private void dgwStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dgwStudents.CurrentCell.ColumnIndex == 0)
                {
                    if (currentStudentsList[e.RowIndex].Eligible == null)
                        currentStudentsList[e.RowIndex].Eligible = false;
                    currentStudentsList[e.RowIndex].Eligible = !currentStudentsList[e.RowIndex].Eligible;
                    if (currentStudentsList == null)
                        return;
                    RefreshStudentsGrid();
                }
            }
        }
        private void dgwStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (!Commons.CheckIfClassChosen(currentClass))
                {
                    return;
                }
                currentClass.CurrentStudent = currentStudentsList[e.RowIndex];
                CurrentStudent = currentClass.CurrentStudent;
                CurrentStudent.SchoolYear = currentClass.SchoolYear;
                loadStudentsData(CurrentStudent);
                dgwStudents.Visible = false;
                txtIdStudent.Visible = true;
                lblIdStudent.Visible = true;
            }
        }
        private void dgwStudents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgwStudents.ReadOnly = true;
            if (dgwStudents.Columns.Count == 29)
            {
                DataGridViewCheckBoxColumn chkSelected = new DataGridViewCheckBoxColumn();
                {
                    chkSelected.HeaderText = "Chosen";
                    chkSelected.Name = "chkSelected";
                    chkSelected.ReadOnly = false;
                }
                dgwStudents.Columns.Insert(0, chkSelected);
            }
        }
        private void RefreshStudentsGrid()
        {
            dgwStudents.DataSource = null;
            dgwStudents.DataSource = currentStudentsList;
            dgwStudents.Refresh();
            dgwStudents.Visible = true;

            if (dgwStudents.Columns.Count > 0)
            {
                dgwStudents.Columns[1].Visible = false;

                //dgwStudents.Columns[4].Visible = false;
                dgwStudents.Columns[5].Visible = false;
                dgwStudents.Columns[6].Visible = false;
                dgwStudents.Columns[7].Visible = false;
                dgwStudents.Columns[8].Visible = false;
                dgwStudents.Columns[9].Visible = false;
                dgwStudents.Columns[10].Visible = false;
                dgwStudents.Columns[11].Visible = false;
                dgwStudents.Columns[12].Visible = false;
                dgwStudents.Columns[13].Visible = false;
                dgwStudents.Columns[14].Visible = false;
                dgwStudents.Columns[15].Visible = false;
                dgwStudents.Columns[16].Visible = false;

                dgwStudents.Columns[18].Visible = false;
                dgwStudents.Columns[19].Visible = false;
                dgwStudents.Columns[20].Visible = false;
                dgwStudents.Columns[21].Visible = false;
                dgwStudents.Columns[22].Visible = false;
                dgwStudents.Columns[23].Visible = false;
                dgwStudents.Columns[24].Visible = false;
                dgwStudents.Columns[25].Visible = false;
                dgwStudents.Columns[26].Visible = false;
                dgwStudents.Columns[27].Visible = false;
                int Index = 0;
                foreach (Student s in currentStudentsList)
                {
                    // "manually" set the check columm (0)
                    if (s.Eligible == true)
                    {
                        dgwStudents.Rows[Index].Cells[0].Value = true;
                    }
                    else
                    {
                        dgwStudents.Rows[Index].Cells[0].Value = false;
                    }
                    Index++;
                }
            }
        }
        private void CopyCheckedStatusIntoEligiblesList()
        {
            // copy the checked status from the CheckedListBox
            foreach (Student stud in currentStudentsList)
            {
                bool found = false;
                foreach (Student s in currentStudentsList)
                {
                    if (s.Eligible == true)
                    {
                        if (stud == s)
                        {
                            found = true;
                            break;
                        }
                    }
                }
                stud.Eligible = found;
            }
        }
        private void ReadCheckSignsIntoCurrentStudentsList()
        {
            int i = 0;
            foreach (DataGridViewRow r in dgwStudents.Rows)
            {
                currentStudentsList[i].Eligible = (bool)r.Cells[0].Value;
            }
        }
        private void lblStudentChosen_DoubleClick(object sender, EventArgs e)
        {
            if (CurrentStudent != null)
            {
                frmStudent fs = new frmStudent(CurrentStudent, true);
                fs.ShowDialog();
            }
        }
        private void LocalizeForm()
        {
            try
            {
                // Buttons - Verifica esistenza prima di localizzare
                if (btnDraw != null) btnDraw.Text = Loc.Get("Main_Draw");
                if (btnComeOn != null) btnComeOn.Text = Loc.Get("Main_ComeOn");
                if (btnSetup != null) btnSetup.Text = Loc.Get("Main_Setup");
                if (btnAssess != null) btnAssess.Text = Loc.Get("Main_Assess");
                if (btnCheckAll != null) btnCheckAll.Text = Loc.Get("Main_CheckAll");
                if (btnCheckNone != null) btnCheckNone.Text = Loc.Get("Main_CheckNone");
                if (btnCheckToggle != null) btnCheckToggle.Text = Loc.Get("Main_CheckToggle");
                if (btnCheckNoGrade != null) btnCheckNoGrade.Text = Loc.Get("Main_CheckNoGrade");
                if (btnCheckRevenge != null) btnCheckRevenge.Text = Loc.Get("Main_CheckRevenge");
                if (btnOldestGrade != null) btnOldestGrade.Text = Loc.Get("Main_OldestGrade");
                if (btnStudentsGradesSummary != null) btnStudentsGradesSummary.Text = Loc.Get("Main_StudentGradesSummary");
                if (btnClassesGradesSummary != null) btnClassesGradesSummary.Text = Loc.Get("Main_ClassGradesSummary");
                if (btnLessonsTopics != null) btnLessonsTopics.Text = Loc.Get("Main_Lessons");
                if (btnTopicsDone != null) btnTopicsDone.Text = Loc.Get("Main_TopicsDone");
                if (btnYearTopics != null) btnYearTopics.Text = Loc.Get("Main_YearTopics");
                if (btnStartLinks != null) btnStartLinks.Text = Loc.Get("Main_StartLinks");
                if (btnQuestion != null) btnQuestion.Text = Loc.Get("Main_Question");
                if (btnMakeGroups != null) btnMakeGroups.Text = Loc.Get("Main_MakeGroups");
                if (btnLessonTime != null) btnLessonTime.Text = Loc.Get("Main_LessonTime");
                if (btnVindicationFactorPlus != null) btnVindicationFactorPlus.Text = Loc.Get("Main_RevengeFactorPlus");
                if (btnVindicationFactorMinus != null) btnVindicationFactorMinus.Text = Loc.Get("Main_RevengeFactorMinus");
                if (btnShowRandomImage != null) btnShowRandomImage.Text = Loc.Get("Main_ShowRandomImage");
                if (btnStartColorTimer != null) btnStartColorTimer.Text = Loc.Get("Main_StartColorTimer");
                if (btnStartBarTimer != null) btnStartBarTimer.Text = Loc.Get("Main_StartBarTimer");
                if (btnMosaic != null) btnMosaic.Text = Loc.Get("Main_Mosaic");
                if (btnStudentsNotes != null) btnStudentsNotes.Text = Loc.Get("Main_StudentsNotes");
                if (btnRandomNumber != null) btnRandomNumber.Text = Loc.Get("Main_RandomNumber");

                // Labels
                if (lblSchoolSubject != null) lblSchoolSubject.Text = Loc.Get("Main_SchoolSubject");
                if (lblGradeType != null) lblGradeType.Text = Loc.Get("Main_GradeType");
                if (lblVindicationFactor != null) lblVindicationFactor.Text = Loc.Get("Main_RevengeFactorLabel");
                if (label1 != null) label1.Text = Loc.Get("Main_MinuteStart");
                if (label3 != null) label3.Text = Loc.Get("Main_MinutesDuration");
                if (label4 != null) label4.Text = Loc.Get("Main_AdvanceMinutes");
                if (label6 != null) label6.Text = Loc.Get("Main_NumberOfStudents");
                if (lblCodYear != null) lblCodYear.Text = Loc.Get("Main_SchoolYearCode");
                if (lblIdStudent != null) lblIdStudent.Text = Loc.Get("Main_IdStudent");
                if (label7 != null) label7.Text = Loc.Get("Main_IdClass");
                if (label2 != null) label2.Text = Loc.Get("Main_SaveDb");
                if (label8 != null) label8.Text = Loc.Get("Main_Time");

                // CheckBoxes
                if (chkNameIsVisible != null) chkNameIsVisible.Text = Loc.Get("Main_NameIsVisible");
                if (chkPhotoVisibile != null) chkPhotoVisibile.Text = Loc.Get("Main_PhotoVisible");
                if (chkStudentsListVisible != null) chkStudentsListVisible.Text = Loc.Get("Main_StudentsListVisible");
                if (chkSuspence != null) chkSuspence.Text = Loc.Get("Main_Suspence");
                if (chkActivateLessonClock != null) chkActivateLessonClock.Text = Loc.Get("Main_ActivateLessonClock");
                if (chkEnableEndLessonWarning != null) chkEnableEndLessonWarning.Text = Loc.Get("Main_EnableEndLessonWarning");
                if (chkPopUpQuestionsEnabled != null) chkPopUpQuestionsEnabled.Text = Loc.Get("Main_PopUpQuestionsEnabled");
                if (chkSoundsInColorTimer != null) chkSoundsInColorTimer.Text = Loc.Get("Main_SoundsInColorTimer");
                if (chkLessonsPictures != null) chkLessonsPictures.Text = Loc.Get("Main_LessonsPictures");
                if (chkGivenFolder != null) chkGivenFolder.Text = Loc.Get("Main_GivenFolder");

                // GroupBoxes
                if (grpSorts != null) grpSorts.Text = Loc.Get("Main_SortsGroup");
                if (grpImageSource != null) grpImageSource.Text = Loc.Get("Main_ImageSourceGroup");
                //if (grpChooseDrawSort != null) grpChooseDrawSort.Text = Loc.Get("Main_ChooseDrawSort");

                // RadioButtons
                if (rdbDrawEqualProbability != null) rdbDrawEqualProbability.Text = Loc.Get("Main_EqualProbability");
                if (rdbDrawByWeightsSum != null) rdbDrawByWeightsSum.Text = Loc.Get("Main_WeightsSum");
                if (rdbDrawNoOfGrades != null) rdbDrawNoOfGrades.Text = Loc.Get("Main_NoOfGrades");
                if (rdbSortByAlphbetical != null) rdbSortByAlphbetical.Text = Loc.Get("Main_Alphabetical");
                if (rdbDrawLowGradesFirst != null) rdbDrawLowGradesFirst.Text = Loc.Get("Main_LowGradesFirst");
                if (rdbDrawByOldestFirst != null) rdbDrawByOldestFirst.Text = Loc.Get("Main_OldestFirst");
                if (rdbDrawByRevengeFactor != null) rdbDrawByRevengeFactor.Text = Loc.Get("Main_RevengeFactor");
                if (rdbMustDraw != null) rdbMustDraw.Text = Loc.Get("Main_MustDraw");
                if (rdbMustSort != null) rdbMustSort.Text = Loc.Get("Main_MustSort");

                // Tooltips - Solo se il controllo esiste
                if (toolTip1 != null)
                {
                    // Tooltips - Buttons
                    if (btnDraw != null) toolTip1.SetToolTip(btnDraw, Loc.Get("Main_Tooltip_Draw"));
                    if (btnComeOn != null) toolTip1.SetToolTip(btnComeOn, Loc.Get("Main_Tooltip_ComeOn"));
                    if (btnCheckNone != null) toolTip1.SetToolTip(btnCheckNone, Loc.Get("Main_Tooltip_CheckNone"));
                    if (btnCheckAll != null) toolTip1.SetToolTip(btnCheckAll, Loc.Get("Main_Tooltip_CheckAll"));
                    if (btnCheckToggle != null) toolTip1.SetToolTip(btnCheckToggle, Loc.Get("Main_Tooltip_CheckToggle"));
                    if (btnCheckRevenge != null) toolTip1.SetToolTip(btnCheckRevenge, Loc.Get("Main_Tooltip_CheckRevenge"));
                    if (btnCheckNoGrade != null) toolTip1.SetToolTip(btnCheckNoGrade, Loc.Get("Main_Tooltip_CheckNoGrade"));
                    if (btnSetup != null) toolTip1.SetToolTip(btnSetup, Loc.Get("Main_Tooltip_Setup"));
                    if (btnStudentsGradesSummary != null) toolTip1.SetToolTip(btnStudentsGradesSummary, Loc.Get("Main_Tooltip_StudentGradesSummary"));
                    if (btnOldestGrade != null) toolTip1.SetToolTip(btnOldestGrade, Loc.Get("Main_Tooltip_OldestGrade"));
                    if (btnLessonsTopics != null) toolTip1.SetToolTip(btnLessonsTopics, Loc.Get("Main_Tooltip_Lessons"));
                    if (btnTopicsDone != null) toolTip1.SetToolTip(btnTopicsDone, Loc.Get("Main_Tooltip_TopicsDone"));
                    if (btnStartLinks != null) toolTip1.SetToolTip(btnStartLinks, Loc.Get("Main_Tooltip_StartLinks"));
                    if (btnQuestion != null) toolTip1.SetToolTip(btnQuestion, Loc.Get("Main_Tooltip_Question"));
                    if (btnMakeGroups != null) toolTip1.SetToolTip(btnMakeGroups, Loc.Get("Main_Tooltip_MakeGroups"));
                    if (btnLessonTime != null) toolTip1.SetToolTip(btnLessonTime, Loc.Get("Main_Tooltip_LessonTime"));
                    if (btnVindicationFactorPlus != null) toolTip1.SetToolTip(btnVindicationFactorPlus, Loc.Get("Main_Tooltip_RevengeFactorPlus"));
                    if (btnVindicationFactorMinus != null) toolTip1.SetToolTip(btnVindicationFactorMinus, Loc.Get("Main_Tooltip_RevengeFactorMinus"));
                    if (btnClassesGradesSummary != null) toolTip1.SetToolTip(btnClassesGradesSummary, Loc.Get("Main_Tooltip_ClassGradesSummary"));
                    if (btnYearTopics != null) toolTip1.SetToolTip(btnYearTopics, Loc.Get("Main_Tooltip_YearTopics"));
                    if (btnStudentsNotes != null) toolTip1.SetToolTip(btnStudentsNotes, Loc.Get("Main_Tooltip_StudentsNotes"));
                    if (btnShowRandomImage != null) toolTip1.SetToolTip(btnShowRandomImage, Loc.Get("Main_Tooltip_ShowRandomImage"));
                    if (btnMosaic != null) toolTip1.SetToolTip(btnMosaic, Loc.Get("Main_Tooltip_Mosaic"));
                    if (btnStartColorTimer != null) toolTip1.SetToolTip(btnStartColorTimer, Loc.Get("Main_Tooltip_StartColorTimer"));
                    if (btnStartBarTimer != null) toolTip1.SetToolTip(btnStartBarTimer, Loc.Get("Main_Tooltip_StartBarTimer"));
                    if (btnRandomNumber != null) toolTip1.SetToolTip(btnRandomNumber, Loc.Get("Main_Tooltip_RandomNumber"));
                    if (btnPath != null) toolTip1.SetToolTip(btnPath, Loc.Get("Main_Tooltip_PathButton"));

                    // Tooltips - Altri controlli principali
                    if (lstClasses != null) toolTip1.SetToolTip(lstClasses, Loc.Get("Main_Tooltip_ClassesList"));
                    if (pgbTimeQuestion != null) toolTip1.SetToolTip(pgbTimeQuestion, Loc.Get("Main_Tooltip_TimeProgressBar"));
                    if (chkNameIsVisible != null) toolTip1.SetToolTip(chkNameIsVisible, Loc.Get("Main_Tooltip_NameIsVisible"));
                    if (chkPhotoVisibile != null) toolTip1.SetToolTip(chkPhotoVisibile, Loc.Get("Main_Tooltip_PhotoVisible"));
                    if (chkStudentsListVisible != null) toolTip1.SetToolTip(chkStudentsListVisible, Loc.Get("Main_Tooltip_StudentsListVisible"));
                    if (cmbSchoolYear != null) toolTip1.SetToolTip(cmbSchoolYear, Loc.Get("Main_Tooltip_SchoolYear"));
                    if (txtPathImages != null) toolTip1.SetToolTip(txtPathImages, Loc.Get("Main_Tooltip_ImagesPath"));
                    if (cmbGradeType != null) toolTip1.SetToolTip(cmbGradeType, Loc.Get("Main_Tooltip_GradeType"));
                    if (cmbSchoolSubject != null) toolTip1.SetToolTip(cmbSchoolSubject, Loc.Get("Main_Tooltip_SchoolSubject"));
                    if (txtQuestion != null) toolTip1.SetToolTip(txtQuestion, Loc.Get("Main_Tooltip_QuestionText"));
                    if (chkSuspence != null) toolTip1.SetToolTip(chkSuspence, Loc.Get("Main_Tooltip_Suspence"));
                    if (chkActivateLessonClock != null) toolTip1.SetToolTip(chkActivateLessonClock, Loc.Get("Main_Tooltip_ActivateLessonClock"));

                    // Tooltips - RadioButtons
                    if (rdbDrawEqualProbability != null) toolTip1.SetToolTip(rdbDrawEqualProbability, Loc.Get("Main_Tooltip_EqualProbability"));
                    if (rdbDrawByWeightsSum != null) toolTip1.SetToolTip(rdbDrawByWeightsSum, Loc.Get("Main_Tooltip_WeightsSum"));
                    if (rdbDrawNoOfGrades != null) toolTip1.SetToolTip(rdbDrawNoOfGrades, Loc.Get("Main_Tooltip_NoOfGrades"));
                    if (rdbDrawByOldestFirst != null) toolTip1.SetToolTip(rdbDrawByOldestFirst, Loc.Get("Main_Tooltip_OldestFirst"));
                    if (rdbSortByAlphbetical != null) toolTip1.SetToolTip(rdbSortByAlphbetical, Loc.Get("Main_Tooltip_Alphabetical"));
                    if (rdbDrawLowGradesFirst != null) toolTip1.SetToolTip(rdbDrawLowGradesFirst, Loc.Get("Main_Tooltip_LowGradesFirst"));
                    if (rdbDrawByRevengeFactor != null) toolTip1.SetToolTip(rdbDrawByRevengeFactor, Loc.Get("Main_Tooltip_RevengeFactor"));

                    // Tooltips - CheckBoxes aggiuntive
                    if (chkLessonsPictures != null) toolTip1.SetToolTip(chkLessonsPictures, Loc.Get("Main_Tooltip_LessonsPictures"));
                    if (chkGivenFolder != null) toolTip1.SetToolTip(chkGivenFolder, Loc.Get("Main_Tooltip_GivenFolder"));
                    if (chkSoundsInColorTimer != null) toolTip1.SetToolTip(chkSoundsInColorTimer, Loc.Get("Main_Tooltip_SoundsInColorTimer"));
                    if (chkEnableEndLessonWarning != null) toolTip1.SetToolTip(chkEnableEndLessonWarning, Loc.Get("Main_Tooltip_EnableEndLessonWarning"));
                    if (chkPopUpQuestionsEnabled != null) toolTip1.SetToolTip(chkPopUpQuestionsEnabled, Loc.Get("Main_Tooltip_PopUpQuestionsEnabled"));

                    // Tooltips - TextBoxes e altri controlli
                    if (txtMinuteStartLesson != null) toolTip1.SetToolTip(txtMinuteStartLesson, Loc.Get("Main_Tooltip_MinuteStartLesson"));
                    if (txtDurationLesson != null) toolTip1.SetToolTip(txtDurationLesson, Loc.Get("Main_Tooltip_DurationLesson"));
                    if (txtAdvanceMinutes != null) toolTip1.SetToolTip(txtAdvanceMinutes, Loc.Get("Main_Tooltip_AdvanceMinutes"));
                    if (txtRevengeFactor != null) toolTip1.SetToolTip(txtRevengeFactor, Loc.Get("Main_Tooltip_RevengeFactor"));
                    if (txtNStudents != null) toolTip1.SetToolTip(txtNStudents, Loc.Get("Main_Tooltip_NStudents"));
                    if (txtIdClass != null) toolTip1.SetToolTip(txtIdClass, Loc.Get("Main_Tooltip_IdClass"));
                    if (txtPopUpQuestionCentralTime != null) toolTip1.SetToolTip(txtPopUpQuestionCentralTime, Loc.Get("Main_Tooltip_PopUpQuestionCentralTime"));
                    if (txtTimeInterval != null) toolTip1.SetToolTip(txtTimeInterval, Loc.Get("Main_Tooltip_TimeInterval"));
                    if (txtIdStudent != null) toolTip1.SetToolTip(txtIdStudent, Loc.Get("Main_Tooltip_IdStudent"));

                    // Tooltips - Labels
                    if (lblVindicationFactor != null) toolTip1.SetToolTip(lblVindicationFactor, Loc.Get("Main_Tooltip_RevengeFactorLabel"));
                    if (label1 != null) toolTip1.SetToolTip(label1, Loc.Get("Main_Tooltip_MinuteStartLabel"));
                    if (label3 != null) toolTip1.SetToolTip(label3, Loc.Get("Main_Tooltip_MinutesDurationLabel"));
                    if (label4 != null) toolTip1.SetToolTip(label4, Loc.Get("Main_Tooltip_AdvanceMinutesLabel"));
                    if (label6 != null) toolTip1.SetToolTip(label6, Loc.Get("Main_Tooltip_NumberOfStudentsLabel"));
                    if (label7 != null) toolTip1.SetToolTip(label7, Loc.Get("Main_Tooltip_IdClassLabel"));
                    if (label8 != null) toolTip1.SetToolTip(label8, Loc.Get("Main_Tooltip_TimeLabel"));
                    if (label2 != null) toolTip1.SetToolTip(label2, Loc.Get("Main_Tooltip_SaveDbLabel"));
                    if (lblDatabaseFile != null) toolTip1.SetToolTip(lblDatabaseFile, Loc.Get("Main_Tooltip_DatabaseFile"));
                    if (lblLastDatabaseModification != null) toolTip1.SetToolTip(lblLastDatabaseModification, Loc.Get("Main_Tooltip_LastModification"));
                    if (lblIdStudent != null) toolTip1.SetToolTip(lblIdStudent, Loc.Get("Main_Tooltip_IdStudentLabel"));

                    // Tooltips - PictureBox e ListBox
                    if (picBackgroundSaveRunning != null) toolTip1.SetToolTip(picBackgroundSaveRunning, Loc.Get("Main_Tooltip_BackgroundSaveRunning"));
                    if (lstTimeInterval != null) toolTip1.SetToolTip(lstTimeInterval, Loc.Get("Main_Tooltip_TimeIntervalList"));

                    // Tooltips - GroupBoxes
                    if (grpSorts != null) toolTip1.SetToolTip(grpSorts, Loc.Get("Main_Tooltip_SortsGroup"));
                    if (grpImageSource != null) toolTip1.SetToolTip(grpImageSource, Loc.Get("Main_Tooltip_ImageSourceGroup"));
                    if (grpChooseDrawSort != null) toolTip1.SetToolTip(grpChooseDrawSort, Loc.Get("Main_Tooltip_ChooseDrawSort"));
                }
            }
            catch (Exception ex)
            {
                // silent log
                Commons.ErrorLog($"frmMain.LocalizeForm: Error in localization: {ex.Message}");
            }
        }
    }
}
