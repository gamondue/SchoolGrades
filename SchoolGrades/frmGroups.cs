using gamon;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.BusinessObjects;
using System.Data;
using System.Linq;
using System.IO;

namespace SchoolGrades
{
    public partial class frmGroups : Form
    {
        List<GroupBox> boxes;

        List<Student> listGroups;
        int nStudentsPerGroup;
        private int nGroups;

        Class schoolClass;
        SchoolSubject schoolSubject;
        GradeType schoolGrade;
        SchoolPeriod schoolPeriod;

        bool AlreadyChanged = false;
        private SchoolPeriod currentSchoolPeriod;

        public frmGroups(List<Student> GroupsList, Class Class, SchoolSubject Subject, GradeType Grade)
        {
            InitializeComponent();

            listGroups = GroupsList;
            schoolClass = Class;
            schoolSubject = Subject;
            schoolGrade = Grade;

            List<SchoolPeriod> listPeriods = Commons.bl.GetSchoolPeriods(Class.SchoolYear);
            cmbSchoolPeriod.DataSource = listPeriods;
            // select the combo item of the partial period of the DateTime.Now
            foreach (SchoolPeriod sp in listPeriods)
            {
                if (sp.DateFinish > DateTime.Now && sp.DateStart < DateTime.Now
                    && sp.IdSchoolPeriodType == "P")
                {
                    cmbSchoolPeriod.SelectedItem = sp;
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
            if (txtGroups.Text == "")
            {
                MessageBox.Show("Prima di salvare un file, generare i gruppi");
                return; 
            }
            string fileName = Path.Combine(Commons.PathDatabase , 
                "Groups_" + schoolClass.Abbreviation + "_" + schoolClass.SchoolYear +
                ".txt");
            TextFile.StringToFile(fileName, txtGroups.Text, false);
            Commons.ProcessStartLink(fileName);
        }
        private void btnCreateGroups_Click(object sender, EventArgs e)
        {
            if (txtNGroups.Text == "" || txtStudentsPerGroup.Text == "")
            {
                MessageBox.Show("Scegliere il numero dei gruppi o degli studenti per gruppo!");
                return; 
            }
            // Balanced component option should use a better algorithm (current one doesn't make the best to balace groups). 
            List<StudentAndGrade> listStudentsWithWeightedAverage = Commons.bl.GetListGradesWeightedAveragesOfClassByName(schoolClass, schoolGrade.IdGradeType, 
                schoolSubject.IdSchoolSubject, dtpStartPeriod.Value, dtpEndPeriod.Value);

            // sort list by WeightedAverage
            listStudentsWithWeightedAverage = listStudentsWithWeightedAverage.OrderBy(item => item.WeightedAverage).ToList();
            // put student's list in descending order, based on the grade
            listStudentsWithWeightedAverage.Reverse();

            List<Student> listTempStudents;

            if (rbdGroupsRandom.Checked)
            {
                // !!!! TODO number of element in group is unbalanced!
                Commons.bl.GroupStudentsByRandom(ref listStudentsWithWeightedAverage); 
            }
            else if (rdbGroupsBestGradesTogether.Checked)
            {
            	//Aggiornare listGroups in modo che gli studenti siano in ordine per il voto (utilizzare listStudents per i voti)
                //listGroups può anche non contenere tutti gli studenti di una classe
                //Evitare di alterare listStudents
                listTempStudents = new List<Student>();

                for (int i = 0; i < listStudentsWithWeightedAverage.Count; i++)
                {
                    for (int j = 0; j < listGroups.Count; j++)
                    {
                        if (listStudentsWithWeightedAverage[i].Student.LastName == listGroups[j].LastName 
                            && listStudentsWithWeightedAverage[i].Student.FirstName == listGroups[j].FirstName)
                        {
                            listTempStudents.Add(listGroups[j]);
                        }
                    }
                }
                listGroups = listTempStudents;
            }
            else if (rdbGradesBalanced.Checked)
            {
                int lengthLista = listStudentsWithWeightedAverage.Count;
                listTempStudents = new List<Student>();
               
                for (int i = 0, g = 0; g < lengthLista ; g++)
                {
                    for (int j = 0; j < listGroups.Count; j++)
                    {
                        if (listStudentsWithWeightedAverage[i].Student.LastName == listGroups[j].LastName && 
                            listStudentsWithWeightedAverage[i].Student.FirstName == listGroups[j].FirstName)
                        {
                            listTempStudents.Add(listGroups[j]);
                        }
                    }
                    listStudentsWithWeightedAverage.RemoveAt(i);
                    
                    if (i == 0)
                        i = listStudentsWithWeightedAverage.Count - 1;
                    else
                        i = 0;
                }
                listGroups = listTempStudents;
            }
            // create groups into groups array
            string[,] groups = new string[nGroups, nStudentsPerGroup];
            int stud = 0;
            for (int i = 0; i < nGroups; i++)
            {
                for (int j = 0; j < nStudentsPerGroup; j++)
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
                    if (groups[j, i] != null && groups[j, i] != " " && groups[j, i] != "  ")
                    {
                        groupsString += $"{nStud.ToString("00")} - {groups[j, i]} \r\n";
                        nStud++; 
                    }
                }
                groupsString += "\r\n";
            }
            groupsString += "\r\n";
            txtGroups.Text = groupsString;
        }
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
        private void cmbSchoolPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSchoolPeriod = (SchoolPeriod)(cmbSchoolPeriod.SelectedValue);
            if (currentSchoolPeriod.IdSchoolPeriodType != "N")
            {
                dtpStartPeriod.Value = (DateTime)currentSchoolPeriod.DateStart;
                dtpEndPeriod.Value = (DateTime)currentSchoolPeriod.DateFinish;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "month")
            {
                dtpStartPeriod.Value = DateTime.Now.AddMonths(-1);
                dtpEndPeriod.Value = DateTime.Now;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "week")
            {
                dtpStartPeriod.Value = DateTime.Now.AddDays(-7);
                dtpEndPeriod.Value = DateTime.Now;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "year")
            {
                dtpStartPeriod.Value = DateTime.Now.AddYears(-1);
                dtpEndPeriod.Value = DateTime.Now;
            }
        }
        private void grpGroups_Enter(object sender, EventArgs e)
        {

        }
        private void rbdTypeOfGroupings_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdGroupsRandom.Checked)
            {
                grpPeriodOfQuestionsTopics.Enabled = false; 
            }
            else if (rdbGroupsBestGradesTogether.Checked)
            {
                grpPeriodOfQuestionsTopics.Enabled = true;
            }
            else if (rdbGradesBalanced.Checked)
            {
                grpPeriodOfQuestionsTopics.Enabled = true;
            }
        }

        private void dtpStartPeriod_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
