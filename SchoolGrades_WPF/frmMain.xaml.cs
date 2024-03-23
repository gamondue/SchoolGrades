//using gamon.TreeMptt;
using gamon;
using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WinFormsColor = System.Drawing.Color;
using WpfColor = System.Windows.Media.Color;

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

        List<frmLessons> listLessons = new List<frmLessons>();

        School school;

        private string schoolYear;

        private bool wndInitializing = true;
        bool firstTime = true;

        Student currentStudent;
        internal Question currentQuestion;
        GradeType currentGradeType;
        Class currentClass;

        Random random = new Random();

        DispatcherTimer timerQuestion = new DispatcherTimer();
        DispatcherTimer timerLesson = new DispatcherTimer();
        DispatcherTimer timerPopUp = new DispatcherTimer();

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

        WinFormsColor startColor = WinFormsColor.Lime;
        //Brush finalColor = Brushes.Green;
        WinFormsColor finalColor = WinFormsColor.Red;
        public WinFormsColor CurrentLessonTimeColor;

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

            this.Title += " v. " + version;

            Commons.CreatePaths();

            // manage the configuration file 
            string messagePrompt = "";
            // read configuration file, if doesn't work run configuration 
            bool fileRead = CommonsWpf.ReadConfigData();
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
                                if (MessageBox.Show(messagePrompt, "SchoolGrades")
                                    == MessageBoxResult.Yes)
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

            frmMain_Load();
        }
        private void frmMain_Load()
        {
            // start the Thread that concurrently saves the Topics tree

            //////////Commons.BackgroundSaveThread = new Thread(CommonsWpf.SaveTreeMptt.SaveTreeMpttBackground);
            //////////Commons.BackgroundSaveThread.Start();

            //////////TreeMpttNoUi tree = new TreeMpttNoUi();
            //////////tree.SaveTreeMpttBackground();

            if (!File.Exists(Commons.PathAndFileDatabase))
                return;

            //////timerQuestion.Interval = 250;

            lblDatabaseFile.Visibility = Visibility.Visible;

            lblLastDatabaseModification.Visibility = Visibility.Visible;
            lblLastDatabaseModification.Text = File.GetLastWriteTime(Commons.PathAndFileDatabase).ToString("yyyy-MM-dd HH:mm:ss");
#if !DEBUG
            //// capture every exception for exception logging
            //Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            //btnTemporary.Visibility = Visibility.Hidden;
#endif
            school = Commons.bl.GetSchool(Commons.IdSchool);
            if (school == null)
                return;

            if (cmbSchoolYear.SelectedItem != null)
                schoolYear = cmbSchoolYear.SelectedItem.ToString();

            lstClasses.ItemsSource = Commons.bl.GetClassesOfYear(school.IdSchool, schoolYear);

            if (lstClasses.ItemsSource == null)
                return;

            CommonsWpf.globalPicLed = picBackgroundSaveRunning;

            if ((bool)chkActivateLessonClock.IsChecked)
            {
                CalculateTimesForEndLessonWarning();
                //////////timerLesson.Start();
            }

            string file = Path.Combine(Commons.PathLogs, "frmMain_parameters.txt");
            ////////////CommonsWpf.RestoreCurrentValuesOfAllControls(this, file);

            txtNStudents.Text = "";

            // picStudent.BringToFront(); // BringToFront() doesn't exist in WPF 
            Panel.SetZIndex(picStudent, 1000);
            //lblStudentChosen.BringToFront();
            lblStudentChosen.Visibility = Visibility.Hidden;
            Panel.SetZIndex(lblStudentChosen, 1000);
            //lblIdStudent.Visibility = Visibility.Hidden;
            Panel.SetZIndex(lblIdStudent, 1000);
            //txtIdStudent.Visibility = Visibility.Hidden;
            Panel.SetZIndex(txtIdStudent, 1000);

            lblDatabaseFile.Text = Path.GetFileName(Commons.PathAndFileDatabase);
            wndInitializing = false;
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
            MessageBox.Show(messagePrompt, "SchoolGrades");
            frmSetup f = new frmSetup();
            f.ShowDialog();
        }
        private void CloseProgramWhileTestingIfConfigurationFileIsRight()
        {
            // read the config file once again 
            bool fileRead = CommonsWpf.ReadConfigData();
            if (!fileRead || !File.Exists(Commons.PathAndFileDatabase))
            {
                MessageBox.Show("Configurare il programma!", "SchoolGrades");
            }
            else
            {
                MessageBox.Show("Il programma verrà chiuso. Alla ripartenza funzionerà regolarmente.");
            }
            CloseBackgroundThread();
            StopAllTimers();
            this.Close();
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
            //dl = new DataLayer(Commons.PathAndFileDatabase);
            //if (dl == null)
            //    return false;
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
        private void btnComeOn_Click(object sender, RoutedEventArgs e)
        {
            if (currentClass != null)
            {
                picStudent.Source = null;
                beBrave();
            }
            else
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
                return;
            if ((bool)chkSuspence.IsChecked)
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
                chkStudentsListVisible.IsChecked = false;
            }
            else
            {

            }
        }
        private void loadStudentsData(Student Student)
        {
            //if ((bool) chkStudentsListVisible.IsChecked)
            loadStudentsPicture(Student);
            chkStudentsListVisible.IsChecked = false;
            lblStudentChosen.Content = Student.ToString();
            txtRevengeFactor.Text = Student.RevengeFactorCounter.ToString();
            txtIdStudent.Text = Student.IdStudent.ToString();
        }
        private void btnDrawOrSort_Click(object sender, RoutedEventArgs e)
        {
            // read checksigns from the grid
            ReadCheckSignsIntoCurrentStudentsList();
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
            {
                return;
            }
            else
            {
                DrawOrSort();
                //ListaVisibile = false;
                dgwStudents.Visibility = Visibility.Visible;
                chkStudentsListVisible.IsChecked = false;
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
        private void btnAssess_Click(object sender, RoutedEventArgs e)
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
                txtTimeInterval.Text = CurrentQuestion.Duration.ToString();
                // start the timer if the question has a timer
                if (CurrentQuestion.Duration != null && CurrentQuestion.Duration > 0)
                {
                    btnStartColorTimer_Click(null, null);
                }
            }
        }
        private void btnCheckAll_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (dgwStudents.Visibility == Visibility.Visible)
                AllChecked();
        }
        private void btnCheckToggle_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (dgwStudents.Visibility == Visibility.Visible)
                AllToggle();
        }
        private void btnCheckNone_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (dgwStudents.Visibility == Visibility.Visible)
                AllUnChecked();
        }
        private void btnCheckRevenge_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (dgwStudents.Visibility == Visibility.Visible)
                AllCheckRevenge();
        }
        private void loadStudentsPicture(Student Chosen)
        {
            try
            {
                string pictureFile = Path.Combine(Commons.PathImages, Commons.bl.GetFilePhoto(Chosen.IdStudent, schoolYear));
                var uriSource = new Uri(pictureFile, UriKind.Absolute);
                picStudent.Source = new BitmapImage(uriSource);
            }
            catch
            {
                picStudent.Source = null;
                Console.Beep();
            }
        }
        private void timerQuestion_Tick(object sender, RoutedEventArgs e)
        {
            ticksPassed++;
            int msPassati = ticksPassed * timerQuestion.Interval.Milliseconds;
            if (msPassati <= pgbTimeQuestion.Maximum) pgbTimeQuestion.Value = pgbTimeQuestion.Maximum - msPassati;
        }
        private void lstNames_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {

        }
        private void chkNomeIsVisibile_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) { return; }
            if ((bool)chkNameVisible.IsChecked)
                lblStudentChosen.Visibility = Visibility.Visible;
            else
                lblStudentChosen.Visibility = Visibility.Hidden;
        }
        private void lstClassi_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            picStudent.Source = null;
            lblStudentChosen.Content = "";
            chkStudentsListVisible.IsChecked = true;
        }
        private void lstClasses_DoubleClick(object sender, RoutedEventArgs e)
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
                    // put full screen the form 
                    // TODO 
                }
                // show popup annotations of the students of the class
                DataTable popUpAnnotations = Commons.bl.GetAnnotationsOfClass(currentClass.IdClass, true, true);
                if (popUpAnnotations.Rows.Count > 0)
                {
                    frmAnnotationsPopUp f = new frmAnnotationsPopUp(popUpAnnotations);
                    //f.StartPosition = FormStartPosition.CenterParent;
                    f.Show();
                }
            }
        }
        private void chkPhotoVisibile_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
            if ((bool)chkPhotoVisibile.IsChecked)
                picStudent.Visibility = Visibility.Visible;
            else
                picStudent.Visibility = Visibility.Hidden;
        }
        private void chkStudentsListVisible_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (wndInitializing) return;
            if ((bool)chkStudentsListVisible.IsChecked)
            {
                dgwStudents.Visibility = Visibility.Visible;
                lblStudentChosen.Visibility = Visibility.Hidden;
                picStudent.Visibility = Visibility.Hidden;
                lblIdStudent.Visibility = Visibility.Hidden;
                txtIdStudent.Visibility = Visibility.Hidden;
                stckLessonTime.Visibility = Visibility.Visible;
            }
            else
            {
                dgwStudents.Visibility = Visibility.Hidden;
                lblStudentChosen.Visibility = Visibility.Visible;
                picStudent.Visibility = Visibility.Visible;
                lblIdStudent.Visibility = Visibility.Visible;
                txtIdStudent.Visibility = Visibility.Visible;
                stckLessonTime.Visibility = Visibility.Hidden;
            }
        }
        private void cmbSchoolYear_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (!wndInitializing && firstTime)
            {
                firstTime = false;
                //List<SchoolYear> ly = Commons.bl.GetSchoolYearsThatHaveClasses();
                //cmbSchoolYear.ItemsSource = ly;

                //if (ly.Count > 0)
                //    cmbSchoolYear.SelectedItem = ly[ly.Count - 1];

                // fill the combo of grade types 
                List<GradeType> ListGradeTypes = Commons.bl.GetListGradeTypes();
                cmbGradeType.ItemsSource = ListGradeTypes;

                // fill the combo of School subjects
                List<SchoolSubject> listSubjects = Commons.bl.GetListSchoolSubjects(true);
                cmbSchoolSubject.ItemsSource = listSubjects;

                frmMain_Load();
            }
            firstTime = true;
        }
        //private void btnSalvaInterrogati_Click(object sender, RoutedEventArgs e)
        //{
        //    SaveStudentsOfClassIfEligibleHasChanged();
        //}
        private void btnPath_Click(object sender, RoutedEventArgs e)
        {
            //////////folderBrowserDialog.SelectedPath = txtPathImages.Text;
            //////////MessageBoxResult r = folderBrowserDialog.ShowDialog();
            //////////if (r == MessageBoxResult.OK)
            //////////{
            //////////    txtPathImages.Text = folderBrowserDialog.SelectedPath;
            //////////}
        }
        Class lastClass = new Class();
        SchoolSubject lastSubject = new SchoolSubject();
        List<string> filesInFolder = new List<string>();
        int indexImage = 0;
        private DateTime nextPopUpQuestionTime;
        private void btnShowRandomImage_Click(object sender, RoutedEventArgs e)
        {
            if (filesInFolder.Count == 0 || currentClass != lastClass || currentSubject != lastSubject
                || indexImage == filesInFolder.Count)
            {
                indexImage = 0;
                lastClass = currentClass;
                lastSubject = currentSubject;
                filesInFolder.Clear();
                if ((bool)chkGivenFolder.IsChecked)
                {
                    if (txtPathImages.Text != "")
                        Commons.bl.RecusivelyFindImagesUnderPath(txtPathImages.Text, ref filesInFolder);
                }
                if ((bool)chkLessonsPictures.IsChecked)
                {
                    if (!CommonsWpf.CheckIfClassChosen(currentClass))
                        return;
                    if (!CommonsWpf.CheckIfSubjectChosen(currentSubject))
                        return;
                    //List<Image> lessonImages = db.GetAllImagesShownToAClassDuringLessons(currentClass, currentSubject);
                    List<SchoolGrades.BusinessObjects.Image> lessonImages = Commons.bl.GetAllImagesShownToAClassDuringLessons(currentClass, currentSubject,
                        DateTime.Now.AddMonths(-8), DateTime.Now);
                    // add the path & filename of the files found to the list of those that we can draw
                    foreach (SchoolGrades.BusinessObjects.Image i in lessonImages)
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
                dgwStudents.ItemsSource = null;
                currentStudentsList = Commons.bl.GetStudentsOfClassList(school.OfficialSchoolAbbreviation, schoolYear,
                    lstClasses.SelectedItem.ToString(), false);
                dgwStudents.ItemsSource = currentStudentsList;
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
            if ((bool)rdbDrawEqualProbability.IsChecked)
            {
                eligiblesList = Commons.bl.PrepareEligiblesByEqualProbability(currentStudentsList);
            }
            else if ((bool)rdbDrawByWeightsSum.IsChecked)
            {
                if (!CommonsWpf.CheckIfSubjectChosen(currentSubject))
                    return;
                if (!CommonsWpf.CheckIfTypeOfAssessmentChosen(currentGradeType))
                    return;
                eligiblesList = PrepareEligiblesByWeightSum();
            }
            else if ((bool)rdbDrawNoOfGrades.IsChecked)
            {
                if (!CommonsWpf.CheckIfSubjectChosen(currentSubject))
                    return;
                if (!CommonsWpf.CheckIfTypeOfAssessmentChosen(currentGradeType))
                    return;
                eligiblesList = PrepareEligiblesByNumberOfGrades();
            }
            else if ((bool)rdbDrawByOldestFirst.IsChecked)
            {
                eligiblesList = PrepareEligiblesByOldestFirst();
            }
            else if ((bool)rdbSortByAlphbetical.IsChecked)
            {
                // same as equal probability
                // but draw will be forbidden later
                eligiblesList = Commons.bl.PrepareEligiblesByEqualProbability(currentStudentsList);
            }
            else if ((bool)rdbDrawLowGradesFirst.IsChecked)
            {
                eligiblesList = PrepareEligiblesByLowGradesFirst();
            }
            else if ((bool)rdbDrawByRevengeFactor.IsChecked)
            {
                eligiblesList = PrepareEligiblesByRevengeFactor();
            }
            if (eligiblesList.Count == 0)
            {
                MessageBox.Show("Nessun allievo presente?");
                return;
            }
            dgwStudents.Visibility = Visibility.Hidden;

            // second pass: shuffle the list or sort 
            // for both operations it uses the SortOrDrawCriterion Property
            if ((bool)rdbMustDraw.IsChecked && !(bool)rdbSortByAlphbetical.IsChecked)
            {
                Commons.ListShuffleWithDifferentProbabilities(eligiblesList);
            }
            else
            {  // sort the list by the criterion
                Commons.SortListBySortOrDrawCriterionDescending(eligiblesList);
            }
            indexCurrentDrawn = 0;
            MessageBox.Show("Sorteggio od ordinamento fatto!", "");
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
                lstTimeInterval.SelectedValue = currentQuestion.Duration.ToString();
                if (currentQuestion.Duration != null && currentQuestion.Duration != 0)
                    txtTimeInterval.Text = CurrentQuestion.Duration.ToString();
            }
        }
        private void showCurrentStudent(Student Student)
        {
            currentClass.CurrentStudent = Student;

            lblStudentChosen.Content = Student.ToString();
            if (lblStudentChosen.Foreground == Brushes.Green)
                lblStudentChosen.Foreground = Brushes.Red;
            else
                lblStudentChosen.Foreground = Brushes.Green;
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
                    MessageBox.Show("Lista finita: sorteggiare", "");
                }
            else
                MessageBox.Show("Nessun sorteggio o nessuno presente! ", "");
        }
        public void ChosenStudent(Student descStudentChosen)
        {
            showCurrentStudent(descStudentChosen);
        }
        private void btnSetup_Click(object sender, RoutedEventArgs e)
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
                frmMain_Load();
                lblDatabaseFile.Text = Commons.DatabaseFileName_Current;
                currentStudentsList = null;
                eligiblesList.Clear();
            }
        }
        private void btnStudentsGradesSummary_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Parte da finire");
            //return; 

            if (!CommonsWpf.CheckIfClassChosen(currentClass))
                return;
            if (!CommonsWpf.CheckIfTypeOfAssessmentChosen(currentGradeType))
                return;
            if (!CommonsWpf.CheckIfStudentChosen(currentStudent))
                return;

            // annotation applied to a single student
            frmGradesStudentsSummary f = new frmGradesStudentsSummary(currentStudent, cmbSchoolYear.Text,
                currentGradeType, (SchoolSubject)cmbSchoolSubject.SelectedItem);
            f.Show();
        }
        private void btnOldestGrade_Click(object sender, RoutedEventArgs e)
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
        private void cmbGradeType_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            currentGradeType = (GradeType)cmbGradeType.SelectedItem;
        }
        private void btnLessonsTopics_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
                return;
            if (!CommonsWpf.CheckIfSubjectChosen(currentSubject))
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
                        //fl.Dispose();
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
        private void cmbSchoolSubject_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            currentSubject = (SchoolSubject)cmbSchoolSubject.SelectedItem;
            if (currentSubject.Name == null)
                currentSubject = null;
            WpfColor BackColor = CommonsWpf.ColorFromNumber(currentSubject.Color);
            SolidColorBrush br = new SolidColorBrush(WpfColor.FromArgb(BackColor.A, BackColor.R, BackColor.G, BackColor.B));
            this.Background = br;
            //  lstClasses.Background = br;
            //lstTimeInterval.Background = br;
            lblCodYear.Background = br;
            grpImageSource.Background = br;
            grpChooseDrawSort.Background = br;
            grpSorts.Background = br;
        }
        private void btnTopicsDone_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
                return;
            if (!CommonsWpf.CheckIfSubjectChosen(currentSubject))
                return;
            frmTopics frm = new frmTopics(frmTopics.TopicsFormType.HighlightTopics,
                currentClass, currentSubject, currentQuestion, null, (frmMain)this);
            frm.Show();
        }
        private void btnStartLinks_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
                return;
            List<StartLink> LinksOfClass = Commons.bl.GetStartLinksOfClass(currentClass);

            Commons.StartLinks(currentClass, LinksOfClass);
        }
        private void btnQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfSubjectChosen(currentSubject))
                return;
            frmQuestionChoose scelta = new frmQuestionChoose(currentSubject,
                currentClass, currentStudent, CurrentQuestion);
            scelta.ShowDialog();
            if (scelta.ChosenQuestion != null && scelta.ChosenQuestion.IdQuestion != 0)
            {
                CurrentQuestion = scelta.ChosenQuestion;
            }
            ////////////scelta.Dispose();
        }
        private void pgbTimeQuestion_Click(object sender, RoutedEventArgs e)
        {
            ToggleTimerBar(txtTimeInterval.Text);
        }
        private void ToggleTimerBar(string Time)
        {
            if (timerQuestion.IsEnabled && pgbTimeQuestion.Value > 0)
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
        private void btnMakeGroups_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
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
        private void txtPathImages_TextChanged(object sender, RoutedEventArgs e)
        {

        }
        private void txtPathImages_DoubleClick(object sender, RoutedEventArgs e)
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
        private void txtPathImages_Click(object sender, RoutedEventArgs e)
        {
            //////////FileDialog fd = new FileDialog(); 
            //////////fd.InitialDirectory = txtPathImages.Text;
            //////////fd.Title = "File da visualizzare";
            //////////fd.Filter = "Tutti i file|*.*";
            //////////fd.FileName = "";
            //////////DialogResult r = fd.ShowDialog();
            //////////if (r == MessageBoxResult.OK)
            //////////    try
            //////////    {
            //////////        picStudent.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
            //////////        txtPathImages.Text = Path.GetDirectoryName(openFileDialog.FileName);
            //////////    }
            //////////    catch
            //////////    {
            //////////        picStudent.Source = null;
            //////////    }
            //////////lblStudentChosen.Text = Path.GetFileName(openFileDialog.FileName);
        }
        private void txtQuestion_TextChanged(object sender, RoutedEventArgs e)
        {

        }
        private void txtQuestion_DoubleClick(object sender, RoutedEventArgs e)
        {
            // !!!! I still don't have the frmQuestion UI xaml file !!!!
            ////////////frmQuestion f = new frmQuestion(frmQuestion.QuestionFormType.EditOneQuestion,
            ////////////    CurrentQuestion, currentSubject, currentClass, null);
            ////////////f.Show();
        }
        private void btnRevengeFactorPlus_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Incremento del fattore vendetta per ogni allievo spuntato",
                    "") == MessageBoxResult.No)
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
        private void btnRevengeFactorMinus_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Decremento del fattore vendetta per ogni allievo spuntato",
                    "") == MessageBoxResult.No)
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
            lstClasses_DoubleClick(null, null);
        }
        private void rdbDrawByRevengeFactor_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if ((bool)rdbDrawByRevengeFactor.IsChecked)
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
        private void picStudent_DoubleClick(object sender, RoutedEventArgs e)
        {
            frmStudent fs = new frmStudent(currentStudent, true);
            fs.ShowDialog();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!File.Exists(Commons.PathAndFileDatabase))
                return;

            CloseBackgroundThread();

            string file = Commons.PathLogs + @"\frmMain_parameters.txt";
            CommonsWpf.SaveCurrentValuesOfAllControls(this, ref file);
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
        private void btnClassesGradesSummary_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (!CommonsWpf.CheckIfSubjectChosen(currentSubject))
            {
                return;
            }
            frmGradesClassSummary f;
            f = new frmGradesClassSummary(currentClass,
                currentGradeType, currentSubject);
            f.Show();
        }
        private void btnCheckNoGrade_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (!CommonsWpf.CheckIfSubjectChosen(currentSubject))
            {
                return;
            }
            if (!CommonsWpf.CheckIfTypeOfAssessmentChosen(currentGradeType))
            {
                return;
            }
            if (dgwStudents.Visibility == Visibility.Visible)
                AllCheckNonGraded();
        }
        private void btnYearTopics_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (!CommonsWpf.CheckIfSubjectChosen(currentSubject))
            {
                return;
            }
            string filenameNoExtension = currentClass.SchoolYear +
                "_" + currentClass.Abbreviation +
                "_" + currentSubject.IdSchoolSubject + "_" +
                "all-topics";
            string createdFile;
            if (MessageBox.Show("Creare un file di testo normale (Sì) od un file per Markdown (No)?",
                "Tipo di file") == MessageBoxResult.Yes)
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
        private void chkEnableEndLessonWarning_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if ((bool)chkEnableEndLessonWarning.IsChecked)
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
        private void timerLesson_Tick(object sender, RoutedEventArgs e)
        {
            timeLeftMinutes = ticksToMinutesFactor * (thisLessonEndTime.Ticks - DateTime.Now.Ticks);

            if ((bool)chkEnableEndLessonWarning.IsChecked)
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
                WpfColor BackColor = CommonsWpf.ColorFromNumber(currentSubject.Color);
                SolidColorBrush br = new SolidColorBrush(WpfColor.FromArgb(BackColor.A, BackColor.R, BackColor.G, BackColor.B));

                // changes color from startColor to finalColor
                colHSL.Hue = (int)(startColor.GetHue() + spanHue * (timeLessonMinutes - timeLeftMinutes) / (timeLessonMinutes));
                colHSL.Saturation = startColor.GetSaturation() + spanSaturation * (timeLessonMinutes - timeLeftMinutes) / (timeLessonMinutes);
                colHSL.Luminance = startColor.GetBrightness() + spanLuminance * (timeLessonMinutes - timeLeftMinutes) / timeLessonMinutes;
                ColorHelper.ColorConverter.HSL2RGB(colHSL, colRGB);
                CurrentLessonTimeColor = colRGB.Color;

                btnLessonTime.Background = CommonsWpf.WinFormsToWpfBrush(CurrentLessonTimeColor);
            }
            else
            {
                timerLesson.Stop();
                CurrentLessonTimeColor = WinFormsColor.Transparent;
                btnLessonTime.Background = CommonsWpf.WinFormsToWpfBrush(CurrentLessonTimeColor);
            }
        }
        private void chkActivateLessonClock_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if ((bool)chkActivateLessonClock.IsChecked)
                timerLesson.IsEnabled = true;
            else
            {
                timerLesson.IsEnabled = false;
                CurrentLessonTimeColor = WinFormsColor.Transparent;
                btnLessonTime.Background = CommonsWpf.WinFormsToWpfBrush(CurrentLessonTimeColor);
            }
            Commons.IsTimerLessonActive = (bool)chkActivateLessonClock.IsChecked;
        }
        private void btnTemporary_Click(object sender, RoutedEventArgs e)
        {
            frmBackupManagement f = new();
            f.Show();
            //Student dummyStudent = new Student();
            //dummyStudent.IdStudent = 388;
            //dummyStudent.LastName = "Dummy"; 

            //frmStudentsAnnotations f = new frmStudentsAnnotations(dummyStudent, 
            //    null);
            //f.Show();
        }
        private void btnLessonTime_Click(object sender, RoutedEventArgs e)
        {
            txtMinuteStartLesson.Text = DateTime.Now.Minute.ToString();
            CalculateTimesForEndLessonWarning();
        }
        private void LessonAlarmChanged(object sender, RoutedEventArgs e)
        {
            CalculateTimesForEndLessonWarning();
        }
        private void txtDurationLesson_Leave(object sender, RoutedEventArgs e)
        {

        }
        private void lstTimeInterval_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            txtTimeInterval.Text = lb.SelectedItem.ToString();
        }
        private void lstTimeInterval_DoubleClick(object sender, RoutedEventArgs e)
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
        private void btnStartColorTimer_Click(object sender, RoutedEventArgs e)
        {
            StartColorTimer((bool)chkSoundsInColorTimer.IsChecked);
        }
        private void btnMosaic_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
                return;
            frmMosaic f = new frmMosaic(currentClass);
            f.Show();
        }
        private void btnStartBarTimer_Click(object sender, RoutedEventArgs e)
        {
            ToggleTimerBar(txtTimeInterval.Text);
        }
        private void btnStudentsNotes_Click(object sender, RoutedEventArgs e)
        {
            if (!CommonsWpf.CheckIfClassChosen(currentClass))
                return;
            if (!CommonsWpf.CheckIfTypeOfAssessmentChosen(currentGradeType))
                return;
            // annotation can be applied to a single student or to a whole list, based on the 
            // lstNames being visible or not 
            List<Student> chosenStudents;
            if (currentStudent != null && dgwStudents.Visibility == Visibility.Visible)
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
                ////////////f.StartPosition = FormStartPosition.CenterParent;
                f.Show();
            }
        }
        private void chkPopUpQuestionsEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            timerPopUp.Interval = new TimeSpan(0, 0, 1);
            timerPopUp.IsEnabled = (bool)chkPopUpQuestionsEnabled.IsChecked;
            if (timerPopUp.IsEnabled)
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
            //////////timerPopUp.IsEnabled = true;
        }
        private void txtPopUpQuestionCentralTime_TextChanged(object sender, RoutedEventArgs e)
        {
            if (timerPopUp.IsEnabled)
            {
                SetNewPopUpOfStudentToQuestion();
            }
        }
        private void timerPopUp_Tick(object sender, RoutedEventArgs e)
        {
            if (nextPopUpQuestionTime <= DateTime.Now)
            {
                timerPopUp.IsEnabled = false;
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
                        chkPhotoVisibile.IsChecked = true;
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
        private void btnRandomNumber_Click(object sender, RoutedEventArgs e)
        {
            frmRandom f = new frmRandom();
            f.Show();
        }
        private void chkSoundsInColorTimer_CheckedChanged(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Chiudere la finestra timer a colori per cambiare lo stato dei suoni"); 
        }
        ////////////private void dgwStudents_CellContentClick(object sender, RoutedEventArgs e)
        ////////////{
        //////////// DataGrid grid = (DataGrid)sender;
        ////////////int RowIndex = grid.SelectedIndex;
        ////////////    if (RowIndex > -1)
        ////////////    {
        ////////////    {
        ////////////        if (dgwStudents.CurrentCell.ColumnIndex == 0)
        ////////////        {
        ////////////            currentStudentsList[RowIndex].Eligible = !currentStudentsList[RowIndex].Eligible;
        ////////////            if (currentStudentsList == null)
        ////////////                return;

        ////////////            RefreshStudentsGrid();
        ////////////        }
        ////////////    }
        ////////////}
        private void dgwStudents_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
        private void dgwStudents_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                currentClass.CurrentStudent = currentStudentsList[RowIndex];
                currentStudent = currentClass.CurrentStudent;
                currentStudent.SchoolYear = currentClass.SchoolYear;
                loadStudentsData(currentStudent);
                chkStudentsListVisible.IsChecked = false;
                dgwStudents.Visibility = Visibility.Hidden;
                picStudent.Visibility = Visibility.Visible;
            }
        }
        ////////////private void dgwStudents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        ////////////{
        ////////////    dgwStudents.ReadOnly = false;
        ////////////    if (dgwStudents.Columns.Count == 20)
        ////////////    {
        ////////////        DataGridViewCheckBoxColumn chkSelected = new DataGridViewCheckBoxColumn();
        ////////////        {
        ////////////            chkSelected.HeaderText = "Chosen";
        ////////////            chkSelected.Name = "chkSelected";
        ////////////            chkSelected.ReadOnly = false;
        ////////////        }
        ////////////        dgwStudents.Columns.Insert(0, chkSelected);
        ////////////    }
        ////////////}
        private void RefreshStudentsGrid()
        {
            dgwStudents.Items.Refresh();
        }
        private void lstClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            picStudent.Source = null;
            lblStudentChosen.Content = "";
            chkStudentsListVisible.IsChecked = true;
            dgwStudents.ItemsSource = null;
        }
        private void lstClasses_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //SaveStudentsOfClassIfEligibleHasChanged();
            currentClass = (Class)lstClasses.SelectedItem;
            //txtIdClass.Text = currentClass.IdClass.ToString();

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
                    //f.StartPosition = FormStartPosition.CenterParent;
                    f.Show();
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
            ////////////foreach (DataGridRow r in dgwStudents.Items)
            ////////////{
            ////////////    currentStudentsList[i].Eligible = (bool)r.Cells[0].Value;
            ////////////}
        }
    }
}
