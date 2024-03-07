using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
{
    public class Topic
    {
        //class TreeNodeMpttMapDb
        //{
            // a tree node with Right and Left node pointers to support Modified Preorder Tree Traversal (MPTT) algorithm 
            // maps the fields in the database with "new" and "old" copies, to detect differences 
            // so we can save only the nodes that have changed
            int? id;
            int? parentNodeNew;
            int? parentNodeOld;
            int? leftNodeOld;
            int? leftNodeNew;
            int? rightNodeOld;
            int? rightNodeNew;
            int? childNumberNew;
            int? childNumberOld;
            string name;
            string desc;

            public int? Id { get => id; set => id = value; }
            public int? LeftNodeOld { get => leftNodeOld; set => leftNodeOld = value; }
            public int? RightNodeOld { get => rightNodeOld; set => rightNodeOld = value; }
            public int? LeftNodeNew { get => leftNodeNew; set => leftNodeNew = value; }
            public int? RightNodeNew { get => rightNodeNew; set => rightNodeNew = value; }
            public string Name { get => name; set => name = value; }
            public string Desc { get => desc; set => desc = value; }
            public int? ParentNodeOld { get => parentNodeNew; set => parentNodeNew = value; }
            public int? ParentNodeNew { get => parentNodeOld; set => parentNodeOld = value; }
            public int? ChildNumberOld { get => childNumberOld; set => childNumberOld = value; }
            public int? ChildNumberNew { get => childNumberNew; set => childNumberNew = value; }
            public bool? Changed { get; internal set; }

            // Date field is not in the database, used by the code when it needs 
            // to associate a date to a topic:
            public DateTime Date { get; internal set; }
        //}
    }
}
