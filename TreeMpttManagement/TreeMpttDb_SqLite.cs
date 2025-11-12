using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Xml.Linq;

namespace gamon.TreeMptt
{
    internal class TreeMpttDb_SqLite : TreeMpttDb
    {
        internal TreeMpttDb_SqLite(string FullNameOfDatabase) : base(FullNameOfDatabase)
        {
        }

        // opening a local connection is specific to the DBMS, so it is implemented here
        internal override bool OpenLocalConnectionIfClosed()
        {
            string ConnectionString = "Data Source=" + base.fullNameOfDatabase + ";Mode=ReadWriteCreate";
            bool hasLocalConnectionBeenOpenedByThisMethod = false;
            if (localDbConnection == null || localDbConnection.State != ConnectionState.Open)
            {
                hasLocalConnectionBeenOpenedByThisMethod = true;
                // open the SQLite local connection 
                try
                {
                    localDbConnection = new SqliteConnection(ConnectionString);
                    localDbConnection.Open();
                }
                catch (Exception ex)
                {
#if DEBUG
                    //Get call stack
                    StackTrace stackTrace = new StackTrace();
                    //Log calling method name
                    Commons.ErrorLog("Connect Method in: " + stackTrace.GetFrame(1).GetMethod().Name);
#endif
                    Commons.ErrorLog("Error connecting to the database: " + ex.Message + "\r\nFile SQLIte>: " + Commons.PathAndFileDatabase + " " + "\n");
                    localDbConnection = null;
                }
            }
            return hasLocalConnectionBeenOpenedByThisMethod;
        }
        /// <summary>
        /// Updates the left and right node values for a given parent node and its descendants in a tree structure.
        /// </summary>
        /// <remarks>This method traverses the tree starting from the specified <paramref name="ParentNode"/> and
        /// calculates the left and right node values for each node. If the calculated values differ from the existing values,
        /// the database is updated accordingly. The traversal uses a modified tree traversal algorithm and processes all child
        /// nodes recursively. <para> The method relies on external conditions to determine whether processing can continue, and
        /// it will terminate early if those conditions are not met. </para></remarks>
        /// <param name="ParentNode">The parent node whose left and right values are to be updated, along with its descendants.</param>
        /// <param name="NodeCount">A reference to the current node count, which is incremented during traversal. This value is used to calculate the
        /// left and right node values for each node.</param>
    }
}
