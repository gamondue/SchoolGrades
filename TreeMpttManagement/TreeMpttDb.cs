using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System.Collections.Generic;

namespace gamon.TreeMptt
{
    internal abstract class TreeMpttDb
    {
        internal DataLayer dl;
        internal TreeMpttDb(DataLayer dataLayer)
        {
            dl = dataLayer;
        }
        internal abstract void SaveTreeToDb(List<Topic> ListTopicsAfter, List<Topic> ListTopicsDeleted,
            bool MustSaveLeftAndRight, bool CloseWhenEnding);
        internal abstract void SaveLeftRightConsistent(bool IsConsistent);
        internal abstract bool AreLeftAndRightConsistent();
        internal abstract List<Topic> GetNodesMpttFromDatabase(int? LeftNode, int? RightNode);
        internal abstract List<Topic> GetNodesByParent();
        internal abstract void SaveLeftAndRightToDbMptt();
        internal abstract void UdpateTopicMptt(int? IdTopic, int? LeftNode, int? RightNode);
        internal abstract List<Topic> GetNodesRoots(bool CloseConnectionEnding);
        internal abstract List<Topic> GetNodesChildsByParent(Topic ParentNode, bool CloseConnectionWhenEnding);
        internal abstract List<Topic> GetNodesAncestors(int? LeftNode, int? RightNode);
        internal abstract string GetNodePath(int? LeftNode, int? RightNode);
        internal abstract string GetNodePath(int? idTopic);
        internal abstract List<Topic> FindNodesLike(string SearchText, bool SearchInDescriptions,
            bool SearchWholeWord, bool SearchCaseInsensitive, bool SearchVerbatimString);
        internal abstract void SaveNodesFromScratch(List<Topic> ListTopics);
        internal abstract int? CreateNewTopic(Topic ct);
        internal abstract List<Topic> GetNodesByParentFromDatabase();
        internal abstract void CloseConnection(bool Close);
        internal abstract void CreateTableTreeMpttDb_SqlServer();
        internal abstract void AddTopic(Topic topic);
        internal abstract bool TopicExists(int? topicId);
        internal abstract void GetTopics(int? numberOfTopics);
    }
}
