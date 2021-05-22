﻿using System;

namespace SchoolGrades.DbClasses
{
    public class Lesson
    {
        int? idLesson;
        DateTime? date;
        int? idClass;
        string idSchoolSubject;
        string note;

        public int? IdLesson { get => idLesson; set => idLesson = value; }
        public int? IdClass { get => idClass; set => idClass = value; }
        public string IdSchoolSubject { get => idSchoolSubject; set => idSchoolSubject = value; }
        public string Note { get => note; set => note = value; }
        public DateTime? Date { get => date; set => date = value; }
        public string IdSchoolYear { get; internal set; }
    }
}
