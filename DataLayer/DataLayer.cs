using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SchoolGrades
{
    internal abstract partial class DataLayer
    {
        // ConstructorsAndGeneralMethods
        private string dbName;

        internal abstract DbConnection Connect();
        internal abstract int nFieldDbDataReader(string NomeCampo, DbDataReader dr);
        internal abstract bool FieldExists(string TableName, string FieldName);
        internal abstract void CompactDatabase();
        internal abstract School GetSchool(string OfficialSchoolAbbreviation);
        internal abstract int NextKey(string Table, string KeyName);
        internal abstract bool CheckKeyExistence(string TableName, string KeyName, string KeyValue);
        internal abstract void CreateNewDatabaseFromScratch(string databaseName);
        internal abstract void CreateNewDatabaseFromExisting();
        internal abstract void BackupAllStudentsDataTsv();
        internal abstract void BackupAllStudentsDataXml();
        internal abstract void RestoreAllStudentsDataTsv(bool MustErase);
        internal abstract void RestoreAllStudentsDataXml(bool MustErase);
        internal abstract void BackupTableTsv(string TableName);
        internal abstract void BackupTableXml(string TableName);
        internal abstract void RestoreTableTsv(string TableName, bool EraseBefore);
        internal abstract void RestoreTableXml(string TableName, bool EraseBefore);
        internal abstract bool IsTableReadable(string Table);
        internal bool ExistsTable(string Table)
        {
            return IsTableReadable(Table);
        }
        internal void DeleteTable(string Table)
        {
            string createQuery = "DROP TABLE " + Table + ";";
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = createQuery;

                cmd.ExecuteNonQuery(); //execute the command
            }
        }
        // GeneralFunctions
        internal abstract object ReadFirstRowFirstField(string Table);

        // AnnotationsManagement
        internal abstract List<StudentAnnotation> AnnotationsAboutThisStudent(Student currentStudent,
            string IdSchoolYear, bool IncludeOnlyActiveAnnotations);
        internal abstract int? UpdateAnnotationsGroup(StudentAnnotation currentAnnotation, Student currentStudent);
        internal abstract void EraseAnnotationByText(string AnnotationText, Student Student);
        internal abstract int? SaveAnnotation(StudentAnnotation Annotation, Student s);
        internal abstract StudentAnnotation GetAnnotation(int? IdAnnotation);
        internal abstract StudentAnnotation GetAnnotationFromRow(DbDataReader Row);
        internal abstract void EraseAnnotationById(int? IdAnnotation);
        internal abstract DataTable GetAnnotationsOfClass(int? IdClass,
            bool IncludeAlsoNonActive, bool IncludeJustPopUp);

        // AnswerManagement
        internal abstract StudentsAnswer GetStudentsAnswerFromRow(DbDataReader Row);
        internal abstract List<StudentsAnswer> GetAllAnswersOfAStudentToAQuestionOfThisTest(
            int? IdStudent, int? IdQuestion, int? IdTest);
        internal abstract void AddAnswerToQuestion(int? idQuestion, int? idAnswer);
        internal abstract void PurgeDatabase();
        internal abstract List<Answer> GetAllCorrectAnswersToThisQuestionOfThisTest(int? IdQuestion, int? IdTest);
        internal abstract Answer GetAnswerFromRow(DbDataReader Row);
        internal abstract int CreateAnswer(Answer currentAnswer);
        internal abstract void SaveAnswer(Answer currentAnswer);
        internal abstract List<Answer> GetAnswersOfAQuestion(int? idQuestion);

        // ClassManagement
        internal abstract void DeleteOneStudentFromClass(int? IdDeletingStudent, int? IdClass);
        internal abstract void EraseAllStudentsOfAClass(Class Class);
        internal abstract void EraseClassFromClasses(Class Class);
        internal abstract string CreateOneClassOnlyDatabase(Class Class);
        internal abstract int CreateClass(string ClassAbbreviation, string ClassDescription, string SchoolYear,
            string IdSchool);
        internal abstract int CreateClassAndStudents(string[,] StudentsData, string ClassAbbreviation,
                    string ClassDescription, string SchoolYear, string OfficialSchoolAbbreviation,
                    bool LinkPhoto);
        internal abstract List<Class> GetClassesOfYear(string School, string Year);
        internal abstract DataTable GetClassTable(int? idClass);
        internal abstract Class GetClassById(int? IdClass);
        internal abstract DataTable GetClassDataTable(string IdSchool, string IdSchoolYear, string ClassAbbreviation);
        internal abstract Class GetClass(string IdSchool, string IdSchoolYear, string ClassAbbreviation);
        internal abstract Class GetClassOfStudent(string IdSchool, string SchoolYearCode, Student Student);
        internal abstract void SaveClass(Class Class);
        internal abstract void GetClassFromRow(Class Class, DbDataReader Row);
        internal abstract List<SchoolYear> GetSchoolYearsThatHaveClasses();
        internal abstract Class GetThisClassNextYear(Class Class);

        // DemoDatabaseCreation
        internal abstract void EraseAllNotConcerningDataOfOtherClasses(DataLayer newDatabaseDl, List<Class> Classes);
        internal abstract void CreateDemoDataInDatabase(DataLayer newDatabaseDl, List<Class> Classes);
        internal abstract void RandomizeGrades(DbCommand cmd);
        internal abstract void RenameStudentsNamesAndManagePictures(Class Class, DbCommand cmd);
        internal abstract void AddLinkPhotoToStudent(int? idStudent, int? idStudentsPhoto, string schoolYear, DbCommand cmd);
        internal abstract bool isDuplicate(string lastName, string firstName, List<Student> StudentsInClass);

        // GradesManagement
        internal abstract void CreateTableGrades();
        internal abstract void CreateTableGradeTypes();
        internal abstract Grade GetGrade(int? IdGrade);
        internal abstract void SaveMacroGrade(int? IdStudent, int? IdParent,
            double Grade, double Weight, string IdSchoolYear,
            string IdSchoolSubject);
        internal abstract void GetGradeAndStudentFromIdGrade(ref Grade Grade, ref Student Student);
        internal abstract double GetDefaultWeightOfGradeType(string IdGradeType);
        internal abstract DataTable GetMicroGradesOfStudentWithMacroOpen(int? IdStudent, string IdSchoolYear,
            string IdGradeType, string IdSchoolSubject);
        internal abstract DataTable GetSubGradesOfGrade(int? IdGrade);
        internal abstract Student GetWeightedAveragesOfStudent(Student Student, string stringKey1, string stringKey2, DateTime value1, DateTime value2);
        internal abstract DataTable GetGradesOfClass(Class Class,
            string IdGradeType, string IdSchoolSubject,
            DateTime DateFrom, DateTime DateTo);
        internal abstract List<Grade> CountNonClosedMicroGrades(Class Class, GradeType GradeType);
        internal abstract Grade LastOpenGradeOfStudent(Student Student, string IdSchoolYear,
            SchoolSubject SchoolSubject, string IdGradeType);
        internal abstract void CloneGrade(DataRow Riga);
        internal abstract List<GradeType> GetListGradeTypes();
        internal abstract void DeleteValueOfGrade(int IdGrade);
        internal abstract GradeType GetGradeTypeFromRow(DbDataReader Row);
        internal abstract GradeType GetGradeType(string IdGradeType);
        internal abstract void SaveGradeValue(int? id, double? grade);
        internal abstract void EraseGrade(int? KeyGrade);
        internal abstract Grade GetGradeFromRow(DbDataReader Row);
        internal abstract DataTable GetGradesOfStudent(Student Student, string SchoolYear,
            string IdGradeType, string IdSchoolSubject, DateTime DateFrom, DateTime DateTo);
        internal abstract object GetGradesWeightsOfStudentOnOpenGrades(Student currentStudent,
            string stringKey1, string stringKey2, DateTime value1, DateTime value2);
        internal abstract DataTable GetWeightedAveragesOfClassByGradesFraction(Class Class,
            string IdGradeType, string IdSchoolSubject, DateTime DateFrom, DateTime DateTo);
        internal abstract DataTable GetGradesWeightedAveragesOfClassByAverage(Class Class, string IdGradeType,
            string IdSchoolSubject, DateTime DateFrom, DateTime DateTo);
        internal abstract List<StudentAndGrade> GetListGradesWeightedAveragesOfClassByName(Class Class, string IdGradeType,
            string IdSchoolSubject, DateTime DateFrom, DateTime DateTo);
        internal abstract DataTable GetUnfixedGrades(Student Student, string IdSchoolSubject,
            double Threshold);
        internal abstract DataTable GetMacroGradesOfStudentClosed(int? IdStudent, string IdSchoolYear,
            string IdGradeType, string IdSchoolSubject);
        internal abstract int CreateMacroGrade(ref Grade Grade, Student Student, string IdMicroGradeType);
        internal abstract int? SaveMicroGrade(Grade Grade);
        internal abstract object GetGradesWeightedAveragesOfStudent(Student currentStudent,
            string stringKey1, string stringKey2, DateTime value1, DateTime value2);
        internal abstract List<Couple> GetGradesOldestInClass(Class Class,
            GradeType GradeType, SchoolSubject SchoolSubject);
        internal abstract DataTable GetGradesWeightsOfClassOnOpenGrades(Class Class,
            string IdGradeType, string IdSchoolSubject, DateTime DateFrom, DateTime DateTo);

        // ImageManagement
        internal abstract List<Image> GetAllImagesShownToAClassDuringLessons(Class Class, SchoolSubject Subject,
            DateTime DateStart = default(DateTime), DateTime DateFinish = default(DateTime));
        internal abstract List<string> GetCaptionsOfThisImage(string FileName);
        internal abstract void EraseStudentsPhoto(int? IdStudent, string SchoolYear);
        internal abstract string GetFilePhoto(int? IdStudent, string SchoolYear);
        internal abstract void ChangeImagesPath(Class Class, DbCommand cmd);
        internal abstract void SaveImagePath(int? id, string path);
        internal abstract int? SaveDemoStudentPhotoPath(string relativePath, DbCommand cmd);
        internal abstract void RemoveImageFromLesson(Lesson Lesson, Image Image, bool AlsoEraseImageFile);
        internal abstract void SaveImage(Image Image);
        internal abstract Image FindImageWithGivenFile(string PathAndFileNameOfImage);
        internal abstract int? LinkOneImage(Image Image, Lesson Lesson);
        // LessonManagement
        internal abstract Lesson GetLessonFromRow(DbDataReader dRead);
        internal abstract int NewLesson(Lesson Lesson);
        internal abstract void SaveLesson(Lesson Lesson);
        internal abstract List<Topic> GetTopicsOfOneLessonOfClass(Class Class, Lesson Lesson);
        internal abstract DataTable GetLessonsOfClass(Class Class, Lesson Lesson);
        internal abstract List<Lesson> GetLessonsOfClass(Class Class, string IdSchoolSubject,
            bool OrderByAscendingDate);
        internal abstract Lesson GetLastLesson(Lesson CurrentLesson);
        internal abstract Lesson GetLessonInDate(Class Class, string IdSubject,
            DateTime Date);
        internal abstract void EraseLesson(int? IdLesson, bool AlsoEraseImageFiles);
        internal abstract List<Topic> GetTopicsOfLesson(int? IdLesson);
        internal abstract void SaveTopicsOfLesson(int? IdLesson, List<Topic> topicsOfTheLesson);
        internal abstract List<Image> GetLessonsImagesList(Lesson Lesson);
        /// <summary>
        /// Creates a new Image in Images and links it to the lesson
        /// If the image has an id != 0, it exists and is not created 
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="Lesson"></param>
        /// <returns></returns>
        internal abstract int? LinkOneImageToLesson(Image Image, Lesson Lesson);
        internal abstract List<Topic> GetTopicsDoneInClassInPeriod(Class Class,
            SchoolSubject Subject, DateTime? DateStart, DateTime? DateFinish);

        // LinkManagement
        internal abstract void UpdatePathStartLinkOfClass(Class currentClass, string text);
        internal abstract void AddLinkToPreviousYearPhoto(int? IdStudent, string IdPreviousSchoolYear,
            string IdNextSchoolYear);
        internal abstract int LinkOnePhoto(Student Student, Class Class, string RelativePathAndFilePhoto);
        internal abstract int? SaveStartLink(int? IdStartLink, int? IdClass, string SchoolYear,
            string StartLink, string Desc);
        internal abstract void DeleteStartLink(Nullable<int> IdStartLink);
        internal abstract List<StartLink> GetStartLinksOfClass(Class Class);

        // PeriodManagement
        internal abstract List<SchoolPeriod> GetSchoolPeriodsOfDate(DateTime Date);
        internal abstract List<SchoolPeriod> GetSchoolPeriods(string IdSchoolYear);
        internal abstract SchoolPeriod GetOneSchoolPeriodFromRow(DbDataReader Row);
        internal abstract void SaveSchoolPeriod(SchoolPeriod SchoolPeriod);
        internal abstract void CreateSchoolPeriod(SchoolPeriod SchoolPeriod);
        internal abstract void UpdateSchoolPeriod(SchoolPeriod SchoolPeriod);
        internal abstract void DeleteSchoolPeriod(string IdSchoolPeriod);
        internal abstract bool FindIfPeriodsAreAlreadyExisting(string SchoolYear);
        internal abstract bool FindIfIdIsAlreadyExisting(string IdSchoolPeriod);
        internal abstract List<SchoolPeriodType> GetSchoolPeriodTypes();
        internal abstract void CreateTableSchoolYears();


        // QuestionManagement
        internal abstract string MakeStringForFilteredQuestionsQuery(List<Tag> Tags, string IdSchoolSubject,
            string IdQuestionType, Topic QuestionsTopic, bool QueryManyTopics, bool TagsAnd);
        internal abstract List<Question> GetAllQuestionsOfATest(int? IdTest);
        internal abstract void FixQuestionInGrade(int? IdGrade);
        internal abstract void RemoveQuestionFromTest(int? IdQuestion, int? IdTest);
        internal abstract Question GetQuestionFromRow(DbDataReader Row);
        internal abstract Question GetQuestionById(int? IdQuestion);
        internal abstract void SaveQuestion(Question Question);
        internal abstract void AddQuestionToTest(SchoolGrades.BusinessObjects.SchoolTest Test, Question Question);
        internal abstract List<QuestionType> GetListQuestionTypes(bool IncludeANullObject);
        internal abstract Question CreateNewVoidQuestion();
        /// <summary>
        /// gets the questions regarding the topics taught to the class that 
        /// haven't been made to the student yet. 
        /// Includes also the questions tha do not have a topic 
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Student"></param>
        /// <param name="Subject"></param>
        /// <returns></returns>
        internal abstract List<Question> GetFilteredQuestionsNotAsked(Student Student, Class Class,
            SchoolSubject Subject, string IdQuestionType, List<Tag> Tags, Topic Topic,
            bool QueryManyTopics, bool TagsAnd, string SearchString,
            DateTime DateFrom, DateTime DateTo);
        internal abstract List<Question> GetFilteredQuestionsAskedToClass(Class Class, SchoolSubject Subject, string IdQuestionType,
            List<Tag> Tags, Topic Topic, bool QueryManyTopics, bool TagsAnd,
            string SearchString, DateTime DateFrom, DateTime DateTo);

        // StudentManagement
        internal abstract void CreateTableStudents();
        internal abstract Student CreateStudentFromStringMatrix(string[,] StudentData, int? StudentRow);
        internal abstract Student GetStudent(Student StudentToFind);
        internal abstract DataTable GetStudentsWithNoMicrogrades(Class Class, string IdGradeType, string IdSchoolSubject,
            DateTime DateFrom, DateTime DateTo);
        internal abstract List<Student> GetAllStudentsThatAnsweredToATest(SchoolTest Test, Class Class);
        internal abstract int? SaveStudent(Student Student);
        internal abstract int? CreateStudent(Student Student);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Student">The student we want to update</param>
        /// <param name="conn">Optional connection that is used if present</param>
        internal abstract int? UpdateStudent(Student Student, DbCommand cmd = null);
        // internal abstract void SaveStudentsOfList(List<Student> studentsList, DbConnection conn)
        //{
        //    foreach (Student s in studentsList)
        //    {
        //        SaveStudent(s, conn);
        //    }
        //}
        internal abstract Student GetStudent(int? IdStudent);
        internal abstract Student GetStudentFromRow(DbDataReader Row);
        internal abstract DataTable GetStudentsSameName(string LastName, string FirstName);
        internal abstract DataTable FindStudentsLike(string LastName, string FirstName);
        internal abstract void PutStudentInClass(int? IdStudent, int? IdClass);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdClass">Id of the class to be searched</param>
        /// <param name="conn">Connection already open on a database different from standard. 
        /// If not null this connection is left open</param>
        /// <returns>List of the </returns>
        internal abstract List<Student> GetStudentsOfClass(int? IdClass, DbCommand cmd);
        internal abstract List<Student> GetStudentsOfClassList(string Scuola, string Anno,
            string SiglaClasse, bool IncludeNonActiveStudents);
        internal abstract List<int> GetIdStudentsNonGraded(Class Class,
            GradeType GradeType, SchoolSubject SchoolSubject);
        internal abstract void ToggleDisabledFlagOneStudent(Student Student);
        internal abstract Nullable<int> GetStudentsPhotoId(int? idStudent, string schoolYear, DbConnection conn);
        internal abstract int? StudentHasAnswered(int? IdAnswer, int? IdTest, int? IdStudent);
        internal abstract List<Student> GetStudentsOnBirthday(Class Class, DateTime Date);
        internal abstract void SaveStudentsAnswer(Student Student, SchoolTest Test, Answer Answer,
            bool StudentsBoolAnswer, string StudentsTextAnswer);

        // SubjectManagement
        internal abstract void SaveSubjects(List<SchoolSubject> SubjectList);
        internal abstract string SaveSubject(SchoolSubject Subject);
        internal abstract SchoolSubject GetSchoolSubject(string IdSchoolSubject);
        internal abstract List<SchoolSubject> GetListSchoolSubjects(bool IncludeANullObject);
        internal abstract void EraseSchoolSubjectById(string IdSchoolSubject);

        // TableManagement
        internal abstract void GetLookupTable(string Table, ref DataSet DSet, ref DataAdapter DAdapt);
        internal abstract void SaveTableOnCsv(DataTable Table, string FileName);
        internal abstract void CreateLookupTableRow(string Table, string IdTable, DataRow Row);

        // TagManagement
        internal abstract List<Tag> GetTagsContaining(string Pattern);
        internal abstract int? CreateNewTag(Tag CurrentTag);
        internal abstract void SaveTag(Tag CurrentTag);
        internal abstract List<Tag> TagsOfAQuestion(int? IdQuestion);
        internal abstract void AddTagToQuestion(int? IdQuestion, int? IdTag);

        // TestManagement
        internal abstract SchoolGrades.BusinessObjects.SchoolTest GetTestFromRow(DbDataReader Row);
        internal abstract SchoolTest GetTest(int? IdTest);
        internal abstract List<SchoolTest> GetTests();
        internal abstract void SaveTest(SchoolTest TestToSave);

        // TopicsManagement
        /// <summary>
        /// Gets the record of the Topic from the database, 
        /// </summary>
        /// <param name="dRead"></param>
        /// <returns></returns>
        internal abstract Topic GetTopicFromRow(DbDataReader dRead);
        internal abstract int CreateNewTopic(Topic NewTopic);
        internal abstract void EraseAllTopics();
        internal abstract Topic GetTopicById(int? idTopic);
        internal abstract List<Topic> GetTopics();
        internal abstract bool IsTopicAlreadyTaught(Topic Topic);
        internal abstract List<Topic> GetTopicsDoneFromThisTopic(Class Class, Topic StartTopic,
            SchoolSubject Subject);
        internal abstract List<Topic> GetTopicsNotDoneFromThisTopic(Class Class, Topic StartTopic,
            SchoolSubject Subject);
        internal abstract List<Topic> GetAllTopicsDoneInClassAndSubject(Class Class,
            SchoolSubject Subject, DateTime DateStart = default(DateTime),
            DateTime DateFinish = default(DateTime));
        internal abstract List<Topic> GetTopicsDoneInPeriod(Class currentClass, SchoolSubject currentSubject,
            DateTime DateFrom, DateTime DateTo);
        internal abstract int GetTopicDescendantsNumber(int? LeftNode, int? RightNode);
        internal abstract void UpdateTopic(Topic t, DbConnection conn);
        internal abstract void InsertTopic(Topic t, DbConnection Conn);
        internal abstract List<Topic> GetNodesByParentFromDatabase();
        internal abstract void SaveTopicsFromScratch(List<Topic> ListTopics);

        // UserManagement
        internal abstract User GetUser(string Username);
        internal abstract List<User> GetAllUsers();
        internal abstract User GetUserFromRow(DbDataReader dRead);
        internal abstract void ChangePassword(User User);
        internal abstract void CreateUser(User User);
        internal abstract void UpdateUser(User User);

        // YearsAndPeriodsManagement
        internal abstract bool SchoolYearExists(string idSchoolYear);
        internal abstract void AddSchoolYear(SchoolYear newSchoolYear);
        internal abstract void DeleteSchoolYear(string idSchoolYear);
    }
}
