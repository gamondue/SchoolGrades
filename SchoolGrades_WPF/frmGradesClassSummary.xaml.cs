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
    /// Logica di interazione per GradesClassSummary.xaml
    /// </summary>
    public partial class frmGradesClassSummary : Window
    {
        private Class currentClass;
        private GradeType currentGradeType;
        private SchoolSubject currentSubject;

        public frmGradesClassSummary()
        {
            InitializeComponent();
        }

        public frmGradesClassSummary(Class currentClass, GradeType currentGradeType, SchoolSubject currentSubject)
        {
            this.currentClass = currentClass;
            this.currentGradeType = currentGradeType;
            this.currentSubject = currentSubject;
        }
    }
}
