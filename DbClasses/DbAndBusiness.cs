using System;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using gamon;
using System.Windows.Forms;

namespace SchoolGrades.DbClasses
{
    /// <summary>
    /// This class plays both the roles of Business ad Data Layer and 
    /// should be separated! Work is in progress into the shared projects
    /// BusinessLayer and DataLayer
    /// </summary>
    public class DbAndBusiness
    {
        DataLayer.DataLayer dl = new DataLayer.DataLayer();
        //private string dbName;

        #region constructors
        public DbAndBusiness()
        {
            dl = new DataLayer.DataLayer();

            //if (!System.IO.File.Exists(Commons.PathAndFileDatabase))
            //{
            //    string err = @"[" + Commons.PathAndFileDatabase + " not in the current nor in the dev directory]";
            //    Commons.ErrorLog(err, true);
            //    //throw new FileNotFoundException(err);
            //}
            //dbName = Commons.PathAndFileDatabase;
        }
        public DbAndBusiness(string PathAndFile)
        {
            dl = new DataLayer.DataLayer(PathAndFile);

            //if (!System.IO.File.Exists(PathAndFile))
            //{
            //    string err = @"[" + PathAndFile + " not in the current nor in the dev directory]";
            //    Commons.ErrorLog(err, true);
            //    throw new FileNotFoundException(err);
            //}
            //dbName = PathAndFile;
        }
        #endregion             
    }
}
