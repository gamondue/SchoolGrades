using gamon;
using gamon.TreeMptt;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
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

        School school;

        private string schoolYear;

        //bool formInitializing = true;
        //bool firstTime = true;

        Student currentStudent;
        Question currentQuestion;
        GradeType currentGradeType;
        Class currentClass;

        Random random = new Random();

        System.Media.SoundPlayer suonatore = new System.Media.SoundPlayer();
        public Student CurrentStudent
        {
            get => currentStudent;
            set => currentStudent = value;
        }

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

            this.Text += " v. " + version;

            Commons.CreatePaths();

            // manage the configuration file 
            string messagePrompt = "";
#if SQL_SERVER
            // SQL server database filename
#if !DEBUG
            // at the end of the development phase use a debug database
            Commons.PathAndFileDatabase = "SchoolGrades"; 
#else
            Commons.PathAndFileDatabase = "SchoolGrades";
#endif

#else
            // SQLite database filename reading 
            // read configuration file, if doesn't work run configuration 
            bool fileRead = CommonsWinForms.ReadConfigData();
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
                        FrmSetup f = new FrmSetup();
                        f.ShowDialog();
                        CloseProgramWhileTestingIfConfigurationFileIsRight();
                    }
                    else
                    {
                        // the configured file exists, if it is a file for a single class,
                        // check if a more recent file exists and ask the user if she wants to
                        // pass to the new file 
                        DateTime fileDateInName = Commons.GetValidDateFromString(configuredFileName.Substring(0, 10));
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
#if !SQL_SERVER
            Commons.bl.GetSchoolYearsThatHaveClasses();
            // da togliere dopo che DataLayer SQL server funziona
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
            FrmSetup f = new FrmSetup();
            f.ShowDialog();
        }
        private void CloseProgramWhileTestingIfConfigurationFileIsRight()
        {
            // read the config file once again 
            bool fileRead = CommonsWinForms.ReadConfigData();
            if (!fileRead || !File.Exists(Commons.PathAndFileDatabase))
            {
                MessageBox.Show("Configurare il programma!", "SchoolGrades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Il programma verrà chiuso. Alla ripartenza funzionerà regolarmente.");
            }
            CloseBackgroundThread();
            StopAllTimers();
            this.Close();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            // start the Thread that concurrently saves the Topics tree
            CommonsWinForms.SaveTreeMptt = new TreeMptt(null, null, null, null, null, null, picBackgroundSaveRunning,
                null, null, null, null, null);
            Commons.BackgroundSaveThread = new Thread(CommonsWinForms.SaveTreeMptt.SaveTreeMpttBackground);
            Commons.BackgroundSaveThread.Start();

            if (!File.Exists(Commons.PathAndFileDatabase))
                return;

            timerQuestion.Interval = 250;

            lblDatabaseFile.Visible = true;

            lblLastDatabaseModification.Visible = true;
            lblLastDatabaseModification.Text = File.GetLastWriteTime(Commons.PathAndFileDatabase).ToString("yyyy-MM-dd HH:mm:ss");
#if !DEBUG
            // capture every exception for exception logging
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            btnTemporary.Visible = false;
#endif

            CreateBusinessLayer(); 
            // da togliere dopo che DataLayer SQL server funziona
#if !SQL_SERVER
            school = Commons.bl.GetSchool(Commons.IdSchool);
            if (school == null)
                return;

            if (cmbSchoolYear.SelectedItem != null)
                schoolYear = cmbSchoolYear.SelectedItem.ToString();

            lstClasses.DataSource = Commons.bl.GetClassesOfYear(school.IdSchool, schoolYear);

            if (lstClasses.DataSource == null)
                return;
#endif
            CommonsWinForms.globalPicLed = picBackgroundSaveRunning;

            if (chkActivateLessonClock.Checked)
            {
                CalculateTimesForEndLessonWarning();
                timerLesson.Start();
            }

            string file = Path.Combine(Commons.PathLogs, "frmMain_parameters.txt");
            CommonsWinForms.RestoreCurrentValuesOfAllControls(this, file);

            txtNStudents.Text = "";

            picStudent.BringToFront();
            lblStudentChosen.BringToFront();
            lblIdStudent.BringToFront();
            txtIdStudent.BringToFront();
            lblStudentChosen.Visible = false;
            lblIdStudent.Visible = false;
            txtIdStudent.Visible = false;

            lblDatabaseFile.Text = Path.GetFileName(Commons.PathAndFileDatabase);
            //formInitializing = false;
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
            newDatabaseFileName = GetNewestAmongFilesWithDateInName(proposedDatabasePath);
            //newDatabaseFileName = Commons.bl.GetNewestAmongFilesWithDateInName(proposedDatabasePath);
            newDatabaseFileName = Commons.GetNewestAmongFilesWithDateInName(proposedDatabasePath);
            if (newDatabaseFileName != "")
                return newDatabaseFileName;
            else
                return "";
        }
        private string GetNewestAmongFilesWithDateInName(string DatabasePath)
        {
            if (!Directory.Exists(DatabasePath))
            {
                return null;
            }
            string[] files = Directory.GetFiles(DatabasePath);
            DateTime newestFileDate = DateTime.MinValue;
            string newestFileNameAndPath = "";
            foreach (string file in files)
            {
                DateTime thisFileDate = Commons.GetValidDateFromString(Path.GetFileName(file).Substring(0, 10));
                if (thisFileDate > newestFileDate)
                {
                    newestFileDate = thisFileDate;
                    newestFileNameAndPath = file;
                }
            }
            return newestFileNameAndPath;
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
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
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
            // read checksigns from the grid
            ReadCheckSignsIntoCurrentStudentsList();
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
            {
                return;
            }
            else
            {
                DrawOrSort();
                //ListaVisibile = false;
                dgwStudents.Visible = false;
                chkStudentsListVisible.Checked = false;
            }
        }
        private List<Student> CreateRevengeList(List<Student> StudentList)
        {
            List<Student> listVf = new List<Student>();
            int? maxVf = 0;
            // take only the eligible students with V.F. > 0 
            foreach (Student s in StudentList)
            {
                if (s.RevengeFactorCounter > 0 && (bool)s.Eligible)
                {
                    listVf.Add(s);
                    // set parameter for sort or draw
                    s.SortOrDrawCriterion = s.RevengeFactorCounter;
                    if (s.RevengeFactorCounter > maxVf)
                        maxVf = s.RevengeFactorCounter;
                }
            }
            return listVf;
        }
        private void btnAssess_Click(object sender, EventArgs e)
        {
            if (currentClass is null)
            {
                MessageBox.Show("Selezionare una classe");
                return;
            }
            if (cmbGradeType.Text == "")
            {
                MessageBox.Show("Selezionare un tipo di valutazione");
                return;
            }
            if (currentClass.CurrentStudent is null)
            {
                MessageBox.Show("Selezionare un allievo da valutare");
                return;
            }
            if (currentSubject == null)
            {
                MessageBox.Show("Selezionare una materia");
                return;
            }
            currentGradeType = ((GradeType)cmbGradeType.SelectedItem);
            if (currentGradeType.IdGradeTypeParent == "")
            {
                MessageBox.Show("Con il tipo di valutazione scelto non si può fare la media.\r\n " +
                    "Selezionare un tipo di valutazione corretto");
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
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (dgwStudents.Visible)
                AllChecked();
        }
        private void btnCheckToggle_Click(object sender, EventArgs e)
        {
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (dgwStudents.Visible)
                AllToggle();
        }
        private void btnCheckNone_Click(object sender, EventArgs e)
        {
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (dgwStudents.Visible)
                AllUnChecked();
        }
        private void btnCheckRevenge_Click(object sender, EventArgs e)
        {
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
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
                string pictureFile = Commons.bl.GetFilePhoto(Chosen.IdStudent, schoolYear);
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
        private void lstClassi_SelectedIndexChanged(object sender, EventArgs e)
        {
            picStudent.Image = null;
            lblStudentChosen.Text = "";
            chkStudentsListVisible.Checked = true;
            dgwStudents.DataSource = null;
        }
        private void lstClassi_DoubleClick(object sender, EventArgs e)
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
                // show popup annotations of the students of the class
                DataTable popUpAnnotations = Commons.bl.GetAnnotationsOfClass(currentClass.IdClass, true, true);
                if (popUpAnnotations.Rows.Count > 0)
                {
                    frmAnnotationsPopUp f = new frmAnnotationsPopUp(popUpAnnotations);
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.Show();
                }
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
            frmMain_Load(null, null);
            //if (!formInitializing && firstTime)
            //{
            //    firstTime = false;
            //    //    AllTheInitializations();
            //    List<SchoolYear> ly = Commons.bl.GetSchoolYearsThatHaveClasses();
            //    cmbSchoolYear.DataSource = ly;

            //    if (ly.Count > 0)
            //        cmbSchoolYear.SelectedItem = ly[ly.Count - 1];

            //    // fill the combo of grade types 
            //    List<GradeType> ListGradeTypes = Commons.bl.GetListGradeTypes();
            //    cmbGradeType.DataSource = ListGradeTypes;

            //    // fill the combo of School subjects
            //    List<SchoolSubject> listSubjects = Commons.bl.GetListSchoolSubjects(true);
            //    cmbSchoolSubject.DataSource = listSubjects;
            //}
            //firstTime = true;
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
                    if (!CommonsWinForms.CheckIfClassChosen(currentClass))
                        return;
                    if (!CommonsWinForms.CheckIfSubjectChosen(currentSubject))
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
                currentStudentsList = Commons.bl.GetStudentsOfClassList(school.OfficialSchoolAbbreviation, schoolYear,
                    lstClasses.SelectedItem.ToString(), false);
                eligiblesList.Clear();

                if (currentStudentsList == null)
                    return;

                RefreshStudentsGrid();
            }
        }
        public void DrawOrSort()
        {
            eligiblesList.Clear();

            // first pass: prepare the sort or draw criterion and pick those present
            // sets the value of property SortOrDrawCriterion according to the type of draw
            if (rdbDrawEqualProbability.Checked)
            {
                eligiblesList = Commons.bl.PrepareEligiblesByEqualProbability(currentStudentsList);
            }
            else if (rdbDrawByWeightsSum.Checked)
            {
                if (!CommonsWinForms.CheckIfSubjectChosen(currentSubject))
                    return;
                if (!CommonsWinForms.CheckIfTypeOfAssessmentChosen(currentGradeType))
                    return;
                eligiblesList = PrepareEligiblesByWeightSum();
            }
            else if (rdbDrawNoOfGrades.Checked)
            {
                if (!CommonsWinForms.CheckIfSubjectChosen(currentSubject))
                    return;
                if (!CommonsWinForms.CheckIfTypeOfAssessmentChosen(currentGradeType))
                    return;
                eligiblesList = PrepareEligiblesByNumberOfGrades();
            }
            else if (rdbDrawByOldestFirst.Checked)
            {
                eligiblesList = PrepareEligiblesByOldestFirst();
            }
            else if (rdbSortByAlphbetical.Checked)
            {
                // same as equal probability
                // but draw will be forbidden later
                eligiblesList = Commons.bl.PrepareEligiblesByEqualProbability(currentStudentsList);
            }
            else if (rdbDrawLowGradesFirst.Checked)
            {
                eligiblesList = PrepareEligiblesByLowGradesFirst();
            }
            else if (rdbDrawByRevengeFactor.Checked)
            {
                eligiblesList = PrepareEligiblesByRevengeFactor();
            }
            if (eligiblesList.Count == 0)
            {
                MessageBox.Show("Nessun allievo presente?");
                return;
            }
            dgwStudents.Visible = false;

            // second pass: shuffle the list or sort 
            // for both operations it uses the SortOrDrawCriterion Property
            if (rdbMustDraw.Checked && !rdbSortByAlphbetical.Checked)
            {
                Commons.ListShuffleWithDifferentProbabilities(eligiblesList);
            }
            else
            {  // sort the list by the criterion
                Commons.SortListBySortOrDrawCriterionDescending(eligiblesList);
            }
            indexCurrentDrawn = 0;
            MessageBox.Show("Sorteggio od ordinamento fatto!", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private List<Student> PrepareEligiblesByRevengeFactor()
        {
            return CreateRevengeList(currentStudentsList);
        }
        private List<Student> PrepareEligiblesByLowGradesFirst()
        {
            throw new NotImplementedException();
        }
        private List<Student> PrepareEligiblesByOldestFirst()
        {
            throw new NotImplementedException();
        }
        private List<Student> PrepareEligiblesByNumberOfGrades()
        {
            List<Student> eligiblesList = new List<Student>();
            //find the number of grades of each student (beside the sum of the weights)
            List<Student> studentsAndWeights =
                Commons.bl.GetStudentsAndSumOfWeights(currentClass,
                currentGradeType, currentSubject,
                DateTime.MinValue, DateTime.MaxValue); // TODO: put the dates of the current school period

            double? maxOfCounts = 0;
            foreach (Student s in studentsAndWeights)
            {
                // in DummyNumber the database passes the number of questions answered by the student
                if (s.DummyNumber > maxOfCounts)
                    maxOfCounts = s.Sum;
            }
            foreach (Student studentOfAll in currentStudentsList)
            {
                // put in SortOrDrawCriterion a number lower if the student has higher weights
                foreach (Student studentOfGraded in studentsAndWeights)
                {
                    // if we will not find the student, then he will get maximum for the SortOrDrawCriterion
                    studentOfAll.SortOrDrawCriterion = maxOfCounts;// we shouldn't ever pass 10 as a sum of weights 
                    // search for this student in the list of those that have a weight of questions
                    if (studentOfAll.IdStudent == studentOfGraded.IdStudent)
                    {
                        // student found, is he has more than maxiumum weights, take maximum
                        // (in Sum there is the sum of the weights of questions of the student)
                        if (studentOfGraded.DummyNumber > maxOfCounts)
                            studentOfGraded.DummyNumber = maxOfCounts;
                        studentOfAll.SortOrDrawCriterion = maxOfCounts - studentOfGraded.DummyNumber;
                        break;
                    }
                }
                // put this student in the eligibles list if he is present
                if (studentOfAll.Eligible == true)
                    eligiblesList.Add(studentOfAll);
            }
            return eligiblesList;
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
        private List<Student> PrepareEligiblesByWeightSum()
        {
            //find the sum of the weights of grades of each student
            List<Student> studentsAndWeights =
                Commons.bl.GetStudentsAndSumOfWeights(currentClass,
                currentGradeType, currentSubject,
                DateTime.MinValue, DateTime.MaxValue); // TODO: put the dates of the current school period
            // find max of weights
            double? maxOfWeights = 0;
            foreach (Student s in studentsAndWeights)
            {
                if (s.Sum > maxOfWeights)
                    maxOfWeights = s.Sum;
            }
            foreach (Student studentOfAll in currentStudentsList)
            {
                // put in SortOrDrawCriterion a number lower if the student has higher weights
                foreach (Student studentOfGraded in studentsAndWeights)
                {
                    // if we will not find the student, then he will get maximum for the SortOrDrawCriterion
                    studentOfAll.SortOrDrawCriterion = maxOfWeights;// we shouldn't ever pass 10 as a sum of weights 
                    // search for this student in the list of those that have a weight of questions
                    if (studentOfAll.IdStudent == studentOfGraded.IdStudent)
                    {
                        // student found, is he has more than maxiumum weights, take maximum
                        // (in Sum there is the sum of the weights of questions of the student)
                        if (studentOfGraded.Sum > maxOfWeights)
                            studentOfGraded.Sum = maxOfWeights;
                        studentOfAll.SortOrDrawCriterion = maxOfWeights - studentOfGraded.Sum;
                        break;
                    }
                }
                // put this student in the eligibles list if he is present
                if ((bool)studentOfAll.Eligible)
                    eligiblesList.Add(studentOfAll);
            }
            return eligiblesList;
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
                List<Student> oldList = Commons.bl.GetStudentsOfClassList(school.OfficialSchoolAbbreviation, schoolYear,
                        currentClass.Abbreviation, false);
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
                    MessageBox.Show("Lista finita: sorteggiare", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            FrmSetup f = new FrmSetup();
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

            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
                return;
            if (!CommonsWinForms.CheckIfTypeOfAssessmentChosen(currentGradeType))
                return;
            if (!CommonsWinForms.CheckIfStudentChosen(currentStudent))
                return;

            // annotation applied to a single student
            frmGradesStudentsSummary f = new frmGradesStudentsSummary(currentStudent, cmbSchoolYear.Text,
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
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
                return;
            if (!CommonsWinForms.CheckIfSubjectChosen(currentSubject))
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
            Color bgColor = CommonsWinForms.ColorFromNumber(currentSubject);
            this.BackColor = bgColor;
            lstClasses.BackColor = bgColor;
            lstTimeInterval.BackColor = bgColor;
            picStudent.BackColor = bgColor;
            lblCodYear.BackColor = bgColor;
        }
        private void btnTopicsDone_Click(object sender, EventArgs e)
        {
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
                return;
            if (!CommonsWinForms.CheckIfSubjectChosen(currentSubject))
                return;
            frmTopics frm = new frmTopics(frmTopics.TopicsFormType.HighlightTopics,
                currentClass, currentSubject, currentQuestion, null, (frmMain)this);
            frm.Show();
        }
        private void btnStartLinks_Click(object sender, EventArgs e)
        {
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
                return;
            List<StartLink> LinksOfClass = Commons.bl.GetStartLinksOfClass(currentClass);

            Commons.StartLinks(currentClass, LinksOfClass);
        }
        private void btnQuestion_Click(object sender, EventArgs e)
        {
            if (!CommonsWinForms.CheckIfSubjectChosen(currentSubject))
                return;
            frmQuestionChoose scelta = new frmQuestionChoose(currentSubject,
                currentClass, currentStudent, CurrentQuestion);
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
                int.TryParse(txtTimeInterval.Text, out value);
                if (value > 01)
                {
                    ticksPassed = 0;
                    pgbTimeQuestion.Maximum = int.Parse(Time) * 1000;
                    timerQuestion.Start();
                }
            }
        }
        private void btnMakeGroups_Click(object sender, EventArgs e)
        {
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
                return;
            eligiblesList = FillListOfChecked(currentStudentsList);
            if (eligiblesList.Count == 0)
            {
                MessageBox.Show("Nessun studente presente!");
                return;
            }
            if (cmbSchoolSubject.SelectedIndex == 0)
            {
                MessageBox.Show("Nessuna materia selezionata!");
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
            if (MessageBox.Show("Incremento del fattore vendetta per ogni allievo spuntato",
                    "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (NoStudentIsChecked())
            {
                MessageBox.Show("Spuntare i nomi degli studenti cui aumentare il fattore vendetta");
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
            lstClassi_DoubleClick(null, null);
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
            if (MessageBox.Show("Decremento del fattore vendetta per ogni allievo spuntato",
                    "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (currentStudentsList.Count == 0)
            {
                MessageBox.Show("Spuntare i nomi degli studenti cui diminuire il fattore vendetta");
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
            lstClassi_DoubleClick(null, null);
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
            frmStudent fs = new frmStudent(currentStudent, true);
            fs.ShowDialog();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!File.Exists(Commons.PathAndFileDatabase))
                return;

            CloseBackgroundThread();

            string file = Commons.PathLogs + @"\frmMain_parameters.txt";
            CommonsWinForms.SaveCurrentValuesOfAllControls(this, ref file);
            SaveStudentsOfClassIfEligibleHasChanged();

            // save in the log folder a copy of the database, if enabled 
            if (Commons.SaveBackupWhenExiting)
            {
                File.Copy(Commons.PathAndFileDatabase,
                    Path.Combine(Commons.PathLogs, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") +
                    "_" + Commons.DatabaseFileName_Current));
            }
            //// we wait for the saving Thread to finish
            //Commons.BackgroundSaveThread.Join(30000);  // enormous timeout just for big problems
        }
        private void CloseBackgroundThread()
        {
            // if a saving of the database with Mptt is running, we close it 
            if (Commons.BackgroundSavingEnabled)
            {
                lock (Commons.LockBackgroundSavingVariables)
                {
                    Commons.BackgroundSavingEnabled = false;
                    Commons.BackgroundTaskClose = true;
                }
            }
            if (Commons.BackgroundSaveThread != null)
            {
                // we wait for the saving Thread to finish
                // (it aborts in a point in which status is preserved)  
                Commons.BackgroundSaveThread.Join(3000);
            }
        }
        private void StopAllTimers()
        {
            timerLesson.Stop();
            timerPopUp.Stop();
            timerQuestion.Stop();
        }
        private void btnClassesGradesSummary_Click(object sender, EventArgs e)
        {
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (!CommonsWinForms.CheckIfSubjectChosen(currentSubject))
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
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (!CommonsWinForms.CheckIfSubjectChosen(currentSubject))
            {
                return;
            }
            if (dgwStudents.Visible)
                AllCheckNonGraded();
        }
        private void btnYearTopics_Click(object sender, EventArgs e)
        {
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (!CommonsWinForms.CheckIfSubjectChosen(currentSubject))
            {
                return;
            }
            string filenameNoExtension = currentClass.SchoolYear +
                "_" + currentClass.Abbreviation +
                "_" + currentSubject.IdSchoolSubject + "_" +
                "all-topics";
            string createdFile;
            if (MessageBox.Show("Creare un file di testo normale (Sì) od un file per Markdown (No)?",
                "Tipo di file", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                createdFile = Commons.bl.CreateAllTopicsDoneFile(filenameNoExtension, currentClass, currentSubject, true);
                Commons.ProcessStartLink(createdFile);
            }
            else
            {
                createdFile = Commons.bl.CreateAllTopicsDoneFile(filenameNoExtension, currentClass, currentSubject, false);
                Commons.ProcessStartLink(createdFile);
            }
            MessageBox.Show("Creato il file " + createdFile);
        }
        private void chkEnableEndLessonWarning_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableEndLessonWarning.Checked)
            {
                CalculateTimesForEndLessonWarning();
            }
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
                    MessageBox.Show("Mancano meno di " + timeAlarmMinutes + " minuti alla fine della lezione");
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
            double t = double.Parse(txtTimeInterval.Text);
            ColorTimer ft = new ColorTimer(t / 60, t / 60, SoundEffectsInTimer);
            if (currentStudent != null)
            {
                ft.FormCaption = ft.FormCaption.Replace("gamon", currentStudent.LastName);
            }
            ft.Show();
        }
        private void btnStartColorTimer_Click(object sender, EventArgs e)
        {
            StartColorTimer(chkSoundsInColorTimer.Checked);
        }
        private void btnMosaic_Click(object sender, EventArgs e)
        {
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
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
            if (!CommonsWinForms.CheckIfClassChosen(currentClass))
                return;
            if (!CommonsWinForms.CheckIfTypeOfAssessmentChosen(currentGradeType))
                return;
            // annotation can be applied to a single student or to a whole list, based on the 
            // lstNames being visible or not 
            List<Student> chosenStudents;
            if (currentStudent != null && !dgwStudents.Visible)
            {
                // annotation applied to a single student
                chosenStudents = new List<Student>();
                chosenStudents.Add(currentStudent);
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
                if (!CommonsWinForms.CheckIfClassChosen(currentClass))
                {
                    return;
                }
                currentClass.CurrentStudent = currentStudentsList[e.RowIndex];
                currentStudent = currentClass.CurrentStudent;
                currentStudent.SchoolYear = currentClass.SchoolYear;
                loadStudentsData(currentStudent);
                dgwStudents.Visible = false;
            }
        }
        private void dgwStudents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgwStudents.ReadOnly = false;
            if (dgwStudents.Columns.Count == 20)
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
    }
}
