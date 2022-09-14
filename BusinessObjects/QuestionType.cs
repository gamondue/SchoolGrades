using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
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
