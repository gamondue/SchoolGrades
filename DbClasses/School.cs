﻿namespace SchoolGrades.DbClasses
{
    class School
    {
        string idSchool;
        string name;
        string desc;
        string officialSchoolAbbreviation;

        public string IdSchool { get => idSchool; set => idSchool = value; }
        public string Name { get => name; set => name = value; }
        public string Desc { get => desc; set => desc = value; }
        public string OfficialSchoolAbbreviation { get => officialSchoolAbbreviation; set => officialSchoolAbbreviation = value; }
    }
}
