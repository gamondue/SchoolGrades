using SchoolGrades.BusinessObjects;
using System.Windows;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for Topics.xaml
    /// </summary>
    public partial class frmTopics : Window
    {
        public enum TopicsFormType
        {
            ShowAndManagement,
            HighlightTopics,
            ImportWithErase,
            ImportWithoutErase,
            SearchTopics,
            ChooseTopic
        }
        public frmTopics()
        {
            InitializeComponent();
        }

        public frmTopics(object highlightTopics, Class currentClass, SchoolSubject currentSubject, Question currentQuestion, object value, frmMain frmMain)
        {
        }
    }
}
