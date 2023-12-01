using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmGroups.xaml
    /// </summary>
    public partial class frmGroups : Window
    {
        public frmGroups()
        {
            InitializeComponent();
        }

        public frmGroups(List<Student> groupsList, Class currentClass, SchoolSubject currentSubject, GradeType currentGradeType)
        {
        }
    }
}
