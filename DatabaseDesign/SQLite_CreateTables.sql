--
-- File generated with SQLiteStudio v3.4.17 on gio dic 18 15:15:07 2025
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Answers
DROP TABLE IF EXISTS Answers;
CREATE TABLE "Answers" (
	"idAnswer"	INT NOT NULL,
	"idQuestion"	INT NOT NULL,
	"showingOrder"	INT,
	"text"	VARCHAR(255),
	"errorCost"	INT,
	"isCorrect"	TINYINT,
	"isOpenAnswer"	TINYINT,
	"isMutex"	TINYINT,
	PRIMARY KEY("idAnswer")
);

-- Table: Answers_Questions
DROP TABLE IF EXISTS Answers_Questions;
CREATE TABLE `Answers_Questions` (
  `idAnswer` INT NOT NULL,
  `idQuestion` INT NOT NULL,
  PRIMARY KEY (`idAnswer`, `idQuestion`));

-- Table: Classes
DROP TABLE IF EXISTS Classes;
CREATE TABLE "Classes" (
	`idClass`	INT NOT NULL,
	`idSchoolYear`	VARCHAR ( 4 ) NOT NULL,
	`idSchool`	VARCHAR ( 15 ) NOT NULL,
	`abbreviation`	VARCHAR ( 8 ),
	`desc`	VARCHAR ( 255 ),
	`uriWebApp`	VARCHAR ( 255 ),
	`pathRestrictedApplication`	VARCHAR ( 255 ),
	PRIMARY KEY(`idClass`)
);

-- Table: Classes_SchoolSubjects
DROP TABLE IF EXISTS Classes_SchoolSubjects;
CREATE TABLE `Classes_SchoolSubjects` (
  `idClass` VARCHAR(8) NOT NULL,
  `idSchoolSubject` VARCHAR(6) NOT NULL,
  PRIMARY KEY (`idClass`, `idSchoolSubject`));

-- Table: Classes_StartLinks
DROP TABLE IF EXISTS Classes_StartLinks;
CREATE TABLE `Classes_StartLinks` (
	`idStartLink`	INT NOT NULL,
	`idClass`	INT NOT NULL,
	`startLink`	VARCHAR(255),
	`desc`	VARCHAR(45),
	PRIMARY KEY(`idStartLink`)
);

-- Table: Classes_Students
DROP TABLE IF EXISTS Classes_Students;
CREATE TABLE Classes_Students (idClass INT NOT NULL, idStudent INT NOT NULL, registerNumber INT, disabled INT, PRIMARY KEY (idClass, idStudent));

-- Table: Classes_Tests
DROP TABLE IF EXISTS Classes_Tests;
CREATE TABLE "Classes_Tests" (
	"idClass"	INT NOT NULL,
	"idTest"	INT NOT NULL,
	"timeAllowed"	INT,
	"dateGiven"	DATE,
	"dateGraded"	DATE,
	PRIMARY KEY("idClass","idTest")
);

-- Table: Flags
DROP TABLE IF EXISTS Flags;
CREATE TABLE "Flags" (
	"areLeftRightConsistent"	INT
);

-- Table: GradeCategories
DROP TABLE IF EXISTS GradeCategories;
CREATE TABLE `GradeCategories` (
  `idGradeCategory` VARCHAR(5) NOT NULL,
  `name` VARCHAR(20) NOT NULL,
  `desc` VARCHAR(255) NULL,
  PRIMARY KEY (`idGradeCategory`));

-- Table: Grades
DROP TABLE IF EXISTS Grades;
CREATE TABLE "Grades" (
	"idGrade"	INT NOT NULL,
	"idStudent"	INT NOT NULL,
	"value"	FLOAT,
	"idSchoolSubject"	VARCHAR(6),
	"weight"	FLOAT,
	"cncFactor"	FLOAT,
	"idSchoolYear"	VARCHAR(4) NOT NULL,
	"timestamp"	DATETIME,
	"idGradeType"	VARCHAR(5) NOT NULL,
	"idGradeParent"	INT,
	"idQuestion"	INT,
	"isFixed"	TINYINT,
	PRIMARY KEY("idGrade")
);

