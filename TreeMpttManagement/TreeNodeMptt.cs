using System;
using System.Collections.Generic;
using System.Text;

namespace gamon.TreeMptt
{
    class TreeNodeMptt<T>
    {
        // TODO use this Class to generalize the TreeViewMppt (also complete it..) 
        // !! currently not used, just an idea !!
        // a Generic tree node with Right and Left node pointers to support Modified Preorder Tree Traversal (MPTT) algorithm 
        int id;
        int parentNode; 
        int leftNodeOld;
        int leftNodeNew;
        int rightNodeOld;
        int rightNodeNew;
        string name;
        string desc;

        public int Id { get => id; set => id = value; }
        public int LeftNodeOld { get => leftNodeOld; set => leftNodeOld = value; }
        public int RightNodeOld { get => rightNodeOld; set => rightNodeOld = value; }
        public int LeftNodeNew { get => leftNodeNew; set => leftNodeNew = value; }
        public int RightNodeNew { get => rightNodeNew; set => rightNodeNew = value; }
        public string Name { get => name; set => name = value; }
        public string Desc { get => desc; set => desc = value; }
        public int ParentNode { get => parentNode; set => parentNode = value; }
   }
}
