using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using gamon;
using System.Diagnostics;
using SchoolGrades.DbClasses;
using gamon.TreeMptt;

namespace SchoolGrades
{
    public partial class frmMain : Form
    {
        Color colorGrade = Color.Red;
        public int indexCurrentDrawn = 0;

        DbAndBusiness db; // must be instantiated after the reading of config file. 
        BusinessLayer.BusinessLayer bl; // must be instantiated after the reading of config file.

        public List<Student> currentStudentsList;
        public List<Student> eligiblesList = new List<Student>();

        List<frmLessons> listLessons = new List<frmLessons>();

        School school;

        private string schoolYear;

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

        int ticksPassed;

        string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        AForge.Imaging.RGB colRGB = new AForge.Imaging.RGB();
        AForge.Imaging.HSL colHSL = new AForge.Imaging.HSL();

        Color startColor = Color.Lime;
        //Color finalColor = Color.Green;
        Color finalColor = Color.Red;
        public Color CurrentLessonTimeColor;

        float spanHue;          // Hue span to cover from start time to end
        float spanSaturation;   // Saturation to cover from start time to end
        float spanLuminance;    // differenza to cover from start time to end

        private DateTime thisLessonStartTime;
        private DateTime thisLessonEndTime;
        private float timeLessonMinutes;
        private float timeLeftMinutes;
        private float timeAlarmMinutes;
        private float ticksToMinutesFactor; // multiplicator from tens of microseconds to minutes
        private int minuteStart;
        private bool alarmNotFired = true;
        private SchoolSubject currentSubject;
        private bool dataModified = false;
        public frmMain()
        {
            InitializeComponent();
            
            this.Text += " v. " + version;

            // first default year in the "years" combo
            int firstYear = 2009;

            for (; firstYear <= DateTime.Now.Year; firstYear++)
            {
                CmbSchoolYear.Items.Add((firstYear - 2000).ToString("00") + ((firstYear + 1) - 2000).ToString("00"));
            }
            int nYears = CmbSchoolYear.Items.Count;
            if (DateTime.Now.Month >= 9)
                CmbSchoolYear.SelectedItem = CmbSchoolYear.Items[nYears - 1];
            else
                CmbSchoolYear.SelectedItem = CmbSchoolYear.Items[nYears - 2];

            // fill the combo of grade types 
            List<GradeType> ListGradeTypes = db.GetListGradeTypes();
            cmbGradeType.DataSource = ListGradeTypes;

            // fill the combo of School subjects
            List<SchoolSubject> listSubjects = db.GetListSchoolSubjects(true);
            cmbSchoolSubject.DataSource = listSubjects;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Commons.PathAndFileDatabase))
                return;

            timerQuestion.Interval = 250;
            
            //#if DEBUG
            lblDatabaseFile.Visible = true;
            lblDatabaseFile.Text = Commons.FileDatabase;
            //#endif
#if !DEBUG
            // capture every exception for exception logging
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            btnTemporary.Visible = false; 
#endif
            db = new DbAndBusiness();
            bl = new BusinessLayer.BusinessLayer();

            school = db.GetSchool(Commons.IdSchool);
            if (school == null)
                return;

            schoolYear = CmbSchoolYear.SelectedItem.ToString();

            lstClasses.DataSource = db.GetClassesOfYear(school.IdSchool, schoolYear);

            if (lstClasses.DataSource == null)
                return;

            Commons.globalPicLed = picBackgroundSaveRunning;

            if (ChkActivateLessonClock.Checked)
            {
                CalculateTimesForEndLessonWarning();
                timerLesson.Start();
            }

            string file = Commons.PathLogs + @"\frmMain_parameters.txt";
            Commons.RestoreCurrentValuesOfAllControls(this, file);

            txtNStudents.Text = "";