-- Table: GradeTypes
DROP TABLE IF EXISTS GradeTypes;
CREATE TABLE `GradeTypes` (
  `idGradeType` VARCHAR(5) NOT NULL,
  `idGradeCategory` VARCHAR(5) NULL,
  `name` VARCHAR(20) NOT NULL,
  `desc` VARCHAR(255) NULL,
  `defaultWeight` FLOAT NULL,
  `programsCode` INT NULL,
  `idGradeTypeParent` VARCHAR(5) NULL,
  PRIMARY KEY (`idGradeType`));

-- Table: Images
DROP TABLE IF EXISTS Images;
CREATE TABLE "Images" (
	`IdImage`	INT NOT NULL,
	`imagePath`	VARCHAR ( 255 ),
	`caption`	VARCHAR ( 45 ),
	PRIMARY KEY(`IdImage`)
);

-- Table: Lessons
DROP TABLE IF EXISTS Lessons;
CREATE TABLE "Lessons" (
	"idLesson"	INT NOT NULL,
	"date"	DATETIME,
	"idClass"	INT NOT NULL,
	"idSchoolSubject"	VARCHAR(6) NOT NULL,
	"note"	VARCHAR(45),
	"idSchoolYear"	VARCHAR(4),
	PRIMARY KEY("idLesson")
);

-- Table: Lessons_Images
DROP TABLE IF EXISTS Lessons_Images;
CREATE TABLE `Lessons_Images` (
	`idLesson`	INT,
	`idImage`	INT
);

-- Table: Lessons_Topics
DROP TABLE IF EXISTS Lessons_Topics;
CREATE TABLE "Lessons_Topics" (
	"idLesson"	INT NOT NULL,
	"idTopic"	INT NOT NULL,
	"insertionOrder"	INT,
	PRIMARY KEY("idLesson","idTopic")
);

-- Table: Questions
DROP TABLE IF EXISTS Questions;
CREATE TABLE "Questions" (
	`idQuestion`	INT NOT NULL,
	`text`	VARCHAR ( 255 ),
	`weight`	FLOAT,
	`duration`	INT,
	`difficulty`	INT,
	`idImage`	INT,
	`image`	VARCHAR ( 90 ),
	`idQuestionType`	VARCHAR ( 5 ),
	`idTopic`	INT,
	`idSubject`	INT,
	`idSchoolSubject`	VARCHAR ( 6 ),
	`nRows`	INT,
	`isParamount`	INT,
	PRIMARY KEY(`idQuestion`)
);

-- Table: Questions_Tags
DROP TABLE IF EXISTS Questions_Tags;
CREATE TABLE `Questions_Tags` (
  `idQuestion` INT NOT NULL,
  `idTag` INT NOT NULL,
  PRIMARY KEY (`idQuestion`, `idTag`));

-- Table: QuestionTypes
DROP TABLE IF EXISTS QuestionTypes;
CREATE TABLE `QuestionTypes` (
  `idQuestionType` VARCHAR(5) NOT NULL,
  `name` VARCHAR(20) NOT NULL,
  `desc` VARCHAR(255) NULL,
  PRIMARY KEY (`idQuestionType`));

-- Table: Reminders
DROP TABLE IF EXISTS Reminders;
CREATE TABLE `Reminders` (
  `idReminder` INT NOT NULL,
  `idReminderType` VARCHAR(5) NOT NULL,
  `description` VARCHAR(128) NULL,
  `idForeignKey` INT NOT NULL,
  PRIMARY KEY (`idReminder`)
  );

-- Table: ReminderTypes
DROP TABLE IF EXISTS ReminderTypes;
CREATE TABLE `ReminderTypes` (
  `idReminderType` VARCHAR(5) NOT NULL, 
  `name` VARCHAR(20) NOT NULL,
  `desc` VARCHAR(255) NULL,
  PRIMARY KEY (`idReminderType`)
);

-- Table: SchoolPeriods
DROP TABLE IF EXISTS SchoolPeriods;
CREATE TABLE "SchoolPeriods" (
	`idSchoolPeriod`	VARCHAR ( 8 ) NOT NULL,
	`idSchoolPeriodType`	VARCHAR ( 3 ),
	`dateStart`	DATE,
	`dateFinish`	DATE,
	`name`	VARCHAR ( 20 ) NOT NULL,
	`desc`	VARCHAR ( 255 ),
	`idSchoolYear`	VARCHAR ( 4 ) NOT NULL,
	PRIMARY KEY(`idSchoolPeriod`)
);

