using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal string GetDemoDatabaseName()
        {
            string newDatabasePathName = Commons.PathDatabase;
            if (!Directory.Exists(newDatabasePathName))
                Directory.CreateDirectory(newDatabasePathName);

            string NewDatabasePathAndName = Path.Combine(newDatabasePathName,
                "Demo_SchoolGrades_" + DateTime.Now.Date.ToString("yy-MM-dd") + ".sqlite");
            return NewDatabasePathAndName;
        }
        internal void CreateDemoDatabase(string NewDatabasePathAndName,
            List<Class> classesToRetain)
        {
            // local instance of a DataLayer to operate on a second database 
            DataLayer newDatabaseDl = Commons.SetDataLayer(NewDatabasePathAndName);
            File.Copy(Commons.PathAndFileDatabase, NewDatabasePathAndName);

            // erase all the data of classes other than those passed 
            dl.EraseAllNotConcerningDataOfOtherClasses(newDatabaseDl, classesToRetain);
            dl.CreateDemoDataInDatabase(newDatabaseDl, classesToRetain);
        }
    }
}
