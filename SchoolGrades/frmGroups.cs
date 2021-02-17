using gamon;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmGroups : Form
    {
        List<GroupBox> boxes;

        List<Student> listGroups;
        int nStudentsPerGroup;
        private int nGroups;

        Class schoolClass;

        public frmGroups(List<Student> GroupsList, Class Class)
        {
            InitializeComponent();

            listGroups = GroupsList;
            schoolClass = Class;
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
        }

        private void btnCreateGroups_Click(object sender, EventArgs e)
        {
            if (rbdGroupsRandom.Checked)
            {
                Commons.ShuffleList(listGroups);
            }
            else if (rdbGroupsBestGradesTogether.Checked)
            {

            }
            else if (rdbGradesBalanced.Checked)
            {

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
