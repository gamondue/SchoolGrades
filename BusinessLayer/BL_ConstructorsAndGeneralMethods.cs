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

        public string NameAndPathDatabase { get; }

        /// <summary>
        /// Incapsulates the business rules for users' management
        /// part of the class that contains the constructors and the general methods
        /// </summary>
        ///  
        internal BusinessLayer(string PathAndFile) 
        {
            dl = new DataLayer(PathAndFile);
            if (dl.NameAndPathDatabase == null)
            {
                this.NameAndPathDatabase = null;
                return; 
            }
            this.NameAndPathDatabase = PathAndFile;
        }
        internal void CreateNewDatabase(string newDatabasePathName)
        {
            File.Copy(Commons.PathAndFileDatabase, newDatabasePathName);

            // local instance of a DataLayer to operate given database 
            DataLayer newDatabaseDl = new DataLayer(newDatabasePathName);

            newDatabaseDl.CreateNewDatabase(); 
            return;
        }
    }
}
