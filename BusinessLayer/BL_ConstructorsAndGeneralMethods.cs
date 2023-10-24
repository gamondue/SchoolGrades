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
        internal string CreateDemoDatabase(string newDatabasePathName, Class currentClass, Class otherClass)
        {
            return dl.CreateDemoDatabase(newDatabasePathName, currentClass, otherClass);
        }
        internal void PurgeDatabase()
        {
            dl.PurgeDatabase(); 
        }
    }
}