            // start Thread that concurrently saves the Topics tree
            Commons.SaveTreeMptt = new TreeMptt(null, null, null, null, null, null, picBackgroundSaveRunning);
            Commons.BackgroundSaveThread= new Thread(Commons.SaveTreeMptt.SaveMpttBackground);
            Commons.BackgroundSaveThread.Start(); 
        }
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Commons.ErrorLog(sender.GetType().Name + " " + e.Exception.Message +
                "\r\n" + e.Exception.StackTrace, true);
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (sender != null)
            {
                Commons.ErrorLog(sender.GetType().Name + " " + (e.ExceptionObject as Exception).Message +
                    (e.ExceptionObject as Exception).StackTrace, true);
            }
            else
            {
                Commons.ErrorLog((e.ExceptionObject as Exception).Message +
                    (e.ExceptionObject as Exception).StackTrace, true);
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
            if (chkStudentsListVisible.Checked)
                loadPicture(Student);
            chkStudentsListVisible.Checked = false;
            lblStudentChosen.Text = Student.ToString();
            txtRevengeFactor.Text = Student.RevengeFactorCounter.ToString();
            txtIdStudent.Text = Student.IdStudent.ToString();
        }
        // Draw
        private void btnDrawOrSort_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            else
            {
                DrawOrSort();
                ListaVisibile = false;
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
            frmMicroAssessment voto = new frmMicroAssessment(this,
                currentClass, currentClass.CurrentStudent,
                currentGradeType, currentSubject, CurrentQuestion);
            //voto.ShowDialog();
            voto.Show();

            if (voto.CurrentQuestion != null)
            {
                CurrentQuestion = voto.CurrentQuestion;
                txtQuestion.Text = CurrentQuestion.Text;
                lstTimeInterval.Text = CurrentQuestion.Duration.ToString();
            }
        }
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (lstNames.Visible)
                AllChecked();
        }
        private void btnCheckToggle_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (lstNames.Visible)
                AllToggle();
        }
        private void btnCheckNone_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (lstNames.Visible)
                AllUnChecked();
        }
        private void btnCheckRevenge_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (lstNames.Visible)
                AllCheckRevenge();
        }
        private void btnResults_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            frmClassifica o = new frmClassifica(currentClass, currentStudentsList);
            o.Show();
        }
        private void loadPicture(Student Chosen)
        {
            try
            {
                string pictureFile = Commons.PathImages + "\\" +
                db.GetFilePhoto(currentStudent.IdStudent, schoolYear);
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
        private void lstNomi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lstNomi_DoubleClick(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
            {
                return;
            }
            if (lstNames.SelectedIndex == -1)
                return;
            currentClass.CurrentStudent = currentStudentsList[lstNames.SelectedIndex];
            currentStudent = currentClass.CurrentStudent;
            currentStudent.SchoolYear = currentClass.SchoolYear;
            loadStudentsData(currentStudent);
            lstNames.Visible = false;
        }
        private void chkNomeVisibile_CheckedChanged(object sender, EventArgs e)
        {
            lblStudentChosen.Visible = chkNomeVisibile.Checked;
        }
        private void lstClassi_SelectedIndexChanged(object sender, EventArgs e)
        {
            picStudent.Image = null;
            lblStudentChosen.Text = "";
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

            //TxtPathImages.Text = currentClass.PathRestrictedApplication + @"\SchoolGrades";
        }
        private void chkFotoVisibile_CheckedChanged(object sender, EventArgs e)
        {
            //fotoVisibile = chkFotoVisibile.Checked;
            picStudent.Visible = chkFotoVisibile.Checked;
        }
        private void chkStudentsListVisible_CheckedChanged(object sender, EventArgs e)
        {
            lstNames.Visible = false;
            ListaVisibile = chkStudentsListVisible.Checked;
        }
        private void cmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmMain_Load(null, null);
        }
        private void btnPresentiRegistro_Click(object sender, EventArgs e)
        {

        }
        private void lstNomi_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        private void btnSalvaInterrogati_Click(object sender, EventArgs e)
        {
            SaveStudentsOfClassIfEligibleHasChanged();
        }
        private void btnPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = TxtPathImages.Text;
            DialogResult r = folderBrowserDialog.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtPathImages.Text = folderBrowserDialog.SelectedPath;
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
                    if (TxtPathImages.Text != "")
                        RecusivelyFindImagesUnderPath(TxtPathImages.Text, ref filesInFolder);
                }
                if (chkLessonsPictures.Checked)
                {
                    if (!Commons.CheckIfClassChosen(currentClass))
                        return;
                    if (!Commons.CheckIfSubjectChosen(currentSubject))
                        return;
                    //List<Image> lessonImages = db.GetAllImagesShownToAClassDuringLessons(currentClass, currentSubject);
                    List<DbClasses.Image> lessonImages = db.GetAllImagesShownToAClassDuringLessons(currentClass, currentSubject,
                        DateTime.Now.AddMonths(-8), DateTime.Now);
                    // add the path & filename of the files foud to the list of those that we can draw
                    foreach (DbClasses.Image i in lessonImages)
                    {
                        filesInFolder.Add(Commons.PathImages + "\\" + i.RelativePathAndFilename);
                    }
                }
                if (filesInFolder.Count > 0)
                    Commons.ShuffleListOfStrings(ref filesInFolder);
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
        private void RecusivelyFindImagesUnderPath(string ParentPath, ref List<string> AllFilesInTree)
        {
            if (Directory.Exists(ParentPath))
            {
                string[] filesInThisFolder = Directory.GetFiles(ParentPath);
                foreach (string file in filesInThisFolder)
                {
                    string ext = Path.GetExtension(file);
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".png" || ext == ".svg")
                        AllFilesInTree.Add(file);
                }
                string[] DaughterFolders = Directory.GetDirectories(ParentPath);
                foreach (string path in DaughterFolders)
                {
                    RecusivelyFindImagesUnderPath(path, ref AllFilesInTree);
                }
            }
        }
        // show the lists in list boxes
        public void ShowStudentsOfClass()
        {
            if (lstClasses.SelectedItem != null)
            {
                currentStudentsList = db.GetStudentsOfClassList(school.OfficialSchoolAbbreviation, schoolYear,
                    lstClasses.SelectedItem.ToString(), false);
                eligiblesList.Clear();

                if (currentStudentsList == null)
                    return;

                lstNames.Items.Clear();

                for (int i = 0; i < currentStudentsList.Count; i++)
                {
                    lstNames.Items.Add(currentStudentsList[i]);
                    SetStudentEligible(i, currentStudentsList[i].Eligible);
                }
                lstNames.Visible = true;
            }
        }
        public void DrawOrSort()
        {
            eligiblesList.Clear();

            // first pass: prepare the sort or draw criterion and pick those present
            // sets the value of property SortOrDrawCriterion according to the type of draw
            if (rdbDrawEqualProbability.Checked)
            {
                PrepareEligiblesByEqualProbability();
            }
            else if (rdbDrawByWeightsSum.Checked)
            {
                if (!Commons.CheckIfSubjectChosen(currentSubject))
                    return;
                if (!Commons.CheckIfTypeOfAssessmentChosen(currentGradeType))
                    return;
                PrepareEligiblesByWeightSum();
            }
            else if (rdbDrawNoOfGrades.Checked)
            {
                if (!Commons.CheckIfSubjectChosen(currentSubject))
                    return;
                if (!Commons.CheckIfTypeOfAssessmentChosen(currentGradeType))
                    return;
                PrepareEligiblesByNumberOfGrades();
            }
            else if (rdbDrawByOldestFirst.Checked)
            {
                PrepareEligiblesByOldestFirst();
            }
            else if (rdbSortByAlphbetical.Checked)
            {
                // same as equal probability
                // but draw will be forbidden later
                PrepareEligiblesByEqualProbability();
            }
            else if (rdbDrawLowGradesFirst.Checked)
            {
                PrepareEligiblesByLowGradesFirst();
            }
            else if (rdbDrawByRevengeFactor.Checked)
            {
                PrepareEligiblesByRevengeFactor();
            }
            if (eligiblesList.Count == 0)
            {
                MessageBox.Show("Nessun allievo presente?");
                return;
            }
            lstNames.Visible = false;

            // second pass: shuffle the list or sort 
            // for both operations it uses the SortOrDrawCriterion Property
            if (rdbMustDraw.Checked && !rdbSortByAlphbetical.Checked)
            {
                Commons.ShuffleListWithDifferentProbabilities(eligiblesList);
            }
            else
            {  // sort the list by the criterion
                Commons.SortListBySortOrDrawCriterionDescending(eligiblesList);
            }
            indexCurrentDrawn = 0;
            MessageBox.Show("Sorteggio od ordinamento fatto!", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void PrepareEligiblesByRevengeFactor()
        {
            eligiblesList = CreateRevengeList(currentStudentsList);
        }
        private void PrepareEligiblesByLowGradesFirst()
        {
            throw new NotImplementedException();
        }
        private void PrepareEligiblesByOldestFirst()
        {
            throw new NotImplementedException();
        }
        private void PrepareEligiblesByNumberOfGrades()
        {
            //find the number of grades of each student (beside the sum of the weights)
            List<Student> studentsAndWeights =
                db.GetStudentsAndSumOfWeights(currentClass,
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
        }
        private void EqualizeTheNumberOfTheGrades()
        {
            // this option equalizes the number of the grades. 
            // a student is put in the list as many times as is necessary for him 
            // to have the same number of grades of the others
            // if you give grades to every element of the list, the students will 
            // have the same number of grades
            // find the number of microgrades for each student
            List<Grade> gradesCounts = db.CountNonClosedMicroGrades(currentClass,
                currentGradeType);
            if (lstNames.CheckedItems.Count != 0)
            {
                int nMaxTimes = 0;
                // find the max number of microgrades that haven't been closed
                foreach (Student stud in lstNames.CheckedItems)
                {
                    // find max of microgrades 
                    foreach (Grade g in gradesCounts)
                    {
                        if (g.IdStudent == stud.IdStudent)
                        {
                            stud.DummyNumber = g.DummyInt;
                            if (stud.DummyNumber > nMaxTimes)
                            {
                                nMaxTimes = (int)stud.DummyNumber;
                            }
                        }
                    }
                }
                foreach (Student st in lstNames.CheckedItems)
                {
                    // put the student in the list as many time as enough
                    // to have a number of grades equal to the maximum just found
                    for (int j = 0; j < 1 + nMaxTimes - st.DummyNumber; j++)
                    {
                        eligiblesList.Add(st);
                    }
                }
            }
        }
        private void PrepareEligiblesByWeightSum()
        {
            //find the sum of the weights of grades of each student
            List<Student> studentsAndWeights =
                db.GetStudentsAndSumOfWeights(currentClass,
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
        }
        private void PrepareEligiblesByEqualProbability()
        {
            foreach (Student s in currentStudentsList)
            {
                if ((bool)s.Eligible)
                {
                    s.SortOrDrawCriterion = 1; // equal probability to all
                    eligiblesList.Add(s);
                }
            }
        }
        private List<Student> FillListOfChecked()
        {
            List<Student> CheckedList = new List<Student>();
            // fill the list with those included in the CheckedItems collection
            foreach (Student s in lstNames.CheckedItems)
            {
                CheckedList.Add(s);
            }
            return CheckedList; 
        }
        public void SaveStudentsOfClassIfEligibleHasChanged()
        {
            // check if the Eligible field has changhed since when we read the students 
            dataModified = dataModified || CheckIfAnyEligibleHasChanged(); 
            if (currentStudentsList != null && dataModified)
                db.SaveStudentsOfList(currentStudentsList, null);
        }
        private bool CheckIfAnyEligibleHasChanged()
        {
            bool OneIsDifferent = false; 
            if (currentClass != null)
            {
                List<Student> oldList = db.GetStudentsOfClassList(school.OfficialSchoolAbbreviation, schoolYear,
                        currentClass.Abbreviation, false);
                if(currentStudentsList != null)
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
            for (int i = 0; i < lstNames.Items.Count; i++)
            {
                SetStudentEligible(i, true);
            }
        }
        public void AllUnChecked()
        {
            for (int i = 0; i < lstNames.Items.Count; i++)
            {
                SetStudentEligible(i, false);
            }
        }
        public void AllToggle()
        {
            for (int i = 0; i < lstNames.Items.Count; i++)
            {
                Student s = (Student)lstNames.Items[i];
                bool found = false;
                foreach (object o in lstNames.CheckedItems)
                {
                    Student s1 = (Student)o;
                    if (s == s1)
                    {
                        SetStudentEligible(i, false);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    SetStudentEligible(i, true);
                }
            }
        }
        private void AllCheckRevenge()
        {
            // TODO !!!! check all the students that have a RfCounter > minimum !!!! 
            for (int i = 0; i < lstNames.Items.Count; i++)
            {
                Student s = (Student)lstNames.Items[i];
                SetStudentEligible(i, (s.RevengeFactorCounter > 0));
            }
        }
        private void AllCheckNonGraded()
        {
            List<int> nonGraded = db.GetIdStudentsNonGraded(currentClass, currentGradeType,
                currentSubject);
            for (int i = 0; i < lstNames.Items.Count; i++)
            {
                Student s = (Student)lstNames.Items[i];
                SetStudentEligible(i, false);
                foreach (int k in nonGraded)
                {
                    if (k == s.IdStudent)
                    {
                        SetStudentEligible(i, true);
                        break;
                    }
                }
            }
        }
        private void SetStudentEligible(int Index, bool? Drawable)
        {
            lstNames.SetItemChecked(Index, (bool)Drawable);
            currentStudentsList[Index].Eligible = Drawable;
        }
        private bool GetStudentDrawable(int Index)
        {
            // takes from the UI and syncs with the students list
            bool d = lstNames.GetItemChecked(Index);
            currentStudentsList[Index].Eligible = d;
            return d;
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
        public bool ListaVisibile
        {
            get
            {
                return lstNames.Visible;
            }
            set
            {
                lstNames.Visible = value;
            }
        }
        internal Question CurrentQuestion
        {
            get => currentQuestion;
            set
            {
                currentQuestion = value;
                txtQuestion.Text = currentQuestion.Text;
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
        private int indexInList(string firstLastName)
        {
            int indexInList = 0;
            for (indexInList = 0; indexInList < currentStudentsList.Count; indexInList++)
            {
                string firstLast = currentStudentsList[indexInList].ToString();
                if (firstLast == firstLastName)
                {
                    break;
                }
            }
            return indexInList;
        }
        private void BtnSetup_Click(object sender, EventArgs e)
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
                lblDatabaseFile.Text = Commons.FileDatabase;
                lstNames.Items.Clear();
                currentStudentsList = null;
                eligiblesList.Clear();
            }
        }
        private void btnStudentsGradesSummary_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Parte da finire");
            return; 

            if (!Commons.CheckIfClassChosen(currentClass))
                return;
            if (!Commons.CheckIfTypeOfAssessmentChosen(currentGradeType))
                return;
            if (!Commons.CheckIfStudentChosen(currentStudent))
                return;

            // annotation applied to a single student
            frmGradesStudentsSummary f = new frmGradesStudentsSummary(currentStudent, CmbSchoolYear.Text,
                currentGradeType, (SchoolSubject)cmbSchoolSubject.SelectedItem);
            f.Show();
        }
        private void btnOldestGrade_Click(object sender, EventArgs e)
        {
            // gets all the list, but we are interested only to the first, the oldest
            List<Couple> fromOldest = db.GetGradesOldestInClass(currentClass,
                ((GradeType)(cmbGradeType.SelectedItem)), currentSubject);
            //if (dalPiuVecchio.Count < StudentsList.Count)
            //{
            //    MessageBox.Show("ATTENZIONE: almeno un allievo non ha neppure un voticino!");
            //}
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
                return;
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
            lstNames.BackColor = bgColor;
            lstTimeInterval.BackColor = bgColor;
            picStudent.BackColor = bgColor;
            lblCodYear.BackColor = bgColor;
        }
        private void lstNames_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue != CheckState.Checked) // seem to work "reversed"..
                currentStudentsList[e.Index].Eligible = true;
            else
                currentStudentsList[e.Index].Eligible = false;
        }
        private void btnTopicsDone_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
                return;
            if (!Commons.CheckIfSubjectChosen(currentSubject))
                return;
            frmTopicChooseByPeriod frm = new frmTopicChooseByPeriod(
                frmTopicChooseByPeriod.TopicChooseFormType.OpenTopicOnExit,
                currentClass, currentSubject);
            frm.Show();
        }
        private void btnStartLinks_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
                return;
            List<string> LinksOfClass = db.GetStartLinksOfClass(currentClass);

            Commons.StartLinks(currentClass, LinksOfClass);
        }
        private void btnQuestion_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfSubjectChosen(currentSubject))
                return;
            frmQuestionChoose scelta = new frmQuestionChoose(null, currentSubject,
                currentClass, currentStudent, CurrentQuestion);
            scelta.ShowDialog();
            if (scelta.ChosenQuestion != null && scelta.ChosenQuestion.IdQuestion != 0)
            {
                CurrentQuestion = scelta.ChosenQuestion;
                txtQuestion.Text = CurrentQuestion.Text;
                lstTimeInterval.Text = CurrentQuestion.Duration.ToString();
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
            if (!Commons.CheckIfClassChosen(currentClass))
                return;
            eligiblesList = FillListOfChecked(); 
            if (eligiblesList.Count == 0)
            {
                MessageBox.Show("Nessun studente presente!");
                return;
            }
            // clone the list of students present to the lesson 
            // by using the constructor with parameters, that CLONES! 
            List<Student> groupsList = new List<Student>(eligiblesList);
            frmGroups f = new frmGroups(groupsList, currentClass);
            f.Show();
        }
        private void txtPathImages_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtPathImages_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Commons.ProcessStartLink(TxtPathImages.Text);
            }
            catch (Exception er)
            {
                //MessageBox.Show("Errore nell'aprire la cartella " + txtEdit.Text);
                ////+ "\nErrore: " + er.ToString());
            }
        }
        private void txtPathImages_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = TxtPathImages.Text;
            openFileDialog.Title = "File da visualizzare";
            openFileDialog.Filter = "Tutti i file|*.*";
            openFileDialog.FileName = "";
            DialogResult r = openFileDialog.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
                try
                {
                    picStudent.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                    TxtPathImages.Text = Path.GetDirectoryName(openFileDialog.FileName);
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

            if (lstNames.CheckedItems.Count == 0)
            {
                MessageBox.Show("Spuntare i nomi degli studenti cui aumentare il fattore vendetta");
                return;
            }
            foreach (object o in lstNames.CheckedItems)
            {
                Student s = (Student)o;
                s.RevengeFactorCounter++;
                db.SaveStudent(s, null);
            }
            lstClassi_DoubleClick(null, null);
        }
        private void btnRevengeFactorMinus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Decremento del fattore vendetta per ogni allievo spuntato",
                    "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (lstNames.CheckedItems.Count == 0)
            {
                MessageBox.Show("Spuntare i nomi degli studenti cui diminuire il fattore vendetta");
                return;
            }
            foreach (object o in lstNames.CheckedItems)
            {
                Student s = (Student)o;
                s.RevengeFactorCounter--;
                if (s.RevengeFactorCounter < 0)
                    s.RevengeFactorCounter = 0;
                db.SaveStudent(s, null);
            }
            lstClassi_DoubleClick(null, null);
        }
        private void rdbDrawOnVindicationFactor_CheckedChanged(object sender, EventArgs e)
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
        private void picStudent_DoubleClick(object sender, EventArgs e)
        {
            frmStudent fs = new frmStudent(currentStudent, true);
            fs.ShowDialog();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!File.Exists(Commons.PathAndFileDatabase))
                return;

            timerLesson.Stop(); 
            timerPopUp.Stop();
            timerQuestion.Stop();

            string file = Commons.PathLogs + @"\frmMain_parameters.txt";
            Commons.SaveCurrentValuesOfAllControls(this, ref file);
            SaveStudentsOfClassIfEligibleHasChanged();
            // if a save of the database with Mptt is running, we close it 
            if (Commons.BackgroundSaveThread.IsAlive)
            {
                Commons.BackgroundCanStillSaveTopicsTree = false;
                // we wait for the saving Thread to finish
                Commons.BackgroundSaveThread.Join(2 * 60000);
            }
            // save in the log folder a copy of the database, if enabled 
            if (Commons.SaveBackupWhenExiting)
            { 
                File.Copy(Commons.PathAndFileDatabase,
                    Commons.PathLogs + "\\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") +
                    "_" + Commons.FileDatabase);
            }
        }
        private void btnClassesGradesSummary_Click(object sender, EventArgs e)
        {
            if (!Commons.CheckIfClassChosen(currentClass))
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
            if (lstNames.Visible)
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
            string filename = currentClass.SchoolYear +
                "_" + currentClass.Abbreviation +
                "_" + currentSubject.IdSchoolSubject + "_" +
                "all-topics.txt";
            List<Topic> lt = db.GetAllTopicsDoneInClassAndSubject(currentClass,
                currentSubject);
            string f = "";
            string tabs = "";
            Topic previous = new Topic();
            previous.Id = -2;
            string status = "s"; // start tab 
            foreach (Topic t in lt)
            {
                // put a tab in front of descending nodes 
                switch (status)
                {
                    case "s": // start tab
                        {
                            if (t.ParentNodeOld == previous.Id)
                            {
                                // is son of the previous
                                tabs += "\t";
                                status = "b"; // brothers
                            }
                            else
                                tabs = "";
                            break;
                        }
                    case "b": // brothers 
                        {
                            if (t.ParentNodeOld == previous.ParentNodeOld)
                            {
                                // another brother: do nothing
                            }
                            else if (t.ParentNodeOld == previous.Id)
                            {
                                // is son of the previous
                                tabs += "\t";
                                status = "b"; // brothers
                            }
                            else
                            {   // non brothers & non son 
                                tabs = "";
                                status = "s"; // brothers
                            }
                            break;
                        }
                    case "u":
                        {
                            break;
                        }
                }
                f += tabs + t.Name;
                if (t.Desc != "")
                    f += ": " + t.Desc;
                f += "\r\n";
                previous = t;
            }
            TextFile.StringToFile(Commons.PathDatabase + "\\" + filename, f, false);
            Commons.ProcessStartLink(Commons.PathDatabase + "\\" + filename);
            MessageBox.Show("Creato il file " + filename);
        }
        private void ChkEnableEndLessonWarning_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkEnableEndLessonWarning.Checked)
            {
                CalculateTimesForEndLessonWarning();
            }
        }
        private void CalculateTimesForEndLessonWarning()
        {
            // start the colored button that shows the time to the end of the lesson
            int.TryParse(txtMinuteStartLesson.Text, out minuteStart);
            float.TryParse(txtDurationLesson.Text, out timeLessonMinutes);

            float.TryParse(txtMinuteStartAlarm.Text, out timeAlarmMinutes);
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

            if (ChkEnableEndLessonWarning.Checked)
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
                AForge.Imaging.ColorConverter.HSL2RGB(colHSL, colRGB);
                CurrentLessonTimeColor = colRGB.Color;

                BtnLessonTime.BackColor = CurrentLessonTimeColor;
            }
            else
            {
                timerLesson.Stop();
                CurrentLessonTimeColor = Color.Transparent;
                BtnLessonTime.BackColor = CurrentLessonTimeColor;
            }
        }
        private void ChkActivateLessonClock_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkActivateLessonClock.Checked)
                timerLesson.Enabled = true;
            else
            {
                timerLesson.Enabled = false;
                CurrentLessonTimeColor = Color.Transparent;
                BtnLessonTime.BackColor = CurrentLessonTimeColor;
            }
            Commons.IsTimerLessonActive = ChkActivateLessonClock.Checked;
        }
        private void btnTemporary_Click(object sender, EventArgs e)
        {
            //frmTestGrading fg = new frmTestGrading();
            //fg.Show();
            ////Student dummyStudent = new Student();
            ////dummyStudent.IdStudent = 388;
            ////dummyStudent.LastName = "Dummy"; 

            ////frmStudentsAnnotations f = new frmStudentsAnnotations(dummyStudent, 
            ////    null);
            ////f.Show();
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
            double t =  double.Parse(txtTimeInterval.Text);
            ColorTimer ft = new ColorTimer(t /60, t /60, SoundEffectsInTimer);
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
             if (currentStudent != null && !lstNames.Visible)
            {
                // annotation applied to a single student
                chosenStudents = new List<Student>();
                chosenStudents.Add(currentStudent);
            }
            else
            {
                // annotation applied to a whole list of students
                chosenStudents = FillListOfChecked();
            }
            if (chosenStudents.Count > 0)
            {
                frmAnnotationsAboutStudents f = new frmAnnotationsAboutStudents(chosenStudents, CmbSchoolYear.Text);
                f.Show();
            }
        }

        private void chkPopUpQuestionsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            timerPopUp.Interval = 1;
            timerPopUp.Enabled = chkPopUpQuestionsEnabled.Checked;
            if (timerPopUp.Enabled)
            {
                SetNewPopUpOfQuestion(); 
            }
        }

        private void SetNewPopUpOfQuestion()
        {
            int PopUpQuestionCentralTime;
            int.TryParse(txtPopUpQuestionCentralTime.Text, out PopUpQuestionCentralTime);
            double displacementTime = PopUpQuestionCentralTime * 0.1;
            double minutesToTheNextQuestion = PopUpQuestionCentralTime - random.NextDouble() * 
                PopUpQuestionCentralTime * displacementTime/ 2; 
            nextPopUpQuestionTime = DateTime.Now.AddMinutes(minutesToTheNextQuestion);
            timerPopUp.Enabled = true;
        }

        private void timerPopUp_Tick(object sender, EventArgs e)
        {
            if (nextPopUpQuestionTime < DateTime.Now)
            {
                timerPopUp.Enabled = false;
                if (currentClass == null)
                {
                    Console.Beep(1000, 500);
                    SetNewPopUpOfQuestion();
                    return;
                }
                if (eligiblesList.Count > 0)
                {
                    if (indexCurrentDrawn < eligiblesList.Count)
                    {
                        Console.Beep(400, 800);
                        // make a question to a random student
                        btnComeOn_Click(null, null);
                        chkFotoVisibile.Checked = true;
                        btnAssess_Click(null, null);
                        // prepare for the next popup question 
                        SetNewPopUpOfQuestion();
                        return; 
                    }
                    else
                    {
                        Console.Beep(2000, 500);
                        SetNewPopUpOfQuestion();
                        return;
                    }
                }
                else
                {
                    Console.Beep(3000, 500);
                    SetNewPopUpOfQuestion();
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
    }
}
