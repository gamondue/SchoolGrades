using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NUnitDbTests
{
    internal class T_LinkManagement
    {
        [SetUp]
        public void SetUp()
        {
            Test_Commons.SetDataLayer();
        }

        [Test]
        public void T_LinkManagement_Create()
        {
            // create table
            Test_Commons.dl.CreateTableLinkManagement();
            //{
            //    throw new NotImplementedException();
            //};
            // !!!! TODO !!!! Assert that the table exists
            //Assert.That(Test_Commons.dl.exist)
            // populate table 
        }
        [Test]
        public void T_LinkManagement_Read()
        {
            Test_Commons.dl.AddLinkToPreviousYearPhoto(467, "IdPreviousSchoolYear", "IdNextSchoolYear");
            Class c = new Class();
            Test_Commons.dl.GetStartLinksOfClass(c);
        }
        [Test]
        public void T_LinkManagement_Update()
        {
            Class c = new Class();
            Test_Commons.dl.UpdatePathStartLinkOfClass(c, "path foto");

            Test_Commons.dl.SaveStartLink(2, 3, "SchoolYear", "StartLink", "Desc");
        }

        [Test]
        public void T_LinkManagement_Delete()
        {
            Class c = new Class();
            Student student = new Student();
            Test_Commons.dl.LinkOnePhoto(student, c, "RelativePathAndFilePhoto");

            Test_Commons.dl.DeleteStartLink(3);
        }
    }

}
