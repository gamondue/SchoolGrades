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
    /// Logica di interazione per frmStudent.xaml
    /// </summary>
    public partial class frmStudent : Window
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        public frmStudent(Student s, bool v)
        {
        }
    }
}
