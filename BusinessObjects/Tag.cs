using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
{
    class Tag
    {
        private int? idTag = 0;
        private string tagName = "";
        private string desc = "";

        public int? IdTag { get => idTag; set => idTag = value; }
        public string TagName { get => tagName; set => tagName = value; }
        public string Desc { get => desc; set => desc = value; }

        public override string ToString()
        {
            return tagName;
        }
    }

}
