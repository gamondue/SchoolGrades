using System;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using gamon;
//using System.Windows.Forms;

namespace SchoolGrades.DbClasses
{
    /// <summary>
    /// This class plays both the roles of Business ad Data Layer and 
    /// Should be separated! Work is (slowly) in progress into the shared projects
    /// BusinessLayer and DataLayer. 
    /// </summary>
    public class DbAndBusiness
    {
        DataLayer dl;
        BusinessLayer bl;
        private string dbName;
        public string DatabaseName { get => dbName; }
        #region constructors
        public DbAndBusiness(string PathAndFile)
        {
            dl = new DataLayer(PathAndFile);
            bl = new BusinessLayer(PathAndFile);
            if (!System.IO.File.Exists(PathAndFile))
            {
                string err = @"[" + PathAndFile + " not in the current nor in the dev directory]";
                Commons.ErrorLog(err); 
                throw new FileNotFoundException(err);
            }
            dbName = PathAndFile;
        }
        #endregion
    }
}
