using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDbTests
{
    internal class T_Serv_PeriodManagement
    {
        [SetUp]
        public void Setup()
        {
            Test_Commons.SetDataLayer();
        }
        [Test]
        public void T_SchoolYears_Create()
        {
            // create table
            DateTime Date = DateTime.Now;
            string IdSchoolYear = "";
            SchoolPeriod SchoolPeriod = new SchoolPeriod();

            Test_Commons.dl.GetSchoolPeriodsOfDate(Date);
            Test_Commons.dl.GetSchoolPeriods(IdSchoolYear); 
            Test_Commons.dl.CreateSchoolPeriod(SchoolPeriod);                           
            // !!!! TODO !!!! Assert that the table exists
            //Assert.That(Test_Commons.dl.exist)
            // populate table 
            SchoolYear sy = new();
            sy.IdSchoolYear = "23-24";
            sy.ShortDescription = "2023-2024";
            sy.Notes = "Anno scolastico introdotto per sola prova";
            Assert.That(!Test_Commons.dl.SchoolYearExists(sy.IdSchoolYear));
            Test_Commons.dl.AddSchoolYear(sy);
            Assert.That(Test_Commons.dl.SchoolYearExists(sy.IdSchoolYear));
        }
        [Test]
        public void T_SchoolYears_Read()
        {
            DbDataReader Row = new DbDataReader();
            SchoolPeriod SchoolPeriod = new SchoolPeriod();
            string SchoolYear = "";
            string IdSchoolPeriod = "";
            // test of DataLayer Methods that read data from table SchoolYears
            Test_Commons.dl.GetOneSchoolPeriodFromRow(Row);
            Test_Commons.dl.SaveSchoolPeriod(SchoolPeriod);
            Test_Commons.dl.FindIfPeriodsAreAlreadyExisting(SchoolYear);
            Test_Commons.dl.FindIfIdIsAlreadyExisting(IdSchoolPeriod);
            Test_Commons.dl.GetSchoolPeriodTypes();
        }
        [Test]
        public void T_SchoolYears_Update()
        {
            SchoolPeriod SchoolPeriod = new SchoolPeriod();
            // test of DataLayer Methods that update data from table SchoolYears
            Test_Commons.dl.UpdateSchoolPeriod(SchoolPeriod); 
        }
        [Test]
        public void T_SchoolYears_Delete()
        {
            string IdSchoolPeriod = "";
            // test of DataLayer Methods that delete data from table SchoolYears
            Test_Commons.dl.DeleteSchoolPeriod(IdSchoolPeriod);
        }
    }
}


