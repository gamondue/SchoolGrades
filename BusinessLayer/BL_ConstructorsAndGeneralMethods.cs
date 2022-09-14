using gamon;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        internal string NameAndPathDatabase { get; }

        /// <summary>
        /// Incapsulates the business rules for users' management
        /// part of the class that contains the constructors and the general methods
        /// </summary>
        ///  
        /// // ???? maybe we should NOT pass this parameter, it is database dependant ????
        internal BusinessLayer(string PathAndFile) 
        {
            dl = Commons.dl;
            if (dl.NameAndPathDatabase == null)
            {
                this.NameAndPathDatabase = null;
                return; 
            }
            this.NameAndPathDatabase = PathAndFile;
        }
        internal void CreateNewDatabase(string NewDatabasePathName)
        {
            File.Copy(Commons.PathAndFileDatabase, NewDatabasePathName);

            // local instance of a DataLayer to operate on a second database 
            DataLayer newDatabaseDl = new DataLayer(NewDatabasePathName);

            newDatabaseDl.CreateNewDatabase(); 
            return;
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
