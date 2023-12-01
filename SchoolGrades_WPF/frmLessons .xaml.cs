using SchoolGrades.BusinessObjects;
using System.Windows;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class frmLessons : Window
    {
        public frmLessons()
        {
            InitializeComponent();
        }

        public frmLessons(Class currentClass, SchoolSubject selectedItem, bool v)
        {
        }
    }
}
