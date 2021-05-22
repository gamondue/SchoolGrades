﻿namespace SchoolGrades.DbClasses
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
