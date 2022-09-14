using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
{
    public class Image
    {
        int? idImage;
        string imagePath;
        string caption;
        public string Caption { get => caption; set => caption = value; }
        public string RelativePathAndFilename { get => imagePath; set => imagePath = value; }
        public int? IdImage { get => idImage; set => idImage = value; }
    }
}
