﻿namespace SchoolGrades.DbClasses
{
    class QuestionType
    {
        private string idQuestionType;
        private string name;
        private string desc;

        public string IdQuestionType { get => idQuestionType; set => idQuestionType = value; }
        public string Name { get => name; set => name = value; }
        public string Desc { get => desc; set => desc = value; }
    }
}
