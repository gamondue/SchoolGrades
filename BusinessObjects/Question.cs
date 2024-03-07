using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
{
    public class Question
    {
        private int? idQuestion = 0;
        private string idQuestionType = "";
        private string text = "";
        private double? weight = 0;
        private int? duration = 0;
        private int? idTopic = 0;
        //private int? idSubject = 0;
        private string idSchoolSubject = "";
        private int? difficulty = 0;
        private string image = "";

        public string QuestionImage { get; internal set; }
        public int? IdQuestion { get => idQuestion; set => idQuestion = value; }
        public string IdQuestionType { get => idQuestionType; set => idQuestionType = value; }
        public string Text { get => text; set => text = value; }
        public double? Weight { get => weight; set => weight = value; }
        public int? Duration { get => duration; set => duration = value; }
        public int? IdTopic { get => idTopic; set => idTopic = value; }
        //public int? IdSubject { get => idSubject; set => idSubject = value; }
        public string IdSchoolSubject { get => idSchoolSubject; set => idSchoolSubject = value; }
        public int? Difficulty { get => difficulty; set => difficulty = value; }
        public string Image { get => image; set => image = value; }
        public int? IdImage { get; internal set; }
        public int? NRows { get; internal set; }
        public int? IsParamount { get; internal set; }
        public bool? IsFixed { get; internal set; }
        public bool? IsMutex { get; internal set; }
    }
}
