using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace gamon.TreeMptt
{
    internal class TreeMpttDb_SqlServer : TreeMpttDb
    {
        private DbConnection localConnection;

        internal TreeMpttDb_SqlServer(string FullNameOfDatabase) : base(FullNameOfDatabase)
        {

        }
        internal override bool OpenLocalConnectionIfClosed()
        {
            throw new NotImplementedException();
        }
    }
}
