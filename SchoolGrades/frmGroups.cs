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
            string fileName = Path.Combine(Commons.PathDatabase,
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

            List<Student> ordered = new();

            if (rbdGroupsRandom.Checked)
            {
                ordered = Commons.bl.OrderStudentsByRandom(listGroups);
            }
            else if (rdbGroupsBestGradesTogether.Checked)
            {

            }
            else if (rdbGradesBalanced.Checked)
            {

            }

            txtGroups.Text = Commons.bl.GroupStudents_Formatted(ordered, nGroups, nStudentsPerGroup);
        }

        #region Group generation
        // TODO
        void GenerateGroupsWeightedAverage()
        {
            // Balanced component option should use a better algorithm (current one doesn't make the best to balace groups). 
            List<StudentAndGrade> l_weighted = Commons.bl.GetListGradesWeightedAveragesOfClassByName(schoolClass, schoolGrade.IdGradeType,
                schoolSubject.IdSchoolSubject, dtpStartPeriod.Value, dtpEndPeriod.Value);

            // sort list by WeightedAverage
            l_weighted = l_weighted.OrderBy(item => item.WeightedAverage).ToList();
            // put student's list in descending order, based on the grade
            l_weighted.Reverse();

            //Aggiornare listGroups in modo che gli studenti siano in ordine per il voto (utilizzare listStudents per i voti)
            //listGroups può anche non contenere tutti gli studenti di una classe
            //Evitare di alterare listStudents
            var l = new List<Student>();

            for (int i = 0; i < l_weighted.Count; i++)
            {
                for (int j = 0; j < listGroups.Count; j++)
                {
                    if (l_weighted[i].Student.LastName == listGroups[j].LastName
                        && l_weighted[i].Student.FirstName == listGroups[j].FirstName)
                    {
                        l.Add(listGroups[j]);
                    }
                }
            }
            listGroups = l;
        }
        // TODO
        void GenerateGroupsHighestGradesTogether()
        {
            // Balanced component option should use a better algorithm (current one doesn't make the best to balace groups). 
            List<StudentAndGrade> l_weighted = Commons.bl.GetListGradesWeightedAveragesOfClassByName(schoolClass, schoolGrade.IdGradeType,
                schoolSubject.IdSchoolSubject, dtpStartPeriod.Value, dtpEndPeriod.Value);

            // sort list by WeightedAverage
            l_weighted = l_weighted.OrderBy(item => item.WeightedAverage).ToList();
            // put student's list in descending order, based on the grade
            l_weighted.Reverse();

            var l = new List<Student>();

            for (int i = 0, g = 0; g < l_weighted.Count; g++)
            {
                for (int j = 0; j < listGroups.Count; j++)
                {
                    if (l_weighted[i].Student.LastName == listGroups[j].LastName &&
                        l_weighted[i].Student.FirstName == listGroups[j].FirstName)
                    {
                        l.Add(listGroups[j]);
                    }
                }
                l_weighted.RemoveAt(i);

                if (i == 0)
                    i = l_weighted.Count - 1;
                else
                    i = 0;
            }
            listGroups = l;
        }
        #endregion

        #region Events
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
        #endregion
    }
}
