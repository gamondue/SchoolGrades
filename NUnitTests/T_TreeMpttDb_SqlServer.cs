using gamon.TreeMptt;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
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
        public void T_TreeMpttDb_SqlServer_Create()
        {
            TreeMpttDb_SqlServer treeMpttDb_SqlServer = new TreeMpttDb_SqlServer(Test_Commons.dl);
            treeMpttDb_SqlServer.CreateTableTreeMpttDb_SqlServer();
            // chiamata al metodo di creazione della tabella 
            Topic topic = new Topic();
            topic.Name = "OOP";
            topic.Id = 1;
            topic.Date = DateTime.Now;
            // Assert.That(!treeMpttDb_SqlServer.TopicExists(topic.Id));
            treeMpttDb_SqlServer.AddTopic(topic);
            Assert.That(treeMpttDb_SqlServer.TopicExists(topic.Id));

        }
        [Test]
        public void T_TreeMpttDb_SqlServer_Read()
        {

        }
        [Test]
        public void T_TreeMpttDb_SqlServer_Update()
        {

        }
        [Test]
        public void T_TreeMpttDb_SqlServer_Delete()
        {

        }
    }
}