-- Table: SchoolPeriodTypes
DROP TABLE IF EXISTS SchoolPeriodTypes;
CREATE TABLE "SchoolPeriodTypes" (
	`idSchoolPeriodType`	VARCHAR ( 3 ),
	`desc`	varchar(45),
	PRIMARY KEY(`idSchoolPeriodType`)
);

-- Table: Schools
DROP TABLE IF EXISTS Schools;
CREATE TABLE `Schools` (
  `idSchool` VARCHAR(15) NOT NULL,
  `name` VARCHAR(80) NULL,
  `desc` VARCHAR(255) NULL,
  `officialSchoolAbbreviation` VARCHAR(10) NULL,
  PRIMARY KEY (`idSchool`));

-- Table: SchoolSubjects
DROP TABLE IF EXISTS SchoolSubjects;
CREATE TABLE "SchoolSubjects" (
	"idSchoolSubject"	VARCHAR(6) NOT NULL,
	"name"	VARCHAR(20) NOT NULL,
	"desc"	VARCHAR(255),
	"color"	INT,
	"orderOfVisualization"	INT,
	PRIMARY KEY("idSchoolSubject")
);

-- Table: SchoolYears
DROP TABLE IF EXISTS SchoolYears;
CREATE TABLE `SchoolYears` (
  `idSchoolYear` VARCHAR(4) NOT NULL,
  `shortDesc` VARCHAR(10) NULL,
  `notes` VARCHAR(255) NULL,
  PRIMARY KEY (`idSchoolYear`));

-- Table: Students
DROP TABLE IF EXISTS Students;
CREATE TABLE Students (idStudent INT NOT NULL, lastName VARCHAR (45), firstName VARCHAR (45), city VARCHAR (45), origin VARCHAR (45), email VARCHAR (45), birthDate DATE, birthPlace VARCHAR (45), telephone VARCHAR (64), mobileTelephone VARCHAR (64), gender TEXT, streetAddress VARCHAR (256), zipCode VARCHAR (15), county VARCHAR (10), state VARCHAR (10), hasSpecialNeeds INTEGER, eligible int, revengeFactorCounter INTEGER, lastPhotoPath TEXT, PRIMARY KEY (idStudent));

-- Table: Students_GradeTypes
DROP TABLE IF EXISTS Students_GradeTypes;
CREATE TABLE `Students_GradeTypes` (
  `idStudent` INT NOT NULL,
  `idGradeType` INT NOT NULL,
  PRIMARY KEY (`idStudent`, `idGradeType`));

-- Table: StudentsAnnotations
DROP TABLE IF EXISTS StudentsAnnotations;
CREATE TABLE "StudentsAnnotations" (
	"idAnnotation"	INT NOT NULL,
	"idStudent"	INTEGER,
	"annotation"	VARCHAR(256),
	"idSchoolYear"	VARCHAR(4),
	"instantTaken"	DATETIME,
	"instantClosed"	DATETIME,
	"isActive"	INTEGER,
	"isPopUp"	INTEGER,
	PRIMARY KEY("idAnnotation")
);

-- Table: StudentsAnswers
DROP TABLE IF EXISTS StudentsAnswers;
CREATE TABLE "StudentsAnswers" (
	"idStudentsAnswer"	INT NOT NULL,
	"idStudent"	INT,
	"idAnswer"	INT,
	"studentsBoolAnswer"	TINYINT,
	"studentsTextAnswer"	VARCHAR(255),
	"idTest"	INTEGER,
	PRIMARY KEY("idStudentsAnswer")
);

-- Table: StudentsPhotos
DROP TABLE IF EXISTS StudentsPhotos;
CREATE TABLE `StudentsPhotos` (
  `idStudentsPhoto` INT NOT NULL,
  `photoPath` VARCHAR(255) NULL,
  PRIMARY KEY (`idStudentsPhoto`));

-- Table: StudentsPhotos_Students
DROP TABLE IF EXISTS StudentsPhotos_Students;
CREATE TABLE `StudentsPhotos_Students` (
  `idStudentsPhoto` INT NOT NULL,
  `idStudent` INT NOT NULL,
  `idSchoolYear` VARCHAR(4) NOT NULL,
  PRIMARY KEY (`idStudentsPhoto`, `idStudent`, `idSchoolYear`));

-- Table: StudentsQuestions
DROP TABLE IF EXISTS StudentsQuestions;
CREATE TABLE `StudentsQuestions` (
  `idStudentsQuestion` INT NOT NULL,
  `idStudent` INT NOT NULL,
  `idQuestion` INT NULL,
  `grade` FLOAT NULL,
  `timestamp` DATETIME NULL,
  PRIMARY KEY (`idStudentsQuestion`));

