using gamon;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.DbClasses;
using System.Data;

namespace SchoolGrades
{
    public partial class frmGroups : Form
    {
        List<GroupBox> boxes;

        List<Student> listGroups;
        int nStudentsPerGroup;
        private int nGroups;
        DbAndBusiness db;

        Class schoolClass;
        SchoolSubject schoolSubject;
        GradeType schoolGrade;
        SchoolPeriod schoolPeriod;

        internal struct StudentAndGrade
        {
            public string lastName;
            public string firstName;
            public double grade;

            public StudentAndGrade(string lastName, string firstName, double grade)
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.grade = grade;
            }
        }

        public frmGroups(List<Student> GroupsList, Class Class, SchoolSubject subject, GradeType grade)
        {
            InitializeComponent();

            listGroups = GroupsList;
            schoolClass = Class;
            schoolSubject = subject;
            schoolGrade = grade;
            db = new DbAndBusiness(Commons.PathAndFileDatabase);

            List<SchoolPeriod> listPeriods = db.GetSchoolPeriods(Class.SchoolYear);
            foreach (SchoolPeriod sp in listPeriods)
            {
                if (sp.DateFinish > DateTime.Now && sp.DateStart < DateTime.Now
                    && sp.IdSchoolPeriodType == "P")
                {
                    schoolPeriod = sp;
                }
            }
        }

        private void frmGroups_Load(object sender, EventArgs e)
        {
            txtTotalStudentsToGroup.Text = listGroups.Count.ToString();
            txtClass.Text = schoolClass.Abbreviation + " " + schoolClass.SchoolYear;
        }

        private void btnCreateFileGroups_Click(object sender, EventArgs e)
        {
            string fileName = Commons.PathDatabase + "\\" +
                "Groups_" + schoolClass.Abbreviation + "_" + schoolClass.SchoolYear +
                ".txt";
            TextFile.StringToFile(fileName, txtGroups.Text, false);
            Commons.ProcessStartLink(fileName);
        }

        private void btnCreateGroups_Click(object sender, EventArgs e)
        {
            DataTable tb = db.GetGradesWeightedAveragesOfClass(schoolClass, schoolGrade.IdGradeType, schoolSubject.IdSchoolSubject, (DateTime)schoolPeriod.DateStart, (DateTime)schoolPeriod.DateFinish);
            List<StudentAndGrade> listStudents = new List<StudentAndGrade>();
            foreach (DataRow row in tb.Rows)
                listStudents.Add(new StudentAndGrade(row.ItemArray[2].ToString(), row.ItemArray[3].ToString(), (double)row.ItemArray[4]));

            listStudents.Sort((firstGrade, secondGrade) => firstGrade.grade.CompareTo(secondGrade.grade));
            listStudents.Reverse(); //Lista studenti in ordine decrescente in base al voto


            if (rbdGroupsRandom.Checked)
            {
                Commons.ShuffleList(listGroups);
            }
            else if (rdbGroupsBestGradesTogether.Checked)
            {
                //Aggiornare listGroups in modo che gli studenti siano in ordine per il voto (utilizzare listStudents per i voti)
                //listGroups può anche non contenere tutti gli studenti di una classe
                //Evitare di alterare listStudents
            }
            else if (rdbGradesBalanced.Checked)
            {
                //Aggiornare listGroups in modo che gli studenti siano suddivisi, in base al valore nStudentsPerGroup, in gruppi bilanciati in base al voto(utilizzare listStudents per i voti)
                //listGroups può anche non contenere tutti gli studenti di una classe. I gruppi si possono bilanciare raggruppando il primo e l'ultimo della lista, poi il secondo e il penultimo, ecc...
                //Tenere conto del caso in cui il numero sia dispari
                //Evitare di alterare listStudents
            }
            // create groups into groups array
            string[,] groups = new string[nStudentsPerGroup, nGroups];
            int stud = 0;
            for (int i = 0; i < nStudentsPerGroup; i++)
            {
                for (int j = 0; j < nGroups; j++)
                {
                    Student s = listGroups[stud];
                    groups[i, j] = s.LastName + " " + s.FirstName;
                    stud++;
                    if (stud == listGroups.Count)
                        break;
                }
                if (stud == listGroups.Count)
                    break;
            }
            // make the string to show groups
            string groupsString = "";
            for (int j = 0; j < nGroups; j++)
            {
                groupsString += "Gruppo " + (j + 1).ToString() + "\r\n";
                int nStud = 1; 
                for (int i = 0; i < nStudentsPerGroup; i++)
                {
                    if (groups[i, j] != null && groups[i, j] != " " && groups[i, j] != "  ")
                    {
                        groupsString += $"{nStud.ToString("00")} - {groups[i, j]} \r\n";
                        nStud++; 
                    }
                }
                groupsString += "\r\n";
            }
            groupsString += "\r\n";
            txtGroups.Text = groupsString;
        }

        bool AlreadyChanged = false;
        private void txtStudentsPerGroup_TextChanged(object sender, EventArgs e)
        {
            if (txtStudentsPerGroup.Text != "" && !AlreadyChanged)
            {
                int.TryParse(txtStudentsPerGroup.Text, out nStudentsPerGroup);
                AlreadyChanged = true;
                if (nStudentsPerGroup != 0)
                {
                    nGroups = (int) Math.Ceiling((double)listGroups.Count / nStudentsPerGroup);
                    //nGroups++;
                    txtNGroups.Text = (nGroups).ToString();
                }
            }
            else
                AlreadyChanged = false;
        }

        private void txtNGroups_TextChanged(object sender, EventArgs e)
        {
            if (txtNGroups.Text != "" && !AlreadyChanged)
            {
                int.TryParse(txtNGroups.Text, out nGroups);
                if (nGroups != 0)
                {
                    nStudentsPerGroup = (int)Math.Ceiling((double)listGroups.Count / nGroups);
                }
                AlreadyChanged = true;
                txtStudentsPerGroup.Text = nStudentsPerGroup.ToString();
            }
            else
                AlreadyChanged = false;
        }
    }
}
