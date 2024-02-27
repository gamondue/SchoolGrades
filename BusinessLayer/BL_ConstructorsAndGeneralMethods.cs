using gamon;
using SchoolGrades.BusinessObjects;
using System;
using System.IO;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        /// <summary>
        /// Business Layer: implements the business rules of the program indipendently from 
        /// the User's Interface
        /// </summary>

        // create the next after the program that is using this has read the configuration file 
        DataLayer dl; // must be instantiated after reading config file! 

        // internal string NameAndPathDatabase { get; }

        internal DataLayer CreateNewDatabaseFromExisting(string NewDatabasePathName)
        {
            ////if (File.Exists(NewDatabasePathName))
            ////    File.Delete(NewDatabasePathName);
            ////File.Copy(Commons.PathAndFileDatabase, NewDatabasePathName);

            ////// local instance of a DataLayer to operate on a second database 

            ////DataLayer newDatabaseDl = new SqLite_DataLayer(NewDatabasePathName);

            ////newDatabaseDl.CreateNewDatabaseFromExisting();
            ////return newDatabaseDl;
            return null;
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
        internal void PurgeDatabase()
        {
            dl.PurgeDatabase();
        }
        internal void WriteConfigData()
        {
            string[] dati = new string[6];
            try
            {
                if (!Directory.Exists(Commons.PathConfig))
                    Directory.CreateDirectory(Commons.PathConfig);
                if (!Directory.Exists(Commons.PathLogs))
                    Directory.CreateDirectory(Commons.PathLogs);
                if (!Directory.Exists(Commons.PathImages))
                    Directory.CreateDirectory(Commons.PathImages);
                //if (!Directory.Exists(Commons.PathStartLinks))
                //    Directory.CreateDirectory(Commons.PathStartLinks);
                if (!Directory.Exists(Commons.PathDatabase))
                    Directory.CreateDirectory(Commons.PathDatabase);
                if (!Directory.Exists(Commons.PathDocuments))
                {
                    if (Commons.PathDocuments != "")
                        Directory.CreateDirectory(Commons.PathDocuments);
                    else
                        Commons.PathDocuments = ".";
                }
                dati[0] = Commons.PathAndFileDatabase;
                dati[1] = Commons.PathImages;
                //dati[2] = Commons.PathStartLinks;
                dati[3] = Commons.PathDatabase;
                dati[4] = Commons.PathDocuments;
                dati[5] = Commons.SaveBackupWhenExiting.ToString();
#if DEBUG
                TextFile.ArrayToFile(Commons.PathAndFileConfig + "_DEBUG", dati, false);
#else
                TextFile.ArrayToFile(Commons.PathAndFileConfig, dati, false);
#endif
            }
            catch (Exception e)
            {
                string err = @"[Error in program's directories] \r\n" + e.Message;
                Commons.ErrorLog(err);
                throw new FileNotFoundException(err);
                //return;
            }
        }
    }
}