-- Table: StudentsTests
DROP TABLE IF EXISTS StudentsTests;
CREATE TABLE `StudentsTests` (
  `idStudentsTest` INT NOT NULL,
  `idStudent` INT NOT NULL,
  `idTest` INT NOT NULL,
  `grade` FLOAT NULL,
  PRIMARY KEY (`idStudentsTest`));

-- Table: StudentsTests_StudentsPhotos
DROP TABLE IF EXISTS StudentsTests_StudentsPhotos;
CREATE TABLE `StudentsTests_StudentsPhotos` (
  `idStudentsTest` INT NOT NULL,
  `idStudentsPhoto` INT NOT NULL,
  PRIMARY KEY (`idStudentsTest`, `idStudentsPhoto`));

-- Table: Subjects
DROP TABLE IF EXISTS Subjects;
CREATE TABLE "Subjects" (
	"idSubject"	INT NOT NULL,
	"name"	VARCHAR(20) NOT NULL,
	"desc"	VARCHAR(255),
	"leftNode"	INT,
	"rightNode"	INT,
	PRIMARY KEY("idSubject")
);

-- Table: Tags
DROP TABLE IF EXISTS Tags;
CREATE TABLE `Tags` (
  `idTag` INT NOT NULL,
  `tag` VARCHAR(20) NOT NULL,
  `desc` VARCHAR(255) NULL,
  PRIMARY KEY (`idTag`));

-- Table: Tests
DROP TABLE IF EXISTS Tests;
CREATE TABLE "Tests" (
	"idTest"	INT NOT NULL,
	"name"	VARCHAR(20),
	"desc"	VARCHAR(255),
	"idSubject"	INT,
	"idSchoolSubject"	VARCHAR(6),
	"idTopic"	INT,
	"idTestType"	VARCHAR(6),
	PRIMARY KEY("idTest")
);

-- Table: Tests_Questions
DROP TABLE IF EXISTS Tests_Questions;
CREATE TABLE "Tests_Questions" (
	"idTest"	INT NOT NULL,
	"idQuestion"	INT NOT NULL,
	"weight"	REAL,
	PRIMARY KEY("idTest","idQuestion")
);

-- Table: Tests_Tags
DROP TABLE IF EXISTS Tests_Tags;
CREATE TABLE `Tests_Tags` (
  `idTest` INT NOT NULL,
  `idTag` INT NOT NULL,
  PRIMARY KEY (`idTest`, `idTag`));

-- Table: TestTypes
DROP TABLE IF EXISTS TestTypes;
CREATE TABLE `TestTypes` (
  `idTestType` VARCHAR(6) NOT NULL,
  `name` VARCHAR(20) NOT NULL,
  `desc` VARCHAR(255) NULL,
  PRIMARY KEY (`idTestType`));

-- Table: Topics
DROP TABLE IF EXISTS Topics;
CREATE TABLE "Topics" (
	"idTopic"	INT NOT NULL,
	"name"	VARCHAR(20) NOT NULL,
	"desc"	VARCHAR(255),
	"leftNode"	INT,
	"rightNode"	INT,
	"parentNode"	INT,
	"childNumber"	INT,
	PRIMARY KEY("idTopic")
);

-- Table: Users
DROP TABLE IF EXISTS Users;
CREATE TABLE "Users" (
	"username"	VARCHAR(16) NOT NULL,
	"description"	VARCHAR(64),
	"lastName"	VARCHAR(45),
	"firstName"	VARCHAR(45),
	"email"	VARCHAR(255),
	"password"	VARCHAR(32) NOT NULL,
	"lastChange"	TIMESTAMP,
	"lastPasswordChange"	TIMESTAMP,
	"creationTime"	TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	"salt"	VARCHAR(32),
	"idUserCategory"	INT,
	"isEnabled"	TINYINT,
	PRIMARY KEY("username")
);

-- Table: UsersCategories
DROP TABLE IF EXISTS UsersCategories;
CREATE TABLE "UsersCategories" (
	"idUserCategory"	INT NOT NULL,
	"name"	VARCHAR(20) NOT NULL,
	"desc"	VARCHAR(255),
	PRIMARY KEY("idUserCategory")
);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
