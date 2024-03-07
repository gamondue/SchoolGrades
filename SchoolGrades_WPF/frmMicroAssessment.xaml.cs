using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per MicroAssessmentWPF.xaml
    /// </summary>
    public partial class frmMicroAssessment : Window
    {
        private string currentYear;
        private int idQuestionParent;
        private string idGradeType;
        //BusinessLayer Commons.bl;
        private string idGradeTypeParent;
        private DispatcherTimer LessonTimer;

        frmMain callingForm;

        private Class currentClass;
        Student currentStudent;
        Grade currentMacroGrade;
        GradeType currentGradeType;
        SchoolSubject currentSchoolSubject;
        Question currentQuestion = new Question();

        #region constructors
        internal frmMicroAssessment(frmMain CallingForm, Class Class, Student Student,
            GradeType GradeType, SchoolSubject Subject, Question Question)
        {
            InitializeComponent();

            callingForm = CallingForm;
            currentClass = Class;
            currentStudent = Student;
            currentGradeType = GradeType;
            currentSchoolSubject = Subject;
            currentQuestion = Question;
            LessonTimer = new DispatcherTimer();

            frmMicroAssessment_Loaded();
        }
        public frmMicroAssessment(int IdGrade)
        {
            InitializeComponent();

            // constructor for subgrades for a grade passed trough its id
            currentGrade.IdGrade = IdGrade;
            currentStudent = new Student();
            Commons.bl.GetGradeAndStudentFromIdGrade(ref currentGrade, ref currentStudent);
            currentYear = currentGrade.IdSchoolYear;
            currentClass = Commons.bl.GetClassOfStudent(Commons.IdSchool, currentYear, currentStudent);

            currentGradeType = Commons.bl.GetGradeType(currentGrade.IdGradeType);

            currentSchoolSubject = Commons.bl.GetSchoolSubject(currentGrade.IdSchoolSubject);
            currentQuestion = Commons.bl.GetQuestionById(currentGrade.IdQuestion);

            frmMicroAssessment_Loaded();
        }
        #endregion

        internal Question CurrentQuestion { get => currentQuestion; set => currentQuestion = value; }
        Grade currentGrade = new Grade();
        internal Grade CurrentGrade { get => currentGrade; set => currentGrade = value; }

        private void frmMicroAssessment_Loaded()
        {
            if (currentStudent is null)
            {
                MessageBox.Show("Selezionare un allievo");
                this.Close();
                return;
            }
            txtGradeType.Text = currentGradeType.Name;

            currentYear = currentClass.SchoolYear;
            txtSchoolSubject.Text = currentSchoolSubject.IdSchoolSubject;
            currentMacroGrade = null;
            if (currentGradeType.IdGradeTypeParent != null && currentGradeType.IdGradeTypeParent != "")
            {
                // find the last macro grade of this student 
                currentMacroGrade = Commons.bl.LastOpenGradeOfStudent(currentStudent, currentYear
                    , currentSchoolSubject, currentGradeType.IdGradeTypeParent);
                // get grade type information of that last macro grade
                GradeType gt = Commons.bl.GetGradeType(currentMacroGrade.IdGradeType);
                if (gt != null)
                {
                    txtGradeTypeParent.Text = gt.Name;
                    txtIdMacroGrade.Text = currentMacroGrade.IdGrade.ToString();
                }
                else
                {
                    txtIdMacroGrade.Background = Brushes.Red;
                }
            }
            else
            {
                txtGradeTypeParent.Text = "----";
                txtIdMacroGrade.Text = "----";
            }
            idGradeType = currentGradeType.IdGradeType;
            TxtIdStudent.Text = currentStudent.IdStudent.ToString();
            ShowStudentsDataAndAverages();

            if (currentQuestion != null)
            {
                DisplayCurrentQuestion();
            }

            try
            {
                picStudent.Source = new BitmapImage(new Uri(Commons.PathImages + "\\" +
                Commons.bl.GetFilePhoto(currentStudent.IdStudent, currentYear))); //System.Drawing.Image.FromFile(Commons.PathImages + "\\" +
                //Commons.bl.GetFilePhoto(currentStudent.IdStudent, currentYear));
            }
            catch
            {
            }

            //this.Background = CommonsWpf.ColorFromNumber(currentSchoolSubject);
            Color BackColor = CommonsWpf.ColorFromNumber(currentSchoolSubject.Color);
            this.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(BackColor.A, BackColor.R, BackColor.G, BackColor.B));
            LessonTimer.Interval = new TimeSpan(0, 0, 1);
            if (Commons.IsTimerLessonActive)
                LessonTimer.Start();
        }
        private void ShowStudentsDataAndAverages()
        {
            // student's label
            lblStudent.Content = currentStudent.ToString();
            if (currentStudent.HasSpecialNeeds != null && currentStudent.HasSpecialNeeds == true)
                chkHasSpecialNeeds.IsChecked = true;
            if (currentGrade.Weight != null)
                txtMicroGradeWeight.Text = ((double)currentGrade.Weight).ToString("#.##");
            if (currentGrade.Value != null)
                txtMicroGrade.Text = ((double)currentGrade.Value).ToString("#.#");

            DataTable T = Commons.bl.GetMicroGradesOfStudentWithMacroOpen(currentStudent.IdStudent, currentYear, currentGradeType.IdGradeType,
                currentSchoolSubject.IdSchoolSubject);
            // weighted sum
            dgwQuestions.ItemsSource = T.AsDataView();
            double weightedSum = 0;
            double sumOfWeights = 0;
            foreach (DataRow riga in T.Rows)
            {
                weightedSum += (double)riga["value"] * (double)riga["weight"];
                sumOfWeights += (double)riga["weight"];
            }
            txtWeightsSum.Text = sumOfWeights.ToString("#.#");
            if (sumOfWeights >= 95)
                txtWeightsSum.Background = Brushes.Lime;
            else if (sumOfWeights > 45)
                txtWeightsSum.Background = Brushes.Orange;
            else if (sumOfWeights > 66)
                txtWeightsSum.Background = Brushes.Yellow;
            else
                txtWeightsSum.Background = Brushes.White;

            double weightedAverage = weightedSum / sumOfWeights;
            txtAverageMicroQuestions.Text = weightedAverage.ToString("#.##");

            double? defaultWeight = Commons.bl.GetDefaultWeightOfGradeType(idGradeType);
            if (txtMicroGradeWeight.Text == "")
            {
                txtMicroGradeWeight.Text = ((double)defaultWeight).ToString("#.#");
            }
            defaultWeight = currentGradeType.DefaultWeight;
            txtMacroGradeWeight.Text = defaultWeight.ToString();
        }
        private void trkbWeight_Scroll(object sender, RoutedEventArgs e)
        {
            txtMicroGradeWeight.Text = trkbWeight.Value.ToString();
        }
        private void trkbGrade_Scroll(object sender, RoutedEventArgs e)
        {
            txtMicroGrade.Text = ((double)trkbGrade.Value).ToString("#.#");
        }
        int previousQuestionCode = int.MinValue;
        private void SaveMicrogradeFromGrid_Click(object sender, RoutedEventArgs e)
        {
            //currentQuestion = (Question) dgwQuestions.SelectedItem;  
            if (currentQuestion == null || currentQuestion.IdQuestion == 0
                || currentQuestion.IdQuestion == previousQuestionCode)
            {
                if (MessageBox.Show("Non hai scelto la domanda." +
                    "\r\nDevo memorizzare un voto senza domanda registrata (Sì)\r\no non memorizzare (No)?",
                    "Attenzione", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.Yes) == MessageBoxResult.No)
                    return;
                else
                {
                    currentQuestion = new Question();
                    currentQuestion.IdQuestion = 0;
                }
            }
            int keyParent = 0;
            int.TryParse(txtIdMacroGrade.Text, out keyParent);
            if (keyParent == 0)
            {
                MessageBox.Show("Prima di assegnare voti parziali, generare un nuovo voto di sintesi\n" +
                    "(\"Nuovo voto\")");
                return;
            }
            Grade gradeParent = Commons.bl.GetGrade(keyParent);
            if (txtIdMacroGrade.Text != "" && (dgwQuestions.Items.Count == 0))
            {
                if (gradeParent.Value > 0)
                {
                    if (MessageBox.Show("La macrovalutazione indicata è chiusa." +
                        "\nVuoi riaprirla per poter aggiungere questa nuova microvalutazione?",
                        "Attenzione", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        Commons.bl.DeleteValueOfGrade(int.Parse(txtIdMacroGrade.Text));
                        ShowStudentsDataAndAverages();
                    }
                    return;
                }
            }
            if (!GradeAndWeightExist())
                return;
            currentGrade = ReadUI(currentGrade);
            // erase IdGrade to save a new record 
            currentGrade.IdGrade = null;
            currentGrade.Timestamp = DateTime.Now;
            currentGrade.IdGrade = Commons.bl.SaveMicroGrade(currentGrade);

            // remember that this question has already been done 
            if (currentQuestion.IdQuestion != 0)
                Commons.QuestionsAlreadyMadeThisTime.Add(currentQuestion);
            ShowStudentsDataAndAverages();
            // goto the last row
            dgwQuestions.UnselectAll();
            dgwQuestions.SelectedItem = dgwQuestions.Items[dgwQuestions.Items.Count - 1];
        }
        private bool GradeAndWeightExist()
        {
            int voto, peso;

            int.TryParse(txtMicroGrade.Text, out voto);
            int.TryParse(txtMicroGradeWeight.Text, out peso);
            if (voto == 0 || peso == 0)
            {
                MessageBox.Show("Scrivere un voto ed un peso");
                return false;
            }
            else
            {
                return true;
            }
        }
        private Grade ReadUI(Grade Grade)
        {
            Grade.IdQuestion = currentQuestion.IdQuestion;
            Grade.IdGradeParent = int.Parse(txtIdMacroGrade.Text);
            Grade.Value = int.Parse(txtMicroGrade.Text);
            Grade.Weight = int.Parse(txtMicroGradeWeight.Text);
            Grade.IdSchoolYear = currentYear;
            Grade.IdQuestion = currentQuestion.IdQuestion;
            Grade.IdGradeType = idGradeType;
            Grade.IdStudent = currentStudent.IdStudent;
            Grade.IdSchoolSubject = currentSchoolSubject.IdSchoolSubject;

            ShowStudentsDataAndAverages();
            return Grade;
        }
        private void btnNewMacroGrade_Click(object sender, RoutedEventArgs e)
        {
            if (dgwQuestions.Items.Count > 0)
            {
                MessageBox.Show("Prima di creare un nuovo voto di sintesi, " +
                    "chiudere quello che è attualmente aperto", "Creazione nuovo voto non consentita");
                return;
            }
            currentMacroGrade.IdSchoolSubject = currentSchoolSubject.IdSchoolSubject;
            currentMacroGrade.IdSchoolYear = currentYear;

            idQuestionParent = Commons.bl.CreateMacroGrade(ref currentMacroGrade
                , currentStudent, idGradeType);
            txtIdMacroGrade.Text = idQuestionParent.ToString();
            txtIdMacroGrade.Background = Brushes.White;
            txtAverageMicroQuestions.Text = "";
            txtWeightsSum.Text = "";
            txtMacroGradeWeight.Text = "";
        }
        private void txtWeight_TextChanged(object sender, RoutedEventArgs e)
        {
            int peso = 0;
            int.TryParse(txtMicroGradeWeight.Text, out peso);
            if (peso >= 0 && peso <= 100)
            {
                trkbWeight.Value = peso;
            }
        }
        private void txtGrade_TextChanged(object sender, RoutedEventArgs e)
        {
            float voto = 0;
            float.TryParse(txtMicroGrade.Text, out voto);
            if (voto >= 10 && voto <= 100)
            {
                trkbGrade.Value = (int)voto;
            }
        }
        private void btnSaveMacroGrade_Click(object sender, RoutedEventArgs e)
        {
            double weight;
            double.TryParse(txtWeightsSum.Text, out weight);

            if (MessageBox.Show("Assegnazione del voto indicato come nuovo voto complessivo",
                "Attenzione", MessageBoxButton.YesNo, MessageBoxImage.Exclamation)
                == MessageBoxResult.No)
                return;

            if (weight == 0)
            {
                MessageBox.Show("Digitare un peso diverso da zero");
                return;
            }
            double average;
            double.TryParse(txtAverageMicroQuestions.Text, out average);
            if (average == 0)
            {
                MessageBox.Show("La media od il voto assegnato deve essere diversa da zero");
                return;
            }
            if (txtIdMacroGrade.Text != "")  // if we have a macrograde 
            {
                Commons.bl.SaveMacroGrade(currentStudent.IdStudent, (int?)int.Parse(txtIdMacroGrade.Text),
                    average, weight, currentYear,
                    currentSchoolSubject.IdSchoolSubject);
                //txtIdMacroGrade.Text = "";
                ShowStudentsDataAndAverages();
            }
            else
            {
                MessageBox.Show("Questo voticino non ha un voto che lo comprende.\r\tCreare un voto.");
            }
        }
        private void btnQuestionChoose_Click(object sender, RoutedEventArgs e)
        {
            // we don't pass the currentSubject because it is better to start from any type of question
            frmQuestionChoose choice = new frmQuestionChoose(currentSchoolSubject, currentClass, currentStudent, currentQuestion);
            choice.ShowDialog();
            if (choice.ChosenQuestion.Text != null && choice.ChosenQuestion.Text != "")
                currentQuestion = choice.ChosenQuestion;
            if (currentQuestion != null)
            {
                DisplayCurrentQuestion();
                // put the question chosen also in the main form
                if (callingForm != null)
                    callingForm.currentQuestion = choice.ChosenQuestion;
            }
            else
            {
                txtQuestionText.Text = "";
                txtMicroGradeWeight.Text = "";
            }
            txtMicroGrade.Text = "";
        }
        internal void DisplayCurrentQuestion()
        {
            txtQuestionText.Text = currentQuestion.Text;
            txtMicroGradeWeight.Text = currentQuestion.Weight.ToString();
        }
        private void btnNoQuestion_Click(object sender, RoutedEventArgs e)
        {
            currentQuestion = null;
        }
        //private void dgwQuestions_CellContentClick(object sender, RoutedEventArgs e)
        //{

        //}
        private void dgwQuestions_CellClick(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if (grid != null)
            {
                int RowIndex = grid.SelectedIndex;
                if (RowIndex > -1)
                {
                    DataRowView q = (DataRowView)grid.Items[RowIndex];
                    ReadCurrentGradeAndQuestionFromGridRow(q);
                    txtMicroGradeWeight.Text = currentGrade.Weight.ToString();
                    txtMicroGrade.Text = ((double)currentGrade.Value).ToString("#.#");
                    if (currentQuestion != null)
                        txtQuestionText.Text = currentQuestion.Text;
                    else
                        txtQuestionText.Text = "";
                }
            }
        }
        private void ReadCurrentGradeAndQuestionFromGridRow(DataRowView row)
        {
            int? Id = Safe.Int(row["IdQuestion"]);
            if (Id != null)
            {
                currentQuestion = Commons.bl.GetQuestionById(Safe.Int(row["IdQuestion"]));
            }
            else
            {
                currentQuestion = new Question();
                currentQuestion.IdQuestion = null;
            }
            currentGrade = Commons.bl.GetGrade(Safe.Int(row["idGrade"]));

            ////////this.Refresh();
        }
        //////////private void dgwQuestions_CellDoubleClick(object sender, RoutedEventArgs e)
        //////////{
        //////////}
        private void btnEraseMicroGrade_Click(object sender, RoutedEventArgs e)
        {
            if (dgwQuestions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Per cancellarla, selezionare una domanda dalla griglia.");
                return;
            }
            Grade rowNode = (Grade)(dgwQuestions.SelectedItems[0]);
            Commons.bl.EraseGrade(rowNode.IdGrade);
            ShowStudentsDataAndAverages();
        }
        private void btnFlushQuestion_Click(object sender, RoutedEventArgs e)
        {
            currentQuestion = null;
            txtQuestionText.Text = "";
        }
        //////////////private void frmMicroAssessment_FormClosing(object sender, FormClosingEventArgs e)
        //////////////{
        //////////////    //currentQuestion = 
        //////////////}
        private void LessonTimer_Tick(object sender, RoutedEventArgs e)
        {
            ////////lblLessonTime.Background = ((frmMain)Application.OpenForms[0]).CurrentLessonTimeColor;
        }
        private void BtnSaveGrade(object sender, RoutedEventArgs e)
        {
            if (dgwQuestions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selezionare una domanda dalla griglia, per poterla salvare.");
                ShowStudentsDataAndAverages();
                return;
            }
            Grade rowNode = (Grade)(dgwQuestions.SelectedItems[0]);
            Commons.bl.EraseGrade(rowNode.IdGrade);
            currentGrade = rowNode;
            //ReadCurrentGradeAndQuestionFromGridRow(row);
            currentGrade = ReadUI(currentGrade);
            currentGrade.IdGrade = Commons.bl.SaveMicroGrade(currentGrade);
            ShowStudentsDataAndAverages();
        }
        private void txtQuestionText_DoubleClick(object sender, RoutedEventArgs e)
        {
            ////////frmQuestion f = new frmQuestion(frmQuestion.QuestionFormType.EditOneQuestion,
            ////////    currentQuestion, currentSchoolSubject, currentClass, null);
            ////////f.ShowDialog();
            ////////if (f.UserHasChosen)
            ////////    txtQuestionText.Text = f.currentQuestion.Text;
        }
    }
}
