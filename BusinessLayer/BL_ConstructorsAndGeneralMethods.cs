using SchoolGrades.BusinessObjects;
using System.IO;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        /// <summary>
        /// Business Layer: implements the business rules of the program indipendently from 
        /// the User's Interface
        /// Porting code from DbAndBusinness class and classes within BusinessLayer is work in progress 
        /// </summary>
        
        // create the next after the program that is using this has read the configuration file 
        DataLayer dl; // must be instantiated after reading config file! 

        // internal string NameAndPathDatabase { get; }

        /// <summary>
        /// Incapsulates the business rules for users' management
        /// part of the class that contains the constructors and the general methods
        /// </summary>
        ///  
        internal BusinessLayer() 
        {
            this.dl = Commons.dl;
        }
        internal DataLayer CreateNewDatabase(string NewDatabasePathName)
        {
            if (File.Exists(NewDatabasePathName))
                File.Delete(NewDatabasePathName);
            File.Copy(Commons.PathAndFileDatabase, NewDatabasePathName);

            // local instance of a DataLayer to operate on a second database 
            DataLayer newDatabaseDl = new DataLayer(NewDatabasePathName);

            newDatabaseDl.CreateNewDatabase();
            return newDatabaseDl;
        }
        internal School GetSchool(string OfficialSchoolAbbreviation)
        {
            return dl.GetSchool(OfficialSchoolAbbreviation);
        }
        internal void CompactDatabase()
        {
            dl.CompactDatabase();
        }
        internal string CreateOneClassOnlyDatabase(Class currentClass)
        {
            return dl.CreateOneClassOnlyDatabase(currentClass);
        }
        internal void CreateDemoDatabase(string NewDatabasePathAndName, 
            Class currentClass, Class otherClass)
        {
            // local instance of a DataLayer to operate on a second database 
            DataLayer newDatabaseDl = new DataLayer(NewDatabasePathAndName);
            File.Copy(Commons.PathAndFileDatabase, NewDatabasePathAndName);

            // gets this same class in next year (if any..)
            Class Class3 = dl.GetThisClassNextYear(currentClass);
            Class Class4 = dl.GetThisClassNextYear(otherClass);
            // erase all the data of other classes
            dl.EraseAllNotPertinentDataOfOtherClasses(newDatabaseDl, currentClass, otherClass,
                Class3, Class4);
            dl.CreateDataInDemoDatabase(newDatabaseDl, currentClass, otherClass,
                Class3, Class4);
        }
        internal void PurgeDatabase()
        {
            dl.PurgeDatabase(); 
        }
    }
}
