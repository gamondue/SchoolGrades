using SchoolGrades;
using SchoolGrades.DbClasses;
using SharedWebForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace SchoolGrades_Web
{
    public partial class Default : System.Web.UI.Page
    {
        Color colorGrade = Color.Red;
        public int indexCurrentDrawn = 0;

        public List<Student> currentStudentsList;
        public List<Student> eligiblesList = new List<Student>();

        ////////List<frmLessons> listLessons = new List<frmLessons>();

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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // read configuration file or run configuration 
                if (!CommonsWebForms.ReadConfigFile())
                {
                    // config file is unexistent or broken 
                    if (Commons.PathAndFileDatabase.Contains("DEMO") && File.Exists(Commons.PathAndFileDatabase))
                    {
                        // if demo database exists, save the configuration program with demo file 
                        CommonsWebForms.WriteConfigFile();
                    }
                    else
                    {
                        MessageBox messageBox = new MessageBox("Configurazione del programma.\r\n" +
                            "Sistemare le cartelle con il percorso dei file (in particolare la cartella che contiene il database), " +
                            "poi scegliere il file di dati .sqlite e premere 'Salva configurazione'", "SchoolGrades");
                        // we don't want the demo file or it doesn't exist. Let's ask the user 
                        //messageBox.Show("Configurazione del programma.\r\n" +
                        //    "Sistemare le cartelle con il percorso dei file (in particolare la cartella che contiene il database), " +
                        //    "poi scegliere il file di dati .sqlite e premere 'Salva configurazione'", "SchoolGrades");
                        Server.Transfer("Setup.aspx");
                        if (!File.Exists(Commons.PathAndFileDatabase))
                        {
                            messageBox.Show("Configurare il programma!", "SchoolGrades",
                                MessageBox.MessageBoxButtons.OK, MessageBox.MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    // config file has been read 
                    // do nothing
                }

                string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                this.Title += " v. " + version;

                // first default year in the "years" combo
                int firstYear = 2009;

                int nYears = CmbSchoolYear.Items.Count;

                string currentYear;
                int nowYear = (DateTime.Now.Year - 2000);
                if (DateTime.Now.Month >= 9)
                    currentYear = nowYear.ToString("00") + (nowYear + 1).ToString("00");
                else
                    currentYear = (nowYear - 1).ToString("00") + (nowYear).ToString("00");

                for (; firstYear <= DateTime.Now.Year; firstYear++)
                {
                    CmbSchoolYear.Items.Add((firstYear - 2000).ToString("00") + ((firstYear + 1) - 2000).ToString("00"));
                }
                // !!!! TODO automatically select the current school year in the combo !!!!

                // fill the combo of grade types 
                List<GradeType> ListGradeTypes = Commons.bl.GetListGradeTypes();
                cmbGradeType.DataSource = ListGradeTypes;
                cmbGradeType.AutoPostBack = true; 

                // fill the combo of School subjects
                List<SchoolSubject> listSubjects = Commons.bl.GetListSchoolSubjects(true);
                cmbSchoolSubject.DataSource = listSubjects;
            }
        }
        internal void btnTest_Click()
        {

        }
    }
}