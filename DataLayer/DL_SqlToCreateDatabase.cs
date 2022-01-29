using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;

namespace SchoolGrades
{
	internal partial class DataLayer
	{
		string creationScript = @"
CREATE TABLE 'Answers' (
	'idAnswer'	INT NOT NULL,
	'idQuestion'	INT NOT NULL,
	'showingOrder'	INT,
	'text'	VARCHAR(255),
	'errorCost'	INT,
	'isCorrect'	TINYINT,
	'isOpenAnswer'	TINYINT,
	'isMutex'	TINYINT,
	PRIMARY KEY('idAnswer')
);

CREATE TABLE 'Answers_Questions' (
  'idAnswer' INT NOT NULL,
  'idQuestion' INT NOT NULL,
  PRIMARY KEY('idAnswer', 'idQuestion
);

CREATE TABLE 'Classes' (
	'idClass'	INT NOT NULL,
	'idSchoolYear'	VARCHAR( 4 ) NOT NULL,
	'idSchool'	VARCHAR( 15 ) NOT NULL,
	'abbreviation'	VARCHAR( 8 ),
	'desc'	VARCHAR( 255 ),
	'uriWebApp'	VARCHAR( 255 ),
	'pathRestrictedApplication'	VARCHAR( 255 ),
	PRIMARY KEY('idClass')
); 

CREATE TABLE 'Classes_SchoolSubjects' (
  'idClass' VARCHAR(8) NOT NULL,
  'idSchoolSubject' VARCHAR(6) NOT NULL,
  PRIMARY KEY('idClass', 'idSchoolSubject')
);

CREATE TABLE 'Classes_StartLinks' (
	'idStartLink'	INT NOT NULL,
	'idClass'	INT NOT NULL,
	'startLink'	VARCHAR(255),
	'desc'	VARCHAR(45),
	PRIMARY KEY('idStartLink')
);

CREATE TABLE 'Classes_Students' (
  'idClass' INT NOT NULL,
  'idStudent' INT NOT NULL,
  'registerNumber' INT NULL,
  PRIMARY KEY('idClass', 'idStudent')
);

CREATE TABLE 'Classes_Tests' (
	'idClass'	INT NOT NULL,
	'idTest'	INT NOT NULL,
	'timeAllowed'	INT,
	'dateGiven'	DATE,
	'dateGraded'	DATE,
	PRIMARY KEY('idClass','idTest')
);

CREATE TABLE 'Flags' (
	'areLeftRightConsistent'	INT
);

CREATE TABLE 'GradeCategories' (
  'idGradeCategory' VARCHAR(5) NOT NULL,
  'name' VARCHAR(20) NOT NULL,
  'desc' VARCHAR(255) NULL,
  PRIMARY KEY('idGradeCategory')
);

CREATE TABLE 'GradeTypes' (
  'idGradeType' VARCHAR(5) NOT NULL,
  'idGradeCategory' VARCHAR(5) NULL,
  'name' VARCHAR(20) NOT NULL,
  'desc' VARCHAR(255) NULL,
  'defaultWeight' FLOAT NULL,
  'programsCode' INT NULL,
  'idGradeTypeParent' VARCHAR(5) NULL,
  PRIMARY KEY('idGradeType')
);

CREATE TABLE 'Grades' (
	'idGrade'	INT NOT NULL,
	'idStudent'	INT NOT NULL,
	'value'	FLOAT,
	'idSchoolSubject'	VARCHAR(6),
	'weight'	FLOAT,
	'cncFactor'	FLOAT,
	'idSchoolYear'	VARCHAR(4) NOT NULL,
	'timestamp'	DATETIME,
	'idGradeType'	VARCHAR(5) NOT NULL,
	'idGradeParent'	INT,
	'idQuestion'	INT,
	'isFixed'	TINYINT,
	PRIMARY KEY('idGrade')
);

CREATE TABLE 'Images' (
	'IdImage'	INT NOT NULL,
	'imagePath'	VARCHAR( 255 ),
	'caption'	VARCHAR( 45 ),
	PRIMARY KEY('IdImage')
);

CREATE TABLE 'Lessons' (
	'idLesson'	INT NOT NULL,
	'date'	DATETIME,
	'idClass'	INT NOT NULL,
	'idSchoolSubject'	VARCHAR(6) NOT NULL,
	'note'	VARCHAR(45),
	'idSchoolYear'	VARCHAR(4),
	PRIMARY KEY('idLesson')
);

CREATE TABLE 'Lessons_Images' (
	'idLesson'	INT,
	'idImage'	INT
);

CREATE TABLE 'Lessons_Topics' (
	'idLesson'	INT NOT NULL,
	'idTopic'	INT NOT NULL,
	'insertionOrder'	INT,
	PRIMARY KEY('idLesson','idTopic')
);

CREATE TABLE 'QuestionTypes' (
  'idQuestionType' VARCHAR(5) NOT NULL,
  'name' VARCHAR(20) NOT NULL,
  'desc' VARCHAR(255) NULL,
  PRIMARY KEY('idQuestionType')
);

CREATE TABLE 'Questions' (
	'idQuestion'	INT NOT NULL,
	'text'	VARCHAR( 255 ),
	'weight'	FLOAT,
	'duration'	INT,
	'difficulty'	INT,
	'idImage'	INT,
	'image'	VARCHAR( 90 ),
	'idQuestionType'	VARCHAR( 5 ),
	'idTopic'	INT,
	'idSubject'	INT,
	'idSchoolSubject'	VARCHAR( 6 ),
	'nRows'	INT,
	'isParamount'	INT,
	PRIMARY KEY('idQuestion')
); 

CREATE TABLE 'Questions_Tags' (
  'idQuestion' INT NOT NULL,
  'idTag' INT NOT NULL,
  PRIMARY KEY('idQuestion', 'idTag')
);

CREATE TABLE 'ReminderTypes' (
  'idReminderType' VARCHAR(5) NOT NULL,
  'name' VARCHAR(20) NOT NULL,
  'desc' VARCHAR(255) NULL,
  PRIMARY KEY('idReminderType')
);

CREATE TABLE 'Reminders' (
  'idReminder' INT NOT NULL,
  'idReminderType' VARCHAR(5) NOT NULL,
  'description' VARCHAR(128) NULL,
  'idForeignKey' INT NOT NULL,
  PRIMARY KEY('idReminder')
); 

CREATE TABLE 'SchoolPeriodTypes' (
	'idSchoolPeriodType'	VARCHAR( 3 ),
	'desc'	varchar(45),
	PRIMARY KEY('idSchoolPeriodType')
); 

CREATE TABLE 'SchoolPeriods' (
	'idSchoolPeriod'	VARCHAR( 8 ) NOT NULL,
	'idSchoolPeriodType'	VARCHAR( 3 ),
	'dateStart'	DATE,
	'dateFinish'	DATE,
	'name'	VARCHAR ( 20 ) NOT NULL,
	'desc'	VARCHAR ( 255 ),
	'idSchoolYear'	VARCHAR ( 4 ) NOT NULL,
	PRIMARY KEY('idSchoolPeriod')
);

CREATE TABLE 'SchoolSubjects' (
	'idSchoolSubject'	VARCHAR(6) NOT NULL,
	'name'	VARCHAR(20) NOT NULL,
	'desc'	VARCHAR(255),
	'color'	INT,
	'orderOfVisualization'	INT,
	PRIMARY KEY('idSchoolSubject')
); 

CREATE TABLE 'SchoolYears' (
  'idSchoolYear' VARCHAR(4) NOT NULL,
  'shortDesc' VARCHAR(10) NULL,
  'notes' VARCHAR(255) NULL,
  PRIMARY KEY ('idSchoolYear')
);

CREATE TABLE 'Schools' (
  'idSchool' VARCHAR(15) NOT NULL,
  'name' VARCHAR(80) NULL,
  'desc' VARCHAR(255) NULL,
  'officialSchoolAbbreviation' VARCHAR(10) NULL,
  PRIMARY KEY ('idSchool')
); 

CREATE TABLE 'Students' (
	'idStudent'	INT NOT NULL,
	'lastName'	VARCHAR(45),
	'firstName'	VARCHAR(45),
	'residence'	VARCHAR(45),
	'origin'	VARCHAR(45),
	'email'	VARCHAR(45),
	'drawable'	int,
	'birthDate'	DATE,
	'birthPlace'	VARCHAR(45),
	'VFCounter'	INTEGER,
	'disabled'	int,
	'hasSpecialNeeds'	INTEGER,
	PRIMARY KEY('idStudent')
);

CREATE TABLE 'StudentsAnnotations' (
	'idAnnotation'	INT NOT NULL,
	'idStudent'	INTEGER,
	'annotation'	VARCHAR(256),
	'idSchoolYear'	VARCHAR(4),
	'instantTaken'	DATETIME,
	'instantClosed'	DATETIME,
	'isActive'	INTEGER,
	'isPopUp'	INTEGER,
	PRIMARY KEY('idAnnotation')
); 

CREATE TABLE 'StudentsAnswers' (
	'idStudentsAnswer'	INT NOT NULL,
	'idStudent'	INT,
	'idAnswer'	INT,
	'studentsBoolAnswer'	TINYINT,
	'studentsTextAnswer'	VARCHAR(255),
	'idTest'	INTEGER,
	PRIMARY KEY('idStudentsAnswer')
); 

CREATE TABLE 'StudentsPhotos' (
  'idStudentsPhoto' INT NOT NULL,
  'photoPath' VARCHAR(255) NULL,
  PRIMARY KEY ('idStudentsPhoto')
);

CREATE TABLE 'StudentsPhotos_Students' (
  'idStudentsPhoto' INT NOT NULL,
  'idStudent' INT NOT NULL,
  'idSchoolYear' VARCHAR(4) NOT NULL,
  PRIMARY KEY ('idStudentsPhoto', 'idStudent', 'idSchoolYear')
);

CREATE TABLE 'StudentsQuestions' (
  'idStudentsQuestion' INT NOT NULL,
  'idStudent' INT NOT NULL,
  'idQuestion' INT NULL,
  'grade' FLOAT NULL,
  'timestamp' DATETIME NULL,
  PRIMARY KEY ('idStudentsQuestion')
); 

CREATE TABLE 'StudentsTests' (
  'idStudentsTest' INT NOT NULL,
  'idStudent' INT NOT NULL,
  'idTest' INT NOT NULL,
  'grade' FLOAT NULL,
  PRIMARY KEY ('idStudentsTest')
); 

CREATE TABLE 'StudentsTests_StudentsPhotos' (
  'idStudentsTest' INT NOT NULL,
  'idStudentsPhoto' INT NOT NULL,
  PRIMARY KEY ('idStudentsTest', 'idStudentsPhoto')
); 

CREATE TABLE 'Students_Annotations' (
	'idStudent'	INTEGER,
	'idAnnotation'	INTEGER
);

CREATE TABLE 'Students_GradeTypes' (
  'idStudent' INT NOT NULL,
  'idGradeType' INT NOT NULL,
  PRIMARY KEY ('idStudent', 'idGradeType')
); 

CREATE TABLE 'Subjects' (
	'idSubject'	INT NOT NULL,
	'name'	VARCHAR(20) NOT NULL,
	'desc'	VARCHAR(255),
	'leftNode'	INT,
	'rightNode'	INT,
	PRIMARY KEY('idSubject')
); 

CREATE TABLE 'Tags' (
  'idTag' INT NOT NULL,
  'tag' VARCHAR(20) NOT NULL,
  'desc' VARCHAR(255) NULL,
  PRIMARY KEY ('idTag')
); 

CREATE TABLE 'TestTypes' (
  'idTestType' VARCHAR(6) NOT NULL,
  'name' VARCHAR(20) NOT NULL,
  'desc' VARCHAR(255) NULL,
  PRIMARY KEY ('idTestType')
);

CREATE TABLE 'Tests' (
	'idTest'	INT NOT NULL,
	'name'	VARCHAR(20),
	'desc'	VARCHAR(255),
	'idSubject'	INT,
	'idSchoolSubject'	VARCHAR(6),
	'idTopic'	INT,
	'idTestType'	VARCHAR(6),
	PRIMARY KEY('idTest')
); 

CREATE TABLE 'Tests_Questions' (
	'idTest'	INT NOT NULL,
	'idQuestion'	INT NOT NULL,
	'weight'	REAL,
	PRIMARY KEY('idTest','idQuestion')
); 

CREATE TABLE 'Tests_Tags' (
  'idTest' INT NOT NULL,
  'idTag' INT NOT NULL,
  PRIMARY KEY ('idTest', 'idTag')
); 

CREATE TABLE 'Topics' (
	'idTopic'	INT NOT NULL,
	'name'	VARCHAR(20) NOT NULL,
	'desc'	VARCHAR(255),
	'leftNode'	INT,
	'rightNode'	INT,
	'parentNode'	INT,
	'childNumber'	INT,
	PRIMARY KEY('idTopic')
); 

CREATE TABLE 'Users' (
	'username'	VARCHAR(16) NOT NULL,
	'description'	VARCHAR(64),
	'lastName'	VARCHAR(45),
	'firstName'	VARCHAR(45),
	'email'	VARCHAR(255),
	'password'	VARCHAR(32) NOT NULL,
	'lastChange'	TIMESTAMP,
	'lastPasswordChange'	TIMESTAMP,
	'creationTime'	TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	'salt'	VARCHAR(32),
	'idUserCategory'	INT,
	'isEnabled'	TINYINT,
	PRIMARY KEY('username')
); 

CREATE TABLE 'UsersCategories' (
	'idUserCategory'	INT NOT NULL,
	'name'	VARCHAR(20) NOT NULL,
	'desc'	VARCHAR(255),
	PRIMARY KEY('idUserCategory')
);";

		private void CreateNewDatabase(string dbName)
		{
			// making new, means erasing existent! 
			if (File.Exists(dbName))
				File.Delete(dbName);

			// when the file does not exist 
			// Microsoft.Data.Sqlite creates the file at first connection
			DbConnection c = Connect();
			c.Close();
			c.Dispose();

			try
			{
				using (DbConnection conn = Connect())
				{
					DbCommand cmd = conn.CreateCommand();

					cmd.CommandText = creationScript;
					cmd.ExecuteNonQuery();
					conn.Close(); 
					cmd.Dispose();
				}
				// !!!! TODO fill the tables of enumerations
			}
			catch (Exception ex)
			{
				//Common.LogOfProgram.Error("Sqlite_DataAndGeneral | CreateNewDatabase", ex);
			}
		}

	}
}
