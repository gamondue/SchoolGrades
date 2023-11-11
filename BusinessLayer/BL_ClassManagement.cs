using SchoolGrades.BusinessObjects;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal List<Class> GetClassesOfYear(string IdSchool, string SchoolYear)
        {
            return dl.GetClassesOfYear(IdSchool, SchoolYear);
        }
        internal string CreateFileAllTopicsOfTheClass(Class Class, SchoolSubject Subject)
        {
            string fileContent = "";
            string tabs = "";

            // write down all the lessons descriptions 
            fileContent += "Lessons descriptions\r\n";
            List<Lesson> ll = dl.GetLessonsOfClass(Class, Subject.IdSchoolSubject, true);
            foreach (Lesson l in ll)
            {
                fileContent += $"\r\nLesson: {l.Note} \r\n";
                List<Topic> lt1 = dl.GetTopicsOfLesson(l.IdLesson);
                foreach (Topic t in lt1)
                {
                    fileContent += $"{t.Name}\r\n";
                    if (t.Desc != null && t.Desc != "")
                        fileContent += $"\t{t.Desc}\r\n";
                }
            }
            // write down all the topics selected
            fileContent += "\r\n\r\nTopics done\r\n";
            List<Topic> lt = dl.GetTopicsDoneInClassInPeriod(Class, Subject, null, null);
            Topic previous = new Topic();
            previous.Id = -2;
            string status = "s"; // start tab 
            foreach (Topic t in lt)
            {
                // put a tab in front of descending nodes 
                switch (status)
                {
                    case "s": // start tab
                        {
                            if (t.ParentNodeOld == previous.Id)
                            {
                                // is son of the previous
                                tabs += "\t";
                                status = "b"; // brothers
                            }
                            else
                                tabs = "";
                            break;
                        }
                    case "b": // brothers 
                        {
                            if (t.ParentNodeOld == previous.ParentNodeOld)
                            {
                                // another brother: do nothing
                            }
                            else if (t.ParentNodeOld == previous.Id)
                            {
                                // is son of the previous
                                tabs += "\t";
                                status = "b"; // brothers
                            }
                            else
                            {   // non brothers & non son 
                                tabs = "";
                                status = "s"; // brothers
                            }
                            break;
                        }
                    case "u":
                        {
                            break;
                        }
                }
                fileContent += tabs + t.Name;
                if (t.Desc != "")
                    fileContent += ": " + t.Desc;
                fileContent += "\r\n";
                previous = t;
            }
            return fileContent;
        }
        internal int? CreateClassAndStudents(string[,] StudentsData, string ClassAbbreviation, string ClassDescription,
            string SchoolYear, string OfficialSchoolAbbreviation, bool LinkPhoto)
        {
            return dl.CreateClassAndStudents(StudentsData, ClassAbbreviation, ClassDescription,
                SchoolYear, OfficialSchoolAbbreviation, LinkPhoto);
        }
        internal Class GetClass(string idSchool, string idSchoolYear, string ClassAbbreviation)
        {
            return dl.GetClass(idSchool, idSchoolYear, ClassAbbreviation);
        }
        internal void CopyAndLinkOnePhoto(Student NewStudent, Class NewClass, string PhotoToCopyFullName)
        {
            string ext = Path.GetExtension(PhotoToCopyFullName);
            string classFolder = NewClass.SchoolYear + NewClass.Abbreviation;
            string justFileName = NewStudent.LastName + "_" + NewStudent.FirstName + "_" + NewClass.Abbreviation + NewClass.SchoolYear + ext;
            string relativePathFileName = Path.Combine(classFolder, justFileName);
            string newPhotoFullName = Path.Combine(Commons.PathImages, relativePathFileName);
            if (!Directory.Exists(Path.Combine(Commons.PathImages, classFolder)))
            {
                Directory.CreateDirectory(Path.Combine(Commons.PathImages, classFolder));
            }
            File.Copy(PhotoToCopyFullName, newPhotoFullName, true);
            dl.LinkOnePhoto(NewStudent, NewClass, relativePathFileName);
        }
        internal int CreateClass(string ClassAbbreviation, string ClassDescription,
            string SchoolYear, string IdSchool)
        {
            return dl.CreateClass(ClassAbbreviation, ClassDescription, SchoolYear, IdSchool);
        }
        internal void DeleteOneStudentFromClass(int idDeletingStudent, int? idClass)
        {
            dl.DeleteOneStudentFromClass(idDeletingStudent, idClass);
        }
        internal void EraseAllStudentsOfAClass(Class CurrentClass)
        {
            dl.EraseAllStudentsOfAClass(CurrentClass);
        }
        internal void EraseClassFromClasses(Class CurrentClass)
        {
            dl.EraseClassFromClasses(CurrentClass);
        }
        // !!!! TODO: refactor to avoid using ADO objects outside BusinessLayer !!!!
        internal DataTable GetClassTable(int? IdClass)
        {
            return dl.GetClassTable(IdClass);
        }
        internal void SaveClass(Class Class)
        {
            dl.SaveClass(Class);
        }
        internal Class GetClassById(int? IdClass)
        {
            if (IdClass != null)
                return dl.GetClassById(IdClass);
            else
                return null;
        }
        internal List<SchoolYear> GetSchoolYearsThatHaveClasses()
        {
            List<SchoolYear> ly = dl.GetSchoolYearsThatHaveClasses();
            return ly;
        }
        internal void GenerateNewClassFromPrevious(List<Student> StudentsOfNewClass, string ClassAbbreviation,
            string ClassDescription, SchoolYear SchoolYear, string IdPreviousSchoolYear, string OfficialSchoolAbbreviation)
        {
            // add the new school year to the database, if it doesn't already exist 
            Commons.bl.AddSchoolYearIfNotExists(SchoolYear);
            // create the new class
            int classCode = Commons.bl.CreateClass(ClassAbbreviation, ClassDescription,
                SchoolYear.IdSchoolYear, OfficialSchoolAbbreviation);
            int studentDone = 1;
            foreach (Student s in StudentsOfNewClass)
            {
                s.RegisterNumber = studentDone.ToString();
                Commons.bl.PutStudentInClass(s.IdStudent, classCode);
                Commons.bl.AddLinkToOldPhoto(s.IdStudent, IdPreviousSchoolYear, SchoolYear.IdSchoolYear);
                Commons.bl.UpdateStudent(s);
                studentDone++;
            }
        }
        internal Class GetThisClassNextYear(Class Class)
        {
            return dl.GetThisClassNextYear(Class);
        }
    }
}
