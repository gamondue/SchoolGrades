using SchoolGrades.DbClasses;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmMicroAssessment : Form
    {
        private string currentYear;

        private int idQuestionParent;
        private string idGradeType;
        private string idGradeTypeParent;

        frmMain callingForm;

        private Class currentClass;
        Student currentStudent;
        Grade currentMacroGrade;
        GradeType currentGradeType;
        SchoolSubject currentSchoolSubject;
        Question currentQuestion = new Question();

        internal Question CurrentQuestion { get => currentQuestion; set => currentQuestion = value; }

        //Question oldQuestion = null;
        Grade currentGrade = new Grade();
        internal Grade CurrentGrade { get => currentGrade; set => currentGrade = value; }

        DbAndBusiness db = new DbAndBusiness();

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
        }

        public frmMicroAssessment(int IdGrade)
        {
            InitializeComponent();

            // constructor for subgrades for a grade passed trough its id
            currentGrade.IdGrade = IdGrade;
            currentStudent = new Student();
            db.GetGradeAndStudent(currentGrade, currentStudent);
            currentYear = currentGrade.IdSchoolYear;
            currentClass = db.GetClassOfStudent(Commons.IdSchool, currentYear, currentStudent);
            
            currentGradeType = db.GetGradeType(currentGrade.IdGradeType);

            currentSchoolSubject = db.GetSchoolSubject(currentGrade.IdSchoolSubject);
            currentQuestion = db.GetQuestionById(currentGrade.IdQuestion);
        }

        private void frmMicroAssessment_Load(object sender, EventArgs e)
        {
            if (currentStudent is null)
            {
                MessageBox.Show("Selezionare un allievo");
                this.Close();
            }

            //if (currentGradeType != null)
            txtGradeType.Text = currentGradeType.Name;

            //currentMacroGrade = db.GetGrade(currentGradeType.IdGradeTypeParent);
            currentYear = currentClass.SchoolYear;
            txtSchoolSubject.Text = currentSchoolSubject.IdSchoolSubject;
            currentMacroGrade = null;
            if (currentGradeType.IdGradeTypeParent != null && currentGradeType.IdGradeTypeParent != "")
            {
                // find the last macro grade of this student 
                currentMacroGrade = db.LastGradeOfStudent(currentStudent, currentYear
                    , currentSchoolSubject, currentGradeType.IdGradeTypeParent);
                // get grade type information of that last macro grade
                GradeType gt = db.GetGradeType(currentMacroGrade.IdGradeType);
                if (gt != null)
                {
                    txtGradeTypeParent.Text = gt.Name;
                    txtIdMacroGrade.Text = currentMacroGrade.IdGrade.ToString();
                }
                else
                {
                    txtIdMacroGrade.BackColor = Color.Red;
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
                picStudent.Image = System.Drawing.Image.FromFile(Commons.PathImages + "\\" +
                db.GetFilePhoto(currentStudent.IdStudent, currentYear));
            }
            catch
            {
            }

            this.BackColor = Commons.ColorFromNumber(currentSchoolSubject);
            LessonTimer.Interval = 1000; 
            if (Commons.IsTimerLessonActive)
                LessonTimer.Start();
        }

        private void ShowStudentsDataAndAverages()
        {
            // student's label
            lblStudent.Text = currentStudent.ToString(); 

            txtMicroGradeWeight.Text = currentGrade.Weight.ToString();
            txtMicroGrade.Text = currentGrade.Value.ToString(); 

            DataTable T = db.GetMicroGradesOfStudentWithMacroOpen(currentStudent.IdStudent, currentYear, currentGradeType.IdGradeType,
                currentSchoolSubject.IdSchoolSubject);
            // weighted sum
            DgwQuestions.DataSource = T;
            double weightedSum = 0;
            double sumOfWeights = 0;
            foreach (DataRow riga in T.Rows)
            {
                weightedSum += (double)riga["value"] * (double)riga["weight"];
                sumOfWeights += (double)riga["weight"];
            }
            txtWeightsSum.Text = sumOfWeights.ToString("#.#");
            if (sumOfWeights >= 95)
                txtWeightsSum.BackColor = Color.Lime;
            else if (sumOfWeights > 45)
                txtWeightsSum.BackColor = Color.Orange;
            else if(sumOfWeights > 66)
                txtWeightsSum.BackColor = Color.Yellow;
            else 
                txtWeightsSum.BackColor = Color.White;

            double weightedAverage = weightedSum / sumOfWeights;
            txtAverageMicroQuestions.Text = weightedAverage.ToString("#.##");

            double? defaultWeight = db.GetDefaultWeightOfGradeType(idGradeType);
            if (txtMicroGradeWeight.Text == "")
            {
                txtMicroGradeWeight.Text = defaultWeight.ToString();
            }
            defaultWeight = currentGradeType.DefaultWeight;
            txtMacroGradeWeight.Text = defaultWeight.ToString();
        }

        private void trkbWeight_Scroll(object sender, EventArgs e)
        {
            txtMicroGradeWeight.Text = trkbWeight.Value.ToString();
        }

        private void trkbGrade_Scroll(object sender, EventArgs e)
        {
            txtMicroGrade.Text = trkbGrade.Value.ToString();
        }

        int previousQuestionCode = int.MinValue;

        private void btnSaveMicroGrade_Click(object sender, EventArgs e)
        {
            if(currentQuestion == null || currentQuestion.IdQuestion == 0 
                || currentQuestion.IdQuestion == previousQuestionCode)
            {
                if (MessageBox.Show("Non hai scelto la domanda." +
                    "\r\nDevo memorizzare un voto senza domanda registrata (Sì)\r\no non memorizzare (No)?",
                    "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1)
                    == DialogResult.No)
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
                MessageBox.Show("Prima di assegnare voti parziali, generare un nuovo voto complessivo\n" +
                    "(\"Nuovo voto\")");
                return;  
            }
            Grade gradeParent = db.GetGrade(keyParent); 
            if (txtIdMacroGrade.Text != "" && (DgwQuestions.Rows.Count == 0))
            {
                if (gradeParent.Value > 0)
                {
                    if (MessageBox.Show("La macrovalutazione indicata è chiusa." +
                        "\nVuoi riaprirla per poter aggiungere questa nuova microvalutazione?",
                        "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button2)
                         == DialogResult.Yes)
                    {
                        // 
                        db.DeleteValueOfGrade(int.Parse(txtIdMacroGrade.Text));
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
            currentGrade.IdGrade = db.SaveMicroGrade(currentGrade);

            // remember that this question has already been done 
            if (currentQuestion.IdQuestion != 0)
                Commons.QuestionsAlreadyMadeThisTime.Add(currentQuestion);
            ShowStudentsDataAndAverages();
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
        private void btnNewMacroGrade_Click(object sender, EventArgs e) 
        {
            if (DgwQuestions.Rows.Count > 0)
            {
                MessageBox.Show("Prima di creare un nuovo voto di sintesi, " +
                    "chiudere quello che è attualmente aperto", "Creazione nuovo voto non consentita");
                return; 
            }
            currentMacroGrade.IdSchoolSubject = currentSchoolSubject.IdSchoolSubject;
            currentMacroGrade.IdSchoolYear = currentYear;

            idQuestionParent = db.CreateMacroGrade(ref currentMacroGrade 
                , currentStudent, idGradeType);
            txtIdMacroGrade.Text = idQuestionParent.ToString();
            txtIdMacroGrade.BackColor = Color.White;
            txtAverageMicroQuestions.Text = "";
            txtWeightsSum.Text = "";
            txtMacroGradeWeight.Text = ""; 
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            int peso = 0;
            int.TryParse(txtMicroGradeWeight.Text, out peso);
            if (peso >= 0 && peso <= 100)
            {
                trkbWeight.Value = peso; 
            }
        }

        private void txtGrade_TextChanged(object sender, EventArgs e)
        {
            float voto = 0;
            float.TryParse(txtMicroGrade.Text, out voto); 
            if (voto >= 10 && voto <= 100)
            {
                trkbGrade.Value = (int) voto;
            }
        }

        private void btnSaveMacroGrade_Click(object sender, EventArgs e)
        {
            double weight; 
            double.TryParse(txtWeightsSum.Text, out weight);

            if (MessageBox.Show("Assegnazione del voto indicato come nuovo voto complessivo",
                "Attenzione", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) 
                == DialogResult.No)
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
                MessageBox.Show("La media deve essere diversa da zero");
                return;
            }
            if (txtIdMacroGrade.Text != "")  // if we have a macrograde 
            {
                db.SaveMacroGrade(currentStudent.IdStudent, (int?)int.Parse(txtIdMacroGrade.Text),
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
        private void btnQuestionChoose_Click(object sender, EventArgs e)
        {
            //frmQuestionChoose choice = new frmQuestionChoose(currentSchoolSubject,
            //    currentClass, currentStudent, currentQuestion); // this one passes the subject
            
            // we don't pass the currentSubject because it is better to start from any type of question
            frmQuestionChoose choice = new frmQuestionChoose(this, currentSchoolSubject, 
                currentClass, currentStudent, currentQuestion);
            choice.ShowDialog();
            if (choice.ChosenQuestion.Text != null && choice.ChosenQuestion.Text != "")
                currentQuestion = choice.ChosenQuestion;
            if (currentQuestion != null)
            {
                DisplayCurrentQuestion(); 

                // put the question chosen also in the main form
                callingForm.CurrentQuestion = choice.ChosenQuestion; 
            } else
            {
                TxtQuestionText.Text = "";
                txtMicroGradeWeight.Text = "";
            }
            txtMicroGrade.Text = "";    
        }

        internal void DisplayCurrentQuestion()
        {
            TxtQuestionText.Text = currentQuestion.Text;
            txtMicroGradeWeight.Text = currentQuestion.Weight.ToString();
        }

        private void btnNoQuestion_Click(object sender, EventArgs e)
        {
            currentQuestion = null; 
        }

        private void DgwQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgwQuestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if ((DataTable)(DgwQuestions.DataSource) != null)
                {
                    DataRow row = ((DataTable)DgwQuestions.DataSource).Rows[e.RowIndex];
                    ReadCurrentGradeAndQuestionFromGridRow(row);
                    txtMicroGradeWeight.Text = currentGrade.Weight.ToString();
                    txtMicroGrade.Text = currentGrade.Value.ToString();
                    if (currentQuestion != null)
                        TxtQuestionText.Text = currentQuestion.Text;
                    else
                        TxtQuestionText.Text = "";

                    DgwQuestions.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void ReadCurrentGradeAndQuestionFromGridRow(DataRow row)
        {
            int? Id = SafeDb.SafeInt(row["IdQuestion"]);
            if (Id != null)
            {
                currentQuestion = db.GetQuestionById(SafeDb.SafeInt(row["IdQuestion"]));
            }
            else
            {
                currentQuestion = new Question(); 
                currentQuestion.IdQuestion = null;
            }
            currentGrade = db.GetGrade(SafeDb.SafeInt(row["idGrade"]));

            this.Refresh(); 
        }

        private void DgwQuestions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEraseMicroGrade_Click(object sender, EventArgs e)
        {
            if (DgwQuestions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Per cancellarla, selezionare una domanda dalla griglia.");
                return; 
            }
            DataGridViewRow row = (DgwQuestions.SelectedRows[0]);
            db.EraseGrade(SafeDb.SafeInt(row.Cells["idGrade"].Value));
            ShowStudentsDataAndAverages();
        }

        private void btnFlushQuestion_Click(object sender, EventArgs e)
        {
            currentQuestion = null;
            TxtQuestionText.Text = ""; 
        }

        private void frmMicroAssessment_FormClosing(object sender, FormClosingEventArgs e)
        {
            //currentQuestion = 
        }

        private void LessonTimer_Tick(object sender, EventArgs e)
        {
            lblLessonTime.BackColor = ((frmMain)Application.OpenForms[0]).CurrentLessonTimeColor; 
        }

        private void BtnSaveGrade(object sender, EventArgs e)
        {
            if (DgwQuestions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare una domanda dalla griglia, per poterla salvare.");
                ShowStudentsDataAndAverages();
                return;
            }
            DataRow row = ((DataTable) DgwQuestions.DataSource).Rows[DgwQuestions.SelectedRows[0].Index];
            ReadCurrentGradeAndQuestionFromGridRow(row);
            currentGrade = ReadUI(currentGrade); 
            currentGrade.IdGrade = db.SaveMicroGrade(currentGrade);
            ShowStudentsDataAndAverages();
        }

        private void TxtQuestionText_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtQuestionText_DoubleClick(object sender, EventArgs e)
        {
            frmQuestion f = new frmQuestion(frmQuestion.QuestionFormType.EditOneQuestion,
                currentQuestion, currentSchoolSubject, currentClass, null);
            f.Show();
        }

        private void txtIdMacroGrade_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
