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

        /// <summary>
        /// Incapsulates the business rules for users' management
        /// part of the class that contains the constructors and the general methods
        /// </summary>
        ///  
        /// // ???? maybe I should NOT pass this parameter, it is database dependant ????
        internal BusinessLayer(string PathAndFile) 
        {
            dl = new DataLayer(PathAndFile);
        }
        internal void NewDatabase(string newDatabasePathName)
        {
            File.Copy(Commons.PathAndFileDatabase, newDatabasePathName);

            // local instance of a DataLayer to operate on a second database 
            DataLayer newDatabaseDl = new DataLayer(newDatabasePathName);

            newDatabaseDl.NewDatabase(); 
            return;
        }
    }
}
