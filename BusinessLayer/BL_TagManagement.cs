using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    internal partial class  BusinessLayer
    {
        internal List<Tag> GetTagsContaining(string text)
        {
            return dl.GetTagsContaining(text);
        }
        internal void SaveTag(Tag currentTag)
        {
            dl.SaveTag(currentTag);
        }
        internal int? CreateNewTag(Tag currentTag)
        {
            return dl.CreateNewTag(currentTag);
        }
        internal List<Tag> TagsOfAQuestion(int? IdQuestion)
        {
            return dl.TagsOfAQuestion(IdQuestion); 
        }
    }
}
