using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    class Topic : gamon.TreeMptt.TreeNodeMpttMapDb
    {
        // Date field is not in the database, used by the code when it needs 
        // to associate a date to a topic:
        public DateTime Date {get; internal set; }

    }
}
