using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal List<QuestionType> GetListQuestionTypes(bool Value)
        {
            return dl.GetListQuestionTypes(Value);
        }
        internal void SaveAnswer(Answer currentAnswer)
        {
            dl.SaveAnswer(currentAnswer);
        }
        internal int? CreateAnswer(Answer currentAnswer)
        {
            return dl.CreateAnswer(currentAnswer);
        }
        internal void RemoveQuestionFromTest(int? idQuestionToRemove, int? idTest)
        {
            dl.RemoveQuestionFromTest(idQuestionToRemove, idTest);
        }
        internal List<StudentsAnswer> GetAllAnswersOfAStudentToAQuestionOfThisTest(int? idStudent, int? idQuestion, int? idTest)
        {
            return dl.GetAllAnswersOfAStudentToAQuestionOfThisTest(idStudent, idQuestion, idTest);
        }
        internal List<Question> GetFilteredQuestionsNotAskedToStudent(Student currentStudent, Class currentClass, 
            SchoolSubject currentSubject, string keyQuestionType, List<Tag> tagsList, Topic currentTopic, 
            bool checked1, bool checked2, string text, DateTime dateFrom, DateTime dateTo)
        {
            return dl.GetFilteredQuestionsNotAsked(currentStudent, currentClass, currentSubject,
                keyQuestionType, tagsList, currentTopic, checked1, checked2, text, dateFrom, dateTo);
        }
        internal List<Question> GetFilteredQuestionsAskedToClass(Class Class, SchoolSubject Subject, string KeyQuestionType, 
            List<Tag> TagsList, Topic Topic, bool Checked1, bool Checked2, string Text, DateTime DateFrom, DateTime DateTo)
        {
            return dl.GetFilteredQuestionsAskedToClass(Class, Subject, KeyQuestionType,
                TagsList, Topic, Checked1, Checked2, Text, DateFrom, DateTo);
        }
        internal void AddTagToQuestion(int? idQuestion, int? idTag)
        {
            dl.AddTagToQuestion(idQuestion, idTag);
        }
        internal Question CreateNewVoidQuestion()
        {
            return dl.CreateNewVoidQuestion();
        }
        internal void SaveQuestion(Question currentQuestion)
        {
            dl.SaveQuestion(currentQuestion);
        }
        internal void FixQuestionInGrade(int currentIdGrade)
        {
            dl.FixQuestionInGrade(currentIdGrade);
        }
        internal void AddQuestionToTest(Test Test, Question ChosenQuestion)
        {
            dl.AddQuestionToTest(Test, ChosenQuestion);
        }
    }
}
