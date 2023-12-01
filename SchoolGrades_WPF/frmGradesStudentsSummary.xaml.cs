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
    /// Logica di interazione per frmGradesStudentsSummary.xaml
    /// </summary>
    public partial class frmGradesStudentsSummary : Window
    {
        public frmGradesStudentsSummary()
        {
            InitializeComponent();
        }

        public frmGradesStudentsSummary(Student currentStudent, string text, GradeType currentGradeType, SchoolSubject selectedItem)
        {
        }
    }
}
