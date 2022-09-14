using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;

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
        internal List<Question> GetFilteredQuestionsNotAskedToStudent(Student Student, Class Class, 
            SchoolSubject Subject, string IdQuestionType, List<Tag> TagsList, 
            Topic Topic, bool QueryManyTopics, bool TagsAnd, string SearchString, 
            DateTime DateFrom, DateTime DateTo)
        {
            return dl.GetFilteredQuestionsNotAsked(Student, Class, Subject,
                IdQuestionType, TagsList, Topic, QueryManyTopics, TagsAnd, SearchString, DateFrom, DateTo);
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
