using System;
using System.Collections.Generic;
using System.Windows.Forms;
using gamon.TreeMptt;
using SchoolGrades.BusinessObjects;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal Lesson GetLastLesson(Lesson currentLesson)
        {
            return dl.GetLastLesson(currentLesson);
        }
        internal List<Topic> GetTopicsOfLesson(int? idLesson)
        {
            return dl.GetTopicsOfLesson(idLesson);
        }
        internal List<Lesson> GetLessonsOfClass(Class currentClass, string idSchoolSubject)
        {
            return dl.GetLessonsOfClass(currentClass, idSchoolSubject, false);
        }
        internal Lesson GetLessonInDate(Class currentClass, string idSchoolSubject, DateTime value)
        {
            return dl.GetLessonInDate(currentClass, idSchoolSubject, value);
        }
        internal void SaveLesson(Lesson currentLesson)
        {
            dl.SaveLesson(currentLesson);
        }
        internal object GetTopicsOfOneLessonOfClass(Class currentClass, Lesson currentLesson)
        {
            return dl.GetTopicsOfOneLessonOfClass(currentClass, currentLesson);
        }
        internal void SaveTopicsOfLesson(int? idLesson, List<Topic> topicsOfTheLesson)
        {
            dl.SaveTopicsOfLesson(idLesson, topicsOfTheLesson);
        }
        internal List<Image> GetListLessonsImages(Lesson currentLesson)
        {
            return dl.GetLessonsImagesList(currentLesson);
        }
        internal void EraseLesson(int? IdLesson, bool AlsoEraseImageFiles)
        {
            dl.EraseLesson(IdLesson, AlsoEraseImageFiles); 
        }
        internal int? NewLesson(Lesson currentLesson)
        {
            return dl.NewLesson(currentLesson); 
        }
        internal void LinkOneImageToLesson(Image currentImage, Lesson currentLesson)
        {
            dl.LinkOneImageToLesson(currentImage, currentLesson);
        }
        internal void DeleteNodeSelected(TreeMptt topicTreeMptt)
        {
            topicTreeMptt.DeleteNodeSelected();
        }

        internal void FindNodes(TreeMptt topicTreeMptt, string txtTopicSearchString, bool chkMarkAllTopicsFound, bool chkSearchInDescriptions, bool chkAllWord, bool chkCaseInsensitive)
        {
            topicTreeMptt.FindNodes(txtTopicSearchString, chkMarkAllTopicsFound,
                chkSearchInDescriptions,
                chkAllWord, chkCaseInsensitive);
        }

        internal void FindUnderNodes(TreeMptt topicTreeMptt, string txtTopicSearchString, bool chkMarkAllTopicsFound)
        {
            topicTreeMptt.FindNodeUnderNode(txtTopicSearchString, chkMarkAllTopicsFound);
        }

        internal void SaveTreeChanges(TreeMptt topicTreeMptt)
        {
            topicTreeMptt.SaveTreeFromTreeViewByParent();
        }

        internal void AddNewNode(TreeMptt topicTreeMptt, bool value)
        {
            //if "value" is true it will be added a "new son", is value is false it will be added a "new brother"
            topicTreeMptt.AddNewNode("Nuovo argomento", value);
        }

        internal void HighlineNodesInList(TreeMptt topicTreeMptt, TreeView trwTopics, List<Topic> listDone, int dummy, bool dummy2)
        {
            topicTreeMptt.HighlightNodesInList(trwTopics.Nodes[0], listDone, ref dummy, ref dummy2);
        }

    }
}
