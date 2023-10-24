using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal List<Student> OrderStudentsByRandom(List<Student> students)
        {
            List<(Student, int)> randomI = new();

            Random r = new();
            for (int i = 0; i < students.Count; i++)
            {
                randomI.Add((students[i], r.Next()));
            }
            return randomI.OrderBy(el => el.Item2).Select(t => t.Item1).ToList();
        }

        internal string[,] GroupStudents(List<Student> students, int nof_groups, int groupSize)
        {
            // create groups into groups array
            string[,] groups = new string[nof_groups, groupSize];

            int group_i = 0;
            int group_l = 0;

            foreach (Student s in students)
            {
                groups[group_i, group_l] = s.LastName + " " + s.FirstName;
                group_l++;

                if (group_l > groupSize - 1)
                {
                    group_l = 0;
                    group_i++;
                }
            }
            return groups;
        }

        internal string GroupStudents_Formatted(List<Student> students, int nof_groups, int groupSize)
        {
            string[,] groups = GroupStudents(students, nof_groups, groupSize);
            // make the string to show groups
            string groupsString = "";
            for (int j = 0; j < nof_groups; j++)
            {
                groupsString += "Gruppo " + (j + 1) + "\r\n";
                int nStud = 1;
                for (int i = 0; i < groupSize; i++)
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
            return groupsString;
        }

    }
}
