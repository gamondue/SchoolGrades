using gamon.TreeMptt;
using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDbTests
{
    internal class T_TreeMpttDb_SqlServer
    {
        [SetUp]
        public void SetUp()
        {
            Test_Commons.SetDataLayer();
        }
        [Test]
        public void T_TreeMpttDb_SqlServer_CreateTable()
        {
            TreeMpttDb_SqlServer treeMpttDb_SqlServer = new TreeMpttDb_SqlServer(Test_Commons.dl);
            treeMpttDb_SqlServer.CreateTableTreeMpttDb_SqlServer();
            // chiamata al metodo di creazione della tabella 
            Topic topic = new Topic();
            topic.Name = "OOP";
            topic.Id = 1;
            topic.Date = DateTime.Now;
             Assert.That(!treeMpttDb_SqlServer.TopicExists(topic.Id));
            treeMpttDb_SqlServer.AddTopic(topic);
            Assert.That(treeMpttDb_SqlServer.TopicExists(topic.Id));

        }
        [Test]
        public void T_TreeMpttDb_SqlServer_ReadTopics()
        {
            TreeMpttDb_SqlServer treeMpttDb_SqlServer = new TreeMpttDb_SqlServer(Test_Commons.dl);
        
            int? numberOfTopics = null;
            treeMpttDb_SqlServer.GetTopics(numberOfTopics);
        }

        [Test]
        public void T_AreLeftAndRightConsistent()
        {
            TreeMpttDb_SqlServer treeMpttDb_SqlServer = new TreeMpttDb_SqlServer(Test_Commons.dl);
            using (DbConnection conn = Test_Commons.dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                /// creazione della tabella Flags
                # region flags create table
              cmd.CommandText = @"CREATE TABLE Flags (areLeftRightConsistent bit);";
              cmd.ExecuteNonQuery();
                #endregion

                cmd.CommandText = @"INSERT INTO Flags (areLeftRightConsistent) Values (1);";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Assert.That(treeMpttDb_SqlServer.AreLeftAndRightConsistent());
            }
        }
        [Test]
        public void T_SaveLeftRightConsistent()
        {
            TreeMpttDb_SqlServer treeMpttDb_SqlServer = new TreeMpttDb_SqlServer(Test_Commons.dl);
            treeMpttDb_SqlServer.SaveLeftRightConsistent(true);

        }
        [Test]
       
        public void T_TreeMpttDb_SqlServer_Update()
        {

        }
        [Test]
        public void T_TreeMpttDb_SqlServer_DeleteTable()
        {
            TreeMpttDb_SqlServer treeMpttDb_SqlServer = new TreeMpttDb_SqlServer(Test_Commons.dl);
            
        }
        [Test]
        public void T_TreeMpttDb_SqlServer_DeleteTopics()
        {
            TreeMpttDb_SqlServer treeMpttDb_SqlServer = new TreeMpttDb_SqlServer(Test_Commons.dl);
            List<Topic>? topicsAfter = null;
            List<Topic> topicsDeleted = new List<Topic>();

           
            bool mustSaveLeftAndRight = false;
            bool closeWhenEnding = true;

            treeMpttDb_SqlServer.SaveTreeToDb(topicsAfter,topicsDeleted,mustSaveLeftAndRight,closeWhenEnding);
        }
        [Test]
        public void T_TreeMpttDb_SqlServer_GetNodesByParent()
        {
            TreeMpttDb_SqlServer treeMpttDb_SqlServer = new TreeMpttDb_SqlServer(Test_Commons.dl);
            Topic topic = new Topic();
            topic.Name = "polimorfismo";
            topic.Id = 100000;
            topic.Date = DateTime.Now;
            treeMpttDb_SqlServer.AddTopic(topic);
            Assert.Equals(1,treeMpttDb_SqlServer.GetNodesByParent().Count);
        }
    }
}
